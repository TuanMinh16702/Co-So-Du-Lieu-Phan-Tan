using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CRUD
{
    public class AddBillRecordEventArgs
    {
        public string Sohd { get; set; }
        
        public string NgayLap { get; set; }
        public string hoten { get; set; }
        public string TenKho { get; set; }
        public string tenkh { get; set; }
        public float Total { get; set; }




        // Constructor để khởi tạo đối tượng với các giá trị
        public AddBillRecordEventArgs(String Sohd, string ngaylap, string hoten,
           string tenkho, string tenkh, float total)
        {
            this.Sohd = Sohd;
            this.NgayLap = ngaylap;
            this.tenkh = tenkh;
            
            this.Total = total;
            //this.SoLuong = soluong;
            this.hoten = hoten;
            this.TenKho = tenkho;
        }
    }
}
