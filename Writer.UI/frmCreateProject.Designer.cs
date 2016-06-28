namespace Cabinink.Writer.UI
{
   partial class frmCreateProject
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
         this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
         this.txtProjectName = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
         this.txtNovelName = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
         this.txtWriter = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
         this.cmbCategory = new MetroFramework.Controls.MetroComboBox();
         this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
         this.txtCreateDate = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
         this.txtKeywords = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
         this.txtSavedPath = new MetroFramework.Controls.MetroTextBox();
         this.lblProjectName = new MetroFramework.Controls.MetroLabel();
         this.btnBrowser = new MetroFramework.Controls.MetroButton();
         this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
         this.txtInfo = new MetroFramework.Controls.MetroTextBox();
         this.btnCreate = new MetroFramework.Controls.MetroButton();
         this.btnCancel = new MetroFramework.Controls.MetroButton();
         this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
         this.cmbSubsectionNumber = new MetroFramework.Controls.MetroComboBox();
         this.cmbChapterNumber = new MetroFramework.Controls.MetroComboBox();
         this.bpdSaved = new Cabinink.Writer.UI.BrowserPathDialog();
         this.SuspendLayout();
         // 
         // metroLabel1
         // 
         this.metroLabel1.AutoSize = true;
         this.metroLabel1.Location = new System.Drawing.Point(18, 58);
         this.metroLabel1.Name = "metroLabel1";
         this.metroLabel1.Size = new System.Drawing.Size(65, 20);
         this.metroLabel1.TabIndex = 0;
         this.metroLabel1.Text = "项目名称";
         this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel1.UseCustomBackColor = true;
         // 
         // txtProjectName
         // 
         this.txtProjectName.Lines = new string[0];
         this.txtProjectName.Location = new System.Drawing.Point(89, 58);
         this.txtProjectName.MaxLength = 32767;
         this.txtProjectName.Name = "txtProjectName";
         this.txtProjectName.PasswordChar = '\0';
         this.txtProjectName.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtProjectName.SelectedText = "";
         this.txtProjectName.Size = new System.Drawing.Size(244, 23);
         this.txtProjectName.TabIndex = 0;
         this.txtProjectName.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtProjectName.UseSelectable = true;
         this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
         // 
         // metroLabel2
         // 
         this.metroLabel2.AutoSize = true;
         this.metroLabel2.Location = new System.Drawing.Point(18, 92);
         this.metroLabel2.Name = "metroLabel2";
         this.metroLabel2.Size = new System.Drawing.Size(65, 20);
         this.metroLabel2.TabIndex = 0;
         this.metroLabel2.Text = "作品名称";
         this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel2.UseCustomBackColor = true;
         // 
         // txtNovelName
         // 
         this.txtNovelName.Lines = new string[0];
         this.txtNovelName.Location = new System.Drawing.Point(89, 92);
         this.txtNovelName.MaxLength = 32767;
         this.txtNovelName.Name = "txtNovelName";
         this.txtNovelName.PasswordChar = '\0';
         this.txtNovelName.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtNovelName.SelectedText = "";
         this.txtNovelName.Size = new System.Drawing.Size(244, 23);
         this.txtNovelName.TabIndex = 1;
         this.txtNovelName.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtNovelName.UseSelectable = true;
         // 
         // metroLabel3
         // 
         this.metroLabel3.AutoSize = true;
         this.metroLabel3.Location = new System.Drawing.Point(18, 126);
         this.metroLabel3.Name = "metroLabel3";
         this.metroLabel3.Size = new System.Drawing.Size(65, 20);
         this.metroLabel3.TabIndex = 0;
         this.metroLabel3.Text = "作者笔名";
         this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel3.UseCustomBackColor = true;
         // 
         // txtWriter
         // 
         this.txtWriter.Lines = new string[0];
         this.txtWriter.Location = new System.Drawing.Point(89, 126);
         this.txtWriter.MaxLength = 32767;
         this.txtWriter.Name = "txtWriter";
         this.txtWriter.PasswordChar = '\0';
         this.txtWriter.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtWriter.SelectedText = "";
         this.txtWriter.Size = new System.Drawing.Size(244, 23);
         this.txtWriter.TabIndex = 2;
         this.txtWriter.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtWriter.UseSelectable = true;
         // 
         // metroLabel4
         // 
         this.metroLabel4.AutoSize = true;
         this.metroLabel4.Location = new System.Drawing.Point(368, 58);
         this.metroLabel4.Name = "metroLabel4";
         this.metroLabel4.Size = new System.Drawing.Size(65, 20);
         this.metroLabel4.TabIndex = 0;
         this.metroLabel4.Text = "作品分类";
         this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel4.UseCustomBackColor = true;
         // 
         // cmbCategory
         // 
         this.cmbCategory.FontSize = MetroFramework.MetroComboBoxSize.Small;
         this.cmbCategory.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
         this.cmbCategory.FormattingEnabled = true;
         this.cmbCategory.ItemHeight = 21;
         this.cmbCategory.Items.AddRange(new object[] {
            "玄幻",
            "都市",
            "修真",
            "武侠",
            "军事",
            "历史",
            "网游",
            "科幻",
            "竞技",
            "体育",
            "灵异",
            "推理",
            "同人",
            "恐怖",
            "穿越",
            "其他"});
         this.cmbCategory.Location = new System.Drawing.Point(439, 58);
         this.cmbCategory.Name = "cmbCategory";
         this.cmbCategory.Size = new System.Drawing.Size(244, 27);
         this.cmbCategory.TabIndex = 3;
         this.cmbCategory.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.cmbCategory.UseSelectable = true;
         // 
         // metroLabel5
         // 
         this.metroLabel5.AutoSize = true;
         this.metroLabel5.Location = new System.Drawing.Point(368, 92);
         this.metroLabel5.Name = "metroLabel5";
         this.metroLabel5.Size = new System.Drawing.Size(65, 20);
         this.metroLabel5.TabIndex = 0;
         this.metroLabel5.Text = "创作日期";
         this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel5.UseCustomBackColor = true;
         // 
         // txtCreateDate
         // 
         this.txtCreateDate.Lines = new string[0];
         this.txtCreateDate.Location = new System.Drawing.Point(439, 92);
         this.txtCreateDate.MaxLength = 32767;
         this.txtCreateDate.Name = "txtCreateDate";
         this.txtCreateDate.PasswordChar = '\0';
         this.txtCreateDate.ReadOnly = true;
         this.txtCreateDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtCreateDate.SelectedText = "";
         this.txtCreateDate.Size = new System.Drawing.Size(244, 23);
         this.txtCreateDate.TabIndex = 4;
         this.txtCreateDate.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtCreateDate.UseSelectable = true;
         // 
         // metroLabel6
         // 
         this.metroLabel6.AutoSize = true;
         this.metroLabel6.Location = new System.Drawing.Point(368, 126);
         this.metroLabel6.Name = "metroLabel6";
         this.metroLabel6.Size = new System.Drawing.Size(51, 20);
         this.metroLabel6.TabIndex = 0;
         this.metroLabel6.Text = "关键词";
         this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel6.UseCustomBackColor = true;
         // 
         // txtKeywords
         // 
         this.txtKeywords.Lines = new string[] {
        "多个关键词之间请用英文逗号分隔"};
         this.txtKeywords.Location = new System.Drawing.Point(439, 126);
         this.txtKeywords.MaxLength = 32767;
         this.txtKeywords.Name = "txtKeywords";
         this.txtKeywords.PasswordChar = '\0';
         this.txtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtKeywords.SelectedText = "";
         this.txtKeywords.Size = new System.Drawing.Size(244, 23);
         this.txtKeywords.TabIndex = 5;
         this.txtKeywords.Text = "多个关键词之间请用英文逗号分隔";
         this.txtKeywords.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtKeywords.UseSelectable = true;
         this.txtKeywords.Click += new System.EventHandler(this.txtKeywords_Click);
         // 
         // metroLabel7
         // 
         this.metroLabel7.AutoSize = true;
         this.metroLabel7.Location = new System.Drawing.Point(18, 317);
         this.metroLabel7.Name = "metroLabel7";
         this.metroLabel7.Size = new System.Drawing.Size(65, 20);
         this.metroLabel7.TabIndex = 0;
         this.metroLabel7.Text = "保存路径";
         this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel7.UseCustomBackColor = true;
         // 
         // txtSavedPath
         // 
         this.txtSavedPath.Lines = new string[] {
        "E:\\CiWriterSolution"};
         this.txtSavedPath.Location = new System.Drawing.Point(89, 317);
         this.txtSavedPath.MaxLength = 32767;
         this.txtSavedPath.Name = "txtSavedPath";
         this.txtSavedPath.PasswordChar = '\0';
         this.txtSavedPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtSavedPath.SelectedText = "";
         this.txtSavedPath.Size = new System.Drawing.Size(273, 23);
         this.txtSavedPath.TabIndex = 7;
         this.txtSavedPath.Text = "E:\\CiWriterSolution";
         this.txtSavedPath.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtSavedPath.UseSelectable = true;
         // 
         // lblProjectName
         // 
         this.lblProjectName.BackColor = System.Drawing.Color.Black;
         this.lblProjectName.Location = new System.Drawing.Point(361, 318);
         this.lblProjectName.Name = "lblProjectName";
         this.lblProjectName.Size = new System.Drawing.Size(231, 21);
         this.lblProjectName.TabIndex = 0;
         this.lblProjectName.Text = "\\";
         this.lblProjectName.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblProjectName.UseCustomBackColor = true;
         // 
         // btnBrowser
         // 
         this.btnBrowser.Location = new System.Drawing.Point(598, 317);
         this.btnBrowser.Name = "btnBrowser";
         this.btnBrowser.Size = new System.Drawing.Size(85, 23);
         this.btnBrowser.TabIndex = 8;
         this.btnBrowser.Text = "浏览(&M)...";
         this.btnBrowser.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnBrowser.UseSelectable = true;
         this.btnBrowser.Click += new System.EventHandler(this.metroButton1_Click);
         // 
         // metroLabel8
         // 
         this.metroLabel8.AutoSize = true;
         this.metroLabel8.Location = new System.Drawing.Point(18, 160);
         this.metroLabel8.Name = "metroLabel8";
         this.metroLabel8.Size = new System.Drawing.Size(65, 20);
         this.metroLabel8.TabIndex = 0;
         this.metroLabel8.Text = "详细信息";
         this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel8.UseCustomBackColor = true;
         // 
         // txtInfo
         // 
         this.txtInfo.Lines = new string[0];
         this.txtInfo.Location = new System.Drawing.Point(89, 160);
         this.txtInfo.MaxLength = 32767;
         this.txtInfo.Multiline = true;
         this.txtInfo.Name = "txtInfo";
         this.txtInfo.PasswordChar = '\0';
         this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtInfo.SelectedText = "";
         this.txtInfo.Size = new System.Drawing.Size(594, 146);
         this.txtInfo.TabIndex = 6;
         this.txtInfo.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtInfo.UseSelectable = true;
         // 
         // btnCreate
         // 
         this.btnCreate.Location = new System.Drawing.Point(510, 413);
         this.btnCreate.Name = "btnCreate";
         this.btnCreate.Size = new System.Drawing.Size(82, 25);
         this.btnCreate.TabIndex = 11;
         this.btnCreate.Text = "创建(&C)";
         this.btnCreate.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnCreate.UseSelectable = true;
         this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(601, 413);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(82, 25);
         this.btnCancel.TabIndex = 12;
         this.btnCancel.Text = "取消(&A)";
         this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnCancel.UseSelectable = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // metroLabel9
         // 
         this.metroLabel9.AutoSize = true;
         this.metroLabel9.Location = new System.Drawing.Point(18, 352);
         this.metroLabel9.Name = "metroLabel9";
         this.metroLabel9.Size = new System.Drawing.Size(93, 20);
         this.metroLabel9.TabIndex = 0;
         this.metroLabel9.Text = "分卷编号样式";
         this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel9.UseCustomBackColor = true;
         // 
         // metroLabel10
         // 
         this.metroLabel10.AutoSize = true;
         this.metroLabel10.Location = new System.Drawing.Point(368, 352);
         this.metroLabel10.Name = "metroLabel10";
         this.metroLabel10.Size = new System.Drawing.Size(93, 20);
         this.metroLabel10.TabIndex = 0;
         this.metroLabel10.Text = "章节编号样式";
         this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel10.UseCustomBackColor = true;
         // 
         // cmbSubsectionNumber
         // 
         this.cmbSubsectionNumber.FontSize = MetroFramework.MetroComboBoxSize.Small;
         this.cmbSubsectionNumber.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
         this.cmbSubsectionNumber.FormattingEnabled = true;
         this.cmbSubsectionNumber.ItemHeight = 21;
         this.cmbSubsectionNumber.Items.AddRange(new object[] {
            "第三十二卷",
            "卷三十二",
            "Subsection 32"});
         this.cmbSubsectionNumber.Location = new System.Drawing.Point(117, 352);
         this.cmbSubsectionNumber.Name = "cmbSubsectionNumber";
         this.cmbSubsectionNumber.Size = new System.Drawing.Size(216, 27);
         this.cmbSubsectionNumber.TabIndex = 9;
         this.cmbSubsectionNumber.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.cmbSubsectionNumber.UseSelectable = true;
         // 
         // cmbChapterNumber
         // 
         this.cmbChapterNumber.FontSize = MetroFramework.MetroComboBoxSize.Small;
         this.cmbChapterNumber.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
         this.cmbChapterNumber.FormattingEnabled = true;
         this.cmbChapterNumber.ItemHeight = 21;
         this.cmbChapterNumber.Items.AddRange(new object[] {
            "128",
            "Chapter 128",
            "章128",
            "节128",
            "第128章",
            "第128节",
            "一百二十八",
            "章一百二十八",
            "节一百二十八",
            "第一百二十八章",
            "第一百二十八节"});
         this.cmbChapterNumber.Location = new System.Drawing.Point(467, 352);
         this.cmbChapterNumber.Name = "cmbChapterNumber";
         this.cmbChapterNumber.Size = new System.Drawing.Size(216, 27);
         this.cmbChapterNumber.TabIndex = 10;
         this.cmbChapterNumber.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.cmbChapterNumber.UseSelectable = true;
         // 
         // bpdSaved
         // 
         this.bpdSaved.DirectoryPath = null;
         // 
         // frmCreateProject
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.CanResize = false;
         this.ClientSize = new System.Drawing.Size(709, 457);
         this.Controls.Add(this.cmbChapterNumber);
         this.Controls.Add(this.cmbSubsectionNumber);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnCreate);
         this.Controls.Add(this.btnBrowser);
         this.Controls.Add(this.cmbCategory);
         this.Controls.Add(this.metroLabel4);
         this.Controls.Add(this.txtKeywords);
         this.Controls.Add(this.txtSavedPath);
         this.Controls.Add(this.txtInfo);
         this.Controls.Add(this.txtWriter);
         this.Controls.Add(this.metroLabel8);
         this.Controls.Add(this.metroLabel7);
         this.Controls.Add(this.metroLabel3);
         this.Controls.Add(this.lblProjectName);
         this.Controls.Add(this.metroLabel10);
         this.Controls.Add(this.metroLabel9);
         this.Controls.Add(this.metroLabel6);
         this.Controls.Add(this.metroLabel5);
         this.Controls.Add(this.txtCreateDate);
         this.Controls.Add(this.txtNovelName);
         this.Controls.Add(this.metroLabel2);
         this.Controls.Add(this.txtProjectName);
         this.Controls.Add(this.metroLabel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmCreateProject";
         this.Text = "创建作品";
         this.Load += new System.EventHandler(this.frmCreateProject_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private MetroFramework.Controls.MetroLabel metroLabel1;
      private MetroFramework.Controls.MetroTextBox txtProjectName;
      private MetroFramework.Controls.MetroLabel metroLabel2;
      private MetroFramework.Controls.MetroTextBox txtNovelName;
      private MetroFramework.Controls.MetroLabel metroLabel3;
      private MetroFramework.Controls.MetroTextBox txtWriter;
      private MetroFramework.Controls.MetroLabel metroLabel4;
      private MetroFramework.Controls.MetroComboBox cmbCategory;
      private MetroFramework.Controls.MetroLabel metroLabel5;
      private MetroFramework.Controls.MetroTextBox txtCreateDate;
      private MetroFramework.Controls.MetroLabel metroLabel6;
      private MetroFramework.Controls.MetroTextBox txtKeywords;
      private MetroFramework.Controls.MetroLabel metroLabel7;
      private MetroFramework.Controls.MetroTextBox txtSavedPath;
      private MetroFramework.Controls.MetroLabel lblProjectName;
      private MetroFramework.Controls.MetroButton btnBrowser;
      private MetroFramework.Controls.MetroLabel metroLabel8;
      private MetroFramework.Controls.MetroTextBox txtInfo;
      private MetroFramework.Controls.MetroButton btnCreate;
      private MetroFramework.Controls.MetroButton btnCancel;
      private MetroFramework.Controls.MetroLabel metroLabel9;
      private MetroFramework.Controls.MetroLabel metroLabel10;
      private MetroFramework.Controls.MetroComboBox cmbSubsectionNumber;
      private MetroFramework.Controls.MetroComboBox cmbChapterNumber;
      private BrowserPathDialog bpdSaved;
   }
}
