namespace INF27507_Boutique_En_Ligne.Services
{
    public interface IServicesFactory
    {
        IDatabaseAdapter GetDatabaseService();
        IAuthentificationAdapter GetAuthService();
    }
}
