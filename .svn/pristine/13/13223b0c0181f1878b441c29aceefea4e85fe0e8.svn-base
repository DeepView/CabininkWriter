using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 故事线单元类
   /// </summary>
   [DebuggerDisplay("StoryCell = {GetCsvFormatString()}")]
   public class StoryCell : ICsvFormater
   {
      /// <summary>
      /// 故事发生的时间
      /// </summary>
      private BigDate happened;
      /// <summary>
      /// 故事的类型，是背景还是正文等等
      /// </summary>
      private EStoryCellCategory category;
      /// <summary>
      /// 这个故事中包含的主要人物
      /// </summary>
      private List<Role> roles;
      /// <summary>
      /// 故事发生的地点
      /// </summary>
      private string place;
      /// <summary>
      /// 故事的简要概述
      /// </summary>
      private string story;
      /// <summary>
      /// 构造函数，创建一个空的故事单元实例
      /// </summary>
      public StoryCell()
      {
         happened = new BigDate(DateTime.Now);
         category = EStoryCellCategory.Background;
         roles = new List<Role>();
         place = string.Empty;
         story = string.Empty;
      }
      /// <summary>
      /// 构造函数，创建一个拥有指定时间、故事类型和故事概要的故事线
      /// </summary>
      /// <param name="_happened">故事的发生时间。</param>
      /// <param name="_category">故事线的类型。</param>
      /// <param name="_story">故事的概述。</param>
      public StoryCell(BigDate _happened, EStoryCellCategory _category, string _story)
      {
         if (_story == null || _story == string.Empty) throw new ObjectDisposedException("故事概述字段不能为空！");
         happened = _happened;
         category = _category;
         story = _story;
      }
      /// <summary>
      /// 构造函数，创建一个拥有指定时间、故事类型、发生地点和故事概要的故事线
      /// </summary>
      /// <param name="_happened">故事的发生时间。</param>
      /// <param name="_category">故事线的类型。</param>
      /// <param name="_place">故事发生的地点。</param>
      /// <param name="_story">故事的概述。</param>
      public StoryCell(BigDate _happened, EStoryCellCategory _category, string _place, string _story)
      {
         if (_story == null || _story == string.Empty) throw new ObjectDisposedException("故事概述字段不能为空！");
         happened = _happened;
         category = _category;
         place = _place;
         story = _story;
      }
      /// <summary>
      /// 构造函数，创建一个拥有制定时间、故事类型、主要角色、发生地点和故事概要的故事线
      /// </summary>
      /// <param name="_happened">故事的发生时间。</param>
      /// <param name="_category">故事线的类型。</param>
      /// <param name="_roles">故事中的主要角色。</param>
      /// <param name="_place">故事发生的地点。</param>
      /// <param name="_story">故事的概述。</param>
      public StoryCell(BigDate _happened, EStoryCellCategory _category, List<Role> _roles, string _place, string _story)
      {
         if (_story == null || _story == string.Empty) throw new ObjectDisposedException("故事概述字段不能为空！");
         happened = _happened;
         category = _category;
         roles = _roles;
         place = _place;
         story = _story;
      }
      /// <summary>
      /// 获取或设置当前实例故事的发生时间
      /// </summary>
      public BigDate HappenedDate
      {
         get { return happened; }
         set { happened = value; }
      }
      /// <summary>
      /// 获取或设置当前实例故事的类型
      /// </summary>
      public EStoryCellCategory StoryCellCategory
      {
         get { return category; }
         set { category = value; }
      }
      /// <summary>
      /// 获取或设置当前实例故事的主要参与角色
      /// </summary>
      public List<Role> Roles
      {
         get { return roles; }
         set { roles = value; }
      }
      /// <summary>
      /// 获取或设置当前实例故事的发生地点
      /// </summary>
      public string Place
      {
         get { return place; }
         set { place = value; }
      }
      /// <summary>
      /// 获取或设置当前实例故事的简单概述
      /// </summary>
      public string Story
      {
         get { return story; }
         set
         {
            if (value == null || value == string.Empty) throw new ObjectDisposedException("故事概述字段不能为空！");
            story = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例故事的其中某一个主要参与角色
      /// </summary>
      /// <param name="_index">对应角色集合中某角色的索引。</param>
      /// <returns>如果无异常发生，这个操作将会返回指定索引所对应的角色。</returns>
      public Role this[int _index]
      {
         get
         {
            if (_index < 0 && _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
            return Roles[_index];
         }
         set
         {
            if (_index < 0 && _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
            Roles[_index] = value;
         }
      }
      /// <summary>
      /// 获取当前实例故事主要参与角色的数量
      /// </summary>
      public uint Count
      {
         get { return (uint)Roles.Count; }
      }
      /// <summary>
      /// 判断两个故事线的故事发生时间是否重合
      /// </summary>
      /// <param name="_cell">需要被用来判断时间重合的故事线。</param>
      /// <returns>如果故事线时间重合，则返回true，否则返回false。</returns>
      public bool IsCoincidentHappenedDate(StoryCell _cell)
      {
         bool iscoincident = false;
         string currdateserial = HappenedDate.ToString(EDateDisplayCategory.OnlySerial);
         string becalcdateserial = _cell.HappenedDate.ToString(EDateDisplayCategory.OnlySerial);
         if (currdateserial == becalcdateserial)
         {
            iscoincident = true;
         }
         return iscoincident;
      }
      /// <summary>
      /// 与指定的故事判断，并获取最先发生的故事
      /// </summary>
      /// <param name="_cell">需要被参与判断的故事线。</param>
      /// <returns>如果无异常发生，则该操作将会返回一个最先发生的那个故事线。</returns>
      public StoryCell HappenedBefore(StoryCell _cell)
      {
         if (IsCoincidentHappenedDate(_cell)) throw new HappendDateIsEqualException("故事的发生时间相同时无法比较故事的时间顺序！");
         StoryCell before = this;
         string currdateserial = HappenedDate.ToString(EDateDisplayCategory.OnlySerial);
         string becalcdateserial = _cell.HappenedDate.ToString(EDateDisplayCategory.OnlySerial);
         if (Convert.ToUInt64(currdateserial, 10) < Convert.ToUInt64(becalcdateserial, 10)) before = _cell;
         return before;
      }
      /// <summary>
      /// 获取当前故事线的CSV文件格式字符串
      /// </summary>
      /// <returns>方法若执行成功，则将返回一个CSV文件格式的字符串，CSV格式文件的内容是将每一个元素通过英文逗号来分割并加以识别的。</returns>
      public string GetCsvFormatString()
      {
         string formatstr = string.Empty;
         string rolescsvst = string.Empty;
         string dateserial = HappenedDate.ToString(EDateDisplayCategory.DashedSegmentation);
         string categorystr = string.Empty;
         switch (StoryCellCategory)
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
            default:
               categorystr = "正文";
               break;
         }
         for (int i = 0; i < Count; i++) rolescsvst = rolescsvst + this[i].Name.ToString(true) + @"/";
         rolescsvst = rolescsvst.Substring(0, rolescsvst.Length - 1);
         formatstr = dateserial + "," + categorystr + "," + rolescsvst + "," + Place + "," + Story;
         return formatstr;
      }
      /// <summary>
      /// 获取当前故事线角色集合的CSV文件格式的字符串
      /// </summary>
      /// <returns>当前操作会返回一个CSV文件格式的字符串，这个字符串的数据源来自于类型为角色集合实例的属性Roles。</returns>
      public string GetRolesCsvFormatString()
      {
         string csvstr = string.Empty;
         for (int i = 0; i < Roles.Count; i++) csvstr = csvstr + this[i].Name.ToString(true) + ",";
         return csvstr.Substring(0, csvstr.Length - 1);
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.StoryCell";
      }
   }
   /// <summary>
   /// 故事线类型枚举
   /// </summary>
   public enum EStoryCellCategory : int
   {
      /// <summary>
      /// 故事背景
      /// </summary>
      [EnumDescription("故事背景")]
      Background = 0x0000,
      /// <summary>
      /// 正文
      /// </summary>
      [EnumDescription("正文")]
      Ceremonial = 0x0001,
      /// <summary>
      /// 外传
      /// </summary>
      [EnumDescription("外传")]
      Outbound = 0x0002
   }
   /// <summary>
   /// 发生时间相同而抛出的异常
   /// </summary>
   [Serializable]
   public class HappendDateIsEqualException : Exception
   {
      public HappendDateIsEqualException() { }
      public HappendDateIsEqualException(string message) : base(message) { }
      public HappendDateIsEqualException(string message, Exception inner) : base(message, inner) { }
      protected HappendDateIsEqualException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
