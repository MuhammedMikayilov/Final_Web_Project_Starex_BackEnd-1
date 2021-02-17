﻿using Buisness.Abstract;
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
    public class AdvantagesController : ControllerBase
    {

        private readonly IAdvantagesService _context;

        public AdvantagesController(IAdvantagesService advantagesService)
        {
            _context = advantagesService;
        }

        // GET: api/<AdvantagesController>
        [HttpGet]
        public ActionResult<List<Advantages>> Get()
        {
            try
            {
                List<Advantages> advantages = _context.GetAll();
                return Ok(advantages);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<AdvantagesController>/5
        [HttpGet("{id}")]
        public ActionResult<Advantages> Get(int id)
        {
            try
            {
                Advantages advantages = _context.GetWithId(id);
                if (advantages == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(advantages);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<AdvantagesController>
        [HttpPost]
        public ActionResult Post([FromBody] Advantages advantages)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _context.Add(advantages);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<AdvantagesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Advantages advantages)
        {
            try
            {
                Advantages dbAdvatages = _context.GetWithId(id);
                if (dbAdvatages == null) return BadRequest();

                dbAdvatages.Icon = advantages.Icon;
                dbAdvatages.Title = advantages.Title;
                dbAdvatages.Description = advantages.Description;

                _context.Update(dbAdvatages);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<AdvantagesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Advantages dbAdvantages = _context.GetWithId(id);
                if (dbAdvantages == null) return BadRequest();
                dbAdvantages.IsDeleted = true;
                _context.Update(dbAdvantages);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
