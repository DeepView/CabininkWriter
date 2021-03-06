﻿namespace Cabinink.Writer.UI
{
   partial class frmNovelProperty
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
         this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
         this.tbcTabControl = new MaterialSkin.Controls.MaterialTabControl();
         this.tpInformation = new System.Windows.Forms.TabPage();
         this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
         this.txtKeywords = new MetroFramework.Controls.MetroTextBox();
         this.txtSavedPath = new MetroFramework.Controls.MetroTextBox();
         this.txtInfo = new MetroFramework.Controls.MetroTextBox();
         this.txtWriter = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
         this.txtCreateDate = new MetroFramework.Controls.MetroTextBox();
         this.txtNovelName = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
         this.txtCategory = new MetroFramework.Controls.MetroTextBox();
         this.txtProjectName = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
         this.tpRoleManagement = new System.Windows.Forms.TabPage();
         this.lsvRoles = new System.Windows.Forms.ListView();
         this.chdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdAppellation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdSex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdInitAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdCamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdOccupation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdAppearance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdCharacter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdPetphrase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdOther = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.cmsRolesContext = new MaterialSkin.Controls.MaterialContextMenuStrip();
         this.查看详情ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.编辑角色信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.创建新角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.移除角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.从内存中恢复已移除的角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tpCompendium = new System.Windows.Forms.TabPage();
         this.lsvCompendium = new System.Windows.Forms.ListView();
         this.chdDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdStoryCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdMainRoles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdPlace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.chdStory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.cmsCompendiumContext = new MaterialSkin.Controls.MaterialContextMenuStrip();
         this.查看详细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.修改故事线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.新建故事线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.删除故事线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tbcTabControl.SuspendLayout();
         this.tpInformation.SuspendLayout();
         this.tpRoleManagement.SuspendLayout();
         this.cmsRolesContext.SuspendLayout();
         this.tpCompendium.SuspendLayout();
         this.cmsCompendiumContext.SuspendLayout();
         this.SuspendLayout();
         // 
         // materialTabSelector1
         // 
         this.materialTabSelector1.BaseTabControl = this.tbcTabControl;
         this.materialTabSelector1.Depth = 0;
         this.materialTabSelector1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.materialTabSelector1.Location = new System.Drawing.Point(1, 39);
         this.materialTabSelector1.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.materialTabSelector1.Name = "materialTabSelector1";
         this.materialTabSelector1.Size = new System.Drawing.Size(702, 33);
         this.materialTabSelector1.TabIndex = 1;
         this.materialTabSelector1.Text = "materialTabSelector1";
         // 
         // tbcTabControl
         // 
         this.tbcTabControl.Controls.Add(this.tpInformation);
         this.tbcTabControl.Controls.Add(this.tpRoleManagement);
         this.tbcTabControl.Controls.Add(this.tpCompendium);
         this.tbcTabControl.Depth = 0;
         this.tbcTabControl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.tbcTabControl.Location = new System.Drawing.Point(7, 78);
         this.tbcTabControl.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.tbcTabControl.Name = "tbcTabControl";
         this.tbcTabControl.SelectedIndex = 0;
         this.tbcTabControl.Size = new System.Drawing.Size(690, 361);
         this.tbcTabControl.TabIndex = 2;
         // 
         // tpInformation
         // 
         this.tpInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.tpInformation.Controls.Add(this.metroLabel4);
         this.tpInformation.Controls.Add(this.txtKeywords);
         this.tpInformation.Controls.Add(this.txtSavedPath);
         this.tpInformation.Controls.Add(this.txtInfo);
         this.tpInformation.Controls.Add(this.txtWriter);
         this.tpInformation.Controls.Add(this.metroLabel8);
         this.tpInformation.Controls.Add(this.metroLabel7);
         this.tpInformation.Controls.Add(this.metroLabel3);
         this.tpInformation.Controls.Add(this.metroLabel6);
         this.tpInformation.Controls.Add(this.metroLabel5);
         this.tpInformation.Controls.Add(this.txtCreateDate);
         this.tpInformation.Controls.Add(this.txtNovelName);
         this.tpInformation.Controls.Add(this.metroLabel2);
         this.tpInformation.Controls.Add(this.txtCategory);
         this.tpInformation.Controls.Add(this.txtProjectName);
         this.tpInformation.Controls.Add(this.metroLabel1);
         this.tpInformation.Location = new System.Drawing.Point(4, 26);
         this.tpInformation.Name = "tpInformation";
         this.tpInformation.Padding = new System.Windows.Forms.Padding(3);
         this.tpInformation.Size = new System.Drawing.Size(682, 331);
         this.tpInformation.TabIndex = 0;
         this.tpInformation.Text = "作品信息";
         // 
         // metroLabel4
         // 
         this.metroLabel4.AutoSize = true;
         this.metroLabel4.Location = new System.Drawing.Point(359, 24);
         this.metroLabel4.Name = "metroLabel4";
         this.metroLabel4.Size = new System.Drawing.Size(65, 20);
         this.metroLabel4.TabIndex = 17;
         this.metroLabel4.Text = "作品分类";
         this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel4.UseCustomBackColor = true;
         // 
         // txtKeywords
         // 
         this.txtKeywords.Lines = new string[0];
         this.txtKeywords.Location = new System.Drawing.Point(430, 92);
         this.txtKeywords.MaxLength = 32767;
         this.txtKeywords.Name = "txtKeywords";
         this.txtKeywords.PasswordChar = '\0';
         this.txtKeywords.ReadOnly = true;
         this.txtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtKeywords.SelectedText = "";
         this.txtKeywords.Size = new System.Drawing.Size(244, 23);
         this.txtKeywords.TabIndex = 23;
         this.txtKeywords.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtKeywords.UseSelectable = true;
         // 
         // txtSavedPath
         // 
         this.txtSavedPath.Lines = new string[] {
        "E:\\CiWriterSolution"};
         this.txtSavedPath.Location = new System.Drawing.Point(80, 283);
         this.txtSavedPath.MaxLength = 32767;
         this.txtSavedPath.Name = "txtSavedPath";
         this.txtSavedPath.PasswordChar = '\0';
         this.txtSavedPath.ReadOnly = true;
         this.txtSavedPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtSavedPath.SelectedText = "";
         this.txtSavedPath.Size = new System.Drawing.Size(594, 23);
         this.txtSavedPath.TabIndex = 25;
         this.txtSavedPath.Text = "E:\\CiWriterSolution";
         this.txtSavedPath.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtSavedPath.UseSelectable = true;
         // 
         // txtInfo
         // 
         this.txtInfo.Lines = new string[0];
         this.txtInfo.Location = new System.Drawing.Point(80, 126);
         this.txtInfo.MaxLength = 32767;
         this.txtInfo.Multiline = true;
         this.txtInfo.Name = "txtInfo";
         this.txtInfo.PasswordChar = '\0';
         this.txtInfo.ReadOnly = true;
         this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtInfo.SelectedText = "";
         this.txtInfo.Size = new System.Drawing.Size(594, 146);
         this.txtInfo.TabIndex = 24;
         this.txtInfo.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtInfo.UseSelectable = true;
         // 
         // txtWriter
         // 
         this.txtWriter.Lines = new string[0];
         this.txtWriter.Location = new System.Drawing.Point(80, 92);
         this.txtWriter.MaxLength = 32767;
         this.txtWriter.Name = "txtWriter";
         this.txtWriter.PasswordChar = '\0';
         this.txtWriter.ReadOnly = true;
         this.txtWriter.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtWriter.SelectedText = "";
         this.txtWriter.Size = new System.Drawing.Size(244, 23);
         this.txtWriter.TabIndex = 20;
         this.txtWriter.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtWriter.UseSelectable = true;
         // 
         // metroLabel8
         // 
         this.metroLabel8.AutoSize = true;
         this.metroLabel8.Location = new System.Drawing.Point(9, 126);
         this.metroLabel8.Name = "metroLabel8";
         this.metroLabel8.Size = new System.Drawing.Size(65, 20);
         this.metroLabel8.TabIndex = 18;
         this.metroLabel8.Text = "详细信息";
         this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel8.UseCustomBackColor = true;
         // 
         // metroLabel7
         // 
         this.metroLabel7.AutoSize = true;
         this.metroLabel7.Location = new System.Drawing.Point(9, 283);
         this.metroLabel7.Name = "metroLabel7";
         this.metroLabel7.Size = new System.Drawing.Size(65, 20);
         this.metroLabel7.TabIndex = 9;
         this.metroLabel7.Text = "保存路径";
         this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel7.UseCustomBackColor = true;
         // 
         // metroLabel3
         // 
         this.metroLabel3.AutoSize = true;
         this.metroLabel3.Location = new System.Drawing.Point(9, 92);
         this.metroLabel3.Name = "metroLabel3";
         this.metroLabel3.Size = new System.Drawing.Size(65, 20);
         this.metroLabel3.TabIndex = 14;
         this.metroLabel3.Text = "作者笔名";
         this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel3.UseCustomBackColor = true;
         // 
         // metroLabel6
         // 
         this.metroLabel6.AutoSize = true;
         this.metroLabel6.Location = new System.Drawing.Point(359, 92);
         this.metroLabel6.Name = "metroLabel6";
         this.metroLabel6.Size = new System.Drawing.Size(51, 20);
         this.metroLabel6.TabIndex = 12;
         this.metroLabel6.Text = "关键词";
         this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel6.UseCustomBackColor = true;
         // 
         // metroLabel5
         // 
         this.metroLabel5.AutoSize = true;
         this.metroLabel5.Location = new System.Drawing.Point(359, 58);
         this.metroLabel5.Name = "metroLabel5";
         this.metroLabel5.Size = new System.Drawing.Size(65, 20);
         this.metroLabel5.TabIndex = 11;
         this.metroLabel5.Text = "创作日期";
         this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel5.UseCustomBackColor = true;
         // 
         // txtCreateDate
         // 
         this.txtCreateDate.Lines = new string[0];
         this.txtCreateDate.Location = new System.Drawing.Point(430, 58);
         this.txtCreateDate.MaxLength = 32767;
         this.txtCreateDate.Name = "txtCreateDate";
         this.txtCreateDate.PasswordChar = '\0';
         this.txtCreateDate.ReadOnly = true;
         this.txtCreateDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtCreateDate.SelectedText = "";
         this.txtCreateDate.Size = new System.Drawing.Size(244, 23);
         this.txtCreateDate.TabIndex = 22;
         this.txtCreateDate.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtCreateDate.UseSelectable = true;
         // 
         // txtNovelName
         // 
         this.txtNovelName.Lines = new string[0];
         this.txtNovelName.Location = new System.Drawing.Point(80, 58);
         this.txtNovelName.MaxLength = 32767;
         this.txtNovelName.Name = "txtNovelName";
         this.txtNovelName.PasswordChar = '\0';
         this.txtNovelName.ReadOnly = true;
         this.txtNovelName.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtNovelName.SelectedText = "";
         this.txtNovelName.Size = new System.Drawing.Size(244, 23);
         this.txtNovelName.TabIndex = 19;
         this.txtNovelName.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtNovelName.UseSelectable = true;
         // 
         // metroLabel2
         // 
         this.metroLabel2.AutoSize = true;
         this.metroLabel2.Location = new System.Drawing.Point(9, 58);
         this.metroLabel2.Name = "metroLabel2";
         this.metroLabel2.Size = new System.Drawing.Size(65, 20);
         this.metroLabel2.TabIndex = 10;
         this.metroLabel2.Text = "作品名称";
         this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel2.UseCustomBackColor = true;
         // 
         // txtCategory
         // 
         this.txtCategory.Lines = new string[0];
         this.txtCategory.Location = new System.Drawing.Point(430, 24);
         this.txtCategory.MaxLength = 32767;
         this.txtCategory.Name = "txtCategory";
         this.txtCategory.PasswordChar = '\0';
         this.txtCategory.ReadOnly = true;
         this.txtCategory.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtCategory.SelectedText = "";
         this.txtCategory.Size = new System.Drawing.Size(244, 23);
         this.txtCategory.TabIndex = 15;
         this.txtCategory.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtCategory.UseSelectable = true;
         // 
         // txtProjectName
         // 
         this.txtProjectName.Lines = new string[0];
         this.txtProjectName.Location = new System.Drawing.Point(80, 24);
         this.txtProjectName.MaxLength = 32767;
         this.txtProjectName.Name = "txtProjectName";
         this.txtProjectName.PasswordChar = '\0';
         this.txtProjectName.ReadOnly = true;
         this.txtProjectName.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtProjectName.SelectedText = "";
         this.txtProjectName.Size = new System.Drawing.Size(244, 23);
         this.txtProjectName.TabIndex = 15;
         this.txtProjectName.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtProjectName.UseSelectable = true;
         // 
         // metroLabel1
         // 
         this.metroLabel1.AutoSize = true;
         this.metroLabel1.Location = new System.Drawing.Point(9, 24);
         this.metroLabel1.Name = "metroLabel1";
         this.metroLabel1.Size = new System.Drawing.Size(65, 20);
         this.metroLabel1.TabIndex = 16;
         this.metroLabel1.Text = "项目名称";
         this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel1.UseCustomBackColor = true;
         // 
         // tpRoleManagement
         // 
         this.tpRoleManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.tpRoleManagement.Controls.Add(this.lsvRoles);
         this.tpRoleManagement.Location = new System.Drawing.Point(4, 26);
         this.tpRoleManagement.Name = "tpRoleManagement";
         this.tpRoleManagement.Padding = new System.Windows.Forms.Padding(3);
         this.tpRoleManagement.Size = new System.Drawing.Size(682, 331);
         this.tpRoleManagement.TabIndex = 1;
         this.tpRoleManagement.Text = "角色管理";
         // 
         // lsvRoles
         // 
         this.lsvRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.lsvRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.lsvRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdName,
            this.chdAppellation,
            this.chdSex,
            this.chdInitAge,
            this.chdCategory,
            this.chdCamp,
            this.chdOccupation,
            this.chdAppearance,
            this.chdCharacter,
            this.chdPetphrase,
            this.chdOther});
         this.lsvRoles.ContextMenuStrip = this.cmsRolesContext;
         this.lsvRoles.ForeColor = System.Drawing.Color.Silver;
         this.lsvRoles.GridLines = true;
         this.lsvRoles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.lsvRoles.Location = new System.Drawing.Point(0, 0);
         this.lsvRoles.Margin = new System.Windows.Forms.Padding(0);
         this.lsvRoles.Name = "lsvRoles";
         this.lsvRoles.Size = new System.Drawing.Size(682, 331);
         this.lsvRoles.TabIndex = 0;
         this.lsvRoles.UseCompatibleStateImageBehavior = false;
         this.lsvRoles.View = System.Windows.Forms.View.Details;
         // 
         // chdName
         // 
         this.chdName.Text = "姓名";
         this.chdName.Width = 100;
         // 
         // chdAppellation
         // 
         this.chdAppellation.DisplayIndex = 3;
         this.chdAppellation.Text = "昵称";
         this.chdAppellation.Width = 150;
         // 
         // chdSex
         // 
         this.chdSex.DisplayIndex = 1;
         this.chdSex.Text = "性别";
         this.chdSex.Width = 80;
         // 
         // chdInitAge
         // 
         this.chdInitAge.DisplayIndex = 2;
         this.chdInitAge.Text = "初始年龄";
         // 
         // chdCategory
         // 
         this.chdCategory.Text = "定位";
         // 
         // chdCamp
         // 
         this.chdCamp.Text = "阵营/势力/国家";
         this.chdCamp.Width = 100;
         // 
         // chdOccupation
         // 
         this.chdOccupation.Text = "职业";
         this.chdOccupation.Width = 100;
         // 
         // chdAppearance
         // 
         this.chdAppearance.Text = "外貌描写";
         this.chdAppearance.Width = 260;
         // 
         // chdCharacter
         // 
         this.chdCharacter.Text = "性格特征";
         this.chdCharacter.Width = 200;
         // 
         // chdPetphrase
         // 
         this.chdPetphrase.Text = "口头禅";
         this.chdPetphrase.Width = 240;
         // 
         // chdOther
         // 
         this.chdOther.Text = "其他信息";
         this.chdOther.Width = 360;
         // 
         // cmsRolesContext
         // 
         this.cmsRolesContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.cmsRolesContext.Depth = 0;
         this.cmsRolesContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看详情ToolStripMenuItem,
            this.编辑角色信息ToolStripMenuItem,
            this.toolStripSeparator1,
            this.创建新角色ToolStripMenuItem,
            this.移除角色ToolStripMenuItem,
            this.从内存中恢复已移除的角色ToolStripMenuItem});
         this.cmsRolesContext.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.cmsRolesContext.Name = "cmsRolesContext";
         this.cmsRolesContext.Size = new System.Drawing.Size(230, 120);
         // 
         // 查看详情ToolStripMenuItem
         // 
         this.查看详情ToolStripMenuItem.Name = "查看详情ToolStripMenuItem";
         this.查看详情ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
         this.查看详情ToolStripMenuItem.Text = "查看详情...";
         this.查看详情ToolStripMenuItem.Click += new System.EventHandler(this.查看详情ToolStripMenuItem_Click);
         // 
         // 编辑角色信息ToolStripMenuItem
         // 
         this.编辑角色信息ToolStripMenuItem.Name = "编辑角色信息ToolStripMenuItem";
         this.编辑角色信息ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
         this.编辑角色信息ToolStripMenuItem.Text = "编辑角色信息...";
         this.编辑角色信息ToolStripMenuItem.Click += new System.EventHandler(this.编辑角色信息ToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
         // 
         // 创建新角色ToolStripMenuItem
         // 
         this.创建新角色ToolStripMenuItem.Name = "创建新角色ToolStripMenuItem";
         this.创建新角色ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
         this.创建新角色ToolStripMenuItem.Text = "创建新角色...";
         this.创建新角色ToolStripMenuItem.Click += new System.EventHandler(this.创建新角色ToolStripMenuItem_Click);
         // 
         // 移除角色ToolStripMenuItem
         // 
         this.移除角色ToolStripMenuItem.Name = "移除角色ToolStripMenuItem";
         this.移除角色ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
         this.移除角色ToolStripMenuItem.Text = "移除角色";
         this.移除角色ToolStripMenuItem.Click += new System.EventHandler(this.移除角色ToolStripMenuItem_Click);
         // 
         // 从内存中恢复已移除的角色ToolStripMenuItem
         // 
         this.从内存中恢复已移除的角色ToolStripMenuItem.Name = "从内存中恢复已移除的角色ToolStripMenuItem";
         this.从内存中恢复已移除的角色ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
         this.从内存中恢复已移除的角色ToolStripMenuItem.Text = "从内存中恢复已移除的角色...";
         this.从内存中恢复已移除的角色ToolStripMenuItem.Click += new System.EventHandler(this.从内存中恢复已移除的角色ToolStripMenuItem_Click);
         // 
         // tpCompendium
         // 
         this.tpCompendium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.tpCompendium.Controls.Add(this.lsvCompendium);
         this.tpCompendium.Location = new System.Drawing.Point(4, 26);
         this.tpCompendium.Name = "tpCompendium";
         this.tpCompendium.Size = new System.Drawing.Size(682, 331);
         this.tpCompendium.TabIndex = 2;
         this.tpCompendium.Text = "作品大纲";
         // 
         // lsvCompendium
         // 
         this.lsvCompendium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.lsvCompendium.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.lsvCompendium.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdDate,
            this.chdStoryCategory,
            this.chdMainRoles,
            this.chdPlace,
            this.chdStory});
         this.lsvCompendium.ContextMenuStrip = this.cmsCompendiumContext;
         this.lsvCompendium.ForeColor = System.Drawing.Color.Silver;
         this.lsvCompendium.GridLines = true;
         this.lsvCompendium.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.lsvCompendium.Location = new System.Drawing.Point(0, 0);
         this.lsvCompendium.Name = "lsvCompendium";
         this.lsvCompendium.Size = new System.Drawing.Size(682, 331);
         this.lsvCompendium.TabIndex = 0;
         this.lsvCompendium.UseCompatibleStateImageBehavior = false;
         this.lsvCompendium.View = System.Windows.Forms.View.Details;
         // 
         // chdDate
         // 
         this.chdDate.Text = "故事日期";
         this.chdDate.Width = 100;
         // 
         // chdStoryCategory
         // 
         this.chdStoryCategory.Text = "分类";
         // 
         // chdMainRoles
         // 
         this.chdMainRoles.Text = "参与角色";
         this.chdMainRoles.Width = 160;
         // 
         // chdPlace
         // 
         this.chdPlace.Text = "发生地点";
         this.chdPlace.Width = 120;
         // 
         // chdStory
         // 
         this.chdStory.Text = "故事概要";
         this.chdStory.Width = 450;
         // 
         // cmsCompendiumContext
         // 
         this.cmsCompendiumContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.cmsCompendiumContext.Depth = 0;
         this.cmsCompendiumContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看详细ToolStripMenuItem,
            this.修改故事线ToolStripMenuItem,
            this.toolStripSeparator2,
            this.新建故事线ToolStripMenuItem,
            this.删除故事线ToolStripMenuItem});
         this.cmsCompendiumContext.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.cmsCompendiumContext.Name = "cmsCompendiumContext";
         this.cmsCompendiumContext.Size = new System.Drawing.Size(153, 120);
         // 
         // 查看详细ToolStripMenuItem
         // 
         this.查看详细ToolStripMenuItem.Name = "查看详细ToolStripMenuItem";
         this.查看详细ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.查看详细ToolStripMenuItem.Text = "查看详细...";
         this.查看详细ToolStripMenuItem.Click += new System.EventHandler(this.查看详细ToolStripMenuItem_Click);
         // 
         // 修改故事线ToolStripMenuItem
         // 
         this.修改故事线ToolStripMenuItem.Name = "修改故事线ToolStripMenuItem";
         this.修改故事线ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.修改故事线ToolStripMenuItem.Text = "修改故事线...";
         this.修改故事线ToolStripMenuItem.Click += new System.EventHandler(this.修改故事线ToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(142, 6);
         // 
         // 新建故事线ToolStripMenuItem
         // 
         this.新建故事线ToolStripMenuItem.Name = "新建故事线ToolStripMenuItem";
         this.新建故事线ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
         this.新建故事线ToolStripMenuItem.Text = "新建故事线...";
         this.新建故事线ToolStripMenuItem.Click += new System.EventHandler(this.新建故事线ToolStripMenuItem_Click);
         // 
         // 删除故事线ToolStripMenuItem
         // 
         this.删除故事线ToolStripMenuItem.Name = "删除故事线ToolStripMenuItem";
         this.删除故事线ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.删除故事线ToolStripMenuItem.Text = "删除故事线";
         this.删除故事线ToolStripMenuItem.Click += new System.EventHandler(this.删除故事线ToolStripMenuItem_Click);
         // 
         // frmNovelProperty
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(704, 446);
         this.Controls.Add(this.tbcTabControl);
         this.Controls.Add(this.materialTabSelector1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.Name = "frmNovelProperty";
         this.Text = "属性";
         this.Load += new System.EventHandler(this.frmNovelProperty_Load);
         this.tbcTabControl.ResumeLayout(false);
         this.tpInformation.ResumeLayout(false);
         this.tpInformation.PerformLayout();
         this.tpRoleManagement.ResumeLayout(false);
         this.cmsRolesContext.ResumeLayout(false);
         this.tpCompendium.ResumeLayout(false);
         this.cmsCompendiumContext.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion
      private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
      private System.Windows.Forms.TabPage tpRoleManagement;
      private System.Windows.Forms.TabPage tpInformation;
      private MaterialSkin.Controls.MaterialTabControl tbcTabControl;
      private System.Windows.Forms.TabPage tpCompendium;
      private MetroFramework.Controls.MetroLabel metroLabel4;
      private MetroFramework.Controls.MetroTextBox txtKeywords;
      private MetroFramework.Controls.MetroTextBox txtSavedPath;
      private MetroFramework.Controls.MetroTextBox txtInfo;
      private MetroFramework.Controls.MetroTextBox txtWriter;
      private MetroFramework.Controls.MetroLabel metroLabel8;
      private MetroFramework.Controls.MetroLabel metroLabel7;
      private MetroFramework.Controls.MetroLabel metroLabel3;
      private MetroFramework.Controls.MetroLabel metroLabel6;
      private MetroFramework.Controls.MetroLabel metroLabel5;
      private MetroFramework.Controls.MetroTextBox txtCreateDate;
      private MetroFramework.Controls.MetroTextBox txtNovelName;
      private MetroFramework.Controls.MetroLabel metroLabel2;
      private MetroFramework.Controls.MetroTextBox txtCategory;
      private MetroFramework.Controls.MetroTextBox txtProjectName;
      private MetroFramework.Controls.MetroLabel metroLabel1;
      private System.Windows.Forms.ListView lsvRoles;
      private System.Windows.Forms.ColumnHeader chdName;
      private System.Windows.Forms.ColumnHeader chdSex;
      private System.Windows.Forms.ColumnHeader chdInitAge;
      private System.Windows.Forms.ColumnHeader chdAppellation;
      private System.Windows.Forms.ColumnHeader chdCategory;
      private System.Windows.Forms.ColumnHeader chdCamp;
      private System.Windows.Forms.ColumnHeader chdOccupation;
      private System.Windows.Forms.ColumnHeader chdAppearance;
      private System.Windows.Forms.ColumnHeader chdCharacter;
      private System.Windows.Forms.ColumnHeader chdPetphrase;
      private System.Windows.Forms.ColumnHeader chdOther;
      private MaterialSkin.Controls.MaterialContextMenuStrip cmsRolesContext;
      private System.Windows.Forms.ToolStripMenuItem 查看详情ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 编辑角色信息ToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem 创建新角色ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 移除角色ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 从内存中恢复已移除的角色ToolStripMenuItem;
      private System.Windows.Forms.ListView lsvCompendium;
      private System.Windows.Forms.ColumnHeader chdDate;
      private System.Windows.Forms.ColumnHeader chdStoryCategory;
      private System.Windows.Forms.ColumnHeader chdMainRoles;
      private System.Windows.Forms.ColumnHeader chdPlace;
      private System.Windows.Forms.ColumnHeader chdStory;
      private MaterialSkin.Controls.MaterialContextMenuStrip cmsCompendiumContext;
      private System.Windows.Forms.ToolStripMenuItem 查看详细ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 修改故事线ToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem 新建故事线ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 删除故事线ToolStripMenuItem;
   }
}
