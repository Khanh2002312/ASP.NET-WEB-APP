using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace LT.NET_project_cuoiki.Models
{
    public class UserModel
    {
        public int Id { get; set;  }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }
        public int RoleId { get; set; }
        public UserModel()
        {

        }

        public UserModel(int id, string username, string password, string fullname, string email, int phone, string createAt, string updateAt, int roleId)
        {
            Id = id;
            Username = username;
            Password = password;
            Fullname = fullname;
            Email = email;
            Phone = phone;
            CreateAt = createAt;
            UpdateAt = updateAt;
            RoleId = roleId;
        }
    }
}

