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
    public partial class NhaXuatBan : Form
    {
        public NhaXuatBan()
        {
            InitializeComponent();
        }
        private void NhaXuatBan_Load(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM NhaXuatBan";
            DataTable dt = qltt.ExecuteQuery(sql);
            this.dgvsach.DataSource = dt;
            dgvsach.DataSource = dt;
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
