using System.ComponentModel.DataAnnotations;
using TicketsBackend.Models;

#nullable disable

namespace TicketsBackend.DTOs
{
    public class TicketsDto
    {
        public int Id { get; set; }

        [Required]
        public required string Subject { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        // Reference to Department
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string AssignedTo { get; set; }

    }
}
