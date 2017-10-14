﻿using EFBANXE.Models;
using EFBANXE.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EFBANXE.Controllers
{
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
                .Where(w=>w.TrangThai == true)
                .Include(c => c.LoaiXe);
            return View(xe);
        }

        // GET: Xes/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var xe = _dbContext.Xes
                .Include(c=>c.LoaiXe)
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
        public ActionResult Create(XeViewModel viewModel)
        {
            try
            {
                var xe = new Xe
                {
                    Ten = viewModel.Ten,
                    MoTa = viewModel.MoTa,
                    Gia = viewModel.Gia,
                    Hinh = viewModel.Hinh,
                    DanhGia = viewModel.DanhGia,
                    ThoiGian = viewModel.ThoiGian,
                    LoaiXeId = viewModel.LoaiXe,
                    TrangThai = true
                };
                _dbContext.Xes.Add(xe);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            return View("Create",viewModel);
        }

        // POST: Xes/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(XeViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    viewModel.LoaiXes = _dbContext.LoaiXes.ToList();
                    return View("Create", viewModel);
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
            if(id == 0)
            {
                return HttpNotFound();
            }
            var xe = _dbContext.Xes
                .Include(c=>c.LoaiXe)
                .Single(s => s.XeId == id);
            return View(xe);
        }

        // POST: Xes/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id,Xe xe)
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