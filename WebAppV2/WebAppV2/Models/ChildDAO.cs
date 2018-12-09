using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppV2.Models;

namespace WebApp.Models
{
    public class ChildDAO
    {
        public static List<child> GetChild()
        {
            List<child> childs = new List<child>();
            using (var ctx = new kindergartenEntities())
            {
                string query = "select * from child";
                childs.AddRange(ctx.Database.SqlQuery<child>(query));
            }
            return childs;
        }

        public static child getById(int id)
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                return (from a in ctx.child where a.child_id == id select a).FirstOrDefault();
            }
        }
        public void CreateChildData(child child)
        {
            using (var ctx = new kindergartenEntities())
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
                //   string idquery = "select child_id from child where  BDay = @P0, father_id= @P1, group_id= @P2, mother_id= @P3, gender= @P4, child_patronymic= @P5, child_surname= @P6,  child_name= @P7";
                int id = ctx.child.Where(c => c.child_surname == child.child_surname && c.child_name == child.child_name && c.gender == child.gender && c.father_id == child.father_id && c.mother_id == child.mother_id).FirstOrDefault().child_id;
                CreateVoidportfolio(id);
            }
        }
        public void CreateVoidportfolio(int child_id)
        {

            child_portfolio cp = new child_portfolio();
            cp.child_id = child_id;
            using (var ctx = new kindergartenEntities())
            {
                ctx.child_portfolio.Add(cp);
                ctx.SaveChanges();

            }
        }
    }

}