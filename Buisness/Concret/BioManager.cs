using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.Bios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class BioManager : IBioService
    {

        private readonly IBioDal _bioDal;

        public BioManager(IBioDal bioDal)
        {
            _bioDal = bioDal;
        }

        public void Add(Bio data)
        {
            _bioDal.Add(data);
        }

        public void Delete(int id)
        {
            _bioDal.Delete(new Bio { Id = id });
        }

        public List<Bio> GetAll()
        {
            return _bioDal.GetAll();
        }

        public Bio GetWithId(int id)
        {
            return _bioDal.Get(b=>b.Id == id);
        }

        public void Update(Bio data)
        {
            _bioDal.Update(data);
        }
    }
}
