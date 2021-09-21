using BanHangDienTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangDienTu.Controllers
{
    public class SanPhamController : Controller
    {
        SanPhamModel spModel = new SanPhamModel();
        KhachHangModel khModel = new KhachHangModel();
        // GET: SanPham
        public ActionResult Index()
        {

            ViewBag.DS = spModel.DanhSachSP();
            return View();
        }
        public ActionResult ChiTietSanPham(int id)
        {
            ViewBag.ChiTiet = spModel.SanPhamId(id);
            return View(spModel.SanPhamId(id));
        }
        public ActionResult XemGioHang()
        {
            //int idKH = 3;
            int idKH = Int32.Parse(Session["MaKH"].ToString());
            ViewBag.XemGioHang = spModel.XemGioHang(idKH);
            return View();
        }
        public ActionResult ThemGioHang(int id, int sl)
        {

            sanpham sp = spModel.SanPhamId(id);
            int idKH = Int32.Parse(Session["MaKH"].ToString());
            //int idKH = 3;
            giohang gh = new giohang();
            gh.khachhang_id = idKH;
            gh.sanpham_id = id;
            gh.giohang_dongia = sp.sanpham_dongia;

            var kt = spModel.KiemTraSanPhamGioHang(idKH, id);
            if (kt.Count() == 0)
            {
                gh.giohang_soluong = sl;
                spModel.ThemGioHang(gh);
            }
            else
            {
                foreach (var item in kt)
                {
                    gh.giohang_id = item.giohang_id;
                    gh.giohang_soluong = sl + item.giohang_soluong;
                    spModel.SuaGioHang(gh);
                }
            }
            TempData["ThemThanhCong"] = "Thêm thành công.";
            return Redirect(Request.UrlReferrer.ToString());//load lại trang
        }
        public ActionResult CapNhatSoLuong(int id, int sl)
        {
            giohang gh = new giohang();
            var layGH = spModel.GioHangId(id);
            foreach (var item in layGH)
            {
                gh.giohang_id = id;
                gh.khachhang_id = item.khachhang_id;
                gh.sanpham_id = item.sanpham_id;
                gh.giohang_soluong = sl;
                gh.giohang_dongia = item.giohang_dongia;
                break;
            }
            spModel.SuaGioHang(gh);
            return Redirect(Request.UrlReferrer.ToString());//load lại trang
        }
        public ActionResult XoaGioHang(int id)
        {
            spModel.XoaGioHang(id);
            TempData["XoaThanhCong"] = "Xóa thành công.";
            return Redirect(Request.UrlReferrer.ToString());//load lại trang
        }
        public ActionResult ThanhToan()
        {
            //int idKH = 3;
            int idKH = Int32.Parse(Session["MaKH"].ToString());
            ViewBag.SanPham = spModel.XemGioHang(idKH);
            return View(khModel.KhachHangId(idKH));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanThanhToan(phieugiaohang pgh)//String phieugiaohang_tennguoinhan, int phieugiaohang_sdtnguoinhan, String phieugiaohang_diachinguoinhan
        {
            int idKH = Int32.Parse(Session["MaKH"].ToString());
            hoadon hd = new hoadon();
            hd.khachhang_id = idKH;
            hd.hoadon_ngaylap = DateTime.Now;
            hd.trangthaihoadon_id = 1;
            int idHD = spModel.ThemHoaDon(hd);//lấy id hóa đơn vừa thêm

            chitiethoadon ct = new chitiethoadon();
            var gh = spModel.XemGioHang(idKH);

            double tongtienHD = 0;//tính tổng tiền của hóa đơn để tiến hành update bảng hóa đơn
            foreach (var item in gh)
            {
                ct.hoadon_id = idHD;
                ct.sanpham_id = item.sanpham_id;
                ct.chitiethd_soluong = item.giohang_soluong;
                ct.chitiethd_thanhtien = item.giohang_soluong * item.giohang_dongia;
                spModel.ThemCTHoaDon(ct);
                tongtienHD = tongtienHD + ct.chitiethd_thanhtien;
            }

            hd.hoadon_tongtien = tongtienHD;
            spModel.SuaHoaDon(hd);

            foreach (var item in gh)
            {
                spModel.XoaGioHang(item.giohang_id);
                spModel.CapNhatSoLuongSP(item.sanpham_id, item.giohang_soluong);
            }

            phieugiaohang pgh1 = new phieugiaohang();
            pgh1.hoadon_id = idHD;
            pgh1.phieugiaohang_tennguoinhan = pgh.phieugiaohang_tennguoinhan;
            pgh1.phieugiaohang_sdtnguoinhan = pgh.phieugiaohang_sdtnguoinhan;
            pgh1.phieugiaohang_diachinguoinhan = pgh.phieugiaohang_diachinguoinhan;
            pgh1.phieugiaohang_thoigiangiaohang = DateTime.Now;
            spModel.ThemPhieuGiaoHang(pgh1);
            
            return RedirectToAction("Index");
        }
        public ActionResult LoaiSanPham(int idTheLoai, int? page = 0)
        {
            ViewBag.IdTheLoai = idTheLoai;
            int limit = 8;
            int start;
            if(page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;
            ViewBag.pageCurrent = page;

            int totalProduct = spModel.TongLoaiSanPham(idTheLoai);
            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = spModel.numberPage(totalProduct, limit);
            var data =  spModel.LoaiSanPham(idTheLoai, start, limit);
            ViewBag.Model = data;
            
            return View(data);
        }
        public ActionResult DonHangDaDat()
        {
            //int idKH = 3;
            int idKH = Int32.Parse(Session["MaKH"].ToString());
            ViewBag.HD = spModel.LayHoaDon(idKH);
            ViewBag.ChiTietHD = spModel.DonHangDaDat(idKH);
            
            return View();
        }
    }
}