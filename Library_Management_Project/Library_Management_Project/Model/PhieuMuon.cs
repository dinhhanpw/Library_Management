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
    
    public partial class PhieuMuon : ValidatableBase<PhieuMuon>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuon()
        {
            this.CTPhieuMuons = new HashSet<CTPhieuMuon>();
            BiAn = false;
        }

        static PhieuMuon()
        {
            validator = new BorrowReceiptValidator();
        }

        private int? idDocgia;
        private DateTime? ngayMuon;

        public int Id { get; set; }
        public Nullable<int> IdDocGia {
            get { return idDocgia; }
            set { SetValidatableProperty(ref idDocgia, value, this); }
        }
        public Nullable<DateTime> NgayMuon
        {
            get { return ngayMuon; }
            set { SetValidatableProperty(ref ngayMuon, value, this); }
        }
        public Nullable<bool> BiAn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuMuon> CTPhieuMuons { get; set; }
        public virtual DocGia DocGia { get; set; }
    }
}
