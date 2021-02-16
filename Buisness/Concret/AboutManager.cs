using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

namespace Buisness.Concret
{
    public class AboutManager :IAboutService
    {
        private readonly IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public List<About> GetAll()
        {
            return _aboutDAL.GetAll();
        }

        public About GetWithId(int id)
        {
            return _aboutDAL.Get(c => c.Id == id);
        }

        public void Add(About data)
        {
            _aboutDAL.Add(data);
        }

        public void Delete(int id)
        {
            _aboutDAL.Delete(new About { Id = id });
        }

        public void Update(About data)
        {
            _aboutDAL.Update(data);
        }
    }
}
