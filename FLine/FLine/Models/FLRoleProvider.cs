using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FLine.Models
{
    public class FLRoleProvider: RoleProvider
    {
        private IAccountRepository _repository;

        public FLRoleProvider() : this(new AccountRepository(new FLDataDataContext()))
        {   
        }

        public FLRoleProvider(IAccountRepository repo)
        {
            _repository = repo;
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["flfit"];
            if (roleName == "Account")
            {
                //replace
                if (cookie["role"].Contains("Account"))
                    return true;
                else
                    return false;

            }
            if (roleName == "Administrator")
            {
                //replace
                if (cookie["role"].Contains("Administrator"))
                    return true;
                else
                    return false;

            }
            return false;
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string email)
        {

            AccountInfoModel model = new AccountInfoModel();
            LoginModel li = new LoginModel();
            Account acc = _repository.getAccount(email);
            li.Password = acc.Password;
            li.Email = acc.Email;
            model = _repository.login(li);
            if (model.account.AccountId > 0)
            {
                var roles = new List<string>();
                if (model.account.AccountId > 0)
                    roles.Add("Account");

                if (model.account.Administrators.Any())
                     roles.Add("Administrator");              

                return roles.ToArray();
            }
            return new string[0];
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}