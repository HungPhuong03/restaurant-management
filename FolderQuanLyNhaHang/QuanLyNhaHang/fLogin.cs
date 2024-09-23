using QuanLyNhaHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//btn login
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if(Login(username, password))
            {
                fTableManager f = new fTableManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên hoặc mật khẩu!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        bool Login(string username, string password)
        {
            //return
            
            return AccountDAO.Intance.Login(username, password); ;
        }

        private void button2_Click(object sender, EventArgs e)//btn exit
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát không?","Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel )
            {
                e.Cancel = true;
            }  
        }
    }
}
