using System;
using System.Linq;
using System.Text;
using lihejushi.arabChange;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 阿拉伯数字与中文数字单向转换类
   /// </summary>
   public class ChineseNumber
   {
      /// <summary>
      /// 转换器实例
      /// </summary>
      private static arabChange convertor;
      /// <summary>
      /// 中文数字集合
      /// </summary>
      private static List<string> cnnums;
      /// <summary>
      /// 初始化转换器实例
      /// </summary>
      public static void InitializeBuilder()
      {
         string cnnocvs = FileOperation.ReadFile(@"app_resources\cnno", true, Encoding.GetEncoding("GB2312"));
         cnnums = cnnocvs.Split(',').ToList();
         convertor = new arabChange();
      }
      /// <summary>
      /// 将阿拉伯整数转换为中文汉字，举例：8192转换之后为八千一百九十二
      /// </summary>
      /// <param name="_arabno">需要被转换的阿拉伯整数。</param>
      /// <returns>如果该操作无异常，则会返回一个由中文表达的数字字符串。</returns>
      public static string ConvertToChinese(int _arabno)
      {
         string arabnost = Convert.ToString(_arabno, 10);
         return convertor.ChangeOver(arabnost, 1);
      }
      /// <summary>
      /// 将中文数字转换为阿拉伯数字，不过这个操作是基于文件的
      /// </summary>
      /// <param name="_cnno">需要被转换的中文数字。</param>
      /// <returns>如果该操作无异常，则会返回一个由阿拉伯数字表达的数字字符串。</returns>
      public static string ConvertToArab(string _cnno)
      {
         int no_index = 0;
         Parallel.For(0, cnnums.Count, (index, interrupt) =>
         {
            if (_cnno == cnnums[index])
            {
               no_index = index + 1;
               interrupt.Stop();
            }
         });
         return Convert.ToString(no_index, 10);
      }
   }
}
