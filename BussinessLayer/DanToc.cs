using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class DanToc
    {
        QuanlyEntities db = null;
        public DanToc()
        {
            db = new QuanlyEntities();
        }
        public tbl_DanToc getItem(int dt)
        {
            return db.tbl_DanToc.FirstOrDefault(x => x.MaDT == dt);
        }
        public List<tbl_DanToc> getList()
        {
            return db.tbl_DanToc.ToList();
        }
        public tbl_DanToc Add(tbl_DanToc dt)
        {
            try
            {
                db.tbl_DanToc.Add(dt);
                db.SaveChanges();
                return dt;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :"+e.Message);
            }
        }
        public tbl_DanToc Update(tbl_DanToc dt)
        {
            try
            {
                var data = db.tbl_DanToc.FirstOrDefault(x => x.MaDT == dt.MaDT);
                data.TenDT = dt.TenDT;
                db.SaveChanges();
                return dt;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :"+e.Message);
            }
        }
        public void Delete(int dt, int UserId)
        {
            try
            {
                var data = db.tbl_DanToc.FirstOrDefault(x => x.MaDT == dt);
                data.DeletedBy = UserId;
                data.DeletedDate = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
