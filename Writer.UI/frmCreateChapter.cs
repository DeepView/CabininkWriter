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
   public partial class frmCreateChapter : Cabinink.Writer.UI.VsSkinFormBase
   {
      private frmMainInterface owner;
      private Project project;
      public frmCreateChapter()
      {
         InitializeComponent();
      }
      public frmCreateChapter(Project _project)
      {
         InitializeComponent();
         project = _project;
      }

      private void btnCreate_Click(object sender, EventArgs e)
      {
         //TODO: 这里还需要改写！！！
         int count = ((Subsection)cmbSubsections.SelectedItem).Count;
         SChapterNumber cno = new SChapterNumber(
            (count + 1).ToString(),
            ((Subsection)cmbSubsections.SelectedItem).Chapters[0].ChapterNumber.ChapterNumberMode
         );
         ((Subsection)cmbSubsections.SelectedItem).AddChapter(new Chapter(cno, txtChapter.Text));
         project.SaveAllChapter();
         owner.EditingProj = project;
         Close();
      }

      private void frmCreateChapter_Load(object sender, EventArgs e)
      {
         cmbSubsections.Items.Clear();
         Console.WriteLine("\n\n\nActivedProject_SubsectionsCount=" + project.CurrentNovel.Count + "\n");
         Console.WriteLine("ActivedProject_ToString=" + project.CurrentNovel.ToString() + "\n\n");
         for (int i = 0; i < project.CurrentNovel.Count; i++)
         {
            cmbSubsections.Items.Add(project.CurrentNovel[i]);
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Close();
      }
      public DialogResult DisplayDialog(frmMainInterface _owner)
      {
         owner = _owner;
         return ShowDialog();
      }
   }
}
