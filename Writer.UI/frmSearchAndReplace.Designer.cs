namespace Cabinink.Writer.UI
{
   partial class frmSearchAndReplace
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchAndReplace));
         this.tcMain = new MetroFramework.Controls.MetroTabControl();
         this.tpSearch = new System.Windows.Forms.TabPage();
         this.btnFoundUp = new MetroFramework.Controls.MetroButton();
         this.btnFoundDown = new MetroFramework.Controls.MetroButton();
         this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
         this.tpReplace = new System.Windows.Forms.TabPage();
         this.btnReplaceUp = new MetroFramework.Controls.MetroButton();
         this.btnReplaceDown = new MetroFramework.Controls.MetroButton();
         this.btnReplace = new MetroFramework.Controls.MetroButton();
         this.btnReplaceAll = new MetroFramework.Controls.MetroButton();
         this.txtSearch = new MetroFramework.Controls.MetroTextBox();
         this.txtReplace = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
         this.tcMain.SuspendLayout();
         this.tpSearch.SuspendLayout();
         this.tpReplace.SuspendLayout();
         this.SuspendLayout();
         // 
         // tcMain
         // 
         this.tcMain.Controls.Add(this.tpSearch);
         this.tcMain.Controls.Add(this.tpReplace);
         this.tcMain.Location = new System.Drawing.Point(1, 40);
         this.tcMain.Name = "tcMain";
         this.tcMain.SelectedIndex = 0;
         this.tcMain.Size = new System.Drawing.Size(472, 219);
         this.tcMain.TabIndex = 2;
         this.tcMain.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.tcMain.UseSelectable = true;
         // 
         // tpSearch
         // 
         this.tpSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.tpSearch.Controls.Add(this.btnFoundUp);
         this.tpSearch.Controls.Add(this.btnFoundDown);
         this.tpSearch.Controls.Add(this.metroTextBox1);
         this.tpSearch.Controls.Add(this.metroLabel3);
         this.tpSearch.Location = new System.Drawing.Point(4, 39);
         this.tpSearch.Name = "tpSearch";
         this.tpSearch.Size = new System.Drawing.Size(464, 176);
         this.tpSearch.TabIndex = 0;
         this.tpSearch.Text = "查找";
         // 
         // btnFoundUp
         // 
         this.btnFoundUp.Location = new System.Drawing.Point(273, 141);
         this.btnFoundUp.Name = "btnFoundUp";
         this.btnFoundUp.Size = new System.Drawing.Size(84, 25);
         this.btnFoundUp.TabIndex = 12;
         this.btnFoundUp.Text = "查找上一个";
         this.btnFoundUp.UseSelectable = true;
         // 
         // btnFoundDown
         // 
         this.btnFoundDown.Location = new System.Drawing.Point(365, 141);
         this.btnFoundDown.Name = "btnFoundDown";
         this.btnFoundDown.Size = new System.Drawing.Size(84, 25);
         this.btnFoundDown.TabIndex = 11;
         this.btnFoundDown.Text = "查找下一个";
         this.btnFoundDown.UseSelectable = true;
         // 
         // metroTextBox1
         // 
         this.metroTextBox1.Lines = new string[0];
         this.metroTextBox1.Location = new System.Drawing.Point(93, 13);
         this.metroTextBox1.MaxLength = 255;
         this.metroTextBox1.Name = "metroTextBox1";
         this.metroTextBox1.PasswordChar = '\0';
         this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.metroTextBox1.SelectedText = "";
         this.metroTextBox1.Size = new System.Drawing.Size(357, 23);
         this.metroTextBox1.TabIndex = 10;
         this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroTextBox1.UseSelectable = true;
         // 
         // metroLabel3
         // 
         this.metroLabel3.AutoSize = true;
         this.metroLabel3.Location = new System.Drawing.Point(12, 13);
         this.metroLabel3.Name = "metroLabel3";
         this.metroLabel3.Size = new System.Drawing.Size(65, 20);
         this.metroLabel3.TabIndex = 9;
         this.metroLabel3.Text = "查找内容";
         this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel3.UseCustomBackColor = true;
         // 
         // tpReplace
         // 
         this.tpReplace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.tpReplace.Controls.Add(this.btnReplaceUp);
         this.tpReplace.Controls.Add(this.btnReplaceDown);
         this.tpReplace.Controls.Add(this.btnReplace);
         this.tpReplace.Controls.Add(this.btnReplaceAll);
         this.tpReplace.Controls.Add(this.txtSearch);
         this.tpReplace.Controls.Add(this.txtReplace);
         this.tpReplace.Controls.Add(this.metroLabel2);
         this.tpReplace.Controls.Add(this.metroLabel1);
         this.tpReplace.Location = new System.Drawing.Point(4, 39);
         this.tpReplace.Name = "tpReplace";
         this.tpReplace.Size = new System.Drawing.Size(464, 176);
         this.tpReplace.TabIndex = 1;
         this.tpReplace.Text = "替换";
         // 
         // btnReplaceUp
         // 
         this.btnReplaceUp.Location = new System.Drawing.Point(89, 141);
         this.btnReplaceUp.Name = "btnReplaceUp";
         this.btnReplaceUp.Size = new System.Drawing.Size(84, 25);
         this.btnReplaceUp.TabIndex = 13;
         this.btnReplaceUp.Text = "查找上一个";
         this.btnReplaceUp.UseSelectable = true;
         // 
         // btnReplaceDown
         // 
         this.btnReplaceDown.Location = new System.Drawing.Point(181, 141);
         this.btnReplaceDown.Name = "btnReplaceDown";
         this.btnReplaceDown.Size = new System.Drawing.Size(84, 25);
         this.btnReplaceDown.TabIndex = 12;
         this.btnReplaceDown.Text = "查找下一个";
         this.btnReplaceDown.UseSelectable = true;
         // 
         // btnReplace
         // 
         this.btnReplace.Location = new System.Drawing.Point(273, 141);
         this.btnReplace.Name = "btnReplace";
         this.btnReplace.Size = new System.Drawing.Size(84, 25);
         this.btnReplace.TabIndex = 11;
         this.btnReplace.Text = "替换选中项";
         this.btnReplace.UseSelectable = true;
         // 
         // btnReplaceAll
         // 
         this.btnReplaceAll.Location = new System.Drawing.Point(365, 141);
         this.btnReplaceAll.Name = "btnReplaceAll";
         this.btnReplaceAll.Size = new System.Drawing.Size(84, 25);
         this.btnReplaceAll.TabIndex = 10;
         this.btnReplaceAll.Text = "全部替换";
         this.btnReplaceAll.UseSelectable = true;
         // 
         // txtSearch
         // 
         this.txtSearch.Lines = new string[0];
         this.txtSearch.Location = new System.Drawing.Point(93, 13);
         this.txtSearch.MaxLength = 255;
         this.txtSearch.Name = "txtSearch";
         this.txtSearch.PasswordChar = '\0';
         this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtSearch.SelectedText = "";
         this.txtSearch.Size = new System.Drawing.Size(357, 23);
         this.txtSearch.TabIndex = 8;
         this.txtSearch.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtSearch.UseSelectable = true;
         // 
         // txtReplace
         // 
         this.txtReplace.Lines = new string[0];
         this.txtReplace.Location = new System.Drawing.Point(93, 53);
         this.txtReplace.MaxLength = 255;
         this.txtReplace.Name = "txtReplace";
         this.txtReplace.PasswordChar = '\0';
         this.txtReplace.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtReplace.SelectedText = "";
         this.txtReplace.Size = new System.Drawing.Size(357, 23);
         this.txtReplace.TabIndex = 9;
         this.txtReplace.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtReplace.UseSelectable = true;
         // 
         // metroLabel2
         // 
         this.metroLabel2.AutoSize = true;
         this.metroLabel2.Location = new System.Drawing.Point(12, 53);
         this.metroLabel2.Name = "metroLabel2";
         this.metroLabel2.Size = new System.Drawing.Size(51, 20);
         this.metroLabel2.TabIndex = 6;
         this.metroLabel2.Text = "替换为";
         this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel2.UseCustomBackColor = true;
         // 
         // metroLabel1
         // 
         this.metroLabel1.AutoSize = true;
         this.metroLabel1.Location = new System.Drawing.Point(12, 13);
         this.metroLabel1.Name = "metroLabel1";
         this.metroLabel1.Size = new System.Drawing.Size(65, 20);
         this.metroLabel1.TabIndex = 7;
         this.metroLabel1.Text = "查找内容";
         this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel1.UseCustomBackColor = true;
         // 
         // frmSearchAndReplace
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(474, 260);
         this.Controls.Add(this.tcMain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "frmSearchAndReplace";
         this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
         this.Text = "查找与替换";
         this.TopMost = true;
         this.tcMain.ResumeLayout(false);
         this.tpSearch.ResumeLayout(false);
         this.tpSearch.PerformLayout();
         this.tpReplace.ResumeLayout(false);
         this.tpReplace.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion
      private MetroFramework.Controls.MetroTabControl tcMain;
      private System.Windows.Forms.TabPage tpSearch;
      private System.Windows.Forms.TabPage tpReplace;
      private MetroFramework.Controls.MetroLabel metroLabel3;
      private MetroFramework.Controls.MetroTextBox txtSearch;
      private MetroFramework.Controls.MetroTextBox txtReplace;
      private MetroFramework.Controls.MetroLabel metroLabel1;
      private MetroFramework.Controls.MetroLabel metroLabel2;
      private MetroFramework.Controls.MetroTextBox metroTextBox1;
      private MetroFramework.Controls.MetroButton btnReplaceAll;
      private MetroFramework.Controls.MetroButton btnReplace;
      private MetroFramework.Controls.MetroButton btnReplaceUp;
      private MetroFramework.Controls.MetroButton btnReplaceDown;
      private MetroFramework.Controls.MetroButton btnFoundDown;
      private MetroFramework.Controls.MetroButton btnFoundUp;
   }
}
