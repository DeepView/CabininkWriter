﻿using System;
using System.Text;
using System.Linq;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 智能感知类
   /// </summary>
   [Obsolete("在当前版本暂不使用！")]
   public class IntelligentizedSence
   {
      /// <summary>
      /// 智能感知的数据源
      /// </summary>
      private List<DatabaseOperation> datasrc;
      /// <summary>
      /// 构造函数，初始化一个空数据源的智能感知类
      /// </summary>
      public IntelligentizedSence()
      {
         datasrc = new List<DatabaseOperation>();
      }
      /// <summary>
      /// 构造函数，创建一个由指定数据库本地路径列表初始化的数据源列表的智能感知实例
      /// </summary>
      /// <param name="_dburls">用于初始化数据源的数据库本地路径列表。</param>
      public IntelligentizedSence(List<Uri> _dburls)
      {
         datasrc = new List<DatabaseOperation>();
         for (int i = 0; i < _dburls.Count; i++) datasrc.Add(new DatabaseOperation(_dburls[i]));
      }
      /// <summary>
      /// 构造函数，创建一个由指定数据库连接字符串列表初始化的数据源列表的智能感知实例
      /// </summary>
      /// <param name="_dbconnsts">用于初始化数据源的数据库连接字符串列表。</param>
      public IntelligentizedSence(List<string> _dbconnsts)
      {
         datasrc = new List<DatabaseOperation>();
         for (int i = 0; i < _dbconnsts.Count; i++) datasrc.Add(new DatabaseOperation(_dbconnsts[i]));
      }
      /// <summary>
      /// 获取或设置当前实例的数据源
      /// </summary>
      public List<DatabaseOperation> DataSources
      {
         get { return datasrc; }
         set
         {
            if (datasrc == null) throw new NotFoundAnyDataSourceException("数据源不能为空！");
            datasrc = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例中指定索引所对应的数据源
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      /// <returns>该操作如果无异常抛出，则会返回指定索引所对应的那个数据源。</returns>
      public DatabaseOperation this[int _index]
      {
         get
         {
            if (_index > GetDataSourcesCount() || _index < 0) throw new ArgumentOutOfRangeException("索引超出范围！");
            return DataSources[_index];
         }
         set
         {
            if (_index > GetDataSourcesCount() || _index < 0) throw new ArgumentOutOfRangeException("索引超出范围！");
            DataSources[_index] = value;
         }
      }
      /// <summary>
      /// 初始化所有的数据源
      /// </summary>
      /// <returns>该操作用于初始化当前实例所包含的所有数据源，如果任意一个数据源初始化失败，则整个初始化操作都会中断，如果发生了这种情况，则会返回false，否则返回true。</returns>
      public bool InitializeDataSource()
      {
         if (GetDataSourcesCount() == 0) throw new NotFoundAnyDataSourceException("未找到任何数据源！");
         bool successful = true;
         Parallel.For(0, GetDataSourcesCount(), (index, interrupt) =>
         {
            bool isconned = this[(int)index].InitializeConnection();
            if (isconned == false)
            {
               successful = false;
               interrupt.Stop();
            }
            else
            {
               this[(int)index].Connect();
            }
         });
         return successful;
      }
      /// <summary>
      /// 获取当前实例所使用的数据源的数据库数量
      /// </summary>
      /// <returns>该操作将会返回当前实例所使用的数据库的数量。</returns>
      public uint GetDataSourcesCount()
      {
         return (uint)datasrc.Count;
      }
      /// <summary>
      /// 搜索满足条件的记录并获取主内容
      /// </summary>
      /// <param name="_key">用于作为条件的关键词。</param>
      /// <returns>如果搜索到满足条件的相关记录的主内容，则返回一个非空列表。</returns>
      public List<string> GetContentAccessSearch(string _key)
      {
         List<string> accordant = new List<string>(), dtnames = new List<string>();
         List<SQLiteDataReader> readers = new List<SQLiteDataReader>();
         Parallel.For(0, GetDataSourcesCount(), (index) =>
         {
            dtnames = this[(int)index].GetAllDataTableName();
            Parallel.For(0, dtnames.Count, (index_s) =>
            {
               string sql = "select * from " + dtnames[index_s];
               string query_if_a = sql + " where _mcon='" + _key + "';";
               string query_if_b = sql + " where _mcon like '" + _key + "%';";
               string query_if_c = sql + " where _mcon like '%" + _key + "';";
               string query_if_d = sql + " where _mcon like '%" + _key + "%';";
               readers.Add(this[(int)index].InvokeSqlToReader(query_if_a));
               readers.Add(this[(int)index].InvokeSqlToReader(query_if_b));
               readers.Add(this[(int)index].InvokeSqlToReader(query_if_c));
               readers.Add(this[(int)index].InvokeSqlToReader(query_if_d));
            });
         });
         try
         {
            Parallel.For(0, readers.Count, (index) =>
            {
               while (readers[index].Read()) accordant.Add(readers[index].GetString(0));
            });
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
         return RemoveReplicate(accordant);
      }
      /// <summary>
      /// 搜索满足条件的记录并获取主内容，如果关键词是全字母，则不仅仅可以搜索其原始匹配主内容，还可以通过其可以匹配的中文字符来搜索主内容
      /// </summary>
      /// <param name="_key">用于作为条件的关键词。</param>
      /// <returns>如果搜索到满足条件的相关记录的主内容，则返回一个非空列表。</returns>
      public List<string> GetContentAccessSearchForAdvanced(string _key)
      {
         List<string> accordant = new List<string>();
         List<string> tocnkeys = new List<string>();
         bool isletter = true;
         byte subkeyascii = 0;
         Parallel.For(0, _key.Length, (index, interrupt) =>
         {
            subkeyascii = Encoding.ASCII.GetBytes(_key.Substring(index, 1).ToUpper())[0];
            if (subkeyascii < 65 || subkeyascii > 90)
            {
               isletter = false;
               interrupt.Stop();
            }
         });
         if (isletter == true)
         {
            for (int i = 0; i < _key.Length; i++)
            {
               PhoneticTranscription pt = new PhoneticTranscription();
               tocnkeys.AddRange(pt.GetChineseByLetter(_key.Substring(i, 1)));
            }
         }
         Parallel.For(0, tocnkeys.Count, (index) => { accordant.AddRange(GetContentAccessSearch(tocnkeys[index])); });
         accordant.AddRange(GetContentAccessSearch(_key));
         return accordant;
      }
      /// <summary>
      /// 移除列表中重复的项目
      /// </summary>
      /// <param name="_results">需要被操作的字符串列表。</param>
      /// <returns>该操作将会返回一个没有重复项目的字符串列表。</returns>
      public List<string> RemoveReplicate(List<string> _results)
      {
         IEnumerable<string> distinct = _results.Distinct();
         return distinct.ToList();
      }
      /// <summary>
      /// 清除所有数据源的连接状态
      /// </summary>
      public void DisposeDataSources()
      {
         for (uint i = 0; i < GetDataSourcesCount(); i++) this[(int)i].Disconnect();
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.IntelligentizedSence";
      }
   }
   /// <summary>
   /// 未找到任何数据源时而抛出的异常
   /// </summary>
   [Serializable]
   public class NotFoundAnyDataSourceException : Exception
   {
      public NotFoundAnyDataSourceException() { }
      public NotFoundAnyDataSourceException(string message) : base(message) { }
      public NotFoundAnyDataSourceException(string message, Exception inner) : base(message, inner) { }
      protected NotFoundAnyDataSourceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
