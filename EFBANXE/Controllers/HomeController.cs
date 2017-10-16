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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}