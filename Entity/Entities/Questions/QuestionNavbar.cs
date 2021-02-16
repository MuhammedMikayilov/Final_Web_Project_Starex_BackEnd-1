using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities.Questions
{
    public class QuestionNavbar:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}
