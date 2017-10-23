using EFBANXE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFBANXE.ViewModels
{
    public class XeDangKyLaiThu
    {
        public Xe Xes { get; set; }
        public DangKyLaiThu DangKyLaiThus { get; set; }

        public string GetTimeCurrent()
        {
            String timeCurrent = DateTime.Now.Year.ToString()+ "-"+ DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString()+"-"+DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString()+":" + DateTime.Now.Millisecond.ToString();
            return timeCurrent;
        }
    }
}