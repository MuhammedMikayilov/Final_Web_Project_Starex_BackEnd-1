using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.Notfications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class NotficationManager : INotficationService
    {
        private readonly INotficationDal _notficationDal;

        public NotficationManager(INotficationDal notficationDal)
        {
            _notficationDal = notficationDal;
        }

        public void Add(Notfication data)
        {
            _notficationDal.Add(data);
        }

        public void Delete(int id)
        {
            _notficationDal.Delete(new Notfication { Id = id });
        }

        public List<Notfication> GetAll()
        {
            return _notficationDal.GetAll(n=>!n.IsDeleted);
        }

        public Notfication GetWithId(int id)
        {
            return _notficationDal.Get(n=>n.Id == id && !n.IsDeleted);
        }

        public void Update(Notfication data)
        {
            _notficationDal.Update(data);
        }
    }
}
