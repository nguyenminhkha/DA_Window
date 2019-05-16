using QLi.DAO;
using QLi.DTO;
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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            LoadKhaiBaoSach();
            LoadThongTinNhanVien();
            LoadKhaiBaoThuKho();
            LoadThongTinHoaDon();
            LoadThongTinTaiKhoan();
            LoadLoaiSach();
            LoadLinhVuc();
            LoadTacGia();
            LoadKho();
            LoadThongTinXuatBan();
            BindingThongTinSach();
            BindingThongTinNhanVien();
            BindingThongTinThuKho();
            BindingThongTinThanhToan();
            BidingThongTinTaiKhoan();
            cbbGiamGia.SelectedIndex = 0;
            loadlistHD();
          
            
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labelNgay.Text = DateTime.Now.ToLongDateString();
            labelGio.Text = DateTime.Now.ToLongTimeString();
            pictureBoxNV.Hide();
            pictureThuKho.Hide();
            pictureTrangThai.Hide();


            //Xoá đi các tabpage
            tabCtrlThongTin.Controls.Remove(tabDoiMK_TrangChinh);
            tabCtrlThongTin.Controls.Remove(tabDanhSachNV_TrangChinh);
            tabCtrlThongTin.Controls.Remove(tabThongTinCaNhan_TrangChinh);
            tabCtrlThongTin.Controls.Remove(tabTaoTaiKhoan_TrangChinh);
            tabCtrlTrangChu.Controls.Remove(tabTaiNguyenSach);
            tabCtrlTrangChu.Controls.Remove(tabDoanhThu);
            tabCtrlTrangChu.Controls.Remove(tabThuKho);
            tabCtrlTrangChu.Controls.Remove(tabNhanVien);

            panelTrangThai.Hide();
            
            listViewHoaDon.FullRowSelect = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelGio.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        //Load thông tin sách lên tabpage Tài nguyên sách
        void LoadKhaiBaoSach()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM dbo.sach";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvThongTinSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvThongTinSach.DataSource = DataProvider.Instance.ExecuteQuery(query);

        }

        //Load thông tin nhân viên lên tabpage Danh sách nhân viên
        void LoadThongTinNhanVien()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM dbo.thongtinnv";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvThongTinNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvThongTinNV.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        //Load thông tin sách lên tabpage của Thủ Kho
        void LoadKhaiBaoThuKho()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM dbo.sach";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvThuKho_ThuKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvThuKho_ThuKho.DataSource = DataProvider.Instance.ExecuteQuery(query);

        }

        //Load thông tin sách lên tabpage của Nhân Viên
        void LoadThongTinHoaDon()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM dbo.sach";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvHoaDon.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        //Load thông tin tài khoản lên tabpage Tạo tài khoản
        void LoadThongTinTaiKhoan()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM dbo.taikhoan";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvTaoTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvTaoTaiKhoan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        //Load thông tin các loại sách lên tabpage loại sách của tabpage Thủ Kho
        void LoadLoaiSach()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM loaisach";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvLoaiSach_ThuKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvLoaiSach_ThuKho.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        //Load thông tin các lĩnh vực lên tabpage lĩnh vực của tabpage Thủ Kho
        void LoadLinhVuc()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM linhvuc";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvLinhVuc_ThuKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvLinhVuc_ThuKho.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        //Load thông tin các tác giả lên tabpage tác giả  của tabpage Thủ Kho
        void LoadTacGia()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM tacgia";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvTacGia_ThuKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvTacGia_ThuKho.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        //Load thông tin xuất bản lên tabpage thông tin xuất bản  của tabpage Thủ Kho
        void LoadThongTinXuatBan()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM thongtinxuatban";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvThongTinXuatBan_ThuKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvThongTinXuatBan_ThuKho.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        //Load thông tin kho lên tabpage kho của tabpage Thủ Kho
        void LoadKho()
        {
            //Câu truy vấn sql
            string query = "SELECT * FROM kho";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvKho_ThuKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvKho_ThuKho.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        //Hiện thị thông tin sách lên các textbox
        void BindingThongTinSach()
        {
            //Từ cái texbox Mã Sách hãy cho tôi giá trị TEXT nó sẽ thay đổi theo giá trị MÃ SÁCH và nguồn nằm trong DataSource       
            tbMaSach.DataBindings.Add(new Binding("Text", dtgvThongTinSach.DataSource, "MaSach",true, DataSourceUpdateMode.Never));
            tbTenSach.DataBindings.Add(new Binding("Text", dtgvThongTinSach.DataSource, "TenSach", true, DataSourceUpdateMode.Never));
            tbMaTacGia.DataBindings.Add(new Binding("Text", dtgvThongTinSach.DataSource, "MaTacGia", true, DataSourceUpdateMode.Never));
            cbbMaLoaiSach.DataBindings.Add(new Binding("Text", dtgvThongTinSach.DataSource, "MaLoaiSach", true, DataSourceUpdateMode.Never));
            cbbMaLinhVuc.DataBindings.Add(new Binding("Text", dtgvThongTinSach.DataSource, "MaLinhVuc", true, DataSourceUpdateMode.Never));
            tbGiaMua.DataBindings.Add(new Binding("Text", dtgvThongTinSach.DataSource, "GiaMua", true, DataSourceUpdateMode.Never));
           // tbLoaiSach.DataBindings.Add(new Binding("Text", dtgvThongTinSach.DataSource, "LoaiSach", true, DataSourceUpdateMode.Never));
        }

        //Hiện thị thông tin nhân viên lên các textbox
        void BindingThongTinNhanVien()
        {
            //Từ cái texbox Họ tên hãy cho tôi giá trị TEXT nó sẽ thay đổi theo giá trị Họ tên và nguồn nằm trong DataSource
            tbMaNV.DataBindings.Add(new Binding("Text", dtgvThongTinNV.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            tbHotenNV.DataBindings.Add(new Binding("Text", dtgvThongTinNV.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            dtNamSinh.DataBindings.Add(new Binding("Text", dtgvThongTinNV.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            tbQueQuan.DataBindings.Add(new Binding("Text", dtgvThongTinNV.DataSource, "QueQuan", true, DataSourceUpdateMode.Never));
            tbLuong.DataBindings.Add(new Binding("Text", dtgvThongTinNV.DataSource, "LuongCoBan", true, DataSourceUpdateMode.Never));
        }

        //Hiện thị thông tin sách lên các textbox của tabpage Thủ kho
        void BindingThongTinThuKho()
        {
            //Từ cái texbox Mã Sách hãy cho tôi giá trị TEXT nó sẽ thay đổi theo giá trị MÃ SÁCH và nguồn nằm trong DataSource       
            tbMaSach_ThuKho.DataBindings.Add(new Binding("Text", dtgvThuKho_ThuKho.DataSource, "MaSach", true, DataSourceUpdateMode.Never));
            tbTenSach_ThuKho.DataBindings.Add(new Binding("Text", dtgvThuKho_ThuKho.DataSource, "TenSach", true, DataSourceUpdateMode.Never));
            tbMaTacGia_ThuKho.DataBindings.Add(new Binding("Text", dtgvThuKho_ThuKho.DataSource, "MaTacGia", true, DataSourceUpdateMode.Never));
            cbbMaLoaiSach_ThuKho.DataBindings.Add(new Binding("Text", dtgvThuKho_ThuKho.DataSource, "MaLoaiSach", true, DataSourceUpdateMode.Never));
            cbbMaLinhVuc_ThuKho.DataBindings.Add(new Binding("Text", dtgvThuKho_ThuKho.DataSource, "MaLinhVuc", true, DataSourceUpdateMode.Never));
            tbGiaMua_ThuKho.DataBindings.Add(new Binding("Text", dtgvThuKho_ThuKho.DataSource, "GiaMua", true, DataSourceUpdateMode.Never));
            //tbLoaiSach_ThuKho.DataBindings.Add(new Binding("Text", dtgvThuKho.DataSource, "LoaiSach", true, DataSourceUpdateMode.Never));
        }

        //Hiện thị thông tin sách lên các textbox của tabpage Nhân viên                                                                                                     
        void BindingThongTinThanhToan()
        {
            //Từ cái texbox Mã Sách hãy cho tôi giá trị TEXT nó sẽ thay đổi theo giá trị MÃ SÁCH và nguồn nằm trong DataSource       
            tbTenSach_NV.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "TenSach"));
            tbGia_NV.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "GiaMua"));
        }

        //Hiện thị thông tin Tài khoản lên các textbox
        void BidingThongTinTaiKhoan()
        {
            //Từ cái texbox USERNAME hãy cho tôi giá trị TEXT nó sẽ thay đổi theo giá trị USERNAME và nguồn nằm trong DataSource       
            tbUsername_TaoTaiKhoan.DataBindings.Add(new Binding("Text", dtgvTaoTaiKhoan.DataSource, "USERNAME", true, DataSourceUpdateMode.Never));
            tbPassword_TaoTaiKhoan.DataBindings.Add(new Binding("Text", dtgvTaoTaiKhoan.DataSource, "PASSWORD", true, DataSourceUpdateMode.Never));
            tbMaNV_TaoTaiKhoan.DataBindings.Add(new Binding("Text", dtgvTaoTaiKhoan.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            tbID_TaoTaiKhoan.DataBindings.Add(new Binding("Text", dtgvTaoTaiKhoan.DataSource, "ID", true, DataSourceUpdateMode.Never));
            dtPKNgayTao_TaoTaiKhoan.DataBindings.Add(new Binding("Text", dtgvTaoTaiKhoan.DataSource, "NgayTao", true, DataSourceUpdateMode.Never));
            cbbChucVu_TaoTaiKhoan.DataBindings.Add(new Binding("Text", dtgvTaoTaiKhoan.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));

        }
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình !", "Thông báo !", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showOrActiveTab(TabPage form)
        {
            // Tạo một biến index để nếu tab đã tồn tại rồi thì show ra
            int index = 0;

            // Tạo 1 biến kiểm tra sự tồn tại của tab đó
            bool isExist = false;

            // Chạy 1 vòng lặp hết tất cả control của tab lớn
            foreach (Control c in tabCtrlThongTin.Controls)
            {

                // Kiểm tra sự tồn tại của tab
                if (c.Name == form.Name)
                {

                    // Nếu tồn tại thì đánh dấu cờ isExist là true
                    isExist = true;

                    // Chuyển sang tab đã tồn tại và những vòng lặp
                    tabCtrlThongTin.SelectedIndex = index;
                    break;
                }

                // Tăng biến index theo vòng lặp
                index++;
            }

            // Nếu chưa tồn tại thì thêm tab đó vào control và show nó
            if (!isExist)
            {
                tabCtrlThongTin.Controls.Add(form);
                tabCtrlThongTin.SelectedIndex = tabCtrlThongTin.TabCount - 1;
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            // Đổi lại tên của tab để so sánh tìm xem tab đã tồn tại hay chưa
            tabDoiMK_TrangChinh.Name = "tabDoiMK_TrangChinh";

            // Gọi hàm kiểm tra xem tab đã tồn tại hay chưa
            this.showOrActiveTab(tabDoiMK_TrangChinh);

        }

        private void btnThongTinNV_Click(object sender, EventArgs e)
        {
            // Đổi lại tên của tab để so sánh tìm xem tab đã tồn tại hay chưa
            tabDanhSachNV_TrangChinh.Name = "tabDanhSachNV_TrangChinh";

            // Gọi hàm kiểm tra xem tab đã tồn tại hay chưa
            this.showOrActiveTab(tabDanhSachNV_TrangChinh);
            //Dòng lên hiện tabpage mỗi khi nhấn vào button thông tin nhân viên
            
        }
        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            // Đổi lại tên của tab để so sánh tìm xem tab đã tồn tại hay chưa
            tabThongTinCaNhan_TrangChinh.Name = "tabThongTinCaNhan_TrangChinh";

            // Gọi hàm kiểm tra xem tab đã tồn tại hay chưa
            this.showOrActiveTab(tabThongTinCaNhan_TrangChinh);

            
        }
        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            // Đổi lại tên của tab để so sánh tìm xem tab đã tồn tại hay chưa
            tabTaoTaiKhoan_TrangChinh.Name = "tabTaoTaiKhoan_TrangChinh";

            // Gọi hàm kiểm tra xem tab đã tồn tại hay chưa
            this.showOrActiveTab(tabTaoTaiKhoan_TrangChinh);
        }
        private void tabThongTinCaNhan_TrangChinh_Click(object sender, EventArgs e)
        {
           
        }
        private void dtgvThongTinNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgvThongTinNV_Click(object sender, EventArgs e)
        {
            int index = dtgvThongTinNV.CurrentRow.Index;
            tbMaNV.Text = dtgvThongTinNV.Rows[index].Cells[0].Value.ToString();
            tbHotenNV.Text = dtgvThongTinNV.Rows[index].Cells[1].Value.ToString();
            tbQueQuan.Text = dtgvThongTinNV.Rows[index].Cells[4].Value.ToString();
            dtPKNgayKetThuc.Text = dtgvThongTinNV.Rows[index].Cells[2].Value.ToString();
            tbLuong.Text = dtgvThongTinNV.Rows[index].Cells[5].Value.ToString();
            string a = dtgvThongTinNV.Rows[index].Cells[3].Value.ToString();
            if (a == "Nam")
            {
                radiobntNam.Checked = true;
            }
            else
            {
                radiobntNu.Checked = true;
            }
        }

        private void dtgvThongTinSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FormDangNhap f = new FormDangNhap();
            f.ShowDialog();
            this.Show();
            if(f.Login == true)
            {
                //Trang Chính
                btnDangNhap.Enabled = false;
                btnDangXuat.Enabled = true;
                btnDoiMK.Enabled = true;
                btnThongTinNV.Enabled = true;
                btnTaoTK.Enabled = true;
                btnThongTinCaNhan.Enabled = true;
                panelTrangThai.Show();
                labelChuaDangNhap.Hide();
                pictureTrangThai.Show();
                pictureBoxNV.Hide();
                pictureThuKho.Hide();
                labelTen.Text = "Admin";

                //Quản lí tài nguyên sách
                panelChucNang_TaiNguyenSach.Enabled = true;
                panelThongTinSach_TaiNguyenSach.Enabled = true;
                panelSach_TaiNguyenSach.Enabled = true;
                //Khi đăng nhập thành công thì sẽ ADD tabpage đã bị xoá trên FROM_LOAD
                tabCtrlTrangChu.Controls.Add(tabTaiNguyenSach);

                //Thống kê doanh thu
                panelChucNang_DoanhThu.Enabled = true;
                panelDoanhThu_DoanhThu.Enabled = true;
                panelThongTin_DoanhThu.Enabled = true;
                //Khi đăng nhập thành công thì sẽ ADD tabpage đã bị xoá trên FROM_LOAD
                tabCtrlTrangChu.Controls.Add(tabDoanhThu);

                //Nhân viên
                panelChucNang_NV.Enabled = true;
                panelHoaDon_NV.Enabled = true;
                panelThoanhToan_NV.Enabled = true;
                panelSach_NV.Enabled = true;
                //Khi đăng nhập thành công thì sẽ ADD tabpage đã bị xoá trên FROM_LOAD
                tabCtrlTrangChu.Controls.Add(tabNhanVien);

                //Thủ kho
                panelChucNang_ThuKho.Enabled = true;
                panelThongTinSach_ThuKho.Enabled = true;
                //panelSach_ThuKho.Enabled = true;
                //Khi đăng nhập thành công thì sẽ ADD tabpage đã bị xoá trên FROM_LOAD
                tabCtrlTrangChu.Controls.Add(tabThuKho);
            }
            if(f.nv== true)
            {
                //Trang Chính
                btnDangNhap.Enabled = false;
                btnDangXuat.Enabled = true;
                btnDoiMK.Enabled = true;
                labelChuaDangNhap.Hide();
                labelTen.Text = "Nhân viên";
                panelTrangThai.Show();
                pictureBoxNV.Show();
                pictureThuKho.Hide();
                pictureTrangThai.Hide();
                

                //Nhân viên
                panelChucNang_NV.Enabled = true;
                panelHoaDon_NV.Enabled = true;
                panelThoanhToan_NV.Enabled = true;
                panelSach_NV.Enabled = true;
                //Khi đăng nhập thành công thì sẽ ADD tabpage đã bị xoá trên FROM_LOAD
                tabCtrlTrangChu.Controls.Add(tabNhanVien);
            }
            if(f.thukho == true)
            {
                //Trang Chính
                btnDangNhap.Enabled = false;
                btnDangXuat.Enabled = true;
                btnDoiMK.Enabled = true;
                labelChuaDangNhap.Hide();
                labelTen.Text = "Thủ kho";
                panelTrangThai.Show();
                pictureThuKho.Show();
                pictureBoxNV.Hide();
                pictureTrangThai.Hide();


                //Thủ kho
                panelChucNang_ThuKho.Enabled = true;
                panelThongTinSach_ThuKho.Enabled = true;
                //Khi đăng nhập thành công thì sẽ ADD tabpage đã bị xoá trên FROM_LOAD
                tabCtrlTrangChu.Controls.Add(tabThuKho);
            }

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn đăng xuất","Thông báo !",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                //Trang Chính
                btnDangNhap.Enabled = true;
                btnDangXuat.Enabled = false;
                btnDoiMK.Enabled = false;
                btnThongTinNV.Enabled = false;
                btnThongTinCaNhan.Enabled = false;
                btnTaoTK.Enabled = false;
                tabCtrlThongTin.Controls.Remove(tabDoiMK_TrangChinh);
                tabCtrlThongTin.Controls.Remove(tabDanhSachNV_TrangChinh);
                tabCtrlThongTin.Controls.Remove(tabThongTinCaNhan_TrangChinh);
                tabCtrlThongTin.Controls.Remove(tabTaoTaiKhoan_TrangChinh);
                panelTrangThai.Hide();
                labelChuaDangNhap.Show();

                //Khi ấn vào nút đăng xuất thì sẽ xoá đi những tabpage  
                tabCtrlTrangChu.Controls.Remove(tabTaiNguyenSach);
                tabCtrlTrangChu.Controls.Remove(tabDoanhThu);
                tabCtrlTrangChu.Controls.Remove(tabThuKho);
                tabCtrlTrangChu.Controls.Remove(tabNhanVien);

                //Quản lí tài nguyên sách
                //panelChucNang_TaiNguyenSach.Enabled = false;
                //panelThongTinSach_TaiNguyenSach.Enabled = false;
                //panelSach_TaiNguyenSach.Enabled = false;

                //Thống kê doanh thu
                //panelChucNang_DoanhThu.Enabled = false;
                //panelDoanhThu_DoanhThu.Enabled = false;
                //panelThongTin_DoanhThu.Enabled = false;

                //Nhân viên
                //panelChucNang_NV.Enabled = false;
                //panelHoaDon_NV.Enabled = false;
                //panelThoanhToan_NV.Enabled = false;
                //panelSach_NV.Enabled = false;

                //Thủ kho
                //panelChucNang_ThuKho.Enabled = false;
                //panelThongTinSach_ThuKho.Enabled = false;
                //panelSach_ThuKho.Enabled = false;
            }
            

        }

        private void tabThuKho_Click(object sender, EventArgs e)
        {
            
        }

        private void tabDoiMK_TrangChinh_Click(object sender, EventArgs e)
        {
            
        }


        public object t { get; set; }

        private void tabAbout_Click(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void dtPkTrangThai_ValueChanged(object sender, EventArgs e)
        {
         
        }





       

        private void label92_Click(object sender, EventArgs e)
        {

        }

        private void dtgvThongTinNV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //for(int i=0; i < dtgvThongTinNV.RowCount; i++)
            //{
            //    dtgvThongTinNV.Rows[i].Cells[0].Value = i + 1;
            //}
        }
        //Tài nguyên sách------------------------------------------------------------------------------------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            string masach = tbMaSach.Text;
            string tensach = tbTenSach.Text;
            string matacgia = tbMaTacGia.Text;
            string maloaisach = cbbMaLoaiSach.Text;
            string malinhvuc = cbbMaLinhVuc.Text;
            float giamua = float.Parse(tbGiaMua.Text);
            if (TaiNguyenSachDAO.Instance.ThemSach(masach, tensach, matacgia, maloaisach, malinhvuc, giamua))
            {
                MessageBox.Show("Thêm sách thành công ^_^","Thông báo !");
                LoadKhaiBaoSach();
                if (themSach != null)
                    themSach(this, new EventArgs());
                
            }
            else
            {
                LoadKhaiBaoSach();
                MessageBox.Show("Có lỗi khi thêm sách :'(","Thông báo !");
            }
            
        }
        //các event
        private event EventHandler themSach;
        public event EventHandler ThemSach
        {
            add { themSach += value; }
            remove { themSach -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string masach = tbMaSach.Text;

            if (MessageBox.Show("Bạn có muốn xoá sách ?", "Thông báo !", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.No)
            {
                if (TaiNguyenSachDAO.Instance.XoaSach(masach))
                {
                    MessageBox.Show("Xoá sách thành công!");
                    LoadKhaiBaoSach();
                    if (xoaSach != null)
                        xoaSach(this, new EventArgs());
                  //  LoadKhaiBaoSach();
                    //BindingThongTinSach();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xoá sách!");
                }
            }
            
        }
        //các event
        private event EventHandler xoaSach;
        public event EventHandler XoaSach
        {
            add { xoaSach += value; }
            remove { xoaSach -= value; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string masach = tbMaSach.Text;
            string tensach = tbTenSach.Text;
            string matacgia = tbMaTacGia.Text;
           // string loaisach = tbLoaiSach.Text;
            string maloaisach = cbbMaLoaiSach.Text;
            string malinhvuc = cbbMaLinhVuc.Text;
            float giamua = float.Parse(tbGiaMua.Text);
            if (TaiNguyenSachDAO.Instance.SuaSach(masach, tensach, matacgia, maloaisach, malinhvuc, giamua))
            {
                MessageBox.Show("Sửa sách thành công ^_^","Thông báo !");
                LoadKhaiBaoSach();
                if (suaSach != null)
                    suaSach(this, new EventArgs());
                //LoadKhaiBaoSach();
               // BindingThongTinSach();

            }
            else
            {
                MessageBox.Show("Thất bại :'(");
            }
           // BindingThongTinSach();
        }
        //các event
        private event EventHandler suaSach;
        public event EventHandler SuaSach
        {
            add { suaSach += value; }
            remove { suaSach -= value; }
        }
        //List<Sach> TimKiemSach(string tensach)
        //{
        //    List<Sach> DanhSach = TaiNguyenSachDAO.Instance.TimKiemSach(tensach);

        //    return DanhSach;
        //}
        private void btnTim_Click(object sender, EventArgs e)
        {
          //  dtgvThongTinSach.DataSource = TimKiemSach(tbTimSach.Text);
            
        }
        //--------------------------------------------------------------------------------------------------------

        // Thủ kho
        private void btnThemSach_Click(object sender, EventArgs e)
        {

            string _masach = tbMaSach_ThuKho.Text;
            string _tensach = tbTenSach_ThuKho.Text;
            string _matacgia = tbMaTacGia_ThuKho.Text;
            //string _loaisach = tbLoaiSach_ThuKho.Text;
            string _maloaisach = cbbMaLoaiSach_ThuKho.Text;
            string _malinhvuc = cbbMaLinhVuc_ThuKho.Text;
            float _giamua = float.Parse(tbGiaMua_ThuKho.Text);
            if (ThuKhoDAO.Instance.themsach(_masach, _tensach, _matacgia, _maloaisach, _malinhvuc, _giamua))
            {
                MessageBox.Show("Thêm sách thành công ^_^","Thông báo !");
                LoadKhaiBaoThuKho();
                if (_themSach != null)
                    _themSach(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm sách :'(","Thông báo !");
            }
            
        }
            //các event
            private event EventHandler _themSach;
            public event EventHandler _ThemSach
           {
            add { _themSach += value; }
            remove { _themSach -= value; }
           }

            private void btnXoaSach_Click(object sender, EventArgs e)
            {
                string masach = tbMaSach_ThuKho.Text;

                if(MessageBox.Show("Bạn có muốn xoá sách ?","Thông báo !", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.No)
                {
                    if (ThuKhoDAO.Instance.xoasach(masach))
                    {
                        MessageBox.Show("Xoá sách thành công ^_^","Thông báo !");
                        LoadKhaiBaoThuKho();
                        if (_xoaSach != null)
                            _xoaSach(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xoá sách :'(","Thông báo !");
                    }
                }
                
            }
            //các event
            private event EventHandler _xoaSach;
            public event EventHandler _XoaSach
            {
                add { _xoaSach += value; }
                remove { _xoaSach -= value; }
            }

            private void btnCapNhat_Click(object sender, EventArgs e)
            {
                string _masach = tbMaSach_ThuKho.Text;
                string _tensach = tbTenSach_ThuKho.Text;
                string _matacgia = tbMaTacGia_ThuKho.Text;
                //string _loaisach = tbLoaiSach_ThuKho.Text;
                string _maloaisach = cbbMaLoaiSach_ThuKho.Text;
                string _malinhvuc = cbbMaLinhVuc_ThuKho.Text;
                float _giamua = float.Parse(tbGiaMua_ThuKho.Text);
                if (ThuKhoDAO.Instance.suasach(_masach, _tensach, _matacgia, _maloaisach, _malinhvuc, _giamua))
                {
                    MessageBox.Show("Sửa sách thành công ^_^","Thông báo !");
                    LoadKhaiBaoThuKho();
                    if (_suaSach != null)
                        _suaSach(this, new EventArgs());

                }
                else
                {
                    MessageBox.Show("Thất bại :'(","Thông báo !");
                }
            }
            //các event
            private event EventHandler _suaSach;
            public event EventHandler _SuaSach
            {
                add { _suaSach += value; }
                remove { _suaSach -= value; }
            }            
        //--------------------------------------------------------------------------------------------

        //Tạo tài khoản-------------------------------------------------------------------------------
            private void btnThem_TaoTaiKhoan_Click(object sender, EventArgs e)
            {
                string username = tbUsername_TaoTaiKhoan.Text;
                string password = tbPassword_TaoTaiKhoan.Text;
                string manv = tbMaNV_TaoTaiKhoan.Text;
                float id = float.Parse(tbID_TaoTaiKhoan.Text);
                string ngaytao = dtPKNgayTao_TaoTaiKhoan.Value.ToString("MM/dd/yyyy");
                string chucvu = cbbChucVu_TaoTaiKhoan.Text;
                var isAddOK = taikhoanDAO.Instance.ThemTaiKhoan(username, password, manv, id, ngaytao, chucvu);
                if (isAddOK == "1")
                {
                    MessageBox.Show("Thêm tài khoản thành công ^_^", "Thông báo !");
                    LoadThongTinTaiKhoan();
                    if (_themTaiKhoan != null)
                        _themTaiKhoan(this, new EventArgs());

                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm tài khoản: " + isAddOK + "", "Thông báo !");
                }
            }
            //các event
            private event EventHandler _themTaiKhoan;
            public event EventHandler _ThemTaiKhoan
            {
                add { _themTaiKhoan += value; }
                remove { _themTaiKhoan -= value; }
            }

            private void btnXoa_TaoTaiKhoan_Click(object sender, EventArgs e)
            {
                string id = tbID_TaoTaiKhoan.Text;

                if (MessageBox.Show("Bạn có muốn xoá tài khoản này ?", "Thông báo !", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.No)
                {
                    if (taikhoanDAO.Instance.XoaTaiKhoan(id))
                    {
                        MessageBox.Show("Xoá tài khoản thành công ^_^","Thông báo !");
                        LoadThongTinTaiKhoan();
                        if (_xoataikhoan != null)
                            _xoataikhoan(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xoá tài khoản :'(","Thông báo !");
                    }
                }
            }
            //các event
            private event EventHandler _xoataikhoan;
            public event EventHandler _XoaTaiKhoan
            {
                add { _xoataikhoan += value; }
                remove { _xoataikhoan -= value; }
            }
            private void btnCapNhat_TaoTaiKhoan_Click(object sender, EventArgs e)
            {
                string username = tbUsername_TaoTaiKhoan.Text;
                string password = tbPassword_TaoTaiKhoan.Text;
                string manv = tbMaNV_TaoTaiKhoan.Text;
                float id = float.Parse(tbID_TaoTaiKhoan.Text);
                string ngaytao = dtPKNgayTao_TaoTaiKhoan.Value.ToString("MM/dd/yyyy");
                string chucvu = cbbChucVu_TaoTaiKhoan.Text;
                if (taikhoanDAO.Instance.CapNhatTK(username, password, manv, id, ngaytao, chucvu))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công ^_^","Thông báo !");
                    LoadThongTinTaiKhoan();
                    if (capnhat != null)
                        capnhat(this, new EventArgs());

                }
                else
                {
                    MessageBox.Show("Thất bại :'(","Thông báo");
                }
            }
            //các event
            private event EventHandler capnhat;
            public event EventHandler CapNhat
            {
                add { capnhat += value; }
                remove { capnhat -= value; }
            } 
            private void panelThongTinSach_ThuKho_Paint(object sender, PaintEventArgs e)
            {

            }

            private void btnHuyBo_Click(object sender, EventArgs e)
            {
                tbmkCu.Text = tbmkMoi.Text = tbXacNhanMK.Text = "";
            }
            //Thông tin nhân viên---------------------------------
            private void btnXoaNV_Click(object sender, EventArgs e)
            {
                string manv = tbMaNV.Text;

                if (MessageBox.Show("Bạn có muốn xoá nhân viên này ?", "Thông báo !", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.No)
                {
                    if (ThongTinNVDAO.Instance.XoaNV(manv))
                    {
                        MessageBox.Show("Xoá nhân viên thành công ^_^", "Thông báo !");
                        LoadThongTinNhanVien();
                        if (xoanv != null)
                            xoanv(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xoá tài khoản :'(", "Thông báo !");
                    }
                }
            }
            //các event
            private event EventHandler xoanv;
            public event EventHandler XoaNV
            {
                add { xoanv += value; }
                remove { xoanv -= value; }
            }
            

            private void btnThemNV_Click(object sender, EventArgs e)
            {
                string manv = tbMaNV.Text;
                string hoten = tbHotenNV.Text;
                string ngaysinh = dtNamSinh.Value.ToString("MM/dd/yyyy");
                string gioitinh;
                if(radiobntNam.Checked == true)
                {
                    gioitinh = radiobntNam.Text;
                }
                else
                {
                    gioitinh = radiobntNu.Text;
                }
                
                string quequan = tbQueQuan.Text;
                float luong = float.Parse(tbLuong.Text);

                if (ThongTinNVDAO.Instance.ThemNV(manv, hoten, ngaysinh, gioitinh, quequan, luong))
                {
                    MessageBox.Show("Thêm nhân viên thành công ^_^", "Thông báo !");
                    LoadThongTinNhanVien();
                    if (themnv != null)
                        themnv(this, new EventArgs());

                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm nhân viên :'(", "Thông báo !");
                }
            }
            //các event
            private event EventHandler themnv;
            public event EventHandler ThemNV
            {
                add { themnv += value; }
                remove { themnv -= value; }
            }
            private void btnUpdateNV_Click(object sender, EventArgs e)
            {
                string manv = tbMaNV.Text;
                string hoten = tbHotenNV.Text;
                string ngaysinh = dtNamSinh.Value.ToString("MM/dd/yyyy");
                string gioitinh;
                if (radiobntNam.Checked == true)
                {
                    gioitinh = radiobntNam.Text;
                }
                else
                {
                    gioitinh = radiobntNu.Text;
                }

                string quequan = tbQueQuan.Text;
                float luong = float.Parse(tbLuong.Text);
                if (ThongTinNVDAO.Instance.UpDateNV(manv, hoten, ngaysinh, gioitinh, quequan, luong))
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công ^_^","Thông báo !");
                    LoadThongTinNhanVien();
                    if (updatenv != null)
                        updatenv(this, new EventArgs());

                }
                else
                {
                    MessageBox.Show("Thất bại :'(","Thông báo");
                }
            }
            private event EventHandler updatenv;
            public event EventHandler UpdateNV
            {
                add { updatenv += value; }
                remove { updatenv -= value; }
            } 
            private void btnThemBill_Click(object sender, EventArgs e)
            {
                int check = 0;
                try
                {
                    
                    if(listViewHoaDon.Items.Count == 0)
                    { 
                     if(tbTenKhachHang.Text == "")
                     {
                         MessageBox.Show("Không được bỏ trống tên khách hàng!!");
                     }
                     else
                     {

                     
                     DataProvider.Instance.ExecuteNonQuery4("insert dbo.Hoadon (TENKHACHHANG) values(N'" + tbTenKhachHang.Text + "')");}
                    }

                    int index = dtgvHoaDon.CurrentRow.Index;
                    //lay mã sách
                    string a= dtgvHoaDon.Rows[index].Cells[0].Value.ToString();
                    //lấy tên sách
                    string b = dtgvHoaDon.Rows[index].Cells[1].Value.ToString();
                    foreach (ListViewItem item in listViewHoaDon.Items)
                    {
                       
                        if (b == item.SubItems[1].Text)
                        {
                            
                            check = 1;
                            
                        }

                    }
                   
                    if (check == 1)
                    {
                        DataProvider.Instance.ExecuteNonQuery4("EXEC updateBillInfo "+numberic.Value+",'"+a+"'");
                    }
                    else
                    {
                        DataProvider.Instance.ExecuteNonQuery4("EXEC CThoadon '" + a + "'," + numberic.Value + "," + cbbGiamGia.Text + " ");
                    }
                    loadlistHD();
                }
                catch
                {
                    MessageBox.Show("Lỗi ");
                }
            }
        private void loadlistHD()
        {
            listViewHoaDon.Items.Clear();
            int a=0;
            DataTable dt = DataProvider.Instance.ExecuteQuery("EXEC LoadList");
            foreach(DataRow row in dt.Rows)
            {
                //Thêm dòng vào listview
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row[1].ToString());
                item.SubItems.Add(row[2].ToString());
                item.SubItems.Add(row[3].ToString());
                item.SubItems.Add(row[4].ToString());
                item.SubItems.Add(row[5].ToString());
                a+=(int.Parse(row[5].ToString()));
                listViewHoaDon.Items.Add(item);

            }
            tbTongTien.Text = a.ToString();
            int HeaderWidth = (listViewHoaDon.Parent.Width - 2) / listViewHoaDon.Columns.Count;
            foreach (ColumnHeader header in listViewHoaDon.Columns)
            {
                header.Width = HeaderWidth;
            }
           

        }

        private void btnXoaBill_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listViewHoaDon.SelectedItems)
            {
                DialogResult dt = MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dt == DialogResult.Yes)
                {
                    
                    DataProvider.Instance.ExecuteNonQuery4("delete chitiethoadon where MaCTHoadon=" + item.SubItems[0].Text + " ");
                }
            }
            loadlistHD();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn thanh toán k? Tổng số tiền: " + tbTongTien.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dt == DialogResult.Yes)
            {
                DateTime aa = DateTime.Now;

                DataProvider.Instance.ExecuteNonQuery4("EXEC UpdateBill '" + aa.ToString("yyyy/MM/dd") + "'," + tbTongTien.Text + " ");
                listViewHoaDon.Items.Clear();
                tbTongTien.Clear();
            }
        }

        private void tbTimKiemSach_NV_TextChanged(object sender, EventArgs e)
        {
           
            string query = "SELECT * FROM dbo.sach where TENSACH like N'%"+tbTimKiemSach_NV.Text+"%'";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvHoaDon.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string query = "EXEC DThu '" + dtPKNgayBatDau.Value.ToString("yyyy/MM/dd") + "', '" + dtPKNgayKetThuc.Value.ToString("yyyy/MM/dd") + "'";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvDoanhThu.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void tbTimSach_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.sach where TENSACH like N'%" + tbTimSach.Text + "%'";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvThongTinSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvThongTinSach.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void tbTimKiemSach_ThuKho_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.sach where TENSACH like N'%" + tbTimKiemSach_ThuKho.Text + "%'";

            //Canh chỉnh cho bản dữ liệu nó vừa với dataGridView
            dtgvThuKho_ThuKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Hiện dữ liệu lên dataGirdView cần hiển thị
            dtgvThuKho_ThuKho.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

 
    }

    

    }

