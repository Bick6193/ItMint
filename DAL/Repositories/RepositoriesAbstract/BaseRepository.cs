using DAL.Context;


namespace DAL.Repositories.RepositoriesAbstract
{
    public class BaseRepository
    {
        protected ApplicationContext Context { get; }

        protected BaseRepository(ApplicationContext context)
        {
            Context = context;
        }
    }
}
