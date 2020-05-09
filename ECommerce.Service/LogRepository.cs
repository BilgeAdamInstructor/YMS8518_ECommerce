namespace ECommerce.Service
{
    public class LogRepository : Repository<Data.Entities.Log>, Data.Interfaces.ILogRepository
    {
        private readonly Data.Contexts.DataContext _dataContext;

        public LogRepository(Data.Contexts.DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}