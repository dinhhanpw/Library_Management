//------------------------------------------------------------------------------
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
    using System.Collections.Generic;

    public partial class CTPhieuMuon
    {
        public CTPhieuMuon()
        {
            BiAn = false;
            BiMat = false;
            TienPhat = 0;
            NgayTra = null;
        }

        public int IdPhieuMuon { get; set; }
        public int IdSach { get; set; }
        public Nullable<DateTime> NgayTra { get; set; }
        public Nullable<bool> BiMat { get; set; }
        public Nullable<int> TienPhat { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> BiAn { get; set; }

        public virtual PhieuMuon PhieuMuon { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
