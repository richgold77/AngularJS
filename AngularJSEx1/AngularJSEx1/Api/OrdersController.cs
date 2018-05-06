using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Configuration;
using Dapper;
using System.Data.SqlClient;
using AngularJSEx1.Models.ViewModels;


namespace AngularJSEx1.Api
{
    public class OrdersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<OrdersViewModel> Get()
        {
            //http://www.zendei.com/article/15695.html  JOIN 寫法參考網址

            var cnstr = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(cnstr))
            {
                string ordersSql = @"SELECT TOP 5 a.ShipName, a.ShipAddress, a.ShipCity, a.ShipRegion, a.ShipPostalCode, a.ShipCountry
                , a.giftwrap, b.OrderID, c.ProductName, c.QuantityPerUnit, c.UnitPrice
                FROM Orders a JOIN[Order Details] b
                ON a.OrderID = b.OrderID JOIN Products c
                ON b.ProductID = c.ProductID";

                //string ordersSqlGroup = @"SELECT TOP 5 a.ShipName, a.ShipAddress, a.ShipCity, a.ShipRegion, a.ShipPostalCode, a.ShipCountry
                //, a.giftwrap, b.OrderID, SUM(c.UnitPrice) total_price
                //FROM Orders a JOIN [Order Details] b
                //ON a.OrderID = b.OrderID JOIN Products c
                //ON b.ProductID = c.ProductID
                //GROUP BY b.OrderID, a.ShipName, a.ShipAddress, a.ShipCity, a.ShipRegion, a.ShipPostalCode, a.ShipCountry
                //, a.giftwrap";

                string ordersSqlSimple = @"SELECT TOP 5 * FROM Orders ORDER BY OrderID ASC";

                string ordersJoin = @"SELECT a.OrderID, a.CustomerID
                                    , b.CompanyName
                                    FROM Orders a JOIN Customers b
                                    ON a.CustomerID = b.CustomerID";


                var orders = conn.Query<OrdersViewModel, CustomersViewModel, OrdersViewModel>(ordersJoin,
                    (OrdersViewModel, CustomersViewModel) => {
                        OrdersViewModel.CustomerOwner = CustomersViewModel;
                        return OrdersViewModel;
                    }, splitOn: "CompanyName");

                List<OrdersViewModel> ordersList = new List<OrdersViewModel>();

                foreach (var item in orders)
                {
                    ordersList.Add(new OrdersViewModel()
                    {
                        OrderID = item.OrderID,
                        //ShipName = item.ShipName,
                        //ShipAddress = item.ShipAddress,
                        //ShipCity = item.ShipCity,
                        //ShipRegion = item.ShipRegion,
                        //ShipPostalCode = item.ShipPostalCode,
                        //ShipCountry = item.ShipCountry,
                        CustomerID = item.CustomerID,
                        CustomerOwner = item.CustomerOwner
                        //giftwrap = item.giftwrap,
                        //ProductName = item.ProductName,
                        //QuantityPerUnit = item.QuantityPerUnit,
                        //total_price = item.total_price,
                    });

                }

                return ordersList;
                //return new
                //{
                //    ProfileCode = new
                //    {
                //        ordersList
                //    }
                //};
            }
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            var cnstr = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(cnstr))
            {
                string ordersSql = @"SELECT TOP 5 a.ShipName, a.ShipAddress, a.ShipCity, a.ShipRegion, a.ShipPostalCode, a.ShipCountry
                , a.giftwrap, b.OrderID, c.ProductName, c.QuantityPerUnit, c.UnitPrice
                FROM Orders a JOIN[Order Details] b
                ON a.OrderID = b.OrderID JOIN Products c
                ON b.ProductID = c.ProductID";

                //string ordersSqlGroup = @"SELECT TOP 5 a.ShipName, a.ShipAddress, a.ShipCity, a.ShipRegion, a.ShipPostalCode, a.ShipCountry
                //, a.giftwrap, b.OrderID, SUM(c.UnitPrice) total_price
                //FROM Orders a JOIN [Order Details] b
                //ON a.OrderID = b.OrderID JOIN Products c
                //ON b.ProductID = c.ProductID
                //GROUP BY b.OrderID, a.ShipName, a.ShipAddress, a.ShipCity, a.ShipRegion, a.ShipPostalCode, a.ShipCountry
                //, a.giftwrap";

                string ordersSqlSimple = @"SELECT TOP 5 * FROM Orders ORDER BY OrderID ASC";

                string ordersJoin = @"SELECT TOP 10 a.OrderID, a.CustomerID
, b.CompanyName
FROM Orders a JOIN Customers b
ON a.CustomerID = b.CustomerID";


                var orders = conn.Query<OrdersViewModel, CustomersViewModel, OrdersViewModel>(ordersJoin, 
                    (OrdersViewModel, CustomersViewModel) => {
                        OrdersViewModel.CustomerOwner = CustomersViewModel;
                        return OrdersViewModel;
                    }, splitOn: "CompanyName");

                List<OrdersViewModel> ordersList = new List<OrdersViewModel>();

                foreach (var item in orders)
                {
                    ordersList.Add(new OrdersViewModel()
                    {
                        OrderID = item.OrderID,
                        ShipName = item.ShipName,
                        ShipAddress = item.ShipAddress,
                        ShipCity = item.ShipCity,
                        ShipRegion = item.ShipRegion,
                        ShipPostalCode = item.ShipPostalCode,
                        ShipCountry = item.ShipCountry,
                        CustomerOwner = item.CustomerOwner
                        //giftwrap = item.giftwrap,
                        //ProductName = item.ProductName,
                        //QuantityPerUnit = item.QuantityPerUnit,
                        //total_price = item.total_price,
                    });

                }

                return ordersList;
                //return new
                //{
                //    ProfileCode = new
                //    {
                //        ordersList
                //    }
                //};
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}