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
    public partial class baocao : Form
    {
        public baocao()
        {
            InitializeComponent();
            checkdangmuon.Checked = true;
        }

        private void baocao_Load(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string sql = "";
            DataTable dt;


            if (checkdangmuon.Checked)
            {

                sql = "SELECT * FROM MuonTra WHERE TrangThai = N'Đang Mượn'";
            }
            else
            {
                sql = "SELECT * FROM MuonTra WHERE TrangThai = N'Đã Trả'";
            }

            dt = qltt.ExecuteQuery(sql);
            GridBaoCao.DataSource = dt;
            lbTong.Text = $"Tổng số sách: {dt.Rows.Count}";

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
    }
}
