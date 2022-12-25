using LT.NET_project_cuoiki.Models;
using System;
using System.Data;
using System.Web.Helpers;

namespace LT.NET_project_cuoiki.dao
{
    public class UserDAO
    {
        public UserModel Login(string username, string password)
        {   
            ConnectionMysql connection = new ConnectionMysql();
            var query = connection.SQL_query_to_DataTable("select * from user where username = '"+ username +"' and password = '"+password +"'");
            UserModel user = null;
            if (query.Rows != null)
            {
                foreach (DataRow r in query.Rows)
                {   
                    user = new UserModel();
                    user.Id = Convert.ToInt32(r["id"].ToString());
                    user.Username = r["username"].ToString();
                    user.Password = r["password"].ToString();
                    user.Fullname = r["full_name"].ToString();
                    user.Email = r["email"].ToString();
                    user.Phone = Convert.ToInt32(r["phone_number"]);
                    user.CreateAt = r["created_at"].ToString();
                    user.UpdateAt = r["updated_at"].ToString();
                    user.RoleId = Convert.ToInt32(r["role_id"]);
                }

            }
            return user;
        }
        public UserModel checkUserExist(string username)
        {
            ConnectionMysql connection = new ConnectionMysql();
            var query = connection.SQL_query_to_DataTable("select * from user where username = '" + username + "'");
            UserModel user = null;
            if (query.Rows != null)
            {
                foreach (DataRow r in query.Rows)
                {
                    user = new UserModel();
                    user.Id = Convert.ToInt32(r["id"].ToString());
                    user.Username = r["username"].ToString();
                    user.Password = r["password"].ToString();
                    user.Fullname = r["full_name"].ToString();
                    user.Email = r["email"].ToString();
                    user.Phone = Convert.ToInt32(r["phone_number"]);
                    user.CreateAt = r["created_at"].ToString();
                    user.UpdateAt = r["updated_at"].ToString();
                    user.RoleId = Convert.ToInt32(r["role_id"]);
                }

            }
            return user;

        }
        public UserModel checkEmailExist(string email)
        {
            ConnectionMysql connection = new ConnectionMysql();
            var query = connection.SQL_query_to_DataTable("select * from user where email = '" + email + "'");
            UserModel user = null;
            if (query.Rows != null)
            {
                foreach (DataRow r in query.Rows)
                {
                    user = new UserModel();
                    user.Id = Convert.ToInt32(r["id"].ToString());
                    user.Username = r["username"].ToString();
                    user.Password = r["password"].ToString();
                    user.Fullname = r["full_name"].ToString();
                    user.Email = r["email"].ToString();
                    user.Phone = Convert.ToInt32(r["phone_number"]);
                    user.CreateAt = r["created_at"].ToString();
                    user.UpdateAt = r["updated_at"].ToString();
                    user.RoleId = Convert.ToInt32(r["role_id"]);
                }

            }
            return user;

        }
        public void Register(string username, string email, string password)
        {
            ConnectionMysql connection = new ConnectionMysql();
            connection.SQL_query_to_DataTable("INSERT INTO `user` (`username`, `password`, full_name, email, phone_number, created_at, updated_at, role_id) VALUES('"+username+"', '"+password+"', null, '"+email+"',0, CURRENT_DATE, CURRENT_DATE, 0)");
        }
        public void forgotPassword(string username, int password)
        {
            ConnectionMysql connection = new ConnectionMysql();
            connection.SQL_query_to_DataTable("UPDATE `user` SET `password` = '" + password + "' WHERE username = '"+username+"'");
        }
        public void sendMaillForgotPassword(string emailTo, int password) 
        {
            string text = "<h1 style=\"padding: 0;font-size: 41px;color: #2672ec;font-family:sans-serif\">Quên mật khẩu tài khoản</h1>" +
                "<p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Bạn vừa sử dụng chức năng quên mật khẩu đối với tài khoản được sử dụng với email này.</p>" +
                "<p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Mật khẩu mới của bạn là: <strong>" + password + "</p>" +
                "<p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Hãy bảo mật tài khoản của bạn cẩn thận.</p>";
            string subject = "Lấy lại mật khẩu";
            WebMail.Send(emailTo, subject, text, null, null, null, true, null, null, null, null, null, null);
        }
    }
}