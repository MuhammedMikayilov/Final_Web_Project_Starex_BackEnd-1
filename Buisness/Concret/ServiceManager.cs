using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Add(Service service)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Service> GetAllService()
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetServiceWithId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Service service)
        {
            throw new NotImplementedException();
        }

        Task<List<Service>> IServiceService.GetAllService()
        {
            throw new NotImplementedException();
        }
    }
}
