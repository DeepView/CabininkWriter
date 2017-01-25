namespace Cabinink.Writer.UI
{
   partial class frmEula
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
         this.rtbEula = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // rtbEula
         // 
         this.rtbEula.AutoWordSelection = true;
         this.rtbEula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.rtbEula.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.rtbEula.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rtbEula.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.rtbEula.ForeColor = System.Drawing.Color.Silver;
         this.rtbEula.Location = new System.Drawing.Point(4, 39);
         this.rtbEula.Name = "rtbEula";
         this.rtbEula.ReadOnly = true;
         this.rtbEula.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
         this.rtbEula.ShowSelectionMargin = true;
         this.rtbEula.Size = new System.Drawing.Size(701, 398);
         this.rtbEula.TabIndex = 0;
         this.rtbEula.Text = "";
         // 
         // frmEula
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(709, 441);
         this.Controls.Add(this.rtbEula);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmEula";
         this.Text = "软件最终用户许可协议";
         this.Load += new System.EventHandler(this.frmEula_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.RichTextBox rtbEula;
   }
}
