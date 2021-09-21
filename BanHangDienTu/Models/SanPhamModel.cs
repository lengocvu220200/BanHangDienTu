using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHangDienTu.Models
{
    public class SanPhamModel
    {
        banhangdientuEntities conn = new banhangdientuEntities();
        //Lấy danh sách sản phẩm 
        public IEnumerable<sanpham> DanhSachSP()
        {
            var data = (from s in conn.sanphams
                        where s.trangthai_id == 1
                        select s);
            var dataProduct = data.OrderByDescending(x => x.sanpham_id).Skip(0).Take(12);//lấy theo vị trí trong dữ liệu
            return dataProduct.ToList();
        }
        //Cập nhật số lượng sản phẩm
        public void CapNhatSoLuongSP(int idSP, int slSP)
        {
            var list = (from s in conn.sanphams where s.sanpham_id == idSP select s).ToList();
            sanpham sp = SanPhamId(idSP);
            foreach (var item in list)
            {
                sp.sanpham_ten = item.sanpham_ten;
                sp.sanpham_mota = item.sanpham_mota;
                sp.loaisanpham_id = item.loaisanpham_id;
                sp.sanpham_soluong = item.sanpham_soluong - slSP;
                sp.sanpham_urlhinhanh = item.sanpham_urlhinhanh;
                sp.trangthai_id = item.trangthai_id;
                conn.SaveChanges();
                break;
            }   
        }
        //Lấy sản phẩm theo mã sản phẩm
        public sanpham SanPhamId(int id)
        {
            return conn.sanphams.First(m => m.sanpham_id.CompareTo(id) == 0);
        }
        //Lấy danh sách sản phẩm trong giỏ hàng 
        public IEnumerable<giohang> XemGioHang(int idKH)
        {
            var gh = (from s in conn.giohangs
                      where s.khachhang_id == idKH
                      select s).ToList();
            return gh;
        }
        //Kiểm tra sản phẩm đã có trong giỏ hàng hay chưa
        public IEnumerable<giohang> KiemTraSanPhamGioHang(int idKH, int idSP)
        {
            var kt = (from g in conn.giohangs
                      where g.khachhang_id == idKH && g.sanpham_id == idSP
                      select g).ToList();
            
            return kt;
        }
        
        //thêm sản giỏ hàng
        public void ThemGioHang(giohang gh)
        {
            conn.giohangs.Add(gh);
            conn.SaveChanges();
        }
        //Lấy giỏ hàng theo mã giỏ hàng
        public giohang layGioHang(int idGH)
        {
            return conn.giohangs.First(m => m.giohang_id.CompareTo(idGH) == 0);
        }
        //Sửa giỏ hàng
        public void SuaGioHang(giohang gh)
        {
            giohang x = layGioHang(gh.giohang_id);
            x.khachhang_id = gh.khachhang_id;
            x.sanpham_id = gh.sanpham_id;
            x.giohang_soluong = gh.giohang_soluong;
            x.giohang_dongia = gh.giohang_dongia;
            conn.SaveChanges();
        }
        public IEnumerable<giohang> GioHangId(int idGH)
        {
            var gh = (from s in conn.giohangs
                      where s.giohang_id == idGH
                      select s).ToList();
            return gh;
        }
        public void XoaGioHang(int id)
        {
            
            giohang c = layGioHang(id);
            conn.giohangs.Remove(c);
            conn.SaveChanges();
        }
        public int ThemHoaDon(hoadon hd)
        {
            conn.hoadons.Add(hd);
            conn.SaveChanges();
            return hd.hoadon_id;
        }
        public void ThemCTHoaDon(chitiethoadon cthd)
        {
            conn.chitiethoadons.Add(cthd);
            conn.SaveChanges();
        }
        public IEnumerable<chitiethoadon> LayCTHoaDon(int idHD)
        {
            var total = (from n in conn.chitiethoadons where n.hoadon_id == idHD select n).ToList();
            return total;
        }
        public void SuaHoaDon(hoadon hd)
        {
            hoadon x = conn.hoadons.First(m => m.hoadon_id.CompareTo(hd.hoadon_id) == 0);
            x.khachhang_id = hd.khachhang_id;
            x.hoadon_ngaylap = hd.hoadon_ngaylap;
            x.hoadon_tongtien = hd.hoadon_tongtien;
            conn.SaveChanges();
        }
        public void ThemPhieuGiaoHang(phieugiaohang pgh)
        {
            conn.phieugiaohangs.Add(pgh);
            conn.SaveChanges();
        }
        public IEnumerable<sanpham> LoaiSanPham(int idTheLoai, int start, int limit)
        {
            var data = (from s in conn.sanphams 
                        join t in conn.loaisanphams on s.loaisanpham_id equals t.loaisanpham_id
                        where s.loaisanpham_id == idTheLoai && s.trangthai_id == 1
                        select s);
            
            var dataProduct = data.OrderByDescending(x => x.sanpham_id).Skip(start).Take(limit);//lấy theo vị trí trong dữ liệu


            return dataProduct.ToList();
        }
        public int numberPage(int totalProduct, int limit)
        {
            int sotrang = totalProduct / limit;
            if(totalProduct%limit != 0)
            {
                sotrang = sotrang + 1;
            }
            //float numberpage = totalProduct / limit;
            //return (int)Math.Ceiling(numberpage);
            return sotrang;
        }

        public int TongLoaiSanPham(int idTheloai)
        {
            List<sanpham> list = new List<sanpham>();
            list = (from s in conn.sanphams where s.loaisanpham_id == idTheloai && s.trangthai_id == 1 select s).ToList();

            return list.Count();
        }

        public IEnumerable<chitiethoadon> DonHangDaDat(int idKH)
        {
            var data = (from a in conn.chitiethoadons
                        join b in conn.hoadons on a.hoadon_id equals b.hoadon_id
                        where b.khachhang_id == idKH
                        select a).ToList();
            return data;
        }
        public IEnumerable<hoadon> LayHoaDon(int idKH)
        {
            var data = (from a in conn.hoadons
                        join b in conn.khachhangs on a.khachhang_id equals b.khachhang_id
                        where a.khachhang_id == idKH
                        select a).ToList();
            return data;
        }
    }
}