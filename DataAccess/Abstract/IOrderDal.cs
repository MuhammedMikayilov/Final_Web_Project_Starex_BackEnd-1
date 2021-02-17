﻿using Core.Repository;
using Entity.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDal: IEntityRepository<Order>
    {
    }
}
