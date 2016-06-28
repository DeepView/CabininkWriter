using System;
using System.IO;
using Cabinink.Writer.Cores;
using System.Runtime.InteropServices;
namespace Cabinink.Writer.Middle
{
   /// <summary>
   /// 字体文件安装类
   /// </summary>
   public sealed class WindowsFontInstaller
   {
      /// <summary>
      /// 在Win.ini初始化文件指定小节内设置一个字串
      /// </summary>
      /// <param name="_section">指定要在其中写入新串的小节。如尚不存在，会创建这个小节。这个字串不区分大小写。</param>
      /// <param name="_key">要设置的项名或条目名。这个字串不区分大小写。用vbNullString可删除这个小节的所有设置项。</param>
      /// <param name="_value">指定为这个项写入的字串值。</param>
      /// <returns>Long，非零表示成功，零表示失败。会设置GetLastError。</returns>
      [DllImport("kernel32.dll", SetLastError = true)]
      private static extern int WriteProfileString(string _section, string _key, string _value);
      /// <summary>
      /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。
      /// </summary>
      /// <param name="_hwnd">其窗口程序将接收消息的窗口的句柄。</param>
      /// <param name="_msg">指定被发送的消息。</param>
      /// <param name="_wp">指定附加的消息特定信息。</param>
      /// <param name="_lp">指定附加的消息特定信息。</param>
      /// <returns>返回值指定消息处理的结果，依赖于所发送的消息。</returns>
      [DllImport("user32.dll")]
      private static extern int SendMessage(int _hwnd, uint _msg, int _wp, int _lp);
      /// <summary>
      /// 向Windows添加字体资源
      /// </summary>
      /// <param name="_furl">需要被添加的字体资源文件地址。</param>
      /// <returns>Long，非零表示成功，零表示失败。会设置GetLastError。</returns>
      [DllImport("gdi32")]
      private static extern int AddFontResource(string _furl);
      /// <summary>
      /// 安装Windows字体
      /// </summary>
      /// <param name="_furl">需要被安装的字体文件路径。</param>
      /// <param name="_fontname">被安装字体的字体名称。</param>
      /// <returns>如果字体安装成功，则将会返回true，否则将会返回false。</returns>
      public static bool InstallFont(string _furl, string _fontname)
      {
         string WinFontDir = Environment.GetEnvironmentVariable("windir") + "\\fonts/";
         int ret = 0;
         int res = 0;
         string fontpath;
         const int WM_FONTCHANGE = 0x001d;
         const int HWND_BROADCAST = 0xffff;
         string fname_withoutex = FileOperation.GetFileNameWithoutExtension(_furl);
         fontpath = WinFontDir + "\\" + fname_withoutex + FileOperation.GetFileExtension(_furl);
         if (!FileOperation.FileExists(fontpath))
         {
            File.Copy(_furl, fontpath);
            ret = AddFontResource(fontpath);
            res = SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0);
            ret = WriteProfileString("fonts", _fontname + "(TrueType)", _furl);
         }
         return ret == 0 ? true : false;
      }
   }
}
