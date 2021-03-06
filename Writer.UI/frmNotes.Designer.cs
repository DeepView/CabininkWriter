﻿namespace Cabinink.Writer.UI
{
   partial class frmNotes
   {
      /// <summary>
      /// 必需的设计器变量。
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// 清理所有正在使用的资源。
      /// </summary>
      /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows 窗体设计器生成的代码

      /// <summary>
      /// 设计器支持所需的方法 - 不要修改
      /// 使用代码编辑器修改此方法的内容。
      /// </summary>
      private void InitializeComponent()
      {
         System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "没有任何笔记...",
            "783565",
            "safddhjhu"}, -1);
         this.lsvNoteList = new System.Windows.Forms.ListView();
         this.cmsListContext = new MaterialSkin.Controls.MaterialContextMenuStrip();
         this.新建笔记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.删除笔记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.rtbNoteBody = new System.Windows.Forms.RichTextBox();
         this.txtNoteTitle = new MetroFramework.Controls.MetroTextBox();
         this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
         this.cmsListContext.SuspendLayout();
         this.SuspendLayout();
         // 
         // lsvNoteList
         // 
         this.lsvNoteList.BackColor = System.Drawing.Color.DimGray;
         this.lsvNoteList.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.lsvNoteList.ContextMenuStrip = this.cmsListContext;
         this.lsvNoteList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.lsvNoteList.ForeColor = System.Drawing.Color.LightGray;
         this.lsvNoteList.FullRowSelect = true;
         this.lsvNoteList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
         this.lsvNoteList.Location = new System.Drawing.Point(1, 40);
         this.lsvNoteList.MultiSelect = false;
         this.lsvNoteList.Name = "lsvNoteList";
         this.lsvNoteList.Size = new System.Drawing.Size(315, 426);
         this.lsvNoteList.TabIndex = 0;
         this.lsvNoteList.UseCompatibleStateImageBehavior = false;
         this.lsvNoteList.View = System.Windows.Forms.View.List;
         this.lsvNoteList.Click += new System.EventHandler(this.lsvNoteList_Click);
         // 
         // cmsListContext
         // 
         this.cmsListContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.cmsListContext.Depth = 0;
         this.cmsListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建笔记ToolStripMenuItem,
            this.删除笔记ToolStripMenuItem});
         this.cmsListContext.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.cmsListContext.Name = "cmsListContext";
         this.cmsListContext.Size = new System.Drawing.Size(125, 48);
         // 
         // 新建笔记ToolStripMenuItem
         // 
         this.新建笔记ToolStripMenuItem.Name = "新建笔记ToolStripMenuItem";
         this.新建笔记ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
         this.新建笔记ToolStripMenuItem.Text = "新建笔记";
         this.新建笔记ToolStripMenuItem.Click += new System.EventHandler(this.新建笔记ToolStripMenuItem_Click);
         // 
         // 删除笔记ToolStripMenuItem
         // 
         this.删除笔记ToolStripMenuItem.Name = "删除笔记ToolStripMenuItem";
         this.删除笔记ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
         this.删除笔记ToolStripMenuItem.Text = "删除笔记";
         this.删除笔记ToolStripMenuItem.Click += new System.EventHandler(this.删除笔记ToolStripMenuItem_Click);
         // 
         // rtbNoteBody
         // 
         this.rtbNoteBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.rtbNoteBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.rtbNoteBody.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.rtbNoteBody.ForeColor = System.Drawing.Color.White;
         this.rtbNoteBody.Location = new System.Drawing.Point(317, 73);
         this.rtbNoteBody.Name = "rtbNoteBody";
         this.rtbNoteBody.Size = new System.Drawing.Size(585, 393);
         this.rtbNoteBody.TabIndex = 1;
         this.rtbNoteBody.Text = "";
         // 
         // txtNoteTitle
         // 
         this.txtNoteTitle.FontSize = MetroFramework.MetroTextBoxSize.Tall;
         this.txtNoteTitle.Lines = new string[] {
        "txtNoteTitle"};
         this.txtNoteTitle.Location = new System.Drawing.Point(317, 40);
         this.txtNoteTitle.MaxLength = 32767;
         this.txtNoteTitle.Name = "txtNoteTitle";
         this.txtNoteTitle.PasswordChar = '\0';
         this.txtNoteTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtNoteTitle.SelectedText = "";
         this.txtNoteTitle.Size = new System.Drawing.Size(585, 32);
         this.txtNoteTitle.Style = MetroFramework.MetroColorStyle.Black;
         this.txtNoteTitle.TabIndex = 2;
         this.txtNoteTitle.Text = "txtNoteTitle";
         this.txtNoteTitle.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtNoteTitle.UseSelectable = true;
         // 
         // btnSave
         // 
         this.btnSave.Depth = 0;
         this.btnSave.Location = new System.Drawing.Point(846, 41);
         this.btnSave.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.btnSave.Name = "btnSave";
         this.btnSave.Primary = true;
         this.btnSave.Size = new System.Drawing.Size(55, 30);
         this.btnSave.TabIndex = 3;
         this.btnSave.Text = "Save";
         this.btnSave.UseVisualStyleBackColor = true;
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // frmNotes
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(905, 467);
         this.Controls.Add(this.btnSave);
         this.Controls.Add(this.txtNoteTitle);
         this.Controls.Add(this.rtbNoteBody);
         this.Controls.Add(this.lsvNoteList);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.Name = "frmNotes";
         this.Text = "笔记管理";
         this.Load += new System.EventHandler(this.frmNotes_Load);
         this.cmsListContext.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListView lsvNoteList;
      private System.Windows.Forms.RichTextBox rtbNoteBody;
      private MetroFramework.Controls.MetroTextBox txtNoteTitle;
      private MaterialSkin.Controls.MaterialRaisedButton btnSave;
      private MaterialSkin.Controls.MaterialContextMenuStrip cmsListContext;
      private System.Windows.Forms.ToolStripMenuItem 新建笔记ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 删除笔记ToolStripMenuItem;
   }
}
