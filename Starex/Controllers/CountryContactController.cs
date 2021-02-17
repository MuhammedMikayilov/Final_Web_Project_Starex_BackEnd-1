using Buisness.Abstract;
using Entity.Entities.Contacts;
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
    public class CountryContactController : ControllerBase
    {
        private readonly ICountryContactService _context;
        public CountryContactController(ICountryContactService contactService)
        {
            _context = contactService;
        }
        // GET: api/<CountryContactController>
        [HttpGet]
        public ActionResult<List<CountryContact>> Get()
        {
            try
            {
                List<CountryContact> contact = _context.GetAllContact();
                return Ok(contact);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<CountryContactController>/5
        [HttpGet("{id}")]
        public ActionResult<CountryContact> Get(int id)
        {
            try
            {
                CountryContact contact = _context.GetContactWithId(id);
                if (contact == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(contact);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<CountryContactController>
        [HttpPost]
        public ActionResult Create([FromBody] CountryContact contact)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _context.Add(contact);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<CountryContactController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CountryContact contact)
        {
            try
            {
                CountryContact contactDb = _context.GetContactWithId(id);
                if (contactDb == null) return StatusCode(StatusCodes.Status404NotFound);
                contactDb.Address = contact.Address;
                contactDb.Time = contact.Time;
                _context.Update(contactDb);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<CountryContactController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                CountryContact countactDb = _context.GetContactWithId(id);
                if (countactDb == null) return StatusCode(StatusCodes.Status404NotFound);
                countactDb.IsDeleted = true;

                _context.Update(countactDb);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
