using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Quanlyhocsinh
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        OverlayWindowOptions options = new OverlayWindowOptions(
            backColor: Color.Black,
            opacity: 0.5,
            fadeIn: false,
            fadeOut:false
        );
        IOverlaySplashScreenHandle ShowProgressPanel(Control control, OverlayWindowOptions option)
        {
            return SplashScreenManager.ShowOverlayForm(control, option);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Common.handle = ShowProgressPanel(this, options);
            formLogin form = new formLogin();
            form.ShowDialog();
        }
        void OpenForm(Type typeForm)
        {
            foreach (var frm in MdiChildren)
            {
                if(frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form form = (Form)Activator.CreateInstance(typeForm);
            form.MdiParent = this;
            form.Show();
        }
        private void mnMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(formMonHoc));
        }

        private void mnNamHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(formNamHoc));
        }

        private void mnGiaoVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(formGiaoVien));

        }

        private void mnChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(formChucVu));
        }

        private void mnTrinhDo_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(formTrinhDo));
        }

        private void mnDanToc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(formDanToc));
        }

        private void mnHocSinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(formHocsinh));
        }

        private void mnLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(formLopHoc));
        }
    }
}