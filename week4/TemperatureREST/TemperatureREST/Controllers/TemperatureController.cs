using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureREST.Models;

namespace TemperatureREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        // really we would use a DB, but for demo purposes, a static variable is used. 
        public static List<Temperature> Data = new List<Temperature>()
        {
            new Temperature
            {
                id = 1,
                Time = DateTime.Now,
                Value = 36,
                Unit = TemperatureUnit.Celsius
            }

        };
        // GET: api/Temperature
        [HttpGet]
        public IEnumerable<Temperature> Get()
        {
            return Data;
        }


        // GET: api/Temperature/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Temperature> Get(int id)
        {
            Temperature result = Data.FirstOrDefault(x => x.id == id);

            if(result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST: api/Temperature
        // inserting a new resouce
        [HttpPost]
        public ActionResult Post([FromBody] Temperature value)
        {
            Data.Add(value);
            return Ok();
        }

        // PUT: api/Temperature/5
        // replace an existing resource
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Temperature value)
        {
            var existing = Data.FirstOrDefault(x => x.id == id);

            if(existing == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }

            Data.Remove(existing);
            value.id = id;
            Data.Add(value); 

            return Ok();// succes = Ok()
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existing = Data.FirstOrDefault(x => x.id == id);

            if (existing == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }

            Data.Remove(existing);

            return Ok();// succes = Ok()
        }
    }
}
