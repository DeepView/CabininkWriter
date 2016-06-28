namespace Cabinink.Writer.UI
{
   partial class VsSkinExceptionForm
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
         this.lblTitle = new System.Windows.Forms.Label();
         this.lblTipString = new System.Windows.Forms.Label();
         this.rtbStackTrackInfo = new System.Windows.Forms.RichTextBox();
         this.btnClose = new MetroFramework.Controls.MetroButton();
         this.SuspendLayout();
         // 
         // lblTitle
         // 
         this.lblTitle.AutoSize = true;
         this.lblTitle.Font = new System.Drawing.Font("微软雅黑 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.lblTitle.ForeColor = System.Drawing.Color.White;
         this.lblTitle.Location = new System.Drawing.Point(30, 27);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Size = new System.Drawing.Size(158, 31);
         this.lblTitle.TabIndex = 0;
         this.lblTitle.Text = "应用程序异常";
         // 
         // lblTipString
         // 
         this.lblTipString.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.lblTipString.ForeColor = System.Drawing.Color.Silver;
         this.lblTipString.Location = new System.Drawing.Point(33, 67);
         this.lblTipString.Name = "lblTipString";
         this.lblTipString.Size = new System.Drawing.Size(917, 23);
         this.lblTipString.TabIndex = 3;
         this.lblTipString.Text = "非常抱歉，应用程序遇到了无法处理的异常，这个异常可能会导致应用程序处于不稳定工作状态下。如果这个异常频繁出现，请直接给我们的开发者留言！";
         // 
         // rtbStackTrackInfo
         // 
         this.rtbStackTrackInfo.AutoWordSelection = true;
         this.rtbStackTrackInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.rtbStackTrackInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.rtbStackTrackInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.rtbStackTrackInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         this.rtbStackTrackInfo.Location = new System.Drawing.Point(36, 107);
         this.rtbStackTrackInfo.Name = "rtbStackTrackInfo";
         this.rtbStackTrackInfo.ReadOnly = true;
         this.rtbStackTrackInfo.Size = new System.Drawing.Size(914, 428);
         this.rtbStackTrackInfo.TabIndex = 4;
         this.rtbStackTrackInfo.Text = "";
         this.rtbStackTrackInfo.ZoomFactor = 0.95F;
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(784, 564);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(166, 34);
         this.btnClose.TabIndex = 5;
         this.btnClose.Text = "确定并发送异常日志(&E)";
         this.btnClose.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnClose.UseSelectable = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // VsSkinExceptionForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.ClientSize = new System.Drawing.Size(987, 627);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.rtbStackTrackInfo);
         this.Controls.Add(this.lblTipString);
         this.Controls.Add(this.lblTitle);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "VsSkinExceptionForm";
         this.ShowDrawIcon = false;
         this.Text = "";
         this.Load += new System.EventHandler(this.VsSkinExceptionForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblTitle;
      private System.Windows.Forms.Label lblTipString;
      private System.Windows.Forms.RichTextBox rtbStackTrackInfo;
      private MetroFramework.Controls.MetroButton btnClose;
   }
}
