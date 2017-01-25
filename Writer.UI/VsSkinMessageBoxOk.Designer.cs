namespace Cabinink.Writer.UI
{
   partial class VsSkinMessageBoxOk
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
         this.btnOk = new MetroFramework.Controls.MetroButton();
         this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
         this.metroPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(458, 18);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 2;
         this.btnOk.Text = "确定(&E)";
         this.btnOk.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnOk.UseSelectable = true;
         this.btnOk.Click += new System.EventHandler(this.metroButton1_Click);
         // 
         // metroPanel1
         // 
         this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.metroPanel1.Controls.Add(this.btnOk);
         this.metroPanel1.HorizontalScrollbarBarColor = true;
         this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
         this.metroPanel1.HorizontalScrollbarSize = 10;
         this.metroPanel1.Location = new System.Drawing.Point(1, 256);
         this.metroPanel1.Name = "metroPanel1";
         this.metroPanel1.Size = new System.Drawing.Size(555, 58);
         this.metroPanel1.TabIndex = 3;
         this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroPanel1.UseCustomBackColor = true;
         this.metroPanel1.VerticalScrollbarBarColor = true;
         this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
         this.metroPanel1.VerticalScrollbarSize = 10;
         // 
         // VsSkinMessageBoxOk
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(557, 315);
         this.Controls.Add(this.metroPanel1);
         this.Name = "VsSkinMessageBoxOk";
         this.Controls.SetChildIndex(this.metroPanel1, 0);
         this.metroPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private MetroFramework.Controls.MetroButton btnOk;
      private MetroFramework.Controls.MetroPanel metroPanel1;
   }
}
