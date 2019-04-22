using Mtf.Persistence.Entities;
using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace Mtf.Persistence.Repositories
{
    [Export]
    public class UsersRepository : RepositoryBase
    {
        [Import]
        private Lazy<OptionsRepository> optionsRepository;

        [Import]
        private Lazy<UserRolesRepository> userRolesRepository;

        [ImportingConstructor]
        public UsersRepository(
            Lazy<OptionsRepository> optionsRepository,
            Lazy<UserRolesRepository> userRolesRepository,
            Database mtfDatabase)
            : base(mtfDatabase)
        {
            this.optionsRepository = optionsRepository;
            this.userRolesRepository = userRolesRepository;
        }

        public User Get(string name)
        {
            var result = MtfDatabase.Users.SingleOrDefault(user => user.Name == name);
            if (result != null)
            {
                PermissionHandler.SetPrincipals(result);
            }
            return result;
        }

        public User GetOrCreate(string name)
        {
            var result = Get(name);
            if (result != null)
            {
                return result;
            }
            result = new User { Name = name };
            MtfDatabase.Users.Add(result);
            optionsRepository.Value.CreateDefaultOptionsForUser(result);
            userRolesRepository.Value.CreateDefaultRolesForUser(result);
            PermissionHandler.SetPrincipals(result);

            MtfDatabase.SaveChanges();
            return result;
        }
    }
}
