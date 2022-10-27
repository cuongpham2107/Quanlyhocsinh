using BussinessLayer;
using DataAccessLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlyhocsinh
{
    public partial class formLopHoc : DevExpress.XtraEditors.XtraForm
    {
        public formLopHoc()
        {
            InitializeComponent();
        }
        bool them;
        LopHoc lopHoc;
        Truong truong;
        int id = 0;

        private void formLopHoc_Load(object sender, EventArgs e)
        {
            ShowHide(true);
            lopHoc = new LopHoc();
            truong = new Truong();
            LoadData();
            LoadTruong();
        }
        void LoadData()
        {
            lopHoc = new LopHoc();
            gcDanhSach.DataSource = lopHoc.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void LoadTruong()
        {
            ccbTruong.DataSource = truong.getList();
            ccbTruong.DisplayMember = "TenTruong";
            ccbTruong.ValueMember = "MaTruong";
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
            txtTenLop.Enabled = !kt;
            ccbTruong.Enabled = !kt;
            rtbGhiChu.Enabled = !kt;
            txtSapXep.Enabled = !kt;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            them = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            them = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lopHoc.Delete(id, Common.UserStatic.UID);
            }
            LoadData();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            LoadData();
            ShowHide(true);
        }
        void SaveData()
        {
            if (them)
            {
                tbl_Lop l = new tbl_Lop();
                l.TenLop = txtTenLop.Text;
                l.SapXep = txtSapXep.Text;
                l.GhiChu = rtbGhiChu.Text;
                
                if(ccbTruong.SelectedValue != null)
                {
                    l.MaTruong = int.Parse(ccbTruong.SelectedValue.ToString());
                }
                l.CrearedBy = Common.UserStatic.UID;
                l.CreatedDate = DateTime.Now;
                lopHoc.Add(l);
            }
            else
            {
                tbl_Lop l = lopHoc.getItem(id);
                l.TenLop = txtTenLop.Text;
                l.SapXep = txtSapXep.Text;
                l.GhiChu = rtbGhiChu.Text;
                l.MaTruong = int.Parse(ccbTruong.SelectedValue.ToString());
                l.UpdatedBy = Common.UserStatic.UID;
                l.UpdatedDate = DateTime.Now;
                lopHoc.Update(l);
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
            them = false;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Giaovien_report report = new Giaovien_report();
            //DocumentViewer documentViewer = new DocumentViewer();
            //var listGiaoVien = giaoVien.getList();
            //report.InitData(listGiaoVien);
            //documentViewer.DocumentSource = report;
            //report.ShowPreviewDialog();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaLop").ToString());
                var l = lopHoc.getItem(id);
                txtTenLop.Text = l.TenLop;
                txtSapXep.Text = l.SapXep;
                ccbTruong.SelectedItem = l.MaTruong;
                rtbGhiChu.Text = l.GhiChu;
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DeletedBy" && e.CellValue != null)
            {
                Image img = Properties.Resources.Cancel_16x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
    }
}