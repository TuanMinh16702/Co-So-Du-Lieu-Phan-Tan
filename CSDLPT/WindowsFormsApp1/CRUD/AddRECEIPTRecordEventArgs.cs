using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CRUD
{
    public class AddRECEIPTRecordEventArgs : EventArgs
    {
        public string SoPn { get; set; }
        public string maHH { get; set; }
        public string TenHH { get; set; }
        public string NgayLap { get; set; }
        public string manv { get; set; }
        public string hoten { get; set; }
        public string TenKho { get; set; }
        public string maddh { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongTon { get; set; }
        public float DonGia { get; set; }
       

        

        // Constructor để khởi tạo đối tượng với các giá trị
        public AddRECEIPTRecordEventArgs(String SoPn, string mahh ,string tenhh, string ngaylap, string manv ,string hoten,
           string tenkho, string maddh, int soluong, int soluongton ,float dongia)
        {
            this.SoPn = SoPn;
            this.maHH = mahh;
            this.TenHH = tenhh;
            this.NgayLap = ngaylap;
            this.hoten = hoten;
            this.TenKho = tenkho;
            this.maddh = maddh;
            this.DonGia = dongia;
            this.SoLuong = soluong;
            this.SoLuongTon = soluongton;
            this.manv = manv;
           
        }
    }
}
