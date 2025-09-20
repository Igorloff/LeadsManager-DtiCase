using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadsManager.backend.Dtos
{
    public class LeadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public LeadStatus Status { get; set; }
    }
}