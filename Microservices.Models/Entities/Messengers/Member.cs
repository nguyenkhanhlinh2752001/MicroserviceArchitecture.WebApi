using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Microservices.Models.Entities.Messengers
{
    public class Member : BaseEntity
    {
        public int PoolID { get; set; }

        [IgnoreDataMember]
        public Pool Pool { get; set; }

        [Required]
        public string AuthID { get; set; }
    }
}