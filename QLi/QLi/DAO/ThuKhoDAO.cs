using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLi.DAO
{
    public class ThuKhoDAO
    {
        //Design patern Singleton
        //Tạo 1 đối tượng kiểu static - bất cứ gì liên kết qua instance thì nó là duy nhất
        //Và đóng gói lại Ctrl + R + E
        private static ThuKhoDAO instance;

        internal static ThuKhoDAO Instance
        {
            get { if (instance == null) instance = new ThuKhoDAO(); return ThuKhoDAO.instance; }
            private set { ThuKhoDAO.instance = value; }
        }
        public bool themsach(string _masach, string _tensach, string _matacgia, string _maloaisach, string _malinhvuc, float _giamua)
        {
            string query = string.Format("INSERT INTO dbo.sach (MASACH, TENSACH, MATACGIA, MALOAISACH, MALINHVUC, GIAMUA) VALUES ('{0}', N'{1}',N'{2}',N'{3}',N'{4}','{5}') ", _masach, _tensach, _matacgia, _maloaisach, _malinhvuc, _giamua);
            //MessageBox.Show(query);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            //Nếu như có 1 dòng được INSERT thì nó sẽ trả ra giá trị là 1 ( sẽ thành công và ngược lại )
            return result > 0;
        }
        public bool suasach(string _masach, string _tensach, string _matacgia, string _maloaisach, string _malinhvuc, float _giamua)
        {
            string query = string.Format("UPDATE sach SET  tensach = N'{0}', matacgia = N'{1}',, maloaisach = N'{2}', malinhvuc = N'{3}', giamua = {4} WHERE MASACH = '{5}'", _tensach, _matacgia, _maloaisach, _malinhvuc, _giamua, _masach);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            //Nếu như có 1 dòng được INSERT thì nó sẽ trả ra giá trị là 1 ( sẽ thành công và ngược lại )
            return result > 0;
        }

        public bool xoasach(string MASACH)
        {
            string query = string.Format("delete  sach where MASACH ='{0}'", MASACH);
            // MessageBox.Show(query);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }





        //internal bool suasach(string _masach, string _tensach, string _matacgia, string _maloaisach, string _malinhvuc, float _giamua)
        //{
        //    throw new NotImplementedException();
        //}

        //internal bool themsach(string _masach, string _tensach, string _matacgia, string _maloaisach, string _malinhvuc, float _giamua)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
