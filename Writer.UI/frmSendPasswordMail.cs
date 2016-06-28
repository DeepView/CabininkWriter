using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using System.Data.SQLite;

namespace Cabinink.Writer.UI
{
   public partial class frmSendPasswordMail : Cabinink.Writer.UI.VsSkinFormBase
   {
      private frmLogin owner;
      public frmSendPasswordMail()
      {
         InitializeComponent();
      }
      public DialogResult DisplayDialog(frmLogin _owner)
      {
         owner = _owner;
         return ShowDialog(_owner);
      }
      private void metroButton1_Click(object sender, EventArgs e)//Send Mail
      {
         string sql = @"select * from userinfo where _user='" + Environment.UserName + @"'";
         DatabaseOperation dbopt = new DatabaseOperation("Data Source=databases\\users.db");
         SQLiteDataReader reader;
         dbopt.InitializeConnection();
         dbopt.Connect();
         reader = dbopt.InvokeSqlToReader(sql);
         string passwd = "", mailaddr = "";
         while (reader.Read())
         {
            passwd = reader.GetString(1);
            mailaddr = reader.GetString(3);
         }
         reader.Close();
         UserCredential user = new UserCredential(Environment.UserName, passwd, mailaddr);
         user.FoundPassword();
         Close();
      }
   }
}
