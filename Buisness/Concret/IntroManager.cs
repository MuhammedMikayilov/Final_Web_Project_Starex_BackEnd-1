using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class IntroManager : IIntroService
    {
        private readonly IIntroDal _introDal;

        public IntroManager(IIntroDal introDal)
        {
            _introDal = introDal;
        }
        public List<Intro> GetAllIntro()
        {
            return _introDal.GetAll();
        }

        public Intro GetIntroWithId(int id)
        {
            return _introDal.Get(i=>i.Id == id);
        }

        public void AddIntro(Intro data)
        {
            _introDal.Add(data);
        }

        public void Delete(int id)
        {
            _introDal.Delete(new Intro { Id = id });
        }

        public void UpdateIntro(Intro data)
        {
            _introDal.Update(data);
        }
    }
}
