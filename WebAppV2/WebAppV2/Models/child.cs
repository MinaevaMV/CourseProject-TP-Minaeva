//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class child
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public child()
        {
            this.child_portfolio = new HashSet<child_portfolio>();
        }
    
        public int child_id { get; set; }
        public string child_surname { get; set; }
        public string child_name { get; set; }
        public string child_patronymic { get; set; }
        public Nullable<System.DateTime> Bday { get; set; }
        public string gender { get; set; }
        public Nullable<int> mother_id { get; set; }
        public Nullable<int> father_id { get; set; }
        public Nullable<int> group_id { get; set; }
    
        public virtual father father { get; set; }
        public virtual group group { get; set; }
        public virtual mother mother { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<child_portfolio> child_portfolio { get; set; }

        [NotMapped]
        public List<mother> momnameslist = new List<mother>();
        public List<father> dadnameslist = new List<father>();
        public List<group> groupslist = new List<group>();
    }
}
