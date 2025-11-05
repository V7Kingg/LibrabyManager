using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace quanlythuvien
{
    public partial class thongtindocgia : Form
    {
        public thongtindocgia()
        {
            InitializeComponent();
        }
         private void Form2_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(thongtindangnhap.MaDocGia))
            {
                MessageBox.Show("Vui lòng đăng nhập lại.");
                this.Close();
                return;
            }
            TaiThongTinCaNhan();
            LoadLichSuMuonTra();
        }
        private void TaiThongTinCaNhan()
        {
            string sql = "SELECT MaDocGia, HoTen, DiaChi, SoDienThoai, Email, GioiTinh, NgaySinh FROM DocGia WHERE MaDocGia = N'" + thongtindangnhap.MaDocGia.Replace("'", "''") + "'";
            DataTable dt = qltt.ExecuteQuery(sql);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtmadocgia1.Text = row["MaDocGia"] + "";
                txttendocgia1.Text = row["HoTen"] + "";
                txtdiachi1.Text = row["DiaChi"] + "";
                txtsodienthoai1.Text = row["SoDienThoai"] + "";
                txtemail1.Text = row["Email"] + "";
                txtgioitinh1.Text = row["GioiTinh"] + "";

                if (row["NgaySinh"] != DBNull.Value && row["NgaySinh"].ToString() != "")
                {
                    DateTime ns = DateTime.Parse(row["NgaySinh"].ToString());
                    txtngaysinh1.Text = ns.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtngaysinh1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin độc giả.");
            }

        }
        private void LoadLichSuMuonTra()
        {
            if (thongtindangnhap.MaDocGia == null || thongtindangnhap.MaDocGia == "")
            {
                MessageBox.Show("Mã độc giả không hợp lệ. Vui lòng đăng nhập lại!");
                Close();
                return;
            }

            string sql = "SELECT mt.MaDocGia, dg.HoTen, s.TieuDe, mt.NgayMuon, mt.NgayTra, mt.TrangThai, mt.GhiChu " +
                         "FROM MuonTra mt JOIN DocGia dg ON mt.MaDocGia = dg.MaDocGia " +
                         "JOIN Sach s ON mt.MaSach = s.MaSach " +
                         "WHERE mt.MaDocGia = N'" + thongtindangnhap.MaDocGia + "'";

            dgv.DataSource = qltt.ExecuteQuery(sql);
        }

        private void TimSachTheoTen(string tenSach)
        {
            string sql = "SELECT s.MaSach, s.TieuDe, t.TenTacGia, tl.TenTheLoai, nxb.TenNhaXuatBan, s.NamXuatBan, s.ISBN, s.SoLuong, s.SoLuongConLai " +
                     "FROM Sach s " +
                     "JOIN TacGia t ON s.MaTacGia = t.MaTacGia " +
                     "JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai " +
                     "JOIN NhaXuatBan nxb ON s.MaNhaXuatBan = nxb.MaNhaXuatBan " +
                     "WHERE s.TieuDe LIKE N'%" + tenSach.Replace("'", "''") + "%'";
            DataTable dt = qltt.ExecuteQuery(sql);
            dgv.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sách phù hợp.");
            }
        }
        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (txtmadocgia1.Text != "")
            {
                try
                {
                    string sql = "UPDATE DocGia SET "
                        + "HoTen = N'" + txttendocgia1.Text + "', "
                        + "DiaChi = N'" + txtdiachi1.Text + "', "
                        + "SoDienThoai = '" + txtsodienthoai1.Text + "', "
                        + "Email = '" + txtemail1.Text + "', "
                        + "GioiTinh = N'" + txtgioitinh1.Text + "' "
                        + "WHERE MaDocGia = '" + txtmadocgia1.Text + "'";

                    qltt.ExecuteNonQuery(sql);
                    MessageBox.Show("Cập Nhật Thành Công");
                    TaiThongTinCaNhan();
                }
                catch
                {
                    MessageBox.Show("Lỗi khi cập nhật. Kiểm tra lại dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng cần sửa.");
            }
        }
        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }
        private void txttimsach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tensach = txttimsach.Text.Trim();
                if (tensach == "")
                    LoadLichSuMuonTra();
                else
                    TimSachTheoTen(tensach);
                e.SuppressKeyPress = true; 
            }
        }
        private void dangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dangnhap().ShowDialog();
            this.Close();
        }
    }
}
