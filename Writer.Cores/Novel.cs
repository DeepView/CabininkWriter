﻿using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 作品信息结构体
   /// </summary>
   public struct SNovelInformation
   {
      /// <summary>
      /// 作品名称，这个名称是用于作品的正式名称或者发布名称
      /// </summary>
      public string NovelName;
      /// <summary>
      /// 作者名称，一般而言，作者名称指的是作者的笔名，而非真实姓名
      /// </summary>
      public string WriterName;
      /// <summary>
      /// 作品的备注信息，比如说这里可以填写作品概要
      /// </summary>
      public string Remarks;
      /// <summary>
      /// 作品的内容分类，这个通常按照内容题材来分类的， 比如说科幻、推理和修真等等
      /// </summary>
      public ENovelCategory Category;
      /// <summary>
      /// 本作品开始创作的时间，这个时间包含了日期和当天的详细时间，精确到秒，当然一般不建议使用详细时间
      /// </summary>
      public DateTime CreationTime;
      /// <summary>
      /// 本作品结束创作或者完结的时间，这个时间包含了日期和当天的详细时间，精确到秒，当然一般不建议使用详细时间
      /// </summary>
      public DateTime BreakupTime;
      /// <summary>
      /// 该作品的相关关键词，这些关键词可以大致的说明这部作品描述的内容是与什么事物产生关联
      /// </summary>
      public List<string> Keywords;
      /// <summary>
      /// 资源文件列表，这里的资源文件主要指的是作品策划、数据资料、重要笔记等等
      /// </summary>
      public List<string> ResourceFiles;
      /// <summary>
      /// 构造函数，创建一个拥有作品名称、作者笔名、详细摘要、创作时间和资源列表的作品信息结构体
      /// </summary>
      /// <param name="_nvlname">指定的作品名称。</param>
      /// <param name="_wrtname">指定的作者笔名。</param>
      /// <param name="_remarks">指定的作品摘要。</param>
      /// <param name="_category">指定的作品分类。</param>
      /// <param name="_stime">指定的创作时间。</param>
      /// <param name="_kw">指定的关键词。</param>
      /// <param name="_resf">指定的资源列表。</param>
      public SNovelInformation(string _nvlname, string _wrtname, string _remarks, ENovelCategory _category, DateTime _ctime, DateTime _btime, List<string> _kw, List<string> _resf)
      {
         NovelName = _nvlname;
         WriterName = _wrtname;
         Remarks = _remarks;
         Category = _category;
         CreationTime = _ctime;
         BreakupTime = _btime;
         Keywords = _kw;
         ResourceFiles = _resf;
      }
      /// <summary>
      /// 获取关键词的CSV文件格式的字符串
      /// </summary>
      /// <returns>该操作将会返回一个CSV文件格式的字符串。</returns>
      public string GetKeywordsCsvString()
      {
         string csvst = string.Empty;
         for (int i = 0; i < Keywords.Count; i++) csvst = csvst + Keywords[i] + ",";
         return csvst.Substring(0, csvst.Length - 1);
      }
   }
   /// <summary>
   /// 作品表示类
   /// </summary>
   [DebuggerDisplay("Novel = {ToString()}, Count = {Count}")]
   public class Novel : IBuilder, ICharacterWhatpulse, INovelManagementSecurity
   {
      /// <summary>
      /// 当前作品的管理密码
      /// </summary>
      private string password;
      /// <summary>
      /// 指示当前作品是否允许操作
      /// </summary>
      private bool isoperation;
      /// <summary>
      /// 当前作品的作品信息
      /// </summary>
      private SNovelInformation information;
      /// <summary>
      /// 分卷列表
      /// </summary>
      private List<Subsection> subsections;
      /// <summary>
      /// 构造函数，创建一个只存在作品信息的空作品
      /// </summary>
      /// <param name="_info">指定的作品信息。</param>
      public Novel(SNovelInformation _info)
      {
         information = _info;
         subsections = new List<Subsection>();
      }
      /// <summary>
      /// 构造函数，创建一个包含作品信息和分卷列表的作品
      /// </summary>
      /// <param name="_info">指定的作品信息。</param>
      /// <param name="_subsections">指定的分卷列表。</param>
      /// <param name="_flag">指示当前作品是否允许被操作。</param>
      public Novel(SNovelInformation _info, List<Subsection> _subsections, bool _flag)
      {
         information = _info;
         subsections = _subsections;
         isoperation = _flag;
      }
      /// <summary>
      /// 获取或者设置作品的信息
      /// </summary>
      public SNovelInformation Information
      {
         get { return information; }
         set
         {
            bool eql_info_nvlname = information.NovelName == string.Empty;
            bool eql_info_wrtname = information.WriterName == string.Empty;
            bool eql_info_remarks = information.Remarks == string.Empty;
            bool eql_info_srttime = information.CreationTime == null;
            if ((eql_info_nvlname && eql_info_wrtname && eql_info_remarks && eql_info_srttime))
            {
               throw new InformationNotEqualException("信息不能为空！");
            }
            information = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的操作标识
      /// </summary>
      public bool OperationFlag
      {
         get { return isoperation; }
         set { isoperation = value; }
      }
      /// <summary>
      /// 获取或设置当前作品的分卷列表
      /// </summary>
      public List<Subsection> Subsections
      {
         get { return subsections; }
         set { subsections = value; }
      }
      /// <summary>
      /// 获取或设置当前作品的某一分卷
      /// </summary>
      /// <param name="_index">需要获取指定分卷的索引。</param>
      /// <returns>如果指定的索引没有超出范围，那么该操作将会返回一个指定索引所对应的那个分卷。</returns>
      public Subsection this[int _index]
      {
         get
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("_index", "索引超出范围！");
            return Subsections[_index];
         }
         set
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("_index", "索引超出范围！");
            Subsections[_index] = value;
         }
      }
      /// <summary>
      /// 获取当前作品的分卷总量
      /// </summary>
      public int Count
      {
         get { return Subsections.Count(); }
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
      /// 获取或设置当前作品的管理密码，但是为了考虑系统的安全性，所以操作完成后，password私有字段保存的是密文而非明文
      /// </summary>
      public string Password
      {
         get
         {
            SChapterNumber cno = new SChapterNumber("0", EChapterNumberMode.ArabicInEnglishChapterMark);
            return new Chapter(cno, "passwd").Decryption(password);
         }
         set
         {
            if (value.Length < 4 || value.Length > 16) throw new LengthOverflowException("密码的长度不能超出[4,16]这个范围！");
            if (Convert.ToByte(value, 10) > 127) throw new IllegitimateCharsException("密码不允许出现非法字符！");
            password = EncryptPassword(value);
         }
      }
      /// <summary>
      /// 加密指定的管理密码
      /// </summary>
      /// <param name="_decstr">需要被加密的管理密码。</param>
      /// <returns>如果该操作执行成功，则会返回一个被加密的密文。</returns>
      public string EncryptPassword(string _decstr)
      {
         SChapterNumber cno = new SChapterNumber("0", EChapterNumberMode.ArabicInEnglishChapterMark);
         Chapter decstring = new Chapter(cno, "passwd");
         decstring.Body = _decstr;
         return decstring.Encryption();
      }
      /// <summary>
      /// 更新当前作品的管理密码
      /// </summary>
      /// <param name="_oldpasswd">以前的旧密码。</param>
      /// <param name="_newpasswd">输入的新密码。</param>
      /// <returns>如果该操作执行成功，则返回true，否则返回false。</returns>
      public bool UpdatePassword(string _oldpasswd, string _newpasswd)
      {
         SChapterNumber cno = new SChapterNumber("0", EChapterNumberMode.ArabicInEnglishChapterMark);
         bool successful = true;
         string plaintext_old = new Chapter(cno, "passwd").Decryption(_oldpasswd);
         if (_newpasswd != plaintext_old) successful = false;
         else Password = _newpasswd;
         return successful;
      }
      /// <summary>
      /// 添加新的分卷
      /// </summary>
      /// <param name="_item">需要被添加到作品里面的分卷。</param>
      /// <returns>这个操作会返回一个整数值，这个整数值表示执行该操作之后的分卷总数。</returns>
      public int AddSubsection(Subsection _item)
      {
         if (OperationFlag == false) throw new ExclusionOperationException("当前状态下不允许操作作品！");
         Subsections.Add(_item);
         return Count;
      }
      /// <summary>
      /// 添加新的分卷到指定位置
      /// </summary>
      /// <param name="_item">需要被添加到作品里面的分卷。</param>
      /// <param name="_index">用于添加到指定位置所对应的索引。</param>
      /// <returns>这个操作会返回一个整数值，这个整数值表示执行该操作之后的分卷总数。</returns>
      public int AddSubsection(Subsection _item, int _index)
      {
         if (OperationFlag == false) throw new ExclusionOperationException("当前状态下不允许操作作品！");
         Subsections.Insert(_index, _item);
         return Count;
      }
      /// <summary>
      /// 添加新的分卷到指定分卷后面
      /// </summary>
      /// <param name="_item">需要被添加到作品里面的分卷。</param>
      /// <param name="_ssectno">指示添加到哪一个分卷后面。</param>
      /// <returns>这个操作会返回一个整数值，这个整数值表示执行该操作之后的分卷总数。</returns>
      public int AddSubsection(Subsection _item, SSubsectionNumber _ssectno)
      {
         if (OperationFlag == false) throw new ExclusionOperationException("当前状态下不允许操作作品！");
         AddSubsection(_item, GetSubsectionIndex(_ssectno));
         return Count;
      }
      /// <summary>
      /// 移除指定的分卷
      /// </summary>
      /// <param name="_ssectno">需要被移除的分卷的分卷编号。</param>
      public void RemoveSubsection(SSubsectionNumber _ssectno)
      {
         if (OperationFlag == false) throw new ExclusionOperationException("当前状态下不允许操作作品！");
         Subsections.RemoveAt(GetSubsectionIndex(_ssectno));
      }
      /// <summary>
      /// 获取指定分卷在作品实例中的索引，当然这个操作是忽略了分卷编号的一个操作
      /// </summary>
      /// <param name="_subsection">需要被查找的分卷。</param>
      /// <returns>如果这个操作无异常，则将会返回一个整形的数据，这个数据用来表示指定分卷在当前作品中所对应的索引。</returns>
      public int GetSubsectionIndex(Subsection _subsection)
      {
         int index = 0;
         for (int i = 0; i < Count; i++)
         {
            if (this[i].Title == _subsection.Title)
            {
               index = i;
               break;
            }
         }
         return index;
      }
      /// <summary>
      /// 获取指定分卷编号在列表中的索引
      /// </summary>
      /// <param name="_ssectno">需要用于获取索引的分卷编号。</param>
      /// <returns>如果这个分卷编号存在则会返回一个正确的索引，否则会抛出异常。</returns>
      public int GetSubsectionIndex(SSubsectionNumber _ssectno)
      {
         int r_index = -1;
         bool eql_ssectno_no = false;
         bool eql_ssectno_mode = false;
         bool isstoped = false;
         Parallel.For(0, Count, (index, interrupt) =>
         {
            eql_ssectno_no = _ssectno.SubsectionNumber.ToString() == this[index].SubsectionNumber.SubsectionNumber.ToString();
            eql_ssectno_mode = _ssectno.SubsectionNumberMode == this[index].SubsectionNumber.SubsectionNumberMode;
            if (eql_ssectno_no && eql_ssectno_mode)
            {
               r_index = index;
               interrupt.Stop();
            }
            isstoped = interrupt.IsStopped;
         });
         if (isstoped == false) throw new NotFoundSubsectionException("找不到该分卷！");
         return r_index;
      }
      /// <summary>
      /// 检查指定的分卷编号是否存在于列表之中
      /// </summary>
      /// <param name="_ssectno">需要被用于检查的分卷编号。</param>
      /// <returns>如果这个分卷编号存在则会返回true，否则会返回false。</returns>
      public bool SubsectionExists(SSubsectionNumber _ssectno)
      {
         bool exists = true;
         try
         {
            GetSubsectionIndex(_ssectno);
         }
         catch (NotFoundSubsectionException ex)
         {
            if (ex != null) exists = false;
         }
         return exists;
      }
      /// <summary>
      /// 打开指定的资源
      /// </summary>
      /// <param name="_resurl">指定资源的文件路径。</param>
      /// <param name="_arguments">打开资源文件所使用的应用程序的参数，如果没有参数，这一项可以设置为null或者为String.Empty。</param>
      /// <returns>如果这个资源成功的被打开，则会返回打开该资源文件的应用程序的进程实例。</returns>
      public Process OpenResource(string _resurl, string _arguments)
      {
         return Process.Start(_resurl, _arguments);
      }
      /// <summary>
      /// 打开指定的资源
      /// </summary>
      /// <param name="_index">指定资源在资源列表中的索引。</param>
      /// <param name="_arguments">打开资源文件所使用的应用程序的参数，如果没有参数，这一项可以设置为null或者为String.Empty。</param>
      /// <returns>如果这个资源成功的被打开，则会返回打开该资源文件的应用程序的进程实例。</returns>
      public Process OpenResource(int _index, string _arguments)
      {
         if (_index > Information.ResourceFiles.Count || _index < 0) throw new ArgumentOutOfRangeException("索引超出范围！");
         return OpenResource(Information.ResourceFiles[_index], _arguments);
      }
      /// <summary>
      /// 添加资源文件到资源列表中
      /// </summary>
      /// <param name="_resurl">需要被添加到列表之中的资源文件的路径。</param>
      public void AddResource(string _resurl)
      {
         if (OperationFlag == false) throw new ExclusionOperationException("当前状态下不允许操作作品！");
         Information.ResourceFiles.Add(_resurl);
      }
      /// <summary>
      /// 添加一个资源集合到资源列表中与之合并
      /// </summary>
      /// <param name="_resurlccx">需要被添加进原资源列表的资源集合。</param>
      public void AddResourceCollection(List<string> _resurlccx)
      {
         if (OperationFlag == false) throw new ExclusionOperationException("当前状态下不允许操作作品！");
         Information.ResourceFiles.AddRange(_resurlccx);
      }
      /// <summary>
      /// 移除指定索引所对应的资源
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      public void RemoveResource(int _index)
      {
         if (OperationFlag == false) throw new ExclusionOperationException("当前状态下不允许操作作品！");
         if (_index > Information.ResourceFiles.Count || _index < 0) throw new ArgumentOutOfRangeException("索引超出范围！");
         FileOperation.DeleteFile(Information.ResourceFiles[_index]);
         Information.ResourceFiles.RemoveAt(_index);
      }
      /// <summary>
      /// 移除全字匹配字符串的资源文件
      /// </summary>
      /// <param name="_resurl">需要进行全字匹配的资源文件路径。</param>
      /// <param name="_isrmvalleqlst">指示是否移除所有满足条件的字符串，如果这个参数为true，则会移除所有满足条件的资源文件，否则只是移除匹配到的第一个满足条件的资源文件。</param>
      public void RemoveResource(string _resurl, bool _isrmvalleqlst)
      {
         if (OperationFlag == false) throw new ExclusionOperationException("当前状态下不允许操作作品！");
         int maxloop = GetResourceListCount();
         if (_isrmvalleqlst == false)
         {
            for (int i = 0; i < maxloop; i++)
            {
               if (_resurl == Information.ResourceFiles[i])
               {
                  FileOperation.DeleteFile(Information.ResourceFiles[i]);
                  Information.ResourceFiles.RemoveAt(i);
                  break;
               }
            }
         }
         else
         {
            Parallel.For(0, maxloop, (index) =>
            {
               if (_resurl == Information.ResourceFiles[index])
               {
                  FileOperation.DeleteFile(Information.ResourceFiles[index]);
                  Information.ResourceFiles.RemoveAt(index);
               }
            });
         }
      }
      /// <summary>
      /// 获取资源列表的元素数量
      /// </summary>
      /// <returns>该操作会返回一个整形数据，用于表示资源列表的所有元素的数量。</returns>
      public int GetResourceListCount()
      {
         return Information.ResourceFiles.Count;
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
         string build_st = _iselinttl ? Information.NovelName + eptline : Information.NovelName;
         for (int i = 0; i < Count; i++) build_st += this[i].Build(_iselinttl, _iselinend);
         if (_iselinend) build_st += eptline;
         return build_st;
      }
      /// <summary>
      /// 停止操作并清空所有的分卷
      /// </summary>
      public void StopOperation()
      {
         Subsections = null;
         OperationFlag = false;
      }
      /// <summary>
      /// 获取作品摘要字符串
      /// </summary>
      /// <returns>该操作返回的字符串值表示的是这部作品的简单摘要信息。</returns>
      public string GetNovelString()
      {
         return Information.NovelName + " " + Information.WriterName + " " + Information.Category.ToString();
      }
      /// <summary>
      /// 获取当前Novel实例的完整类名的字符串表达形式
      /// </summary>
      /// <returns>该操作会返回一个当前实例的完整类名的字符串表达形式。</returns>
      public override string ToString()
      {
         return Information.NovelName + "-" + Information.WriterName;
      }
   }
   /// <summary>
   /// 枚举注释特性类
   /// </summary>
   [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
   public sealed class EnumDescriptionAttribute : Attribute
   {
      /// <summary>
      /// 枚举的注释
      /// </summary>
      private string description;
      /// <summary>
      /// 构造函数，创建一个指定枚举注释的实例
      /// </summary>
      /// <param name="_description">枚举值对应的注释。</param>
      public EnumDescriptionAttribute(string _description) : base()
      {
         description = _description;
      }
      /// <summary>
      /// 获取当前实例的枚举注释
      /// </summary>
      public string Description { get { return description; } }
   }
   /// <summary>
   /// 作品内容分类的枚举
   /// </summary>
   public enum ENovelCategory : int
   {
      /// <summary>
      /// 玄幻
      /// </summary>
      [EnumDescription("玄幻")]
      Unreal = 0x0001,
      /// <summary>
      /// 都市
      /// </summary>
      [EnumDescription("都市")]
      Metropolis = 0x0002,
      /// <summary>
      /// 修真
      /// </summary>
      [EnumDescription("修真")]
      Coatard = 0x0003,
      /// <summary>
      /// 武侠
      /// </summary>
      [EnumDescription("武侠")]
      Swordsmen = 0x0004,
      /// <summary>
      /// 军事
      /// </summary>
      [EnumDescription("军事")]
      Military = 0x0005,
      /// <summary>
      /// 历史
      /// </summary>
      [EnumDescription("历史")]
      History = 0x0006,
      /// <summary>
      /// 网游
      /// </summary>
      [EnumDescription("网游")]
      OnlineGames = 0x0007,
      /// <summary>
      /// 科幻
      /// </summary>
      [EnumDescription("科幻")]
      ScienceFiction = 0x0008,
      /// <summary>
      /// 竞技
      /// </summary>
      [EnumDescription("竞技")]
      Athletics = 0x0009,
      /// <summary>
      /// 体育
      /// </summary>
      [EnumDescription("体育")]
      PhysicalEducation = 0x000a,
      /// <summary>
      /// 灵异
      /// </summary>
      [EnumDescription("灵异")]
      Supernatural = 0x000b,
      /// <summary>
      /// 推理
      /// </summary>
      [EnumDescription("推理")]
      Deduction = 0x000c,
      /// <summary>
      /// 同人
      /// </summary>
      [EnumDescription("同人")]
      SamePerson = 0x000d,
      /// <summary>
      /// 恐怖
      /// </summary>
      [EnumDescription("恐怖")]
      Horror = 0x000e,
      /// <summary>
      /// 穿越
      /// </summary>
      [EnumDescription("穿越")]
      TimeTravel = 0x000f,
      /// <summary>
      /// 其他
      /// </summary>
      [EnumDescription("其他")]
      Other = 0x0010
   }
   /// <summary>
   /// 当作品信息不相等时抛出的异常
   /// </summary>
   [Serializable]
   public class InformationNotEqualException : Exception
   {
      public InformationNotEqualException() { }
      public InformationNotEqualException(string message) : base(message) { }
      public InformationNotEqualException(string message, Exception inner) : base(message, inner) { }
      protected InformationNotEqualException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 当文本长度超出指定范围时而抛出的异常
   /// </summary>
   [Serializable]
   public class LengthOverflowException : Exception
   {
      public LengthOverflowException() { }
      public LengthOverflowException(string message) : base(message) { }
      public LengthOverflowException(string message, Exception inner) : base(message, inner) { }
      protected LengthOverflowException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 当出现非法字符时而抛出的异常
   /// </summary>
   [Serializable]
   public class IllegitimateCharsException : Exception
   {
      public IllegitimateCharsException() { }
      public IllegitimateCharsException(string message) : base(message) { }
      public IllegitimateCharsException(string message, Exception inner) : base(message, inner) { }
      protected IllegitimateCharsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 尝试在操作标识为false的情况下去操作作品而抛出的异常
   /// </summary>
   [Serializable]
   public class ExclusionOperationException : Exception
   {
      public ExclusionOperationException() { }
      public ExclusionOperationException(string message) : base(message) { }
      public ExclusionOperationException(string message, Exception inner) : base(message, inner) { }
      protected ExclusionOperationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}

