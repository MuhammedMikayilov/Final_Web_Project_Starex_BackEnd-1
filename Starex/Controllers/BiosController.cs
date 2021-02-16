using Buisness.Abstract;
using Entity.Entities.Bios;
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
    public class BiosController : ControllerBase
    {

        private readonly IBioService _bioService;

        public BiosController(IBioService bioService)
        {
            _bioService = bioService;
        }
        // GET: api/<BiosController>
        [HttpGet]
        public ActionResult<List<Bio>> Get()
        {
            try
            {
                List<Bio> bio = _bioService.GetAll();
                return Ok(bio);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<BiosController>/5
        [HttpGet("{id}")]
        public ActionResult<Bio> Get(int id)
        {
            try
            {
                Bio bio = _bioService.GetWithId(id);
                if (bio == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(bio);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<BiosController>
        [HttpPost]
        public ActionResult Post([FromBody] Bio bio)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _bioService.Add(bio);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<BiosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Bio bio)
        {
            try
            {
                Bio dbBio = _bioService.GetWithId(id);
                if (dbBio == null) return BadRequest();

                dbBio.Address = bio.Address;
                dbBio.Contact = bio.Contact;
                dbBio.WorkTime = bio.WorkTime;

                //Will be image

                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<BiosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _bioService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
