using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT.NET_project_cuoiki.Models
{
    public class CheckoutModel
    {
        private string name,hnum,ward,county,province,mail,phone,note;

        public CheckoutModel()
        {
        }

        public CheckoutModel(string name, string hnum, string ward, string county, string province, string mail, string phone, string note)
        {
            this.Name = name;
            this.Hnum = hnum;
            this.Ward = ward;
            this.County = county;
            this.Province = province;
            this.Mail = mail;
            this.Phone = phone;
            this.Note = note;
        }

        public string Name { get => name; set => name = value; }
        public string Hnum { get => hnum; set => hnum = value; }
        public string Ward { get => ward; set => ward = value; }
        public string County { get => county; set => county = value; }
        public string Province { get => province; set => province = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Note { get => note; set => note = value; }
    }
}