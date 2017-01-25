namespace Cabinink.Writer.UI
{
   partial class VsSkinMessageBoxOkCancel
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
         this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
         this.btnOk = new MetroFramework.Controls.MetroButton();
         this.btnCancel = new MetroFramework.Controls.MetroButton();
         this.metroPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // metroPanel1
         // 
         this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.metroPanel1.Controls.Add(this.btnOk);
         this.metroPanel1.Controls.Add(this.btnCancel);
         this.metroPanel1.HorizontalScrollbarBarColor = true;
         this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
         this.metroPanel1.HorizontalScrollbarSize = 10;
         this.metroPanel1.Location = new System.Drawing.Point(1, 256);
         this.metroPanel1.Name = "metroPanel1";
         this.metroPanel1.Size = new System.Drawing.Size(555, 58);
         this.metroPanel1.TabIndex = 4;
         this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroPanel1.UseCustomBackColor = true;
         this.metroPanel1.VerticalScrollbarBarColor = true;
         this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
         this.metroPanel1.VerticalScrollbarSize = 10;
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(377, 18);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 2;
         this.btnOk.Text = "确定(&E)";
         this.btnOk.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnOk.UseSelectable = true;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(458, 18);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "取消(&C)";
         this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnCancel.UseSelectable = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // VsSkinMessageBoxOkCancel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(557, 315);
         this.Controls.Add(this.metroPanel1);
         this.Name = "VsSkinMessageBoxOkCancel";
         this.Controls.SetChildIndex(this.metroPanel1, 0);
         this.metroPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private MetroFramework.Controls.MetroPanel metroPanel1;
      private MetroFramework.Controls.MetroButton btnCancel;
      private MetroFramework.Controls.MetroButton btnOk;
   }
}
