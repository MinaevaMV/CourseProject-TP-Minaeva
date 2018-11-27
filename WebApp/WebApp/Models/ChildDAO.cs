using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ChildDAO
    {
        public static List<child> GetChild()
        {
            List<child> childs = new List<child>();
            using (var ctx = new kindergartenEntities2())
            {
                string query = "select * from child";
                childs.AddRange(ctx.Database.SqlQuery<child>(query));
            }
            return childs;
        }
        public void CreateChildData(child child)
        {
            using (var ctx = new kindergartenEntities2())
            {
                string query = "insert into child (BDay, father_id, group_id, mother_id, gender, child_patronymic, child_surname,  child_name ) values (@P0, @P1, @P2, @P3, @P4, @P5, @P6, @P7)";
                List<object> paramlist = new List<object>
            {
                child.Bday,
                child.father_id,
                child.group_id,
                child.mother_id,
                child.gender,
                child.child_patronymic,
                child.child_surname,
                child.child_name,
                

            };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);
            }
        }
    }
}