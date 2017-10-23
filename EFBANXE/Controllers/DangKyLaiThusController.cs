using EFBANXE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFBANXE.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class DangKyLaiThusController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public DangKyLaiThusController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: DangKyLaiThus
        public ActionResult Index()
        {
            var viewModel = _dbContext.DangKyLaiThus
                 .Include(c => c.Xe);
            return View(viewModel);
        }
        public ActionResult Duyet(int id)
        {
            DangKyLaiThu viewModel = _dbContext.DangKyLaiThus
                .Include(c => c.Xe)
                .Single(c => c.Id == id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Duyet(DangKyLaiThu viewModel)
        {
            viewModel = _dbContext.DangKyLaiThus
                .Include(c => c.Xe)
                .Single(c => c.Id == viewModel.Id);
            if (viewModel.TrangThai)
            {
                viewModel.TrangThai = false;
            }
            else
            {
                viewModel.TrangThai = true;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
