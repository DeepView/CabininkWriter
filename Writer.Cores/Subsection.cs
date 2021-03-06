﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
using cncvt = Cabinink.Writer.Cores.ChineseNumber;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 分卷编号结构体
   /// </summary>
   public struct SSubsectionNumber
   {
      /// <summary>
      /// 分卷编号的表达方式枚举
      /// </summary>
      public ESubsectionNumberMode SubsectionNumberMode;
      /// <summary>
      /// 分卷编号
      /// </summary>
      public string SubsectionNumber;
      /// <summary>
      /// 构造函数，创建一个指定分卷章节表达方式和分卷编号的SSubsectionNumber结构体实例
      /// </summary>
      /// <param name="_ssectnom">指定的分卷编号样式。</param>
      /// <param name="_ssectno">指定的分卷编号。</param>
      public SSubsectionNumber(ESubsectionNumberMode _ssectnom, string _ssectno)
      {
         SubsectionNumberMode = _ssectnom;
         SubsectionNumber = _ssectno;
      }
      /// <summary>
      /// 获取这个分卷编号的int数据
      /// </summary>
      /// <returns>该操作将会返回一个int数值，这个数值表示这个分卷的编号ID。</returns>
      public int GetPublicNumber()
      {
         int pno = 0;
         cncvt.InitializeBuilder();
         switch (SubsectionNumberMode)
         {
            case ESubsectionNumberMode.NumberAfterChineseSubsection:
            case ESubsectionNumberMode.NumberBeforeChineseSubsectionFirstAndLast:
               pno = Convert.ToInt32(cncvt.ConvertToArab(SubsectionNumber), 10);
               break;
            case ESubsectionNumberMode.ArabicNumberAfterEnglishSubsection:
               pno = Convert.ToInt32(SubsectionNumber, 10);
               break;
         }
         return pno;
      }
      /// <summary>
      /// 获取该结构体实例的字符串表达形式
      /// </summary>
      /// <returns>该操作会返回一个分卷编号的字符串表达形式，举例：Subsection 12，第五卷，卷十六。</returns>
      public override string ToString()
      {
         string tostr = string.Empty;
         ESubsectionNumberMode mode = SubsectionNumberMode;
         Action throws_string = new Action(() =>
         {
            SSubsectionNumber ssn = new SSubsectionNumber(ESubsectionNumberMode.NumberAfterChineseSubsection, "1024");
            if (ssn.SubsectionNumber.GetType() != "1024".GetType()) throw new TypeIsErrorException("参数错误，正确类型为string！");
         });
         switch (SubsectionNumberMode)
         {
            case ESubsectionNumberMode.NumberAfterChineseSubsection:
               throws_string.Invoke();
               tostr = "卷" + SubsectionNumber.ToString();
               break;
            case ESubsectionNumberMode.NumberBeforeChineseSubsectionFirstAndLast:
               throws_string.Invoke();
               tostr = "第" + SubsectionNumber.ToString() + "卷";
               break;
            case ESubsectionNumberMode.ArabicNumberAfterEnglishSubsection:
               throws_string.Invoke();
               tostr = "Subsection " + SubsectionNumber.ToString();
               break;
            default:
               throws_string.Invoke();
               tostr = "第" + SubsectionNumber.ToString() + "卷";
               break;
         }
         return tostr;
      }
   }
   /// <summary>
   /// 分卷表示类
   /// </summary>
   [DebuggerDisplay("SubsectionCount = {Count}")]
   public class Subsection : IBuilder, ICharacterWhatpulse, ILevelCreationTime
   {
      /// <summary>
      /// 当前分卷的所有章节
      /// </summary>
      private List<Chapter> chapters;
      /// <summary>
      /// 分卷编号
      /// </summary>
      private SSubsectionNumber ssectno;
      /// <summary>
      /// 分卷标题
      /// </summary>
      private string title;
      /// <summary>
      /// 当前分卷的创作时间
      /// </summary>
      private DateTime creation;
      /// <summary>
      /// 当前分卷的完结时间
      /// </summary>
      private DateTime breakup;
      /// <summary>
      /// 构造函数，创建一个非空编号的分卷实例
      /// </summary>
      /// <param name="_ssectno">指定的分卷编号。</param>
      public Subsection(SSubsectionNumber _ssectno)
      {
         if (_ssectno.SubsectionNumber == null) throw new NullSubsectionNumberException("不允许空分卷编号！");
         chapters = new List<Chapter>();
         ssectno = _ssectno;
         title = string.Empty;
      }
      /// <summary>
      /// 构造函数，创建一个非空编号和指定分卷标题的分卷实例
      /// </summary>
      /// <param name="_ssectno">指定的分卷编号。</param>
      /// <param name="_title">指定的分卷标题。</param>
      public Subsection(SSubsectionNumber _ssectno, string _title)
      {
         if (_ssectno.SubsectionNumber == null) throw new NullSubsectionNumberException("不允许空分卷编号！");
         chapters = new List<Chapter>();
         ssectno = _ssectno;
         title = _title;
      }
      /// <summary>
      /// 构造函数，创建一个非空编号、分卷标题和包含该分卷包含的章节的分卷实例
      /// </summary>
      /// <param name="_ssectno">指定的分卷编号。</param>
      /// <param name="_title">指定的分卷标题。</param>
      /// <param name="_chapters">当前分卷的章节集合。</param>
      public Subsection(SSubsectionNumber _ssectno, string _title, List<Chapter> _chapters)
      {
         if (_ssectno.SubsectionNumber == null) throw new NullSubsectionNumberException("不允许空分卷编号！");
         chapters = _chapters;
         ssectno = _ssectno;
         title = _title;
      }
      /// <summary>
      /// 获取或设置当前实例的分卷编号
      /// </summary>
      public SSubsectionNumber SubsectionNumber
      {
         get { return ssectno; }
         set
         {
            if (value.SubsectionNumber == null) throw new NullSubsectionNumberException("不允许空分卷编号！");
            ssectno = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的分卷标题
      /// </summary>
      public string Title
      {
         get { return title; }
         set { title = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的分卷包含的章节
      /// </summary>
      public List<Chapter> Chapters
      {
         get { return chapters; }
         set { chapters = value; }
      }
      /// <summary>
      /// 获取当前分卷所包含的章节数量
      /// </summary>
      public int Count
      {
         get { return Chapters.Count; }
      }
      /// <summary>
      /// 获取当前层级正文的所有字符的数量
      /// </summary>
      public uint CharacterCount
      {
         get
         {
            uint ccnt = 0;
            for (short i = 0; i < Count; i++) ccnt += this[i].CharacterCount;
            return ccnt;
         }
      }
      /// <summary>
      /// 获取当前层级正文的所有标点符号的数量
      /// </summary>
      public uint PunctuationCount
      {
         get
         {
            uint pcnt = 0;
            for (short i = 0; i < Count; i++) pcnt += this[i].PunctuationCount;
            return pcnt;
         }
      }
      /// <summary>
      /// 获取当前层级正文的所有单词或者汉字的数量
      /// </summary>
      public uint WordCount
      {
         get
         {
            return CharacterCount - PunctuationCount;
         }
      }
      /// <summary>
      /// 获取或设置当前层级的创作时间
      /// </summary>
      public DateTime CreationTime
      {
         get { return creation; }
         set { creation = value; }
      }
      /// <summary>
      /// 获取或设置当前层级的完结时间
      /// </summary>
      public DateTime BreakupTime
      {
         get { return breakup; }
         set { breakup = value; }
      }
      /// <summary>
      /// 获取或者设置指定的子章节
      /// </summary>
      /// <param name="_index">指定的子章节的列表索引。</param>
      /// <returns>该操作会通过一个索引返回一个子章节，如果这个索引超出了搜索范围，则会抛出异常。</returns>
      public Chapter this[int _index]
      {
         get
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
            return Chapters[_index];
         }
         set
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
            Chapters[_index] = value;
         }
      }
      /// <summary>
      /// 添加新的章节
      /// </summary>
      /// <param name="_item">需要被添加到分卷章节列表中的章节。</param>
      /// <returns>该操作会返回追加新章节之后的章节总数量，比如说，执行该操作之前，章节列表有20个章节，那么执行了此方法之后，返回的章节数量是21。</returns>
      public int AddChapter(Chapter _item)
      {
         SChapterNumber scn;
         if (Count == 0) scn = new SChapterNumber("0", _item.ChapterNumber.ChapterNumberMode);
         else scn = new SChapterNumber("0", this[0].ChapterNumber.ChapterNumberMode);
         Chapters.Add(_item);
         ResetChapterNumber();
         return Count;
      }
      /// <summary>
      /// 添加新的章节到指定的索引后面
      /// </summary>
      /// <param name="_item">需要被添加到分卷章节列表中的章节。</param>
      /// <param name="_index">用于添加到指定位置所对应的索引。</param>
      /// <returns>该操作会返回追加新章节之后的章节总数量，比如说，执行该操作之前，章节列表有20个章节，那么执行了此方法之后，返回的章节数量是21。</returns>
      public int AddChapter(Chapter _item, int _index)
      {
         Chapters.Insert(_index, _item);
         AdjustNumber(_index, Count, 1);
         ResetChapterNumber();
         return Count;
      }
      /// <summary>
      /// 添加新的章节到指定的索引后面
      /// </summary>
      /// <param name="_item">需要被添加到分卷章节列表中的章节。</param>
      /// <param name="_chapterno">指示添加到哪一个章节后面。</param>
      /// <returns>该操作会返回追加新章节之后的章节总数量，比如说，执行该操作之前，章节列表有20个章节，那么执行了此方法之后，返回的章节数量是21。</returns>
      public int AddChapter(Chapter _item, SChapterNumber _chapterno)
      {
         AddChapter(_item, GetChapterIndex(_chapterno));
         return Count;
      }
      /// <summary>
      /// 移除指定的章节
      /// </summary>
      /// <param name="_chapterno">需要被移除的章节的章节编号。</param>
      public void RemoveChapter(SChapterNumber _chapterno)
      {
         int index_r = GetChapterIndex(_chapterno);
         Chapters.RemoveAt(index_r);
         AdjustNumber(index_r, Count, 1);
         ResetChapterNumber();
      }
      /// <summary>
      /// 将数学范围[_start,_end)所包含的章节编号进行调整
      /// </summary>
      /// <param name="_start">调整范围的起始索引。</param>
      /// <param name="_end">调整范围的终止索引。</param>
      /// <param name="_quantity">调整量，允许负数和0。</param>
      public void AdjustNumber(int _start, int _end, int _quantity)
      {
         int toint = 0;
         SChapterNumber scn = new SChapterNumber("0", this[0].ChapterNumber.ChapterNumberMode);
         cncvt.InitializeBuilder();
         if (_end <= _start) throw new ArgumentOutOfRangeException("范围参数错误，请重新指定！");
         if (Math.Abs(_start - _end) >= Count) throw new ArgumentOutOfRangeException("范围溢出，请重新指定！");
         if ((_start < 0) || (_end >= Count)) throw new ArgumentOutOfRangeException("起始索引或者终止索引不在范围内！");
         for (int i = _start; i < _end; i++)
         {
            if (this[i].ChapterNumber.IsArabNumber())
            {
               scn.ChapterNumber = (Convert.ToInt32(this[i].ChapterNumber.ChapterNumber) + _quantity).ToString();
               this[i].ChapterNumber = scn;
            }
            else
            {
               toint = Convert.ToInt32(cncvt.ConvertToArab(this[i].ChapterNumber.ChapterNumber)) + _quantity;
               scn.ChapterNumber = cncvt.ConvertToChinese(toint);
               this[i].ChapterNumber = scn;
            }
         }
      }
      /// <summary>
      /// 获取指定章节编号在列表中的索引
      /// </summary>
      /// <param name="_chapterno">需要用于获取索引的章节编号。</param>
      /// <returns>如果这个章节编号存在则会返回一个正确的索引，否则会抛出异常。</returns>
      public int GetChapterIndex(SChapterNumber _chapterno)
      {
         int r_index = -1;
         bool eql_chapterno_no = false;
         bool eql_chapterno_mode = false;
         bool isstoped = false;
         Parallel.For(0, Count, (index, interrupt) =>
         {
            eql_chapterno_no = _chapterno.ChapterNumber.ToString() == this[index].ChapterNumber.ChapterNumber.ToString();
            eql_chapterno_mode = _chapterno.ChapterNumberMode == this[index].ChapterNumber.ChapterNumberMode;
            if (eql_chapterno_no && eql_chapterno_mode)
            {
               r_index = index;
               interrupt.Stop();
            }
            isstoped = interrupt.IsStopped;
         });
         if (isstoped == false) throw new NotFoundChapterException("找不到指定的章节！");
         return r_index;
      }
      /// <summary>
      /// 检查指定的章节编号是否存在于列表之中
      /// </summary>
      /// <param name="_chapterno">需要被用于检查的章节编号。</param>
      /// <returns>如果这个章节编号存在则会返回true，否则会返回false。</returns>
      public bool ChapterExists(SChapterNumber _chapterno)
      {
         bool exists = true;
         try
         {
            GetChapterIndex(_chapterno);
         }
         catch (NotFoundChapterException ex)
         {
            if (ex != null) exists = false;
         }
         return exists;
      }
      /// <summary>
      /// 按照索引重新定义所有章节的编号
      /// </summary>
      public void ResetChapterNumber()
      {
         ResetChapterNumber(this[0].ChapterNumber.ChapterNumberMode);
      }
      /// <summary>
      /// 按照索引重新定义所有章节的编号，并重新指定编号模式
      /// </summary>
      /// <param name="_mode">重新定义编号时需要指定的编号模式。</param>
      public void ResetChapterNumber(EChapterNumberMode _mode)
      {
         cncvt.InitializeBuilder();
         SChapterNumber scn = new SChapterNumber("0", _mode);
         Parallel.For(0, Count, (index) =>
         {
            if (this[0].ChapterNumber.IsArabNumber()) scn.ChapterNumber = Convert.ToString(index + 1, 10);
            else scn.ChapterNumber = cncvt.ConvertToChinese(index + 1);
            this[index].ChapterNumber = scn;
         });
      }
      /// <summary>
      /// 在当前的作品层级组建并生成用户能够直接使用的文本
      /// </summary>
      /// <param name="_iselinttl">是否在标题结尾追加空行。</param>
      /// <param name="_iselinend">是否在正文结尾追加空行。</param>
      /// <returns>该操作会返回一个可以供普通用户使用并阅读的文本，这些文本则是可以发表的作品内容的一部分或者全部内容。</returns>
      public string Build(bool _iselinttl, bool _iselinend)
      {
         string eptline = "\n";
         string build_st = _iselinttl ? SubsectionNumber.ToString() + Title + eptline : Title;
         for (int i = 0; i < Count; i++) build_st += this[i].Build(_iselinttl, _iselinend);
         if (_iselinend) build_st += eptline;
         return build_st;
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return SubsectionNumber.ToString() + " " + Title;
      }
   }
   /// <summary>
   /// 分卷编号表达模式枚举
   /// </summary>
   public enum ESubsectionNumberMode : int
   {
      /// <summary>
      /// 中文编号处于中文“卷”的后面，举例：卷二十三
      /// </summary>
      NumberAfterChineseSubsection = 0x0000,
      /// <summary>
      /// 中文编号处于中文“第”和“卷”的中间，格式为：第[EMBROIL_NUMBER]卷，举例：第十四卷
      /// </summary>
      NumberBeforeChineseSubsectionFirstAndLast = 0x0001,
      /// <summary>
      /// 阿拉伯数字处于英文Subsection后面，举例：Subsection 12
      /// </summary>
      ArabicNumberAfterEnglishSubsection = 0x0002
   }
   /// <summary>
   /// 当出现空分卷编号的时候需要抛出的异常
   /// </summary>
   [Serializable]
   public class NullSubsectionNumberException : Exception
   {
      public NullSubsectionNumberException() { }
      public NullSubsectionNumberException(string message) : base(message) { }
      public NullSubsectionNumberException(string message, Exception inner) : base(message, inner) { }
      protected NullSubsectionNumberException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 当找不到指定分卷时抛出的异常
   /// </summary>
   [Serializable]
   public class NotFoundSubsectionException : Exception
   {
      public NotFoundSubsectionException() { }
      public NotFoundSubsectionException(string message) : base(message) { }
      public NotFoundSubsectionException(string message, Exception inner) : base(message, inner) { }
      protected NotFoundSubsectionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 找不到指定章节时抛出的异常
   /// </summary>
   [Serializable]
   public class NotFoundChapterException : Exception
   {
      public NotFoundChapterException() { }
      public NotFoundChapterException(string message) : base(message) { }
      public NotFoundChapterException(string message, Exception inner) : base(message, inner) { }
      protected NotFoundChapterException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
