namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 实现整个作品安全性的接口
   /// </summary>
   public interface INovelManagementSecurity
   {
      /// <summary>
      /// 获取或设置当前作品的管理密码
      /// </summary>
      string Password { get; set; }
      /// <summary>
      /// 加密指定的管理密码
      /// </summary>
      /// <param name="_decstr">需要被加密的管理密码。</param>
      /// <returns>如果该操作执行成功，则会返回一个被加密的密文。</returns>
      string EncryptPassword(string _decstr);
      /// <summary>
      /// 更新当前作品的管理密码
      /// </summary>
      /// <param name="_oldpasswd">以前的旧密码。</param>
      /// <param name="_newpasswd">输入的新密码。</param>
      /// <returns>如果该操作执行成功，做饭会true，否则返回false。</returns>
      bool UpdatePassword(string _oldpasswd, string _newpasswd);
   }
}
