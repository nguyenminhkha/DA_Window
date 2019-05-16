using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLi
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            
        }
        public bool Login = false;
        public bool nv = false;
        public bool thukho = false;
        private void DangNhap()
        {
            if (txbUSERNAME.Text.Length == 0 && txbPASSWORK.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu !", "Thông báo !");
            }
            else
                if (this.txbUSERNAME.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản !", "Thông báo !");
                }
                else
                    if (this.txbPASSWORK.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu !", "Thông báo !");
                    }
                    else
                        if (this.txbUSERNAME.Text == "admin" && this.txbPASSWORK.Text == "1")
                        {
                            MessageBox.Show("Đăng nhập thành công !","Thông báo !");
                            Login = true;
                            
                        }
                       else
                       if (this.txbUSERNAME.Text == "nhanvien" && this.txbPASSWORK.Text == "1")
                        {
                          MessageBox.Show("Đăng nhập thành công !", "Thông báo !");
                             nv = true;
                         }
                       else
                        if (this.txbUSERNAME.Text == "thukho" && this.txbPASSWORK.Text == "1")
                          {
                            MessageBox.Show("Đăng nhập thành công !", "Thông báo !");
                            thukho = true;
                         }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !", "Thông báo !");
                        }
                         
                         
                         
                         
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            DangNhap();
            if (Login == true || nv == true || thukho == true)
            {
                
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.User = txbUSERNAME.Text;
                    Properties.Settings.Default.Pass=txbPASSWORK.Text;
                    Properties.Settings.Default.Save();
                    
                }
                else
                {
                    Properties.Settings.Default.User = "";
                    Properties.Settings.Default.Pass = "";
                    Properties.Settings.Default.Save();
                }
                this.Close();
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txbUSERNAME_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbPASSWORK_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void txbUSERNAME_Click(object sender, EventArgs e)
        {
            
            txbUSERNAME.ForeColor = Color.DarkBlue;
            panel1.BackColor = Color.DarkBlue;

            txbPASSWORK.ForeColor = Color.Black;
            panel3.BackColor = Color.Black;
        }

        private void txbPASSWORK_Click(object sender, EventArgs e)
        {
            
            txbPASSWORK.ForeColor = Color.DarkBlue;
            panel3.BackColor = Color.DarkBlue;

            txbUSERNAME.ForeColor = Color.Black;
            panel1.BackColor = Color.Black;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            txbUSERNAME.Text = Properties.Settings.Default.User;
            txbPASSWORK.Text = Properties.Settings.Default.Pass;
            checkBox1.Checked = true;
        }
    }
}
