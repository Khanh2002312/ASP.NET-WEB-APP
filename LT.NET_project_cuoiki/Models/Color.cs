using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT.NET_project_cuoiki.Models
{
    public class Color
    {
        int id;
        string name_color;

        public int Id { get => id; set => id = value; }
        public string Name_color { get => name_color; set => name_color = value; }

        public Color(int id, string color)
        {
            this.id = id;
            this.name_color = color;
        }
    }
}