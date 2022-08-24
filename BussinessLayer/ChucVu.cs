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
        public tbl_ChucVu Add(tbl_ChucVu cv)
        {
            try
            {
                db.tbl_ChucVu.Add(cv);
                db.SaveChanges();
                return cv;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :"+ e.Message);
            }
        }
        public tbl_ChucVu Update(tbl_ChucVu cv)
        {
            try
            {
                var data = db.tbl_ChucVu.FirstOrDefault(x=>x.MaCV == cv.MaCV);
                data.TenCV = cv.TenCV;
                db.SaveChanges();
                return cv;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :" + e.Message);
            }
        }
        public void Delete(int maCv, int UserID)
        {
            try
            {
                var data = db.tbl_ChucVu.FirstOrDefault(x => x.MaCV == maCv);
                data.DeletedBy = UserID;
                data.DeletedDate = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :" + e.Message);
            }
        }

    }
}
