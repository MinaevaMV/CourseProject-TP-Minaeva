using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppV2.Models
{
    public class SuperintendentDAO
    {

        public static bool UpdateLogin(superintendent sup)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update superintendent set superintendent_login = @p0 where [superintendent_passport_data] = @p1";
                List<object> paramlist = new List<object>
                {

                sup.superintendent_login,
                sup.superintendent_passport_data,

                };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
