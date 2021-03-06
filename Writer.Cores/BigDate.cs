﻿using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 大型日期类，可以表示跨度很长的日期
   /// </summary>
   [DebuggerDisplay("Date = {ToString(EDateDisplayCategory.DashedSegmentation)}")]
   public class BigDate
   {
      /// <summary>
      /// 当前日期的年份，范围是公元前6000至公元2147483647年
      /// </summary>
      protected int year;
      /// <summary>
      /// 当前日期的月份，范围是1至12
      /// </summary>
      protected byte month;
      /// <summary>
      /// 当前月份的天，范围是1至month的天数
      /// </summary>
      protected byte day;
      /// <summary>
      /// 构造函数，初始化一个包含了当前日期的BigDate实例
      /// </summary>
      public BigDate()
      {
         year = DateTime.Now.Year;
         month = (byte)DateTime.Now.Month;
         day = (byte)DateTime.Now.Day;
      }
      /// <summary>
      /// 构造函数，通过一个指定的DateTime结构体实例来初始化当前BigDate实例
      /// </summary>
      /// <param name="_date">指定的DateTime结构体实例。</param>
      public BigDate(DateTime _date)
      {
         year = _date.Year;
         month = (byte)_date.Month;
         day = (byte)_date.Day;
      }
      /// <summary>
      /// 构造函数，通过指定的年月日来初始化当前的BigDate实例
      /// </summary>
      /// <param name="_year">指定的年份，范围是公元前6000至公元2147483647年。</param>
      /// <param name="_month">指定的月份，范围是1至12。</param>
      /// <param name="_day">指定的天数，范围是1至month的天数。</param>
      public BigDate(int _year, byte _month, byte _day)
      {
         if (_year < MinimumYear && _year > MaximumYear) throw new DateOverflowException("年份超出范围！");
         if (_month < 1 && _month > 12) throw new DateOverflowException("月份超出范围！");
         if (_day < 1 && _day > MaximumDays) throw new DateOverflowException("天数超出当前月份所包含天数的范围");
         year = _year;
         month = _month;
         day = _day;
      }
      /// <summary>
      /// 获取BigDate能够表示的最大年份
      /// </summary>
      public static int MaximumYear
      {
         get { return int.MaxValue; }
      }
      /// <summary>
      /// 获取BigDate能够表示的最小年份
      /// </summary>
      public static int MinimumYear
      {
         get { return -6000; }
      }
      /// <summary>
      /// 获取当前实例中指定的月份的最大天数
      /// </summary>
      public byte MaximumDays
      {
         get
         {
            byte maxdays = 30;
            switch (Month)
            {
               case 1:
               case 3:
               case 5:
               case 7:
               case 8:
               case 10:
               case 12:
                  maxdays = 31;
                  break;
               case 4:
               case 6:
               case 9:
               case 11:
                  maxdays = 30;
                  break;
               case 2:
                  if (IsIntercalaryYear()) maxdays = 29; else maxdays = 28;
                  break;
            }
            return maxdays;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的年份
      /// </summary>
      public int Year
      {
         get { return year; }
         set
         {
            if (value < MinimumYear && value > MaximumYear) throw new DateOverflowException("年份超出范围！");
            year = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的月份
      /// </summary>
      public byte Month
      {
         get { return month; }
         set
         {
            if (value < 1 && value > 12) throw new DateOverflowException("月份超出范围！");
            month = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例中这个月份所显示的天数
      /// </summary>
      public byte Day
      {
         get { return day; }
         set
         {
            if (value < 1 && value > MaximumDays) throw new DateOverflowException("天数超出当前月份所包含天数的范围");
            day = value;
         }
      }
      /// <summary>
      /// 获取当前实例的日期是从-6000年01月01日开始的第几天
      /// </summary>
      public ulong DaysBeginWithMinimumYear
      {
         get
         {
            ulong days = 0;
            int leapyear_count = 0;
            days = (ulong)Math.Abs(MinimumYear) * 365 + (ulong)Year * 365;
            if (IsIntercalaryYear()) days += (ulong)new DateTime(2008, Month, Day).DayOfYear;
            else days += (ulong)new DateTime(2010, Month, Day).DayOfYear;
            for (int i = MinimumYear; i <= Year; i++)
            {
               if (new BigDate(i, 1, 1).IsIntercalaryYear()) ++leapyear_count;
            }
            return days + (ulong)leapyear_count;
         }
      }
      /// <summary>
      /// 判定当前实例所表示的年份是否属于闰年
      /// </summary>
      /// <returns>如果当前日期表示的年份是闰年，则返回true，否则返回false。</returns>
      public bool IsIntercalaryYear()
      {
         return DateTime.IsLeapYear(Year);
      }
      /// <summary>
      /// 将两个年份按照从小到大的顺序排列
      /// </summary>
      /// <param name="_diffdate">指定的BigDate实例。</param>
      /// <returns>若执行成功，则会返回一个有顺序的年份列表。</returns>
      public List<int> CompareOfYear(BigDate _diffdate)
      {
         return Year >= _diffdate.Year ? new int[] { _diffdate.Year, Year }.ToList() : new int[] { Year, _diffdate.Year }.ToList();
      }
      /// <summary>
      /// 将两个日期按照年份从小到大的顺序排列
      /// </summary>
      /// <param name="_diffdate">指定的BigDate实例。</param>
      /// <returns>若执行成功，则会返回一个有顺序的DateTime年份列表。</returns>
      public List<DateTime> CompareOfDateTime(BigDate _diffdate)
      {
         return Year >= _diffdate.Year ? new DateTime[]
         {
            new DateTime(_diffdate.Year, _diffdate.Month, _diffdate.Day),
            new DateTime(Year, Month, Day)
         }
         .ToList() :
         new DateTime[]
         {
            new DateTime(Year, Month, Day),
            new DateTime(_diffdate.Year, _diffdate.Month, _diffdate.Day)
         }.ToList();
      }
      /// <summary>
      /// 获取指定范围之间的闰年年份
      /// </summary>
      /// <param name="_diffdate">指定的范围上限或者下限。</param>
      /// <returns>如果函数无异常，则会返回一个范围内的闰年集合。</returns>
      public List<int> GetIntercalaryYears(BigDate _diffdate)
      {
         List<int> leaps = new List<int>();
         if (Math.Abs(CompareOfYear(_diffdate)[0] - CompareOfYear(_diffdate)[1]) < 2)
         {
            throw new DifferenceTooSmallException("指定范围的年份差的绝对值不能小于2！");
         }
         Parallel.For(CompareOfYear(_diffdate)[0], CompareOfYear(_diffdate)[1] + 1, (index) =>
         {
            if (new BigDate(index, 1, 1).IsIntercalaryYear()) leaps.Add(index);
         });
         leaps.Sort();
         return leaps;
      }
      /// <summary>
      /// 计算指定日期与当前日期之间的天数差
      /// </summary>
      /// <param name="_diffdate">指定的与当前日期有差别的日期。</param>
      /// <returns>如果这个方法未抛出异常，则会返回两个日期之间的天数差的UInt64表示形式。</returns>
      public ulong GetDifferenceOfDay(BigDate _diffdate)
      {
         return (ulong)Math.Abs(DaysBeginWithMinimumYear - (decimal)_diffdate.DaysBeginWithMinimumYear);
      }
      /// <summary>
      /// 获取当前实例的指定格式的字符串
      /// </summary>
      /// <param name="_category">指定的格式，即显示方式。</param>
      /// <returns>该操作将会返回这个实例的字符串形式，但是这个字符串是一个有使用意义的字符串。</returns>
      public string ToString(EDateDisplayCategory _category)
      {
         string datest = string.Empty;
         switch (_category)
         {
            case EDateDisplayCategory.OnlySerial:
               datest = Year.ToString() + Month.ToString("D2") + Day.ToString("D2");
               break;
            case EDateDisplayCategory.SolidusSegmentation:
               datest = Year.ToString() + "/" + Month.ToString("D2") + "/" + Day.ToString("D2");
               break;
            case EDateDisplayCategory.DashedSegmentation:
               datest = Year.ToString() + "-" + Month.ToString("D2") + "-" + Day.ToString("D2");
               break;
            case EDateDisplayCategory.PointSegmentation:
               datest = Year.ToString() + "." + Month.ToString("D2") + "." + Day.ToString("D2");
               break;
            case EDateDisplayCategory.VolnaSegmentation:
               datest = Year.ToString() + "~" + Month.ToString("D2") + "~" + Day.ToString("D2");
               break;
            case EDateDisplayCategory.ChineseSegmentation:
               datest = Year.ToString() + "年" + Month.ToString("D2") + "月" + Day.ToString("D2") + "日";
               break;
            default:
               datest = Year.ToString() + Month.ToString("D2") + Day.ToString("D2");
               break;
         }
         return datest;
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.BigDate";
      }
   }
   /// <summary>
   /// 关系运算符的枚举
   /// </summary>
   [Obsolete("Do not use it")]
   public enum ERelationalOperator : int
   {
      /// <summary>
      /// 等于
      /// </summary>
      Equal = 0x0000,
      /// <summary>
      /// 大于
      /// </summary>
      GreaterThan = 0x0001,
      /// <summary>
      /// 小于
      /// </summary>
      LessThan = 0x0002,
      /// <summary>
      /// 大于等于
      /// </summary>
      GtEqual = 0x0003,
      /// <summary>
      /// 小于等于
      /// </summary>
      LtEqual = 0x0004,
      /// <summary>
      /// 不等于
      /// </summary>
      NotEqual = 0x0005
   }
   /// <summary>
   /// 日期显示方式的枚举
   /// </summary>
   public enum EDateDisplayCategory : int
   {
      /// <summary>
      /// 序列表示
      /// </summary>
      OnlySerial = 0x0000,
      /// <summary>
      /// 斜线符号分割
      /// </summary>
      SolidusSegmentation = 0x0001,
      /// <summary>
      /// 短横线符号分割
      /// </summary>
      DashedSegmentation = 0x0002,
      /// <summary>
      /// 句点符号分割
      /// </summary>
      PointSegmentation = 0x0003,
      /// <summary>
      /// 波浪号分割
      /// </summary>
      VolnaSegmentation = 0x0004,
      /// <summary>
      /// 中文单位分割
      /// </summary>
      ChineseSegmentation = 0x0006
   }
   /// <summary>
   /// 大型日期任意成分超出范围时而抛出的异常
   /// </summary>
   [Serializable]
   public class DateOverflowException : Exception
   {
      public DateOverflowException() { }
      public DateOverflowException(string message) : base(message) { }
      public DateOverflowException(string message, Exception inner) : base(message, inner) { }
      protected DateOverflowException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 如果指定的年份范围太小而抛出的异常
   /// </summary>
   [Serializable]
   public class DifferenceTooSmallException : Exception
   {
      public DifferenceTooSmallException() { }
      public DifferenceTooSmallException(string message) : base(message) { }
      public DifferenceTooSmallException(string message, Exception inner) : base(message, inner) { }
      protected DifferenceTooSmallException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
