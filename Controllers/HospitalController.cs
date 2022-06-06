using AHTG_Hospitals.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AHTG_Hospitals.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HospitalController : ControllerBase
    {
        private readonly ILogger<HospitalController> _logger;

        public HospitalController(ILogger<HospitalController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHospitals")]
        public IEnumerable<Hospital> Get()
        {
            using(var dbContext = new MyDbContext())
            {
                return dbContext.Hospitals.Include(hospital => hospital.Address).Include(hospital => hospital.Employees).ToList();
            }
        }

        [HttpGet(Name = "GetHospital")]
        public Hospital? GetHospital(int id)
        {
            using(var dbContext = new MyDbContext())
            {
                var result = dbContext.Hospitals
                    .Include(hospital => hospital.Address)
                    .Include(hospital => hospital.Employees)
                    .Where(hospital => hospital.Id == id).FirstOrDefault();
                return result;
            }
        }

        [HttpPut(Name = "UpdateHospital")]
        public Hospital UpdateHospital(Hospital updatedHospital)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Hospitals.Update(updatedHospital);
                dbContext.SaveChanges();
                return updatedHospital;
            }
        }

        [HttpPost(Name = "CreateHospital")]
        public Hospital CreateHospital(Hospital newHospital)
        {
            using(var dbContext = new MyDbContext())
            {
                dbContext.Hospitals.Add(newHospital);
                dbContext.SaveChanges();
                return newHospital;
            }
        }

        [HttpDelete(Name = "DeleteHospital")]
        public bool Delete(int hospitalId)
        {
            using(var dbContext = new MyDbContext())
            {
                Hospital hospitalToRemove = new Hospital { Id = hospitalId };
                dbContext.Hospitals.Remove(hospitalToRemove);
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}