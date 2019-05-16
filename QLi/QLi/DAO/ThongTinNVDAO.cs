using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLi.DAO
{
    public class ThongTinNVDAO
    {
        //Design patern Singleton
        //Tạo 1 đối tượng kiểu static - bất cứ gì liên kết qua instance thì nó là duy nhất
        //Và đóng gói lại Ctrl + R + E
        private static ThongTinNVDAO instance;

        internal static ThongTinNVDAO Instance
        {
            get { if (instance == null) instance = new ThongTinNVDAO(); return ThongTinNVDAO.instance; }
            private set { ThongTinNVDAO.instance = value; }
        }
        public bool ThemNV(string manv, string hoten, string ngaysinh, string gioitinh, string quequan, float luong)
        {
            string query = string.Format("INSERT INTO dbo.thongtinnv (MANV, HOTEN, NGAYSINH, GIOITINH, QUEQUAN, LUONGCOBAN) VALUES (N'{0}', N'{1}',N'{2}',N'{3}',N'{4}','{5}') ", manv, hoten, ngaysinh, gioitinh, quequan, luong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpDateNV(string manv, string hoten, string ngaysinh, string gioitinh, string quequan, float luong)
        {
            string query = string.Format("UPDATE thongtinnv SET HOTEN = N'{0}', NGAYSINH = N'{1}', GIOITINH = N'{2}', QUEQUAN = N'{3}', LUONGCOBAN = N'{4}' WHERE MANV = N'{5}'", hoten, ngaysinh, gioitinh, quequan, luong, manv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            //Nếu như có 1 dòng được INSERT thì nó sẽ trả ra giá trị là 1 ( sẽ thành công và ngược lại )
            return result > 0;
        }
        public bool XoaNV(string manv)
        {
            string query = string.Format("delete  thongtinnv where MANV =N'{0}'", manv);
            // MessageBox.Show(query);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //internal bool ThemNV(string HoTen, string NamSinh, string QueQuan, float LuongCoBan)
        //{
        //    throw new NotImplementedException();
        //}





    }
}
