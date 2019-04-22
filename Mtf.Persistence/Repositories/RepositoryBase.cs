using System.ComponentModel.Composition;

namespace Mtf.Persistence.Repositories
{
    public class RepositoryBase
    {
        [Import]
        protected Database MtfDatabase;

        [ImportingConstructor]
        public RepositoryBase(Database mtfDatabase)
        {
            MtfDatabase = mtfDatabase;
        }
    }
}
