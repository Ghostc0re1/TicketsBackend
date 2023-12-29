#nullable enable
namespace TicketsBackend.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string? ContactInfo { get; set; }

        // Constructor
        public Department(int id, DepartmentName departmentName, string description)
        {
            Id = id;
            Name = departmentName.ToString();
            Description = description;
        }
    }
    public enum DepartmentName
    {
        IT,
        CRM,
        ProjectManagement
    }
}
