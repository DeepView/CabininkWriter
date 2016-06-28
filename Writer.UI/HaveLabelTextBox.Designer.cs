namespace Cabinink.Writer.UI
{
   partial class HaveLabelTextBox
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

      #region 组件设计器生成的代码

      /// <summary> 
      /// 设计器支持所需的方法 - 不要修改
      /// 使用代码编辑器修改此方法的内容。
      /// </summary>
      private void InitializeComponent()
      {
         this.txtContext = new MetroFramework.Controls.MetroTextBox();
         this.lblLabel = new MetroFramework.Controls.MetroLabel();
         this.SuspendLayout();
         // 
         // txtContext
         // 
         this.txtContext.Lines = new string[0];
         this.txtContext.Location = new System.Drawing.Point(0, 0);
         this.txtContext.MaxLength = 32767;
         this.txtContext.Name = "txtContext";
         this.txtContext.PasswordChar = '\0';
         this.txtContext.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtContext.SelectedText = "";
         this.txtContext.Size = new System.Drawing.Size(82, 23);
         this.txtContext.TabIndex = 0;
         this.txtContext.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtContext.UseSelectable = true;
         // 
         // lblLabel
         // 
         this.lblLabel.AutoSize = true;
         this.lblLabel.Location = new System.Drawing.Point(86, 0);
         this.lblLabel.Name = "lblLabel";
         this.lblLabel.Size = new System.Drawing.Size(42, 20);
         this.lblLabel.TabIndex = 1;
         this.lblLabel.Text = "TEXT";
         this.lblLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblLabel.UseCustomBackColor = true;
         // 
         // HaveLabelTextBox
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Transparent;
         this.Controls.Add(this.lblLabel);
         this.Controls.Add(this.txtContext);
         this.Name = "HaveLabelTextBox";
         this.Size = new System.Drawing.Size(134, 29);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private MetroFramework.Controls.MetroTextBox txtContext;
      private MetroFramework.Controls.MetroLabel lblLabel;
   }
}
