using System;
using System.ComponentModel.DataAnnotations;

namespace TicketsBackend.Models
{
    public class Ticket
    {
        public required int Id { get; set; }
        public required string Subject { get; set; }
        public string? Description { get; set; }
        public Priority? Priotity { get; set; }
        public Status? Status { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public Category? Category { get; set; }
        public SubCategory? SubCategory { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? AssignedTo { get; set; }
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
    public enum SubCategory
    {
        Open,
        InProgress,
        Closed
    }
}
