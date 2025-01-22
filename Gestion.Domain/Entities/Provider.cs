using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Domain.Entities
{
    public class Provider
    {
        public string Id { get; set; }
        public string NIT { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }

    }
}
