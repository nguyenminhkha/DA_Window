using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLi.DTO
{
    public class HoaDon
    {
        public HoaDon(int MAHOADON, int TENKHACHHANG, DateTime? NGAYLAP, int TONGTIEN)
        {
            this.MAHOADON1 = MAHOADON;
            this.TENKHACHHANG1 = TENKHACHHANG;
            this.NGAYLAP1 = NGAYLAP;
            this.TONGTIEN1 = TONGTIEN; 
        }
        public HoaDon(DataRow row)
        {
            this.MAHOADON1 =(int) row ["MAHOADON"];
            this.TENKHACHHANG1 =(int) row ["TENKHACHHANG"];
            this.NGAYLAP1 =(DateTime?) row ["NGAYLAP"];
            this.TONGTIEN1 = (int) row ["TONGTIEN"]; 
        }

        private int TONGTIEN;

        public int TONGTIEN1
        {
            get { return TONGTIEN; }
            set { TONGTIEN = value; }
        }

        private DateTime? NGAYLAP;

        public DateTime? NGAYLAP1
        {
            get { return NGAYLAP; }
            set { NGAYLAP = value; }
        }

        private int TENKHACHHANG;

        public int TENKHACHHANG1
        {
            get { return TENKHACHHANG; }
            set { TENKHACHHANG = value; }
        }

        private int MAHOADON;

        public int MAHOADON1
        {
            get { return MAHOADON; }
            set { MAHOADON = value; }
        }
    }
}
