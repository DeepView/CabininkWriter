using System;
using System.Data.SQLite;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 用户注册类
   /// </summary>
   public class UserRegister
   {
      /// <summary>
      /// 需要被注册的用户凭据
      /// </summary>
      private UserCredential credential;
      /// <summary>
      /// 用于操作用户信息数据库的DatabaseOperation实例
      /// </summary>
      private DatabaseOperation databaseopt;
      /// <summary>
      /// 构造函数，创建一个指定用户凭据的实例
      /// </summary>
      /// <param name="_credential">需要被注册的用户。</param>
      public UserRegister(UserCredential _credential)
      {
         databaseopt = new DatabaseOperation("Data Source=databases\\users.db");
         databaseopt.InitializeConnection();
         credential = _credential;
      }
      /// <summary>
      /// 获取或设置当前实例的用户凭据（set代码对于其他程序集不可见）
      /// </summary>
      public UserCredential Credential
      {
         get { return credential; }
         internal set { credential = value; }
      }
      /// <summary>
      /// 注册当前给定的用户
      /// </summary>
      /// <returns>如果该用户已存在或者注册线程发生异常，该操作将会失败，并返回false，否则将会返回true。</returns>
      public bool Register()
      {
         bool isreged = true;
         string username = @"'" + Credential.UserName;
         string passwd = @"','" + Credential.Password;
         string maxdate_tick = @"','" + DateTime.MaxValue.Ticks.ToString();
         string mailaddr = @"','" + Credential.EmailAddress + @"')";
         string sqldata = username + passwd + maxdate_tick + mailaddr;
         if (Exists()) isreged = false;
         else
         {
            int iscomp = 0;
            string sql = @"insert into userinfo values(" + sqldata;
            databaseopt.Connect();
            iscomp = databaseopt.InvokeSql(sql);
            databaseopt.Disconnect();
            if (iscomp > 0) isreged = true; else isreged = false;
         }
         return isreged;
      }
      /// <summary>
      /// 判断当前给定的用户是否已注册
      /// </summary>
      /// <returns>如果该用户已注册则返回true，否则返回false。</returns>
      public bool Exists()
      {
         bool exists = true;
         string sql = @"select _user from userinfo where _user='" + Credential.UserName + @"'";
         SQLiteDataReader sqlreader;
         databaseopt.Connect();
         sqlreader = databaseopt.InvokeSqlToReader(sql);
         try
         {
            if (sqlreader.HasRows == true) exists = true; else exists = false;
         }
         catch (Exception ex)
         {
            if (ex != null) exists = true;
         }
         databaseopt.Disconnect();
         return exists;
      }
   }
}
