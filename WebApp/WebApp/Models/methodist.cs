//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class methodist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public methodist()
        {
            this.report = new HashSet<report>();
        }
    
        public int methodist_id { get; set; }
        public int organization_id { get; set; }
        public string methodist_surname { get; set; }
        public string methodist_name { get; set; }
        public string methodist_patronymic { get; set; }
        public string methodist_education { get; set; }
        public string methodist_category { get; set; }
        public int methodist_experience { get; set; }
        public int methodist_cabinet { get; set; }
        public string methodist_phone { get; set; }
    
        public virtual organization organization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<report> report { get; set; }
    }
}
