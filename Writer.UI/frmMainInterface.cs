﻿using System;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using Cabinink.Properties;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using Cabinink.Writer.Middle;
using app = Cabinink.Program;
using System.Collections.Generic;
using iniopter = Cabinink.Writer.Cores.InitializationFileOperation;

namespace Cabinink.Writer.UI
{
   public partial class frmMainInterface : Cabinink.Writer.UI.VsSkinFormBase
   {
      public PlayQueue BackgroundMusicList = new PlayQueue();
      public Project EditingProj;
      public bool SecurityFlag = true;
      public TreeNode SelectedNode = new TreeNode();

      private Chapter Editing = new Chapter(new SChapterNumber("0", 0));
      //private int TextLength;
      //private string SelectedItemUri;
      //private frmIntelliSence IntelliSenceForm;
      public frmMainInterface()
      {
         InitializeComponent();
         Visible = false;
         //TextLength = 0;
      }
      //protected override void WndProc(ref Message m)
      //{
      //   const int WM_SYSCOMMAND = 0x112;
      //   const int SC_CLOSE = 0xf060;
      //   const int WM_CLOSE = 0x0010;
      //   if ((m.Msg == WM_SYSCOMMAND && Convert.ToInt32(m.WParam) == SC_CLOSE) || (m.WParam.ToInt32() == WM_CLOSE))
      //   {
      //      Visible = false;
      //      return;
      //   }
      //   base.WndProc(ref m);
      //}

      public void ShowTreeViewAccessProject(Project _proj)
      {
         trvNovelTree.Nodes.Add(_proj.CurrentNovel.ToString());
         for (int i = 0; i < _proj.CurrentNovel.Count; i++)
         {
            int count_L1 = trvNovelTree.Nodes.Count;
            trvNovelTree.Nodes[count_L1 - 1].Nodes.Add(_proj.CurrentNovel[i].ToString());
            for (int j = 0; j < _proj.CurrentNovel[i].Chapters.Count; j++)
            {
               trvNovelTree.Nodes[count_L1 - 1].Nodes[i].Nodes.Add(_proj.CurrentNovel[i].Chapters[j].ToString());
            }
         }
      }
      public void ShowTreeViewAll()
      {
         trvNovelTree.Nodes.Clear();
         for (int i = 0; i < app.Projects.Count; i++)
         {
            ShowTreeViewAccessProject(app.Projects[i]);
         }
         //Console.WriteLine("\n\nLoad Complate,Project Count is " + app.Projects.Count + "\n");
      }
      /// <summary>
      /// 获取指定节点的节点深度
      /// </summary>
      /// <param name="_fullpath">节点的路径。</param>
      /// <returns>该操作如果无异常发生，则会返回这个节点的节点深度，另外，根节点的节点深度为0。</returns>
      public int GetNodeDeepin(string _fullpath)
      {
         int deepin = 0;
         for (int i = 0; i < _fullpath.Length; i++)
         {
            if (_fullpath.Substring(i, 1) == trvNovelTree.PathSeparator)
            {
               deepin += 1;
            }
         }
         return deepin;
      }
      /// <summary>
      /// 获取选中节点的根节点
      /// </summary>
      /// <param name="_selected"></param>
      /// <returns></returns>
      public TreeNode GetRootNode(TreeNode _selected)
      {
         TreeNode root = _selected;
         string fullpath = _selected.FullPath;
         int deepin = GetNodeDeepin(fullpath);
         for (int i = 0; i < deepin; i++)
         {
            root = root.Parent;
         }
         return root;
      }
      /// <summary>
      /// 获取根节点的值
      /// </summary>
      /// <param name="_fullpath">节点的路径。</param>
      /// <returns>该操作将会返回指定节点路径的根节点的值。</returns>
      public string GetRootNodeValue(string _fullpath)
      {
         string root = string.Empty;
         int firstnode_index = 0;
         for (int i = 0; i < _fullpath.Length; i++)
         {
            if (_fullpath.Substring(i, 1) == trvNovelTree.PathSeparator)
            {
               firstnode_index = i;
               break;
            }
         }
         root = _fullpath.Substring(0, firstnode_index + 1);
         return root;
      }
      /// <summary>
      /// 获取被选中节点对应的项目
      /// </summary>
      /// <returns></returns>
      public Project GetProjectAccessSelectedNode()
      {
         Project proj = app.Projects[GetRootNode(trvNovelTree.SelectedNode).Index];
         //Console.WriteLine("\n\n" + proj.ToString() + "\n");
         return proj;
      }
      public bool IsSelectedSubsectionNode()
      {
         return GetNodeDeepin(GetRootNodeValue(trvNovelTree.SelectedNode.FullPath)) == 1 ? true : false;
      }
      public Subsection GetSubsectionAccessSelectedNode()
      {
         Subsection section;
         if (IsSelectedSubsectionNode())
         {
            int index = trvNovelTree.SelectedNode.Index;
            section = app.Projects[GetRootNode(trvNovelTree.SelectedNode).Index].CurrentNovel[index];
         }
         else section = null;
         return section;
      }
      public TreeNode GetSubsectionNode(TreeNode _selected)
      {
         if (GetNodeDeepin(_selected.FullPath) == 2) return _selected.Parent; else return null;
      }
      private void trvNovelTree_Click(object sender, EventArgs e)
      {
         tmrSaveChapter_Tick(sender, e);
         trvNovelTree.Refresh();
         TreeNode node = GetRootNode(trvNovelTree.SelectedNode);
         GetProjectAccessSelectedNode().ReadAll();
         EditingProj = app.Projects[GetRootNode(node).Index];
         SelectedNode = trvNovelTree.SelectedNode;
         #region LoadChapterToEditor
         if (GetNodeDeepin(node.FullPath) == 2)
         {
            Editing = EditingProj.CurrentNovel[node.Parent.Index][node.Index];
            rtbBody.Text = Editing.Body;
         }
         //新建章节ToolStripMenuItem.Enabled = IsSelectedSubsectionNode();
         #endregion
         //MessageBox.Show(trvNovelTree.SelectedNode.FullPath);
      }

      private void frmMainInterface_SizeChanged(object sender, EventArgs e)
      {
         trvNovelTree.Height = Height - 41;
         rtbBody.Size = new Size(Width - trvNovelTree.Width - trvNovelTree.Left - 2, Height - pnlStat.Height - 41);
         pnlStat.Width = rtbBody.Width;
         pnlStat.Top = rtbBody.Top + rtbBody.Height - 1;
         btnSearch.Top = Height - btnSearch.Height - 1;
         ResizeMenu();
      }
      protected override void OnLoad(EventArgs e)
      {
         System.Threading.Thread.Sleep(new Random().Next(1024, 8196));
         base.OnLoad(e);
      }

      private void frmMainInterface_Load(object sender, EventArgs e)
      {
         if (new UserRegister(new UserCredential(Environment.UserName, "000000")).Exists())
         {
            frmLogin login = new frmLogin();
            login.DisplayDialog(this);
         }
         else
         {
            frmLogon logon = new frmLogon();
            logon.DisplayDialog(this);
         }
         if (SecurityFlag == false)
         {
            ntiNotify.Visible = false;
            Application.ExitThread();
         }
         rtbBody.CanPaste(DataFormats.GetFormat(DataFormats.Text));
         trvNovelTree.ExpandAll();
         //LoadProjects();
         ShowTreeViewAll();
         ResizeMenu();
         Visible = true;
      }

      private void btnNovel_Click(object sender, EventArgs e)
      {
         //btnNovel.BackColor = Color.FromArgb(45, 45, 48);
         cmsNovel.Show(btnNovel, new Point(55, 0));
         //cmsNovel.Left = 55 + Left;
         //cmsNovel.Top = 40 + Top;
      }

      private void btnToolkit_Click(object sender, EventArgs e)
      {
         cmsToolkit.Show(btnNovel, new Point(55, 0));
      }

      //private void vsbScoll_Scroll(object sender, ScrollEventArgs e)
      //{
      //   float currentValue = Math.Abs(vsbScoll.Value - oldValue);//该变量表示当前滚动条中的值
      //   float temp = ScrollBarPercentage(rtbBody.Height + 50); //为临时变量temp赋值
      //   if (vsbScoll.Value > oldValue) //当向下滚动时
      //   {
      //      rtbBody.Top -= (int)(temp * currentValue);//定义RichTextBox控件的上边距与其工作区容器上边距间的距离
      //   }
      //   else if (vsbScoll.Value < oldValue)//当滚动条向上滚动时
      //   {
      //      rtbBody.Top += (int)(temp * currentValue);//定义RichTextBox控件的上边距与其工作区容器上边距间的距离
      //   }
      //   oldValue = vsbScoll.Value;//设置oldValue值为滚动条的当前值
      //}
      //private float ScrollBarPercentage(float height)
      //{
      //   float divisor = (float)(20);//将整型转化为浮点型
      //   float wholeValue = height - vsbScoll.Height;//获取滚动条的全值
      //   return (wholeValue / divisor);//获取滚动条移动时每移动一部分所占的百分比
      //}
      public void ResizeMenu()
      {
         cmsNovel.Size = new Size(265, Height - 42);
         cmsToolkit.Size = new Size(265, Height - 42);
         cmsSystem.Size = new Size(265, Height - 42);
         cmsHelp.Size = new Size(265, Height - 42);
      }

      private void btnSystem_Click(object sender, EventArgs e)
      {
         cmsSystem.Show(btnNovel, new Point(55, 0));
      }

      private void btnHelp_Click(object sender, EventArgs e)
      {
         cmsHelp.Show(btnNovel, new Point(55, 0));
      }

      private void cmsNovel_Opened(object sender, EventArgs e)
      {
         btnNovel.BackColor = Color.FromArgb(45, 45, 48);
         Text = "> 作品";
      }

      private void cmsNovel_Closed(object sender, ToolStripDropDownClosedEventArgs e)
      {
         btnNovel.BackColor = Color.FromArgb(64, 64, 64);
         Text = "Cabinink Writer";
      }

      private void cmsToolkit_Opened(object sender, EventArgs e)
      {
         btnToolkit.BackColor = Color.FromArgb(45, 45, 48);
         Text = "> 工具";
      }

      private void cmsToolkit_Closed(object sender, ToolStripDropDownClosedEventArgs e)
      {
         btnToolkit.BackColor = Color.FromArgb(64, 64, 64);
         Text = "Cabinink Writer";
      }

      private void cmsSystem_Opened(object sender, EventArgs e)
      {
         btnSystem.BackColor = Color.FromArgb(45, 45, 48);
         Text = "> 系统";
      }

      private void cmsSystem_Closed(object sender, ToolStripDropDownClosedEventArgs e)
      {
         btnSystem.BackColor = Color.FromArgb(64, 64, 64);
         Text = "Cabinink Writer";
      }

      private void cmsHelp_Opened(object sender, EventArgs e)
      {
         btnHelp.BackColor = Color.FromArgb(45, 45, 48);
         Text = "> 帮助";
      }

      private void cmsHelp_Closed(object sender, ToolStripDropDownClosedEventArgs e)
      {
         btnHelp.BackColor = Color.FromArgb(64, 64, 64);
         Text = "Cabinink Writer";
      }

      private void 查看产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ApplicationHelp.ShowProductionInformation(new frmAbout());
      }

      private void 创建新作品ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmCreateProject crtnovel = new frmCreateProject(this);
         crtnovel.ShowDialog();
      }

      private void 联系我们ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string tipstr = "如果您在使用我们的产品时有一些很奇特的想法，或者是在使用过程中你有一些很难费解的疑问，不妨通过下面的联系方式与我们交流交流：\n\n电子邮箱：lihuaxiang0321@msn.cn\nQQ号码：576882001\n微信：deepview_studio";
         VsSkinMessageBoxOk contact = new VsSkinMessageBoxOk("联系我们", tipstr, EMessageLevel.Information);
         contact.Display(this);
      }

      private void 退出应用程序ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ntiNotify.Visible = false;
         Application.ExitThread();
      }

      private void 反馈中心ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ApplicationHelp.OpenFeedback();
      }

      private void 查看最终用户许可协议ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ApplicationHelp.OpenEndUserLicenseAgreement(new frmEula());
      }

      private void 网页浏览器ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Process.Start(@"ciw_httpviewer.exe");
      }

      private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Process.Start(@"calc");
      }

      private void 作品属性与信息查看ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmNovelProperty npi = new frmNovelProperty();
         npi.Display(this);
      }

      private void 关闭WindowsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Action sd = delegate { long code = ExitWindows.Shutdown(); };
         VsSkinMessageBoxOkCancel shutdown = new VsSkinMessageBoxOkCancel("关机", "退出Windows可能会造成某些未保存的数据被丢失。这些数据包含但不限制于当前应用程序的未保存数据，并且也包含了运行于Windows中所有应用程序未保存的数据。\n\n所有您确定要这样做吗？", EMessageLevel.Question, sd, DoNothing);
         shutdown.Display(this);
      }

      private void 重新启动WindowsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Action rst = delegate { long code = ExitWindows.ResetBoot(); };
         VsSkinMessageBoxOkCancel shutdown = new VsSkinMessageBoxOkCancel("重新启动", "重新启动Windows也会导致某些未保存的数据被丢失，相对于没有UPS的计算机系统，这个操作是不会中断AC电源而再次进入Windows。当然，这些未保存的数据包含但不限制于当前应用程序的未保存数据，并且也包含了运行于Windows中所有应用程序未保存的数据。\n\n您确定要这样做吗？", EMessageLevel.Question, rst, DoNothing);
         shutdown.Display(this);
      }

      private void 电脑休眠ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Action hbrt = delegate { ExitWindows.Hibernate(); };
         VsSkinMessageBoxOkCancel shutdown = new VsSkinMessageBoxOkCancel("休眠", "休眠是一种将内存中未保存的数据压缩到硬盘中，然后退出Windows。当您重新进入Windows之后，这些未保存的数据将会还原到内存之中，并且返回到上次退出Windows时的工作点。\n\n您确定要这样做吗？", EMessageLevel.Question, hbrt, DoNothing);
         shutdown.Display(this);
      }

      private void 使系统进入挂起状态ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Action sleep = delegate { ExitWindows.Suspend(); };
         VsSkinMessageBoxOkCancel shutdown = new VsSkinMessageBoxOkCancel("挂起", "挂起Windows是将数据保留在内存中，然后使其他设备停止工作。如果您要返回到上一个工作点，从挂起状态恢复到工作状态的过程只需要几秒钟不到。但是对于没有后备能源系统的计算机，意外断电将会导致这些数据被丢失。\n\n您确定要这样做吗？", EMessageLevel.Question, sleep, DoNothing);
         shutdown.Display(this);
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
         frmSearchAndReplace srchrplc = new frmSearchAndReplace();
         srchrplc.Location = new Point(btnSearch.Width + 2 + Left, Height - srchrplc.Height + Top);
         if (!CheckFormIsOpen("frmSearchAndReplace")) srchrplc.Show(this);
      }
      /// <summary>
      /// 检查指定的窗口是否被打开
      /// </summary>
      /// <param name="_formname">需要被检测的窗体名称。</param>
      /// <returns>如果这个窗体被打开，则返回true，否则返回false。</returns>
      public static bool CheckFormIsOpen(string _formname)
      {
         bool bResult = false;
         foreach (Form frm in Application.OpenForms)
         {
            if (frm.Name == _formname)
            {
               bResult = true;
               break;
            }
         }
         return bResult;
      }

      private void 电脑休眠ToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         电脑休眠ToolStripMenuItem_Click(sender, e);
      }

      private void 显示主界面MToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Visible = true;
      }

      private void 关闭WindowsSToolStripMenuItem_Click(object sender, EventArgs e)
      {
         关闭WindowsToolStripMenuItem_Click(sender, e);
      }

      private void 重新启动WindowsRToolStripMenuItem_Click(object sender, EventArgs e)
      {
         重新启动WindowsToolStripMenuItem_Click(sender, e);
      }

      private void 强制挂起WindowsUToolStripMenuItem_Click(object sender, EventArgs e)
      {
         使系统进入挂起状态ToolStripMenuItem_Click(sender, e);
      }

      private void 产品信息IToolStripMenuItem_Click(object sender, EventArgs e)
      {
         查看产品信息ToolStripMenuItem_Click(sender, e);
      }

      private void 退出应用程序EToolStripMenuItem_Click(object sender, EventArgs e)
      {
         退出应用程序ToolStripMenuItem_Click(sender, e);
      }

      private void frmMainInterface_FormClosing(object sender, FormClosingEventArgs e)
      {
         //if (Visible) ntiNotify.ShowBalloonTip(4000, "Cabinink Writer", "应用程序已转入后台运行，如果您要继续编辑作品，请右键单击该应用程序的后台图标，然后再弹出的上下文菜单中选择显示主界面！", ToolTipIcon.Info);
         EventArgs events = new EventArgs();
         tmrSaveChapter_Tick(sender, events);
         e.Cancel = true;
         Visible = false;
      }

      private void frmMainInterface_VisibleChanged(object sender, EventArgs e)
      {
         if (!Visible) ntiNotify.ShowBalloonTip(4000, "Cabinink Writer", "应用程序已转入后台运行，如果您要继续编辑作品，请右键单击该应用程序的后台图标，然后再弹出的上下文菜单中选择显示主界面！", ToolTipIcon.Info);
      }

      private void 首选项ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmVerification veri = new frmVerification();
         veri.ShowDialog(this);
      }

      private void rtbBody_TextChanged(object sender, EventArgs e)
      {
         #region IntelliSence
         //Chapter isc = new Chapter(new SChapterNumber("1", 0), string.Empty);
         //isc.Body = rtbBody.Text; 
         //if (rtbBody.TextLength > TextLength && rtbBody.TextLength >= 2)
         //{
         //   IntelliSenceForm = new frmIntelliSence(5, isc.GetLastSentence());
         //   if (CheckFormIsOpen("frmIntelliSence") == false) IntelliSenceForm.Show(Handle);
         //   IntelliSenceForm.DoQuery();
         //   IntelliSenceForm.Location = IntelliSenceForm.CaretPosition();
         //}
         //else
         //{
         //   if (CheckFormIsOpen("frmIntelliSence")) IntelliSenceForm.Close();
         //}
         //TextLength = rtbBody.TextLength;
         Editing.Body = rtbBody.Text;
         #endregion
      }

      private void 查看帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("提示", "帮助文档正在建设之中...", EMessageLevel.Information);
         msg.Display(this);
      }

      private void 字符统计ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmWordCount wordcount = new frmWordCount();
         wordcount.ShowDialog(this);
      }

      private void 背景音乐管理ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmBackgroundMusicConsole bgsound = new frmBackgroundMusicConsole(this);
         if (CheckFormIsOpen("frmBackgroundMusicConsole") == false) bgsound.Show(); else bgsound.Visible = true;
      }

      private void 备份管理ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (app.CloudBackup.IsLogin())
            {
               VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("提示", "已登录至百度云，请勿重复登录！", EMessageLevel.Warning);
               msg.Display(this);
            }
            else
            {
               frmLoginBaiduCloud login_bdc = new frmLoginBaiduCloud();
               login_bdc.ShowDialog(this);
            }
         }
         catch
         {
            frmLoginBaiduCloud login_bdc = new frmLoginBaiduCloud();
            login_bdc.ShowDialog(this);
         }
         //throw new Exception("CLR exception be happend in application.");    //未知异常捕捉窗体测试代码。
      }

      private void 文本编辑器设置ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmEditorSetting editsetting = new frmEditorSetting();
         editsetting.DisplayDialog(this);
      }

      private void 重新启动ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Action reset = delegate { Application.Restart(); };
         VsSkinMessageBoxOkCancel ques = new VsSkinMessageBoxOkCancel("提示", "您确定要重新启动当前正在运行的应用程序？", EMessageLevel.Question, reset, DoNothing);
         ques.Display(this);
      }

      private void 资料与笔记ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmNotesOrResources notes = new frmNotesOrResources();
         notes.Display(this);
      }

      private void 新建作品ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         创建新作品ToolStripMenuItem_Click(sender, e);
      }

      private void 新建分卷ToolStripMenuItem_Click(object sender, EventArgs e)
      {

      }

      private void tmrSaveChapter_Tick(object sender, EventArgs e)
      {
         //TODO: 这里新出现一个Bug，位置 Writer.UI\frmMainInterface.cs:行号 557
         //TODO: 原因：未将对象引用设置到对象的实例。
         #region SaveChapter
         //if (Editing != null)
         //{
         //   int root = GetRootNode(SelectedNode).Index;
         //   int subsection, chapter;
         //   if (GetNodeDeepin(trvNovelTree.SelectedNode.FullPath) == 2)
         //   {
         //      subsection = trvNovelTree.SelectedNode.Parent.Index;
         //      chapter = trvNovelTree.SelectedNode.Index;
         //      Editing.Body = rtbBody.Text;
         //      app.Projects[root].SaveChapter((subsection + 1).ToString(), (chapter + 1).ToString());
         //   }
         //}
         //GetProjectAccessSelectedNode().SaveAllChapter();
         #endregion
      }

      private void 用户账户设置ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmUpgradeCredential cred_update = new frmUpgradeCredential();
         cred_update.Show();
      }

      private void 在当前作品创建新分卷ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmCreateRole crtrole = new frmCreateRole();
         crtrole.ShowDialog();
      }

      private void 作品属性ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmNovelProperty attrib = new frmNovelProperty(0);
         attrib.Display(this);
      }

      private void 大纲管理ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmNovelProperty attrib = new frmNovelProperty(2);
         attrib.Display(this);
      }

      private void 角色管理ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmNovelProperty attrib = new frmNovelProperty(1);
         attrib.Display(this);
      }

      private void 新建章节ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //MessageBox.Show(GetProjectAccessSelectedNode().ToString());
         //MessageBox.Show("SubsectionsCount=" + GetProjectAccessSelectedNode().CurrentNovel.Count);
         //MessageBox.Show("ChaptersCount=" + GetProjectAccessSelectedNode().CurrentNovel[0].Count);
         //Subsection subsection = GetSubsectionAccessSelectedNode();
         ////subsection.
         //GetSubsectionNode(trvNovelTree.SelectedNode).Nodes.Add((subsection.Count + 1) + " 新章节");
         ////TODO: 该函数可能需要重写一次！
         Project proj = GetProjectAccessSelectedNode();
         frmCreateChapter crtchapter = new frmCreateChapter(proj);
         crtchapter.ShowDialog(this);
         proj.ReadAll();
         ShowTreeViewAll();
      }

      private void 清空编辑区ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Action ok = delegate { rtbBody.Text = string.Empty; };
         VsSkinMessageBoxOkCancel ques = new VsSkinMessageBoxOkCancel("询问", "您确定要这样做吗？如果这样做可能会导致您的文档内容丢失。", EMessageLevel.Question, ok, DoNothing);
         ques.Display(this);
      }

      private void SaveCurrentNovel_Click(object sender, EventArgs e)
      {
         GetProjectAccessSelectedNode().SaveAll();
      }
   }
}
