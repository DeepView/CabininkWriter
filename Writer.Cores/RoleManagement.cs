﻿using System;
using System.Data;
using System.Linq;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 角色管理类
   /// </summary>
   [DebuggerDisplay("RolesCount = {Count}")]
   public class RoleManagement : INovelAttribureDatabaseIO
   {
      /// <summary>
      /// 当前作品已经拥有的角色
      /// </summary>
      private List<Role> roles;
      /// <summary>
      /// 当前作品暂时被移出，却未被删除的角色
      /// </summary>
      private List<Role> removed;
      /// <summary>
      /// 创建roles表格的SQL语句
      /// </summary>
      private const string CRETAE_TABLE_ROLES_SQL = @"create table role_collection(role not null text,appellation text,sex text,initage integer,category text,camp text,occupation text,appearance text,character text,petphrase text,other text)";
      /// <summary>
      /// 构造函数，创建一个没有角色的空集管理实例
      /// </summary>
      public RoleManagement()
      {
         roles = new List<Role>();
         removed = new List<Role>();
      }
      /// <summary>
      /// 构造函数，创建一个指定角色集合的管理实例
      /// </summary>
      /// <param name="_roles">需要被管理的角色集合。</param>
      public RoleManagement(List<Role> _roles)
      {
         roles = _roles;
         removed = new List<Role>();
      }
      /// <summary>
      /// 构造函数，创建一个指定角色集合以及被移除角色集合的管理实例
      /// </summary>
      /// <param name="_roles">需要被管理的角色集合。</param>
      /// <param name="_removed">被移除的角色的集合。</param>
      public RoleManagement(List<Role> _roles, List<Role> _removed)
      {
         roles = _roles;
         removed = _removed;
      }
      /// <summary>
      /// 获取或设置当前实例的角色集合
      /// </summary>
      public List<Role> Roles
      {
         get { return roles; }
         set
         {
            if (value == null) throw new ObjectDisposedException("不允许空引用的列表！");
            roles = value;
         }
      }
      /// <summary>
      /// 获取当前实例的被移除角色的集合
      /// </summary>
      public List<Role> Removed
      {
         get { return removed; }
      }
      /// <summary>
      /// 获取需要被管理的角色集合的实际角色数量
      /// </summary>
      public int Count
      {
         get { return Roles.Count; }
      }
      /// <summary>
      /// 获取或设置指定索引所对应的角色
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      /// <returns>如果该索引器未抛出异常，则get代码部分会返回指定索引所对应的元素。</returns>
      public Role this[int _index]
      {
         get
         {
            if (_index > Count || _index < 0) throw new ArgumentOutOfRangeException("索引超出范围！");
            return Roles[_index];
         }
         set
         {
            if (_index > Count || _index < 0) throw new ArgumentOutOfRangeException("索引超出范围！");
            Roles[_index] = value;
         }
      }
      /// <summary>
      /// 新增一个角色到管理实例中
      /// </summary>
      /// <param name="_item">需要被加入到管理实例中的角色。</param>
      /// <returns>如果操作成功，则会返回该操作结束后角色管理实例集合的实际元素数量。</returns>
      public int AddRole(Role _item)
      {
         Roles.Add(_item);
         return Count;
      }
      /// <summary>
      /// 根据指定的索引从管理实例中移除（不是删除）一个角色
      /// </summary>
      /// <param name="_index">需要被移除的角色。</param>
      /// <returns>如果操作成功，则会返回该操作结束后角色管理实例集合的实际元素数量。</returns>
      public int RemoveRole(int _index)
      {
         if (_index > Count || _index < 0) throw new ArgumentOutOfRangeException("索引超出范围！");
         Removed.Add(Roles[_index]);
         Roles.RemoveAt(_index);
         return Count;
      }
      /// <summary>
      /// 从管理实例中移除（不是删除）一个与参数相同的角色，如果存在多个名称相同的角色，则会抛出异常
      /// </summary>
      /// <param name="_item">需要被移除的角色</param>
      /// <returns>如果操作成功，则会返回该操作结束后角色管理实例集合的实际元素数量。</returns>
      public int RemoveRole(Role _item)
      {
         int rplctno = 0;
         List<int> repidxes = new List<int>();
         List<Role> reps = new List<Role>();
         FindReplicateName(Roles, _item.Name, ref rplctno);
         if (rplctno > 0) throw new ReplicatedNameException("存在重复的姓名！");
         repidxes = GetReplicateIndexes(Roles, _item, ref reps);
         Removed.Add(_item);
         Roles.RemoveAt(repidxes[0]);
         return Count;
      }
      /// <summary>
      /// 寻找相同姓名的角色
      /// </summary>
      /// <param name="_befinded">用于方法执行的数据源。</param>
      /// <param name="_finded">需要被寻找的角色的姓名。</param>
      /// <param name="_rplctno">如果这个方法执行无异常抛出，则该参数则作为相同姓名的角色数量。</param>
      /// <returns>该方法会返回一个列表，用于表示相同姓名的角色集合。</returns>
      public List<Role> FindReplicateName(List<Role> _befinded, SCompleteName _finded, ref int _rplctno)
      {
         List<Role> replicated = new List<Role>();
         Parallel.For(0, _befinded.Count, (index) =>
         {
            if (_befinded[index].Name.Equals(_finded)) replicated.Add(_befinded[index]);
         });
         _rplctno = replicated.Count;
         return replicated;
      }
      /// <summary>
      /// 收集相同角色的索引
      /// </summary>
      /// <param name="_befinded">用于方法执行的数据源。</param>
      /// <param name="_replicated">需要被寻找的角色。</param>
      /// <param name="_repelems">如果这个方法执行无异常抛出，则该参数则作为相同角色的一个统计集合。</param>
      /// <returns>该方法会返回这个操作生成的相同角色索引列表。</returns>
      public List<int> GetReplicateIndexes(List<Role> _befinded, Role _replicated, ref List<Role> _repelems)
      {
         List<int> repindexes = new List<int>();
         List<Role> repelems = _repelems;
         Parallel.For(0, _befinded.Count, (index) =>
         {
            if (_befinded[index] == _replicated)
            {
               repindexes.Add(index);
               repelems.Add(_befinded[index]);
            }
         });
         if (repindexes.Count == 0) throw new NotFoundRoleException("该角色不存在于管理实例中！");
         repindexes.Sort();
         _repelems = repelems;
         return repindexes;
      }
      /// <summary>
      /// 从被移除列表中恢复一个角色到角色管理列表之中
      /// </summary>
      /// <param name="_recovered">需要被恢复的角色。</param>
      public void Recover(Role _recovered)
      {
         List<Role> reps = new List<Role>();
         Roles.Add(_recovered);
         Removed.RemoveAt(GetReplicateIndexes(Removed, _recovered, ref reps)[0]);
      }
      /// <summary>
      /// 从被移除列表中恢复一个角色到角色管理列表之中
      /// </summary>
      /// <param name="_index">需要被恢复的角色在待恢复列表中的索引。</param>
      public void Recover(int _index)
      {
         List<Role> reps = new List<Role>();
         Roles.Add(Removed[_index]);
         Removed.RemoveAt(_index);
      }
      /// <summary>
      /// 清空待恢复列表（被移除角色的集合）中的所有角色，但是在执行这个操作之前，请用户一定要仔细确认是否该这样做
      /// </summary>
      public void ClearAllRemoved()
      {
         Removed.Clear();
      }
      /// <summary>
      /// 在当前角色管理实例中根据角色名称查找符合条件的角色
      /// </summary>
      /// <param name="_name">用于查找角色的角色名称。</param>
      /// <returns>如果查找到满足条件的角色，则将会累积到一个List实例并返回。</returns>
      public List<Role> SearchByName(string _name)
      {
         return Roles.FindAll(delegate (Role role) { return role.Name.ToString(true) == _name; });
      }
      /// <summary>
      /// 将所有的角色信息保存到数据库
      /// </summary>
      /// <param name="_dburl">需要将角色信息保存到哪一个数据库。</param>
      /// <param name="_isdisconn">操作结束后是否断开数据库的连接。</param>
      public void SaveToDatabase(string _dburl, bool _isdisconn)
      {
         DatabaseOperation dbopt = new DatabaseOperation(new Uri(_dburl));
         string r_name, r_appellation, r_sex, r_initage, r_category, r_camp, r_occupation, r_appearance, r_character, r_petphrase, r_other;
         string inserted = string.Empty;
         dbopt.InitializeConnection();
         if (dbopt.ConnectionStatus == ConnectionState.Closed) dbopt.Connect();
         dbopt.InvokeSql("delete from roles");
         for (int i = 0; i < Roles.Count; i++)
         {
            r_name = "\x27" + this[i].Name.ToString(Roles[i].Name.DisplayFlag) + "\x27" + @",";
            r_appellation = "\x27" + this[i].GetCsvFormatString() + "\x27" + @",";
            r_sex = (int)this[i].Sex + @",";
            r_initage = "\x27" + Convert.ToString(this[i].InitializeAge, 10) + "\x27" + @",";
            r_category = (int)this[i].Category + @",";
            r_camp = "\x27" + this[i].Camp + "\x27" + @",";
            r_occupation = "\x27" + this[i].Occupation + "\x27" + @",";
            r_appearance = "\x27" + this[i].Appearance + "\x27" + @",";
            r_character = "\x27" + this[i].Character + "\x27" + @",";
            r_petphrase = "\x27" + this[i].PetPhrase + "\x27" + @",";
            r_other = "\x27" + this[i].OtherInformation + "\x27";
            inserted = r_name + r_appellation + r_sex + r_initage + r_category + r_camp + r_occupation + r_appearance + r_character + r_petphrase + r_other;
            dbopt.InvokeSql("insert into roles values(" + inserted + ")");
         }
         if (_isdisconn) dbopt.Disconnect();
      }
      /// <summary>
      /// 将所有的角色信息保存到数据库
      /// </summary>
      /// <param name="_dburl">需要将角色信息保存到哪一个数据库。</param>
      /// <param name="_sql">用于执行查询操作的SQL语句。</param>
      /// <param name="_parameters">用于SQL语句中的参数。</param>
      /// <param name="_isdisconn">操作结束后是否断开数据库的连接。</param>
      /// <returns>操作结束之后，将会返回这个操作的数据表。</returns>
      public DataTable SaveToDatabase(string _dburl, string _sql, IList<SQLiteParameter> _parameters, bool _isdisconn)
      {
         DataTable dt = new DataTable();
         DatabaseOperation dbo = new DatabaseOperation(new Uri(_dburl));
         dbo.InitializeConnection();
         if (dbo.ConnectionStatus == ConnectionState.Closed) dbo.Connect();
         dt = dbo.InvokeSqlToDataTable(_sql, _parameters);
         if (_isdisconn) dbo.Disconnect();
         return dt;
      }
      /// <summary>
      /// 从数据库文件读取角色信息并加载到当前实例中
      /// </summary>
      /// <param name="_dburl">存储读取角色信息的数据库文件地址。</param>
      public void ReadFromDatabase(string _dburl)
      {
         SQLiteDataReader reader;
         DatabaseOperation dbopt = new DatabaseOperation(@"Data Source=" + _dburl);
         dbopt.InitializeConnection();
         dbopt.Connect();
         reader = dbopt.InvokeSqlToReader(@"select * from roles");
         while (reader.Read())
         {
            Role role = new Role();
            string[] name_str = reader.GetString(reader.GetOrdinal("_name")).Split(' ');
            role.Name = new SCompleteName(name_str[0], name_str[1]);
            role.Appellation = reader.GetString(reader.GetOrdinal("_appellation")).Split(',').ToList();
            role.Sex = (EPeopleSex)reader.GetInt32(reader.GetOrdinal("_sex"));
            role.InitializeAge = (uint)reader.GetInt32(reader.GetOrdinal("_initage"));
            role.Category = (ERoleCategory)reader.GetInt32(reader.GetOrdinal("_category"));
            role.Camp = reader.GetString(reader.GetOrdinal("_camp"));
            role.Occupation = reader.GetString(reader.GetOrdinal("_occupation"));
            role.Appearance = reader.GetString(reader.GetOrdinal("_appearance"));
            role.Character = reader.GetString(reader.GetOrdinal("_character"));
            role.PetPhrase = reader.GetString(reader.GetOrdinal("_petphrase"));
            role.OtherInformation = reader.GetString(reader.GetOrdinal("_other"));
            AddRole(role);
         }
         reader.Close();
         dbopt.Disconnect();
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.RoleManagement";
      }
   }
   /// <summary>
   /// 当角色集合中出现重复的姓名时而抛出的异常
   /// </summary>
   [Serializable]
   public class ReplicatedNameException : Exception
   {
      public ReplicatedNameException() { }
      public ReplicatedNameException(string message) : base(message) { }
      public ReplicatedNameException(string message, Exception inner) : base(message, inner) { }
      protected ReplicatedNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 找不到指定的Role实例时而抛出的异常
   /// </summary>
   [Serializable]
   public class NotFoundRoleException : Exception
   {
      public NotFoundRoleException() { }
      public NotFoundRoleException(string message) : base(message) { }
      public NotFoundRoleException(string message, Exception inner) : base(message, inner) { }
      protected NotFoundRoleException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
