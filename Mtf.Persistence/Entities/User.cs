using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mtf.Persistence.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(PersistenceConstants.MaxLengthOfStrings)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
