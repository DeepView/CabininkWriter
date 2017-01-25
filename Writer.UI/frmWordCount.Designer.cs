namespace Cabinink.Writer.UI
{
   partial class frmWordCount
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
         this.lblChinese = new MetroFramework.Controls.MetroLabel();
         this.lblEnglish = new MetroFramework.Controls.MetroLabel();
         this.lblAll = new MetroFramework.Controls.MetroLabel();
         this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
         this.SuspendLayout();
         // 
         // lblChinese
         // 
         this.lblChinese.AutoSize = true;
         this.lblChinese.Location = new System.Drawing.Point(27, 59);
         this.lblChinese.Name = "lblChinese";
         this.lblChinese.Size = new System.Drawing.Size(191, 20);
         this.lblChinese.TabIndex = 0;
         this.lblChinese.Text = "中文字符（包含日韩文字）：";
         this.lblChinese.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblChinese.UseCustomBackColor = true;
         // 
         // lblEnglish
         // 
         this.lblEnglish.AutoSize = true;
         this.lblEnglish.Location = new System.Drawing.Point(27, 91);
         this.lblEnglish.Name = "lblEnglish";
         this.lblEnglish.Size = new System.Drawing.Size(205, 20);
         this.lblEnglish.TabIndex = 0;
         this.lblEnglish.Text = "英文字符（包含阿拉伯数字）：";
         this.lblEnglish.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblEnglish.UseCustomBackColor = true;
         // 
         // lblAll
         // 
         this.lblAll.AutoSize = true;
         this.lblAll.Location = new System.Drawing.Point(27, 158);
         this.lblAll.Name = "lblAll";
         this.lblAll.Size = new System.Drawing.Size(79, 20);
         this.lblAll.TabIndex = 0;
         this.lblAll.Text = "所有字符：";
         this.lblAll.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblAll.UseCustomBackColor = true;
         // 
         // materialRaisedButton1
         // 
         this.materialRaisedButton1.Depth = 0;
         this.materialRaisedButton1.Location = new System.Drawing.Point(274, 230);
         this.materialRaisedButton1.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.materialRaisedButton1.Name = "materialRaisedButton1";
         this.materialRaisedButton1.Primary = true;
         this.materialRaisedButton1.Size = new System.Drawing.Size(88, 32);
         this.materialRaisedButton1.TabIndex = 2;
         this.materialRaisedButton1.Text = "确定";
         this.materialRaisedButton1.UseVisualStyleBackColor = true;
         this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
         // 
         // frmWordCount
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(388, 281);
         this.Controls.Add(this.materialRaisedButton1);
         this.Controls.Add(this.lblAll);
         this.Controls.Add(this.lblEnglish);
         this.Controls.Add(this.lblChinese);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.Name = "frmWordCount";
         this.Text = "字符统计";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private MetroFramework.Controls.MetroLabel lblChinese;
      private MetroFramework.Controls.MetroLabel lblEnglish;
      private MetroFramework.Controls.MetroLabel lblAll;
      private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
   }
}
