﻿using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data.SQLite;
using Cabinink.Writer.Cores;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Cabinink.Writer.Middle
{
   /// <summary>
   /// Cabinink Writer 项目表示类
   /// </summary>
   [DebuggerDisplay("ProjectName = {Name}, ProjectDbUri = {Database.SourceUri}")]
   public class Project
   {
      /// <summary>
      /// 当前项目所包含的作品
      /// </summary>
      private Novel novel;
      /// <summary>
      /// 当前作品所包含的角色
      /// </summary>
      private RoleManagement roles;
      /// <summary>
      /// 当前作品所包含的故事大纲
      /// </summary>
      private Compendium compendium;
      /// <summary>
      /// 当前项目所对应的数据库
      /// </summary>
      private DatabaseOperation dbopt;
      /// <summary>
      /// 当前项目的用户设置
      /// </summary>
      private List<int> usersetting;
      /// <summary>
      /// 构造函数，创建一个空的项目实例
      /// </summary>
      public Project() : base()
      {
         usersetting = new List<int>();
         roles = new RoleManagement();
         compendium = new Compendium();
         ChineseNumber.InitializeBuilder();
      }
      /// <summary>
      /// 构造函数，创建一个指定数据库文件地址的实例
      /// </summary>
      /// <param name="_projurl">指定的数据库文件地址，如果这个数据库不存在则将会被创建。</param>
      private Project(string _projurl)
      {
         dbopt = new DatabaseOperation(@"Data Source=" + _projurl);
         roles = new RoleManagement();
         compendium = new Compendium();
         usersetting = new List<int>();
         ChineseNumber.InitializeBuilder();
      }
      /// <summary>
      /// 构造函数，创建一个指定数据库文件地址和作品信息的实例
      /// </summary>
      /// <param name="_projurl">指定的数据库文件地址，如果这个数据库不存在则将会被创建。</param>
      /// <param name="_info">作品的相关信息。</param>
      public Project(string _projurl, SNovelInformation _info)
      {
         dbopt = new DatabaseOperation(@"Data Source=" + _projurl);
         novel = new Novel(_info);
         usersetting = new List<int>();
         roles = new RoleManagement();
         compendium = new Compendium();
         ChineseNumber.InitializeBuilder();
      }
      /// <summary>
      /// 获取或设置当前实例的项目名称
      /// </summary>
      public string Name
      {
         get { return FileOperation.GetFileNameWithoutExtension(Database.SourceUri); }
         set { Database.SourceUri = FileOperation.GetFatherDirectory(Database.SourceUri) + value + ".db"; }
      }
      /// <summary>
      /// 获取或设置当前实例的作品实例
      /// </summary>
      public Novel CurrentNovel
      {
         get { return novel; }
         set { novel = value; }
      }
      /// <summary>
      /// 获取或设置当前实例所安排的所有角色
      /// </summary>
      public RoleManagement Roles
      {
         get { return roles; }
         set { roles = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的故事大纲
      /// </summary>
      public Compendium Compendium
      {
         get { return compendium; }
         set { compendium = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的项目数据库（set代码对其他程序集不可见）
      /// </summary>
      public DatabaseOperation Database
      {
         get { return dbopt; }
         internal set { dbopt = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的作品用户设置
      /// </summary>
      public List<int> UserSetting
      {
         get { return usersetting; }
         internal set { usersetting = value; }
      }
      /// <summary>
      /// 初始化项目，并做好项目的准备工作
      /// </summary>
      public void InitializeProject()
      {
         Database.InitializeConnection();
         Database.Connect();
         if (Database.DataTableExists("property") == false)
            Database.InvokeSql(ReadSqlDocument(@"databases\crtt_property_sql.document-ci"));
         if (Database.DataTableExists("novel") == false)
            Database.InvokeSql(ReadSqlDocument(@"databases\crtt_novel_sql.document-ci"));
         if (Database.DataTableExists("usersetting") == false)
            Database.InvokeSql(ReadSqlDocument(@"databases\crtt_usersetting_sql.document-ci"));
         if (Database.DataTableExists("compendium") == false)
            Database.InvokeSql(ReadSqlDocument(@"databases\crtt_compendium_sql.document-ci"));
         if (Database.DataTableExists("roles") == false)
            Database.InvokeSql(ReadSqlDocument(@"databases\crtt_roles_sql.document-ci"));
         Database.Disconnect();
      }
      /// <summary>
      /// 从数据库读取当前项目的作品相关信息
      /// </summary>
      /// <returns>如果读取成功，则将会返回true，否则返回false。</returns>
      public bool ReadNovelInformation()
      {
         bool iscomp = true;
         string resdir = FileOperation.GetFatherDirectory(Database.SourceUri) + @"\ResourceFiles";
         SNovelInformation info = CurrentNovel.Information;
         SQLiteDataReader reader;
         Database.InitializeConnection();
         Database.Connect();
         reader = Database.InvokeSqlToReader(@"select * from property");
         if (reader.HasRows == false) iscomp = false;
         while (reader.Read())
         {
            info.NovelName = reader.GetString(reader.GetOrdinal("_novelname"));
            info.WriterName = reader.GetString(reader.GetOrdinal("_writer"));
            info.Remarks = reader.GetString(reader.GetOrdinal("_remarks"));//
            info.Category = (ENovelCategory)reader.GetInt16(reader.GetOrdinal("_category"));
            info.CreationTime = new DateTime(reader.GetInt64(reader.GetOrdinal("_create_t")));
            info.BreakupTime = new DateTime(reader.GetInt64(reader.GetOrdinal("_breakup_t")));
            info.Keywords = reader.GetString(reader.GetOrdinal("_keywords")).Split(',').ToList();
            info.ResourceFiles = FileOperation.GetFiles(resdir);
         }
         CurrentNovel.Information = info;
         reader.Close();
         Database.Disconnect();
         return iscomp;
      }
      /// <summary>
      /// 保存项目中的作品信息
      /// </summary>
      /// <returns>如果操作成功则返回true，否则返回false。</returns>
      public bool SaveNovelInformation()
      {
         int isins = 0;
         Database.InitializeConnection();
         Database.Connect();
         SNovelInformation info = CurrentNovel.Information;
         string projname = "'" + FileOperation.GetFileNameWithoutExtension(Database.SourceUri) + "'";
         string novelname = "'" + info.NovelName + "'";
         string writer = "'" + info.WriterName + "'";
         string remarks = "'" + info.Remarks + "'";
         int category = (int)info.Category;        //int
         long create = info.CreationTime.Ticks;    //long
         long breakup = info.BreakupTime.Ticks;    //long
         string keywords = "'" + info.GetKeywordsCsvString() + "'";
         string inserted = projname + "," + novelname + "," + writer + "," + remarks + ","
                           + category + "," + create + "," + breakup + "," + keywords;
         string updated = "_projname=" + projname + ",_novelname=" + novelname + ",_writer=" +
                           writer + ",remarks=" + remarks + ",_category=" + category + ",_create_t=" +
                           create + ",_breakup_t=" + breakup + ",_keywords=" + keywords;
         if (IsNullProject()) isins = Database.InvokeSql("insert into property values(" + inserted + ")");
         else //isins = Database.InvokeSql("update property set " + updated + " where _projname=" + projname);
         {
            Database.InvokeSql("delete from property where _projname=" + projname);
            isins = Database.InvokeSql("insert into property values(" + inserted + ")");
         }
         Database.Disconnect();
         return isins > 0 ? true : false;
      }
      /// <summary>
      /// 从数据库中读取当前实例的作品用户设置
      /// </summary>
      /// <returns>如果操作成功则返回true，否则返回false。</returns>
      public bool ReadUserSetting()
      {
         bool iscomp = false;
         SQLiteDataReader reader;
         Database.InitializeConnection();
         Database.Connect();
         reader = Database.InvokeSqlToReader("select * from usersetting");
         iscomp = reader.HasRows;
         while (reader.Read())
         {
            UserSetting.Add(reader.GetInt32(reader.GetOrdinal("_intellisence")));
            UserSetting.Add(reader.GetInt32(reader.GetOrdinal("_chapternomod")));
            UserSetting.Add(reader.GetInt32(reader.GetOrdinal("_sectionnomod")));
         }
         reader.Close();
         Database.Disconnect();
         return iscomp;
      }
      /// <summary>
      /// 保存当前用户设置
      /// </summary>
      /// <returns>如果操作成功则返回true，否则返回false。</returns>
      public bool SaveUserSetting()
      {
         bool iscomp = false;
         int isins = 0;
         Database.InitializeConnection();
         Database.Connect();
         string inserted = UserSetting[0] + "," + UserSetting[1] + "," + UserSetting[2];
         if (IsNullProject()) isins = Database.InvokeSql("insert into usersetting values(" + inserted + ")");
         else
         {
            Database.InvokeSql("delete from usersetting");
            isins = Database.InvokeSql("insert into usersetting values(" + inserted + ")");
         }
         Database.Disconnect();
         return iscomp;
      }
      /// <summary>
      /// 从数据库中读取一个分卷
      /// </summary>
      /// <param name="_stno">需要被读取的分卷所对应的分卷编号。</param>
      public void ReadSection(int _stno)
      {
         SQLiteDataReader reader;
         string cnno = string.Empty, title = string.Empty;
         int index = 0;
         ESubsectionNumberMode mode = 0x0000;
         Database.InitializeConnection();
         Database.Connect();
         reader = Database.InvokeSqlToReader("select * from novel where _section=" + _stno);
         CurrentNovel.Subsections = new List<Subsection>();
         while (reader.Read())
         {
            if (index > 0)
            {
               string readedno = reader.GetInt32(reader.GetOrdinal("_section")).ToString();
               string provsno = CurrentNovel[index - 1].SubsectionNumber.SubsectionNumber;
               switch (UserSetting[2])
               {
                  case 0:
                  case 1:
                     if (readedno == ChineseNumber.ConvertToArab(provsno)) continue;
                     break;
                  case 2:
                     if (readedno == provsno) continue;
                     break;
               }
            }
            title = reader.GetString(reader.GetOrdinal("_section_title"));
            switch (UserSetting[2])
            {
               case 0:
                  cnno = ChineseNumber.ConvertToChinese(_stno);
                  mode = ESubsectionNumberMode.NumberAfterChineseSubsection;
                  break;
               case 1:
                  cnno = ChineseNumber.ConvertToChinese(_stno);
                  mode = ESubsectionNumberMode.NumberBeforeChineseSubsectionFirstAndLast;
                  break;
               case 2:
                  cnno = _stno.ToString();
                  mode = ESubsectionNumberMode.ArabicNumberAfterEnglishSubsection;
                  break;
            }
            CurrentNovel.OperationFlag = true;
            CurrentNovel.AddSubsection(new Subsection(new SSubsectionNumber(mode, cnno), title));
            index++;
         }
         reader.Close();
         Database.Disconnect();
      }
      /// <summary>
      /// 从数据库中读取章节
      /// </summary>
      /// <param name="_stno">指定的分卷编号。</param>
      /// <param name="_cpno">指定的章节编号。</param>
      public void ReadChapter(int _stno, int _cpno)
      {
         SQLiteDataReader reader;
         SChapterNumber cpno_s = new SChapterNumber();
         EChapterNumberMode mode_c = (EChapterNumberMode)UserSetting[1];
         ESubsectionNumberMode mode_s = (ESubsectionNumberMode)UserSetting[2];
         string body, section_t, chapter_t;
         Database.InitializeConnection();
         Database.Connect();
         reader = Database.InvokeSqlToReader("select * from novel where _section=" + _stno + " and _chapter=" + _cpno);
         while (reader.Read())
         {
            body = reader.GetString(reader.GetOrdinal("_body"));
            section_t = reader.GetString(reader.GetOrdinal("_section_title"));
            chapter_t = reader.GetString(reader.GetOrdinal("_chapter_title"));
            switch (mode_c)
            {
               case EChapterNumberMode.OnlyArabic:
                  cpno_s = new SChapterNumber(_cpno.ToString(), 0x0000);
                  break;
               case EChapterNumberMode.ArabicInEnglishChapterMark:
                  cpno_s = new SChapterNumber(_cpno.ToString(), (EChapterNumberMode)0x0001);
                  break;
               case EChapterNumberMode.ArabicInChineseChapterMark:
                  cpno_s = new SChapterNumber(_cpno.ToString(), (EChapterNumberMode)0x0002);
                  break;
               case EChapterNumberMode.ArabicInChineseSectionMark:
                  cpno_s = new SChapterNumber(_cpno.ToString(), (EChapterNumberMode)0x0003);
                  break;
               case EChapterNumberMode.ArabicBeforeChineseChapterMarkFirstWordAndLastWord:
                  cpno_s = new SChapterNumber(_cpno.ToString(), (EChapterNumberMode)0x0004);
                  break;
               case EChapterNumberMode.ArabicBeforeChineseSectionMarkFirstWordAndLastWord:
                  cpno_s = new SChapterNumber(_cpno.ToString(), (EChapterNumberMode)0x0005);
                  break;
               case EChapterNumberMode.OnlyChineseNum:
                  cpno_s = new SChapterNumber(ChineseNumber.ConvertToChinese(_cpno), (EChapterNumberMode)0x0006);
                  break;
               case EChapterNumberMode.ChineseNumInChineseChapterMark:
                  cpno_s = new SChapterNumber(ChineseNumber.ConvertToChinese(_cpno), (EChapterNumberMode)0x0007);
                  break;
               case EChapterNumberMode.ChineseNumInChineseSectionMark:
                  cpno_s = new SChapterNumber(ChineseNumber.ConvertToChinese(_cpno), (EChapterNumberMode)0x0008);
                  break;
               case EChapterNumberMode.ChineseNumBeforeChineseChapterMarkFirstWordAndLastWord:
                  cpno_s = new SChapterNumber(ChineseNumber.ConvertToChinese(_cpno), (EChapterNumberMode)0x0009);
                  break;
               case EChapterNumberMode.ChineseNumBeforeChineseSectionMarkFirstWordAndLastWord:
                  cpno_s = new SChapterNumber(ChineseNumber.ConvertToChinese(_cpno), (EChapterNumberMode)0x000a);
                  break;
            }
            CurrentNovel[_stno - 1].AddChapter(new Chapter(cpno_s, chapter_t));
            CurrentNovel[_stno - 1][_cpno - 1].Body = body;
         }
         reader.Close();
         Database.Disconnect();
      }
      /// <summary>
      /// 保存指定的章节至指定分卷下
      /// </summary>
      /// <param name="_stno">指定的分卷编号。</param>
      /// <param name="_cpno">指定的章节编号。</param>
      public void SaveChapter(string _stno, string _cpno)
      {
         Database.InitializeConnection();
         int stno = Convert.ToInt32(_stno), cpno = Convert.ToInt32(_cpno);
         string section_t, chapter_t, body;
         section_t = CurrentNovel[stno - 1].Title;
         chapter_t = CurrentNovel[stno - 1][cpno - 1].Title;
         body = CurrentNovel[stno - 1][cpno - 1].Body;
         string updated = "update novel set " + "_section_title='" +
                           section_t + "',_chapter_title='" + chapter_t + "',_body='" + body + "'";
         string inserted = "insert into novel values(" + stno +
                           ",'" + section_t + "'," + cpno + ",'" + chapter_t + "','" + body + "')";
         if (ChapterExists(stno, cpno))
         {
            Database.Connect();
            Database.InvokeSql(updated);
         }
         else
         {
            Database.Connect();
            Database.InvokeSql(inserted);
         }
         Database.Disconnect();
      }
      /// <summary>
      /// 保存当前作品所包含的所有章节
      /// </summary>
      public void SaveAllChapter()
      {
         for (int i = 0; i < CurrentNovel.Count; i++)
         {
            for (int j = 0; j < CurrentNovel[i].Count; j++) SaveChapter((i + 1).ToString(), (j + 1).ToString());
         }
      }
      /// <summary>
      /// 创建一个新的章节，如果指定的分卷不存在，则会自动创建一个新的分卷
      /// </summary>
      /// <param name="_subsection">决定创建于哪一个分卷下面，如果这个分卷不存在，则将会自动创建。</param>
      /// <param name="_chapter">需要被创建的章节。</param>
      public void CreateChapter(Subsection _subsection, Chapter _chapter)
      {
         string section_t, chapter_t;
         int stno = 0, cpno = 0;
         SSubsectionNumber ssn = _subsection.SubsectionNumber;
         SChapterNumber scn = _chapter.ChapterNumber;
         section_t = _subsection.Title;
         chapter_t = _subsection.Title;
         if (IsNullDataTable("novel"))
         {
            stno = 1;
            cpno = 1;
         }
         else
         {
            stno = GetMaximumNumber("_section", "") + 1;
            cpno = GetMaximumNumber("_chapter", "where _section=" + (stno - 1)) + 1;
         }
         switch (_subsection.SubsectionNumber.SubsectionNumberMode)
         {
            case ESubsectionNumberMode.NumberAfterChineseSubsection:
            case ESubsectionNumberMode.NumberBeforeChineseSubsectionFirstAndLast:
               ssn.SubsectionNumber = ChineseNumber.ConvertToChinese(stno);
               break;
            case ESubsectionNumberMode.ArabicNumberAfterEnglishSubsection:
               ssn.SubsectionNumber = stno.ToString();
               break;
         }
         if (_chapter.ChapterNumber.IsArabNumber()) scn.ChapterNumber = ChineseNumber.ConvertToChinese(cpno);
         else scn.ChapterNumber = cpno.ToString();
         _subsection.SubsectionNumber = ssn;
         _chapter.ChapterNumber = scn;
         CurrentNovel.OperationFlag = true;
         CurrentNovel.AddSubsection(_subsection);
         CurrentNovel[CurrentNovel.Count - 1].AddChapter(_chapter);
         SaveChapter(stno.ToString(), cpno.ToString());
      }
      /// <summary>
      /// 获取数据库中指定字段的最大值
      /// </summary>
      /// <returns>该操作返回的值表示指定字段所拥有的最大值，但这个操作只适合用于字段类型为数值型的字段。</returns>
      public int GetMaximumNumber(string _field, string _condition)
      {
         SQLiteDataReader reader;
         int maxno = 0;
         Database.InitializeConnection();
         Database.Connect();
         string sql = "select max(" + _field + ") as _max_number from novel " + _condition;
         reader = Database.InvokeSqlToReader(sql);
         reader.Read();
         maxno = reader.GetInt32(reader.GetOrdinal("_max_number"));
         reader.Close();
         Database.Disconnect();
         return maxno;
      }
      /// <summary>
      /// 读取整个项目
      /// </summary>
      public void ReadAll()
      {
         int index = 1;
         int index_s = 1;
         ReadNovelInformation();
         ReadUserSetting();
         while (SubsectionExists(index))
         {
            ReadSection(index);
            while (ChapterExists(index, index_s))
            {
               ReadChapter(index, index_s);
               index_s += 1;
            }
            index += 1;
         }
      }
      /// <summary>
      /// 保存整个项目
      /// </summary>
      public void SaveAll()
      {
         SaveNovelInformation();
         SaveUserSetting();
         SaveAllChapter();
      }
      /// <summary>
      /// 记录已成功创建的项目
      /// </summary>
      public void RecordProjectSaved()
      {
         DatabaseOperation db = new DatabaseOperation(@"Data Source=config\ciwconfig.db");
         db.InitializeConnection();
         db.Connect();
         db.InvokeSql("insert into projects values('" + Name + "','" + Database.SourceUri + "')");
         db.Disconnect();
      }
      /// <summary>
      /// 指示当前项目是否是空项目
      /// </summary>
      /// <returns>如果这个项目是空项目，则返回true，否则返回false。</returns>
      public bool IsNullProject()
      {
         return IsNullDataTable("property") && IsNullDataTable("novel") && IsNullDataTable("usersetting");
      }
      /// <summary>
      /// 检查指定数据表是否为空表
      /// </summary>
      /// <param name="_table">需要被检查的数据表。</param>
      /// <returns>如果该数据表为空，则返回true，否则返回false。</returns>
      public bool IsNullDataTable(string _table)
      {
         SQLiteDataReader reader;
         bool isnull = false;
         Database.InitializeConnection();
         Database.Connect();
         reader = Database.InvokeSqlToReader("select * from " + _table);
         if (reader.HasRows == false) isnull = true;
         reader.Close();
         return isnull;
      }
      /// <summary>
      /// 检测指定章节在数据库中是否存在
      /// </summary>
      /// <param name="_stno">指定的分卷编号。</param>
      /// <param name="_cpno">指定的章节编号。</param>
      /// <returns>如果该章节存在则返回true，否则返回false。</returns>
      public bool ChapterExists(int _stno, int _cpno)
      {
         SQLiteDataReader reader;
         bool exists = false;
         Database.InitializeConnection();
         Database.Connect();
         reader = Database.InvokeSqlToReader("select * from novel where _section=" + _stno + " and _chapter=" + _cpno);
         if (reader.HasRows) exists = true;
         reader.Close();
         Database.Disconnect();
         return exists;
      }
      /// <summary>
      /// 检测指定的分卷在数据库中是否存在
      /// </summary>
      /// <param name="_stno">指定的分卷编号。</param>
      /// <returns>如果该分卷存在则返回true，否则返回false。</returns>
      public bool SubsectionExists(int _stno)
      {
         SQLiteDataReader reader;
         bool exists = false;
         Database.InitializeConnection();
         Database.Connect();
         reader = Database.InvokeSqlToReader("select * from novel where _section=" + _stno);
         if (reader.HasRows) exists = true;
         reader.Close();
         Database.Disconnect();
         return exists;
      }
      /// <summary>
      /// 检查指定的项目名称是否符合规范，项目名称文本的组成元素只允许是字母，下划线和数字，且数字不能存在于首字符位置
      /// </summary>
      /// <param name="_projname">需要被检查的项目名称。</param>
      /// <returns>如果被检查的项目名称符合规范，则返回true，否则会返回false。</returns>
      public bool IsInconformitySpecification(string _projname)
      {
         bool specification = false;
         char[] projname_chars = _projname.ToCharArray();
         int[] ascii_fragment = { 48, 57, 65, 90, 95, 97, 122 };//48~57 is number,65~90 is lowercase,97 is underline,97~122 is uppercase.
         Parallel.For(0, _projname.Length, (index, interrupt) =>
         {
            if (projname_chars[index] >= ascii_fragment[0] && projname_chars[index] <= ascii_fragment[1] && index != 0)
            {
               specification = true;
            }
            else if (projname_chars[index] >= ascii_fragment[2] && projname_chars[index] <= ascii_fragment[3])
            {
               specification = true;
            }
            else if (projname_chars[index] >= ascii_fragment[5] && projname_chars[index] <= ascii_fragment[6])
            {
               specification = true;
            }
            else if (projname_chars[index] == ascii_fragment[4])
            {
               specification = true;
            }
            else
            {
               specification = false;
               interrupt.Stop();
            }
         });
         return specification;
      }
      /// <summary>
      /// 从指定文件读取SQL语句
      /// </summary>
      /// <param name="_furl">SQL语句文档。</param>
      /// <returns>该操作将会返回从文件中读取的SQL字符串。</returns>
      internal string ReadSqlDocument(string _furl)
      {
         return FileOperation.ReadFile(_furl, true, Encoding.UTF8);
      }
      /// <summary>
      /// 获取无效的项目的项目名称和项目路径集合
      /// </summary>
      /// <returns>如果该操作不会抛出异常，则会返回一个数组，这个数组包含了两个List&lt;string&gt;实例，第一个为无效项目的名称集合，第二个是无效项目路径的集合。</returns>
      public static List<string>[] GetInvalidProjects()
      {
         List<string> readed_urls = new List<string>();
         List<string> readed_projnames = new List<string>();
         List<string> ret_urls = new List<string>();
         List<string> ret_projnames = new List<string>();
         DatabaseOperation dbopt = new DatabaseOperation(@"Data Source=config\ciwconfig.db");
         SQLiteDataReader reader;
         dbopt.InitializeConnection();
         dbopt.Connect();
         reader = dbopt.InvokeSqlToReader(@"select * from projects");
         while (reader.Read())
         {
            readed_projnames.Add(reader.GetString(reader.GetOrdinal("_name")));
            readed_urls.Add(reader.GetString(reader.GetOrdinal("_url")));
         }
         for (int i = 0; i < readed_urls.Count; i++)
         {
            if (!FileOperation.FileExists(readed_urls[i]))
            {
               ret_urls.Add(readed_urls[i]);
               ret_projnames.Add(readed_projnames[i]);
            }
         }
         reader.Close();
         dbopt.Disconnect();
         return new List<string>[] { ret_projnames, ret_urls };
      }
      /// <summary>
      /// 检查指定的项目数据库文件是否存在
      /// </summary>
      /// <param name="_dburl">指定的项目数据库文件地址。</param>
      /// <returns>如果这个项目数据库文件存在则返回true，否则将会返回false。</returns>
      public static bool ProjectDbExists(string _dburl)
      {
         if (FileOperation.FileExists(_dburl)) return true; else return false;
      }
      /// <summary>
      /// 从项目记录数据表中移除指定的项目
      /// </summary>
      /// <param name="_projurl">需要被移除的项目的数据库文件地址。</param>
      public static void RemoveProjectFromDb(string _projurl)
      {
         DatabaseOperation db = new DatabaseOperation(@"Data Source=config\ciwconfig.db");
         db.InitializeConnection();
         db.Connect();
         db.InvokeSql(@"delete from projects where _url='" + @_projurl + "'");
         db.Disconnect();
      }
      /// <summary>
      /// 从项目记录数据表中批量移除指定的项目集合
      /// </summary>
      /// <param name="_projurls">需要被移除的项目集合的数据库文件地址。</param>
      public static void RemoveProjectCollectionFromDb(List<string> _projurls)
      {
         Parallel.For(0, _projurls.Count, (index) => { RemoveProjectFromDb(_projurls[index]); });
      }
      /// <summary>
      /// 获取当前实例的字符串表达形式
      /// </summary>
      /// <returns>该操作会返回一个特定的实例表达字符串。</returns>
      public override string ToString()
      {
         return "Project{" + Database.SourceUri + ", " + CurrentNovel.ToString() + ")";
      }
   }
}
