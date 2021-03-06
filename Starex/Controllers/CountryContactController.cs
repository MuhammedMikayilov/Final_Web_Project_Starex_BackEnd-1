﻿using Buisness.Abstract;
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
        public async Task<ActionResult<List<CountryContact>>> Get()
        {
            try
            {
                List<CountryContact> contact = await _context.GetAll();
                return Ok(contact);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<CountryContactController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryContact>> Get(int id)
        {
            try
            {
                CountryContact contact = await _context.GetWithId(id);
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
        public async Task<ActionResult> Create([FromBody] CountryContact contact)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                await _context.Add(contact);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<CountryContactController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CountryContact contact)
        {
            try
            {
                CountryContact contactDb = await _context.GetWithId(id);
                if (contactDb == null) return StatusCode(StatusCodes.Status404NotFound);
                contactDb.Address = contact.Address;
                contactDb.Time = contact.Time;
                contactDb.CountryId = contact.CountryId;
                await _context.Update(contactDb);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<CountryContactController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                CountryContact countactDb = await _context.GetWithId(id);
                if (countactDb == null) return StatusCode(StatusCodes.Status404NotFound);
                countactDb.IsDeleted = true;

                await _context.Update(countactDb);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
