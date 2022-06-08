using System.ComponentModel.DataAnnotations.Schema;

namespace AHTG_Hospitals.models
{
    [Table("Hospital")]
    public class Hospital : BaseModel
    {
        public string Name { get; set; }

        public string? Director { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}