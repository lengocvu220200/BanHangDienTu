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
    
    public partial class phieunhaphang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phieunhaphang()
        {
            this.chitietphieunhaphangs = new HashSet<chitietphieunhaphang>();
        }
    
        public int phieunhaphang_id { get; set; }
        public int nhanvien_id { get; set; }
        public int ncc_id { get; set; }
        public System.DateTime phieunhaphang_ngaylap { get; set; }
        public Nullable<double> phieunhaphang_tongtien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietphieunhaphang> chitietphieunhaphangs { get; set; }
        public virtual nhacungcap nhacungcap { get; set; }
        public virtual nhanvien nhanvien { get; set; }
    }
}
