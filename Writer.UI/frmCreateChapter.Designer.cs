namespace Cabinink.Writer.UI
{
   partial class frmCreateChapter
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
         this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
         this.cmbSubsections = new MetroFramework.Controls.MetroComboBox();
         this.txtChapter = new MetroFramework.Controls.MetroTextBox();
         this.btnCancel = new MetroFramework.Controls.MetroButton();
         this.btnCreate = new MetroFramework.Controls.MetroButton();
         this.SuspendLayout();
         // 
         // metroLabel1
         // 
         this.metroLabel1.AutoSize = true;
         this.metroLabel1.Location = new System.Drawing.Point(18, 60);
         this.metroLabel1.Name = "metroLabel1";
         this.metroLabel1.Size = new System.Drawing.Size(37, 20);
         this.metroLabel1.TabIndex = 0;
         this.metroLabel1.Text = "分卷";
         this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel1.UseCustomBackColor = true;
         // 
         // metroLabel2
         // 
         this.metroLabel2.AutoSize = true;
         this.metroLabel2.Location = new System.Drawing.Point(18, 104);
         this.metroLabel2.Name = "metroLabel2";
         this.metroLabel2.Size = new System.Drawing.Size(37, 20);
         this.metroLabel2.TabIndex = 0;
         this.metroLabel2.Text = "章节";
         this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel2.UseCustomBackColor = true;
         // 
         // cmbSubsections
         // 
         this.cmbSubsections.FormattingEnabled = true;
         this.cmbSubsections.ItemHeight = 24;
         this.cmbSubsections.Location = new System.Drawing.Point(61, 60);
         this.cmbSubsections.Name = "cmbSubsections";
         this.cmbSubsections.Size = new System.Drawing.Size(314, 30);
         this.cmbSubsections.TabIndex = 1;
         this.cmbSubsections.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.cmbSubsections.UseSelectable = true;
         // 
         // txtChapter
         // 
         this.txtChapter.Lines = new string[0];
         this.txtChapter.Location = new System.Drawing.Point(61, 104);
         this.txtChapter.MaxLength = 32767;
         this.txtChapter.Name = "txtChapter";
         this.txtChapter.PasswordChar = '\0';
         this.txtChapter.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtChapter.SelectedText = "";
         this.txtChapter.Size = new System.Drawing.Size(314, 23);
         this.txtChapter.TabIndex = 2;
         this.txtChapter.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtChapter.UseSelectable = true;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(300, 175);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 28);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "取消(&C)";
         this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnCancel.UseSelectable = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnCreate
         // 
         this.btnCreate.Location = new System.Drawing.Point(219, 175);
         this.btnCreate.Name = "btnCreate";
         this.btnCreate.Size = new System.Drawing.Size(75, 28);
         this.btnCreate.TabIndex = 3;
         this.btnCreate.Text = "创建(&O)";
         this.btnCreate.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnCreate.UseSelectable = true;
         this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
         // 
         // frmCreateChapter
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(398, 222);
         this.Controls.Add(this.btnCreate);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.txtChapter);
         this.Controls.Add(this.cmbSubsections);
         this.Controls.Add(this.metroLabel2);
         this.Controls.Add(this.metroLabel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmCreateChapter";
         this.Text = "创建新章节";
         this.Load += new System.EventHandler(this.frmCreateChapter_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private MetroFramework.Controls.MetroLabel metroLabel1;
      private MetroFramework.Controls.MetroLabel metroLabel2;
      private MetroFramework.Controls.MetroComboBox cmbSubsections;
      private MetroFramework.Controls.MetroTextBox txtChapter;
      private MetroFramework.Controls.MetroButton btnCancel;
      private MetroFramework.Controls.MetroButton btnCreate;
   }
}
