using ECommerce.Data.Contexts;
using ECommerce.Data.Interfaces;

namespace ECommerce.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }
        public IOutgoingEmailRepository OutgoingEmailRepository { get; set; }
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            UserRepository = new UserRepository(_dataContext);
            OutgoingEmailRepository = new OutgoingEmailRepository(_dataContext);
        }

        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}