using Mtf.Persistence.Entities;
using Mtf.Persistence.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Mtf.Persistence.Repositories
{
    [Export]
    public class UserRolesRepository : RepositoryBase
    {
        [Import]
        private Lazy<UsersRepository> usersRepository;

        [Import]
        private Lazy<RolesRepository> rolesRepository;

        [ImportingConstructor]
        public UserRolesRepository(
            Lazy<UsersRepository> usersRepository,
            Lazy<RolesRepository> rolesRepository,
            Database mtfDatabase)
            : base(mtfDatabase)
        {
            this.usersRepository = usersRepository;
            this.rolesRepository = rolesRepository;
        }

        public Role Get(string name)
        {
            return MtfDatabase.Roles.SingleOrDefault(user => user.Name == name);
        }

        public void AddUserToRole(User user, Role role)
        {
            var userRole = MtfDatabase.UserRoles.Find(user.Id, role.Id);
            if (userRole == null)
            {
                MtfDatabase.UserRoles.Add(new UserRole
                {
                    User = user,
                    Role = role
                });

                MtfDatabase.SaveChanges();
                PermissionHandler.SetPrincipals(user);
            }
        }

        public void RemoveUserFromRole(User user, Role role)
        {
            var userRole = MtfDatabase.UserRoles.Find(user.Id, role.Id);
            if (userRole != null)
            {
                MtfDatabase.UserRoles.Remove(userRole);
                MtfDatabase.SaveChanges();
                PermissionHandler.SetPrincipals(user);
            }
        }

        public void CreateDefaultRolesForUser(User user)
        {
            var defaultRoleNames = MtfDatabase.Users.Any() ? RoleDistributor.GetAdvancedRoles() : RoleDistributor.GetBasicRoles();
            foreach (var roleName in defaultRoleNames)
            {
                var role = rolesRepository.Value.Get(roleName.ToString());
                AddUserToRole(user, role);
            }
        }
    }
}
