using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Cabinink.Writer.Cores;
using System.Data.SQLite;

namespace Cabinink.Writer.UI
{
   public partial class frmLogin : Cabinink.Writer.UI.VsSkinFormBase
   {

      private bool iscomplate = false;
      private frmMainInterface owner;
      private Image image;
      private Graphics graphics;

      public frmLogin()
      {
         InitializeComponent();
         graphics = picAccountAvater.CreateGraphics();
      }
      #region "GetCurrentWindowsUserAvatar"
      [Obsolete("方法 GetCurrentWindowsUserAvatarUri() 暂时不会使用！")]
      public string GetCurrentWindowsUserAvatarUri()
      {
         RegistryKey key = Registry.CurrentUser;
         RegistryKey mkey = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\AccountPicture");
         string fname = mkey.GetValue("AccountPicture").ToString();
         key.Close();
         mkey.Close();
         string ua_suburi = @"\AppData\Roaming\Microsoft\Windows\AccountPictures\" + fname + ".accountpicture-ms";
         return GetOperatingSystemDriverId() + @"\Users\" + GetCurrentWindowsUserName() + @"\" + ua_suburi;
      }
      [Obsolete("方法 GetCurrentWindowsUserName() 暂时不会使用！")]
      public string GetCurrentWindowsUserName()
      {
         return Environment.UserName;
      }
      [Obsolete("方法 GetOperatingSystemDriverId() 暂时不会使用！")]
      public string GetOperatingSystemDriverId()//获取当前操作系统所在分区的编号，比如C:
      {
         return Environment.SystemDirectory.Substring(0, 2);
      }
      #endregion

      public DialogResult DisplayDialog(frmMainInterface _owner)
      {
         owner = _owner;
         return ShowDialog(_owner);
      }
      private void materialRaisedButton1_Click(object sender, EventArgs e)   //------LOGIN_METHOD------//
      {
         UserCredential credential_local = new UserCredential(Environment.UserName, txtPassword.Text);
         string username_db = credential_local.UserName + @"' and ";
         string passwd_db = @"_passwd='" + credential_local.Password + @"'";
         string sql = @"select _user from userinfo where _user='" + username_db + passwd_db;
         SQLiteDataReader reader;
         DatabaseOperation dbopt = new DatabaseOperation("Data Source=databases\\users.db");
         dbopt.InitializeConnection();
         dbopt.Connect();
         reader = dbopt.InvokeSqlToReader(sql);
         if (reader.HasRows == true)
         {
            iscomplate = true;
            Close();
         }
         else
         {
            VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("登录失败", "用户凭据不正确，请确保您是否使用的已注册Windows账户或正确的密码！", EMessageLevel.Error);
            msg.Display(this);
         }
      }

      private void lnkFoundPassword_Click(object sender, EventArgs e)
      {
         //frmUpgradeCredential rstpasswd = new frmUpgradeCredential();
         //rstpasswd.ShowDialog();
         frmSendPasswordMail sendpswmail = new frmSendPasswordMail();
         sendpswmail.ShowDialog(this);
      }

      private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (iscomplate == false) owner.SecurityFlag = false;
      }

      private void frmLogin_Load(object sender, EventArgs e)
      {
         string username = Environment.UserName;
         string sysvol = Environment.SystemDirectory.Substring(0, 3);
         string pic = sysvol + @"Users\" + username + @"\ciwriter_avater.jpg";
         image = Image.FromFile(pic);
         if (FileOperation.FileExists(pic))
         {
            image = Image.FromFile(pic);
         }
         else
         {
            image = Properties.Resources.def_accountpicture;
         }
         picAccountAvater.Image = image;
         picAccountAvater.SizeMode = PictureBoxSizeMode.StretchImage;
         graphics.DrawImage(image, new Rectangle(new Point(0, 0), picAccountAvater.Size));
      }
   }
}
