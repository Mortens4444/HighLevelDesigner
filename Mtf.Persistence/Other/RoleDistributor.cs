using System.Collections.Generic;

namespace Mtf.Persistence.Other
{
    public static class RoleDistributor
    {
        public static IList<RoleName> GetBasicRoles()
        {
            return new List<RoleName>
            {
                RoleName.AbleToExit
            };
        }

        public static IList<RoleName> GetAdvancedRoles()
        {
            var result = GetBasicRoles();
            result.Add(RoleName.CanAddUserToGroup);
            result.Add(RoleName.CanCreateGroup);
            result.Add(RoleName.CanCreateUser);
            return result;
        }
    }
}
