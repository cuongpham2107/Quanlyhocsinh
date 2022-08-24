using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class TrinhDo
    {
        QuanlyEntities db = null;
        public TrinhDo()
        {
            db = new QuanlyEntities();
        }
        public tbl_TrinhDo getItem(int id)
        {
            return db.tbl_TrinhDo.FirstOrDefault(x => x.MaTD == id);
        }
        public List<tbl_TrinhDo> getList()
        {
            return db.tbl_TrinhDo.ToList();
        }
        public tbl_TrinhDo Add(tbl_TrinhDo td)
        {
            try
            {
                db.tbl_TrinhDo.Add(td);
                db.SaveChanges();
                return td;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :"+e.Message);
            }
        }
        //public tbl_TrinhDo Update(tbl_TrinhDo td)
        //{
        //    try
        //    {
        //        var data = db.tbl_TrinhDo.FirstOrDefault(x => x.MaTD == td.MaTD);
                
        //        data.TenTD = td.TenTD;
        //        data.UpdatedBy = td.Upda

        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception("Lỗi :"+e.Message);
        //    }
        //}
    }
}
