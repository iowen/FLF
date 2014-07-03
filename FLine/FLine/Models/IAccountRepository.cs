using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }

    public class AccountInfoModel
    {
        public Account account { get; set; }
        public int count { get; set; }
    }

    public class RegisterModel
    {

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public interface IAccountRepository
    {
        List<Account> getAllAccounts();
        Account getAccount(int id);
        Account getAccount(string email);
        Account getAccount(string email, string pwd);

        int addAccount(Account account);
        bool updateAccount(int id, string email, string pwd);
        AccountInfoModel login(LoginModel model);
        bool emailAvailable(string email);
        Account getAccountByName(string first, string last);
    }
}