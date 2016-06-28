namespace Cabinink.Writer.UI
{
   partial class VsSkinMessageBoxBase
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
         this.lblTipString = new MetroFramework.Controls.MetroLabel();
         this.SuspendLayout();
         // 
         // lblTipString
         // 
         this.lblTipString.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblTipString.Location = new System.Drawing.Point(24, 62);
         this.lblTipString.Name = "lblTipString";
         this.lblTipString.Size = new System.Drawing.Size(509, 171);
         this.lblTipString.TabIndex = 0;
         this.lblTipString.Text = "Cabinink Writer";
         this.lblTipString.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblTipString.UseCustomBackColor = true;
         this.lblTipString.WrapToLine = true;
         // 
         // VsSkinMessageBoxBase
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(557, 315);
         this.Controls.Add(this.lblTipString);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "VsSkinMessageBoxBase";
         this.ResumeLayout(false);

      }

      #endregion

      private MetroFramework.Controls.MetroLabel lblTipString;
   }
}
