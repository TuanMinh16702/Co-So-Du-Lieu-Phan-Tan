using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CRUD
{
    public class AddSTAFFRecordEventArgs : EventArgs
    {
        public string Manv { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Phai { get; set; }

        // Constructor để khởi tạo đối tượng với các giá trị
        public AddSTAFFRecordEventArgs(String manv, string ho, string ten, string sdt, string ngaySinh, string diaChi, string phai)
        {
            Manv = manv;
            Ho = ho;
            Ten = ten;
            Sdt = sdt;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            Phai = phai;
        }
    }
}
