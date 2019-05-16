using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLi.DTO
{
    public class TTNV
    {
        private string HoTen;

        public string HoTen1
        {
            get { return HoTen; }
            set { HoTen = value; }
        }
        private string NamSinh;

        public string NamSinh1
        {
            get { return NamSinh; }
            set { NamSinh = value; }
        }
        private string QueQuan;

        public string QueQuan1
        {
            get { return QueQuan; }
            set { QueQuan = value; }
        }
        private string GioiTinh;

        public string GioiTinh1
        {
            get { return GioiTinh; }
            set { GioiTinh = value; }
        }
        private string LuongCoBan;

        public string LuongCoBan1
        {
            get { return LuongCoBan; }
            set { LuongCoBan = value; }
        }

        public  TTNV(string HOTEN, string NAMSINH, string QUEQUAN, string GIOITINH, string LUONGCOBAN)
        {
            this.HoTen = HOTEN;
            this.NamSinh = NAMSINH;
            this.QueQuan = QUEQUAN;
            this.GioiTinh = GIOITINH;
            this.LuongCoBan = LUONGCOBAN;
        }
        public TTNV(DataRow row)
        {
            this.HoTen = row["HoTen"].ToString();
            this.NamSinh = row["NamSinh"].ToString();
            this.QueQuan = row["QueQuan"].ToString();
            this.GioiTinh = row["GioiTinh"].ToString();
            this.LuongCoBan = row["LuongCoBan"].ToString();
            
        }

       

    }
}
