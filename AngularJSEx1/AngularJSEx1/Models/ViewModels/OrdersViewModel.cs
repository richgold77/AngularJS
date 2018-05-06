using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSEx1.Models.ViewModels
{
    public class OrdersViewModel
    {
        public int OrderID { get; set; }     
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public CustomersViewModel CustomerOwner { get; set; } 

        //public Boolean giftwrap { get; set; }
        //public string ProductName { get; set; }
        //public string QuantityPerUnit { get; set; }
        //public decimal total_price { get; set; }
    }
}