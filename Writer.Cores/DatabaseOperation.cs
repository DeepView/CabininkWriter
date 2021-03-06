﻿using System;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 数据库操作类
   /// </summary>
   /// <example>
   /// 下面是该类的基本演示，其代码如下：
   /// <code>
   /// using System;
   /// using System.Data.SQLite;
   /// using Cabinink.Writer.Cores;
   /// namespace SQLiteDatabaseOperationDemo
   /// {
   ///    public class Program
   ///    {
   ///       public static DatabaseOperation dbopt;
   ///       public static void Main(string[] args)
   ///       {
   ///          SQLiteDataReader reader;
   ///          dbopt = new DatabaseOperation("Data Source=test.db");
   ///          dbopt.InitializeConnection();
   ///          dbopt.Connect();
   ///          reader = dbopt.InvokeSqlToReader(@"select * from infotable where _level=0");
   ///          while(reader.Read())
   ///          {
   ///             Console.WriteLine(reader.GetString(reader.GetOrdinal("_name")));
   ///             Console.WriteLine(reader.GetString(reader.GetOrdinal("_address_home")));
   ///          }
   ///          reader.Close();
   ///          dbopt.Disconnect();
   ///          Console.Write("Press any key to continue...");
   ///          Console.ReadKey(true);
   ///       }
   ///    }
   /// }
   /// </code>
   /// 提示：SQLiteDataReader的成员方法Read返回值类型为bool，可用于判断当前SQLiteDataReader实例是否仍在读取数据。
   /// </example>
   public class DatabaseOperation
   {
      /// <summary>
      /// 数据库连接字符串
      /// </summary>
      public string dbconnst;
      /// <summary>
      /// SQLite 数据库查询执行类
      /// </summary>
      public SQLiteCommand sqlcmd;
      /// <summary>
      /// SQLite 数据库连接类
      /// </summary>
      public SQLiteConnection sqlconn;
      /// <summary>
      /// 构造函数，通过一个指定的数据库文件地址来初始化当前实例
      /// </summary>
      /// <param name="_dburl">指定的数据库文件地址，如果这个文件地址无效则会抛出 NotFoundFileException 异常。</param>
      public DatabaseOperation(Uri _dburl)
      {
         if (FileOperation.FileExists(_dburl.LocalPath) == false) throw new NotFoundFileException("找不到数据库文件！");
         dbconnst = "Data Source=" + _dburl.LocalPath;
      }
      /// <summary>
      /// 构造函数，通过一个指定的数据库连接字符串地址来初始化当前实例
      /// </summary>
      /// <param name="_dbconnst">指定的数据库连接字符串。</param>
      public DatabaseOperation(string _dbconnst)
      {
         dbconnst = _dbconnst;
      }
      /// <summary>
      /// 获取或设置当前数据库的连接字符串
      /// </summary>
      public string ConnectionString
      {
         get { return dbconnst; }
         set
         {
            string furl = value.Substring("Data Source=".Length);
            if (FileOperation.FileExists(furl) == false)
            {
               throw new NotFoundFileException("找不到数据库文件！");
            }
            dbconnst = value;
         }
      }
      /// <summary>
      /// 获取或设置当前数据库的源文件地址（set代码对于其他程序集不可见）
      /// </summary>
      public string SourceUri
      {
         get
         {
            string furl = dbconnst.Substring("Data Source=".Length);
            return furl;
         }
         internal set { dbconnst = "Data Source=" + value; }
      }
      /// <summary>
      /// 获取或设置当前实例的SQLiteConnection实例
      /// </summary>
      public SQLiteConnection DbConnector
      {
         get { return sqlconn; }
         set { sqlconn = value; }
      }
      /// <summary>
      /// 获取当前数据库的连接状态
      /// </summary>
      public ConnectionState ConnectionStatus
      {
         get
         {
            return sqlconn.State;
         }
      }
      /// <summary>
      /// 初始化当前的数据库连接
      /// </summary>
      /// <returns>如果初始化成功则会返回true，若被该方法捕获了一些无法处理的异常则会视为初始化失败，并返回false。</returns>
      public bool InitializeConnection()
      {
         bool isconned = true;
         try
         {
            sqlconn = new SQLiteConnection(ConnectionString);
            sqlcmd = new SQLiteCommand(sqlconn);
         }
         catch (Exception ex)
         {
            Console.WriteLine("\nEXCEPTION::\n" + ex.Message + "\nSTACK_TRACE_INFOMATION::\n" + ex.StackTrace + "\n");
            if (ex != null) isconned = false;
         }
         return isconned;
      }
      /// <summary>
      /// 连接当前实例指定的数据库
      /// </summary>
      public void Connect()
      {
         sqlconn.Open();
      }
      /// <summary>
      /// 执行指定的SQL语句
      /// </summary>
      /// <param name="_sql">需要被执行的SQL语句。</param>
      /// <returns>如果该方法未产生任何异常，则会返回数据表里面受影响的数据行。</returns>
      public int InvokeSql(string _sql)
      {
         if (_sql.Length == 0 || _sql == null) throw new EmptySqlCommandLineException("不允许空的 SQL 语句！");
         if (ConnectionStatus == ConnectionState.Closed) throw new ConnectionNotExistsException("数据库未连接或者连接已断开！");
         int impact = -1;
         sqlcmd.CommandText = _sql;
         try
         {
            impact = sqlcmd.ExecuteNonQuery();
         }
         catch (Exception ex)
         {
            if (ex != null)
            {
               Console.WriteLine("\n\n\nSQLite Exception\n" + ex.Message + "\n\n" + ex.StackTrace + "\n\n\n");
               throw new SqlGrammarErrorException("SQL 语法错误或者出现了其他异常！");
            }
         }
         return impact;
      }
      /// <summary>     
      /// 执行指定的SQL语句
      /// </summary>     
      /// <param name="_sql">要执行的增删改的SQL语句。</param>     
      /// <param name="_parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准。</param>     
      /// <returns>对SQLite数据库执行增删改操作，返回受影响的行数。</returns>     
      public int InvokeSql(string _sql, IList<SQLiteParameter> _parameters)
      {
         int affectedRows = 0;
         if (ConnectionStatus == ConnectionState.Closed) throw new ConnectionNotExistsException("数据库未连接或者连接已断开！");
         DbTransaction transaction = sqlconn.BeginTransaction();
         SQLiteCommand command = new SQLiteCommand(sqlconn);
         command.CommandText = _sql;
         if (!(_parameters == null || _parameters.Count == 0))
         {
            foreach (SQLiteParameter parameter in _parameters) command.Parameters.Add(parameter);
         }
         affectedRows = command.ExecuteNonQuery();
         transaction.Commit();
         return affectedRows;
      }
      /// <summary>
      /// 执行指定的SQL语句，返回一个包含查询结果的DataTable
      /// </summary>
      /// <param name="_sql">需要被执行的SQL语句。</param>
      /// <param name="_parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准。</param>
      /// <returns>如果执行未产生任何异常，则会返回这个操作之后的查询结果。</returns>
      public DataTable InvokeSqlToDataTable(string _sql, IList<SQLiteParameter> _parameters)
      {
         SQLiteCommand command = new SQLiteCommand(_sql, sqlconn);
         if (ConnectionStatus == ConnectionState.Closed) throw new ConnectionNotExistsException("数据库未连接或者连接已断开！");
         if (!(_parameters == null || _parameters.Count == 0))
         {
            foreach (SQLiteParameter parameter in _parameters) command.Parameters.Add(parameter);
         }
         SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
         DataTable data = new DataTable();
         adapter.Fill(data);
         return data;
      }
      /// <summary>
      /// 执行一个查询语句，返回一个关联的 SQLiteDataReader 实例
      /// </summary>
      /// <param name="_sql">需要被执行的SQL语句。</param>
      /// <returns>如果执行未产生任何异常，则会返回这个操作之后的查询结果关联的 SQLiteDataReader 实例。</returns>
      public SQLiteDataReader InvokeSqlToReader(string _sql)
      {
         if (ConnectionStatus == ConnectionState.Closed) throw new ConnectionNotExistsException("数据库未连接或者连接已断开！");
         SQLiteCommand command = new SQLiteCommand(_sql, sqlconn);
         return command.ExecuteReader();
      }
      /// <summary>
      /// 执行一个查询语句，返回一个关联的 SQLiteDataReader 实例
      /// </summary>
      /// <param name="_sql">需要被执行的SQL语句。</param>
      /// <param name="_parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准。</param>
      /// <returns>如果执行未产生任何异常，则会返回这个操作之后的查询结果关联的 SQLiteDataReader 实例。</returns>
      public SQLiteDataReader InvokeSqlToReader(string _sql, IList<SQLiteParameter> _parameters)
      {
         SQLiteCommand command = new SQLiteCommand(_sql, sqlconn);
         if (ConnectionStatus == ConnectionState.Closed) throw new ConnectionNotExistsException("数据库未连接或者连接已断开！");
         if (!(_parameters == null || _parameters.Count == 0))
         {
            foreach (SQLiteParameter parameter in _parameters) command.Parameters.Add(parameter);
         }
         Connect();
         return command.ExecuteReader(CommandBehavior.CloseConnection);
      }
      /// <summary>
      /// 检查当前数据库中指定的数据表格是否存在
      /// </summary>
      /// <param name="_table">需要被检查是否存在的表格。</param>
      /// <returns>如果这个表格存在，则返回true，否则将返回false。</returns>
      public bool DataTableExists(string _table)
      {
         bool exists = true;
         if (ConnectionStatus == ConnectionState.Closed) throw new ConnectionNotExistsException("数据库未连接或者连接已断开！");
         sqlcmd = sqlconn.CreateCommand();
         sqlcmd.CommandText = "select count(*) from sqlite_master where type='table' and name='" + _table + "';";
         if (Convert.ToInt32(sqlcmd.ExecuteScalar()) == 0) exists = false;
         return exists;
      }
      /// <summary>
      /// 根据指定条件判断指定数据表中的某一条记录是否存在
      /// </summary>
      /// <param name="_table">需要被判定记录存在性的数据表。</param>
      /// <param name="_condition">用于判定的条件，这个条件会直接作为SQL语句的条件。</param>
      /// <returns>如果这条记录存在，则返回true，否则将返回false。</returns>
      public bool RecordExists(string _table, string _condition)
      {
         if (ConnectionStatus == ConnectionState.Closed) throw new ConnectionNotExistsException("数据库未连接或者连接已断开！");
         string sql = "select * from " + _table + " where " + _condition;
         return InvokeSqlToReader(sql).HasRows;
      }
      /// <summary>
      /// 获取当前数据库中所有数据表的表名称
      /// </summary>
      /// <returns>如果操作无异常，则会以列表实例的形式返回当前数据库中所有数据表的表名称。</returns>
      public List<string> GetAllDataTableName()
      {
         List<string> dtnames = new List<string>();
         if (ConnectionStatus == ConnectionState.Closed) Connect();
         SQLiteDataReader reader = InvokeSqlToReader(@"SELECT name FROM sqlite_master WHERE type='table'");
         while (reader.Read()) dtnames.Add(reader.GetString(0));
         return dtnames;
      }
      /// <summary>     
      /// 查询数据库中的所有数据类型信息
      /// </summary>     
      /// <returns>操作成功之后会返回所查询数据库中的所有数据类型的相关信息。</returns>     
      public DataTable GetSchema()
      {
         if (ConnectionStatus == ConnectionState.Closed) throw new ConnectionNotExistsException("数据库未连接或者连接已断开！");
         DataTable data = sqlconn.GetSchema("TABLES");
         return data;
      }
      /// <summary>
      /// 为当前数据库设置访问密码
      /// </summary>
      /// <param name="_passwd">即将生效的数据库访问密码。</param>
      public void SetDbPassword(string _passwd)
      {
         sqlconn.SetPassword(_passwd);
      }
      /// <summary>
      /// 更新当前数据库的访问密码
      /// </summary>
      /// <param name="_passwd">用于重新生效的数据库访问密码。</param>
      public void UpgradePassword(string _passwd)
      {
         sqlconn.ChangePassword(_passwd);
      }
      /// <summary>
      /// 断开当前数据库的连接
      /// </summary>
      public void Disconnect()
      {
         sqlconn.Close();
      }
      /// <summary>
      /// 根据指定的路径创建一个 SQLite 数据库
      /// </summary>
      /// <param name="_dburl">需要被创建的数据库的路径。</param>
      public static void CreateDatabase(string _dburl)
      {
         using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + _dburl))
         {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
               command.CommandText = "create table demo(id integer not null primary key autoincrement unique)";
               command.ExecuteNonQuery();
               command.CommandText = "drop table demo";
               command.ExecuteNonQuery();
            }
         }
      }
      /// <summary>
      /// 获取当前DatabaseOperation实例的完整类名的字符串表达形式
      /// </summary>
      /// <returns>该操作会返回一个当前实例的完整类名的字符串表达形式。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.DatabaseOperation";
      }
   }
   /// <summary>
   /// 数据库连接状态枚举
   /// </summary>
   public enum EConnectionStatus : int
   {
      /// <summary>
      /// 已打开数据库连接
      /// </summary>
      Connected = 0x0000,
      /// <summary>
      /// 已关闭数据库连接
      /// </summary>
      Disconnected = 0x0001
   }
   /// <summary>
   /// 当SQL语句为NULL的时候抛出的异常
   /// </summary>
   [Serializable]
   public class EmptySqlCommandLineException : Exception
   {
      public EmptySqlCommandLineException() { }
      public EmptySqlCommandLineException(string message) : base(message) { }
      public EmptySqlCommandLineException(string message, Exception inner) : base(message, inner) { }
      protected EmptySqlCommandLineException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 当SQL语句出现语法错误或者其他异常情况的时候而抛出的异常
   /// </summary>
   [Serializable]
   public class SqlGrammarErrorException : Exception
   {
      public SqlGrammarErrorException() { }
      public SqlGrammarErrorException(string message) : base(message) { }
      public SqlGrammarErrorException(string message, Exception inner) : base(message, inner) { }
      protected SqlGrammarErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 数据库连接不存在或者已断开连接时而抛出的异常
   /// </summary>
   [Serializable]
   public class ConnectionNotExistsException : Exception
   {
      public ConnectionNotExistsException() { }
      public ConnectionNotExistsException(string message) : base(message) { }
      public ConnectionNotExistsException(string message, Exception inner) : base(message, inner) { }
      protected ConnectionNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
