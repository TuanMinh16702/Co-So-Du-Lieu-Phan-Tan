using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CRUD
{
    public class AddRecordEventArgs : EventArgs
    {
        public AddRecordEventArgs(String maHH, String nameproduct, String dvt, String productType)
        {
            this.maHH = maHH;
            this.tenHH = nameproduct;
            this.dvt = dvt;
            this.tenlh = productType;
        }

        public string maHH { get; private set; }
        public string tenHH { get; private set; }
        public string dvt { get; private set; }
        public string tenlh { get; private set; }
    }
}
