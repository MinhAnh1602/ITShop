﻿using ITShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlugGenerator;
using static ITShop.Models.SanPham;

namespace ITShop.Controllers
{
    public class SanPhamController : Controller

    {
        private readonly ITShopDbContext _context;

        public SanPhamController(ITShopDbContext context)

        {
            _context = context;

        }
        // GET: ChiTiet
        [Route("SanPham/{tenLoai}/{tenSanPham}")]
        public IActionResult ChiTiet(string tenLoai,string tenSanPham)
        {
            var sanPham = _context.SanPham
            .Include(s => s.HangSanXuat)
            .Include(s => s.LoaiSanPham)
            .AsEnumerable().Where(r => r.TenSanPham.GenerateSlug() == tenSanPham).SingleOrDefault();
            if (sanPham == null)
                return NotFound();
            else
                return View(sanPham);
        }
        // GET: PhanLoai
        [Route("SanPham/PhanLoai/{tenLoai}/{trang?}")]
        public IActionResult PhanLoai(int? trang, string tenLoai)
        {
            var danhSachPhanLoai = LayDanhSachSanPhamTheoPhanLoai(trang ?? 1, tenLoai);
            if (danhSachPhanLoai.SanPham.Count == 0)
                return NotFound();
            else
                return View(danhSachPhanLoai);
        }

        private PhanTrangSanPham LayDanhSachSanPhamTheoPhanLoai(int trangHienTai, string tenLoai)
        {
            int maxRows = 20;

            var sanPhamPhanLoai = _context.SanPham
            .Include(s => s.HangSanXuat)
            .Include(s => s.LoaiSanPham)
            .AsEnumerable().Where(r => r.LoaiSanPham.TenLoai.GenerateSlug() == tenLoai);

            PhanTrangSanPham phanTrang = new PhanTrangSanPham();
            phanTrang.SanPham = sanPhamPhanLoai.OrderBy(r => r.LoaiSanPhamID)
            .Skip((trangHienTai - 1) * maxRows)
            .Take(maxRows).ToList();

            decimal tongSoTrang = Convert.ToDecimal(sanPhamPhanLoai.Count()) / Convert.ToDecimal(maxRows);
            phanTrang.TongSoTrang = (int)Math.Ceiling(tongSoTrang);
            phanTrang.TrangHienTai = trangHienTai;

            return phanTrang;
        }

        // GET: Index
        [Route("SanPham/{trang?}")]
        public IActionResult Index(int? trang)

        {
            var danhSach = LayDanhSachSanPham(trang ?? 1);
            if (danhSach.SanPham.Count == 0)
                return NotFound();
            else
                return View(danhSach);

        }

        private PhanTrangSanPham LayDanhSachSanPham(int trangHienTai)
        {
            int maxRows = 20;

            PhanTrangSanPham phanTrang = new PhanTrangSanPham();
            phanTrang.SanPham = _context.SanPham
            .Include(s => s.HangSanXuat)
            .Include(s => s.LoaiSanPham)
            .OrderBy(r => r.LoaiSanPhamID)
            .Skip((trangHienTai - 1) * maxRows)
            .Take(maxRows).ToList();

            decimal tongSoTrang = Convert.ToDecimal(_context.SanPham.Count()) / Convert.ToDecimal(maxRows);
            phanTrang.TongSoTrang = (int)Math.Ceiling(tongSoTrang);
            phanTrang.TrangHienTai = trangHienTai;

            return phanTrang;
        }
    }
}
