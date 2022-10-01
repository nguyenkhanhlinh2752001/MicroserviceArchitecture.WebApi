using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Models.ViewModels
{
    public class ResponseVM
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
