using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class DatHang
    {
        public int ID { get; set; }
        public int NguoiDungID { get; set; }
        public int TinhTrangID { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Điện thoại giao hàng không được bỏ trống.")]
        public string DienThoaiGiaoHang { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Địa chỉ giao hàng không được bỏ trống.")]
        public string DiaChiGiaoHang { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Ngày đặt hàng không được bỏ trống.")]
        public DateTime NgayDatHang { get; set; }
        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
        public NguoiDung? NguoiDung { get; set; }
        public TinhTrang? TinhTrang { get; set; }
    }
}
