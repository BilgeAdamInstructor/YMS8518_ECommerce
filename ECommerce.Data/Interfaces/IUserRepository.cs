namespace ECommerce.Data.Interfaces
{
    public interface IUserRepository : IRepository<Entities.User>
    {
        Entities.User GetByEmailAndPassword(string email, string password);
        Entities.User GetByAutoLoginKey(System.Guid autoLoginKey);
        Entities.User GetById(int id);
    }
}