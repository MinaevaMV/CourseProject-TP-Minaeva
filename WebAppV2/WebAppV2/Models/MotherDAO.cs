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
    }
}