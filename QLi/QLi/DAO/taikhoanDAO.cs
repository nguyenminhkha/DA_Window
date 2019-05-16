using QLi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLi.DAO
{
    public class taikhoanDAO
    {
        //Design patern Singleton
        //Tạo 1 đối tượng kiểu static - bất cứ gì liên kết qua instance thì nó là duy nhất
        //Và đóng gói lại Ctrl + R + E
        private static taikhoanDAO instance; 

        public  static taikhoanDAO Instance
        {
            get { if (instance == null) instance = new taikhoanDAO(); return instance; }
            private set { instance = value; }
        }
        private taikhoanDAO()
        {

        }
       
        //public bool Login(string USERNAME, string PASSWORK)
        //{
        //    string query = "SELECT * FROM taikhoan WHERE USERNAME = N'" + USERNAME + "' AND PASSWORD = N'" + PASSWORK +"'";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query);

        //    return result.Rows.Count > 0;
        //}
        public string ThemTaiKhoan(string username, string password, string manv, float id, string ngaytao, string chucvu)
        {
            try
            {
                string query = string.Format("INSERT INTO taikhoan (USERNAME, PASSWORD, MaNV, ID, NgayTao, ChucVu) VALUES (N'{0}', N'{1}',N'{2}','{3}',N'{4}',N'{5}') ", username, password, manv, id, ngaytao, chucvu);
                //MessageBox.Show(query);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                //Nếu như có 1 dòng được INSERT thì nó sẽ trả ra giá trị là 1 ( sẽ thành công và ngược lại )
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public bool XoaTaiKhoan(string ID)
        {
            string query = string.Format("delete  taikhoan where ID ='{0}'", ID);
            // MessageBox.Show(query);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool CapNhatTK(string username, string password, string manv, float id, string ngaytao, string chucvu)
        {
            string query = string.Format("UPDATE taikhoan SET  PASSWORD = N'{0}', MaNV = N'{1}', ID = '{2}', NgayTao = N'{3}', ChucVu = N'{4}' WHERE USERNAME = N'{5}'", password, manv, id, ngaytao, chucvu, username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            //Nếu như có 1 dòng được INSERT thì nó sẽ trả ra giá trị là 1 ( sẽ thành công và ngược lại )
            return result > 0;
        }
        // public TaiKhoan GetTaiKhoanByUserName(string USERNAME)
        //{
        //    DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.taikhoan WHERE USERNAME = N'" + USERNAME + "'"  );
             
        //     foreach (DataRow item in data.Rows)
        //     {
        //         return new TaiKhoan(item);
        //     }
        //     return  null;
        //}



        
    }
}
