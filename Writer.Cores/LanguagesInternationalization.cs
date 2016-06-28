using System;
using System.Linq;
using System.Collections.Generic;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 语言国际化类
   /// </summary>
   public class LanguagesInternationalization
   {
      /// <summary>
      /// 该实例的语言类别
      /// </summary>
      private ELanguagesCategory language;
      /// <summary>
      /// 该实例语言类别所对应的字符串文本集合
      /// </summary>
      private List<string> text;
      /// <summary>
      /// 构造函数，创建一个默认语言为简体中文，文本集合为空的实例
      /// </summary>
      public LanguagesInternationalization()
      {
         language = ELanguagesCategory.SimplifiedChinese;
         text = new List<string>();
      }
      /// <summary>
      /// 构造函数，创建一个指定语言类别，文本集合为空的实例
      /// </summary>
      /// <param name="_language">指定的语言类别。</param>
      public LanguagesInternationalization(ELanguagesCategory _language)
      {
         language = _language;
         text = new List<string>();
      }
      /// <summary>
      /// 构造函数，创建一个指定语言类别和文本集合的实例
      /// </summary>
      /// <param name="_language">指定的语言类别。</param>
      /// <param name="_text">指定的文本集合。</param>
      public LanguagesInternationalization(ELanguagesCategory _language, List<string> _text)
      {
         language = _language;
         text = _text;
      }
      /// <summary>
      /// 构造函数，创建一个指定语言类别和数组类型文本集合的实例
      /// </summary>
      /// <param name="_language">指定的语言类别。</param>
      /// <param name="_text">指定的数组类型文本集合。</param>
      public LanguagesInternationalization(ELanguagesCategory _language, string[] _text)
      {
         language = _language;
         text = _text.ToList();
      }
      /// <summary>
      /// 获取当前实例的文本集合的实际元素数量
      /// </summary>
      public int Count
      {
         get { return text.Count; }
      }
      /// <summary>
      /// 获取或设置当前实例的语言类别
      /// </summary>
      public ELanguagesCategory LanguagesCategory
      {
         get { return language; }
         set { language = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的文本集合
      /// </summary>
      public List<string> Text
      {
         get { return text; }
         set { text = value; }
      }
      /// <summary>
      /// 通过索引来获取或设置当前实例的指定文本
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      /// <returns>如果无异常产生，则会返回指定索引所对应的文本。</returns>
      public string this[int _index]
      {
         get
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
            return text[_index];
         }
         set
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("索引超出范围！");
            text[_index] = value;
         }
      }
      /// <summary>
      /// 添加文本到文本集合
      /// </summary>
      /// <param name="_ntext">需要被添加的新文本。</param>
      /// <returns>如果操作成功，则会返回该操作结束后文本集合的实际元素数量。</returns>
      public int AddText(string _ntext)
      {
         Text.Add(_ntext);
         return Count;
      }
      /// <summary>
      /// 从文本集合移除指定索引所对应的文本
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      /// <returns>如果操作成功，则会返回该操作结束后文本集合的实际元素数量。</returns>
      public int RemoveText(int _index)
      {
         Text.RemoveAt(_index);
         return Count;
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.LanguagesInternationalization";
      }
   }
   /// <summary>
   /// 用于区分语言的语言枚举
   /// </summary>
   public enum ELanguagesCategory : int
   {
      /// <summary>
      /// 简体中文
      /// </summary>
      SimplifiedChinese = 0x0001,
      /// <summary>
      /// 繁体中文
      /// </summary>
      TraditionalChinese = 0x0002,
      /// <summary>
      /// 美式英语
      /// </summary>
      EnglishOfAmerica = 0x0003,
      /// <summary>
      /// 英式英语
      /// </summary>
      EnglishOfBritain = 0x0004,
      /// <summary>
      /// 澳式英语
      /// </summary>
      EnglishOfAustralia = 0x0005,
      /// <summary>
      /// 日语
      /// </summary>
      Japanese = 0x0006,
      /// <summary>
      /// 法语
      /// </summary>
      French = 0x0007,
      /// <summary>
      /// 西班牙语
      /// </summary>
      Spanish = 0x0008
   }
}
