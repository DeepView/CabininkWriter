﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;

namespace Cabinink.Writer.UI
{
   public partial class frmResources : Cabinink.Writer.UI.VsSkinFormBase
   {
      private frmMainInterface owner;
      private List<string> files;

      public frmResources()
      {
         InitializeComponent();
      }

      public void Display(frmMainInterface _owner)
      {
         owner = _owner;
         Show();
      }

      public void LoadResourceFileInfo(string _furl)
      {
         FileInfo info = new FileInfo(_furl);
         string fname = FileOperation.GetFileName(_furl);
         double fsize = Math.Round(info.Length / Math.Pow(1024, 2), 3);//CountUnit=MillByte
         DateTime fcrttime = info.CreationTime;
         FileAttributes fattrib = info.Attributes;
         string furl = _furl;
         string[] itemstr = new string[] { fname, fsize.ToString() + " MB", fcrttime.ToString(), fattrib.ToString(), furl };
         ListViewItem item = new ListViewItem(itemstr);
         lsvExplorer.Items.Add(item);
      }

      private void frmResources_Load(object sender, EventArgs e)
      {
         //string fdir = FileOperation.GetFatherDirectory(owner.GetProjectAccessSelectedNode().Database.SourceUri);
         lsvExplorer.Items.Clear();
         files = owner.GetProjectAccessSelectedNode().CurrentNovel.Information.ResourceFiles;
         if (files.Count > 0)
         {
            for (int i = 0; i < files.Count; i++) LoadResourceFileInfo(files[i]);
         }
      }

      private void lsvExplorer_DoubleClick(object sender, EventArgs e)
      {
         owner.GetProjectAccessSelectedNode().CurrentNovel.OpenResource(lsvExplorer.FocusedItem.SubItems[4].Text, string.Empty);
      }

      private void 打开资源文件ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            lsvExplorer_DoubleClick(sender, e);
         }
         catch (Exception ex)
         {
            Console.WriteLine("\n\n" + ex.Message + "\n" + ex.StackTrace + "\n");
         }
      }

      private void 确认参数并打开ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            owner.GetProjectAccessSelectedNode().CurrentNovel.OpenResource(lsvExplorer.FocusedItem.SubItems[4].Text, Arguments.Text);
         }
         catch (Exception ex)
         {
            Console.WriteLine("\n\n" + ex.Message + "\n" + ex.StackTrace + "\n");
         }
      }

      private void 删除文件ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            Action del = delegate
            {
               owner.GetProjectAccessSelectedNode().CurrentNovel.RemoveResource(lsvExplorer.FocusedItem.Index);
               frmResources_Load(sender, e);
            };
            VsSkinMessageBoxOkCancel ques = new VsSkinMessageBoxOkCancel("操作确认", "该操作属于不可逆操作，您确定要删除这个资源文件吗？删除之后文件将无法恢复！", EMessageLevel.Question, del, DoNothing);
            ques.Display(this);
         }
         catch (Exception ex)
         {
            Console.WriteLine("\n\n" + ex.Message + "\n" + ex.StackTrace + "\n");
         }
      }

      private void 添加新文件ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            string fdir = FileOperation.GetFatherDirectory(owner.GetProjectAccessSelectedNode().Database.SourceUri) + @"\ResourceFiles\";
            if (ofdAddResource.ShowDialog() == DialogResult.OK)
            {
               owner.GetProjectAccessSelectedNode().CurrentNovel.AddResource(
                  ofdAddResource.FileName
               );
               File.Copy(ofdAddResource.FileName, fdir + FileOperation.GetFileName(ofdAddResource.FileName), false);
               frmResources_Load(sender, e);
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine("\n\n" + ex.Message + "\n" + ex.StackTrace + "\n");
         }
      }

      private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmResources_Load(sender, e);
      }
   }
}
