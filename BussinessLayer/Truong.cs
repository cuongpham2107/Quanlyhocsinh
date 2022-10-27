using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class Truong
    {
        QuanlyEntities db = null;

        public Truong()
        {
            db = new QuanlyEntities();
        }
        public tbl_Truong getItem(int maT)
        {
            return db.tbl_Truong.FirstOrDefault(x => x.MaTruong == maT);
        }
        public List<tbl_Truong> getList()
        {
            return db.tbl_Truong.ToList();
        }
        public tbl_Truong Add(tbl_Truong t)
        {
            try
            {
                db.tbl_Truong.Add(t);
                db.SaveChanges();
                return t;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :" + e.Message);
            }
        }
        public tbl_Truong Update(tbl_Truong t)
        {
            try
            {
                var data = db.tbl_Truong.FirstOrDefault(x => x.MaTruong == t.MaTruong);
                data.TenTruong = t.TenTruong;
                data.Email = t.Email;
                data.DienThoai = t.DienThoai;
                data.DiaChi = t.DiaChi;
                data.Website = t.Website;
                data.UpdatedBy = t.UpdatedBy;
                data.UpdatedDate = t.UpdatedDate;
                db.SaveChanges();
                return t;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :" + e.Message);
            }
        }
        public void Delete(int maT, int UserID)
        {
            try
            {
                var data = db.tbl_Truong.FirstOrDefault(x => x.MaTruong == maT);
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
