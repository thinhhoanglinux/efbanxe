using EFBANXE.Models;
using EFBANXE.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFBANXE.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class XesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public XesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Xes
        [Authorize]
        public ActionResult Index()
        {
            var xe = _dbContext.Xes
                .Where(w => w.TrangThai == true)
                .Include(c => c.LoaiXe);
            return View(xe);
        }

        // GET: Xes/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var xe = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Single(s => s.XeId == id);
            return View(xe);
        }

        // GET: Xes/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new XeViewModel
            {
                LoaiXes = _dbContext.LoaiXes.ToList(),
                Heading = "Tạo mới"
            };
            return View(viewModel);
        }

        // POST: Xes/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(XeViewModel viewModel,HttpPostedFileBase chonHinh)
        {
            if(chonHinh != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(chonHinh.FileName);
                string extensions = Path.GetExtension(chonHinh.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                viewModel.Hinh = "~/Content/images/" + fileName;
                chonHinh.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            var xe = new Xe
            {
                Ten = viewModel.Ten,
                MoTa = viewModel.MoTa,
                Gia = viewModel.Gia,
                Hinh = viewModel.Hinh,
                DanhGia = viewModel.DanhGia,
                ThoiGian = viewModel.ThoiGian,
                LoaiXeId = viewModel.LoaiXe,
                TrangThai = true,
                NoiBat = viewModel.NoiBat
            };
            _dbContext.Xes.Add(xe);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Xes/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var xe = _dbContext.Xes
                .Single(s => s.XeId == id);
            var viewModel = new XeViewModel
            {
                LoaiXes = _dbContext.LoaiXes.ToList(),
                XeId = xe.XeId,
                Ten = xe.Ten,
                MoTa = xe.MoTa,
                Gia = xe.Gia,
                Hinh = xe.Hinh,
                DanhGia = xe.DanhGia,
                ThoiGian = xe.ThoiGian,
                Heading = "Sửa",
                LoaiXe = xe.LoaiXeId
            };
            return View("Create", viewModel);
        }

        // POST: Xes/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(XeViewModel viewModel,HttpPostedFileBase chonHinh)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    viewModel.LoaiXes = _dbContext.LoaiXes.ToList();
                    return View("Create", viewModel);
                }

                if (chonHinh != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(chonHinh.FileName);
                    string extensions = Path.GetExtension(chonHinh.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                    viewModel.Hinh = "~/Content/images/" + fileName;
                    chonHinh.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                var xe = _dbContext.Xes.Single(s => s.XeId == viewModel.XeId);

                xe.Ten = viewModel.Ten;
                xe.MoTa = viewModel.MoTa;
                xe.Gia = viewModel.Gia;
                xe.Hinh = viewModel.Hinh;
                xe.DanhGia = viewModel.DanhGia;
                xe.LoaiXeId = viewModel.LoaiXe;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Xes/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var xe = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Single(s => s.XeId == id);
            return View(xe);
        }

        // POST: Xes/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, Xe xe)
        {
            try
            {
                // TODO: Add delete logic here
                xe = _dbContext.Xes
                    .Include(c => c.LoaiXe)
                    .Single(s => s.XeId == id);
                xe.TrangThai = false;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Xes/Deleted
        [Authorize]
        public ActionResult Deleted()
        {
            var xe = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Where(w => w.TrangThai == false);
            return View(xe);
        }
        // GET: Xes/Delete2
        [Authorize]
        public ActionResult Delete2(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var xe = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Single(s => s.XeId == id);
            return View(xe);
        }

        // POST: Xes/Delete2
        [Authorize]
        [HttpPost]
        public ActionResult Delete2(int id, Xe xe)
        {
            try
            {
                // TODO: Add delete logic here
                xe = _dbContext.Xes
                    .Include(c => c.LoaiXe)
                    .Single(s => s.XeId == id);
                xe.TrangThai = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
