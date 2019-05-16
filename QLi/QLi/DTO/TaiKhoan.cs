using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLi.DTO
{
    public class TaiKhoan
    {
        public TaiKhoan(string USERNAME, string TEN, string ID, string NGAYLAM, string CHUCVU, string PASSWORD = null)
        {
            this.USERNAME = USERNAME;
            this.TEN = TEN;
            this.ID = ID;
            this.NGAYLAM = NGAYLAM;
            this.CHUCVU = CHUCVU;
            this.PASSWORD = PASSWORD;
        }
        public TaiKhoan(DataRow row)
        {
            this.USERNAME = row["USERNAME"].ToString ();
            this.TEN = row["TEN"].ToString();
            this.ID = row["ID"].ToString();
            this.NGAYLAM = row["NGAYLAM"].ToString();
            this.CHUCVU = row["CHUCVU"].ToString();
            this.PASSWORD = row["PASSWORD"].ToString();
        }
        private string CHUCVU;

        public string CHUCVU1
        {
            get { return CHUCVU; }
            set { CHUCVU = value; }
        }
        private string NGAYLAM;

        public string NGAYLAM1
        {
            get { return NGAYLAM; }
            set { NGAYLAM = value; }
        }
        private string ID;

        public string ID1
        {
            get { return ID; }
            set { ID = value; }
        }
        private string TEN;

        public string TEN1
        {
            get { return TEN; }
            set { TEN = value; }
        }
        private string PASSWORD;

        public string PASSWORDl1
        {
            get { return PASSWORD; }
            set { PASSWORD = value; }
        }
        private string USERNAME;

        public string USERNAME1
        {
            get { return USERNAME; }
            set { USERNAME = value; }
        }
    }
}
