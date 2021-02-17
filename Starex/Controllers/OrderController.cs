using Buisness.Abstract;
using Entity.Entities.Orders;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _context;

        public OrderController(IOrderService orderService)
        {
            _context = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            try
            {
                List<Order> orders = _context.GetAll();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            try
            {
                Order order = _context.GetWithId(id);
                if (order == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _context.Add(order);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order order)
        {
            try
            {
                Order dbOrder = _context.GetWithId(id);
                if (dbOrder == null) return BadRequest();

                dbOrder.CargoCountry = order.CargoCountry;
                dbOrder.Color = order.Color;
                dbOrder.Comment = order.Comment;
                dbOrder.Count = order.Count;
                dbOrder.Link = order.Link;
                dbOrder.Price = order.Price;
                dbOrder.Size = order.Size;
                dbOrder.Total = order.Total;

                _context.Update(dbOrder);

                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Order dbOrder = _context.GetWithId(id);
                if (dbOrder == null) return BadRequest();
                dbOrder.IsDeleted = true;
                _context.Update(dbOrder);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
