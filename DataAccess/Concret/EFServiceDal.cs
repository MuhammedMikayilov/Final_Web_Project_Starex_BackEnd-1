﻿using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entity.Entities.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concret
{
    public class EFServiceDal: EFEntityRepositoryBase<Service,AppDbContext>, IServiceDal
    {
    }
}
