using Entity.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface IAdvantagesService
    {
        Advantages GetWithId(int id);
        List<Advantages> GetAll();
        void Add(Advantages data);
        void Update(Advantages data);
        void Delete(int id);
    }
}
