using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities.HomePages
{
    public class Intro:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
