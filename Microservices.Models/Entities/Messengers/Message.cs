using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Microservices.Models.Entities.Messengers
{
    public class Message : BaseEntity
    {
        public int PoolID { get; set; }

        [IgnoreDataMember]
        public Pool Pool { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string FromAuth { get; set; }
    }
}