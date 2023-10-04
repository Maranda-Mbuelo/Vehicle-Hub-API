using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Hub.Data;
using Vehicle_Hub.Models;

namespace Vehicle_Hub.Controllers
{
    [Route("api/usercars")]
    [ApiController]
    public class UserCarsController : ControllerBase
    {
        private readonly CarDbContext _context; // Inject your DbContext here

        public UserCarsController(CarDbContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public ActionResult<IEnumerable<Car>> GetUserCars(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userCars = _context.Cars.Where(c => c.OwnerId == user.UserId).ToList();

            return Ok(userCars);
        }
    }
}
