using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities.HomePages
{
    public class HowWorks: IEntity
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
