using Buisness.Abstract;
using Entity.Entities.Questions;
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
    public class QuestionNavbarController : ControllerBase
    {
        private readonly IQuestionNavbarService _context;

        public QuestionNavbarController(IQuestionNavbarService context)
        {
            _context = context;   
        }
        // GET: api/<QuestionNavbarController>
        [HttpGet]
        public ActionResult<List<QuestionNavbar>> Get()
        {
            try
            {
                List<QuestionNavbar> questions = _context.GetAll();
                return Ok(questions);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<QuestionNavbarController>/5
        [HttpGet("{id}")]
        public ActionResult<QuestionNavbar> Get(int id)
        {
            try
            {
                QuestionNavbar question = _context.GetWithId(id);
                if (question == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<QuestionNavbarController>
        [HttpPost]
        public ActionResult Post(QuestionNavbar question)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _context.Add(question);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<QuestionNavbarController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] QuestionNavbar questionNavbar)
        {
            try
            {
                QuestionNavbar dbQuestion = _context.GetWithId(id);
                if (dbQuestion == null) return BadRequest();

                dbQuestion.Title = questionNavbar.Title;

                _context.Update(dbQuestion);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<QuestionNavbarController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            QuestionNavbar dbQuestion = _context.GetWithId(id);
            try
            {
                if (dbQuestion == null) return BadRequest();
                dbQuestion.IsDeleted = true;
                foreach (Question item in dbQuestion.Questions)
                {
                    item.IsDelete = true;
                }
                _context.Update(dbQuestion);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
