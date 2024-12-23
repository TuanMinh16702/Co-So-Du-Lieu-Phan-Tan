using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CRUD
{
    public class AddORDERRecordEventArgs : EventArgs
    {

        public string MaDDH { get; set; }
        public string NgayLap { get; set; }
        public string TenNCC { get; set; }
        public string TenKho { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public string TenHH { get; set; }

        public string manv {  get; set; }
        public string hoten { get; set; }

        // Constructor để khởi tạo đối tượng với các giá trị
        public AddORDERRecordEventArgs(String maddh,  string tenhh, string ngaylap, string manv ,string hoten,
           string tenkho, string tenncc, int soluong, float dongia)
        {
            this.MaDDH = maddh;
            this.NgayLap = ngaylap;
            this.TenNCC = tenncc;
            this.TenHH = tenhh;
            this.DonGia = dongia;
            this.SoLuong = soluong;
            this.hoten = hoten;
            this.TenKho = tenkho;
            this.manv = manv;
        }   
    }
}
