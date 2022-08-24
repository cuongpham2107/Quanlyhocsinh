using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.DataObject;
using DataAccessLayer;

namespace BussinessLayer
{
    public class GiaoVien
    {
        QuanlyEntities db = null;
        TrinhDo trinhDo;
        ChucVu chucVu;
        public GiaoVien()
        {
            db = new QuanlyEntities();
            trinhDo = new TrinhDo();
            chucVu = new ChucVu();
        }
        public tbl_GiaoVien getItem(int maGv)
        {
            return db.tbl_GiaoVien.FirstOrDefault(x => x.MaGV == maGv);
        }
        public List<GiaoVienDTO> getList()
        {
            var list = db.tbl_GiaoVien.ToList();
            
            List<GiaoVienDTO> listGV = new List<GiaoVienDTO>();
            GiaoVienDTO giaoVienDTO;

            foreach (var item in list)
            {
                giaoVienDTO = new GiaoVienDTO();
                giaoVienDTO.MaGV = item.MaGV;
                giaoVienDTO.HoTen = item.HoTen;
                giaoVienDTO.Ten = item.Ten;
                giaoVienDTO.GioiTinh = item.GioiTinh;
                giaoVienDTO.NgaySinh = item.NgaySinh;
                giaoVienDTO.DiaChi = item.DiaChi;
                giaoVienDTO.DienThoai = item.DienThoai;
                giaoVienDTO.Email = item.Email;
                giaoVienDTO.HinhAnh = item.HinhAnh;
                giaoVienDTO.MaTD = item.MaTD;

                var td = trinhDo.getItem((int)item.MaTD);
                giaoVienDTO.TenTD = td.TenTD;
                giaoVienDTO.MaCV = item.MaCV;
                var cv = chucVu.getItem((int)item.MaCV);
                giaoVienDTO.TenCV = cv.TenCV;

                giaoVienDTO.CrearedBy = item.CrearedBy;
                giaoVienDTO.CreatedDate = item.CreatedDate;
                giaoVienDTO.UpdatedBy = item.UpdatedBy;
                giaoVienDTO.UpdatedDate = item.UpdatedDate;
                giaoVienDTO.DeletedBy = item.DeletedBy;
                giaoVienDTO.DeletedDate = item.DeletedDate;

                listGV.Add(giaoVienDTO);
            }
            return listGV;
            
            
          
        }
        public tbl_GiaoVien Add(tbl_GiaoVien gv)
        {
            try
            {
                db.tbl_GiaoVien.Add(gv);
                db.SaveChanges();
                return gv;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :"+e.Message);
            }
        }
        public tbl_GiaoVien Update(tbl_GiaoVien gv)
        {
            try
            {
                var data = db.tbl_GiaoVien.FirstOrDefault(x => x.MaGV == gv.MaGV);
               
                data.HoTen = gv.HoTen;
                data.Ten = gv.Ten;
                data.GioiTinh = gv.GioiTinh;
                data.NgaySinh = gv.NgaySinh;
                data.DiaChi = gv.DiaChi;
                data.DienThoai = gv.DienThoai;
                data.Email = gv.Email;
                data.MaTD = gv.MaTD;
                data.MaCV = gv.MaCV;
                data.UpdatedDate = gv.UpdatedDate;
                data.UpdatedBy = gv.UpdatedBy;
               
                db.SaveChanges();
                return gv;
            }
            catch (Exception e)
            {

                throw new Exception("Lỗi :"+e.Message);
            }

        }
        public void Delete(int maGv, int UserID)
        {
            try
            {
                var data = db.tbl_GiaoVien.FirstOrDefault(x => x.MaGV == maGv);
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
