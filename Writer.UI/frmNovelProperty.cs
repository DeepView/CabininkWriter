using Cabinink.Writer.Cores;
using Cabinink.Writer.Middle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using app = Cabinink.Program;
namespace Cabinink.Writer.UI
{
   public partial class frmNovelProperty : Cabinink.Writer.UI.VsSkinFormBase
   {
      private frmMainInterface owner;
      private Project project;
      public frmNovelProperty()
      {
         InitializeComponent();
      }
      public frmNovelProperty(int _tabindex)
      {
         InitializeComponent();
         switch (_tabindex)
         {
            case 0:
               tbcTabControl.SelectTab(0);
               break;
            case 1:
               tbcTabControl.SelectTab(1);
               break;
            case 2:
               tbcTabControl.SelectTab(2);
               break;
            default:
               tbcTabControl.SelectTab(0);
               break;
         }
      }
      public void Display(frmMainInterface _owner)
      {
         owner = _owner;
         project = owner.GetProjectAccessSelectedNode();
         Show();
      }
      private void frmNovelProperty_Load(object sender, EventArgs e)
      {
         LoadNovelInformation();
         LoadRoleCollection();
         LoadCompendium();
         //MessageBox.Show("SelectedNodeIndex=" + owner.trvNovelTree.SelectedNode.Index);
      }
      public void LoadNovelInformation()
      {
         txtProjectName.Text = project.Name;
         txtNovelName.Text = project.CurrentNovel.Information.NovelName;
         txtWriter.Text = project.CurrentNovel.Information.WriterName;
         txtCategory.Text = app.GetEnumDescription(project.CurrentNovel.Information.Category);
         txtCreateDate.Text = project.CurrentNovel.Information.CreationTime.ToLongDateString();
         txtKeywords.Text = project.CurrentNovel.Information.GetKeywordsCsvString();
         txtInfo.Text = project.CurrentNovel.Information.Remarks;
         txtSavedPath.Text = project.Database.SourceUri;
      }
      public void LoadRoleCollection()
      {
         RoleManagement roles = project.Roles;
         ListViewItem item;
         string name, camp, occup, appear, character, pet, other, appell, sex, initage, category;
         string[] itemstr;
         lsvRoles.Items.Clear();
         for (int i = 0; i < roles.Count; i++)
         {
            name = roles[i].Name.ToString(true);
            camp = roles[i].Camp;
            occup = roles[i].Occupation;
            appear = roles[i].Appearance;
            character = roles[i].Character;
            pet = roles[i].PetPhrase;
            other = roles[i].OtherInformation;
            appell = roles[i].GetCsvFormatString();
            sex = app.GetEnumDescription(roles[i].Sex);
            initage = roles[i].InitializeAge.ToString();
            category = app.GetEnumDescription(roles[i].Category);
            itemstr = new string[] { name, appell, sex, initage, category, camp, occup, appear, character, pet, other };
            item = new ListViewItem(itemstr);
            lsvRoles.Items.Add(item);
         }
      }
      public void LoadCompendium()
      {
         Compendium compendium = project.Compendium;
         ListViewItem item;
         string date, category, roles, place, story;
         string[] itemstr;
         lsvCompendium.Items.Clear();
         for (int i = 0; i < compendium.Count; i++)
         {
            date = compendium[i].HappenedDate.ToString(EDateDisplayCategory.DashedSegmentation);
            category = app.GetEnumDescription(compendium[i].StoryCellCategory);
            roles = compendium[i].GetRolesCsvFormatString();
            place = compendium[i].Place;
            story = compendium[i].Story;
            itemstr = new string[] { date, category, roles, place, story };
            item = new ListViewItem(itemstr);
            lsvCompendium.Items.Add(item);
         }
      }

      private void 创建新角色ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmCreateRole crtrole = new frmCreateRole(owner.GetProjectAccessSelectedNode());
         crtrole.ShowDialog(this);
         LoadRoleCollection();
      }

      private void 查看详情ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ListViewItem selected = lsvRoles.SelectedItems[0];
         string name = "姓名 = " + selected.SubItems[0].Text + "\n";
         string appell = "别称/昵称 = " + selected.SubItems[1].Text + "\n";
         string sex = "性别 = " + selected.SubItems[2].Text + "\n";
         string initage = "初始年龄 = " + selected.SubItems[3].Text + "\n";
         string category = "角色定位 = " + selected.SubItems[4].Text + "\n";
         string camp = "阵营/势力/国家 = " + selected.SubItems[5].Text + "\n";
         string occup = "职业 = " + selected.SubItems[6].Text + "\n";
         string appear = "外貌描写 = " + selected.SubItems[7].Text + "\n";
         string character = "性格特征 = " + selected.SubItems[8].Text + "\n";
         string pet = "口头禅/习惯用语 = " + selected.SubItems[9].Text + "\n";
         string other = "其他信息 = " + selected.SubItems[10].Text;
         string details_str = name + appell + sex + initage + category + camp + occup + appear + character + pet + other;
         frmRoleDetails details = new frmRoleDetails(details_str);
         details.Show(this);
      }

      private void 移除角色ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         project.Roles.RemoveRole(lsvRoles.SelectedIndices[0]);
         LoadRoleCollection();
      }
      private void 从内存中恢复已移除的角色ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         while (project.Roles.Removed.Count > 0)
         {
            project.Roles.Recover(0);
         }
         LoadRoleCollection();
      }

      private void 编辑角色信息ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         int selected = lsvRoles.SelectedIndices[0];
         frmCreateRole crtrole = new frmCreateRole(owner.GetProjectAccessSelectedNode(), false, selected);
         crtrole.ShowDialog(this);
         LoadRoleCollection();
      }

      private void 新建故事线ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmCreateCompendium crtcmpdm = new frmCreateCompendium(owner.GetProjectAccessSelectedNode());
         crtcmpdm.ShowDialog();
         LoadCompendium();
      }

      private void 删除故事线ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Action ok = delegate
         {
            int selected = lsvCompendium.SelectedIndices[0];
            lsvCompendium.Items.RemoveAt(selected);
            project.Compendium.RemoveStoryCell(selected);
            project.Compendium.SaveToDatabase(project.Database.SourceUri, true);
            LoadCompendium();
         };
         VsSkinMessageBoxOkCancel ques = new VsSkinMessageBoxOkCancel("询问", "故事线删除之后不可被恢复，您确定要这样做吗？", EMessageLevel.Question, ok, DoNothing);
         ques.Display(this);
      }

      private void 修改故事线ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmCreateCompendium crtcmpd = new frmCreateCompendium(project, false, lsvCompendium.SelectedIndices[0]);
         crtcmpd.ShowDialog(this);
         LoadCompendium();
      }

      private void 查看详细ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ListViewItem selected = lsvCompendium.SelectedItems[0];
         string date = "发生日期 = " + selected.SubItems[0].Text + "\n";
         string category = "故事线分类 = " + selected.SubItems[1].Text + "\n";
         string roles = "参与角色 = " + selected.SubItems[2].Text + "\n";
         string place = "故事发生地点 = " + selected.SubItems[3].Text + "\n";
         string story = "故事简要 = " + selected.SubItems[4].Text + "\n";
         string details = date + category + roles + place + story;
         frmRoleDetails view = new frmRoleDetails(details, false);
         view.Show(this);
      }
   }
}
