using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuvien
{
    public partial class docgia : Form
    {
        public docgia()
        {
            InitializeComponent();
            timkiem.KeyDown += timkiem_KeyDown;
        }
        private void docgia_Load(object sender, EventArgs e)
        {
            taidocgia();
        }
        private void taidocgia(string madg = "")
        {
            string sql;
            if (string.IsNullOrEmpty(madg))
                sql = "SELECT MaDocGia, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email FROM DocGia";
            else
                sql = "SELECT MaDocGia, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email FROM DocGia WHERE MaDocGia = '" + madg.Replace("'", "''") + "'";

            GridView.DataSource = qltt.ExecuteQuery(sql);
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (GridView.SelectedRows.Count > 0)
            {
                this.txtmadg.Text = this.GridView.SelectedRows[0].Cells["MaDocGia"].Value.ToString();
                this.txttendg.Text = this.GridView.SelectedRows[0].Cells["HoTen"].Value.ToString();
                this.txtngaysinh.Text = this.GridView.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
                this.txtgioitinh.Text = this.GridView.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
                this.txtdiachi.Text = this.GridView.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                this.txtsdt.Text = this.GridView.SelectedRows[0].Cells["SoDienThoai"].Value.ToString();
                this.txtemail.Text = this.GridView.SelectedRows[0].Cells["Email"].Value.ToString();
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "INSERT INTO DocGia(MaDocGia, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email) VALUES('";
                sql += txtmadg.Text + "', N'" + txttendg.Text + "', '" + txtngaysinh.Text + "', N'" + txtgioitinh.Text + "', N'" + txtdiachi.Text + "', '" + txtsdt.Text + "', '" + txtemail.Text + "')";
                qltt.ExecuteNonQuery(sql);
                MessageBox.Show("Thêm Thành Công");
                taidocgia();
            }
            catch
            {
                MessageBox.Show("Thêm Thất Bại", "Lỗi");
            }
        }

        private void capnhat_Click(object sender, EventArgs e)
        {
            if (txtmadg.Text != "")
            {
                String sql = "UPDATE DocGia SET ";
                sql += "HoTen = N'" + txttendg.Text + "', ";
                sql += "NgaySinh = '" + txtngaysinh.Text + "', ";
                sql += "GioiTinh = N'" + txtgioitinh.Text + "', ";
                sql += "DiaChi = N'" + txtdiachi.Text + "', ";
                sql += "SoDienThoai = '" + txtsdt.Text + "', ";
                sql += "Email = '" + txtemail.Text + "' ";
                sql += "WHERE MaDocGia = '" + txtmadg.Text + "'";
                qltt.ExecuteNonQuery(sql);
                MessageBox.Show("Cập Nhật Thành Công");
                taidocgia();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn...");
            }
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn xóa không? (Sẽ xóa luôn lịch sử mượn sách!)",
                "Chú ý",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr == DialogResult.Yes)
            {
                if (txtmadg.Text != "")
                {
                    try
                    {
                        String deleteMuonTra = "DELETE FROM MuonTra WHERE MaDocGia = '" + txtmadg.Text + "'";
                        qltt.ExecuteNonQuery(deleteMuonTra);

                        String sql = "DELETE FROM DocGia WHERE MaDocGia = '" + txtmadg.Text + "'";
                        qltt.ExecuteNonQuery(sql);

                        MessageBox.Show("Xóa Thành Công");
                        taidocgia();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa Thất Bại: " + ex.Message, "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn...", "Thông báo");
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new trangchu().ShowDialog();
            this.Show();
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new quanlysach().ShowDialog();
            this.Show();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new docgia().ShowDialog();
            this.Show();
        }

        private void mượnTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new muontra().ShowDialog();
            this.Show();
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new baocao().ShowDialog();
            this.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new thongtinthuthu().ShowDialog();
            this.Show();
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dangnhap().ShowDialog();
            this.Close();
        }

        private void timkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                taidocgia(timkiem.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
