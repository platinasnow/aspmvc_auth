using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace auth_test.Models
{
    public class User 
    {
        public string Email { get; set; }
        public string Roles { get; set; }
        public string Password { get; set; }

    }

    public static class Repository
    {
        static List<User> users = new List<User>() {

        new User() {Email="admin",Roles="Admin,Editor",Password="1" },
        new User() {Email="editor",Roles="Editor",Password="1" }
    };

        public static User GetUserDetails(User user)
        {
            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "전자 메일")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "암호")]
        public string Password { get; set; }

        [Display(Name = "사용자 이름 및 암호 저장")]
        public bool RememberMe { get; set; }
    }
}