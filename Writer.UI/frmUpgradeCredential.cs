using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Properties;
using Cabinink.Writer.Cores;

namespace Cabinink.Writer.UI
{
   public partial class frmUpgradeCredential : Cabinink.Writer.UI.VsSkinFormBase
   {
      private Graphics graphics;
      private Image image;

      public frmUpgradeCredential()
      {
         InitializeComponent();
         graphics = picAccountAvater.CreateGraphics();
         image = picAccountAvater.Image;
      }

      private void picAccountAvater_MouseMove(object sender, MouseEventArgs e)
      {
         graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
         graphics.DrawImage(Resources.change_avater, new Rectangle(new Point(64, 64), new Size(72, 72)));
      }

      private void frmUpgradeCredential_MouseMove(object sender, MouseEventArgs e)
      {
         graphics.DrawImage(image, new Rectangle(new Point(0, 0), picAccountAvater.Size));
      }

      private void picAccountAvater_Click(object sender, EventArgs e)
      {
         if (ofdSelectAvater.ShowDialog() == DialogResult.OK)
         {
            image = Image.FromFile(ofdSelectAvater.FileName);
            picAccountAvater.Image = image;
            //frmPictureTrim trim = new frmPictureTrim(ref image);
            //trim.ShowDialog();
            graphics.DrawImage(image, new Rectangle(new Point(0, 0), picAccountAvater.Size));
            string exname = FileOperation.GetFileExtension(ofdSelectAvater.FileName);
            string username = Environment.UserName;
            string sysvol = Environment.SystemDirectory.Substring(0, 3);
            string newfile = sysvol + @"Users\" + username + @"\ciwriter_avater" + exname;
            System.IO.File.Copy(ofdSelectAvater.FileName, newfile, true);
         }
      }

      private void materialRaisedButton1_Click(object sender, EventArgs e)//Update Credential.
      {
         UserCredential credential;
         DatabaseOperation dbopt = new DatabaseOperation(@"Data Source=databases\users.db");
         dbopt.InitializeConnection();
         dbopt.Connect();
         SQLiteDataReader reader = dbopt.InvokeSqlToReader("select * from userinfo");
         string user = string.Empty;
         string oldpasswd = string.Empty;
         decimal ticks = 0;
         string mailaddr = string.Empty;
         while (reader.Read())
         {
            user = reader.GetString(reader.GetOrdinal("_user"));
            oldpasswd = reader.GetString(reader.GetOrdinal("_passwd"));
            ticks = reader.GetDecimal(reader.GetOrdinal("_ineffective"));
            mailaddr = reader.GetString(reader.GetOrdinal("_mailaddr"));
         }
         reader.Close();
         credential = new UserCredential(user, oldpasswd, mailaddr, new DateTime((long)ticks));
         if (oldpasswd != txtOldPassword.Text)
         {
            VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("错误", "输入的旧密码与数据库中的记录不一致，请重新输入！", EMessageLevel.Error);
            msg.Display(this);
         }
         else
         {
            if (txtNewPassword.Text != txtInputAgain.Text)
            {
               VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("错误", "两次输入的新密码必须保证一致，请重新输入！", EMessageLevel.Error);
               msg.Display(this);
            }
            else
            {
               if (txtNewPassword.Text == string.Empty)
               {
                  VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("错误", "密码不能为空，请重新输入！", EMessageLevel.Error);
                  msg.Display(this);
               }
               else
               {
                  string values = "'" + user + "','" + oldpasswd + "'," + ticks + ",'" + mailaddr + "'";
                  credential.UpgradePassword(oldpasswd, txtNewPassword.Text);
                  dbopt.InvokeSql(@"delete * from userinfo where _user='" + user + "'");
                  dbopt.InvokeSql(@"insert into userinfo values(" + values + @")");
                  dbopt.Disconnect();
                  VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("提示", "密码修改成功，将会在下次启动应用程序时（或者重新启动应用程序）生效。", EMessageLevel.Information);
                  msg.Display(this);
               }
            }
         }
      }

      private void frmUpgradeCredential_Load(object sender, EventArgs e)
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
            image = Resources.def_accountpicture;
         }
         picAccountAvater.Image = image;
         picAccountAvater.SizeMode = PictureBoxSizeMode.StretchImage;
         graphics.DrawImage(image, new Rectangle(new Point(0, 0), picAccountAvater.Size));
      }
   }
}
