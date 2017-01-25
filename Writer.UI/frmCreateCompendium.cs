using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using Cabinink.Writer.Middle;

namespace Cabinink.Writer.UI
{
   public partial class frmCreateCompendium : Cabinink.Writer.UI.VsSkinFormBase
   {
      private bool iscreate;
      private Project project;
      private int beupdatedindex;
      public frmCreateCompendium()
      {
         InitializeComponent();
      }
      public frmCreateCompendium(Project _project)
      {
         InitializeComponent();
         project = _project;
         iscreate = true;
         beupdatedindex = -1;
      }
      public frmCreateCompendium(Project _project, bool _iscreate, int _beupdatedindex)
      {
         InitializeComponent();
         project = _project;
         iscreate = _iscreate;
         beupdatedindex = _beupdatedindex;
      }
      public Project ActivedProject
      {
         get { return project; }
      }
      public bool IsCreate
      {
         get { return iscreate; }
      }
      public int BeUpdatedIndex
      {
         get { return beupdatedindex; }
      }
      private void frmCreateCompendium_Load(object sender, EventArgs e)
      {
         cmbCategory.Text = @"故事背景";
         if (!IsCreate)
         {
            StoryCell cell = ActivedProject.Compendium[BeUpdatedIndex];
            Text = @"修改故事线";
            btnOk.Text = @"修改(&U)";
            hltYear.Context = cell.HappenedDate.Year.ToString();
            hltMonth.Context = cell.HappenedDate.Month.ToString();
            hltDay.Context = cell.HappenedDate.Day.ToString();
            cmbCategory.Text = Program.GetEnumDescription(cell.StoryCellCategory);
            for (int i = 0; i < cell.Roles.Count; i++) lstRoles.Items.Add(cell.Roles[i]);
            txtPlace.Text = cell.Place;
            txtStory.Text = cell.Story;
         }
      }

      private void btnAdd_Click(object sender, EventArgs e)
      {
         frmAddRoleToStoryCell addrole = new frmAddRoleToStoryCell(ActivedProject);
         addrole.DisplayDialog(this);
      }

      private void btnRemove_Click(object sender, EventArgs e)
      {
         lstRoles.Items.RemoveAt(lstRoles.SelectedIndex);
      }

      private void btnClearAll_Click(object sender, EventArgs e)
      {
         lstRoles.Items.Clear();
      }

      private void metroButton1_Click(object sender, EventArgs e) //OK button's click event.
      {
         StoryCell cell = new StoryCell();
         cell.HappenedDate = new BigDate(Convert.ToInt32(hltYear.Context), Convert.ToByte(hltMonth.Context), Convert.ToByte(hltDay.Context));
         switch (cmbCategory.Text)
         {
            case "故事背景":
               cell.StoryCellCategory = EStoryCellCategory.Background;
               break;
            case "正文":
               cell.StoryCellCategory = EStoryCellCategory.Ceremonial;
               break;
            case "外传":
               cell.StoryCellCategory = EStoryCellCategory.Outbound;
               break;
         }
         for (int i = 0; i < lstRoles.Items.Count; i++) cell.Roles.Add((Role)lstRoles.Items[i]);
         cell.Place = txtPlace.Text;
         cell.Story = txtStory.Text;
         if (IsCreate) ActivedProject.Compendium.AddStoryCell(cell);
         else ActivedProject.Compendium[BeUpdatedIndex] = cell;
         ActivedProject.Compendium.SaveToDatabase(ActivedProject.Database.SourceUri, true);
         Close();
      }
   }
}
