using System.ComponentModel.DataAnnotations;

namespace Microservices.Models.Entities.Users
{
    public class Image : BaseEntity
    {
        [Required]
        public string File { get; set; }
    }
}