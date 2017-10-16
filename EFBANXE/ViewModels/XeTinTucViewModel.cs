using EFBANXE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFBANXE.ViewModels
{
    public class XeTinTucViewModel
    {
        public IEnumerable<Xe> Xes{ get; set; }
        public IEnumerable<TinTuc> TinTucs { get; set; }
    }
}