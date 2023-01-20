using exe1HW.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace exe1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {

        //**************VARIBLE FOR LOG FILE**************
        private readonly ILogger<FlatsController> _logger;

        public FlatsController(ILogger<FlatsController> logger)
        {
            _logger = logger;
        }
        //**************END OF VARIBLE FOR LOG FILE**************

        // GET: api/<FlatsController>
        [HttpGet]
        public IEnumerable<Flat> Get()
        {
            try
            {
                return Flat.Read();
               
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);//Write to log file in ErrorLog directory
                throw;
            }
           
        }

        // GET api/<FlatsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        [HttpGet("/city_maxPrice")]//qurey string 
        public IActionResult GetByCityPrice(string city, double maxPrice)
        {
            List<Flat> flist= Flat.getByCityPrice(city, maxPrice);
            if (flist.Count>0)
            {
                return Ok(flist);
            }
            else
            {
                return NotFound($"Not found flats at {city} in less then {maxPrice}$");
            }
        }

        // POST api/<FlatsController>
        [HttpPost]
        public int Post([FromBody] Flat flat)
        {
            //try {
            //    return flat.Insert();
            //}
            //catch (Exception ex )
            //{
            //    _logger.LogError(ex.Message);//Write to log file in ErrorLog directory
            //    return false;   
            //}
            return flat.Insert();
        }

        // PUT api/<FlatsController>/5
        [HttpPut("{id}")]
        public List<Flat> Put(int id, [FromBody] Flat falt)
        {
           return falt.Update();
        }

        // DELETE api/<FlatsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Flat f = new Flat();
            List<Flat> flist = new List<Flat>();
            flist = f.Delete(id);
            if (flist.Count > 0)
            {
                return Ok(flist);
            }
            return BadRequest("Error: This flat have at least one vacation. can't delete flat with an order.");
        }
    }
}
