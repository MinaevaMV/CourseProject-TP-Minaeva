using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppV2.Models;

namespace WebAppV2.Models
{
    public class FatherDAO
    {
        public static List<father> GetFather()
        {
            List<father> mothers = new List<father>();
            using (var ctx = new kindergartenEntities())
            {
                string query = "select * from father";
                mothers.AddRange(ctx.Database.SqlQuery<father>(query));
            }
            return mothers;
        }
        public void CreateFatherData(father father)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "insert into father (father_surname, father_name, father_patronymic, father_passport_data, father_Bday, father_phone, father_education, father_job ) values (@P0, @P1, @P2, @P3, @P4, @P5, @P6, @P7)";
                List<object> paramlist = new List<object>
                {

                father.father_surname,
                father.father_name,
                father.father_patronymic,
                father.father_passport_data,
                father.father_Bday,
                father.father_phone,
                father.father_education,
                father.father_job,

                };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);
            }
        }

        public static bool UpdateLogin(father father)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update father set father_login = @p1 where father_passport_data = @p2";
                List<object> paramlist = new List<object>
                {

                father.father_login,
                father.father_passport_data,

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

        public static void updatefather(father father)
        {

            using (var ctx = new kindergartenEntities())
            {
                father fa = ctx.father.Where(f => f.father_id == father.father_id).FirstOrDefault();

                string upquery = "update father set father_surname = @P0, father_name= @P1, father_patronymic= @P2, father_passport_data= @P3, father_Bday= @P4, father_phone= @P5, father_education= @P6, father_job= @P7";
                List<object> paramlist = new List<object>
                {

                fa.father_surname,
                fa.father_name,
                fa.father_patronymic,
                fa.father_passport_data,
                fa.father_Bday,
                fa.father_phone,
                fa.father_education,
                fa.father_job,

                };
                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(upquery, parameters);
            }
        }

    }
}
