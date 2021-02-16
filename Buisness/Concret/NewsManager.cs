using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.Newss;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class NewsManager : INewsService
    {
        private readonly INewsDal _context;

        public NewsManager(INewsDal context)
        {
            _context = context;
        }
        public List<News> GetAll()
        {
            return _context.GetAll(n=> !n.IsDeleted);
        }       

        public News GetWithId(int id)
        {
            return _context.Get(n=>n.Id == id && !n.IsDeleted);
        }
        public void Add(News data)
        {
            _context.Add(data);
        }

        public void Delete(int id)
        {
            _context.Delete(new News { Id = id });
        }

        public void Update(News data)
        {
            _context.Update(data);
        }
    }
}
