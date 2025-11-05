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
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
            this.btndagnhap.Click += btndagnhap_Click;
        }
        private void btndagnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttendangnhap.Text.Trim()) || string.IsNullOrEmpty(txtmatkhaudangnhap.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }
            string sqlThuThu = "SELECT MaThuThu FROM ThuThu WHERE TenDangNhap = N'" + txttendangnhap.Text + "' AND MatKhau = N'" + txtmatkhaudangnhap.Text.Trim() + "'";
            DataTable dt = qltt.ExecuteQuery(sqlThuThu);

            if (dt != null && dt.Rows.Count > 0)
            {
                thongtindangnhap.MaThuThu = dt.Rows[0]["MaThuThu"].ToString();
                thongtindangnhap.VaiTro = "ThuThu";
                MessageBox.Show("Xin chào Thủ thư!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new trangchu().ShowDialog();
                this.Close();
                return;
            }
            string sqlDocGia = "SELECT MaDocGia FROM DocGia WHERE TenDangNhap = N'" + txttendangnhap.Text + "' AND MatKhau = N'" + txtmatkhaudangnhap.Text.Trim() + "'";
            dt = qltt.ExecuteQuery(sqlDocGia);

            if (dt != null && dt.Rows.Count > 0)
            {
                thongtindangnhap.MaDocGia = dt.Rows[0]["MaDocGia"].ToString();
                thongtindangnhap.VaiTro = "DocGia";
                MessageBox.Show("Xin chào Độc giả!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new thongtindocgia().ShowDialog();
                this.Close();
                return;
            }
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            txtmatkhaudangnhap.Clear();
        }              
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new quenmatkhau().ShowDialog();
            this.Show();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dangki().ShowDialog();
            this.Show();
        }
        private void dangnhap_Load(object sender, EventArgs e)
        {
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}

