using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLi.DTO
{
    public class Sach
    {
        private string _MaSach;

        public string MaSach
        {
            get { return _MaSach; }
            set { _MaSach = value; }
        }

        private string _TenSach;

        public string TenSach
        {
            get { return _TenSach; }
            set { _TenSach = value; }
        }

        private string _MaTacGia;

        public string MaTacGia
        {
            get { return _MaTacGia; }
            set { _MaTacGia = value; }
        }

        private string _LoaiSach;

        public string LoaiSach
        {
            get { return _LoaiSach; }
            set { _LoaiSach = value; }
        }

        private string _MaLoaiSach;

        public string MaLoaiSach
        {
            get { return _MaLoaiSach; }
            set { _MaLoaiSach = value; }
        }

        private string _MaLinhVuc;

        public string MaLinhVuc
        {
            get { return _MaLinhVuc; }
            set { _MaLinhVuc = value; }
        }

        private float _GiaMua;

        public float GiaMua
        {
            get { return _GiaMua; }
            set { _GiaMua = value; }
        }

        public Sach(string pMaSach, string pTenSach, string pMaTacGia, string pLoaiSach, string pMaLoaiSach, string pMaLinhVuc, float pGiaMua)
        {
            this._MaSach = pMaSach;
            this._TenSach = pTenSach;
            this._MaTacGia = pMaTacGia;
            this._LoaiSach = pLoaiSach;
            this._MaLoaiSach = pMaLoaiSach;
            this._MaLinhVuc = pMaLinhVuc;
            this._GiaMua = pGiaMua;
        }
        public Sach(DataRow row)
        {


            this._MaSach = row["MaSach"].ToString(); ;
            this._TenSach = row["TenSach"].ToString(); ;
            this._MaTacGia = row["MaTacGia"].ToString(); ;
            this._LoaiSach = row["LoaiSach"].ToString(); ;
            this._MaLoaiSach = row["MaLoaiSach"].ToString(); ;
            this._MaLinhVuc = row["MaLinhVuc"].ToString(); ;
            this._GiaMua = (float)row["GiaMua"]; ;
        }
    }
}
