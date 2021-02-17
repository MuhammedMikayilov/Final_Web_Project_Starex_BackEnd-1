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
    public class IntroController : ControllerBase
    {
        private readonly IIntroService _context;

        public IntroController(IIntroService introService)
        {
            _context = introService;
        }

        // GET: api/<IntroController>
        [HttpGet]
        public ActionResult<List<Intro>> Get()
        {
            try
            {
                List<Intro> intros = _context.GetAllIntro();
                return Ok(intros);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<IntroController>/5
        [HttpGet("{id}")]
        public ActionResult<Intro> Get(int id)
        {
            try
            {
                Intro intro = _context.GetIntroWithId(id);
                if (intro == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(intro);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<IntroController>
        [HttpPost]
        public ActionResult Post([FromBody] Intro intro)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _context.AddIntro(intro);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<IntroController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Intro intro)
        {
            try
            {
                Intro dbIntro = _context.GetIntroWithId(id);
                if (dbIntro == null) return BadRequest();

                dbIntro.Title = intro.Title;
                _context.UpdateIntro(dbIntro);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<IntroController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Intro dbIntro = _context.GetIntroWithId(id);
                if (dbIntro == null) return BadRequest();
                _context.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
