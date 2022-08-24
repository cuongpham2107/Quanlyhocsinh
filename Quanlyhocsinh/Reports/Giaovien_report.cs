using BussinessLayer.DataObject;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Quanlyhocsinh.Reports
{
    public partial class Giaovien_report : DevExpress.XtraReports.UI.XtraReport
    {
        public Giaovien_report()
        {
            InitializeComponent();
        }
        public void InitData(List<GiaoVienDTO> data)
        {
            objectDataSource1.DataSource = data;
        }
        
    }
}
