﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using OnlineSmartPhoneShop_CommonFiles;


namespace OnlineSmartPhoneShop_Entities.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string SmartphoneID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
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
