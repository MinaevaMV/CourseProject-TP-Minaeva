using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppV2.Models
{
    public class Family
    {
        public int id_child { get; set; }
        public int id_mother { get; set; }
        public int id_father { get; set; }

        public Family(int id_child, int id_mother, int id_father)
        {
            this.id_child = id_child;
            this.id_mother = id_mother;
            this.id_father = id_father;
    }
    }
  
}