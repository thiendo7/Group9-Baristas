using CoffeeWebsite.Models;
using System;
using System.Linq;

namespace CoffeeWebsite.Business
{
    public class AccountService
    {
        private static AccountService instance;

        public static AccountService Instance
        {
            get { if (instance == null) instance = new AccountService(); return instance; }
            private set => instance = value;
        }

        public Account GetAccountLogin(LoginModel model)
        {
            using(var db = new BaristasEntities())
            {
                return db.Accounts
                    .Include("AccountType")
                    .FirstOrDefault(x => x.UserName == model.UserName 
                                        && x.Password == model.Password);
            }
        }

        public Account CreateAccount(UserModel model)
        {
            Account account = null;

            using (var db = new BaristasEntities())
            {
                var isExist = db.Accounts
                    .SingleOrDefault(x => x.UserName == model.UserName);

                if (isExist != null)
                {
                    return null;
                }

                account = new Account
                {
                    AccountID = 0,
                    AccountTypeID = 2, //chỗ này bị lỗi vi phạm khóa ngoại vì không có AccountTypeID nào = 0
                    Address = model.Address,
                    CustomerName = model.CustomerName,
                    Email = model.Email,
                    Password = model.Password,
                    UserName = model.UserName,
                    Phone = model.Phone
                };

                db.Accounts.Add(account);

                if (db.SaveChanges() > 0)
                {
                    return GetUserByUsername(model.UserName);
                }
            }

            return account;
        }

        public Account GetUserByUsername(string username)
        {
            using(var db = new BaristasEntities())
            {
                var account = db.Accounts
                    .Include("AccountType")
                    .FirstOrDefault(x => x.UserName == username);

                account.Bills = db.Bills.Include("Payment").Where(x => x.AccountID == account.AccountID).ToList();

                return account;
            }
        }

        public string ChangePassword(string username, ChangePasswordModel model)
        {
            string returnMessage = string.Empty;

            using(var db = new BaristasEntities())
            {
                Account currentAccount = db.Accounts
                    .FirstOrDefault(x => x.UserName == username);

                if (currentAccount == null)
                {
                    returnMessage = "Đã có lỗi xảy ra! Xin vui lòng thử lại sau";
                    return returnMessage;
                }

                if (currentAccount.Password != model.PasswordOld)
                {
                    returnMessage = "Mật khẩu cũ không trùng khớp! Xin vui lòng thử lại";
                    return returnMessage;
                }

                currentAccount.Password = model.PasswordNew;

                if (db.SaveChanges() > 0)
                {
                    returnMessage = "SUCCESS";
                }

                returnMessage = "Đã có lỗi xảy ra! Xin vui lòng thử lại sau";

                return returnMessage;
            }
        }

        public int UpdateProfile(AccountModel model, string username)
        {
            using (var db = new BaristasEntities())
            {
                var account = db.Accounts
                    .SingleOrDefault(x => x.UserName == username);

                if (account == null)
                {
                    return default;
                }

                account.Address = model.Address;
                account.CustomerName = model.CustomerName;
                account.Email = model.Email;
                account.Phone = model.Phone;

                return db.SaveChanges();
            }
        }
    }
}