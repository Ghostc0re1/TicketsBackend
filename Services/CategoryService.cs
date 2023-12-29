using TicketsBackend.Models;

namespace TicketsBackend.Services
{
    public class CategoryService
    {
        public Dictionary<int, List<Category>> DepartmentCategories { get; set; }
        public Dictionary<Category, List<SubCategory>> CategorySubCategories { get; set; }

        public CategoryService(IEnumerable<Department> departments)
        {
            // Initialize the dictionaries
            DepartmentCategories = new Dictionary<int, List<Category>>();
            CategorySubCategories = new Dictionary<Category, List<SubCategory>>();

            // Populate the DepartmentCategories dictionary
            foreach (var department in departments)
            {
                List<Category> categories = new List<Category>();
                // Populate categories based on department.Name or other criteria
                switch (department.Name)
                {
                    case "IT":
                        categories = new List<Category> { Category.Hardware, Category.Software, Category.AccessPermissions, Category.GeneralInquiries };
                        break;
                    case "CRM":
                        categories = new List<Category> { Category.ErrantEntry, Category.Data, Category.AccessPermissions, Category.GeneralInquiries };
                        break;
                    case "ProjectManagement":
                        categories = new List<Category> { Category.ProjectRequest, Category.Data, Category.StatusUpdates, Category.Testing, Category.Enhancements, Category.GeneralInquiries };
                        break;
                    case null: 
                        break;
                }

                DepartmentCategories.Add(department.Id, categories);
            }
        }

        /*public List<Category> GetCategoriesForDepartment(Department department)
        {
            return DepartmentCategories.TryGetValue(department, out var categories) ? categories : new List<Category>();
        }

        public List<SubCategory> GetSubCategoriesForCategory(Category category)
        {
            return CategorySubCategories.TryGetValue(category, out var subCategories) ? subCategories : new List<SubCategory>();
        }*/
    }

}
