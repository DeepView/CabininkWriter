using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using Cabinink.Writer.Middle;

namespace Cabinink.Writer.UI
{
   public partial class frmAddRoleToStoryCell : Cabinink.Writer.UI.VsSkinFormBase
   {
      private Project project;
      private frmCreateCompendium owner;
      public frmAddRoleToStoryCell()
      {
         InitializeComponent();
      }
      public frmAddRoleToStoryCell(Project _project)
      {
         InitializeComponent();
         project = _project;
      }
      public Project ActivedProject
      {
         get { return project; }
      }
      public DialogResult DisplayDialog(frmCreateCompendium _owner)
      {
         owner = _owner;
         return ShowDialog(_owner);
      }

      private void frmAddRoleToStoryCell_Load(object sender, EventArgs e)
      {
         for (int i = 0; i < ActivedProject.Roles.Count; i++)
         {
            lstRoles.Items.Add(ActivedProject.Roles[i]);
         }
         for (int i = 0; i < owner.lstRoles.Items.Count; i++)
         {
            if (owner.lstRoles.Items[i] == lstRoles.Items[i]) lstRoles.Items.RemoveAt(i);
         }
      }

      private void btnAdd_Click(object sender, EventArgs e)
      {
         owner.lstRoles.Items.Add(lstRoles.SelectedItem);
         Close();
      }

      private void metroButton2_Click(object sender, EventArgs e)
      {
         lstRoles.Items.Clear();
         frmAddRoleToStoryCell_Load(sender, e);
      }

      private void metroButton3_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
