using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExampleApi.Models;

namespace ExampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       private IWorkersRepository _workersRepository;

        public WeatherForecastController(IWorkersRepository workersRepository)
        {
            _workersRepository = workersRepository;
        }

        [HttpGet]
        public IEnumerable<Workers> Get()
        {
            return _workersRepository.Get();
        }

        [HttpGet("GetWorkers")]
        public IActionResult Get(int Id)
        {
            Workers workers = _workersRepository.Get(Id);

            if (workers == null)
            {
                return NotFound();
            }

            return new ObjectResult(workers);
        }

        [HttpPost("items")]
        public IActionResult Create([FromBody] Workers workers)
        {
            if (workers == null)
            {
                return BadRequest();
            }
            _workersRepository.Create(workers);
            return CreatedAtRoute("GetWorkers", new { id = workers.Id }, workers);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, [FromBody] Workers updateWorkers)
        {
            if (updateWorkers == null || updateWorkers.Id != Id)
            {
                return BadRequest();
            }

            var workers = _workersRepository.Get(Id);
            if (workers == null)
            {
                return NotFound();
            }

            _workersRepository.Update(updateWorkers);
            return RedirectToRoute("GetAllItems");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var deleteWorkers = _workersRepository.Delete(Id);

            if (deleteWorkers == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deleteWorkers);
        }
    }
}
