namespace INF27507_Boutique_En_Ligne.Services
{
    public abstract class ModelHandler : IModelHandler
    {
        protected readonly IDatabaseAdapter _database;

        public ModelHandler()
        {
            _database = ServicesFactory.getInstance().GetDatabaseService();
        }

        public abstract void ExecuteOperation(ModelWrapper modelWrapper);

        public abstract void Operation();
    }
}
