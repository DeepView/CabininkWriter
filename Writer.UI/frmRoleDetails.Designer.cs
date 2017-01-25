namespace Cabinink.Writer.UI
{
   partial class frmRoleDetails
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
         this.rtbRoleDetails = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // rtbRoleDetails
         // 
         this.rtbRoleDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.rtbRoleDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.rtbRoleDetails.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rtbRoleDetails.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.rtbRoleDetails.ForeColor = System.Drawing.Color.Silver;
         this.rtbRoleDetails.Location = new System.Drawing.Point(4, 39);
         this.rtbRoleDetails.Name = "rtbRoleDetails";
         this.rtbRoleDetails.ReadOnly = true;
         this.rtbRoleDetails.Size = new System.Drawing.Size(473, 321);
         this.rtbRoleDetails.TabIndex = 0;
         this.rtbRoleDetails.Text = "";
         // 
         // frmRoleDetails
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(481, 364);
         this.Controls.Add(this.rtbRoleDetails);
         this.MinimumSize = new System.Drawing.Size(317, 266);
         this.Name = "frmRoleDetails";
         this.Text = "角色详细信息";
         this.Load += new System.EventHandler(this.frmRoleDetails_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.RichTextBox rtbRoleDetails;
   }
}
