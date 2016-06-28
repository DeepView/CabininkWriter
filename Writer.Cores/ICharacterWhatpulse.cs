namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 字符统计接口，定义了一些相关的字符统计方法和属性
   /// </summary>
   public interface ICharacterWhatpulse
   {
      /// <summary>
      /// 获取当前层级正文的所有字符的数量
      /// </summary>
      uint CharacterCount { get; }
      /// <summary>
      /// 获取当前层级正文的所有标点符号的数量
      /// </summary>
      uint PunctuationCount { get; }
      /// <summary>
      /// 获取当前层级正文的所有单词或者汉字的数量
      /// </summary>
      uint WordCount { get; }
   }
}
