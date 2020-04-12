using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Data.Interfaces;
using ECommerce.Helper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Service.HostedServices
{
    public class OutgoingEmailService : IHostedService, IDisposable
    {
        private bool _cancelRequested = false;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly Helper.MailHelper.SMTP _smtp = new MailHelper.SMTP()
        {
            Email = Data.Singletons.AppSettingsDto.AppSetting.SMTP.Email,
            Password = Data.Singletons.AppSettingsDto.AppSetting.SMTP.Password,
            Server = Data.Singletons.AppSettingsDto.AppSetting.SMTP.Server,
            Port = Data.Singletons.AppSettingsDto.AppSetting.SMTP.Port
        };

        public OutgoingEmailService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Thread(DoWork) {IsBackground = true, Name = "OutgoingEmailService"}.Start();

            return Task.CompletedTask;
        }

        public void DoWork()
        {
            while (true)
            {
                if (_cancelRequested) break;

                using (IServiceScope serviceScope = _serviceScopeFactory.CreateScope())
                {
                    using (IUnitOfWork unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                    {
                        var outgoingEmails = unitOfWork.OutgoingEmailRepository.Query().Where(a =>
                            a.Active &&
                            !a.Deleted &&
                            (a.OutgoingEmailStateId == Data.Enum.OutgoingEmailState.Pending ||
                             (a.OutgoingEmailStateId == Data.Enum.OutgoingEmailState.Fail && a.TryCount < 5)));

                        foreach (var outgoingEmail in outgoingEmails)
                        {
                            var outgoingEmailDto = new Helper.MailHelper.OutgoingEmail()
                            {
                                To = outgoingEmail.To,
                                Subject = outgoingEmail.Subject,
                                Body = outgoingEmail.Body,
                                Id = outgoingEmail.Id
                            };
                            Helper.MailHelper.Send(SendCompletedCallback, _smtp, outgoingEmailDto);
                            outgoingEmail.TryCount++;
                            outgoingEmail.OutgoingEmailStateId = Data.Enum.OutgoingEmailState.Sending;
                        }

                        unitOfWork.Complete();
                    }
                }

                Thread.Sleep(1000);
            }
        }
        
        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            using (IServiceScope serviceScope = _serviceScopeFactory.CreateScope())
            {
                using (IUnitOfWork unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                {
                    int id = (int)e.UserState;

                    var outgoingEmail = unitOfWork.OutgoingEmailRepository.Get(id);

                    if (e.Cancelled)
                    {
                        //mail gönderimi iptal edildi
                        outgoingEmail.OutgoingEmailStateId = Data.Enum.OutgoingEmailState.Fail;
                    }
                    else if (e.Error != null)
                    {
                        //gönderim sırasında hata oluştu
                        outgoingEmail.OutgoingEmailStateId = Data.Enum.OutgoingEmailState.Fail;
                    }
                    else
                    {
                        //mail başarıyla gönderildi
                        outgoingEmail.OutgoingEmailStateId = Data.Enum.OutgoingEmailState.Sent;
                    }

                    unitOfWork.Complete();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancelRequested = true;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _cancelRequested = true;
        }
    }
}