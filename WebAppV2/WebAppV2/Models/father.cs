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
    using System.ComponentModel.DataAnnotations;

    public partial class father
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public father()
        {
            this.child = new HashSet<child>();
        }
    
        public int father_id { get; set; }
        public string father_surname { get; set; }
        public string father_name { get; set; }
        public string father_patronymic { get; set; }
        public string father_passport_data { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime father_Bday { get; set; }
        public string father_phone { get; set; }
        public string father_education { get; set; }
        public string father_job { get; set; }
        public string father_login { get; set; }
        public string father_password { get; set; }
        public string fio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<child> child { get; set; }
    }
}
