using EFBANXE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFBANXE.ViewModels
{
    public class XeViewModel
    {
        public int XeId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tên xe không được quá 255 ký tự.")]
        [Display(Name = "Tên Xe")]
        public string Ten { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }

        [Required]
        [Display(Name = "Giá")]
        public decimal Gia { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        [Required]
        [Display(Name = "Đánh Giá")]
        public string DanhGia { get; set; }

        [Required]
        [Display(Name = "Ngày Đăng")]
        public DateTime ThoiGian { get; set; }

        public IEnumerable<LoaiXe> LoaiXes { get; set; }
        [Required]
        [Display(Name = "Loại Xe")]
        public int LoaiXe { get; set; }
        public string Heading { get; set; }
        public string Action
        {
            get { return (XeId != 0) ? "Update" : "Create"; }
        }
    }
}