using BanHangDienTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangDienTu.Controllers
{
    public class KhachHangController : Controller
    {
        KhachHangModel khModel = new KhachHangModel();
        public ActionResult Login()
        {
            ViewBag.Message = TempData["message"];

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(khachhang model)
        {

            if (ModelState.IsValid)
            {
                var data = khModel.DangNhap(model);
                if (data.Count() > 0)
                {
                    //add session
                    Session["MaKH"] = data.FirstOrDefault().khachhang_id;
                    Session["TenKH"] = data.FirstOrDefault().khachhang_ten;
                    return Redirect("/SanPham/Index");

                }
                else
                {
                    TempData["message"] = "Tên đăng hoặc mật khẩu không chính xác.";
                    ViewBag.mes = "Tên đăng nhập hoặc mật khẩu không chính xác.";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult DangKy()
        {
            ViewBag.Message = TempData["message"];

            return View();
        }
        [HttpPost]
        public ActionResult DangKy(khachhang kh)
        {
            var data = khModel.DangKy(kh);
            Session["MaKH"] = data.FirstOrDefault().khachhang_id;
            Session["TenKH"] = data.FirstOrDefault().khachhang_ten;
            TempData["ThemThanhCong"] = "Thêm thành công.";
            return RedirectToAction("Index", "SanPham");

        }
        //Logout
        public ActionResult DangXuat()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "SanPham");
        }
    }
}