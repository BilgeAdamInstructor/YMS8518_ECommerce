namespace ECommerce.Data.Interfaces
{
    public interface IUserRepository : IRepository<Entities.User>
    {
        Entities.User GetByEmailAndPassword(string email, string password);
    }
}