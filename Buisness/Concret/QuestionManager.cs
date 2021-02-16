using Buisness.Abstract;
using DataAccess.Abstract;
using Entity.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concret
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _context;

        public QuestionManager(IQuestionDal context)
        {
            _context = context;
        }

        public List<Question> GetAll()
        {
            return _context.GetAll(q => !q.IsDelete);
        }

        public Question GetWithId(int id)
        {
            return _context.Get(q=>q.Id == id && !q.IsDelete);
        }

        public void Add(Question data)
        {
            _context.Add(data);

        }

        public void Delete(int id)
        {
            _context.Delete(new Question { Id = id });
        }

        public void Update(Question data)
        {
            _context.Update(data);
        }
    }
}
