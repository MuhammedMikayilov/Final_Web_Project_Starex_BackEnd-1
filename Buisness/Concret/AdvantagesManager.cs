using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class AdvantagesManager : IAdvantagesService
    {
        private readonly IAdvantagesDal _advantagesDal;

        public AdvantagesManager(IAdvantagesDal advantagesDal)
        {
            _advantagesDal = advantagesDal;
        }

        public List<Advantages> GetAll()
        {
            return _advantagesDal.GetAll();
        }

        public Advantages GetWithId(int id)
        {
            return _advantagesDal.Get(a=>a.Id==id && !a.IsDeleted);
        }

        public void Add(Advantages data)
        {
            _advantagesDal.Add(data);
        }

        public void Delete(int id)
        {
            _advantagesDal.Delete(new Advantages { Id = id });
        }

        public void Update(Advantages data)
        {
            _advantagesDal.Update(data);
        }
    }
}
