using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class StoreManager : IStoreService
    {
        private readonly IStoreDal _storeDal;

        public StoreManager(IStoreDal storeDal)
        {
            _storeDal = storeDal;
        }
        public void Add(Store data)
        {
            _storeDal.Add(data);
        }

        public void Delete(int id)
        {
            _storeDal.Delete(new Store { Id = id });
        }

        public List<Store> GetAll()
        {
            return _storeDal.GetAll(s=>!s.IsDeleted);
        }

        public Store GetWithId(int id)
        {
            return _storeDal.Get(s=>s.Id == id && s.IsDeleted);
        }

        public void Update(Store data)
        {
            _storeDal.Update(data);
        }
    }
}
