﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SESSI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseOfSessiEntities1 : DbContext
    {
        public DatabaseOfSessiEntities1()
            : base("name=DatabaseOfSessiEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<DownloadGeneral> DownloadGenerals { get; set; }
        public virtual DbSet<DownloadTender> DownloadTenders { get; set; }
        public virtual DbSet<HomeBanner> HomeBanners { get; set; }
        public virtual DbSet<HomeGallery> HomeGalleries { get; set; }
        public virtual DbSet<HomeTeam> HomeTeams { get; set; }
        public virtual DbSet<OurTeamMember> OurTeamMembers { get; set; }
    }
}
