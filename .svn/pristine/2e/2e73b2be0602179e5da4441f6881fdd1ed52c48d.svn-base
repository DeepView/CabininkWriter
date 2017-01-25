using System;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 写作笔记类
   /// </summary>
   public class Note : IDisposable
   {
      /// <summary>
      /// 笔记的详细记录时间
      /// </summary>
      private DateTime record;
      /// <summary>
      /// 笔记的标题
      /// </summary>
      private string title;
      /// <summary>
      /// 笔记的主体内容
      /// </summary>
      private string body;
      /// <summary>
      /// 笔记的标识
      /// </summary>
      private ENoteFlag flag;
      /// <summary>
      /// 用于管理笔记的数据库操作实例
      /// </summary>
      private DatabaseOperation dbopt;
      /// <summary>
      /// 构造函数，创建一个没有主体内容但是有默认标题和记录时间的实例
      /// </summary>
      public Note()
      {
         record = DateTime.Now;
         title = record.ToString();
         body = string.Empty;
         flag = ENoteFlag.Normal;
      }
      /// <summary>
      /// 构造函数，创建一个默认标题的笔记实例
      /// </summary>
      /// <param name="_body">指定的笔记主体内容。</param>
      public Note(string _body)
      {
         record = DateTime.Now;
         title = record.ToString();
         body = _body;
         flag = ENoteFlag.Normal;
      }
      /// <summary>
      /// 构造函数，创建一个指定标题的笔记实例
      /// </summary>
      /// <param name="_title">指定的笔记标题。</param>
      /// <param name="_body">指定的笔记主体内容。</param>
      public Note(string _title, string _body)
      {
         record = DateTime.Now;
         title = _title;
         body = _body;
         flag = ENoteFlag.Normal;
      }
      /// <summary>
      /// 构造函数，创建一个指定记录时间、标题、主体内容和标识的笔记实例
      /// </summary>
      /// <param name="_time">指定的记录时间。</param>
      /// <param name="_title">指定的笔记标题。</param>
      /// <param name="_body">指定的笔记主体内容。</param>
      /// <param name="_flag">指定的笔记标识。</param>
      public Note(DateTime _time, string _title, string _body, ENoteFlag _flag)
      {
         record = _time;
         title = _title;
         body = _body;
         flag = _flag;
      }
      /// <summary>
      /// 获取或设置当前实例的笔记记录时间（set代码对外不可见）
      /// </summary>
      public DateTime RecordTime
      {
         get { return record; }
         private set { record = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的笔记标题
      /// </summary>
      public string Title
      {
         get { return title; }
         set
         {
            if (value.Length == 0) title = RecordTime.ToString();
            else title = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的笔记主体内容
      /// </summary>
      public string Body
      {
         get { return body; }
         set
         {
            if (value == null) throw new ObjectDisposedException("不允许空引用的string实例！");
            body = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的笔记标识
      /// </summary>
      public ENoteFlag Flag
      {
         get { return flag; }
         set { flag = value; }
      }
      /// <summary>
      /// 初始化管理数据库
      /// </summary>
      public void InitializeSupportedDb()
      {
         dbopt = new DatabaseOperation(@"Data Source=databases\notes.db");
         dbopt.InitializeConnection();
         dbopt.Connect();
      }
      /// <summary>
      /// 保存当前笔记到数据库
      /// </summary>
      public void Save()
      {
         string condition = "_time=" + RecordTime.Ticks;
         RecordTime = DateTime.Now;
         string update = "_time=" + RecordTime.Ticks + ",_title='" + Title + "',_context='" + Body + "',_flag=" + (int)Flag;
         string insert = RecordTime.Ticks + ",'" + Title + "','" + Body + "'," + (int)Flag;
         try
         {
            if (dbopt.RecordExists("notes", condition))
            {
               dbopt.InvokeSql("update notes set " + update + " where " + condition);
            }
            else
            {
               dbopt.InvokeSql("insert into notes values(" + insert + ");");
            }
         }
         catch
         {
            System.Threading.Thread.Sleep(10);
         }
      }
      /// <summary>
      /// 在断开对象引用连接的同时断开数据库的连接
      /// </summary>
      public void Dispose()
      {
         dbopt.Disconnect();
      }
      /// <summary>
      /// 获取当前实例的字符串表达形式
      /// </summary>
      /// <returns>该操作会返回一个有意义的实例字符串。</returns>
      public override string ToString()
      {
         string s_date = RecordTime.Year + "-" + RecordTime.Month + "-" + RecordTime.Day;
         return Title + "（" + s_date + " " + RecordTime.ToShortTimeString() + "）";
      }
   }
   /// <summary>
   /// 笔记标识枚举
   /// </summary>
   public enum ENoteFlag : int
   {
      /// <summary>
      /// 常规标志
      /// </summary>
      Normal = 0x0000,
      /// <summary>
      /// 存在疑问的笔记
      /// </summary>
      ExistingQuestion = 0x0001,
      /// <summary>
      /// 非常重要的笔记
      /// </summary>
      Important = 0x0002,
      /// <summary>
      /// 有趣的笔记
      /// </summary>
      Interesting = 0x0003
   }
}
