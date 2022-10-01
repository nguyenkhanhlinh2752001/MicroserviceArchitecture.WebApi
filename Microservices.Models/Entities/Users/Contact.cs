using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Microservices.Models.Entities.Users
{
    public class Contact : BaseEntity
    {
        public int UserID { get; set; }

        [IgnoreDataMember]
        public User User { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string Type { get; set; }
    }
}