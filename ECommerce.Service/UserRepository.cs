using ECommerce.Data.Entities;
using System;
using System.Linq;

namespace ECommerce.Service
{
    public class UserRepository : Repository<Data.Entities.User>, Data.Interfaces.IUserRepository
    {
        private readonly Data.Contexts.DataContext _dataContext;

        public UserRepository(Data.Contexts.DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public User GetByAutoLoginKey(Guid autoLoginKey)
        {
            return _dataContext.Users.SingleOrDefault(a => a.AutoLoginKey == autoLoginKey);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _dataContext.Users.SingleOrDefault(a => a.Email == email && a.Password == Helper.CryptoHelper.Sha1(password));
        }
    }
}