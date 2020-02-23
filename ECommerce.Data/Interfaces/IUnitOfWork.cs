using System;

namespace ECommerce.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        int Complete();
    }
}