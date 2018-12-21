using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppV2.Models
{
    public class ReportDAO
    {
        public static void CreateReport(report rep)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "insert into report (author_id, auditor_id, text, saved, sended ) values (@P0, @P1, @P2, @P3, @P4)";
                List<object> paramlist = new List<object>
                {
                rep.author_id,
                rep.auditor_id,
                rep.text,
                "not accepted",
                "not sent",

                };
                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);
            }
        }
        public static void UpdateStatus(report rep)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update report set sended = 'sent for checking' where [report_id] = @p0";
                List<object> paramlist = new List<object>
                {

                rep.report_id

                };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);

            }
        }
        public static void UpdateChecking(report rep)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update report set saved = 'accept' where [report_id] = @p0";
                List<object> paramlist = new List<object>
                {

                rep.report_id

                };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);

            }
        }
        public static void UpdateComment(report rep, string comm)
        {
            using (var ctx = new kindergartenEntities())
            {
                string query = "update report set comment = @p0 where [report_id] = @p1";
                List<object> paramlist = new List<object>
                {
                comm,
                rep.report_id

                };

                object[] parameters = paramlist.ToArray();
                int result = ctx.Database.ExecuteSqlCommand(query, parameters);

            }
        }


    }
}
