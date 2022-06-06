using System.ComponentModel.DataAnnotations.Schema;

namespace AHTG_Hospitals.models
{
    [Table("Address")]
    public class Address : BaseModel
    { 
        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }
    }
}
