using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class VsSkinInputBox : Cabinink.Writer.UI.VsSkinFormBase
   {
      internal DialogResult res = DialogResult.Cancel;
      public VsSkinInputBox()
      {
         InitializeComponent();
      }
      private void txtData_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter) Close();
         else if (e.KeyCode == Keys.Escape)
         {
            txtData.Text = string.Empty;
            Close();
         }
      }
      public static string Display()
      {
         VsSkinInputBox inputbox = new VsSkinInputBox();
         return Display(inputbox.Text, inputbox.lblTipString.Text);
      }
      public static string Display(string _title)
      {
         VsSkinInputBox inputbox = new VsSkinInputBox();
         return Display(_title, inputbox.lblTipString.Text);
      }
      public static string Display(string _title, string _tips)
      {
         VsSkinInputBox inputbox = new VsSkinInputBox();
         inputbox.Text = _title;
         if (_tips.Trim() != string.Empty) inputbox.lblTipString.Text = _tips;
         inputbox.ShowDialog();
         if (inputbox.res == DialogResult.OK) return inputbox.txtData.Text; else return string.Empty;
      }

      private void btnOkey_Click(object sender, EventArgs e)
      {
         res = DialogResult.OK;
         Close();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         res = DialogResult.Cancel;
         Close();
      }
   }
}
