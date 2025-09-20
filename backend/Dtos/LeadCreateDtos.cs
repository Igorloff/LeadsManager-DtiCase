using System.ComponentModel.DataAnnotations;

namespace LeadsManager.backend.Dtos
{
    public class LeadCreateDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Phone]
        public string ContactPhone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
