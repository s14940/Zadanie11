using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly HospitalContext _context;

        public DoctorController(HospitalContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public IActionResult Doctor(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);

            if (null == doctor)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult EditDoctor([Bind("IdDoctor, FirstName, LastName, Email")]
            Doctor doctor)
        {
            if (null == _context.Doctors.Find(doctor))
            {
                return BadRequest();
            }

            _context.Update(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }


        [HttpPost]
        public IActionResult Doctor([Bind("IdDoctor, FirstName, LastName, Email")]
            Doctor doctor)
        {
            if (null != _context.Doctors.Find(doctor))
            {
                return BadRequest();
            }

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);

            if (null != doctor)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }
    }
}