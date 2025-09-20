public enum LeadStatus { Invited, Accepted, Declined }

namespace LeadsManager.backend.Models
{
    public class Lead
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
        public LeadStatus Status { get; set; } = LeadStatus.Invited;
    }
}