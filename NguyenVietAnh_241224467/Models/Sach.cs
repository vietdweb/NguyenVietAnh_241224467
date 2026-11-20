using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NguyenVietAnh_241224467.Models;

public partial class Sach
{
    [Key]
    public int MaSach { get; set; }

    public int MaTl { get; set; }

    [Required(ErrorMessage ="Ten sach ko dc de trong")]
    public string TenSach { get; set; } = null!;
    [Required(ErrorMessage = "Gia ko dc de trong")]
    [Range(50,1000,ErrorMessage ="Gia phai nam trong khoang 50 toi 1000")]
    public decimal? Gia { get; set; }
    [Required(ErrorMessage = "Anh ko dc de trong")]
    [RegularExpression(@"^.*\.(jpg|jpeg|png|webp)$",ErrorMessage ="Anh phai co dinh dang jpg jpeg png webp")]
    public string? Anh { get; set; }

    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
