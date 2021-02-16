using Entity.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface IQuestionNavbarService
    {
        QuestionNavbar GetWithId(int id);
        List<QuestionNavbar> GetAll();
        void Add(QuestionNavbar data);
        void Update(QuestionNavbar data);
        void Delete(int id);
    }
}
