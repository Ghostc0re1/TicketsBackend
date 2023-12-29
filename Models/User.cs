namespace TicketsBackend.Models
{
    public class User
    {
        public string? Id { get; set; } // ObjectId from Azure AD
        public string? Email { get; set; } // User email or UPN (User Principal Name)
        public string? TenantId { get; set; } // Tenant ID, if needed
    }
}
