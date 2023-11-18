using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class TinhTrang
    {
        public int ID { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Tình trạng sản xuất không được bỏ trống.")]
        public string MoTa { get; set; }
        
        public ICollection<DatHang>? DatHang { get; set; }
    }
}
