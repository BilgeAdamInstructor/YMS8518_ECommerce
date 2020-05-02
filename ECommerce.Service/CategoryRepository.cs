namespace ECommerce.Service
{
    public class CategoryRepository : Repository<Data.Entities.Category>, Data.Interfaces.ICategoryRepository
    {
        private readonly Data.Contexts.DataContext _dataContext;

        public CategoryRepository(Data.Contexts.DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}