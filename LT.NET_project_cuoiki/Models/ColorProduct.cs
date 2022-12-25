using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT.NET_project_cuoiki.Models
{
    public class ColorProduct
    {
        int id_product, id_color;

        public int Id_product { get => id_product; set => id_product = value; }
        public int Id_color { get => id_color; set => id_color = value; }

        public ColorProduct(int id_product, int id_color)
        {
            this.id_product = id_product;
            this.id_color = id_color;
        }
    }
}