using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSmartPhoneShop_Entities.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string SmartphoneID { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public string EmailAddress { get; set; }

        public string ShipAddress { get; set; }

        Smartphone smartphone = new Smartphone();
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=OnlineShop-Dev;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        
        public string OrderPhone(Order order)
        {
            order.SmartphoneID = smartphone.Id.ToString();
            cmd.CommandText = "Insert into Orders values('" + order.OrderID + "','" + order.SmartphoneID + "','" + order.FirstName + "','" + order.LastName + "','" +order.EmailAddress + "', '" + order.ShipAddress + "')";
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Clone();
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
