using System;
using System.IO;
using System.Text;
using Cabinink.Writer.Cores;
namespace ChineseNumber_Demo
{
   class Program
   {
      static void Main(string[] args)
      {
         string saved = string.Empty;
         ChineseNumber.InitializeBuilder();
         try
         {
            for (short i = 1; i <= 1000; i++)
            {
               saved = saved + ChineseNumber.ConvertToChinese(i) + ",";
            }
         }
         catch (ArgumentException ex)
         {
            Console.WriteLine(ex.Message);
         }
         saved = saved.Substring(0, saved.Length - 1);
         if (FileOperation.FileExists(@"cnno.txt") == false)
         {
            FileOperation.CreateFile(@"cnno.txt", FileAccess.ReadWrite, FileShare.ReadWrite);
         }
         FileOperation.WriteFile(@"cnno.txt", saved, false, true, Encoding.GetEncoding("GB2312"));
         Console.WriteLine(FileOperation.ReadFile(@"cnno.txt", true, Encoding.GetEncoding("GB2312")));
         Console.ReadKey(true);
      }
   }
}
