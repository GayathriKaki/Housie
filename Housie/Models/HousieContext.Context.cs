﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Housie.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_housieEntities : DbContext
    {
        public db_housieEntities()
            : base("name=db_housieEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tb_tickets> tb_tickets { get; set; }
        public DbSet<tbl_customers> tbl_customers { get; set; }
        public DbSet<tbl_gamemaster> tbl_gamemaster { get; set; }
        public DbSet<tbl_gameplay> tbl_gameplay { get; set; }
        public DbSet<tbl_games> tbl_games { get; set; }
        public DbSet<tbl_picknumber> tbl_picknumber { get; set; }
        public DbSet<tbl_winner> tbl_winner { get; set; }
    }
}
