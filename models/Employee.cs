using System.ComponentModel.DataAnnotations.Schema;

namespace AHTG_Hospitals.models
{
    [Table("Employee")]
    public class Employee : Person
    {
        public double SalaryPerYear { get; set; }

        public string Department { get; set; }

        public DateTime HireDate { get; set; }

        public int HospitalId { get; set; }

        public Hospital Hospital { get; set; }
    }
}
