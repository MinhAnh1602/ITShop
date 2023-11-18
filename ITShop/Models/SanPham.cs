using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class SanPham
    {
        public int ID { get; set; }
        public int HangSanXuatID { get; set; }
        public int LoaiSanPhamID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống.")]
        public string TenSanPham { get; set; }

        [Required(ErrorMessage = "Đơn giá không được bỏ trống.")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int DonGia { get; set; }

        [Required(ErrorMessage = "Số lượng không được bỏ trống.")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int SoLuong { get; set; }

        [StringLength(255)]
        public string? HinhAnh { get; set; }

        [Column(TypeName = "ntext")]
        [DataType(DataType.MultilineText)]
        public string? MoTa { get; set; }

        [NotMapped]
        [Display(Name = "Hình ảnh sản phẩm")]
        public IFormFile? DuLieuHinhAnh { get; set; }
        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
        public LoaiSanPham? LoaiSanPham { get; set; }
        public HangSanXuat? HangSanXuat { get; set; }

    }
}
