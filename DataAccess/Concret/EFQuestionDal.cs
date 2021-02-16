using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entity.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concret
{
    public class EFQuestionDal: EFEntityRepositoryBase<Question, AppDbContext>, IQuestionDal
    {
    }
}
