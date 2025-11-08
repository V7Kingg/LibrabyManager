using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuvien
{
    public partial class dangki : Form
    {
        public dangki()
        {
            InitializeComponent();
            dtpngaysinhdangki.Value = DateTime.Now.AddYears(-18);
            dtpngaysinhdangki.MaxDate = DateTime.Now;
            txtmatkhaudangki.UseSystemPasswordChar = true;
        }
        private void dangki_Load(object sender, EventArgs e)
        {
        }
        private string SinhMaDocGiaMoi()
        {
            string sql = "SELECT TOP 1 MaDocGia FROM DocGia ORDER BY MaDocGia DESC";
            DataTable dt = qltt.ExecuteQuery(sql);
            string maMoi = "GN0001";
            if (dt.Rows.Count > 0)
            {
                string maCu = dt.Rows[0]["MaDocGia"].ToString(); 
                int so = int.Parse(maCu.Substring(2));
                so++;
                maMoi = "GN" + so.ToString("D4");
            }
            return maMoi;
        }
        private void btndangki_Click(object sender, EventArgs e)
        {
            try
            {
                string matKhau = txtmatkhaudangki.Text;
                if (!kiemtramatkhau(matKhau))
                {
                    MessageBox.Show("Mật khẩu yếu...", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string gioiTinh = rbnamdangki.Checked ? "Nam" : (rbnudangki.Checked ? "Nữ" : "");
                string maDocGiaMoi = SinhMaDocGiaMoi();

                string sql = "INSERT INTO DocGia(MaDocGia, HoTen, TenDangNhap, MatKhau, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email) VALUES('";
                sql += maDocGiaMoi + "', '";
                sql += txthovatendangki.Text.Replace("'", "''") + "', '";
                sql += txttendangnhapdangki.Text.Replace("'", "''") + "', '";
                sql += matKhau.Replace("'", "''") + "', '";
                sql += dtpngaysinhdangki.Value.ToString("yyyy-MM-dd") + "', '";
                sql += gioiTinh.Replace("'", "''") + "', '";
                sql += txtdiachidangki.Text.Replace("'", "''") + "', '";
                sql += txtsodienthoaidangki.Text.Replace("'", "''") + "', '";
                sql += txtemaildangki.Text.Replace("'", "''") + "')";

                qltt.ExecuteNonQuery(sql);
                MessageBox.Show("Đăng ký thành công!");

                this.Hide();
                new dangnhap().ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool kiemtramatkhau(string password)
        {            
            if (password.Length < 8)
                return false;
            bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"[0-9]");
            bool hasSpecial = Regex.IsMatch(password, @"[!@#$%^&*(),.?""':;{}/|[\]\\]");
            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dangnhap().ShowDialog();
            this.Close();
        }
    }
}

