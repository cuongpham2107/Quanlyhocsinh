using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.DataObject;
using DataAccessLayer;

namespace BussinessLayer
{
    public class LopHoc
    {
        QuanlyEntities db = null;
        Truong truong;
        public LopHoc()
        {
            db = new QuanlyEntities();
            truong = new Truong();
        }
        public tbl_Lop getItem(int maLop)
        {
            return db.tbl_Lop.FirstOrDefault(x => x.MaLop == maLop);
        }
        public List<LopHocDTO> getList()
        {
            var list = db.tbl_Lop.ToList();
            List<LopHocDTO> listLH = new List<LopHocDTO>();
            LopHocDTO lopHocDTO;
            foreach (var item in list)
            {
                lopHocDTO = new LopHocDTO();
                lopHocDTO.MaLop = item.MaLop;
                lopHocDTO.TenLop = item.TenLop;
                lopHocDTO.GhiChu = item.GhiChu;
                lopHocDTO.SapXep = item.SapXep;
                lopHocDTO.MaTruong = item.MaTruong;
                if(item.MaTruong != null)
                {
                    var t = truong.getItem((int)item.MaTruong);
                    lopHocDTO.TenTruong = t.TenTruong;
                }
                lopHocDTO.CrearedBy = item.CrearedBy;
                lopHocDTO.CreatedDate = item.CreatedDate;
                lopHocDTO.UpdatedBy = item.UpdatedBy;
                lopHocDTO.UpdatedDate = item.UpdatedDate;
                lopHocDTO.DeletedBy = item.DeletedBy;
                lopHocDTO.DeletedDate = item.DeletedDate;
                listLH.Add(lopHocDTO);
            }
            return listLH;
        }
        public tbl_Lop Add(tbl_Lop lop)
        {
            try
            {
                db.tbl_Lop.Add(lop);
                db.SaveChanges();
                return lop;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :" + e.Message);
            }
        }
        public tbl_Lop Update(tbl_Lop lop)
        {
            try
            {
                var data = db.tbl_Lop.FirstOrDefault(x => x.MaLop == lop.MaLop);
                data.TenLop = lop.TenLop;
                data.GhiChu = lop.GhiChu;
                data.MaTruong = lop.MaTruong;
                data.UpdatedBy = lop.UpdatedBy;
                data.UpdatedDate = lop.UpdatedDate;
                db.SaveChanges();
                return lop;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :" + e.Message);
            }
        }
        public void Delete(int maL, int UserID)
        {
            try
            {
                var data = db.tbl_Lop.FirstOrDefault(x => x.MaLop == maL);
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
