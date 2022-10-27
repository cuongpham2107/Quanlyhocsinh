using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DataObject
{
    
    public class LopHocDTO
    {
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public string GhiChu { get; set; }
        public string SapXep { get; set; }
        public Nullable<int> MaTruong { get; set; }
        public Nullable<int> CrearedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string TenTruong { get; set; }
    }
    
}
