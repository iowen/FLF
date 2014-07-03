using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class AccountRepository : IAccountRepository
    {
        private FLDataDataContext db;

        public AccountRepository(FLDataDataContext context)
        {
            db = context;
        }

        public List<Account> getAllAccounts()
        {
            var accounts = db.Accounts.ToList();
            return accounts;

        }

        public Account getAccount(int id)
        {

            try
            {
                var account = db.Accounts.Single(a => a.AccountId == id);

                return account;
            }
            catch
            {
                Account acc = new Account();
                acc.AccountId = -1;
                return acc;
            }
        }

        public Account getAccount(string email)
        {
            try
            {
                var account = db.Accounts.Single(a => a.Email == email);

                return account;
            }
            catch
            {
                Account acc = new Account();
                acc.AccountId = -1;
                return acc;
            }
        }

        public Account getAccount(string email, string pwd)
        {
            try
            {
                var account = db.Accounts.Single(a => a.Email == email && a.Password == pwd);

                return account;
            }
            catch
            {
                Account acc = new Account();
                acc.AccountId = -1;
                return acc;
            }
        }

        public Account getAccountByName(string first, string last)
        {
            try
            {
                var account = db.Accounts.Single(a => a.FirstName == first && a.LastName == last);

                return account;
            }
            catch
            {
                Account acc = new Account();
                acc.AccountId = -1;
                return acc;
            }
        }

        public int addAccount(Account a)
        {
            db.Accounts.InsertOnSubmit(a);
            db.SubmitChanges();
            return a.AccountId;

        }

        public bool updateAccount(int id, string email, string pwd)
        {
            Account a = getAccount(id);
            if (a.AccountId > 0)
            {
                a.Email = email;
                a.Password = pwd;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public AccountInfoModel login(LoginModel model)
        {
            var info = new AccountInfoModel();

            try
            {
                var ac = db.Accounts.Single(a => a.Email == model.Email && a.Password == model.Password);
                if (ac.AccountId > 0)
                {
                    info.account = ac;

                }
                else
                {
                    info.account = new Account() { AccountId = -1 };
                }

                return info;
            }
            catch
            {
                info.account = new Account() { AccountId = -1 };
                return info;
            }
        }


        public bool emailAvailable(string email)
        {
            var account = (from a in db.Accounts
                           where a.Email == email
                           select a).Any();
            return account;
        }
    }
}