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

namespace AdoNetDemo2.Forms
{
    public partial class FormCategories : DevExpress.XtraBars.Ribbon.RibbonForm, IDataForm
    {
        public FormCategories()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            kategorilerTableAdapter.Fill(dataSetMain.Kategoriler);
            ürünlerTableAdapter.Fill(dataSetMain.Ürünler);
        }

        private void FormCategories_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            tableAdapterManager.UpdateAll(dataSetMain);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Kayıt silinsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.Yes:
                    bindingSourceKategoriler.RemoveCurrent();
                    break;
            }
        }

        private void FormCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataSetMain.HasChanges())
            {
                var result = MessageBox.Show("Değişiklikler kaydedilsin mi?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                switch (result)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                    case DialogResult.Yes:
                        tableAdapterManager.UpdateAll(dataSetMain);
                        break;
                }
            }
        }
    }
}