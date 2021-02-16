using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IAboutService
    {
        About GetWithId(int id);
        List<About> GetAll();
        void Add(About data);
        void Update(About data);
        void Delete(int id);
    }
}
