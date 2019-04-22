using Mtf.Persistence.Entities;
using Mtf.Persistence.Other;
using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace Mtf.Persistence.Repositories
{
    [Export]
    public class RolesRepository : RepositoryBase
    {
        [Import]
        private Lazy<UsersRepository> usersRepository;

        [ImportingConstructor]
        public RolesRepository(
            Lazy<UsersRepository> usersRepository,
            Database mtfDatabase)
            : base(mtfDatabase)
        {
            this.usersRepository = usersRepository;
        }

        public Role Get(string name)
        {
            if (!MtfDatabase.Roles.Any())
            {
                CreateRoles();
            }

            return MtfDatabase.Roles.SingleOrDefault(user => user.Name == name);
        }

        public void CreateRoles()
        {
            var roleNames = System.Enum.GetNames(typeof(RoleName));
            foreach (var roleName in roleNames)
            {
                CreateRole(roleName);
            }
            MtfDatabase.SaveChanges();
        }

        private Role CreateRole(string name)
        {
            Entities.Role result = new Entities.Role { Name = name };
            MtfDatabase.Roles.Add(result);
            return result;
        }
    }
}
