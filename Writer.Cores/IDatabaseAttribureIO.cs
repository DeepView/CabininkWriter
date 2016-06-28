namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 读取和存储项目附加属性的接口
   /// </summary>
   public interface INovelAttribureDatabaseIO
   {
      /// <summary>
      /// 将所有的信息保存到数据库
      /// </summary>
      /// <param name="_dburl">需要将信息保存到哪一个数据库。</param>
      /// <param name="_isdisconn">操作结束后是否断开数据库的连接。</param>
      void SaveToDatabase(string _dburl, bool _isdisconn);
      /// <summary>
      /// 从数据库文件读取信息并加载到实例中
      /// </summary>
      /// <param name="_dburl">存储读取指定信息的数据库文件地址。</param>
      void ReadFromDatabase(string _dburl);
   }
}
