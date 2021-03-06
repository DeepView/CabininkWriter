﻿using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using cncvt = Cabinink.Writer.Cores.ChineseNumber;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 章节编号结构体
   /// </summary>
   public struct SChapterNumber
   {
      /// <summary>
      /// 章节编号
      /// </summary>
      public string ChapterNumber;
      /// <summary>
      /// 章节编号的样式，或者说是编号的显示方式
      /// </summary>
      public EChapterNumberMode ChapterNumberMode;
      /// <summary>
      /// 构造函数，创建一个指定的SChapterNumber结构体实例
      /// </summary>
      /// <param name="_chapterno">指定的章节编号。</param>
      /// <param name="_chapternom">指定的章节编号的样式。</param>
      public SChapterNumber(string _chapterno, EChapterNumberMode _chapternom)
      {
         ChapterNumber = _chapterno;
         ChapterNumberMode = _chapternom;
      }
      /// <summary>
      /// 指示章节编号是否是阿拉伯数字
      /// </summary>
      /// <returns>该操作返回一个bool数据类型值，这个值表示的是当前章节编号是否是阿拉伯数字，如果这个值为true，则章节编号为阿拉伯数字，否则为中文数字。</returns>
      public bool IsArabNumber()
      {
         bool isarab = true;
         switch (ChapterNumberMode)
         {
            case EChapterNumberMode.OnlyArabic:
            case EChapterNumberMode.ArabicInEnglishChapterMark:
            case EChapterNumberMode.ArabicInChineseChapterMark:
            case EChapterNumberMode.ArabicInChineseSectionMark:
            case EChapterNumberMode.ArabicBeforeChineseChapterMarkFirstWordAndLastWord:
            case EChapterNumberMode.ArabicBeforeChineseSectionMarkFirstWordAndLastWord:
               break;
            case EChapterNumberMode.OnlyChineseNum:
            case EChapterNumberMode.ChineseNumInChineseChapterMark:
            case EChapterNumberMode.ChineseNumInChineseSectionMark:
            case EChapterNumberMode.ChineseNumBeforeChineseChapterMarkFirstWordAndLastWord:
            case EChapterNumberMode.ChineseNumBeforeChineseSectionMarkFirstWordAndLastWord:
            default:
               isarab = false;
               break;
         }
         return isarab;
      }
      /// <summary>
      /// 获取这个章节编号的int数据
      /// </summary>
      /// <returns>该操作将会返回一个int数值，这个数值表示这个章节的编号ID。</returns>
      public int GetPublicNumber()
      {
         int pno = 0;
         cncvt.InitializeBuilder();
         if (IsArabNumber()) pno = Convert.ToInt32(ChapterNumber, 10);
         else pno = Convert.ToInt32(cncvt.ConvertToArab(ChapterNumber), 10);
         return pno;
      }
      /// <summary>
      /// 获取该结构体实例的字符串表达形式
      /// </summary>
      /// <returns>该操作会返回一个章节编号的字符串表达形式，举例：Chapter 23，第八十二章，章69。</returns>
      public override string ToString()
      {
         string tostr = string.Empty;
         EChapterNumberMode mode = ChapterNumberMode;
         Action throws_string = new Action(() =>
         {
            SChapterNumber scn = new SChapterNumber("1024", mode);
            if (scn.ChapterNumber.GetType() != "1024".GetType()) throw new TypeIsErrorException("参数错误，正确类型为string！");
         });
         switch (ChapterNumberMode)
         {
            case EChapterNumberMode.OnlyArabic:
               throws_string.Invoke();
               tostr = ChapterNumber.ToString();
               break;
            case EChapterNumberMode.ArabicInEnglishChapterMark:
               throws_string.Invoke();
               tostr = "Chapter " + ChapterNumber.ToString();
               break;
            case EChapterNumberMode.ArabicInChineseChapterMark:
               throws_string.Invoke();
               tostr = "章" + ChapterNumber.ToString();
               break;
            case EChapterNumberMode.ArabicInChineseSectionMark:
               throws_string.Invoke();
               tostr = "节" + ChapterNumber.ToString();
               break;
            case EChapterNumberMode.ArabicBeforeChineseChapterMarkFirstWordAndLastWord:
               throws_string.Invoke();
               tostr = "第" + ChapterNumber.ToString() + "章";
               break;
            case EChapterNumberMode.ArabicBeforeChineseSectionMarkFirstWordAndLastWord:
               throws_string.Invoke();
               tostr = "第" + ChapterNumber.ToString() + "节";
               break;
            case EChapterNumberMode.OnlyChineseNum:
               throws_string.Invoke();
               tostr = ChapterNumber.ToString();
               break;
            case EChapterNumberMode.ChineseNumInChineseChapterMark:
               throws_string.Invoke();
               tostr = "章" + ChapterNumber.ToString();
               break;
            case EChapterNumberMode.ChineseNumInChineseSectionMark:
               throws_string.Invoke();
               tostr = "节" + ChapterNumber.ToString();
               break;
            case EChapterNumberMode.ChineseNumBeforeChineseChapterMarkFirstWordAndLastWord:
               throws_string.Invoke();
               tostr = "第" + ChapterNumber.ToString() + "章";
               break;
            case EChapterNumberMode.ChineseNumBeforeChineseSectionMarkFirstWordAndLastWord:
               throws_string.Invoke();
               tostr = "第" + ChapterNumber.ToString() + "节";
               break;
            default:
               throws_string.Invoke();
               tostr = "第" + ChapterNumber.ToString() + "章";
               break;
         }
         return tostr;
      }
   }
   /// <summary>
   /// 章节备份结构体
   /// </summary>
   public struct SChapterBodyBackup
   {
      /// <summary>
      /// 备份章节的章节编号
      /// </summary>
      public SChapterNumber ChapterNumber;
      /// <summary>
      /// 章节的备份时间
      /// </summary>
      public DateTime BackupTime;
      /// <summary>
      /// 章节的备份正文内容
      /// </summary>
      public string BackupBody;
      /// <summary>
      /// 构造函数，创建一个指定章节编号和章节备份内容的SChapterBodyBackup结构体实例
      /// </summary>
      /// <param name="_chapterno">指定的备份章节编号。</param>
      /// <param name="_bkpbody">指定的章节备份内容。</param>
      public SChapterBodyBackup(SChapterNumber _chapterno, string _bkpbody)
      {
         bool b_cpn_no = _chapterno.ChapterNumber == null;
         if (b_cpn_no) throw new NullChapterNumberException("章节编号不能为null！");
         ChapterNumber = _chapterno;
         BackupTime = DateTime.Now;
         BackupBody = _bkpbody;
      }
   }
   /// <summary>
   /// 章节表示类
   /// </summary>
   [DebuggerDisplay("ChapterTitle = {Title}, ChapterWordCount = {WordCount}")]
   public class Chapter : IBuilder, ICharacterWhatpulse, ILevelCreationTime, INovelContextSecurity, ISentences
   {
      /// <summary>
      /// 章节的正文内容
      /// </summary>
      private string body;
      /// <summary>
      /// 章节的标题文本
      /// </summary>
      private string title;
      /// <summary>
      /// 章节的编号
      /// </summary>
      private SChapterNumber chapterno;
      /// <summary>
      /// 章节正文内容备份
      /// </summary>
      private List<SChapterBodyBackup> backup;
      /// <summary>
      /// 当前章节的创作时间
      /// </summary>
      private DateTime creation;
      /// <summary>
      /// 当前章节的完结时间
      /// </summary>
      private DateTime breakup;
      /// <summary>
      /// 中文标点符号
      /// </summary>
      private string[] chinesepunct = new string[] { "，", "。", "？", "！", "、", "；", "：",
                                                "“", "”", "‘", "’", "（", "）", "【",
                                                "】", "{", "}", "…", "．", "—", "-",
                                                "《", "》", "〈", "〉", "￥" };
      /// <summary>
      /// 英文标点符号
      /// </summary>
      private string[] englishpunct = new string[] { @",", @".", @"/", @"\", @"~", @"`", @"!",
                                                "\x40", @"#", @"$", @"%", @"^", @"&", @"*",
                                                @"(", @")", @"-", @"_", @"+", @"=", @"[",
                                                @"]", @";", @":", "\x22", "\x27", @"?" };
      /// <summary>
      /// 构造函数，创建一个指定章节编号的Chapter实例
      /// </summary>
      /// <param name="_chapterno">指定的章节编号。</param>
      public Chapter(SChapterNumber _chapterno)
      {
         bool b_cpn_no = _chapterno.ChapterNumber == null;
         if (b_cpn_no == true) throw new NullChapterNumberException("章节编号不能为null！");
         title = string.Empty;
         body = string.Empty;
         backup = new List<SChapterBodyBackup>();
      }
      /// <summary>
      /// 构造函数，创建一个指定章节编号和指定标题的Chapter实例
      /// </summary>
      /// <param name="_chapterno">指定的章节编号。</param>
      /// <param name="_title">指定的章节标题。</param>
      public Chapter(SChapterNumber _chapterno, string _title)
      {
         bool b_cpn_no = _chapterno.ChapterNumber == null;
         if (b_cpn_no == true) throw new NullChapterNumberException("章节编号不能为null！");
         title = _title;
         body = string.Empty;
         backup = new List<SChapterBodyBackup>();
      }
      /// <summary>
      /// 获取或设置当前实例的章节编号
      /// </summary>
      public SChapterNumber ChapterNumber
      {
         get { return chapterno; }
         set
         {
            bool b_cpn_no = value.ChapterNumber == null;
            if (b_cpn_no == true) throw new NullChapterNumberException("章节编号不能为null！");
            chapterno = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的章节标题
      /// </summary>
      public string Title
      {
         get { return title; }
         set { title = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的章节正文内容，如果当更新的内容长度为0或者更新内容与原内容长度差的绝对值大于等于100时，则会自动备份原内容
      /// </summary>
      public string Body
      {
         get { return body; }
         set
         {
            if (value == string.Empty || Math.Abs(body.Length - value.Length) >= 100)
            {
               Backup.Add(new SChapterBodyBackup(ChapterNumber, Body));
            }
            body = value;
         }
      }
      /// <summary>
      /// 获取或者设置当前章节的备份内容
      /// </summary>
      public List<SChapterBodyBackup> Backup
      {
         get { return backup; }
         set
         {
            backup = new List<SChapterBodyBackup>();
            backup = value;
         }
      }
      /// <summary>
      /// 获取当前层级正文的所有字符的数量
      /// </summary>
      public uint CharacterCount
      {
         get
         {
            if (Body == null) throw new ObjectDisposedException("找不到正文部分！");
            return (uint)Body.Length;
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
            string[] punct = englishpunct;
            Array.ConstrainedCopy(chinesepunct, 0, punct, punct.GetLength(0) - 1, chinesepunct.GetLength(0));
            Parallel.For(0, punct.GetLength(0), (index) =>
            {
               Parallel.For(0, CharacterCount, (s_index) =>
               {
                  if (Body.Substring((int)s_index, 1) == punct[index]) ++pcnt;
               });
            });
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
      /// 获取当前实例的单句总量
      /// </summary>
      public int SentencesCount
      {
         get
         {
            return GetSentences().Count;
         }
      }
      /// <summary>
      /// 清空当前实例的章节标题
      /// </summary>
      public void ClearTitle()
      {
         Title = string.Empty;
      }
      /// <summary>
      /// 清空当前实例的章节正文内容
      /// </summary>
      public void ClearBody()
      {
         Body = string.Empty;
      }
      /// <summary>
      /// 从正文内容备份中恢复
      /// </summary>
      public void RecoverFromBackup(DateTime _bkptime)
      {
         Parallel.For(0, Backup.Count, (index, interrupt) =>
         {
            if (_bkptime == Backup[index].BackupTime)
            {
               Body = Backup[index].BackupBody;
               interrupt.Stop();
            }
            if (interrupt.IsStopped == false) throw new NotFoundBackupException("找不到指定的备份！");
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
         string build_st = string.Empty;
         string eptline = "\n";
         if (_iselinttl)
         {
            if (_iselinend) build_st = ChapterNumber.ToString() + Title + eptline + Body + eptline;
            else build_st = ChapterNumber.ToString() + Title + eptline + Body;
         }
         else
         {
            if (_iselinend) build_st = ChapterNumber.ToString() + Title + Body + eptline;
            else build_st = ChapterNumber.ToString() + Title + Body;
         }
         return build_st;
      }
      /// <summary>
      /// 加密当前实例中的正文内容
      /// </summary>
      /// <returns>如果该算法执行成功，则会返回一个被加密的字符串，这个字符串对于普通用户而言是毫无意义的。</returns>
      public string Encryption()
      {
         StringBuilder ciphertext = new StringBuilder();
         byte[] data = Encoding.ASCII.GetBytes(Body);
         DESCryptoServiceProvider des = new DESCryptoServiceProvider();
         {
            des.Key = Encoding.ASCII.GetBytes(@"cabinink");
            des.IV = Encoding.ASCII.GetBytes(@"cabinink");
         }
         MemoryStream ms = new MemoryStream();
         CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
         {
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();
         }
         foreach (byte b in ms.ToArray()) ciphertext.AppendFormat("{0:X2}", b);
         return ciphertext.ToString();
      }
      /// <summary>
      /// 解密指定的密文
      /// </summary>
      /// <param name="_encstr">需要被解密的密文。</param>
      /// <returns>如果该算法执行成功，则会返回一个对应于密文的明文字符串，这个字符串对于任何用户而言都是能够理解的。</returns>
      public string Decryption(string _encstr)
      {
         DESCryptoServiceProvider des = new DESCryptoServiceProvider();
         List<byte> inputByteArray = new List<byte>(_encstr.Length / 2 - 1);
         int x = 0;
         while (x < _encstr.Length)
         {
            int i = Convert.ToInt32(_encstr.ToString().Substring(x, 2), 16);
            inputByteArray[x / 2] = Convert.ToByte(i);
            x += 2;
         }
         des.Key = Encoding.ASCII.GetBytes(@"cabinink");
         des.IV = Encoding.ASCII.GetBytes(@"cabinink");
         MemoryStream ms = new MemoryStream();
         CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
         cs.Write(inputByteArray.ToArray(), 0, inputByteArray.Count);
         cs.FlushFinalBlock();
         StringBuilder ret = new StringBuilder();
         return Encoding.GetEncoding("GB2312").GetString(ms.ToArray());
      }
      /// <summary>
      /// 获取当前实例所有的单句
      /// </summary>
      /// <returns>该操作会返回一个List实例列表，这个列表之中存放了其所有的单句，每一个单句都包含了后面的标点符号。</returns>
      public List<string> GetSentences()
      {
         List<string> sentences = new List<string>();
         Regex regex = new Regex(@"'(?!(s|t|re|m)( |$))|\.$|\. |\.{2,}|©|`|~|!|@|#|\$|%|\^|\*|\(|\)|(^|[^\w])-+|-+($|[^\w])|_|=|\+|\[|\]|\{|\}|<|>|\\|\||/|;|:|""|•|–|,|\?|×|！|·|…|—|（|）|、|：|；|‘|’|“|”|《|》|，|。|？");
         MatchCollection mc = regex.Matches(Body);
         Parallel.For(0, mc.Count, (index) => { sentences.Add(mc[index].Value); });
         return sentences;
      }
      /// <summary>
      /// 获取第一个单句
      /// </summary>
      /// <returns>该操作会返回当前实例的第一个单句。</returns>
      public string GetFirstSentence()
      {
         return GetSentences()[0];
      }
      /// <summary>
      /// 获取最后一个单句
      /// </summary>
      /// <returns>该操作会返回当前实例的最后一个单句。</returns>
      public string GetLastSentence()
      {
         return GetSentences()[SentencesCount - 1];
      }
      /// <summary>
      /// 获取当前Chapter实例的完整类名的字符串表达形式
      /// </summary>
      /// <returns>该操作会返回一个当前实例的完整类名的字符串表达形式。</returns>
      public override string ToString()
      {
         return ChapterNumber.ToString() + " " + Title;
      }
   }
   /// <summary>
   /// 章节标号方式枚举
   /// </summary>
   public enum EChapterNumberMode : int
   {
      /// <summary>
      /// 只有阿拉伯数字
      /// </summary>
      OnlyArabic = 0x0000,
      /// <summary>
      /// 阿拉伯数字显示在单词Chapter后面，举例：Chapter 64
      /// </summary>
      ArabicInEnglishChapterMark = 0x0001,
      /// <summary>
      /// 阿拉伯数字显示在中文“章”后面
      /// </summary>
      ArabicInChineseChapterMark = 0x0002,
      /// <summary>
      /// 阿拉伯数字显示在中文“节”后面
      /// </summary>
      ArabicInChineseSectionMark = 0x0003,
      /// <summary>
      /// 章节标记显示格式为第[ARABIC_NO]章，举例：第42章
      /// </summary>
      ArabicBeforeChineseChapterMarkFirstWordAndLastWord = 0x0004,
      /// <summary>
      /// 章节标记显示格式为第[ARABIC_NO]节，举例：第42节
      /// </summary>
      ArabicBeforeChineseSectionMarkFirstWordAndLastWord = 0x0005,
      /// <summary>
      /// 只有中文数字，举例：四十五
      /// </summary>
      OnlyChineseNum = 0x0006,
      /// <summary>
      /// 中文数字显示在中文“章”后面
      /// </summary>
      ChineseNumInChineseChapterMark = 0x0007,
      /// <summary>
      /// 中文数字显示在中文“节”后面
      /// </summary>
      ChineseNumInChineseSectionMark = 0x0008,
      /// <summary>
      /// 章节标记显示格式为第[CHINESE_NO]章，举例：第二十八章
      /// </summary>
      ChineseNumBeforeChineseChapterMarkFirstWordAndLastWord = 0x0009,
      /// <summary>
      /// 章节标记显示格式为第[CHINESE_NO]节，举例：第二十八节
      /// </summary>
      ChineseNumBeforeChineseSectionMarkFirstWordAndLastWord = 0x000a
   }
   /// <summary>
   /// 当类型出现不匹配的时候而引发的异常
   /// </summary>
   [Serializable]
   public class TypeIsErrorException : Exception
   {
      public TypeIsErrorException() { }
      public TypeIsErrorException(string message) : base(message) { }
      public TypeIsErrorException(string message, Exception inner) : base(message, inner) { }
      protected TypeIsErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 当出现空章节编号时引发的异常
   /// </summary>
   [Serializable]
   public class NullChapterNumberException : Exception
   {
      public NullChapterNumberException() { }
      public NullChapterNumberException(string message) : base(message) { }
      public NullChapterNumberException(string message, Exception inner) : base(message, inner) { }
      protected NullChapterNumberException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 找不到指定备份而引发的异常
   /// </summary>
   [Serializable]
   public class NotFoundBackupException : Exception
   {
      public NotFoundBackupException() { }
      public NotFoundBackupException(string message) : base(message) { }
      public NotFoundBackupException(string message, Exception inner) : base(message, inner) { }
      protected NotFoundBackupException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
