using exe1HW.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace exe1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        //**************VARIBLE FOR LOG FILE**************
        private readonly ILogger<VacationsController> _logger;

        public VacationsController(ILogger<VacationsController> logger)
        {
            _logger = logger;
        }
        //**************END OF VARIBLE FOR LOG FILE**************


        // GET: api/<VacationsController>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            try
            {
                return Vacation.Read();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);//Write to log file in ErrorLog directory
                throw;
            }
        }

        // GET api/<VacationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }




        [HttpGet("/startDate/{fromdate}/endDate/{todate}")]//route
        public IActionResult getByDates(DateTime fromdate, DateTime todate)
        {
            List<Vacation> vList = Vacation.GetBetweenDates(fromdate, todate);
            if (vList.Count > 0)
            {
                return Ok(vList);
            }
            else
            {
                return NotFound($"Not found vacation from date {fromdate.Date} to date {todate.Date}");
            }
        }
     
        [HttpGet("/month/{month}")]//route
        public List<Object> getvagPrice(int month)
        {
            Vacation v = new Vacation();
            return v.getvagPrice(month);

        }


        // POST api/<VacationsController>
        [HttpPost]
        public int Post([FromBody] Vacation vacation)
        {
            try
            {
                return vacation.Insert();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);//Write to log file in ErrorLog directory
                return 0;
            }
        }

        // PUT api/<VacationsController>/5
        [HttpPut("{id}")]
        public List<Vacation> Put(int id, [FromBody] Vacation vacation)
        {
            try
            {
                return vacation.Update();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
              
           
    
        }

        // DELETE api/<VacationsController>/5
        [HttpDelete("{id}")]
        public List<Vacation> Delete(int id)
        {
            Vacation v = new Vacation();
            return v.Delete(id);
        }
    }
}
