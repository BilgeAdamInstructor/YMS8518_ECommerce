using ECommerce.Data.Contexts;
using ECommerce.Data.Interfaces;

namespace ECommerce.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }
        public IOutgoingEmailRepository OutgoingEmailRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IMenuRepository MenuRepository { get; set; }
        public ILogRepository LogRepository { get; set; }
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            UserRepository = new UserRepository(_dataContext);
            OutgoingEmailRepository = new OutgoingEmailRepository(_dataContext);
            CategoryRepository = new CategoryRepository(_dataContext);
            MenuRepository = new MenuRepository(_dataContext);
            LogRepository = new LogRepository(_dataContext);
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