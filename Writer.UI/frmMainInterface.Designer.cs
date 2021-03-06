﻿using MaterialSkin;
using MaterialSkin.Controls;
namespace Cabinink.Writer.UI
{
   partial class frmMainInterface
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainInterface));
         this.trvNovelTree = new Cabinink.Writer.UI.BaseTreeView();
         this.cmsTreeContextMenu = new MaterialSkin.Controls.MaterialContextMenuStrip();
         this.新建作品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.新建分卷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.新建章节ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.rtbBody = new System.Windows.Forms.RichTextBox();
         this.cmsEditContext = new MaterialSkin.Controls.MaterialContextMenuStrip();
         this.立即保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.清空编辑区ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.作品属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.角色管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.大纲管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.pnlStat = new System.Windows.Forms.Panel();
         this.lblWordCount = new MetroFramework.Controls.MetroLabel();
         this.btnNovel = new Cabinink.Writer.UI.FunctionIconButton();
         this.btnToolkit = new Cabinink.Writer.UI.FunctionIconButton();
         this.btnSystem = new Cabinink.Writer.UI.FunctionIconButton();
         this.btnHelp = new Cabinink.Writer.UI.FunctionIconButton();
         this.btnSearch = new Cabinink.Writer.UI.FunctionIconButton();
         this.ttpToolTip = new MetroFramework.Components.MetroToolTip();
         this.cmsNovel = new MetroFramework.Controls.MetroContextMenu(this.components);
         this.创建新作品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SaveCurrentNovel = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.作品属性与信息查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.退出应用程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.cmsToolkit = new MetroFramework.Controls.MetroContextMenu(this.components);
         this.网页浏览器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.计算器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.资料与笔记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
         this.背景音乐管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.文本编辑器设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.一键整理正文格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
         this.备份管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.字符统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.cmsSystem = new MetroFramework.Controls.MetroContextMenu(this.components);
         this.首选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.用户账户设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.关闭WindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.重新启动WindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.电脑休眠ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.使系统进入挂起状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.cmsHelp = new MetroFramework.Controls.MetroContextMenu(this.components);
         this.查看帮助文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.反馈中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.联系我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this.查看最终用户许可协议ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.查看产品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ntiNotify = new System.Windows.Forms.NotifyIcon(this.components);
         this.cmsNotify = new MaterialSkin.Controls.MaterialContextMenuStrip();
         this.显示主界面MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.首选项OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.系统电源PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.关闭WindowsSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.重新启动WindowsRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.电脑休眠ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.强制挂起WindowsUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.产品信息IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.重新启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.退出应用程序EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tmrSaveChapter = new System.Windows.Forms.Timer(this.components);
         this.cmsTreeContextMenu.SuspendLayout();
         this.cmsEditContext.SuspendLayout();
         this.pnlStat.SuspendLayout();
         this.cmsNovel.SuspendLayout();
         this.cmsToolkit.SuspendLayout();
         this.cmsSystem.SuspendLayout();
         this.cmsHelp.SuspendLayout();
         this.cmsNotify.SuspendLayout();
         this.SuspendLayout();
         // 
         // trvNovelTree
         // 
         this.trvNovelTree.BackColor = System.Drawing.Color.DimGray;
         this.trvNovelTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.trvNovelTree.ContextMenuStrip = this.cmsTreeContextMenu;
         this.trvNovelTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
         this.trvNovelTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.trvNovelTree.FullRowSelect = true;
         this.trvNovelTree.HideSelection = false;
         this.trvNovelTree.HotTracking = true;
         this.trvNovelTree.Indent = 19;
         this.trvNovelTree.ItemHeight = 23;
         this.trvNovelTree.LabelEdit = true;
         this.trvNovelTree.Location = new System.Drawing.Point(55, 40);
         this.trvNovelTree.Name = "trvNovelTree";
         this.trvNovelTree.Size = new System.Drawing.Size(267, 478);
         this.trvNovelTree.TabIndex = 0;
         this.trvNovelTree.Click += new System.EventHandler(this.trvNovelTree_Click);
         // 
         // cmsTreeContextMenu
         // 
         this.cmsTreeContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.cmsTreeContextMenu.Depth = 0;
         this.cmsTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建作品ToolStripMenuItem,
            this.新建分卷ToolStripMenuItem,
            this.新建章节ToolStripMenuItem,
            this.重命名ToolStripMenuItem,
            this.移除ToolStripMenuItem});
         this.cmsTreeContextMenu.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.cmsTreeContextMenu.Name = "cmsTreeContextMenu";
         this.cmsTreeContextMenu.Size = new System.Drawing.Size(134, 114);
         // 
         // 新建作品ToolStripMenuItem
         // 
         this.新建作品ToolStripMenuItem.Name = "新建作品ToolStripMenuItem";
         this.新建作品ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this.新建作品ToolStripMenuItem.Text = "新建作品...";
         this.新建作品ToolStripMenuItem.Click += new System.EventHandler(this.新建作品ToolStripMenuItem_Click);
         // 
         // 新建分卷ToolStripMenuItem
         // 
         this.新建分卷ToolStripMenuItem.Name = "新建分卷ToolStripMenuItem";
         this.新建分卷ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this.新建分卷ToolStripMenuItem.Text = "新建分卷";
         this.新建分卷ToolStripMenuItem.Click += new System.EventHandler(this.新建分卷ToolStripMenuItem_Click);
         // 
         // 新建章节ToolStripMenuItem
         // 
         this.新建章节ToolStripMenuItem.Name = "新建章节ToolStripMenuItem";
         this.新建章节ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this.新建章节ToolStripMenuItem.Text = "新建章节";
         this.新建章节ToolStripMenuItem.Click += new System.EventHandler(this.新建章节ToolStripMenuItem_Click);
         // 
         // 重命名ToolStripMenuItem
         // 
         this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
         this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this.重命名ToolStripMenuItem.Text = "重命名...";
         // 
         // 移除ToolStripMenuItem
         // 
         this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
         this.移除ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this.移除ToolStripMenuItem.Text = "移除...";
         // 
         // rtbBody
         // 
         this.rtbBody.AutoWordSelection = true;
         this.rtbBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.rtbBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.rtbBody.ContextMenuStrip = this.cmsEditContext;
         this.rtbBody.DetectUrls = false;
         this.rtbBody.EnableAutoDragDrop = true;
         this.rtbBody.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.rtbBody.ForeColor = System.Drawing.Color.White;
         this.rtbBody.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
         this.rtbBody.Location = new System.Drawing.Point(323, 41);
         this.rtbBody.MaxLength = 65535;
         this.rtbBody.Name = "rtbBody";
         this.rtbBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
         this.rtbBody.ShowSelectionMargin = true;
         this.rtbBody.Size = new System.Drawing.Size(574, 449);
         this.rtbBody.TabIndex = 1;
         this.rtbBody.Text = "";
         this.rtbBody.TextChanged += new System.EventHandler(this.rtbBody_TextChanged);
         // 
         // cmsEditContext
         // 
         this.cmsEditContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.cmsEditContext.Depth = 0;
         this.cmsEditContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.立即保存ToolStripMenuItem,
            this.清空编辑区ToolStripMenuItem,
            this.toolStripSeparator1,
            this.作品属性ToolStripMenuItem,
            this.角色管理ToolStripMenuItem,
            this.大纲管理ToolStripMenuItem});
         this.cmsEditContext.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.cmsEditContext.Name = "cmsEditContext";
         this.cmsEditContext.Size = new System.Drawing.Size(137, 120);
         // 
         // 立即保存ToolStripMenuItem
         // 
         this.立即保存ToolStripMenuItem.Name = "立即保存ToolStripMenuItem";
         this.立即保存ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
         this.立即保存ToolStripMenuItem.Text = "立即保存";
         // 
         // 清空编辑区ToolStripMenuItem
         // 
         this.清空编辑区ToolStripMenuItem.Name = "清空编辑区ToolStripMenuItem";
         this.清空编辑区ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
         this.清空编辑区ToolStripMenuItem.Text = "清空编辑区";
         this.清空编辑区ToolStripMenuItem.Click += new System.EventHandler(this.清空编辑区ToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
         // 
         // 作品属性ToolStripMenuItem
         // 
         this.作品属性ToolStripMenuItem.Name = "作品属性ToolStripMenuItem";
         this.作品属性ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
         this.作品属性ToolStripMenuItem.Text = "作品属性";
         this.作品属性ToolStripMenuItem.Click += new System.EventHandler(this.作品属性ToolStripMenuItem_Click);
         // 
         // 角色管理ToolStripMenuItem
         // 
         this.角色管理ToolStripMenuItem.Name = "角色管理ToolStripMenuItem";
         this.角色管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
         this.角色管理ToolStripMenuItem.Text = "角色管理";
         this.角色管理ToolStripMenuItem.Click += new System.EventHandler(this.角色管理ToolStripMenuItem_Click);
         // 
         // 大纲管理ToolStripMenuItem
         // 
         this.大纲管理ToolStripMenuItem.Name = "大纲管理ToolStripMenuItem";
         this.大纲管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
         this.大纲管理ToolStripMenuItem.Text = "大纲管理";
         this.大纲管理ToolStripMenuItem.Click += new System.EventHandler(this.大纲管理ToolStripMenuItem_Click);
         // 
         // pnlStat
         // 
         this.pnlStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.pnlStat.Controls.Add(this.lblWordCount);
         this.pnlStat.Location = new System.Drawing.Point(322, 493);
         this.pnlStat.Name = "pnlStat";
         this.pnlStat.Size = new System.Drawing.Size(575, 25);
         this.pnlStat.TabIndex = 2;
         // 
         // lblWordCount
         // 
         this.lblWordCount.AutoSize = true;
         this.lblWordCount.BackColor = System.Drawing.Color.Transparent;
         this.lblWordCount.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblWordCount.ForeColor = System.Drawing.Color.White;
         this.lblWordCount.Location = new System.Drawing.Point(4, 4);
         this.lblWordCount.Name = "lblWordCount";
         this.lblWordCount.Size = new System.Drawing.Size(263, 17);
         this.lblWordCount.TabIndex = 0;
         this.lblWordCount.Text = "当前作品总字数：65536，当前章节字数：2048";
         this.lblWordCount.UseCustomBackColor = true;
         this.lblWordCount.UseCustomForeColor = true;
         // 
         // btnNovel
         // 
         this.btnNovel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnNovel.BackgroundImage = global::Cabinink.Properties.Resources.b_novel;
         this.btnNovel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnNovel.FlatAppearance.BorderSize = 0;
         this.btnNovel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnNovel.Location = new System.Drawing.Point(1, 40);
         this.btnNovel.Name = "btnNovel";
         this.btnNovel.Size = new System.Drawing.Size(54, 40);
         this.btnNovel.TabIndex = 3;
         this.ttpToolTip.SetToolTip(this.btnNovel, "作品");
         this.btnNovel.UseVisualStyleBackColor = true;
         this.btnNovel.Click += new System.EventHandler(this.btnNovel_Click);
         // 
         // btnToolkit
         // 
         this.btnToolkit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnToolkit.BackgroundImage = global::Cabinink.Properties.Resources.b_toolkit;
         this.btnToolkit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnToolkit.FlatAppearance.BorderSize = 0;
         this.btnToolkit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnToolkit.Location = new System.Drawing.Point(1, 98);
         this.btnToolkit.Name = "btnToolkit";
         this.btnToolkit.Size = new System.Drawing.Size(54, 40);
         this.btnToolkit.TabIndex = 4;
         this.ttpToolTip.SetToolTip(this.btnToolkit, "工具");
         this.btnToolkit.UseVisualStyleBackColor = true;
         this.btnToolkit.Click += new System.EventHandler(this.btnToolkit_Click);
         // 
         // btnSystem
         // 
         this.btnSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnSystem.BackgroundImage = global::Cabinink.Properties.Resources.b_option;
         this.btnSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnSystem.FlatAppearance.BorderSize = 0;
         this.btnSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnSystem.Location = new System.Drawing.Point(1, 156);
         this.btnSystem.Name = "btnSystem";
         this.btnSystem.Size = new System.Drawing.Size(54, 40);
         this.btnSystem.TabIndex = 5;
         this.ttpToolTip.SetToolTip(this.btnSystem, "系统");
         this.btnSystem.UseVisualStyleBackColor = true;
         this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);
         // 
         // btnHelp
         // 
         this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnHelp.BackgroundImage = global::Cabinink.Properties.Resources.b_help;
         this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnHelp.FlatAppearance.BorderSize = 0;
         this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnHelp.Location = new System.Drawing.Point(1, 214);
         this.btnHelp.Name = "btnHelp";
         this.btnHelp.Size = new System.Drawing.Size(54, 40);
         this.btnHelp.TabIndex = 6;
         this.ttpToolTip.SetToolTip(this.btnHelp, "帮助");
         this.btnHelp.UseVisualStyleBackColor = true;
         this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
         // 
         // btnSearch
         // 
         this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnSearch.BackgroundImage = global::Cabinink.Properties.Resources.b_search;
         this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnSearch.FlatAppearance.BorderSize = 0;
         this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnSearch.Location = new System.Drawing.Point(1, 476);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(54, 40);
         this.btnSearch.TabIndex = 7;
         this.ttpToolTip.SetToolTip(this.btnSearch, "查找与替换");
         this.btnSearch.UseVisualStyleBackColor = false;
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // ttpToolTip
         // 
         this.ttpToolTip.AutoPopDelay = 5000;
         this.ttpToolTip.InitialDelay = 100;
         this.ttpToolTip.ReshowDelay = 100;
         this.ttpToolTip.Style = MetroFramework.MetroColorStyle.Black;
         this.ttpToolTip.StyleManager = null;
         this.ttpToolTip.Theme = MetroFramework.MetroThemeStyle.Dark;
         // 
         // cmsNovel
         // 
         this.cmsNovel.AutoSize = false;
         this.cmsNovel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.cmsNovel.DropShadowEnabled = false;
         this.cmsNovel.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.cmsNovel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建新作品ToolStripMenuItem,
            this.SaveCurrentNovel,
            this.toolStripSeparator2,
            this.作品属性与信息查看ToolStripMenuItem,
            this.toolStripSeparator3,
            this.退出应用程序ToolStripMenuItem});
         this.cmsNovel.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
         this.cmsNovel.Name = "cmsNovel";
         this.cmsNovel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.cmsNovel.ShowImageMargin = false;
         this.cmsNovel.Size = new System.Drawing.Size(184, 450);
         this.cmsNovel.Style = MetroFramework.MetroColorStyle.Black;
         this.cmsNovel.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.cmsNovel.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.cmsNovel_Closed);
         this.cmsNovel.Opened += new System.EventHandler(this.cmsNovel_Opened);
         // 
         // 创建新作品ToolStripMenuItem
         // 
         this.创建新作品ToolStripMenuItem.AutoSize = false;
         this.创建新作品ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.创建新作品ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.创建新作品ToolStripMenuItem.Name = "创建新作品ToolStripMenuItem";
         this.创建新作品ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.创建新作品ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.创建新作品ToolStripMenuItem.Text = "创建新作品";
         this.创建新作品ToolStripMenuItem.Click += new System.EventHandler(this.创建新作品ToolStripMenuItem_Click);
         // 
         // SaveCurrentNovel
         // 
         this.SaveCurrentNovel.AutoSize = false;
         this.SaveCurrentNovel.ForeColor = System.Drawing.Color.White;
         this.SaveCurrentNovel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.SaveCurrentNovel.Name = "SaveCurrentNovel";
         this.SaveCurrentNovel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.SaveCurrentNovel.Size = new System.Drawing.Size(265, 30);
         this.SaveCurrentNovel.Text = "保存当前作品";
         this.SaveCurrentNovel.Click += new System.EventHandler(this.SaveCurrentNovel_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.AutoSize = false;
         this.toolStripSeparator2.ForeColor = System.Drawing.Color.White;
         this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
         this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.toolStripSeparator2.Size = new System.Drawing.Size(180, 30);
         // 
         // 作品属性与信息查看ToolStripMenuItem
         // 
         this.作品属性与信息查看ToolStripMenuItem.AutoSize = false;
         this.作品属性与信息查看ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.作品属性与信息查看ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.作品属性与信息查看ToolStripMenuItem.Name = "作品属性与信息查看ToolStripMenuItem";
         this.作品属性与信息查看ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.作品属性与信息查看ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.作品属性与信息查看ToolStripMenuItem.Text = "作品属性与信息查看";
         this.作品属性与信息查看ToolStripMenuItem.Click += new System.EventHandler(this.作品属性与信息查看ToolStripMenuItem_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.AutoSize = false;
         this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
         this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
         this.toolStripSeparator3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.toolStripSeparator3.Size = new System.Drawing.Size(180, 30);
         // 
         // 退出应用程序ToolStripMenuItem
         // 
         this.退出应用程序ToolStripMenuItem.AutoSize = false;
         this.退出应用程序ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.退出应用程序ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.退出应用程序ToolStripMenuItem.Name = "退出应用程序ToolStripMenuItem";
         this.退出应用程序ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.退出应用程序ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.退出应用程序ToolStripMenuItem.Text = "退出应用程序";
         this.退出应用程序ToolStripMenuItem.Click += new System.EventHandler(this.退出应用程序ToolStripMenuItem_Click);
         // 
         // cmsToolkit
         // 
         this.cmsToolkit.AutoSize = false;
         this.cmsToolkit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.cmsToolkit.DropShadowEnabled = false;
         this.cmsToolkit.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.cmsToolkit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.网页浏览器ToolStripMenuItem,
            this.计算器ToolStripMenuItem,
            this.资料与笔记ToolStripMenuItem,
            this.toolStripSeparator6,
            this.背景音乐管理ToolStripMenuItem,
            this.文本编辑器设置ToolStripMenuItem,
            this.一键整理正文格式ToolStripMenuItem,
            this.toolStripSeparator7,
            this.备份管理ToolStripMenuItem,
            this.字符统计ToolStripMenuItem});
         this.cmsToolkit.Name = "cmsToolkit";
         this.cmsToolkit.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.cmsToolkit.ShowImageMargin = false;
         this.cmsToolkit.Size = new System.Drawing.Size(148, 500);
         this.cmsToolkit.Style = MetroFramework.MetroColorStyle.Black;
         this.cmsToolkit.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.cmsToolkit.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.cmsToolkit_Closed);
         this.cmsToolkit.Opened += new System.EventHandler(this.cmsToolkit_Opened);
         // 
         // 网页浏览器ToolStripMenuItem
         // 
         this.网页浏览器ToolStripMenuItem.AutoSize = false;
         this.网页浏览器ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.网页浏览器ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.网页浏览器ToolStripMenuItem.Name = "网页浏览器ToolStripMenuItem";
         this.网页浏览器ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.网页浏览器ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.网页浏览器ToolStripMenuItem.Text = "网页浏览器";
         this.网页浏览器ToolStripMenuItem.Click += new System.EventHandler(this.网页浏览器ToolStripMenuItem_Click);
         // 
         // 计算器ToolStripMenuItem
         // 
         this.计算器ToolStripMenuItem.AutoSize = false;
         this.计算器ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.计算器ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.计算器ToolStripMenuItem.Name = "计算器ToolStripMenuItem";
         this.计算器ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.计算器ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.计算器ToolStripMenuItem.Text = "计算器";
         this.计算器ToolStripMenuItem.Click += new System.EventHandler(this.计算器ToolStripMenuItem_Click);
         // 
         // 资料与笔记ToolStripMenuItem
         // 
         this.资料与笔记ToolStripMenuItem.AutoSize = false;
         this.资料与笔记ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.资料与笔记ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.资料与笔记ToolStripMenuItem.Name = "资料与笔记ToolStripMenuItem";
         this.资料与笔记ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.资料与笔记ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.资料与笔记ToolStripMenuItem.Text = "资料与笔记";
         this.资料与笔记ToolStripMenuItem.Click += new System.EventHandler(this.资料与笔记ToolStripMenuItem_Click);
         // 
         // toolStripSeparator6
         // 
         this.toolStripSeparator6.AutoSize = false;
         this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.toolStripSeparator6.Name = "toolStripSeparator6";
         this.toolStripSeparator6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.toolStripSeparator6.Size = new System.Drawing.Size(144, 30);
         // 
         // 背景音乐管理ToolStripMenuItem
         // 
         this.背景音乐管理ToolStripMenuItem.AutoSize = false;
         this.背景音乐管理ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.背景音乐管理ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.背景音乐管理ToolStripMenuItem.Name = "背景音乐管理ToolStripMenuItem";
         this.背景音乐管理ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.背景音乐管理ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.背景音乐管理ToolStripMenuItem.Text = "背景音乐管理";
         this.背景音乐管理ToolStripMenuItem.Click += new System.EventHandler(this.背景音乐管理ToolStripMenuItem_Click);
         // 
         // 文本编辑器设置ToolStripMenuItem
         // 
         this.文本编辑器设置ToolStripMenuItem.AutoSize = false;
         this.文本编辑器设置ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.文本编辑器设置ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.文本编辑器设置ToolStripMenuItem.Name = "文本编辑器设置ToolStripMenuItem";
         this.文本编辑器设置ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.文本编辑器设置ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.文本编辑器设置ToolStripMenuItem.Text = "文本编辑器设置";
         this.文本编辑器设置ToolStripMenuItem.Click += new System.EventHandler(this.文本编辑器设置ToolStripMenuItem_Click);
         // 
         // 一键整理正文格式ToolStripMenuItem
         // 
         this.一键整理正文格式ToolStripMenuItem.AutoSize = false;
         this.一键整理正文格式ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.一键整理正文格式ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.一键整理正文格式ToolStripMenuItem.Name = "一键整理正文格式ToolStripMenuItem";
         this.一键整理正文格式ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.一键整理正文格式ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.一键整理正文格式ToolStripMenuItem.Text = "一键整理正文格式";
         // 
         // toolStripSeparator7
         // 
         this.toolStripSeparator7.AutoSize = false;
         this.toolStripSeparator7.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.toolStripSeparator7.Name = "toolStripSeparator7";
         this.toolStripSeparator7.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.toolStripSeparator7.Size = new System.Drawing.Size(144, 30);
         // 
         // 备份管理ToolStripMenuItem
         // 
         this.备份管理ToolStripMenuItem.AutoSize = false;
         this.备份管理ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.备份管理ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.备份管理ToolStripMenuItem.Name = "备份管理ToolStripMenuItem";
         this.备份管理ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.备份管理ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.备份管理ToolStripMenuItem.Text = "备份管理";
         this.备份管理ToolStripMenuItem.Click += new System.EventHandler(this.备份管理ToolStripMenuItem_Click);
         // 
         // 字符统计ToolStripMenuItem
         // 
         this.字符统计ToolStripMenuItem.AutoSize = false;
         this.字符统计ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.字符统计ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.字符统计ToolStripMenuItem.Name = "字符统计ToolStripMenuItem";
         this.字符统计ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.字符统计ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.字符统计ToolStripMenuItem.Text = "字符统计";
         this.字符统计ToolStripMenuItem.Click += new System.EventHandler(this.字符统计ToolStripMenuItem_Click);
         // 
         // cmsSystem
         // 
         this.cmsSystem.AutoSize = false;
         this.cmsSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.cmsSystem.DropShadowEnabled = false;
         this.cmsSystem.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.cmsSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首选项ToolStripMenuItem,
            this.用户账户设置ToolStripMenuItem,
            this.toolStripSeparator4,
            this.关闭WindowsToolStripMenuItem,
            this.重新启动WindowsToolStripMenuItem,
            this.电脑休眠ToolStripMenuItem,
            this.使系统进入挂起状态ToolStripMenuItem});
         this.cmsSystem.Name = "cmsSystem";
         this.cmsSystem.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.cmsSystem.ShowImageMargin = false;
         this.cmsSystem.Size = new System.Drawing.Size(153, 600);
         this.cmsSystem.Style = MetroFramework.MetroColorStyle.Black;
         this.cmsSystem.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.cmsSystem.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.cmsSystem_Closed);
         this.cmsSystem.Opened += new System.EventHandler(this.cmsSystem_Opened);
         // 
         // 首选项ToolStripMenuItem
         // 
         this.首选项ToolStripMenuItem.AutoSize = false;
         this.首选项ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.首选项ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.首选项ToolStripMenuItem.Name = "首选项ToolStripMenuItem";
         this.首选项ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.首选项ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.首选项ToolStripMenuItem.Text = "首选项";
         this.首选项ToolStripMenuItem.Click += new System.EventHandler(this.首选项ToolStripMenuItem_Click);
         // 
         // 用户账户设置ToolStripMenuItem
         // 
         this.用户账户设置ToolStripMenuItem.AutoSize = false;
         this.用户账户设置ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.用户账户设置ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.用户账户设置ToolStripMenuItem.Name = "用户账户设置ToolStripMenuItem";
         this.用户账户设置ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.用户账户设置ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.用户账户设置ToolStripMenuItem.Text = "用户账户设置";
         this.用户账户设置ToolStripMenuItem.Click += new System.EventHandler(this.用户账户设置ToolStripMenuItem_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.AutoSize = false;
         this.toolStripSeparator4.ForeColor = System.Drawing.Color.White;
         this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.toolStripSeparator4.Size = new System.Drawing.Size(149, 30);
         // 
         // 关闭WindowsToolStripMenuItem
         // 
         this.关闭WindowsToolStripMenuItem.AutoSize = false;
         this.关闭WindowsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.关闭WindowsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.关闭WindowsToolStripMenuItem.Name = "关闭WindowsToolStripMenuItem";
         this.关闭WindowsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.关闭WindowsToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.关闭WindowsToolStripMenuItem.Text = "关闭Windows";
         this.关闭WindowsToolStripMenuItem.Click += new System.EventHandler(this.关闭WindowsToolStripMenuItem_Click);
         // 
         // 重新启动WindowsToolStripMenuItem
         // 
         this.重新启动WindowsToolStripMenuItem.AutoSize = false;
         this.重新启动WindowsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.重新启动WindowsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.重新启动WindowsToolStripMenuItem.Name = "重新启动WindowsToolStripMenuItem";
         this.重新启动WindowsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.重新启动WindowsToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.重新启动WindowsToolStripMenuItem.Text = "重新启动Windows";
         this.重新启动WindowsToolStripMenuItem.Click += new System.EventHandler(this.重新启动WindowsToolStripMenuItem_Click);
         // 
         // 电脑休眠ToolStripMenuItem
         // 
         this.电脑休眠ToolStripMenuItem.AutoSize = false;
         this.电脑休眠ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.电脑休眠ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.电脑休眠ToolStripMenuItem.Name = "电脑休眠ToolStripMenuItem";
         this.电脑休眠ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.电脑休眠ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.电脑休眠ToolStripMenuItem.Text = "电脑休眠";
         this.电脑休眠ToolStripMenuItem.Click += new System.EventHandler(this.电脑休眠ToolStripMenuItem_Click);
         // 
         // 使系统进入挂起状态ToolStripMenuItem
         // 
         this.使系统进入挂起状态ToolStripMenuItem.AutoSize = false;
         this.使系统进入挂起状态ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.使系统进入挂起状态ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.使系统进入挂起状态ToolStripMenuItem.Name = "使系统进入挂起状态ToolStripMenuItem";
         this.使系统进入挂起状态ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.使系统进入挂起状态ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.使系统进入挂起状态ToolStripMenuItem.Text = "使系统进入挂起状态";
         this.使系统进入挂起状态ToolStripMenuItem.Click += new System.EventHandler(this.使系统进入挂起状态ToolStripMenuItem_Click);
         // 
         // cmsHelp
         // 
         this.cmsHelp.AutoSize = false;
         this.cmsHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.cmsHelp.DropShadowEnabled = false;
         this.cmsHelp.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.cmsHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助文档ToolStripMenuItem,
            this.反馈中心ToolStripMenuItem,
            this.联系我们ToolStripMenuItem,
            this.toolStripSeparator5,
            this.查看最终用户许可协议ToolStripMenuItem,
            this.查看产品信息ToolStripMenuItem});
         this.cmsHelp.Name = "cmsHelp";
         this.cmsHelp.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.cmsHelp.ShowImageMargin = false;
         this.cmsHelp.Size = new System.Drawing.Size(172, 400);
         this.cmsHelp.Style = MetroFramework.MetroColorStyle.Black;
         this.cmsHelp.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.cmsHelp.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.cmsHelp_Closed);
         this.cmsHelp.Opened += new System.EventHandler(this.cmsHelp_Opened);
         // 
         // 查看帮助文档ToolStripMenuItem
         // 
         this.查看帮助文档ToolStripMenuItem.AutoSize = false;
         this.查看帮助文档ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.查看帮助文档ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.查看帮助文档ToolStripMenuItem.Name = "查看帮助文档ToolStripMenuItem";
         this.查看帮助文档ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.查看帮助文档ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.查看帮助文档ToolStripMenuItem.Text = "查看帮助文档";
         this.查看帮助文档ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助文档ToolStripMenuItem_Click);
         // 
         // 反馈中心ToolStripMenuItem
         // 
         this.反馈中心ToolStripMenuItem.AutoSize = false;
         this.反馈中心ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.反馈中心ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.反馈中心ToolStripMenuItem.Name = "反馈中心ToolStripMenuItem";
         this.反馈中心ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.反馈中心ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.反馈中心ToolStripMenuItem.Text = "反馈中心";
         this.反馈中心ToolStripMenuItem.Click += new System.EventHandler(this.反馈中心ToolStripMenuItem_Click);
         // 
         // 联系我们ToolStripMenuItem
         // 
         this.联系我们ToolStripMenuItem.AutoSize = false;
         this.联系我们ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.联系我们ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.联系我们ToolStripMenuItem.Name = "联系我们ToolStripMenuItem";
         this.联系我们ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.联系我们ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.联系我们ToolStripMenuItem.Text = "联系我们";
         this.联系我们ToolStripMenuItem.Click += new System.EventHandler(this.联系我们ToolStripMenuItem_Click);
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.AutoSize = false;
         this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.toolStripSeparator5.Size = new System.Drawing.Size(168, 30);
         // 
         // 查看最终用户许可协议ToolStripMenuItem
         // 
         this.查看最终用户许可协议ToolStripMenuItem.AutoSize = false;
         this.查看最终用户许可协议ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.查看最终用户许可协议ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.查看最终用户许可协议ToolStripMenuItem.Name = "查看最终用户许可协议ToolStripMenuItem";
         this.查看最终用户许可协议ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.查看最终用户许可协议ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.查看最终用户许可协议ToolStripMenuItem.Text = "查看最终用户许可协议";
         this.查看最终用户许可协议ToolStripMenuItem.Click += new System.EventHandler(this.查看最终用户许可协议ToolStripMenuItem_Click);
         // 
         // 查看产品信息ToolStripMenuItem
         // 
         this.查看产品信息ToolStripMenuItem.AutoSize = false;
         this.查看产品信息ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.查看产品信息ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
         this.查看产品信息ToolStripMenuItem.Name = "查看产品信息ToolStripMenuItem";
         this.查看产品信息ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
         this.查看产品信息ToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
         this.查看产品信息ToolStripMenuItem.Text = "查看产品信息";
         this.查看产品信息ToolStripMenuItem.Click += new System.EventHandler(this.查看产品信息ToolStripMenuItem_Click);
         // 
         // ntiNotify
         // 
         this.ntiNotify.ContextMenuStrip = this.cmsNotify;
         this.ntiNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("ntiNotify.Icon")));
         this.ntiNotify.Text = "Cabinink Writer";
         this.ntiNotify.Visible = true;
         // 
         // cmsNotify
         // 
         this.cmsNotify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.cmsNotify.Depth = 0;
         this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主界面MToolStripMenuItem,
            this.首选项OToolStripMenuItem,
            this.系统电源PToolStripMenuItem,
            this.产品信息IToolStripMenuItem,
            this.重新启动ToolStripMenuItem,
            this.退出应用程序EToolStripMenuItem});
         this.cmsNotify.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.cmsNotify.Name = "cmsNotify";
         this.cmsNotify.Size = new System.Drawing.Size(137, 166);
         // 
         // 显示主界面MToolStripMenuItem
         // 
         this.显示主界面MToolStripMenuItem.Name = "显示主界面MToolStripMenuItem";
         this.显示主界面MToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.显示主界面MToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
         this.显示主界面MToolStripMenuItem.Text = "显示主界面";
         this.显示主界面MToolStripMenuItem.Click += new System.EventHandler(this.显示主界面MToolStripMenuItem_Click);
         // 
         // 首选项OToolStripMenuItem
         // 
         this.首选项OToolStripMenuItem.Name = "首选项OToolStripMenuItem";
         this.首选项OToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.首选项OToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
         this.首选项OToolStripMenuItem.Text = "首选项";
         // 
         // 系统电源PToolStripMenuItem
         // 
         this.系统电源PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭WindowsSToolStripMenuItem,
            this.重新启动WindowsRToolStripMenuItem,
            this.电脑休眠ToolStripMenuItem1,
            this.强制挂起WindowsUToolStripMenuItem});
         this.系统电源PToolStripMenuItem.Name = "系统电源PToolStripMenuItem";
         this.系统电源PToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.系统电源PToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
         this.系统电源PToolStripMenuItem.Text = "系统电源";
         // 
         // 关闭WindowsSToolStripMenuItem
         // 
         this.关闭WindowsSToolStripMenuItem.Name = "关闭WindowsSToolStripMenuItem";
         this.关闭WindowsSToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.关闭WindowsSToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
         this.关闭WindowsSToolStripMenuItem.Text = "关闭Windows";
         this.关闭WindowsSToolStripMenuItem.Click += new System.EventHandler(this.关闭WindowsSToolStripMenuItem_Click);
         // 
         // 重新启动WindowsRToolStripMenuItem
         // 
         this.重新启动WindowsRToolStripMenuItem.Name = "重新启动WindowsRToolStripMenuItem";
         this.重新启动WindowsRToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.重新启动WindowsRToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
         this.重新启动WindowsRToolStripMenuItem.Text = "重新启动Windows";
         this.重新启动WindowsRToolStripMenuItem.Click += new System.EventHandler(this.重新启动WindowsRToolStripMenuItem_Click);
         // 
         // 电脑休眠ToolStripMenuItem1
         // 
         this.电脑休眠ToolStripMenuItem1.Name = "电脑休眠ToolStripMenuItem1";
         this.电脑休眠ToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.电脑休眠ToolStripMenuItem1.Size = new System.Drawing.Size(177, 28);
         this.电脑休眠ToolStripMenuItem1.Text = "电脑休眠";
         this.电脑休眠ToolStripMenuItem1.Click += new System.EventHandler(this.电脑休眠ToolStripMenuItem1_Click);
         // 
         // 强制挂起WindowsUToolStripMenuItem
         // 
         this.强制挂起WindowsUToolStripMenuItem.Name = "强制挂起WindowsUToolStripMenuItem";
         this.强制挂起WindowsUToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.强制挂起WindowsUToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
         this.强制挂起WindowsUToolStripMenuItem.Text = "进入挂起状态";
         this.强制挂起WindowsUToolStripMenuItem.Click += new System.EventHandler(this.强制挂起WindowsUToolStripMenuItem_Click);
         // 
         // 产品信息IToolStripMenuItem
         // 
         this.产品信息IToolStripMenuItem.Name = "产品信息IToolStripMenuItem";
         this.产品信息IToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.产品信息IToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
         this.产品信息IToolStripMenuItem.Text = "产品信息";
         this.产品信息IToolStripMenuItem.Click += new System.EventHandler(this.产品信息IToolStripMenuItem_Click);
         // 
         // 重新启动ToolStripMenuItem
         // 
         this.重新启动ToolStripMenuItem.Name = "重新启动ToolStripMenuItem";
         this.重新启动ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
         this.重新启动ToolStripMenuItem.Text = "重新启动";
         this.重新启动ToolStripMenuItem.Click += new System.EventHandler(this.重新启动ToolStripMenuItem_Click);
         // 
         // 退出应用程序EToolStripMenuItem
         // 
         this.退出应用程序EToolStripMenuItem.Name = "退出应用程序EToolStripMenuItem";
         this.退出应用程序EToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
         this.退出应用程序EToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
         this.退出应用程序EToolStripMenuItem.Text = "退出";
         this.退出应用程序EToolStripMenuItem.Click += new System.EventHandler(this.退出应用程序EToolStripMenuItem_Click);
         // 
         // tmrSaveChapter
         // 
         this.tmrSaveChapter.Enabled = true;
         this.tmrSaveChapter.Interval = 5000;
         this.tmrSaveChapter.Tick += new System.EventHandler(this.tmrSaveChapter_Tick);
         // 
         // frmMainInterface
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.ClientSize = new System.Drawing.Size(898, 519);
         this.Controls.Add(this.btnSearch);
         this.Controls.Add(this.btnHelp);
         this.Controls.Add(this.btnSystem);
         this.Controls.Add(this.btnToolkit);
         this.Controls.Add(this.btnNovel);
         this.Controls.Add(this.pnlStat);
         this.Controls.Add(this.rtbBody);
         this.Controls.Add(this.trvNovelTree);
         this.ForeColor = System.Drawing.Color.White;
         this.MinimumSize = new System.Drawing.Size(898, 519);
         this.Name = "frmMainInterface";
         this.ShowDrawIcon = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainInterface_FormClosing);
         this.Load += new System.EventHandler(this.frmMainInterface_Load);
         this.SizeChanged += new System.EventHandler(this.frmMainInterface_SizeChanged);
         this.VisibleChanged += new System.EventHandler(this.frmMainInterface_VisibleChanged);
         this.cmsTreeContextMenu.ResumeLayout(false);
         this.cmsEditContext.ResumeLayout(false);
         this.pnlStat.ResumeLayout(false);
         this.pnlStat.PerformLayout();
         this.cmsNovel.ResumeLayout(false);
         this.cmsToolkit.ResumeLayout(false);
         this.cmsSystem.ResumeLayout(false);
         this.cmsHelp.ResumeLayout(false);
         this.cmsNotify.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.Panel pnlStat;
      private FunctionIconButton btnNovel;
      private FunctionIconButton btnToolkit;
      private FunctionIconButton btnSystem;
      private FunctionIconButton btnHelp;
      private MetroFramework.Controls.MetroLabel lblWordCount;
      private FunctionIconButton btnSearch;
      private MetroFramework.Components.MetroToolTip ttpToolTip;
      private MetroFramework.Controls.MetroContextMenu cmsNovel;
      private System.Windows.Forms.ToolStripMenuItem 创建新作品ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem SaveCurrentNovel;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem 作品属性与信息查看ToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem 退出应用程序ToolStripMenuItem;
      private MetroFramework.Controls.MetroContextMenu cmsToolkit;
      private System.Windows.Forms.ToolStripMenuItem 网页浏览器ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 资料与笔记ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 背景音乐管理ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 计算器ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 一键整理正文格式ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 文本编辑器设置ToolStripMenuItem;
      private MetroFramework.Controls.MetroContextMenu cmsSystem;
      private System.Windows.Forms.ToolStripMenuItem 首选项ToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private MetroFramework.Controls.MetroContextMenu cmsHelp;
      private System.Windows.Forms.ToolStripMenuItem 查看帮助文档ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 反馈中心ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 查看最终用户许可协议ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 联系我们ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 查看产品信息ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 关闭WindowsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 重新启动WindowsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 电脑休眠ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 使系统进入挂起状态ToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
      private System.Windows.Forms.ToolStripMenuItem 备份管理ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 字符统计ToolStripMenuItem;
      internal BaseTreeView trvNovelTree;
      private System.Windows.Forms.NotifyIcon ntiNotify;
      private MaterialSkin.Controls.MaterialContextMenuStrip cmsNotify;
      private System.Windows.Forms.ToolStripMenuItem 显示主界面MToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 首选项OToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 系统电源PToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 关闭WindowsSToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 重新启动WindowsRToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 电脑休眠ToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem 强制挂起WindowsUToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 产品信息IToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 退出应用程序EToolStripMenuItem;
      private MaterialContextMenuStrip cmsTreeContextMenu;
      private System.Windows.Forms.ToolStripMenuItem 新建作品ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 新建分卷ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 新建章节ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 移除ToolStripMenuItem;
      internal System.Windows.Forms.RichTextBox rtbBody;
      private System.Windows.Forms.ToolStripMenuItem 重新启动ToolStripMenuItem;
      private System.Windows.Forms.Timer tmrSaveChapter;
      private System.Windows.Forms.ToolStripMenuItem 用户账户设置ToolStripMenuItem;
      private MaterialContextMenuStrip cmsEditContext;
      private System.Windows.Forms.ToolStripMenuItem 立即保存ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 清空编辑区ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 作品属性ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 大纲管理ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 角色管理ToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
   }
}
