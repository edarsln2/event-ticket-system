namespace EventTicketSystem.WebApi.ApplicationStorage
{
    public class ApplicationStorage
    {
        private readonly Dictionary<Type, object> _application;

        public ApplicationStorage(EventApplication eventApplication, UserApplication userApplication, PurchaseApplication purchaseApplication)
        {
            _application = new Dictionary<Type, object>
            {
                { typeof(EventApplication), eventApplication },
                { typeof(UserApplication), userApplication },
                { typeof(PurchaseApplication), purchaseApplication }
            };
        }

        public object GetApplication(Type type)
        {
            return _application[type];
        }
    }
}
