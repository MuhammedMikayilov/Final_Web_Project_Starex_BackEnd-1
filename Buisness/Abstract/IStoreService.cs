using Entity.Entities.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface IStoreService
    {
        Store GetWithId(int id);
        List<Store> GetAll();
        void Add(Store data);
        void Update(Store data);
        void Delete(int id);
    }
}
