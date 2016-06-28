using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabinink.Writer.Middle;

namespace Cabinink.Writer.UI
{
   public partial class frmWelcome : Form
   {
      public frmWelcome()
      {
         InitializeComponent();
      }
      public void KillMe(object sender, EventArgs e)
      {
         Close();
      }
      /// <summary>
      /// Load and run
      /// </summary>
      /// <param name="form"></param>
      public static void LoadAndRun(Form form)
      {
         form.HandleCreated += delegate
         {
            new Thread(new ThreadStart(delegate
            {
               frmWelcome splash = new frmWelcome();
               form.Shown += delegate
               {
                  splash.Invoke(new EventHandler(splash.KillMe));
                  splash.Dispose();
               };
               Application.Run(splash);
            })).Start();
         };
         Application.Run(form);
      }

      private void frmWelcome_Load(object sender, EventArgs e)
      {
         lblCopyright.Text = AssemblyInformation.Copyright;
         lblVersion.Text = @"Version " + AssemblyInformation.ProductionVersion + Program.AppBuildingProcessFlag;
         lblVersion.Left = Width - lblVersion.Width - 9;
         lblCopyright.Left = Width - lblCopyright.Width - 9;
      }

      private void metroLabel1_Click(object sender, EventArgs e)
      {
      }
   }
}
