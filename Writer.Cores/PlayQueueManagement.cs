using System;
using System.Data.SQLite;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 播放列表管理类
   /// </summary>
   public class PlayQueueManagement : IDisposable
   {
      /// <summary>
      /// 需要被管理的播放列表
      /// </summary>
      private PlayQueue list;
      /// <summary>
      /// 用于管理播放列表的数据库操作实例
      /// </summary>
      private DatabaseOperation dbopt;
      /// <summary>
      /// 构造函数，创建一个空的播放列表管理实例
      /// </summary>
      public PlayQueueManagement()
      {
         list = new PlayQueue();
      }
      /// <summary>
      /// 构造函数，创建一个指定播放列表（这个列表允许为非null的空列表）的管理实例
      /// </summary>
      /// <param name="_list">需要被管理的播放列表实例。</param>
      public PlayQueueManagement(PlayQueue _list)
      {
         if (_list == null) throw new ObjectDisposedException("无法导入空播放列表！");
         list = _list;
      }
      /// <summary>
      /// 初始化管理平台
      /// </summary>
      public void InitializeSupportedDb()
      {
         dbopt = new DatabaseOperation(@"Data Source=config\ciwconfig.db");
         dbopt.InitializeConnection();
         dbopt.Connect();
      }
      /// <summary>
      /// 从数据库中读取播放列表中所有的音频文件地址
      /// </summary>
      /// <param name="_hwnd">播放音频文件的窗口句柄。</param>
      public void ReadAll(IntPtr _hwnd)
      {
         ReadAll(false, _hwnd);
      }
      /// <summary>
      /// 从数据库中读取播放列表中所有的音频文件地址，并决定是以追加还是覆盖的方式添加到现有的PlayQueue实例中
      /// </summary>
      /// <param name="_isappend">决定以追加还是覆盖的方式将读取的内容添加到现有的PlayQueue实例中去，如果该参数为true，则以追加的方式添加从数据库读取的数据。</param>
      /// <param name="_hwnd">播放音频文件的窗口句柄。</param>
      public void ReadAll(bool _isappend, IntPtr _hwnd)
      {
         if (!_isappend) list.PlayList.Clear();
         SQLiteDataReader reader;
         string furl = string.Empty;
         reader = dbopt.InvokeSqlToReader(@"select * from bgmplaylist");
         while (reader.Read())
         {
            furl = reader.GetString(reader.GetOrdinal("_furl"));
            list.PlayList.Add(new Sound(furl, _hwnd));
         }
         reader.Close();
      }
      /// <summary>
      /// 保存播放列表至数据库
      /// </summary>
      public void SaveAll()
      {
         dbopt.InvokeSql(@"delete * from bgmplaylist");
         for (int i = 0; i < list.Count; i++) dbopt.InvokeSql("insert into bgmplaylist values(" + list[i].MediaUri + ")");
      }
      /// <summary>
      /// 在断开对象引用连接的同时断开数据库的连接，并强制释放播放列表实例所包含的所有Sound实例
      /// </summary>
      public void Dispose()
      {
         for (int i = 0; i < list.Count; i++) list[i].Dispose();
         dbopt.Disconnect();
      }
   }
}
