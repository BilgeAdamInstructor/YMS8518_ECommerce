namespace ECommerce.Service
{
    public class MenuRepository : Repository<Data.Entities.Menu>, Data.Interfaces.IMenuRepository
    {
        private readonly Data.Contexts.DataContext _dataContext;

        public MenuRepository(Data.Contexts.DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}