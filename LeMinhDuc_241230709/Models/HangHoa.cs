using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeMinhDuc_241230709.Models;

public partial class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    [Required(ErrorMessage ="Tên hàng không được để trống")]
    public string TenHang { get; set; } = null!;

    [Required(ErrorMessage = "Giá phải là số từ 100 đến 5000")]
    [Range(100, 5000, ErrorMessage = "Giá phải là số từ 100 đến 5000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"(?i)^.+\.(jpg|gif|png|tiff)",
        ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff")]
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
