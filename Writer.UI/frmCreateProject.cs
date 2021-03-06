﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using Cabinink.Writer.Middle;
using System.Linq;
using app = Cabinink.Program;

namespace Cabinink.Writer.UI
{
   public partial class frmCreateProject : Cabinink.Writer.UI.VsSkinFormBase
   {
      //private Project project;
      private frmMainInterface owner;
      public frmCreateProject(frmMainInterface _owner)
      {
         InitializeComponent();
         app.Projects = new List<Project>();
         cmbCategory.Text = "其他";
         txtCreateDate.Text = DateTime.Today.ToShortDateString();
         owner = _owner;
      }
      private void ShowProjectNameErrorMessageBox()
      {
         string tipstr = "项目名称字符串之中不允许出现除下划线（_）、阿拉伯数字和英文字母之外的字符，并且不能以阿拉伯数字开头！";
         VsSkinMessageBoxOk warning = new VsSkinMessageBoxOk("警告", tipstr, EMessageLevel.Warning);
         warning.Display(this);
      }

      private void frmCreateProject_Load(object sender, EventArgs e)
      {
         txtNovelName.ImeMode = ImeMode.KatakanaHalf;
         txtWriter.ImeMode = ImeMode.KatakanaHalf;
         txtSavedPath.ImeMode = ImeMode.KatakanaHalf;
         txtKeywords.ImeMode = ImeMode.KatakanaHalf;
         txtInfo.ImeMode = ImeMode.KatakanaHalf;
         cmbChapterNumber.Text = "第128章";
         cmbSubsectionNumber.Text = "第三十二卷";
      }

      private void txtProjectName_TextChanged(object sender, EventArgs e)
      {
         Project proj = new Project();
         if (proj.IsInconformitySpecification(txtProjectName.Text) == false && txtProjectName.Text != string.Empty)
         {
            ShowProjectNameErrorMessageBox();
         }
         lblProjectName.Text = @"\" + txtProjectName.Text + @"\" + txtProjectName.Text + ".db";
      }

      private void btnCreate_Click(object sender, EventArgs e)
      {
         SNovelInformation info = new SNovelInformation();
         Action crtproj = delegate
         {
            info.NovelName = txtNovelName.Text;
            info.WriterName = txtWriter.Text;
            info.Remarks = txtInfo.Text;
            switch (cmbCategory.Text)
            {
               case "玄幻":
                  info.Category = ENovelCategory.Unreal;
                  break;
               case "都市":
                  info.Category = ENovelCategory.Metropolis;
                  break;
               case "修真":
                  info.Category = ENovelCategory.Coatard;
                  break;
               case "武侠":
                  info.Category = ENovelCategory.Swordsmen;
                  break;
               case "军事":
                  info.Category = ENovelCategory.Military;
                  break;
               case "历史":
                  info.Category = ENovelCategory.History;
                  break;
               case "网游":
                  info.Category = ENovelCategory.OnlineGames;
                  break;
               case "科幻":
                  info.Category = ENovelCategory.ScienceFiction;
                  break;
               case "竞技":
                  info.Category = ENovelCategory.Athletics;
                  break;
               case "体育":
                  info.Category = ENovelCategory.PhysicalEducation;
                  break;
               case "灵异":
                  info.Category = ENovelCategory.Supernatural;
                  break;
               case "推理":
                  info.Category = ENovelCategory.Deduction;
                  break;
               case "同人":
                  info.Category = ENovelCategory.SamePerson;
                  break;
               case "恐怖":
                  info.Category = ENovelCategory.Horror;
                  break;
               case "穿越":
                  info.Category = ENovelCategory.TimeTravel;
                  break;
               case "其他":
                  info.Category = ENovelCategory.Other;
                  break;
               default:
                  info.Category = ENovelCategory.Other;
                  break;
            }
            info.CreationTime = DateTime.Today;
            info.BreakupTime = new DateTime(2100, 12, 31);
            info.Keywords = txtKeywords.Text.Split(',').ToList();
            info.ResourceFiles = new List<string>();
            string saved = txtSavedPath.Text + lblProjectName.Text;
            if (FileOperation.DirectoryExists(FileOperation.GetFatherDirectory(saved)) == false)
            {
               FileOperation.CreateDirectory(FileOperation.GetFatherDirectory(saved));
            }
            string savedfather = FileOperation.GetFatherDirectory(saved);
            FileOperation.CreateDirectory(savedfather + @"\ResourceFiles");
            Project proj = new Project(saved, info);
            proj.InitializeProject();
            proj.SaveNovelInformation();
            proj.UserSetting.Add(0);
            ESubsectionNumberMode snm;
            switch (cmbSubsectionNumber.Text)
            {
               case "第三十二卷":
                  snm = ESubsectionNumberMode.NumberBeforeChineseSubsectionFirstAndLast;
                  break;
               case "卷三十二":
                  snm = ESubsectionNumberMode.NumberAfterChineseSubsection;
                  break;
               case "Subsection 32":
                  snm = ESubsectionNumberMode.ArabicNumberAfterEnglishSubsection;
                  break;
               default:
                  snm = ESubsectionNumberMode.NumberBeforeChineseSubsectionFirstAndLast;
                  break;
            }
            EChapterNumberMode cnm;
            switch (cmbChapterNumber.Text)
            {
               case " 128":
                  cnm = EChapterNumberMode.OnlyArabic;
                  break;
               case " Chapter 128":
                  cnm = EChapterNumberMode.ArabicInEnglishChapterMark;
                  break;
               case " 章128":
                  cnm = EChapterNumberMode.ArabicInChineseChapterMark;
                  break;
               case " 节128":
                  cnm = EChapterNumberMode.ArabicInChineseSectionMark;
                  break;
               case " 第128章":
                  cnm = EChapterNumberMode.ArabicBeforeChineseChapterMarkFirstWordAndLastWord;
                  break;
               case " 第128节":
                  cnm = EChapterNumberMode.ArabicBeforeChineseSectionMarkFirstWordAndLastWord;
                  break;
               case " 一百二十八":
                  cnm = EChapterNumberMode.OnlyChineseNum;
                  break;
               case " 章一百二十八":
                  cnm = EChapterNumberMode.ChineseNumInChineseChapterMark;
                  break;
               case " 节一百二十八":
                  cnm = EChapterNumberMode.ChineseNumInChineseSectionMark;
                  break;
               case " 第一百二十八章":
                  cnm = EChapterNumberMode.ChineseNumBeforeChineseChapterMarkFirstWordAndLastWord;
                  break;
               case " 第一百二十八节":
                  cnm = EChapterNumberMode.ChineseNumBeforeChineseSectionMarkFirstWordAndLastWord;
                  break;
               default:
                  cnm = EChapterNumberMode.ArabicBeforeChineseChapterMarkFirstWordAndLastWord;
                  break;
            }
            proj.UserSetting.Add((int)cnm);
            proj.UserSetting.Add((int)snm);
            proj.SaveUserSetting();
            //TODO: 这里添加创建一个空白分卷和空白章节的代码
            Subsection subsection = new Subsection(new SSubsectionNumber((ESubsectionNumberMode)1, "一"), "新分卷");
            Chapter chapter = new Chapter(new SChapterNumber("一", (EChapterNumberMode)9), "新章节");
            proj.CreateChapter(subsection, chapter);
            proj.RecordProjectSaved();
            owner.trvNovelTree.Nodes.Clear();
            app.Projects.Clear();
            app.LoadProjects();
            Console.WriteLine("\n\nProjectCount=" + app.Projects.Count + "\n");
            owner.ShowTreeViewAll();
            owner.trvNovelTree.Refresh();
            string body = app.Projects[app.Projects.Count - 1].CurrentNovel[0][0].Body;
            owner.rtbBody.Text = body;
         };
         crtproj.Invoke();
         Action invoked = delegate
         {
            frmCreateRole crtrole = new frmCreateRole(app.Projects[app.Projects.Count - 1]);
            crtrole.ShowDialog(this);
         };
         //VsSkinMessageBoxOkCancel ques = new VsSkinMessageBoxOkCancel("询问", "项目已成功创建，是否马上转入到角色管理和大纲管理页面？", EMessageLevel.Question, invoked, DoNothing);
         //ques.Display(this);
         Close();
      }

      private void metroButton1_Click(object sender, EventArgs e)    //选择项目的保存路径
      {
         if (bpdSaved.ShowDialog(this) == DialogResult.OK)
         {
            txtSavedPath.Text = bpdSaved.DirectoryPath;
         }
      }

      private void txtKeywords_Click(object sender, EventArgs e)
      {
         if (txtKeywords.Text == "多个关键词之间请用英文逗号分隔") txtKeywords.Text = string.Empty;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
