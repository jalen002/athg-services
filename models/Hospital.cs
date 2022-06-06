using System.ComponentModel.DataAnnotations.Schema;

namespace AHTG_Hospitals.models
{
    [Table("Hospital")]
    public class Hospital : BaseModel
    {
        public string Name { get; set; }

        public string Director { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}