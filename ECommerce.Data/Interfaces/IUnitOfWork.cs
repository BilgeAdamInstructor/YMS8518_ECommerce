using System;

namespace ECommerce.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        IOutgoingEmailRepository OutgoingEmailRepository { get; set; }
        int Complete();
    }
}