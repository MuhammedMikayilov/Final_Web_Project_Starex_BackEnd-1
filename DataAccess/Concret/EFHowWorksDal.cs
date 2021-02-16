using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entity.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concret
{
    public class EFHowWorksDal: EFEntityRepositoryBase<HowWorks, AppDbContext>, IHowWorksDal
    {
    }
}
