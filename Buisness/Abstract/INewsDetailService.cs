using Entity.Entities.Newss;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface INewsDetailService
    {
        NewsDetail GetWithId(int id);
        List<NewsDetail> GetAll();
        void Add(NewsDetail data);
        void Update(NewsDetail data);
        void Delete(int id);
    }
}
