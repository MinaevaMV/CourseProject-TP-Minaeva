using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppV2.Models
{
    public class ChildportfolioDAO
    {

        public static child_portfolio getPortfolioById(int id)
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                return (from a in ctx.child_portfolio where a.child_id == id select a).FirstOrDefault();
            }
        }

        public void CreateVoidportfolio(child child)
        {
            child_portfolio cp = new child_portfolio();
            cp.child_id = child.child_id;
            using (var ctx = new kindergartenEntities())
            {
             
                ctx.child_portfolio.Add(cp);
                ctx.SaveChanges();


            }
        }

        public static int UpdatePortfolio(child_portfolio portfolio)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update portfolio set child_private_health_data = @p1, child_private_mental_data = @p2, child_achivements = @p3   where child_id = @p4";
                List<object> paramlist = new List<object>
                {

                portfolio.child_private_health_data,
                portfolio.child_private_mental_health_data,
                portfolio.child_achivements,
                portfolio.child_id,

                };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);
                return result;
              
            }
        }
    }
}