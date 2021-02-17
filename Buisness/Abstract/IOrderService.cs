using Entity.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface IOrderService
    {
        Order GetWithId(int id);
        List<Order> GetAll();
        void Add(Order data);
        void Update(Order data);
        void Delete(int id);
    }
}
