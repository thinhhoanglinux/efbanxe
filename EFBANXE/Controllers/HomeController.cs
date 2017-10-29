using EFBANXE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFBANXE.ViewModels;
using System.Dynamic;

namespace EFBANXE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var xe = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Where(c => c.TrangThai == true);
            var tintuc = _dbContext.TinTucs
                .Include(c => c.NhanVien)
                .Include(c => c.LoaiTinTuc)
                .Where(c => c.TrangThai == true);
            XeTinTucViewModel viewModel = new XeTinTucViewModel();
            viewModel.Xes = xe;
            viewModel.TinTucs = tintuc;
            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            var xe = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Single(c => c.XeId == id);
            XeDangKyLaiThu xeDangKyLaiThu = new XeDangKyLaiThu();
            xeDangKyLaiThu.Xes = xe;
            return View(xeDangKyLaiThu);
        }

        [HttpPost]
        public ActionResult Details(XeDangKyLaiThu viewModel)
        {
            var dangKyLaiThu = new DangKyLaiThu
            {
                HoTen = viewModel.DangKyLaiThus.HoTen,
                Email = viewModel.DangKyLaiThus.Email,
                Sdt = viewModel.DangKyLaiThus.Sdt,
                TrangThai = false,
                NgayDangKy = viewModel.GetTimeCurrent(),
                DiaChi = viewModel.DangKyLaiThus.DiaChi,
                LoiNhan = viewModel.DangKyLaiThus.LoiNhan,
                XeId = viewModel.Xes.XeId,
            };
            _dbContext.DangKyLaiThus.Add(dangKyLaiThu);
            _dbContext.SaveChanges();

            var xe = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Single(c => c.XeId == viewModel.Xes.XeId);
            XeDangKyLaiThu xeDangKyLaiThu = new XeDangKyLaiThu();
            xeDangKyLaiThu.Xes = xe;
            ViewBag.onSuccess = "Bạn đã đăng ký lái thử xe này rồi, vui lòng quay lại sau!";
            return View(xeDangKyLaiThu);
        }

        public ActionResult Information(int id)
        {
            var xe = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Single(c => c.XeId == id);
            return View(xe);
        }

        public ActionResult Search(string Search, string submit)
        {
            submit = "Search";
            var xe = _dbContext.Xes
            .Include(c => c.LoaiXe)
            .Where(w => w.LoaiXe.Ten.Equals(Search));
            
            return View(xe);
        }
    }
}