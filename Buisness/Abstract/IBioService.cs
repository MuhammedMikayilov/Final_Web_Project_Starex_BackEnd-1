using Entity.Entities.Bios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface IBioService
    {
        Bio GetWithId(int id);
        List<Bio> GetAll();
        void Add(Bio data);
        void Update(Bio data);
        void Delete(int id);
    }
}
