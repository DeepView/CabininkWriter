namespace Cabinink.Writer.UI
{
   partial class VsSkinInputBox
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
         this.txtData = new MetroFramework.Controls.MetroTextBox();
         this.btnOkey = new MetroFramework.Controls.MetroButton();
         this.btnCancel = new MetroFramework.Controls.MetroButton();
         this.lblTipString = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // txtData
         // 
         this.txtData.Lines = new string[0];
         this.txtData.Location = new System.Drawing.Point(17, 128);
         this.txtData.MaxLength = 32767;
         this.txtData.Name = "txtData";
         this.txtData.PasswordChar = '\0';
         this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtData.SelectedText = "";
         this.txtData.Size = new System.Drawing.Size(526, 23);
         this.txtData.TabIndex = 1;
         this.txtData.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtData.UseSelectable = true;
         // 
         // btnOkey
         // 
         this.btnOkey.Location = new System.Drawing.Point(371, 303);
         this.btnOkey.Name = "btnOkey";
         this.btnOkey.Size = new System.Drawing.Size(81, 29);
         this.btnOkey.TabIndex = 2;
         this.btnOkey.Text = "确认(&O)";
         this.btnOkey.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnOkey.UseSelectable = true;
         this.btnOkey.Click += new System.EventHandler(this.btnOkey_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(462, 303);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(81, 29);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "取消(&C)";
         this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnCancel.UseSelectable = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // lblTipString
         // 
         this.lblTipString.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.lblTipString.ForeColor = System.Drawing.Color.DarkGray;
         this.lblTipString.Location = new System.Drawing.Point(15, 56);
         this.lblTipString.Name = "lblTipString";
         this.lblTipString.Size = new System.Drawing.Size(528, 59);
         this.lblTipString.TabIndex = 3;
         this.lblTipString.Text = "请在下面的文本框中输入文本，如果文本确认无误则单击“确认(O)”接受当前输入的文本，否则请单击“取消(C)”。";
         // 
         // VsSkinInputBox
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(560, 352);
         this.Controls.Add(this.lblTipString);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOkey);
         this.Controls.Add(this.txtData);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "VsSkinInputBox";
         this.ResumeLayout(false);

      }

      #endregion
      private MetroFramework.Controls.MetroTextBox txtData;
      private MetroFramework.Controls.MetroButton btnOkey;
      private MetroFramework.Controls.MetroButton btnCancel;
      private System.Windows.Forms.Label lblTipString;
   }
}
