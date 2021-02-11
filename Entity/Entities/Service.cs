using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Service:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
    }
}
