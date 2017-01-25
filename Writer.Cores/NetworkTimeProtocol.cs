﻿using System;
using System.Net;
using System.Net.Sockets;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 网络时间协议类
   /// </summary>
   /// <example>
   /// 下面是如何实现与NIST的NTP服务器同步时间的示例代码（NTP默认端口123）
   /// <code>
   /// NetworkTimeProtocol ntp = new NetworkTimeProtocol("192.43.244.18");
   /// ntp.Synchronization();
   /// </code>
   /// </example>
   public class NetworkTimeProtocol
   {
      /// <summary>
      /// NTP数据结构长度
      /// </summary>
      private const byte NTP_DATA_STRING_LENGTH = 48;
      /// <summary>
      /// NTP数据结构
      /// </summary>
      private byte[] ntpdat = new byte[NTP_DATA_STRING_LENGTH];
      /// <summary>
      /// 引用编号常量
      /// </summary>
      private const byte OFF_REFID = 12;
      /// <summary>
      /// 所提供的引用时间戳
      /// </summary>
      private const byte OFF_REFTIMESTAMP = 16;
      /// <summary>
      /// 所提供的起始时间戳
      /// </summary>
      private const byte OFF_ORITIMESTAMP = 24;
      /// <summary>
      /// 所提供的接收时间戳
      /// </summary>
      private const byte OFF_RECTTIMESTAMP = 32;
      /// <summary>
      /// 所提供的传输时间戳
      /// </summary>
      private const byte OFF_TRATIMESTAMP = 40;
      /// <summary>
      /// 接收时间戳
      /// </summary>
      public DateTime rectimestamp;
      /// <summary>
      /// 时间服务器地址
      /// </summary>
      private string server;
      /// <summary>
      /// 时间服务器端口
      /// </summary>
      private string port;
      /// <summary>
      /// 构造函数，创建一个指定时间服务器和默认端口的NTP实例
      /// </summary>
      /// <param name="_host">指定的时间服务器。</param>
      public NetworkTimeProtocol(string _host)
      {
         server = _host;
         port = @"123";
      }
      /// <summary>
      /// 构造函数，创建一个指定时间服务器和端口的NTP实例
      /// </summary>
      /// <param name="_host">指定的时间服务器。</param>
      /// <param name="_port">指定的时间服务器端口。</param>
      public NetworkTimeProtocol(string _host, int _port)
      {
         server = _host;
         port = _port.ToString();
      }
      /// <summary>
      /// 获取当前实例的时间调整指示
      /// </summary>
      public ELeapIndicator LeapIndicator
      {
         get
         {
            byte val = (byte)(ntpdat[0] >> 6);
            switch (val)
            {
               case 0: return ELeapIndicator.NoWarning;
               case 1: return ELeapIndicator.LastMinute61;
               case 2: return ELeapIndicator.LastMinute59;
               case 3:
               default:
                  return ELeapIndicator.Alarm;
            }
         }
      }
      /// <summary>
      /// 获取当前实例的协议版本
      /// </summary>
      public byte VersionNumber
      {
         get
         {
            byte val = (byte)((ntpdat[0] & 0x38) >> 3);
            return val;
         }
      }
      /// <summary>
      /// 获取当前实例的操作返回模式
      /// </summary>
      public ENtpOperatingReturnMode Mode
      {
         get
         {
            byte val = (byte)(ntpdat[0] & 0x7);
            switch (val)
            {
               case 0:
               case 6:
               case 7:
               default:
                  return ENtpOperatingReturnMode.Unknown;
               case 1:
                  return ENtpOperatingReturnMode.SymmetricActive;
               case 2:
                  return ENtpOperatingReturnMode.SymmetricPassive;
               case 3:
                  return ENtpOperatingReturnMode.Client;
               case 4:
                  return ENtpOperatingReturnMode.Server;
               case 5:
                  return ENtpOperatingReturnMode.Broadcast;
            }
         }
      }
      /// <summary>
      /// 获取当前实例的层级字段值
      /// </summary>
      public EStratum Stratum
      {
         get
         {
            byte val = (byte)ntpdat[1];
            if (val == 0) return EStratum.Unspecified;
            else if (val == 1) return EStratum.PrimaryReference;
            else if (val <= 15) return EStratum.SecondaryReference;
            else return EStratum.Reserved;
         }
      }
      /// <summary>
      /// 获取当前实例的协议轮询间隔
      /// </summary>
      public uint PollInterval
      {
         get
         {
            return (uint)Math.Round(Math.Pow(2, ntpdat[2]));
         }
      }
      /// <summary>
      /// 获取当前实例的协议精度（以毫秒为单位）
      /// </summary>
      public double Precision
      {
         get
         {
            return (1000 * Math.Pow(2, ntpdat[3]));
         }
      }
      /// <summary>
      /// 获取当前实例的协议根延迟（以毫秒为单位）
      /// </summary>
      public double RootDelay
      {
         get
         {
            int temp = 0;
            temp = 256 * (256 * (256 * ntpdat[4] + ntpdat[5]) + ntpdat[6]) + ntpdat[7];
            return 1000 * (((double)temp) / 0x10000);
         }
      }
      /// <summary>
      /// 获取当前实例的协议根离散（以毫秒为单位）
      /// </summary>
      public double RootDispersion
      {
         get
         {
            int temp = 0;
            temp = 256 * (256 * (256 * ntpdat[8] + ntpdat[9]) + ntpdat[10]) + ntpdat[11];
            return 1000 * (((double)temp) / 0x10000);
         }
      }
      /// <summary>
      /// 获取当前实例的引用编号
      /// </summary>
      public string ReferenceId
      {
         get
         {
            string val = "";
            switch (Stratum)
            {
               case EStratum.Unspecified:
               case EStratum.PrimaryReference:
                  val += Convert.ToChar(ntpdat[OFF_REFID + 0]);
                  val += Convert.ToChar(ntpdat[OFF_REFID + 1]);
                  val += Convert.ToChar(ntpdat[OFF_REFID + 2]);
                  val += Convert.ToChar(ntpdat[OFF_REFID + 3]);
                  break;
               case EStratum.SecondaryReference:
                  break;
            }
            return val;
         }
      }
      /// <summary>
      /// 获取当前实例的引用时间戳
      /// </summary>
      public DateTime ReferenceTimestamp
      {
         get
         {
            DateTime time = ComputeDate(GetMilliSeconds(OFF_REFTIMESTAMP));
            // Take care of the time zone
            long offset = Convert.ToInt64(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now));
            TimeSpan offspan = TimeSpan.FromTicks(offset);
            return time + offspan;
         }
      }
      /// <summary>
      /// 获取当前实例的起始时间戳
      /// </summary>
      public DateTime OriginateTimestamp
      {
         get
         {
            return ComputeDate(GetMilliSeconds(OFF_ORITIMESTAMP));
         }
      }
      /// <summary>
      /// 获取当前实例的接收时间戳
      /// </summary>
      public DateTime ReceiveTimestamp
      {
         get
         {
            DateTime time = ComputeDate(GetMilliSeconds(OFF_RECTTIMESTAMP));
            long offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Ticks;
            TimeSpan offspan = TimeSpan.FromTicks(offset);
            return time + offspan;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的传输时间戳
      /// </summary>
      public DateTime TransmitTimestamp
      {
         get
         {
            DateTime time = ComputeDate(GetMilliSeconds(OFF_TRATIMESTAMP));
            // Take care of the time zone    
            long offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Ticks;
            TimeSpan offspan = TimeSpan.FromTicks(offset);
            return time + offspan;
         }
         set
         {
            SetDate(OFF_TRATIMESTAMP, value);
         }
      }
      /// <summary>
      /// 获取当前实例的传输往返延迟
      /// </summary>
      public int RoundTripDelay
      {
         get
         {
            TimeSpan span = (ReceiveTimestamp - OriginateTimestamp) + (rectimestamp - TransmitTimestamp);
            return (int)span.TotalMilliseconds;
         }
      }
      /// <summary>
      /// 获取当前实例的本地时钟偏移量（以毫秒为单位）
      /// </summary>
      public int LocalClockOffset
      {
         get
         {
            TimeSpan span = (ReceiveTimestamp - OriginateTimestamp) - (rectimestamp - TransmitTimestamp);
            return (int)(span.TotalMilliseconds / 2);
         }
      }
      /// <summary>
      /// 初始化NTP客户端
      /// </summary>
      private void InitializeNtpCliect()
      {
         ntpdat[0] = 0x1B;
         for (int i = 1; i < 48; i++) ntpdat[i] = 0;
         TransmitTimestamp = DateTime.Now;
      }
      /// <summary>
      /// 根据自1900年1月1日以来所经过的毫秒数来计算日期
      /// </summary>
      /// <param name="_milliseconds">指定的毫秒数。</param>
      /// <returns>该操作将会返回根据指定毫秒数来转换的日期。</returns>
      public DateTime ComputeDate(ulong _milliseconds)
      {
         TimeSpan span = TimeSpan.FromMilliseconds((double)_milliseconds);
         DateTime time = new DateTime(1900, 1, 1);
         time += span;
         return time;
      }
      /// <summary>
      /// 会根据所给出的8字节数组的偏移量来计算的毫秒数
      /// </summary>
      /// <param name="_offset">指定的8字节数组的偏移量。</param>
      /// <returns>返回一个指定偏移量所计算出来的毫秒数。</returns>
      public ulong GetMilliSeconds(byte _offset)
      {
         ulong intpart = 0, fractpart = 0;
         for (int i = 0; i <= 3; i++)
         {
            intpart = 256 * intpart + ntpdat[_offset + i];
         }
         for (int i = 4; i <= 7; i++)
         {
            fractpart = 256 * fractpart + ntpdat[_offset + i];
         }
         ulong milliseconds = intpart * 1000 + (fractpart * 1000) / 0x100000000L;
         return milliseconds;
      }
      /// <summary>
      /// 设置日期
      /// </summary>
      /// <param name="_offset">偏移量。</param>
      /// <param name="_date">需要被设置的日期。</param>
      public void SetDate(byte _offset, DateTime _date)
      {
         ulong intpart = 0, fractpart = 0;
         DateTime StartOfCentury = new DateTime(1900, 1, 1, 0, 0, 0);
         ulong milliseconds = (ulong)(_date - StartOfCentury).TotalMilliseconds;
         intpart = milliseconds / 1000;
         fractpart = ((milliseconds % 1000) * 0x100000000L) / 1000;
         ulong temp = intpart;
         for (int i = 3; i >= 0; i--)
         {
            ntpdat[_offset + i] = (byte)(temp % 256);
            temp = temp / 256;
         }
         temp = fractpart;
         for (int i = 7; i >= 4; i--)
         {
            ntpdat[_offset + i] = (byte)(temp % 256);
            temp = temp / 256;
         }
      }
      /// <summary>
      /// 连接到NTP服务器并将服务器上的时间同步到本地
      /// </summary>
      public void Synchronization()
      {
         try
         {
            IPAddress hostadd = IPAddress.Parse(server);
            IPEndPoint EPhost = new IPEndPoint(hostadd, Convert.ToInt32(port));
            UdpClient TimeSocket = new UdpClient();
            TimeSocket.Connect(EPhost);
            InitializeNtpCliect();
            TimeSocket.Send(ntpdat, ntpdat.Length);
            ntpdat = TimeSocket.Receive(ref EPhost);
            if (!IsResponseValid())
            {
               throw new Exception("Invalid response from " + server);
            }
            rectimestamp = DateTime.Now;
         }
         catch (SocketException e)
         {
            throw new Exception(e.Message);
         }
      }
      /// <summary>
      /// 检查来自服务器的响应是否有效
      /// </summary>
      /// <returns>如果服务器的响应有效则返回true，否则返回false。</returns>
      public bool IsResponseValid()
      {
         if (ntpdat.Length < NTP_DATA_STRING_LENGTH || Mode != ENtpOperatingReturnMode.Server) return false;
         else return true;
      }
      /// <summary>
      /// 获取当前实例的字符串表达形式
      /// </summary>
      /// <returns>该操作将会返回一个用于用户理解的类的字符串表达形式文本。</returns>
      public override string ToString()
      {
         string str = string.Empty;
         str = "Leap Indicator: ";
         switch (LeapIndicator)
         {
            case ELeapIndicator.NoWarning:
               str += "No warning";
               break;
            case ELeapIndicator.LastMinute61:
               str += "Last minute has 61 seconds";
               break;
            case ELeapIndicator.LastMinute59:
               str += "Last minute has 59 seconds";
               break;
            case ELeapIndicator.Alarm:
               str += "Alarm Condition (clock not synchronized)";
               break;
         }
         str += "\r\nVersion number: " + VersionNumber.ToString() + "\r\n";
         str += "Mode: ";
         switch (Mode)
         {
            case ENtpOperatingReturnMode.Unknown:
               str += "Unknown";
               break;
            case ENtpOperatingReturnMode.SymmetricActive:
               str += "Symmetric Active";
               break;
            case ENtpOperatingReturnMode.SymmetricPassive:
               str += "Symmetric Pasive";
               break;
            case ENtpOperatingReturnMode.Client:
               str += "Client";
               break;
            case ENtpOperatingReturnMode.Server:
               str += "Server";
               break;
            case ENtpOperatingReturnMode.Broadcast:
               str += "Broadcast";
               break;
         }
         str += "\r\nStratum: ";
         switch (Stratum)
         {
            case EStratum.Unspecified:
            case EStratum.Reserved:
               str += "Unspecified";
               break;
            case EStratum.PrimaryReference:
               str += "Primary Reference";
               break;
            case EStratum.SecondaryReference:
               str += "Secondary Reference";
               break;
         }
         str += "\r\nLocal time: " + TransmitTimestamp.ToString();
         str += "\r\nPrecision: " + Precision.ToString() + " ms";
         str += "\r\nPoll Interval: " + PollInterval.ToString() + " s";
         str += "\r\nReference ID: " + ReferenceId.ToString();
         str += "\r\nRoot Dispersion: " + RootDispersion.ToString() + " ms";
         str += "\r\nRound Trip Delay: " + RoundTripDelay.ToString() + " ms";
         str += "\r\nLocal Clock Offset: " + LocalClockOffset.ToString() + " ms";
         str += "\r\n";
         return str;
      }

   }
   /// <summary>
   /// 时间调整指示枚举
   /// </summary>
   public enum ELeapIndicator : int
   {
      /// <summary>
      /// 没有任何指示
      /// </summary>
      NoWarning = 0x0000,
      /// <summary>
      /// 最后一分钟多了一秒
      /// </summary>
      LastMinute61 = 0x0001,
      /// <summary>
      /// 最后一分钟少了一秒
      /// </summary>
      LastMinute59 = 0x0002,
      /// <summary>
      /// 报警状态，时钟不同步
      /// </summary>
      Alarm = 0x0003
   }
   /// <summary>
   /// NTP操作返回类型模式枚举
   /// </summary>
   public enum ENtpOperatingReturnMode
   {
      /// <summary>
      /// Symmetric active
      /// </summary>
      SymmetricActive = 0x0001,
      /// <summary>
      /// Symmetric pasive
      /// </summary>
      SymmetricPassive = 0x0002,
      /// <summary>
      /// Client
      /// </summary>
      Client = 0x0003,
      /// <summary>
      /// Server
      /// </summary>
      Server = 0x0004,
      /// <summary>
      /// Broadcast
      /// </summary>
      Broadcast = 0x0005,
      /// <summary>
      /// Reserved or unknown
      /// </summary>
      Unknown = 0x0000
   }
   /// <summary>
   /// 层级字段值枚举
   /// </summary>
   public enum EStratum
   {
      /// <summary>
      /// 未指定或不可用
      /// </summary>
      Unspecified = 0x0000,
      /// <summary>
      /// 主引用
      /// </summary>
      PrimaryReference = 0x0001,
      /// <summary>
      /// 次引用
      /// </summary>
      SecondaryReference = 0x000f,
      /// <summary>
      /// 保留字段值
      /// </summary>
      Reserved = 0x00ff
   }
}
