using Buisness.Abstract;
using Entity.Entities.HomePages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Starex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HowWorksController : ControllerBase
    {
        private readonly IHowWorksService _howWorks;

        public HowWorksController(IHowWorksService howWorks)
        {
            _howWorks = howWorks;
        }

        // GET: api/<HowWorksController>
        [HttpGet]
        public ActionResult<List<HowWorks>> Get()
        {
            try
            {
                List<HowWorks> howWorks = _howWorks.GetAll();
                return Ok(howWorks);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<HowWorksController>/5
        [HttpGet("{id}")]
        public ActionResult<HowWorks> Get(int id)
        {
            try
            {
                HowWorks howWorks = _howWorks.GetWithId(id);
                if (howWorks == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(howWorks);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<HowWorksController>
        [HttpPost]
        public ActionResult Post([FromBody] HowWorks howWorks)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _howWorks.Add(howWorks);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<HowWorksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] HowWorks howWorks)
        {
            try
            {
                HowWorks dbWorks = _howWorks.GetWithId(id);
                if (dbWorks == null) return BadRequest();

                dbWorks.Icon = howWorks.Icon;
                dbWorks.Title = howWorks.Title;
                dbWorks.Description = howWorks.Description;

                _howWorks.Update(dbWorks);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<HowWorksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _howWorks.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
