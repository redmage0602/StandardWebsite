using StandardWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace StandardWebsite.DAL
{
    public class AccountDAL : BaseDAL
    {
        public Account GetById(int id, DeleteFlag deleteFlag)
        {
            try
            {
                Account account = DBContext.Accounts.SingleOrDefault(a => a.Id == id && a.DeleteFlag == deleteFlag);
                return account;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public List<Account> GetByUsernamePassword(string username, string password, DeleteFlag deleteFlag)
        {
            try
            {
                List<Account> accounts = new List<Account>();

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    accounts = DBContext.Accounts.Where(a => a.Username == username
                        && a.Password == password
                        && a.DeleteFlag == deleteFlag
                    ).ToList();
                }

                return accounts;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public Account Update(Account account)
        {
            try
            {
                if (account != null)
                {
                    DBContext.Entry(account).State = EntityState.Modified;
                    DBContext.SaveChanges();
                }

                return GetById(account.Id, account.DeleteFlag);
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}