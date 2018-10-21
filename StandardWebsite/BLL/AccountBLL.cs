using StandardWebsite.Common;
using StandardWebsite.DAL;
using StandardWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardWebsite.BLL
{
    public class AccountBLL : BaseBLL
    {
        private AccountDAL _accountDAL = new AccountDAL();

        public SigninStatus Signin(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                password = Util.HashStringUsingSHA512(username + password);

                List<Account> acounts = _accountDAL.GetByUsernamePassword(username, password, DeleteFlag.Active);

                if (acounts != null)
                {
                    switch (acounts.Count)
                    {
                        case 0:
                            return SigninStatus.Incorrect;

                        case 1:
                            Account account = acounts.First();
                            account.LastLogin = DateTime.Now;
                            account = _accountDAL.Update(account);

                            if (account != null)
                            {
                                Session["accountId"] = account.Id;
                                Session["accountUsername"] = account.Username;
                                Session["accountAvatar"] = account.Avatar;

                                return SigninStatus.Success;
                            }

                            return SigninStatus.Failure;

                        default:
                            return SigninStatus.Failure;
                    }
                }

                return SigninStatus.Failure;
            }

            return SigninStatus.Incorrect;
        }
    }

    public enum SigninStatus
    {
        Success = 0,
        Incorrect = 1,
        Failure = 2
    }
}