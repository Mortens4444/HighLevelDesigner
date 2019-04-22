using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mtf.Persistence.Entities
{
    public class UserRole
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        public override string ToString()
        {
            return $"{User} is member of {Role} role";
        }
    }
}
