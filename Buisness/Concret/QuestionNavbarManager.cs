using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class QuestionNavbarManager : IQuestionNavbarService
    {
        private readonly IQuestionNavbarDal _context;

        public QuestionNavbarManager(IQuestionNavbarDal context)
        {
            _context = context;
        }

        public List<QuestionNavbar> GetAll()
        {
            return _context.GetAll(q=> !q.IsDeleted);
        }

        public QuestionNavbar GetWithId(int id)
        {
            return _context.Get(q=>q.Id==id && !q.IsDeleted);
        }

        public void Add(QuestionNavbar data)
        {
           _context.Add(data);
        }

        public void Delete(int id)
        {
            _context.Delete(new QuestionNavbar { Id = id });
        }

        public void Update(QuestionNavbar data)
        {
            _context.Update(data);
        }
    }
}
