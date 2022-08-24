using BussinessLayer;
using DataAccessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Preview;
using Quanlyhocsinh.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace Quanlyhocsinh
{
    public partial class formGiaoVien : DevExpress.XtraEditors.XtraForm
    {
        public formGiaoVien()
        {
            InitializeComponent();
        }
        bool them;
        GiaoVien giaoVien;
        TrinhDo _trinhDo;
        ChucVu _chucVu;
        int id = 0;
        int gioitinh = 0;
        private void formGiaoVien_Load(object sender, EventArgs e)
        {
            ShowHide(true);
            giaoVien = new GiaoVien();
            _trinhDo = new TrinhDo();
            _chucVu = new ChucVu();
            LoadData();
            LoadChucVu();
            LoadTrinhDo();
        }
        void LoadData()
        {
            giaoVien = new GiaoVien();
            gcDanhSach.DataSource = giaoVien.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void LoadTrinhDo()
        {
            cbbTrinhDo.DataSource = _trinhDo.getList();
            cbbTrinhDo.DisplayMember = "TenTD";
            cbbTrinhDo.ValueMember = "MaTD";
        }
        void LoadChucVu()
        {
            cbbChucVu.DataSource = _chucVu.getList();
            cbbChucVu.DisplayMember = "TenCV";
            cbbChucVu.ValueMember = "MaCV";
        }
        void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            txtHoTen.Enabled = !kt;
            txtDiaChi.Enabled = !kt;
            txtDienThoai.Enabled = !kt;
            txtEmail.Enabled = !kt;
            cbbTrinhDo.Enabled = !kt;
            cbbChucVu.Enabled = !kt;
            btnChonHinh.Enabled = !kt;
            cbGioiTinh.Enabled = !kt;
            dtNgaySinh.Enabled = !kt;
        }

        #region Hàm thêm hình ảnh
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
        public Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0 , imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }


        #endregion
        void SaveData()
        {
            if (them)
            {
                tbl_GiaoVien gv = new tbl_GiaoVien();
                gv.HoTen = txtHoTen.Text;
                int index = gv.HoTen.LastIndexOf(" ");
                gv.Ten = gv.HoTen.Substring(index + 1);
                gv.GioiTinh = gioitinh;
                gv.NgaySinh = dtNgaySinh.Value;
                gv.Email = txtEmail.Text;
                gv.DienThoai = txtDienThoai.Text;
                gv.DiaChi = txtDiaChi.Text;
                gv.MaCV = int.Parse(cbbChucVu.SelectedValue.ToString());
                gv.MaTD = int.Parse(cbbTrinhDo.SelectedValue.ToString());
                gv.HinhAnh = ImageToBase64(picHinhAnh.Image,picHinhAnh.Image.RawFormat);
                gv.CrearedBy = Common.UserStatic.UID;
                gv.CreatedDate = DateTime.Now;
                giaoVien.Add(gv);
            }
            else
            {
                tbl_GiaoVien gv = giaoVien.getItem(id);
                gv.HoTen = txtHoTen.Text;
                int index = gv.HoTen.LastIndexOf(" ");
                gv.Ten = gv.HoTen.Substring(index + 1);
                gv.GioiTinh = gioitinh;
                gv.NgaySinh = dtNgaySinh.Value;
                gv.Email = txtEmail.Text;
                gv.DienThoai = txtDienThoai.Text;
                gv.DiaChi = txtDiaChi.Text;
                gv.MaCV = int.Parse(cbbChucVu.SelectedValue.ToString());
                gv.MaTD = int.Parse(cbbTrinhDo.SelectedValue.ToString());
                gv.HinhAnh = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);
                gv.UpdatedBy = Common.UserStatic.UID;
                gv.UpdatedDate = DateTime.Now;
                giaoVien.Update(gv);
            }
        }
        
        private void btnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            them = true;
            
        }
        private void btnSua_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            them = false;
            
        }
        private void btnXoa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                giaoVien.Delete(id, Common.UserStatic.UID);
            }
            LoadData();
        }

        private void btnLuu_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            LoadData();
            ShowHide(true);
        }
       
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
            them = false;
        }


        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Giaovien_report report = new Giaovien_report();
            DocumentViewer documentViewer = new DocumentViewer();
            var listGiaoVien = giaoVien.getList();
            report.InitData(listGiaoVien);
            documentViewer.DocumentSource = report;
            report.ShowPreviewDialog();

        }

        
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cbGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGioiTinh.Checked)
            {
                gioitinh = 1;
            }
            else
            {
                gioitinh = 0;
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if(gvDanhSach.RowCount > 0)
            {
                id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaGV").ToString());
                var gv = giaoVien.getItem(id);
                txtHoTen.Text = gv.HoTen;
                txtDienThoai.Text = gv.DienThoai;
                txtEmail.Text = gv.Email;
                txtDiaChi.Text = gv.DiaChi;
                dtNgaySinh.Value = gv.NgaySinh.Value;
                cbbChucVu.SelectedItem = gv.MaCV;
                cbbTrinhDo.SelectedItem = gv.MaTD;
                if(gv.GioiTinh == 1)
                {
                    cbGioiTinh.Checked = true;
                }
                else
                {
                    cbGioiTinh.Checked = false;
                }
                
                picHinhAnh.Image = Base64ToImage(gv.HinhAnh);

            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name =="DeletedBy" && e.CellValue != null)
            {
                Image img = Properties.Resources.Cancel_16x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
            if(e.Column.Name == "GioiTinh")
            {
                if (int.Parse(e.CellValue.ToString()) == 0)
                {
                    e.DisplayText = "Nữ";
                }
                else
                {
                    e.DisplayText = "Nam";
                }
            }
            
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png, .jpg)|*.png;*.jpg";
            openFile.Title = "Chọn Hình Ảnh";
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = Image.FromFile(openFile.FileName);
                picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        
    }
}