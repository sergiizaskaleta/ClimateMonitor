using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClimateMonitor.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateMonitor.Controllers
{
    [Route("api/[controller]")]
    public class SensorController : Controller
    {
        private readonly SensorContext _context;

        public SensorController(SensorContext context)
        {
            _context = context;

            if (_context.Sensors.Count() == 0)
            {
                _context.Sensors.Add(new Sensor { Name = "Temperature, *C" });
                _context.Sensors.Add(new Sensor { Name = "Humidity, %" });
                _context.Sensors.Add(new Sensor { Name = "CO2, ppm" });
                _context.SaveChanges();
            }
        }

        // GET: api/sensor
        [HttpGet]
        [Route("all")]
        [Route("")]
        public IEnumerable<Sensor> GetAll()
        {
            return _context.Sensors.ToList();
        }

        // GET: api/sensor/{id}
        [HttpGet]
        [Route("{id:long}", Name = "GetSensor")]
        public IActionResult GetById(long id)
        {
            var item = _context.Sensors.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/sensor
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] Sensor sensor)
        {
            if (sensor == null)
            {
                return BadRequest();
            }

            _context.Sensors.Add(sensor);
            _context.SaveChanges();

            return CreatedAtRoute("GetSensor", new { id = sensor.Id }, sensor);
        }

        // PUT: api/sensor/{id}
        [HttpPut]
        [Route("{id:long}")]
        public IActionResult Update(long id, [FromBody] Sensor item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var sensor = _context.Sensors.FirstOrDefault(t => t.Id == id);
            if (sensor == null)
            {
                return NotFound();
            }

            sensor.Name = item.Name;

            _context.Sensors.Update(sensor);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE: api/sensor/{id}
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _context.Sensors.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Sensors.Remove(item);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
