//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanHangDienTu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sanpham()
        {
            this.chitiethoadons = new HashSet<chitiethoadon>();
            this.chitietphieunhaphangs = new HashSet<chitietphieunhaphang>();
            this.giohangs = new HashSet<giohang>();
        }
    
        public int sanpham_id { get; set; }
        public string sanpham_ten { get; set; }
        public string sanpham_mota { get; set; }
        public int loaisanpham_id { get; set; }
        public int sanpham_soluong { get; set; }
        public double sanpham_dongia { get; set; }
        public string sanpham_urlhinhanh { get; set; }
        public int trangthai_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitiethoadon> chitiethoadons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietphieunhaphang> chitietphieunhaphangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<giohang> giohangs { get; set; }
        public virtual loaisanpham loaisanpham { get; set; }
        public virtual trangthai trangthai { get; set; }
    }
}
