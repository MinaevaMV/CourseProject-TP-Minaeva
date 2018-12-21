using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppV2.Models
{
    public class TeacherDAO
    {
        public static bool UpdateLogin(teacher teacher)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update teacher set teacher_login = @p0 where [teacher_passport_data] = @p1";
                List<object> paramlist = new List<object>
                {

                teacher.teacher_login,
                teacher.teacher_passport_data,

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