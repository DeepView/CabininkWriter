using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class VsSkinMessageBoxOk : Cabinink.Writer.UI.VsSkinMessageBoxBase
   {
      public VsSkinMessageBoxOk()
      {
         InitializeComponent();
      }
      public VsSkinMessageBoxOk(string _caption, string _tipstr, EMessageLevel _level) : base(_caption, _tipstr, _level)
      {
         InitializeComponent();
      }

      private void metroButton1_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
