﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class kindergartenEntities2 : DbContext
    {
        public kindergartenEntities2()
            : base("name=kindergartenEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<child> child { get; set; }
        public virtual DbSet<child_portfolio> child_portfolio { get; set; }
        public virtual DbSet<father> father { get; set; }
        public virtual DbSet<group> group { get; set; }
        public virtual DbSet<methodist> methodist { get; set; }
        public virtual DbSet<mother> mother { get; set; }
        public virtual DbSet<organization> organization { get; set; }
        public virtual DbSet<psychologist> psychologist { get; set; }
        public virtual DbSet<report> report { get; set; }
        public virtual DbSet<superintendent> superintendent { get; set; }
        public virtual DbSet<teacher> teacher { get; set; }
    }
}
