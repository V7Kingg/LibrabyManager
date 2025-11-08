using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlythuvien
{
    public static class thongtindangnhap
    {
        public static string MaDocGia { get; set; }
        public static string MaThuThu { get; set; }
        public static string VaiTro { get; set; }

        public static void DangXuat()
        {
            MaDocGia = null;
            MaThuThu = null;
            VaiTro = null;
        }
        public static bool DaDangNhap()
        {
            return !string.IsNullOrEmpty(MaDocGia) || !string.IsNullOrEmpty(MaThuThu);
        }
    }
}
