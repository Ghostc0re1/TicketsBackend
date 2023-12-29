using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TicketsBackend.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public required string Subject { get; set; }
        public string Description { get; set; }
        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
        // Reference to Department
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public Category? Category { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string AssignedTo { get; set; }
    }
    public enum Priority
    {
        Low,
        Medium,
        High
    }
    public enum Status
    {
        NewTicket,
        Open,
        InProgress,
        OnHoldTech,
        OnHoldUser,
        OnHoldVendor,
        Resolved,
        Closed
    }
    public enum Category
    {
        Hardware,
        Software,
        AccessPermissions,
        GeneralInquiries,
        ErrantEntry,
        Data,
        ProjectRequest,
        StatusUpdates,
        Testing,
        Enhancements
    }
}
