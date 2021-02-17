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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _context;

        public QuestionController(IQuestionService questionService)
        {
            _context = questionService;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public ActionResult<List<Question>> Get()
        {
            return _context.GetAll();
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            return _context.GetWithId(id);
        }

        // POST api/<QuestionController>
        [HttpPost]
        public ActionResult Post([FromBody] Question question)
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

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Question question)
        {
            try
            {
                Question dbQuestion = _context.GetWithId(id);
                if (dbQuestion == null) return BadRequest();

                _context.Update(dbQuestion);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Question dbQuestion = _context.GetWithId(id);
                if (dbQuestion == null) return BadRequest();
                dbQuestion.IsDelete = true;

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
