using Entity.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface IQuestionService
    {
        Question GetWithId(int id);
        List<Question> GetAll();
        void Add(Question data);
        void Update(Question data);
        void Delete(int id);
    }
}
