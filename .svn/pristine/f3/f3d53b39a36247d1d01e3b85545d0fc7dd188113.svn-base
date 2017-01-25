using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MetroFramework.Forms;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using Cabinink.Writer.Middle;
using app = Cabinink.Program;

namespace Cabinink.Writer.UI
{
   public partial class frmCreateRole : VsSkinFormBase
   {
      public string BuildedName;
      public int NameCategory = 0;

      private Project proj;
      private bool iscreate;
      private int beupdatedindex;
      public frmCreateRole()
      {
         InitializeComponent();
      }
      public frmCreateRole(Project _project)
      {
         InitializeComponent();
         proj = _project;
         proj.InitializeProject();
         iscreate = true;
         beupdatedindex = -1;
      }
      public frmCreateRole(Project _project, bool _iscreate, int _beupdatedindex)
      {
         InitializeComponent();
         proj = _project;
         proj.InitializeProject();
         iscreate = _iscreate;
         beupdatedindex = _beupdatedindex;
      }
      public Project ActivedProject
      {
         get { return proj; }
      }
      public bool IsCreate
      {
         get { return iscreate; }
      }
      public int BeUpdatedIndex
      {
         get { return beupdatedindex; }
      }
      private void btnRandomBuildName_Click(object sender, EventArgs e)
      {
         frmBuildName build = new frmBuildName();
         build.DisplayDialog(this);
         txtName.Text = BuildedName;
      }

      private void btnAdd_Click(object sender, EventArgs e)
      {
         string appell = Interaction.InputBox("请在下面的文本框输入您需要添加的昵称！", "添加昵称", txtName.Text);
         //string appell = VsSkinInputBox.Display("添加昵称");
         if (appell != string.Empty) lstAppellation.Items.Add(appell);
      }

      private void btnRemove_Click(object sender, EventArgs e)
      {
         lstAppellation.Items.RemoveAt(lstAppellation.SelectedIndex);
      }

      private void btnRename_Click(object sender, EventArgs e)
      {
         int selected = lstAppellation.SelectedIndex;
         string appell = Interaction.InputBox("请在下面的文本框输入新的昵称来替换原有选中的昵称！", "重命名昵称", txtName.Text);
         if (appell != string.Empty) lstAppellation.Items.Add(appell);
         lstAppellation.Items.RemoveAt(selected);
      }

      private void btnClear_Click(object sender, EventArgs e)
      {
         lstAppellation.Items.Clear();
      }

      private void frmCreateRole_Load(object sender, EventArgs e)
      {
         cmbCategory.Text = @"路人（不需要太多的描述）";
         if (!IsCreate)
         {
            Text = "修改角色";
            btnCreate.Text = "修改(&U)";
            txtName.Text = ActivedProject.Roles[BeUpdatedIndex].Name.ToString(true);
            for (int i = 0; i < ActivedProject.Roles[BeUpdatedIndex].Appellation.Count; i++)
            {
               lstAppellation.Items.Add(ActivedProject.Roles[BeUpdatedIndex].Appellation[i]);
            }
            txtOccupation.Text = ActivedProject.Roles[BeUpdatedIndex].Occupation;
            txtPetPhrase.Text = ActivedProject.Roles[BeUpdatedIndex].PetPhrase;
            txtCharacter.Text = ActivedProject.Roles[BeUpdatedIndex].Character;
            switch (ActivedProject.Roles[BeUpdatedIndex].Sex)
            {
               case EPeopleSex.Male:
                  rdbSexM.Checked = true;
                  rdbSexN.Checked = false;
                  rdbSexW.Checked = false;
                  break;
               case EPeopleSex.Famale:
                  rdbSexM.Checked = false;
                  rdbSexN.Checked = false;
                  rdbSexW.Checked = true;
                  break;
               case EPeopleSex.Asexual:
                  rdbSexM.Checked = false;
                  rdbSexN.Checked = true;
                  rdbSexW.Checked = false;
                  break;
            }
            txtInitializeAge.Text = ActivedProject.Roles[BeUpdatedIndex].InitializeAge.ToString();
            switch (ActivedProject.Roles[BeUpdatedIndex].Category)
            {
               case ERoleCategory.Protagonist:
                  cmbCategory.Text = @"主角（包含男女主角等）";
                  break;
               case ERoleCategory.Supporting:
                  cmbCategory.Text = @"配角（包含男女配角等）";
                  break;
               case ERoleCategory.Passerby:
                  cmbCategory.Text = @"路人（不需要太多的描述）";
                  break;
               case ERoleCategory.Villain:
                  cmbCategory.Text = @"反派（与主角或者配角存在瓜葛）";
                  break;
            }
            txtCamp.Text = ActivedProject.Roles[BeUpdatedIndex].Camp;
            txtAppearance.Text = ActivedProject.Roles[BeUpdatedIndex].Appearance;
            txtOtherInformation.Text = ActivedProject.Roles[BeUpdatedIndex].OtherInformation;
         }
      }

      private void btnCreate_Click(object sender, EventArgs e)
      {
         string[] name_s = txtName.Text.Split(' ');
         SCompleteName name;
         if (NameCategory == 0) name = new SCompleteName(name_s[0], name_s[1]);
         else name = new SCompleteName(name_s[1], name_s[0]);
         Role role = new Role(name);
         for (int i = 0; i < lstAppellation.Items.Count; i++) role.AddAppellation(lstAppellation.Items[i].ToString());
         if (rdbSexM.Checked) role.Sex = EPeopleSex.Male;
         if (rdbSexW.Checked) role.Sex = EPeopleSex.Famale;
         if (rdbSexN.Checked) role.Sex = EPeopleSex.Asexual;
         role.InitializeAge = Convert.ToUInt32(txtInitializeAge.Text);
         role.Occupation = txtOccupation.Text;
         role.Camp = txtCamp.Text;
         role.Character = txtCharacter.Text;
         role.Appearance = txtAppearance.Text;
         role.OtherInformation = txtOtherInformation.Text;
         role.PetPhrase = txtPetPhrase.Text;
         switch (cmbCategory.Text)
         {
            case "主角（包含男女主角等）":
               role.Category = ERoleCategory.Protagonist;
               break;
            case "配角（包含男女配角等）":
               role.Category = ERoleCategory.Supporting;
               break;
            case "路人（不需要太多的描述）":
               role.Category = ERoleCategory.Passerby;
               break;
            case "反派（与主角或者配角存在瓜葛）":
               role.Category = ERoleCategory.Villain;
               break;
         }
         if (IsCreate)
         {
            ActivedProject.Roles.AddRole(role);//添加角色至Project实例的Roles属性中
            VsSkinMessageBoxOk ques = new VsSkinMessageBoxOk("创建角色成功", "已成功创建当前设定的角色！", EMessageLevel.Information);
            ques.Display(this);
         }
         else
         {
            ActivedProject.Roles[BeUpdatedIndex] = role;
            VsSkinMessageBoxOk ques = new VsSkinMessageBoxOk("修改角色成功", "已成功修改指定的角色！", EMessageLevel.Information);
            ques.Display(this);
         }
         ActivedProject.Roles.SaveToDatabase(ActivedProject.Database.SourceUri, true);
         Close();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
