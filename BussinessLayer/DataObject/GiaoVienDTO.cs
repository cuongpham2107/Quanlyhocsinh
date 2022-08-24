using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DataObject
{
    public class GiaoVienDTO
    {
        public int MaGV { get; set; }
        public string HoTen { get; set; }
        public string Ten { get; set; }
        public Nullable<int> GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public byte[] HinhAnh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public Nullable<int> MaTD { get; set; }
        public Nullable<int> MaCV { get; set; }
        public Nullable<int> CrearedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string TenTD { get; set; }
        public string TenCV { get; set; }
    }
}
