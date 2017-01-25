namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 作品的内容安全接口
   /// </summary>
   public interface INovelContextSecurity
   {
      /// <summary>
      /// 加密当前实例中的正文内容
      /// </summary>
      /// <returns>如果该算法执行成功，则会返回一个被加密的字符串，这个字符串对于普通用户而言是毫无意义的。</returns>
      string Encryption();
      /// <summary>
      /// 解密指定的密文
      /// </summary>
      /// <param name="_encstr">需要被解密的密文。</param>
      /// <returns>如果该算法执行成功，则会返回一个对应于密文的明文字符串，这个字符串对于任何用户而言都是能够理解的。</returns>
      string Decryption(string _encstr);
   }
}
