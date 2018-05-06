using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSEx1.Models.ViewModels
{
    public class ProductsViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public string CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
    }
}