using System.ComponentModel.DataAnnotations;

namespace Microservices.Models.Entities.Users
{
    public class User : BaseEntity
    {
        [Required]
        public string AuthID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Profile { get; set; }

        public DateTimeOffset? BirthDate { get; set; }
        public Image Avatar { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}