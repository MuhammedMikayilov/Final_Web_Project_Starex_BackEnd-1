using Core.Repository;
using Entity.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IQuestionNavbarDal: IEntityRepository<QuestionNavbar>
    {
    }
}
