using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities.Orders
{
    public class Order: IEntity
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public double Count { get; set; }
        public double Size { get; set; }
        public string Color { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        public double CargoCountry { get; set; }
        public string DeclarationLink { get; set; }
        public double Total { get; set; }
        public bool İsPayment { get; set; }
        public bool İsAccepted { get; set; }
        public bool İsRejected { get; set; }
        public bool IsDeleted { get; set; }
    }
}
