using Entity.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface IHowWorksService
    {
        HowWorks GetWithId(int id);
        List<HowWorks> GetAll();
        void Add(HowWorks data);
        void Update(HowWorks data);
        void Delete(int id);
    }
}
