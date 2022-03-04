namespace INF27507_Boutique_En_Ligne.Services
{
    public class SimpleSessionAuthAdapter : IAuthentificationAdapter
    {
        private readonly SimpleSessionService _sessionService;

        public SimpleSessionAuthAdapter(IDatabaseAdapter database)
        {
            _sessionService = new SimpleSessionService(database);
        }

        public void SetDefaultUser(ISession session)
        {
            _sessionService.SetDefaultUser(session);
        }

        public bool IsAuthenticated(ISession session)
        {
            return _sessionService.IsAuthenticated(session);
        }

        public bool IsAuthenticatedAsClient(ISession session)
        {
            return _sessionService.IsAuthenticatedAsClient(session);
        }

        public bool IsAuthenticatedAsSeller(ISession session)
        {
            return _sessionService.IsAuthenticatedAsSeller(session);
        }

        public int GetClientIdIfAuthenticated(ISession session)
        {
            return _sessionService.GetClientIdIfAuthenticated(session);
        }

        public int GetSellerIdIfAuthenticated(ISession session)
        {
            return _sessionService.GetSellerIdIfAuthenticated(session);
        }
    }
}
