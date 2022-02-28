namespace INF27507_Boutique_En_Ligne.Services
{
    public class SimpleSessionAuthAdapter : IAuthentificationAdapter
    {
        private readonly SimpleSessionService _sessionService;

        public SimpleSessionAuthAdapter()
        {
            _sessionService = new SimpleSessionService();
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
    }
}
