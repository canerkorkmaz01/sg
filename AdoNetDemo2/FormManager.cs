using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo2
{
    
    internal static class FormManager
    {
        public static FormMain MainForm { get; set; } = new FormMain();

        //bu ülkede adonet bilen yok!!!!
        //bd.net

        public static void OpenForm<T>() where T : Form
        {

            var form = MainForm.MdiChildren.SingleOrDefault(p => p is T) ?? Activator.CreateInstance<T>();
            MainForm.splashScreenManager.ShowWaitForm();
            MainForm.Invoke((Action)(() =>
            {
                form.Show();
                form.MdiParent = MainForm;
                form.Focus();
                if (form is IDataForm)
                    ((IDataForm)form).LoadData();
                MainForm.splashScreenManager.CloseWaitForm();
            }));
           
        }
    }
}
