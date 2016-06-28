using System;
using System.Text;
using System.Runtime.InteropServices;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 配置文件（后缀名为*.ini）操作类
   /// </summary>
   /// <example>
   /// 下面的代码将演示这个类该怎么使用：
   /// <code>
   /// private void Test()
   /// {
   ///      string file = "F:\\TestIni.ini";
   ///      WriteValue(file, "Desktop", "Color", "Red"); //写入/更新键值（下面三行代码也属于这个功能）
   ///      WriteValue(file, "Desktop", "Width", "3270");
   ///      WriteValue(file, "Toolbar", "Items", "Save,Delete,Open");
   ///      WriteValue(file, "Toolbar", "Dock", "True");
   ///      WriteItems(file, "Menu", "File=文件\0View=视图\0Edit=编辑");   //写入一批键值
   ///      string[] sections = GetAllSectionNames(file);   //获取文件中所有的节点
   ///      string[] items = GetAllItems(file, "Menu");  //获取指定节点中的所有项
   ///      string[] keys = GetAllItemKeys(file, "Menu");   //获取指定节点中所有的键
   ///      string value = GetStringValue(file, "Desktop", "color", null); //获取指定KEY的值
   ///      DeleteKey(file, "desktop", "color");   //删除指定的KEY
   ///      DeleteSection(file, "desktop");  //删除指定的节点
   ///      EmptySection(file, "toolbar");   //清空指定的节点
   /// }
   /// </code>
   /// </example>
   public class InitializationFileOperation
   {
      /// <summary>
      /// 获取所有节点名称(Section)
      /// </summary>
      /// <param name="_retbuffer">存放节点名称的内存地址,每个节点之间用\0分隔。</param>
      /// <param name="_size">内存大小(characters)。</param>
      /// <param name="_furl">指定的Ini文件。</param>
      /// <returns>内容的实际长度,为0表示没有内容,为nSize-2表示内存大小不够。</returns>
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private static extern uint GetPrivateProfileSectionNames(IntPtr _retbuffer, uint _size, string _furl);
      /// <summary>
      /// 获取某个指定节点(Section)中所有KEY和Value
      /// </summary>
      /// <param name="_section">节点名称。</param>
      /// <param name="_retmemaddr">返回值的内存地址,每个之间用\0分隔。</param>
      /// <param name="_size">内存大小(characters)。</param>
      /// <param name="_furl">Ini文件。</param>
      /// <returns>内容的实际长度,为0表示没有内容,为nSize-2表示内存大小不够。</returns>
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private static extern uint GetPrivateProfileSection(string _section, IntPtr _retmemaddr, uint _size, string _furl);
      /// <summary>
      /// 读取INI文件中指定的Key的值
      /// </summary>
      /// <param name="_section">节点名称。如果为null,则读取INI中所有节点名称,每个节点名称之间用\0分隔。</param>
      /// <param name="_key">Key名称。如果为null,则读取INI中指定节点中的所有KEY,每个KEY之间用\0分隔。</param>
      /// <param name="_defval">读取失败时的默认值。</param>
      /// <param name="_buffer">读取的内容缓冲区，读取之后，多余的地方使用\0填充。</param>
      /// <param name="_size">内容缓冲区的长度。</param>
      /// <param name="_furl">INI文件名。</param>
      /// <returns>实际读取到的长度。</returns>
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private static extern uint GetPrivateProfileString(string _section, string _key, string _defval, [In, Out] char[] _buffer, uint _size, string _furl);
      /// <summary>
      /// 读取INI文件中指定的Key的值
      /// </summary>
      /// <param name="_section">节点名称。如果为null,则读取INI中所有节点名称,每个节点名称之间用\0分隔。</param>
      /// <param name="_key">Key名称。如果为null,则读取INI中指定节点中的所有KEY,每个KEY之间用\0分隔。</param>
      /// <param name="_defval">读取失败时的默认值。</param>
      /// <param name="_buffer">读取的内容缓冲区。</param>
      /// <param name="_size">内容缓冲区的长度。</param>
      /// <param name="_furl">INI文件名。</param>
      /// <returns>实际读取到的长度。</returns>
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private static extern uint GetPrivateProfileString(string _section, string _key, string _defval, StringBuilder _buffer, uint _size, string _furl);
      /// <summary>
      /// 读取INI文件中指定的Key的值
      /// </summary>
      /// <param name="_section">节点名称。如果为null,则读取INI中所有节点名称,每个节点名称之间用\0分隔。</param>
      /// <param name="_key">Key名称。如果为null,则读取INI中指定节点中的所有KEY,每个KEY之间用\0分隔。</param>
      /// <param name="_defval">读取失败时的默认值。</param>
      /// <param name="_buffer">读取的内容缓冲区。</param>
      /// <param name="_size">内容缓冲区的长度。</param>
      /// <param name="_furl">INI文件名。</param>
      /// <returns>实际读取到的长度。</returns>
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private static extern uint GetPrivateProfileString(string _section, string _key, string _defval, string _buffer, uint _size, string _furl);
      /// <summary>
      /// 将指定的键值对写到指定的节点，如果已经存在则替换
      /// </summary>
      /// <param name="_section">节点，如果不存在此节点，则创建此节点。</param>
      /// <param name="_dic">Item键值对，多个用\0分隔,形如key1=value1\0key2=value2。
      /// <para>如果为string.Empty，则删除指定节点下的所有内容，保留节点。</para>
      /// <para>如果为null，则删除指定节点下的所有内容，并且删除该节点。</para>
      /// </param>
      /// <param name="_furl">INI文件。</param>
      /// <returns>是否成功写入。</returns>
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      [return: MarshalAs(UnmanagedType.Bool)]     //可以没有此行
      private static extern bool WritePrivateProfileSection(string _section, string _dic, string _furl);
      /// <summary>
      /// 将指定的键和值写到指定的节点，如果已经存在则替换
      /// </summary>
      /// <param name="lpAppName">节点名称</param>
      /// <param name="lpKeyName">键名称。如果为null，则删除指定的节点及其所有的项目</param>
      /// <param name="lpString">值内容。如果为null，则删除指定节点中指定的键。</param>
      /// <param name="lpFileName">INI文件</param>
      /// <returns>操作是否成功</returns>
      [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
      /// <summary>
      /// 读取INI文件中指定INI文件中的所有节点名称(Section)
      /// </summary>
      /// <param name="_furl">Ini文件。</param>
      /// <returns>所有节点,没有内容返回string[0]。</returns>
      public static string[] GetAllSectionNames(string _furl)
      {
         uint MAX_BUFFER = 32767;
         string[] sections = new string[0];
         IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
         uint bytesReturned = GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, _furl);
         if (bytesReturned != 0)
         {
            string local = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned).ToString();
            sections = local.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
         }
         Marshal.FreeCoTaskMem(pReturnedString);
         return sections;
      }
      /// <summary>
      /// 获取INI文件中指定节点(Section)中的所有条目(key=value形式)
      /// </summary>
      /// <param name="_furl">Ini文件。</param>
      /// <param name="_section">节点名称。</param>
      /// <returns>指定节点中的所有项目,没有内容返回string[0]。</returns>
      public static string[] GetAllItems(string _furl, string _section)
      {
         uint MAX_BUFFER = 32767;
         string[] items = new string[0];
         IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
         uint bytesReturned = GetPrivateProfileSection(_section, pReturnedString, MAX_BUFFER, _furl);
         if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
         {
            string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);
            items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
         }
         Marshal.FreeCoTaskMem(pReturnedString);
         return items;
      }
      /// <summary>
      /// 获取INI文件中指定节点(Section)中的所有条目的Key列表
      /// </summary>
      /// <param name="_furl">Ini文件。</param>
      /// <param name="_section">节点名称。</param>
      /// <returns>如果没有内容,反回string[0]。</returns>
      public static string[] GetAllItemKeys(string _furl, string _section)
      {
         string[] value = new string[0];
         const int SIZE = 1024 * 10;
         if (string.IsNullOrEmpty(_section)) throw new ArgumentException("必须指定节点名称", "_section");
         char[] chars = new char[SIZE];
         uint bytesReturned = GetPrivateProfileString(_section, null, null, chars, SIZE, _furl);
         if (bytesReturned != 0)
         {
            value = new string(chars).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
         }
         chars = null;
         return value;
      }
      /// <summary>
      /// 读取INI文件中指定KEY的字符串型值
      /// </summary>
      /// <param name="_furl">Ini文件。</param>
      /// <param name="_section">节点名称。</param>
      /// <param name="_key">键名称。</param>
      /// <param name="defaultValue">如果没此KEY所使用的默认值。</param>
      /// <returns>读取到的值。</returns>
      public static string GetStringValue(string _furl, string _section, string _key, string _defval)
      {
         string value = _defval;
         const int SIZE = 1024 * 10;
         if (string.IsNullOrEmpty(_section)) throw new ArgumentException("必须指定节点名称", "_section");
         if (string.IsNullOrEmpty(_key)) throw new ArgumentException("必须指定键名称(key)", "_key");
         StringBuilder sb = new StringBuilder(SIZE);
         uint bytesReturned = GetPrivateProfileString(_section, _key, _defval, sb, SIZE, _furl);
         if (bytesReturned != 0) value = sb.ToString();
         sb = null;
         return value;
      }
      /// <summary>
      /// 在INI文件中，将指定的键值对写到指定的节点，如果已经存在则替换
      /// </summary>
      /// <param name="_furl">INI文件。</param>
      /// <param name="_section">节点，如果不存在此节点，则创建此节点。</param>
      /// <param name="_items">键值对，多个用\0分隔,形如key1=value1\0key2=value2。</param>
      /// <returns>指示是否已经写入。</returns>
      public static bool WriteItems(string _furl, string _section, string _items)
      {
         if (string.IsNullOrEmpty(_section)) throw new ArgumentException("必须指定节点名称", "_section");
         if (string.IsNullOrEmpty(_items)) throw new ArgumentException("必须指定键值对", "_items");
         return WritePrivateProfileSection(_section, _items, _furl);
      }
      /// <summary>
      /// 在INI文件中，指定节点写入指定的键及值。如果已经存在，则替换。如果没有则创建
      /// </summary>
      /// <param name="_furl">INI文件。</param>
      /// <param name="_section">指定的节点。</param>
      /// <param name="_key">指定的键。</param>
      /// <param name="_value">写入的值。</param>
      /// <returns>操作是否成功。</returns>
      public static bool WriteValue(string _furl, string _section, string _key, string _value)
      {
         if (string.IsNullOrEmpty(_section)) throw new ArgumentException("必须指定节点名称", "_section");
         if (string.IsNullOrEmpty(_key)) throw new ArgumentException("必须指定键名称", "_key");
         if (_value == null) throw new ArgumentException("值不能为null", "_value");
         return WritePrivateProfileString(_section, _key, _value, _furl);
      }
      /// <summary>
      /// 在INI文件中，删除指定节点中的指定的键
      /// </summary>
      /// <param name="_furl">INI文件。</param>
      /// <param name="_section">节点。</param>
      /// <param name="_key">指定的键。</param>
      /// <returns>操作是否成功。</returns>
      public static bool DeleteKey(string _furl, string _section, string _key)
      {
         if (string.IsNullOrEmpty(_section)) throw new ArgumentException("必须指定节点名称", "_section");
         if (string.IsNullOrEmpty(_key)) throw new ArgumentException("必须指定键名称", "_key");
         return WritePrivateProfileString(_section, _key, null, _furl);
      }
      /// <summary>
      /// 在INI文件中，删除指定的节点
      /// </summary>
      /// <param name="_furl">INI文件。</param>
      /// <param name="_section">节点。</param>
      /// <returns>操作是否成功。</returns>
      public static bool DeleteSection(string _furl, string _section)
      {
         if (string.IsNullOrEmpty(_section)) throw new ArgumentException("必须指定节点名称", "_section");
         return WritePrivateProfileString(_section, null, null, _furl);
      }
      /// <summary>
      /// 在INI文件中，删除指定节点中的所有内容
      /// </summary>
      /// <param name="_furl">INI文件。</param>
      /// <param name="_section">节点。</param>
      /// <returns>操作是否成功。</returns>
      public static bool EmptySection(string _furl, string _section)
      {
         if (string.IsNullOrEmpty(_section)) throw new ArgumentException("必须指定节点名称", "_section");
         return WritePrivateProfileSection(_section, string.Empty, _furl);
      }
   }
}
