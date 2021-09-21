using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHangDienTu.Models
{
    public class KhachHangModel
    {
        banhangdientuEntities conn = new banhangdientuEntities();
        //Đăng nhập
        public IEnumerable<khachhang> DangNhap(khachhang model)
        {
            var dn = (from p in conn.khachhangs
                      where p.khachhang_email.Equals(model.khachhang_email) && p.khachhang_matkhau.Equals(model.khachhang_matkhau)
                      select p).ToList();
            return dn;
        }
        public khachhang KhachHangId(int idKH)
        {
            return conn.khachhangs.First(m => m.khachhang_id.CompareTo(idKH) == 0);
        }
        public IEnumerable<khachhang> DangKy(khachhang kh)
        {
            conn.khachhangs.Add(kh);
            conn.SaveChanges();

            var dk = (from p in conn.khachhangs
                      where p.khachhang_email.Equals(kh.khachhang_email) && p.khachhang_matkhau.Equals(kh.khachhang_matkhau)
                      select p).ToList();
            return dk;
        }
    }
}