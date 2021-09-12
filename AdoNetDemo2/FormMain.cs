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

namespace AdoNetDemo2
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormManager.OpenForm<Forms.FormCategories>();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormManager.OpenForm<Forms.FormProducts>();

        }
    }
}