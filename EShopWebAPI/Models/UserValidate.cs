using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopWebAPI.Models
{
    public class UserValidate
    {
        public static bool Login(string user, string pass)
        {
            using (EshopEntities db = new EshopEntities())
            {
                var account = db.Accounts.SingleOrDefault(u => u.Username == user &&
   u.Password == pass);
                if (account != null)
                    return true;
                else
                    return false;
            }
        }
    }
}