using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlythuvien
{
    public class TienPhatCalculator
    {
        private const int HAN_MUON_TOI_DA = 7;
        private const double PHI_PHAT_MOI_NGAY = 5000;

        public double TinhTienPhat(DateTime ngayMuon, DateTime ngayTra)
        {
            int soNgayMuon = (ngayTra - ngayMuon).Days;

            if (soNgayMuon <= HAN_MUON_TOI_DA)
                return 0;

            int soNgayTre = soNgayMuon - HAN_MUON_TOI_DA;
            return soNgayTre * PHI_PHAT_MOI_NGAY;
        }
    }
}
