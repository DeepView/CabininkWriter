using System;
using System.IO;
using System.Text;
using System.Linq;
using Cabinink.FileSystem;
using lihejushi.arabChange;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace ciw_cnancvt
{
   class Program
   {
      static void Main(string[] args)
      {
         arabChange cvt = new arabChange();
         Console.WriteLine("C2A & A2C Convertor\n");
         Console.WriteLine("1.Chinese number convert to arab number.");
         Console.WriteLine("2.Arab number convert to Chinese number.");
         Console.WriteLine("3.To specify a range of numbers for Chinese number and saved.\n");
         Console.Write("Select a function(available selection[1,2,3]): ");
         switch (Console.ReadLine())
         {
            case "1":
               Console.WriteLine("\nReading resources...");
               StreamReader srr = new StreamReader("cnno.txt", Encoding.GetEncoding("GB2312"));
               List<string> cns = new List<string>();
               cns = srr.ReadToEnd().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
               Console.WriteLine("Operation completed!");
               Console.Write("\nPlease enter a Chinese number(available scope:[1," + cns.Count + "]): ");
               string cnno = Console.ReadLine();
               string commensurate = "#Non-effective number or scope is overflow!";
               ParallelLoopResult loopres;
               loopres = Parallel.For(0, cns.Count, (index, interrupt) =>
               {
                  if (cnno == cns[index])
                  {
                     commensurate = Convert.ToString(index + 1, 10);
                     interrupt.Break();
                  }
               });
               Console.WriteLine("\nDeveloper's information: ");
               Console.WriteLine("[1].IsCompleted(Parallel.For Method): " + loopres.IsCompleted);
               Console.WriteLine("[2].LowestBreakIteration(Parallel.For Method): " + loopres.LowestBreakIteration);
               Console.WriteLine("\nArab number: " + commensurate);
               break;
            case "2":
               Console.Write("\nEnter a arab number[type:integer]: ");
               string arab = Console.ReadLine();
               Console.WriteLine("Chinese number: " + cvt.ChangeOver(arab, 1));
               break;
            case "3":
               Uri saveto = new Uri(Environment.CurrentDirectory + @"\cnno.txt");
               string lban = string.Empty, uban = string.Empty, saved = string.Empty;
               Console.Write("Please enter a arab number of lower bound(min_value{1}): ");
               lban = Console.ReadLine();
               Console.Write("Please enter a arab number of upper bound(min_value{lower+1}): ");
               uban = Console.ReadLine();
               Console.WriteLine("\nConverting...");
               for (int i = Convert.ToInt32(lban, 10); i <= Convert.ToInt32(uban, 10); i++)
               {
                  saved = saved + cvt.ChangeOver(Convert.ToString(i, 10), 1) + ",";
               }
               Console.WriteLine("\n(1).Convertion completed!");
               if (FileOperation.FileExists(saveto) == false)
               {
                  FileStream fs = new FileStream(saveto.LocalPath, FileMode.CreateNew);
                  fs.Close();
               }
               File.WriteAllText(saveto.LocalPath, saved, Encoding.GetEncoding("GB2312"));
               Console.WriteLine("(2).Result is saved!");
               Console.WriteLine("\nWork completed,Saved path:\n" + saveto.LocalPath);
               break;
            default:
               Console.WriteLine("\nNon-effective selection,current program will be exiting!");
               break;
         }
         Console.Write("\nPress any key to exit...");
         Console.ReadKey(true);
      }
   }
}
