using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ChucVu
    {
        QuanlyEntities db = null;
        public ChucVu()
        {
            db = new QuanlyEntities();
        }
        public tbl_ChucVu getItem(int id)
        {
            return db.tbl_ChucVu.FirstOrDefault(x=>x.MaCV == id);
        }
        public List<tbl_ChucVu> getList()
        {
            return db.tbl_ChucVu.ToList();
        }
    }
}
