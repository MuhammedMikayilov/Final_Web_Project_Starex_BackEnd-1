using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class HowWorksManager : IHowWorksService
    {

        private readonly IHowWorksDal _howWorksDal;

        public HowWorksManager(IHowWorksDal howWorksDal)
        {
            _howWorksDal = howWorksDal;
        }

        //private readonly 
        public void Add(HowWorks data)
        {
            _howWorksDal.Add(data);
        }

        public void Delete(int id)
        {
            _howWorksDal.Delete(new HowWorks { Id = id });
        }

        public List<HowWorks> GetAll()
        {
            return _howWorksDal.GetAll();
        }

        public HowWorks GetWithId(int id)
        {
            return _howWorksDal.Get(a => a.Id == id);
        }

        public void Update(HowWorks data)
        {
            _howWorksDal.Update(data);
        }
    }
}
