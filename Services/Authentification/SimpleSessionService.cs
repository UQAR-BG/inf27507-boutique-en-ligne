namespace INF27507_Boutique_En_Ligne.Services
{
    public class SimpleSessionService
    {
        public void SetDefaultUser(ISession session)
        {
            if (session.GetInt32("UserId") == null)
            {
                session.SetInt32("UserId", 1);
                session.SetString("Username", "Default-User");
                session.SetString("UserType", "Client");
            }
        }

        public bool IsAuthenticated(ISession session)
        {
            return session.GetInt32("UserId") != null && session.GetString("UserType") != null;
        }

        public bool IsAuthenticatedAsClient(ISession session)
        {
            return IsAuthenticated(session) && session.GetString("UserType") == "Client";
        }
    }
}
