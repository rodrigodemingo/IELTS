﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IELTSDataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IELTSOnlineEntities : DbContext
    {
        public IELTSOnlineEntities()
            : base("name=IELTSOnlineEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AddressInfo> AddressInfoes { get; set; }
        public DbSet<OfficeUse> OfficeUses { get; set; }
        public DbSet<TestInfo> TestInfoes { get; set; }
        public DbSet<StudentInfo> StudentInfoes { get; set; }
    }
}
