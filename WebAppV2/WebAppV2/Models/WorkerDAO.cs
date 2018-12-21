using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppV2.Models
{
    public class WorkerDAO
    {
        public static List<methodist> GetMethodist()
        {
            List<methodist> methodists = new List<methodist>();

            using (var ctx = new kindergartenEntities())
            {
                string mquery = "select * from methodist";
                methodists.AddRange(ctx.Database.SqlQuery<methodist>(mquery));

            }


            return methodists;
        }

        public static List<teacher> GetTeacher()
        {


            List<teacher> teachers = new List<teacher>();
            using (var ctx = new kindergartenEntities())
            {


                teachers.AddRange(from a in ctx.teacher select a);
            }


            return teachers;
        }

        public static List<psychologist> GetPsyhologist()
        {

            List<psychologist> psyhos = new List<psychologist>();

            using (var ctx = new kindergartenEntities())
            {

                string pquery = "select * from psyhologist";
                psyhos.AddRange(ctx.Database.SqlQuery<psychologist>(pquery));

            }


            return psyhos;
        }

       
    }
}