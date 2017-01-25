using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 汉字拼音单向转换类
   /// </summary>
   public class PhoneticTranscription : IDisposable
   {
      /// <summary>
      /// 中文拼音代码集合
      /// </summary>
      private List<int> ptvalue;
      /// <summary>
      /// 中文拼音集合
      /// </summary>
      private List<string> ptname;
      /// <summary>
      /// 二级汉字集合
      /// </summary>
      private List<string> r2cnchar;
      /// <summary>
      /// 二级汉字对应的拼音集合
      /// </summary>
      private List<string> r2cnpt;
      /// <summary>
      /// 配置中文字符的正则表达式
      /// </summary>
      private Regex cnregex;
      /// <summary>
      /// 检测冗余调用
      /// </summary>
      private bool disposedval = false;
      /// <summary>
      /// GB2312-80 标准规范中第一个汉字的机内码，即“啊”的机内码
      /// </summary>
      private const int FIRST_GB231280_CN_CODE = -20319;
      /// <summary>
      /// GB2312-80 标准规范中最后一个汉字的机内码，即“齄”的机内码
      /// </summary>
      private const int LAST_GB231280_CN_CODE = -2050;
      /// <summary>
      /// GB2312-80 标准规范中最后一个一级汉字的机内码，即“座”的机内码
      /// </summary>
      private const int LAST_GB231280_L1CN_CODE = -10247;
      /// <summary>
      /// 构造函数，初始化当前汉字拼音单向转换器实例
      /// </summary>
      public PhoneticTranscription()
      {
         List<string> ptvalst = GetElementFromCsvFile(@"pt_resources\ptvalue");
         ptvalue = new List<int>();
         Parallel.For(0, ptvalst.Count, (index) => { ptvalue.Add(Convert.ToInt32(ptvalst[index], 10)); });
         ptname = GetElementFromCsvFile(@"pt_resources\ptname");
         r2cnchar = GetElementFromCsvFile(@"pt_resources\r2cnchar");
         r2cnpt = GetElementFromCsvFile(@"pt_resources\r2cnpt");
         cnregex = new Regex("[\u4e00-\u9fa5]$");
      }
      /// <summary>
      /// 获取中文拼音的第一个字段
      /// </summary>
      /// <param name="_pt">被用于获取字段的拼音。</param>
      /// <returns>该操作将会返回一个string格式的拼音字段。</returns>
      public string GetFirstField(char _pt)
      {
         string rs = GetPtWithSingleWord(_pt);
         if (!string.IsNullOrEmpty(rs)) rs = rs.Substring(0, 1);
         return rs;
      }
      /// <summary>
      /// 获取中文拼音的第一个字段
      /// </summary>
      /// <param name="_pt">被用于获取字段的字符串形式的拼音。</param>
      /// <returns>该操作将会返回一个string格式的拼音字段。</returns>
      public string GetFirstField(string _pt)
      {
         if (string.IsNullOrEmpty(_pt)) return string.Empty;
         StringBuilder sb = new StringBuilder(_pt.Length + 1);
         char[] chs = _pt.ToCharArray();
         for (var i = 0; i < chs.Length; i++) sb.Append(GetFirstField(chs[i]));
         return sb.ToString();
      }
      /// <summary>
      /// 获取单字拼音
      /// </summary>
      /// <param name="_scn">需要被获取拼音的单字。</param>
      /// <returns>该操作将会返回一个string格式的拼音。</returns>
      public string GetPtWithSingleWord(char _scn)
      {
         if (_scn <= '\x00FF') return _scn.ToString();
         if (char.IsPunctuation(_scn) || char.IsSeparator(_scn)) return _scn.ToString();
         if (_scn < '\x4E00' || _scn > '\x9FA5') return _scn.ToString();
         byte[] arr = Encoding.GetEncoding("GB2312").GetBytes(_scn.ToString());
         int chr = arr[0] * 256 + arr[1] - 65536;
         if (chr > 0 && chr < 160) return _scn.ToString();
         if (chr > LAST_GB231280_CN_CODE || chr < FIRST_GB231280_CN_CODE) return _scn.ToString();
         else if (chr <= LAST_GB231280_L1CN_CODE)
         {
            for (int i_apos = 11; i_apos >= 0; i_apos--)
            {
               int aboutPos = i_apos * 33;
               if (chr >= ptvalue[aboutPos])
               {
                  for (int i = aboutPos + 32; i >= aboutPos; i--) if (ptvalue[i] <= chr) return ptname[i];
                  break;
               }
            }
         }
         else
         {
            int pos = Array.IndexOf(r2cnchar.ToArray(), _scn.ToString());
            if (pos != decimal.MinusOne) return r2cnpt[pos];
         }
         return string.Empty;
      }
      /// <summary>
      /// 把汉字转换成拼音(全拼)
      /// </summary>
      /// <param name="_cn">需要被转换成拼音的汉字字符串。</param>
      /// <returns>该操作将会返回一个转换后的拼音(全拼)字符串。</returns>
      public string ConvertToPt(string _cn)
      {
         if (string.IsNullOrEmpty(_cn)) return string.Empty;
         StringBuilder sb = new StringBuilder(_cn.Length * 10);
         char[] chs = _cn.ToCharArray();
         for (int j = 0; j < chs.Length; j++) sb.Append(GetPtWithSingleWord(chs[j]));
         return sb.ToString();
      }
      /// <summary>
      /// 根据拼音首字母获取对应的中文字符集
      /// </summary>
      /// <param name="_letter">指定的拼音首字母，在这里可以理解为一个英文字母，忽略大小写。</param>
      /// <returns>如果这个操作无异常发生，则将会返回一个符合筛选条件的中文字符集。</returns>
      public List<string> GetChineseByLetter(string _letter)
      {
         List<string> cncoll = new List<string>();
         string ltbysscn = FileOperation.ReadFile(@"pt_resources\cnptfword", true, Encoding.GetEncoding("GB2312"));
         string cnbyslt = FileOperation.ReadFile(@"pt_resources\r2cnnocsv", true, Encoding.GetEncoding("GB2312"));
         Parallel.For(0, ltbysscn.Length, (index) =>
         {
            if (_letter.ToUpper() == ltbysscn.Substring(index, 1)) cncoll.Add(cnbyslt.Substring(index, 1));
         });
         return cncoll;
      }
      /// <summary>
      /// 读取CSV文件
      /// </summary>
      /// <param name="_furl">需要被读取的CSV文件的本地路径。</param>
      /// <returns>该操作将会返回一个包含了CSV文件内容元素的列表。</returns>
      private List<string> GetElementFromCsvFile(string _furl)
      {
         return FileOperation.ReadFile(_furl, true, Encoding.GetEncoding("GB2312")).Split(',').ToList();
      }
      /// <summary>
      /// 释放当前实例使用的未托管资源，同时还可以根据需要释放托管资源
      /// </summary>
      /// <param name="_disposing">决定该方法如何释放资源，若为true则释放托管资源和非托管资源，否则仅释放非托管资源。</param>
      protected virtual void Dispose(bool _disposing)
      {
         if (!disposedval)
         {
            if (_disposing)
            {
               ptvalue = null;
               ptname = null;
               r2cnchar = null;
               r2cnpt = null;
               cnregex = null;
               GC.Collect();
               disposedval = true;
            }
         }
      }
      /// <summary>
      /// 释放由当前对象占用的所有资源
      /// </summary>
      public void Dispose()
      {
         Dispose(true);
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.PhoneticTranscription";
      }
   }
}
