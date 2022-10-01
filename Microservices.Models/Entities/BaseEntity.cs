using System.ComponentModel.DataAnnotations;

namespace Microservices.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        [Required]
        public bool IsDisabled { get; set; } = false;

        [Required]
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        public DateTimeOffset LastUpdated { get; set; } = DateTimeOffset.UtcNow;

        [Timestamp]
        [Required]
        public byte[] RowVersion { get; set; }
    }
}