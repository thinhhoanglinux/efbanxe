using EFBANXE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFBANXE.Controllers
{
    public class XeNoiBatsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public XeNoiBatsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: XeNoiBats
        public ActionResult Index()
        {
            var xeNoiBat = _dbContext.Xes
                .Include(c => c.LoaiXe)
                .Where(w => w.NoiBat == true);
            return View(xeNoiBat);
        }
    }
}