using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppV2.Models
{
    public class PsychologistDAO
    {
        public static bool SearchPassport(psychologist psycho)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "select methodist_id from methodist where methodist_passport_data=@P0";
                List<object> paramlist = new List<object>
                {
                psycho.psychologist_passport_data,
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