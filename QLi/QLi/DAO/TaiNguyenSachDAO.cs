using QLi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLi.DAO
{
    public class TaiNguyenSachDAO
    {
        //Design patern Singleton
        //Tạo 1 đối tượng kiểu static - bất cứ gì liên kết qua instance thì nó là duy nhất
        //Và đóng gói lại Ctrl + R + E
        private static TaiNguyenSachDAO instance;

        internal static TaiNguyenSachDAO Instance
        {
            get { if (instance == null) instance = new TaiNguyenSachDAO(); return TaiNguyenSachDAO.instance; }
            private set { TaiNguyenSachDAO.instance = value; }
        }
        
        public bool ThemSach(string masach, string tensach, string matacgia, string maloaisach, string malinhvuc, float giamua)
        {
            string query = string.Format("INSERT INTO dbo.sach (MASACH, TENSACH, MATACGIA, MALOAISACH, MALINHVUC, GIAMUA) VALUES ('{0}', N'{1}',N'{2}',N'{3}',N'{4}','{5}') ", masach, tensach, matacgia, maloaisach, malinhvuc, giamua);
           
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            //Nếu như có 1 dòng được INSERT thì nó sẽ trả ra giá trị là 1 ( sẽ thành công và ngược lại )
            return result > 0;
        }
        public bool SuaSach(string masach, string tensach, string matacgia, string maloaisach, string malinhvuc, float giamua)
        {
            string query = string.Format("UPDATE sach SET  tensach = N'{0}', matacgia = N'{1}', maloaisach = N'{2}', malinhvuc = N'{3}', giamua = {4} WHERE MASACH = '{5}'", tensach, matacgia, maloaisach, malinhvuc, giamua, masach);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            //Nếu như có 1 dòng được INSERT thì nó sẽ trả ra giá trị là 1 ( sẽ thành công và ngược lại )
            return result > 0;
        }

        public bool XoaSach(string MASACH)
        {
            string query = string.Format("delete  sach where MASACH ='{0}'", MASACH);
           // MessageBox.Show(query);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }





        internal bool SuaSach(string masach, string tensach, string matacgia, DataGridViewTextBoxColumn loaisach, string maloaisach, string malinhvuc, float giamua)
        {
            throw new NotImplementedException();
        }
    }
}
