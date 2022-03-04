using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class SimpleSessionService
    {
        private readonly IDatabaseAdapter _database;

        public SimpleSessionService(IDatabaseAdapter database)
        {
            _database = database;
        }

        public void SetDefaultUser(ISession session)
        {
            if (session.GetInt32("UserId") == null)
            {
                session.SetInt32("UserId", 1);
                session.SetString("Username", "Default-User");
                session.SetString("UserType", UserType.Client.ToString());
            }
        }

        public bool IsAuthenticated(ISession session)
        {
            return session.GetInt32("UserId") != null && session.GetString("UserType") != null;
        }

        public bool IsAuthenticatedAsClient(ISession session)
        {
            return IsAuthenticated(session) && session.GetString("UserType").Equals(UserType.Client.ToString());
        }

        public bool IsAuthenticatedAsSeller(ISession session)
        {
            return IsAuthenticated(session) && session.GetString("UserType").Equals(UserType.Seller.ToString());
        }

        public int GetClientIdIfAuthenticated(ISession session)
        {
            int clientId = 0;

            if (IsAuthenticatedAsClient(session))
            {
                Client client = _database.GetClient((int)session.GetInt32("UserId"));
                if (client != null)
                    clientId = client.Id;
            }

            return clientId;
        }

        public int GetSellerIdIfAuthenticated(ISession session)
        {
            int sellerId = 0;

            if (IsAuthenticatedAsSeller(session))
            {
                Seller seller = _database.GetSeller((int)session.GetInt32("UserId"));
                if (seller != null)
                    sellerId = seller.Id;
            }

            return sellerId;
        }
    }
}
