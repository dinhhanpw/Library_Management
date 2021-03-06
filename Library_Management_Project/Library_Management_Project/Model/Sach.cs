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
    using Library_Management_Project.Helper;
    using Library_Management_Project.Helper.Validator;
    using System;
    using System.Collections.Generic;

    public partial class Sach : ValidatableBase<Sach>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.CTPhieuMuons = new HashSet<CTPhieuMuon>();
            BiAn = false;
        }

        static Sach()
        {
            validator = new BookValidator();
        }

        private string ten;
        private int? idLoai;
        private string tacGia;
        private int? namXB;
        private string nhaXB;
        private DateTime? ngayNhap;
        private int? soLuong;
        private int? gia;


        public int Id { get; set; }
        public string Ten
        {
            get { return ten; }
            set { SetValidatableProperty(ref ten, value, this); }
        }
        public Nullable<int> IdLoai
        {
            get { return idLoai; }
            set { SetBindableProperty(ref idLoai, value); }
        }
        public string TacGia
        {
            get { return tacGia; }
            set { SetValidatableProperty(ref tacGia, value, this); }
        }
        public Nullable<int> NamXB
        {
            get { return namXB; }
            set { SetValidatableProperty(ref namXB, value, this); }
        }
        public string NhaXB
        {
            get { return nhaXB; }
            set { SetValidatableProperty(ref nhaXB, value, this); }
        }
        public Nullable<DateTime> NgayNhap
        {
            get { return ngayNhap; }
            set { SetValidatableProperty(ref ngayNhap, value, this); }
        }
        public Nullable<int> SoLuong
        {
            get { return soLuong; }
            set { SetValidatableProperty(ref soLuong, value, this); }
        }
        public Nullable<int> Gia
        {
            get { return gia; }
            set { SetValidatableProperty(ref gia, value, this); }
        }
        public Nullable<bool> BiAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuMuon> CTPhieuMuons { get; set; }
        public virtual LoaiSach LoaiSach { get; set; }
    }
}
