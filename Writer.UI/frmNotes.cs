using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using Cabinink.Writer.Cores;

namespace Cabinink.Writer.UI
{
   public partial class frmNotes : Cabinink.Writer.UI.VsSkinFormBase
   {
      private NoteManagement Notes = new NoteManagement();
      private int SelectedIndex = 0;
      public frmNotes()
      {
         InitializeComponent();
         lsvNoteList.Items.Clear();
         if (LoadNotes()) AddToListView();
      }
      /// <summary>
      /// 加载笔记
      /// </summary>
      /// <returns>加载后Count是否为0。</returns>
      public bool LoadNotes()
      {
         Notes.InitializeSupportedDb();
         Notes.ReadAll();
         return Notes.Count > 0 ? true : false;
      }
      public void AddToListView()
      {
         int count = Notes.Count;
         //lsvNoteList.Items.Clear();
         for (int i = 0; i < count; i++)
         {
            lsvNoteList.Items.Add(Notes[i].ToString());
         }
      }
      public void ReflushList()
      {
         //lsvNoteList.Items.Clear();
         if (LoadNotes())
         {

            AddToListView();
         }
      }
      private void lsvNoteList_Click(object sender, EventArgs e)
      {
         txtNoteTitle.Text = Notes[SelectedIndex].Title;
         rtbNoteBody.Text = Notes[SelectedIndex].Body;
         SelectedIndex = lsvNoteList.SelectedIndices[0];
      }

      private void 删除笔记ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Action remove = delegate
         {
            Notes.RemoveNote(SelectedIndex);
            Notes.SaveAll();
         };
         VsSkinMessageBoxOkCancel ques = new VsSkinMessageBoxOkCancel("提示", "确定要删除这条笔记吗？\n\n即将被删除：" + Notes[SelectedIndex].ToString(), EMessageLevel.Question, remove, DoNothing);
         ques.Display(this);
         ReflushList();
      }

      private void 新建笔记ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         lsvNoteList.Items.Add("新笔记");
         txtNoteTitle.Text = string.Empty;
         rtbNoteBody.Text = string.Empty;
         Notes.AddNote(new Note());
         lsvNoteList.Items.Clear();
         AddToListView();
         SelectedIndex = lsvNoteList.Items.Count - 1;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         Notes[Notes.Count - 1].Title = txtNoteTitle.Text;
         Notes[Notes.Count - 1].Body = rtbNoteBody.Text;
         Notes.SaveAll();
         lsvNoteList.Items.Clear();
         //Notes.Sort();
         AddToListView();

      }

      private void frmNotes_Load(object sender, EventArgs e)
      {
         txtNoteTitle.ImeMode = ImeMode.KatakanaHalf;
         rtbNoteBody.ImeMode = ImeMode.KatakanaHalf;
      }
   }
}
