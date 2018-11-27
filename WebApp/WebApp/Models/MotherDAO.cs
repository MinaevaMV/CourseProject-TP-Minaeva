using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MotherDAO
    {
        public static List<mother> GetMother()
        {
            List<mother> mothers = new List<mother>();
            using (var ctx = new kindergartenEntities2())
            {
                string query = "select * from mother";
                mothers.AddRange(ctx.Database.SqlQuery<mother>(query));
            }
            return mothers;
        }
        public void CreateMotherData(mother mother)
        {
            using (var ctx = new kindergartenEntities2())
            {
                string query = "insert into mother (mother_name, mother_surname, mother_patronymic ) values (@P0, @P1, @P2)";
                List<object> paramlist = new List<object>
            {
                mother.mother_name,
                mother.mother_surname,
                mother.mother_patronymic,



            };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);
            }
        }
    }
}