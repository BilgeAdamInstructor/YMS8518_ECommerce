namespace ECommerce.Service
{
    public class OutgoingEmailRepository : Repository<Data.Entities.OutgoingEmail>, Data.Interfaces.IOutgoingEmailRepository
    {
        private readonly Data.Contexts.DataContext _dataContext;

        public OutgoingEmailRepository(Data.Contexts.DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}