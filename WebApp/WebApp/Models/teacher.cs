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
    
    public partial class teacher
    {
        public int teacher_id { get; set; }
        public int organization_id { get; set; }
        public string teacher_surname { get; set; }
        public string teacher_name { get; set; }
        public string teacher_patronymic { get; set; }
        public string teacher_education { get; set; }
        public string teacher_category { get; set; }
        public int teacher_experience { get; set; }
        public int teacher_group_id { get; set; }
        public string teacher_phone { get; set; }
    
        public virtual group group { get; set; }
        public virtual organization organization { get; set; }
    }
}
