using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class frmEula : Cabinink.Writer.UI.VsSkinFormBase
   {
      public frmEula()
      {
         InitializeComponent();
      }

      private void frmEula_Load(object sender, EventArgs e)
      {
         rtbEula.Text = Cores.FileOperation.ReadFile("ciwriter_eula.textdocument-ci", true, Encoding.GetEncoding("GB2312"));
      }
   }
}
