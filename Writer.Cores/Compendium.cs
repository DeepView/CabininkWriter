using System;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 故事大纲类
   /// </summary>
   [DebuggerDisplay("Compendium[StoryCount = {Count}]")]
   public class Compendium : INovelAttribureDatabaseIO
   {
      /// <summary>
      /// 故事线集合
      /// </summary>
      private List<StoryCell> stories;
      /// <summary>
      /// 构造函数，创建一个故事线集合为空的故事大纲
      /// </summary>
      public Compendium()
      {
         stories = new List<StoryCell>();
      }
      /// <summary>
      /// 构造函数，创建一个由指定Compendium实例中集合为故事线源的故事大纲
      /// </summary>
      /// <param name="_compendium">包含故事线源的指定Compendium实例。</param>
      public Compendium(Compendium _compendium)
      {
         if (_compendium.Count == 0) throw new CompendiumIsNothingException("故事线集合的元素数量不能为0！");
         stories.AddRange(_compendium.Stories);
      }
      /// <summary>
      /// 构造函数，创建一个由指定故事线集合作为故事线源的故事大纲
      /// </summary>
      /// <param name="_stories">指定的故事线集合。</param>
      public Compendium(List<StoryCell> _stories)
      {
         if (_stories.Count == 0) throw new CompendiumIsNothingException("故事线集合的元素数量不能为0！");
         stories.AddRange(_stories);
      }
      /// <summary>
      /// 获取或设置当前实例指定的故事线
      /// </summary>
      /// <param name="_index">用于查找故事线的索引。</param>
      /// <returns>如果这个操作无异常，则会返回指定索引所对应的故事线。</returns>
      public StoryCell this[int _index]
      {
         get
         {
            if (_index < 0 && _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
            return Stories[_index];
         }
         set
         {
            if (_index < 0 && _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
            Stories[_index] = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的故事线集合
      /// </summary>
      public List<StoryCell> Stories
      {
         get { return stories; }
         set { stories = value; }
      }
      /// <summary>
      /// 获取当前实例中故事线的数量
      /// </summary>
      public uint Count
      {
         get { return (uint)Stories.Count; }
      }
      /// <summary>
      /// 根据故事线的时间顺序来排序
      /// </summary>
      public void SortByHappendDate()
      {
         if (Count >= 1) throw new CompendiumIsNothingException("当故事线集合元素数量小于等于1时，是不允许执行该排序操作的！");
         Stories.Sort(delegate (StoryCell scl, StoryCell scr)
         {
            long sclserial = Convert.ToInt64(scl.HappenedDate.ToString(EDateDisplayCategory.OnlySerial), 10);
            long scrserial = Convert.ToInt64(scr.HappenedDate.ToString(EDateDisplayCategory.OnlySerial), 10);
            return sclserial.CompareTo(scrserial);
         });
      }
      /// <summary>
      /// 向大纲尾部添加故事线
      /// </summary>
      /// <param name="_item">需要被添加的故事线。</param>
      /// <returns>如果这个操作无异常产生，则会返回操作之后大纲的故事线数量。</returns>
      public uint AddStoryCell(StoryCell _item)
      {
         Stories.Add(_item);
         return Count;
      }
      /// <summary>
      /// 从大纲中移除指定索引所对应的故事线
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      /// <returns>如果这个操作无异常产生，则会返回操作之后大纲的故事线数量。</returns>
      public uint RemoveStoryCell(int _index)
      {
         if (_index < 0 && _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
         Stories.RemoveAt(_index);
         return Count;
      }
      /// <summary>
      /// 从大纲中移除与指定故事线实例相匹配的故事线
      /// </summary>
      /// <param name="_item">需要进行匹配的故事线实例。</param>
      /// <returns>如果这个操作无异常产生，则会返回操作之后大纲的故事线数量。</returns>
      public uint RemoveStoryCell(StoryCell _item)
      {
         Stories.Remove(_item);
         return Count;
      }
      /// <summary>
      /// 清空大纲中所存储的所有故事线
      /// </summary>
      public void ClearToNothing()
      {
         Stories.Clear();
      }
      /// <summary>
      /// 根据故事的发生日期来搜索故事线
      /// </summary>
      /// <param name="_keyitem">指定的故事的发生日期。</param>
      /// <returns>如果操作无异常，则会返回这个操作的搜索结果。</returns>
      public List<StoryCell> SearchByHappendDate(BigDate _keyitem)
      {
         return Stories.FindAll(delegate (StoryCell cell)
         {
            string keydateserial = _keyitem.ToString(EDateDisplayCategory.OnlySerial);
            string celldateserial = cell.HappenedDate.ToString(EDateDisplayCategory.OnlySerial);
            return keydateserial == celldateserial;
         });
      }
      /// <summary>
      /// 根据故事线的类型来搜索故事线
      /// </summary>
      /// <param name="_keyitem">指定的故事线的类型。</param>
      /// <returns>如果操作无异常，则会返回这个操作的搜索结果。</returns>
      public List<StoryCell> SearchByStoryCellCategory(EStoryCellCategory _keyitem)
      {
         return Stories.FindAll(delegate (StoryCell cell) { return cell.StoryCellCategory == _keyitem; });
      }
      /// <summary>
      /// 根据支撑故事线中的角色来搜索故事线
      /// </summary>
      /// <param name="_keyitem">指定的角色（在这里主要用角色姓名去判断）。</param>
      /// <returns>如果操作无异常，则会返回这个操作的搜索结果。</returns>
      public List<StoryCell> SearchByRole(Role _keyitem)
      {
         return Stories.FindAll(delegate (StoryCell cell)
         {
            return cell.Roles.Exists(delegate (Role role)
            {
               bool exists = false;
               bool eql_fname = role.Name.FamilyName == _keyitem.Name.FamilyName;
               bool eql_lname = role.Name.LastName == _keyitem.Name.LastName;
               if (eql_fname && eql_lname) exists = true;
               return exists;
            });
         });
      }
      /// <summary>
      /// 根据故事发生的地点来搜索故事线
      /// </summary>
      /// <param name="_keyitem">指定的故事发生地点。</param>
      /// <returns>如果操作无异常，则会返回这个操作的搜索结果。</returns>
      public List<StoryCell> SearchByPlace(string _keyitem)
      {
         return Stories.FindAll(delegate (StoryCell cell) { return cell.Place == _keyitem; });
      }
      /// <summary>
      /// 根据故事概要来搜索故事线
      /// </summary>
      /// <param name="_keyitem">指定的故事概要。</param>
      /// <returns>如果操作无异常，则会返回这个操作的搜索结果。</returns>
      public List<StoryCell> SearchByStorySummary(string _keyitem)
      {
         return Stories.FindAll(delegate (StoryCell cell) { return cell.Story == _keyitem; });
      }
      /// <summary>
      /// 根据字符串形式的关键词来搜索故事线
      /// </summary>
      /// <param name="_keyitem">指定的字符串形式的关键词。</param>
      /// <returns>如果操作无异常，则会返回这个操作的搜索结果。</returns>
      public List<StoryCell> SearchByEnsemble(string _keyitem)
      {
         List<StoryCell> cells = new List<StoryCell>();
         string categorystr = string.Empty;
         cells = SearchByPlace(_keyitem);
         cells.AddRange(SearchByStorySummary(_keyitem));
         cells.AddRange(Stories.FindAll(delegate (StoryCell cell)
         {
            string celldateserial = cell.HappenedDate.ToString(EDateDisplayCategory.OnlySerial);
            return _keyitem == celldateserial;
         }));
         cells.AddRange(Stories.FindAll(delegate (StoryCell cell)
         {
            return cell.Roles.Exists(delegate (Role role)
            {
               bool exists = false;
               if (role.Name.FamilyName == _keyitem && role.Name.LastName == _keyitem) exists = true;
               return exists;
            });
         }));
         cells.AddRange(Stories.FindAll(delegate (StoryCell cell)
         {
            bool iseql = false;
            switch (cell.StoryCellCategory)
            {
               case EStoryCellCategory.Background:
                  categorystr = "故事背景";
                  break;
               case EStoryCellCategory.Ceremonial:
                  categorystr = "正文";
                  break;
               case EStoryCellCategory.Outbound:
                  categorystr = "外传";
                  break;
            }
            if (categorystr == _keyitem) iseql = true;
            return iseql;
         }));
         Compendium compendium = new Compendium(cells);
         compendium.SortByHappendDate();
         return compendium.Stories;
      }
      /// <summary>
      /// 将所有的大纲信息保存到数据库
      /// </summary>
      /// <param name="_dburl">需要将大纲信息保存到哪一个数据库。</param>
      /// <param name="_isdisconn">操作结束后是否断开数据库的连接。</param>
      public void SaveToDatabase(string _dburl, bool _isdisconn)
      {
         DatabaseOperation dbopt = new DatabaseOperation(@"Data Source=" + _dburl);
         int h_year, h_month, h_day, category;
         string roles, place, story, date, sqldata;
         dbopt.InitializeConnection();
         if (dbopt.ConnectionStatus == ConnectionState.Closed) dbopt.Connect();
         dbopt.InvokeSql("delete from compendium");
         if (Count > 0)
         {
            for (int i = 0; i < Count; i++)
            {
               h_year = this[i].HappenedDate.Year;
               h_month = this[i].HappenedDate.Month;
               h_day = this[i].HappenedDate.Day;
               category = (int)this[i].StoryCellCategory;
               roles = "\x27" + this[i].GetRolesCsvFormatString() + "\x27,";
               place = "\x27" + this[i].Place + "\x27,";
               story = "\x27" + this[i].Story + "\x27";
               date = "(" + h_year + "," + h_month + "," + h_day + "," + category + ",";
               sqldata = date + roles + place + story + ")";
               dbopt.InvokeSql("insert into compendium values" + sqldata);
            }
         }
         if (_isdisconn) dbopt.Disconnect();
      }
      /// <summary>
      /// 从数据库文件读取大纲信息并加载到实例中（警告：该方法不可用，因为该方法没有任何有意义的代码实现，其重载版本ReadFromDatabase(string, RoleManagement)则拥有该函数的全部有意义的代码实现）
      /// </summary>
      /// <param name="_dburl">存储读取大纲信息的数据库文件地址。</param>
      [Obsolete("该方法不可用，因为该方法没有任何有意义的代码实现。")]
      public void ReadFromDatabase(string _dburl)
      {
         throw new NotImplementedException();
      }
      /// <summary>
      /// 从数据库文件读取大纲信息并加载到实例中
      /// </summary>
      /// <param name="_dburl">存储读取大纲信息的数据库文件地址。</param>
      /// <param name="_roles">用于检索角色的角色管理实例。</param>
      public void ReadFromDatabase(string _dburl, RoleManagement _roles)
      {
         SQLiteDataReader reader;
         DatabaseOperation dbopt = new DatabaseOperation(@"Data Source=" + _dburl);
         dbopt.InitializeConnection();
         dbopt.Connect();
         reader = dbopt.InvokeSqlToReader("select * from compendium");
         while (reader.Read())
         {
            StoryCell cell = new StoryCell();
            int hy = reader.GetInt32(reader.GetOrdinal("_happend_y"));
            byte hm = reader.GetByte(reader.GetOrdinal("_happend_m"));
            byte hd = reader.GetByte(reader.GetOrdinal("_happend_d"));
            cell.HappenedDate = new BigDate(hy, hm, hd);
            cell.StoryCellCategory = (EStoryCellCategory)reader.GetInt32(reader.GetOrdinal("_category"));
            List<string> roles_str = reader.GetString(reader.GetOrdinal("_roles")).Split(',').ToList();
            if (roles_str.Count == 1) cell.Roles.Add(_roles.SearchByName(roles_str[0])[0]);
            else
            {
               for (int i = 0; i < roles_str.Count; i++)
               {
                  cell.Roles.Add(_roles.SearchByName(roles_str[i])[0]);
               }
            }
            cell.Place = reader.GetString(reader.GetOrdinal("_place"));
            cell.Story = reader.GetString(reader.GetOrdinal("_story"));
            AddStoryCell(cell);
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
         return "Cabinink.Writer.Cores.Compendium";
      }
   }
   /// <summary>
   /// 当大纲中故事线集合为空时而抛出的异常
   /// </summary>
   [Serializable]
   public class CompendiumIsNothingException : Exception
   {
      public CompendiumIsNothingException() { }
      public CompendiumIsNothingException(string message) : base(message) { }
      public CompendiumIsNothingException(string message, Exception inner) : base(message, inner) { }
      protected CompendiumIsNothingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
