namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 用于实现可以组建并生成直观文档的接口
   /// </summary>
   public interface IBuilder
   {
      /// <summary>
      /// 在当前的作品层级组建并生成用户能够直接使用的文本
      /// </summary>
      /// <param name="_iselinttl">是否在标题结尾追加空行。</param>
      /// <param name="_iselinend">是否在正文结尾追加空行。</param>
      /// <returns>该操作会返回一个可以供普通用户使用并阅读的文本，这些文本则是可以发表的作品内容的一部分或者全部内容。</returns>
      string Build(bool _iselinttl, bool _iselinend);
   }
}
