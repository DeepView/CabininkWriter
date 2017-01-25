using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class frmEditorSetting : Cabinink.Writer.UI.VsSkinFormBase
   {
      private frmMainInterface owner;
      public frmEditorSetting()
      {
         InitializeComponent();
      }
      public DialogResult DisplayDialog(frmMainInterface _owner)
      {
         owner = _owner;
         return ShowDialog();
      }
      private void frmEditorSetting_Load(object sender, EventArgs e)
      {
         cmbFontSize.Text = Convert.ToString(owner.rtbBody.Font.Size);
      }
   }
}
