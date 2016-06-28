using MaterialSkin.Controls;
namespace Cabinink.Writer.UI
{
   partial class frmVerification
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerification));
         this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.btnVerification = new MaterialSkin.Controls.MaterialRaisedButton();
         this.SuspendLayout();
         // 
         // txtPassword
         // 
         this.txtPassword.BackColor = System.Drawing.Color.White;
         this.txtPassword.Depth = 0;
         resources.ApplyResources(this.txtPassword, "txtPassword");
         this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.txtPassword.Hint = "在这里输入密码";
         this.txtPassword.MaxLength = 32767;
         this.txtPassword.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.PasswordChar = '●';
         this.txtPassword.SelectedText = "";
         this.txtPassword.SelectionLength = 0;
         this.txtPassword.SelectionStart = 0;
         this.txtPassword.TabStop = false;
         this.txtPassword.UseSystemPasswordChar = false;
         // 
         // btnVerification
         // 
         this.btnVerification.Depth = 0;
         resources.ApplyResources(this.btnVerification, "btnVerification");
         this.btnVerification.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.btnVerification.Name = "btnVerification";
         this.btnVerification.Primary = true;
         this.btnVerification.UseVisualStyleBackColor = true;
         // 
         // frmVerification
         // 
         this.BackColor = System.Drawing.Color.White;
         resources.ApplyResources(this, "$this");
         this.Controls.Add(this.btnVerification);
         this.Controls.Add(this.txtPassword);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmVerification";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.ResumeLayout(false);

      }

      #endregion

      private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
      private MaterialRaisedButton btnVerification;
      //private MaterialFlatButton materialFlatButton1;
   }
}
