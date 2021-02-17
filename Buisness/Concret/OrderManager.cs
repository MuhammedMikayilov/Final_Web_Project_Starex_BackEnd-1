using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public void Add(Order data)
        {
            _orderDal.Add(data);
        }

        public void Delete(int id)
        {
            _orderDal.Delete(new Order { Id = id });
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll(o=>!o.IsDeleted);
        }

        public Order GetWithId(int id)
        {
            return _orderDal.Get(o=>o.Id == id && !o.IsDeleted);
        }

        public void Update(Order data)
        {
            _orderDal.Update(data);
        }
    }
}
