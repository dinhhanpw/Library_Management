﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Management_Project.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLiThuVienEntities : DbContext
    {
        public QuanLiThuVienEntities()
            : base("name=QuanLiThuVienEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CTPhieuMuon> CTPhieuMuons { get; set; }
        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<LoaiDocGia> LoaiDocGias { get; set; }
        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }
        public virtual DbSet<QuyDinh> QuyDinhs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
    }
}
