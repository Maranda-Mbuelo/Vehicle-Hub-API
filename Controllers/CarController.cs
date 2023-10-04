using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle_Hub.Data;
using Vehicle_Hub.Models;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Hub.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarDbContext _context; // Inject your DbContext here

        public CarController(CarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            var cars = _context.Cars.ToList();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _context.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCar), new { id = car.CarId }, car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
