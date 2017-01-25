using System.Collections.Generic;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 章节的单句简单操作接口
   /// </summary>
   public interface ISentences
   {
      /// <summary>
      /// 获取当前实例的单句总量
      /// </summary>
      int SentencesCount { get; }
      /// <summary>
      /// 获取当前实例所有的单句
      /// </summary>
      /// <returns>该操作会返回一个List实例列表，这个列表之中存放了其所有的单句，每一个单句都包含了后面的标点符号。</returns>
      List<string> GetSentences();
      /// <summary>
      /// 获取第一个单句
      /// </summary>
      /// <returns>该操作会返回当前实例的第一个单句。</returns>
      string GetFirstSentence();
      /// <summary>
      /// 获取最后一个单句
      /// </summary>
      /// <returns>该操作会返回当前实例的最后一个单句。</returns>
      string GetLastSentence();
   }
}
