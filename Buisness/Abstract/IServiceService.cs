using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IServiceService
    {
        Task<Service> GetServiceWithId(int id);
        Task<List<Service>> GetAllService();
        void Add(Service service);
        void Update(Service service);
        void Delete(int id);

    }
}
