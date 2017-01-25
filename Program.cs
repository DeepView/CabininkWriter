using System;
using System.Threading;
using System.Data.SQLite;
using Cabinink.Writer.UI;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using Cabinink.Writer.Middle;
using System.Collections.Generic;
namespace Cabinink
{
   /// <summary>
   /// 用于访问应用程序主入口点的静态类
   /// </summary>
   public static class Program
   {
      private const string APPLICATION_BUILD_PROCESS_BASE = " Base";
      private const string APPLICATION_BUILD_PROCESS_ALPHA = " Alpha";
      private const string APPLICATION_BUILD_PROCESS_BETA = "Beta";
      private const string APPLICATION_BUILD_PROCESS_RC = " RC";
      private const string APPLICATION_BUILD_PROCESS_RELEASE = " Release";
      public static string AppBuildingProcessFlag = APPLICATION_BUILD_PROCESS_BASE;
      public static BaiduCloudBackup CloudBackup;
      public static List<Project> Projects = new List<Project>();
      public static List<string> IntelliSenceSources = new List<string>();
      /// <summary>
      /// 应用程序的主入口点
      /// </summary>
      [STAThread]
      public static void Main()
      {
         Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
         Application.ThreadException += new ThreadExceptionEventHandler(UIThreadUnhandledExceptionCatched);
         AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CoresThreadUnhandledExceptionCatched);
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         frmMainInterface main = new frmMainInterface();
         List<string>[] invalids = Project.GetInvalidProjects();
         string invalid_str = "即将从数据库中移除下列被检测到的无效项目。这些项目被移除之后，其项目源并不会真正的从您的计算机上删除，它将会继续在您的磁盘上，直到您手动删除为止！\n\n";
         for (int i = 0; i < invalids[1].Count; i++)
         {
            invalid_str += invalids[0][i] + "（数据库文件地址：" + invalids[1][i] + "）\n";
         }
         if (invalids[1].Count > 0)
         {
            VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("注意", invalid_str, EMessageLevel.Warning);
            msg.Display();
         }
         Project.RemoveProjectCollectionFromDb(invalids[1]);
         InitializeBackupModule();
         LoadProjects();
         LoadRoles();
         LoadCompendiums();
         frmWelcome.LoadAndRun(main);
      }
      /// <summary>
      /// 枚举注释获取
      /// </summary>
      /// <param name="_value"></param>
      /// <returns></returns>
      public static string GetEnumDescription(Enum _value)
      {
         if (_value == null) throw new ArgumentException("_value");
         string description = _value.ToString();
         var fieldInfo = _value.GetType().GetField(description);
         var attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
         if (attributes != null && attributes.Length > 0)
         {
            description = attributes[0].Description;
         }
         return description;
      }
      /// <summary>
      /// 加载项目
      /// </summary>
      public static void LoadProjects()
      {
         DatabaseOperation dbopt = new DatabaseOperation(@"Data Source=config\ciwconfig.db");
         List<string> projurls = new List<string>();
         SQLiteDataReader reader;
         dbopt.InitializeConnection();
         dbopt.Connect();
         reader = dbopt.InvokeSqlToReader(@"select * from projects");
         while (reader.Read())
         {
            projurls.Add(reader.GetString(reader.GetOrdinal("_url")));
         }
         reader.Close();
         dbopt.Disconnect();
         for (int i = 0; i < projurls.Count; i++) BuildProject(projurls[i]);
      }
      /// <summary>
      /// 移除无效项目
      /// </summary>
      /// <param name="_dburl">无效的项目的数据库文件地址记录。</param>
      [Obsolete("Not used.")]
      public static void RemoveInefficientProject(string _dburl)
      {
         if (!Project.ProjectDbExists(_dburl)) Project.RemoveProjectFromDb(_dburl);
      }
      /// <summary>
      /// 从配置文件中移除所有无效项目数据库文件的地址记录
      /// </summary>
      [Obsolete("Not used.")]
      public static void RemoveAllInefficientProjects()
      {
         List<string> inefficients = Project.GetInvalidProjects()[1];
         for (int i = 0; i < inefficients.Count; i++) RemoveInefficientProject(inefficients[i]);
      }
      /// <summary>
      /// 生成项目实例
      /// </summary>
      /// <param name="_projurl">项目保存的地址。</param>
      public static void BuildProject(string _projurl)
      {
         Project project = new Project(_projurl, new SNovelInformation());
         project.InitializeProject();
         project.ReadNovelInformation();
         project.ReadUserSetting();
         project.ReadAssemblyInformation();
         for (int i = 1; i <= project.GetMaximumNumber("_section", ""); i++)
         {
            project.ReadSection(i);
            for (int j = 1; j <= project.GetMaximumNumber("_chapter", "where _section=" + i); j++)
            {
               project.ReadChapter(i, j);
            }
         }
         Projects.Add(project);
      }
      /// <summary>
      /// 加载所有项目的角色
      /// </summary>
      public static void LoadRoles()
      {
         string dburl = string.Empty;
         for (int i = 0; i < Projects.Count; i++)
         {
            dburl = Projects[i].Database.SourceUri;
            Projects[i].Roles.ReadFromDatabase(dburl);
         }
      }
      /// <summary>
      /// 加载所有项目的大纲
      /// </summary>
      public static void LoadCompendiums()
      {
         string dburl = string.Empty;
         for (int i = 0; i < Projects.Count; i++)
         {
            dburl = Projects[i].Database.SourceUri;
            Projects[i].Compendium.ReadFromDatabase(dburl, Projects[i].Roles);
         }
      }
      /// <summary>
      /// 初始化百度云备份模块
      /// </summary>
      public static void InitializeBackupModule()
      {
         string rnd_usr = @"";
         string rnd_passwd = @"";
         CloudBackup = new BaiduCloudBackup(rnd_usr, rnd_passwd);
      }
      public static void UIThreadUnhandledExceptionCatched(object sender, ThreadExceptionEventArgs e)
      {
         VsSkinExceptionForm exform = new VsSkinExceptionForm(e.Exception.Message + "\n\n" + e.Exception.StackTrace);
         exform.ShowDialog();
      }
      public static void CoresThreadUnhandledExceptionCatched(object sender, UnhandledExceptionEventArgs e)
      {
         VsSkinExceptionForm exform = new VsSkinExceptionForm(e.ExceptionObject.ToString() + "\nIsTerminating = " + e.IsTerminating);
         exform.ShowDialog();
      }
   }
}
