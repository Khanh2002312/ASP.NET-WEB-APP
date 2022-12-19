using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT.NET_project_cuoiki.Entity
{
    public class ProductEntity
    {
        int id;
        string category;
        string title, keyword;
        int price;
        int discount;
        string design;
        string thumbnail;
        string description;
        int quantity;
        int is_on_sale;

        public int Id { get => id; set => id = value; }
        public string Category { get => category; set => category = value; }
        public string Title { get => title; set => title = value; }
        public string Keyword { get => keyword; set => keyword = value; }
        public int Price { get => price; set => price = value; }
        public int Discount { get => discount; set => discount = value; }
        public string Design { get => design; set => design = value; }
        public string Thumbnail { get => thumbnail; set => thumbnail = value; }
        public string Description { get => description; set => description = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Is_on_sale { get => is_on_sale; set => is_on_sale = value; }

        public ProductEntity(int id, string category, string title, string keyword, int price, int discount, string design, string thumbnail, string description, int quantity, int is_on_sale)
        {
            this.Id = id;
            this.Category = category;
            this.Title = title;
            this.Keyword = keyword;
            this.Price = price;
            this.Discount = discount;
            this.Design = design;
            this.Thumbnail = thumbnail;
            this.Description = description;
            this.Quantity = quantity;
            this.Is_on_sale = is_on_sale;
        }

        public ProductEntity(int id, string category, string title, int price, string design, string thumbnail, string description, int quantity)
        {
            this.Id = id;
            this.Category = category;
            this.Title = title;
            this.Price = price;
            this.Design = design;
            this.Thumbnail = thumbnail;
            this.Description = description;
            this.Quantity = quantity;
        }

        public ProductEntity()
        {
        }


    }
}