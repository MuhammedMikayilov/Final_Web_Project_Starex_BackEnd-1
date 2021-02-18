using Entity.Entities.Notfications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface INotficationService
    {
        Notfication GetWithId(int id);
        List<Notfication> GetAll();
        void Add(Notfication data);
        void Update(Notfication data);
        void Delete(int id);
    }
}
