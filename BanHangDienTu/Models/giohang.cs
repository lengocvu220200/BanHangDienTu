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
    
    public partial class giohang
    {
        public int giohang_id { get; set; }
        public int khachhang_id { get; set; }
        public int sanpham_id { get; set; }
        public int giohang_soluong { get; set; }
        public double giohang_dongia { get; set; }
    
        public virtual khachhang khachhang { get; set; }
        public virtual sanpham sanpham { get; set; }
    }
}
