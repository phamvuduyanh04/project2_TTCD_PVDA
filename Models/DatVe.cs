//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJECT2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DatVe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatVe()
        {
            this.ThanhToans = new HashSet<ThanhToan>();
        }
    
        public int MaDatVe { get; set; }
        public int MaKhachHang { get; set; }
        public int MaChuyenBay { get; set; }
        public System.DateTime NgayDat { get; set; }
        public int SoLuongVe { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
    
        public virtual ChuyenBay ChuyenBay { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
