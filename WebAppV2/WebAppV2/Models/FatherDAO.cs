using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppV2.Models;

namespace WebApp.Models
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
    }
}