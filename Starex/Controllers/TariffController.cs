using Buisness.Abstract;
using Entity.Entities.Tariffs;
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
    public class TariffController : ControllerBase
    {
        private readonly ITariffService _context;
        public TariffController(ITariffService tariffService)
        {
            _context = tariffService;
        }
        // GET: api/<TariffController>
        [HttpGet]
        public ActionResult<List<Tariff>> Get()
        {
            try
            {
                List<Tariff> tariffs = _context.GetAllTariff();
                return Ok(tariffs);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        // GET api/<TariffController>/5
        [HttpGet("{id}")]
        public ActionResult<Tariff> Get(int id)
        {
            try
            {
                Tariff tariffsDb = _context.GetTariffWithId(id);
                if (tariffsDb == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(tariffsDb);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<TariffController>
        [HttpPost]
        public ActionResult Create([FromBody] Tariff tariff)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _context.Add(tariff);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<TariffController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Tariff tariff)
        {
            try
            {
                Tariff tariffDb = _context.GetTariffWithId(id);
                if (tariffDb == null) return StatusCode(StatusCodes.Status404NotFound);

                tariffDb.EndWeight = tariff.EndWeight;
                tariffDb.IsLiquid = tariff.IsLiquid;
                tariffDb.Price = tariff.Price;
                tariffDb.StartWeight = tariff.StartWeight;
                tariffDb.Weight = tariff.Weight;

                _context.Update(tariffDb);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<TariffController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Tariff tariffDb = _context.GetTariffWithId(id);
                if (tariffDb == null) return StatusCode(StatusCodes.Status404NotFound);
                tariffDb.IsDeleted = true;
                _context.Update(tariffDb);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
