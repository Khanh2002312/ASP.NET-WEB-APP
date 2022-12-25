using LT.NET_project_cuoiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT.NET_project_cuoiki.Models
{
    public class DetailModel
    {
        private ProductEntity product;
        private string categoryName;
        private string gem;
        private List<ProductEntity> listProduct;
        public DetailModel()
        {
        }

        public DetailModel(ProductEntity product, string categoryName, string gem, List<ProductEntity> listProduct)
        {
            this.product = product;
            this.categoryName = categoryName;
            this.gem = gem;
            this.listProduct = listProduct;
        }

        public ProductEntity Product { get => product; set => product = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string Gem { get => gem; set => gem = value; }
        public List<ProductEntity> ListProduct { get => listProduct; set => listProduct = value; }
    }
}