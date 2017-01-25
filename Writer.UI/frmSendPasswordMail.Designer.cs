namespace Cabinink.Writer.UI
{
   partial class frmSendPasswordMail
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
         this.label1 = new System.Windows.Forms.Label();
         this.metroButton1 = new MetroFramework.Controls.MetroButton();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.label1.ForeColor = System.Drawing.Color.Silver;
         this.label1.Location = new System.Drawing.Point(21, 57);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(332, 66);
         this.label1.TabIndex = 0;
         this.label1.Text = "忘记密码了？点击下面的按钮，我们将会向您预留的电子邮箱发送一条关于找回密码的邮件，请注意查收！如果长时间未收到，请留意一下垃圾邮件或者重新发送。";
         // 
         // metroButton1
         // 
         this.metroButton1.Location = new System.Drawing.Point(230, 280);
         this.metroButton1.Name = "metroButton1";
         this.metroButton1.Size = new System.Drawing.Size(118, 31);
         this.metroButton1.TabIndex = 1;
         this.metroButton1.Text = "发送邮件";
         this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroButton1.UseSelectable = true;
         this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
         // 
         // frmSendPasswordMail
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(371, 332);
         this.Controls.Add(this.metroButton1);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmSendPasswordMail";
         this.Text = "向预留电子邮箱发送邮件";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private MetroFramework.Controls.MetroButton metroButton1;
   }
}
