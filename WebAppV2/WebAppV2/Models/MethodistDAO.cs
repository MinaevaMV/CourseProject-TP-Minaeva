using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppV2.Models
{
    public class MethodistDAO
    {

        public static bool SearchPassport(methodist methodist)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "select methodist_id from methodist where methodist_passport_data=@P0";
                List<object> paramlist = new List<object>
                {
                methodist.methodist_passport_data,
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

        public static bool UpdateLogin(methodist methodist)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update methodist set methodist_login = @p0 where [methodist_passport_data] = @p1";
                List<object> paramlist = new List<object>
                {

                methodist.methodist_login,
                methodist.methodist_passport_data,

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