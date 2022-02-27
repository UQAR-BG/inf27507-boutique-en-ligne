using INF27507_Boutique_En_Ligne.Services.Database;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class ServicesFactory : IServicesFactory
    {
        private static Mutex mutex = new Mutex();
        private static Lazy<ServicesFactory> instance;

        private readonly IDatabaseAdapter database;

        public static ServicesFactory getInstance()
        {
            if (instance == null)
            {
                mutex.WaitOne();

                if (instance == null)
                    instance = new Lazy<ServicesFactory>(() => new ServicesFactory());

                mutex.ReleaseMutex();
            }
                
            return instance.Value;
        }

        private ServicesFactory()
        {
            database = new MySQLDatabaseAdapter();
        }

        public IDatabaseAdapter GetDatabaseService()
        {
            return database;
        }
    }
}
