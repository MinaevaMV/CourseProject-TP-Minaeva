using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppV2.Models;

namespace WebApp.Models
{
    public class MotherDAO
    {
        public static List<mother> GetMother()
        {
            List<mother> mothers = new List<mother>();
            using (var ctx = new kindergartenEntities())
            {
                string query = "select * from mother";
                mothers.AddRange(ctx.Database.SqlQuery<mother>(query));
            }
            return mothers;
        }
        public void CreateMotherData(mother mother)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "insert into mother (mother_surname, mother_name, mother_patronymic, mother_passport_data, mother_Bday, mother_phone, mother_education, mother_job ) values (@P0, @P1, @P2, @P3, @P4, @P5, @P6, @P7)";
                List<object> paramlist = new List<object>
            {

                mother.mother_surname,
                mother.mother_name,
                mother.mother_patronymic,
                mother.mother_passport_data,
                mother.mother_Bday,
                mother.mother_phone,
                mother.mother_education,
                mother.mother_job,




            };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);
            }
        }

        public static void updatemother(mother mother)
        {

            using (var ctx = new kindergartenEntities())
            {
                

                string upquery = "update mother set mother_surname = @P0, mother_name= @P1, mother_patronymic= @P2, mother_passport_data= @P3, mother_Bday= @P4, mother_phone= @P5, mother_education= @P6, mother_job= @P7 where mother_id = @P8";
                List<object> paramlist = new List<object>
                {

                mother.mother_surname,
                mother.mother_name,
                mother.mother_patronymic,
                mother.mother_passport_data,
                mother.mother_Bday,
                mother.mother_phone,
                mother.mother_education,
                mother.mother_job,
                mother.mother_id

                };
                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(upquery, parameters);
            }
        }

        public static bool UpdateLogin(mother mother)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update mother set mother_login = @p0 where [mother_passport_data] = @p1";
                List<object> paramlist = new List<object>
                {

                mother.mother_login,
                mother.mother_passport_data,

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