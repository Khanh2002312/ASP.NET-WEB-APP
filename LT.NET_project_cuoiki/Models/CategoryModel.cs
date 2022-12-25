using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT.NET_project_cuoiki.Models
{
    public class CategoryModel
    {

        int id;
        int parent_id;
        string name;


        public CategoryModel(int id, int parent_id, string name)
        {
            this.id = id;
            this.parent_id = parent_id;
            this.name = name;
        }

        public CategoryModel()
        {
        }

        public int Id { get => id; set => id = value; }
        public int Parent_id { get => parent_id; set => parent_id = value; }
        public string Name { get => name; set => name = value; }
    }
}