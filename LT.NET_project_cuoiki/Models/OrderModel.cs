using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT.NET_project_cuoiki.Models
{
    public class OrderModel
    {
        int order_id, user_id, address_id;
        string fullname, email, phone;
        string date;
        int total;
        string pay_method;
        int status;

        public OrderModel(int order_id, string fullname, int total, int status)
        {
            this.Order_id = order_id;
            this.Fullname = fullname;
            this.Total = total;
            this.Status = status;
        }

        public int Order_id { get => order_id; set => order_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public int Address_id { get => address_id; set => address_id = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Date { get => date; set => date = value; }
        public int Total { get => total; set => total = value; }
        public string Pay_method { get => pay_method; set => pay_method = value; }
        public int Status { get => status; set => status = value; }
    }
}