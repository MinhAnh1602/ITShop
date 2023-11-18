using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class HangSanXuat
    {
        public int ID { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Tên hãng sản xuất không được bỏ trống.")]
        public string TenHangSanXuat { get; set; }
        public ICollection<SanPham>? SanPham { get; set; }
    }
}
