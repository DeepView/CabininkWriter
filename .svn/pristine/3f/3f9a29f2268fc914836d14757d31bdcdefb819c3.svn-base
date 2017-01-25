using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;

namespace Cabinink.Writer.UI
{
   public partial class frmBuildName : Cabinink.Writer.UI.VsSkinFormBase
   {
      private frmCreateRole owner;
      public frmBuildName()
      {
         InitializeComponent();
      }

      private void btnBuild_Click(object sender, EventArgs e)
      {
         NamingSystem ns = new NamingSystem();
         List<SCompleteName> names = new List<SCompleteName>();
         bool style = true;
         if (rdbCnName.Checked) ns.NameType = ENameType.ChineseName;
         if (rdbEaName.Checked)
         {
            ns.NameType = ENameType.EuramericanName;
            ns.SetDisplayStyle(ref style);
            owner.NameCategory = 1;
         }
         if (rdbJpName.Checked) ns.NameType = ENameType.JapaneseName;
         if (rdbRuName.Checked)
         {
            ns.NameType = ENameType.RussianName;
            ns.SetDisplayStyle(ref style);
            owner.NameCategory = 1;
         }
         ns.InitializeBuilder();
         names = ns.RandomBuildNames(31);
         lstNames.Items.Clear();
         for (int i = 0; i < names.Count; i++) lstNames.Items.Add(names[i].ToString(style));
         lstNames.SetSelected(0, true);
      }

      private void btnOkey_Click(object sender, EventArgs e)
      {
         owner.BuildedName = lstNames.SelectedItem.ToString();
         btnCancel_Click(sender, e);
      }
      public DialogResult DisplayDialog(frmCreateRole _form)
      {
         owner = _form;
         return ShowDialog(_form);
      }
      private void btnCancel_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
