namespace Cabinink.Writer.UI
{
   partial class frmBackgroundMusicConsole
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
         this.lstPlayList = new System.Windows.Forms.ListBox();
         this.cmsPlayList = new MaterialSkin.Controls.MaterialContextMenuStrip();
         this.添加文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.添加文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.移除当前文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.trbPlayingProcess = new MetroFramework.Controls.MetroTrackBar();
         this.lblPlaying = new MetroFramework.Controls.MetroLabel();
         this.btnPrevious = new Cabinink.Writer.UI.FunctionIconButton();
         this.btnPlayAndPause = new Cabinink.Writer.UI.FunctionIconButton();
         this.btnNext = new Cabinink.Writer.UI.FunctionIconButton();
         this.btnStop = new Cabinink.Writer.UI.FunctionIconButton();
         this.btnVolumn = new Cabinink.Writer.UI.FunctionIconButton();
         this.trbVolumn = new MetroFramework.Controls.MetroTrackBar();
         this.tmrShowVol = new System.Windows.Forms.Timer(this.components);
         this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
         this.tmrProcessTick = new System.Windows.Forms.Timer(this.components);
         this.bpdBrowserPath = new Cabinink.Writer.UI.BrowserPathDialog();
         this.cmsPlayList.SuspendLayout();
         this.SuspendLayout();
         // 
         // lstPlayList
         // 
         this.lstPlayList.BackColor = System.Drawing.Color.Gray;
         this.lstPlayList.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.lstPlayList.ContextMenuStrip = this.cmsPlayList;
         this.lstPlayList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.lstPlayList.ForeColor = System.Drawing.Color.White;
         this.lstPlayList.FormattingEnabled = true;
         this.lstPlayList.HorizontalScrollbar = true;
         this.lstPlayList.ItemHeight = 20;
         this.lstPlayList.Location = new System.Drawing.Point(7, 42);
         this.lstPlayList.Name = "lstPlayList";
         this.lstPlayList.ScrollAlwaysVisible = true;
         this.lstPlayList.Size = new System.Drawing.Size(500, 260);
         this.lstPlayList.TabIndex = 0;
         this.lstPlayList.DataSourceChanged += new System.EventHandler(this.lstPlayList_DataSourceChanged);
         this.lstPlayList.DoubleClick += new System.EventHandler(this.lstPlayList_DoubleClick);
         this.lstPlayList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstPlayList_MouseDown);
         // 
         // cmsPlayList
         // 
         this.cmsPlayList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.cmsPlayList.Depth = 0;
         this.cmsPlayList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加文件ToolStripMenuItem,
            this.添加文件夹ToolStripMenuItem,
            this.移除当前文件ToolStripMenuItem});
         this.cmsPlayList.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.cmsPlayList.Name = "cmsPlayList";
         this.cmsPlayList.Size = new System.Drawing.Size(149, 70);
         // 
         // 添加文件ToolStripMenuItem
         // 
         this.添加文件ToolStripMenuItem.Name = "添加文件ToolStripMenuItem";
         this.添加文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
         this.添加文件ToolStripMenuItem.Text = "添加文件...";
         this.添加文件ToolStripMenuItem.Click += new System.EventHandler(this.添加文件ToolStripMenuItem_Click);
         // 
         // 添加文件夹ToolStripMenuItem
         // 
         this.添加文件夹ToolStripMenuItem.Name = "添加文件夹ToolStripMenuItem";
         this.添加文件夹ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
         this.添加文件夹ToolStripMenuItem.Text = "添加文件夹...";
         this.添加文件夹ToolStripMenuItem.Click += new System.EventHandler(this.添加文件夹ToolStripMenuItem_Click);
         // 
         // 移除当前文件ToolStripMenuItem
         // 
         this.移除当前文件ToolStripMenuItem.Name = "移除当前文件ToolStripMenuItem";
         this.移除当前文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
         this.移除当前文件ToolStripMenuItem.Text = "移除当前文件";
         // 
         // trbPlayingProcess
         // 
         this.trbPlayingProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.trbPlayingProcess.Location = new System.Drawing.Point(7, 448);
         this.trbPlayingProcess.Maximum = 1000;
         this.trbPlayingProcess.Name = "trbPlayingProcess";
         this.trbPlayingProcess.Size = new System.Drawing.Size(500, 23);
         this.trbPlayingProcess.TabIndex = 1;
         this.trbPlayingProcess.Text = "metroTrackBar1";
         this.trbPlayingProcess.UseCustomBackColor = true;
         this.trbPlayingProcess.Value = 0;
         this.trbPlayingProcess.ValueChanged += new System.EventHandler(this.trbPlayingProcess_ValueChanged);
         // 
         // lblPlaying
         // 
         this.lblPlaying.FontSize = MetroFramework.MetroLabelSize.Tall;
         this.lblPlaying.Location = new System.Drawing.Point(7, 322);
         this.lblPlaying.Name = "lblPlaying";
         this.lblPlaying.Size = new System.Drawing.Size(500, 23);
         this.lblPlaying.TabIndex = 2;
         this.lblPlaying.Text = "Playing";
         this.lblPlaying.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         this.lblPlaying.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblPlaying.UseCustomBackColor = true;
         // 
         // btnPrevious
         // 
         this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnPrevious.BackgroundImage = global::Cabinink.Properties.Resources.m_previous;
         this.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnPrevious.FlatAppearance.BorderSize = 0;
         this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnPrevious.Location = new System.Drawing.Point(189, 387);
         this.btnPrevious.Name = "btnPrevious";
         this.btnPrevious.Size = new System.Drawing.Size(30, 30);
         this.btnPrevious.TabIndex = 3;
         this.btnPrevious.UseVisualStyleBackColor = false;
         this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
         // 
         // btnPlayAndPause
         // 
         this.btnPlayAndPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnPlayAndPause.BackgroundImage = global::Cabinink.Properties.Resources.m_play;
         this.btnPlayAndPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnPlayAndPause.FlatAppearance.BorderSize = 0;
         this.btnPlayAndPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnPlayAndPause.Location = new System.Drawing.Point(225, 372);
         this.btnPlayAndPause.Name = "btnPlayAndPause";
         this.btnPlayAndPause.Size = new System.Drawing.Size(60, 60);
         this.btnPlayAndPause.TabIndex = 3;
         this.btnPlayAndPause.UseVisualStyleBackColor = false;
         this.btnPlayAndPause.Click += new System.EventHandler(this.btnPlayAndPause_Click);
         // 
         // btnNext
         // 
         this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnNext.BackgroundImage = global::Cabinink.Properties.Resources.m_next;
         this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnNext.FlatAppearance.BorderSize = 0;
         this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnNext.Location = new System.Drawing.Point(291, 387);
         this.btnNext.Name = "btnNext";
         this.btnNext.Size = new System.Drawing.Size(30, 30);
         this.btnNext.TabIndex = 3;
         this.btnNext.UseVisualStyleBackColor = false;
         this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
         // 
         // btnStop
         // 
         this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnStop.BackgroundImage = global::Cabinink.Properties.Resources.m_stop;
         this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnStop.FlatAppearance.BorderSize = 0;
         this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnStop.Location = new System.Drawing.Point(327, 387);
         this.btnStop.Name = "btnStop";
         this.btnStop.Size = new System.Drawing.Size(30, 30);
         this.btnStop.TabIndex = 3;
         this.btnStop.UseVisualStyleBackColor = false;
         this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
         // 
         // btnVolumn
         // 
         this.btnVolumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.btnVolumn.BackgroundImage = global::Cabinink.Properties.Resources.m_volumn;
         this.btnVolumn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnVolumn.FlatAppearance.BorderSize = 0;
         this.btnVolumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnVolumn.Location = new System.Drawing.Point(153, 387);
         this.btnVolumn.Name = "btnVolumn";
         this.btnVolumn.Size = new System.Drawing.Size(30, 30);
         this.btnVolumn.TabIndex = 3;
         this.btnVolumn.UseVisualStyleBackColor = false;
         this.btnVolumn.Visible = false;
         this.btnVolumn.Click += new System.EventHandler(this.btnVolumn_Click);
         // 
         // trbVolumn
         // 
         this.trbVolumn.BackColor = System.Drawing.Color.Transparent;
         this.trbVolumn.Location = new System.Drawing.Point(83, 357);
         this.trbVolumn.Maximum = 10;
         this.trbVolumn.Name = "trbVolumn";
         this.trbVolumn.Size = new System.Drawing.Size(100, 23);
         this.trbVolumn.TabIndex = 4;
         this.trbVolumn.Text = "metroTrackBar1";
         this.trbVolumn.UseCustomBackColor = true;
         this.trbVolumn.Value = 10;
         this.trbVolumn.Visible = false;
         this.trbVolumn.ValueChanged += new System.EventHandler(this.trbVolumn_ValueChanged);
         // 
         // tmrShowVol
         // 
         this.tmrShowVol.Tick += new System.EventHandler(this.tmrShowVol_Tick);
         // 
         // ofdOpenFile
         // 
         this.ofdOpenFile.FileName = "openFileDialog1";
         this.ofdOpenFile.Filter = "支持的文件格式|*.mp3;*.m4a;*.ape;*.flac;*.aac;*.wav;*.wma";
         // 
         // tmrProcessTick
         // 
         this.tmrProcessTick.Enabled = true;
         this.tmrProcessTick.Tick += new System.EventHandler(this.tmrProcessTick_Tick);
         // 
         // bpdBrowserPath
         // 
         this.bpdBrowserPath.DirectoryPath = null;
         // 
         // frmBackgroundMusicConsole
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(514, 476);
         this.Controls.Add(this.trbVolumn);
         this.Controls.Add(this.btnVolumn);
         this.Controls.Add(this.btnStop);
         this.Controls.Add(this.btnNext);
         this.Controls.Add(this.btnPlayAndPause);
         this.Controls.Add(this.btnPrevious);
         this.Controls.Add(this.lblPlaying);
         this.Controls.Add(this.trbPlayingProcess);
         this.Controls.Add(this.lstPlayList);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.Name = "frmBackgroundMusicConsole";
         this.ShowDrawIcon = false;
         this.Text = "背景音乐控制台";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBackgroundMusicConsole_FormClosing);
         this.Load += new System.EventHandler(this.frmBackgroundMusicConsole_Load);
         this.VisibleChanged += new System.EventHandler(this.frmBackgroundMusicConsole_VisibleChanged);
         this.cmsPlayList.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox lstPlayList;
      private MetroFramework.Controls.MetroTrackBar trbPlayingProcess;
      private MetroFramework.Controls.MetroLabel lblPlaying;
      private FunctionIconButton btnPrevious;
      private FunctionIconButton btnPlayAndPause;
      private FunctionIconButton btnNext;
      private FunctionIconButton btnStop;
      private FunctionIconButton btnVolumn;
      private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
      private MetroFramework.Controls.MetroTrackBar trbVolumn;
      private System.Windows.Forms.Timer tmrShowVol;
      private MaterialSkin.Controls.MaterialContextMenuStrip cmsPlayList;
      private System.Windows.Forms.ToolStripMenuItem 添加文件ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 添加文件夹ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 移除当前文件ToolStripMenuItem;
      private System.Windows.Forms.OpenFileDialog ofdOpenFile;
      private System.Windows.Forms.Timer tmrProcessTick;
      private BrowserPathDialog bpdBrowserPath;
   }
}
