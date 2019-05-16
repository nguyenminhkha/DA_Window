using QLi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLi.DAO
{
    public class HoaDonDAO
    {
        //Design patern Singleton
        //Tạo 1 đối tượng kiểu static - bất cứ gì liên kết qua instance thì nó là duy nhất
        //Và đóng gói lại Ctrl + R + E
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set { HoaDonDAO.instance = value; }
        }

        private HoaDonDAO() { }

        public int GetUncheckHoaDon(int MAHOADON)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.hoadon");
            if (data.Rows.Count > 0 )
            {
                HoaDon hoadon = new HoaDon(data.Rows[0]);
                return hoadon.MAHOADON1;
            }
            return -1;
        }
    }
}
