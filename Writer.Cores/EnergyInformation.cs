﻿using System;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 能源信息结构体
   /// </summary>
   [StructLayout(LayoutKind.Sequential)]
   public struct SPowerStatus
   {
      /// <summary>
      /// AC电源状态
      /// </summary>
      public byte AcLineStatus;
      /// <summary>
      /// 电池状态
      /// </summary>
      public byte BatteryFlag;
      /// <summary>
      /// 电池的可用电量
      /// </summary>
      public byte BatteryLifePercent;
      /// <summary>
      /// 电池保护程序的状态
      /// </summary>
      public byte Reserved;
      /// <summary>
      /// 电池剩余电量可用时间
      /// </summary>
      public int BatteryLifeTime;
      /// <summary>
      /// 电池最佳状态下的可用时间
      /// </summary>
      public uint BatteryFullLifeTime;
   }
   /// <summary>
   /// 计算机能源信息类
   /// </summary>
   public sealed class EnergyInformation
   {
      /// <summary>
      /// 获取计算机的能源信息
      /// </summary>
      /// <param name="_ps">计算机能源信息的结构类型。</param>
      /// <returns>获取当前计算机的能源信息，所传入的参数所表示的状态在操作执行之后指示系统是否运行在交流或直流电源、是否电池正在充电时，电池还有多少寿命。</returns>
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private extern static bool GetSystemPowerStatus(SPowerStatus _ps);
      /// <summary>
      /// 检索活动电源方案并返回GUID
      /// </summary>
      /// <param name="_usrrtpwrkey">此参数是保留供将来使用，必须设置为 NULL。</param>
      /// <param name="_guidpointer">接收到一个 GUID 结构的指针的指针，使用 LocalFree 函数来释放该内存。</param>
      /// <returns>检索Windows当前所有的活动电源方案并返回对应的GUID，如果调用成功，则返回0，否则返回非0。</returns>
      [DllImport("powrprof.dll", CharSet = CharSet.Auto, SetLastError = true)]
      private extern static uint PowerGetActiveScheme(IntPtr _usrrtpwrkey, ref IntPtr _guidpointer);
      /// <summary>
      /// 设置当前用户的活动电源方案
      /// </summary>
      /// <param name="_usrrtperkey">此参数是保留供将来使用，必须设置为 NULL。</param>
      /// <param name="_sguid">指定电源方案的GUID。</param>
      /// <returns>设置当前Windows用户的活动电源方案，如果操作成功则返回0，否则返回非0。</returns>
      [DllImport("powrprof.dll", CharSet = CharSet.Auto)]
      private extern static uint PowerSetActiveScheme(IntPtr _usrrtperkey, ref IntPtr _sguid);
      /// <summary>
      /// 检索指定电源设置的AC索引
      /// </summary>
      /// <param name="_rtperkey">此参数是保留供将来使用，必须设置为 NULL。</param>
      /// <param name="_sguid">电源使用方案的标识符。</param>
      /// <param name="_subgroup">电源设置的子群。此参数可以是 WinNT.h 中的定义为下列值之一。使用 NO_SUBGROUP_GUID 来引用的默认电源方案。
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————
      /// |NO_SUBGROUP_GUID //
      /// |fea3413e-7e05-4911-9a71-700331f1c294 //
      /// |Settings in this subgroup are part of the default power scheme.
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————
      /// |GUID_DISK_SUBGROUP //
      /// |0012ee47-9041-4b5d-9b77-535fba8b1442 //
      /// |Settings in this subgroup control power management configuration of the system's hard disk drives.
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————
      /// |GUID_SYSTEM_BUTTON_SUBGROUP //
      /// |4f971e89-eebd-4455-a8de-9e59040e7347 // 
      /// |Settings in this subgroup control configuration of the system power buttons.
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————
      /// |GUID_PROCESSOR_SETTINGS_SUBGROUP //
      /// |54533251-82be-4824-96c1-47b60b740d00 // 
      /// |Settings in this subgroup control configuration of processor power management features.
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————
      /// |GUID_VIDEO_SUBGROUP //
      /// |7516b95f-f776-4464-8c53-06167f40cc99 //
      /// |Settings in this subgroup control configuration of the video power management features.
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————
      /// |GUID_BATTERY_SUBGROUP //
      /// |e73a048d-bf27-4f12-9731-8b2076e8891f //
      /// |Settings in this subgroup control battery alarm trip points and actions.
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————
      /// |GUID_SLEEP_SUBGROUP //
      /// |238C9FA8-0AAD-41ED-83F4-97BE242C8F20 //
      /// |Settings in this subgroup control system sleep settings.
      /// |———————————————————————————————————————————————————————————————————————————————————————————————————— 
      /// |GUID_PCIEXPRESS_SETTINGS_SUBGROUP //
      /// |501a4d13-42af-4429-9fd1-a8218c268e20 //
      /// |Settings in this subgroup control PCI Express settings.
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————
      /// </param>
      /// <param name="_settingguid">电源设置标识符。</param>
      /// <param name="_acvalidx">指向接收 AC 值索引的变量的指针。</param>
      /// <returns>检索Windows指定的电源设置方案的AC索引，如果操作成功则返回0，否则返回非0。</returns>
      [DllImport("powrprof.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
      private extern static uint PowerReadACValueIndex(IntPtr _rtperkey, byte[] _sguid, byte[] _subgroup, byte[] _settingguid, ref IntPtr _acvalidx);
      /// <summary>
      /// 设置指定电源解决方案的AC值索引
      /// </summary>
      /// <param name="_rtperkey">此参数是保留供将来使用，必须设置为 NULL。</param>
      /// <param name="_sguid">指定电源方案的GUID。</param>
      /// <param name="_subgroup">电源设置的子群。此参数可以是 WinNT.h 中的定义为下列值之一。使用 NO_SUBGROUP_GUID 来引用的默认电源方案。
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// |NO_SUBGROUP_GUID //<br/>
      /// |fea3413e-7e05-4911-9a71-700331f1c294 //<br/>
      /// |Settings in this subgroup are part of the default power scheme.<br/>
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// |GUID_DISK_SUBGROUP //<br/>
      /// |0012ee47-9041-4b5d-9b77-535fba8b1442 //<br/>
      /// |Settings in this subgroup control power management configuration of the system's hard disk drives.<br/>
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// |GUID_SYSTEM_BUTTON_SUBGROUP //<br/>
      /// |4f971e89-eebd-4455-a8de-9e59040e7347 // <br/>
      /// |Settings in this subgroup control configuration of the system power buttons.<br/>
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// |GUID_PROCESSOR_SETTINGS_SUBGROUP //<br/>
      /// |54533251-82be-4824-96c1-47b60b740d00 // <br/>
      /// |Settings in this subgroup control configuration of processor power management features.
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// |GUID_VIDEO_SUBGROUP //<br/>
      /// |7516b95f-f776-4464-8c53-06167f40cc99 //<br/>
      /// |Settings in this subgroup control configuration of the video power management features.<br/>
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// |GUID_BATTERY_SUBGROUP //<br/>
      /// |e73a048d-bf27-4f12-9731-8b2076e8891f //<br/>
      /// |Settings in this subgroup control battery alarm trip points and actions.<br/>
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// |GUID_SLEEP_SUBGROUP //<br/>
      /// |238C9FA8-0AAD-41ED-83F4-97BE242C8F20 //<br/>
      /// |Settings in this subgroup control system sleep settings.<br/>
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// |GUID_PCIEXPRESS_SETTINGS_SUBGROUP //<br/>
      /// |501a4d13-42af-4429-9fd1-a8218c268e20 //<br/>
      /// |Settings in this subgroup control PCI Express settings.<br/>
      /// |————————————————————————————————————————————————————————————————————————————————————————————————————<br/>
      /// </param>
      /// <param name="_settingguid">电源设置的标识符。</param>
      /// <param name="_acvalidx">AC 值的索引。</param>
      /// <returns>设置Windows指定电源解决方案的AC值索引，如果操作成功则返回0，否则返回非0。</returns>
      [DllImport("powrprof.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
      private extern static uint PowerWriteACValueIndex(IntPtr _rtperkey, byte[] _sguid, byte[] _subgroup, byte[] _settingguid, int _acvalidx);
      /// <summary>
      /// 使应用程序能够告知系统，它是在使用中，当应用程序正在运行时，从而防止从进入睡眠或关闭显示器
      /// </summary>
      /// <param name="_flags">执行标识。</param>
      /// <returns>使应用程序能够告知系统，它是在使用中，当应用程序正在运行时，从而防止从进入睡眠或关闭显示器。</returns>
      [DllImport("kernel32.dll")]
      private extern static uint SetThreadExecutionState(EExecutionFlag _flags);
      /// <summary>
      /// 注册以接收通知时电源设置的更改
      /// </summary>
      /// <param name="_recipient">指示电源设置通知在哪里发送。</param>
      /// <param name="_settingguid">指示为哪些通知发送GUID。</param>
      /// <param name="_flags">执行标志。</param>
      /// <returns>返回用于注销为电源通知通知句柄。如果函数失败，返回值为 NULL。</returns>
      [DllImport("user32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
      private extern static IntPtr RegisterPowerSettingNotification(IntPtr _recipient, ref Guid _settingguid, uint _flags);
      /// <summary>
      /// 获取AC电源的状态
      /// </summary>
      /// <returns>获取当前计算机所连接的AC电源适配器的状态。</returns>
      public static EAcPowerStatus GetAcPowerStatus()
      {
         SPowerStatus ps = new SPowerStatus();
         bool b = GetSystemPowerStatus(ps);
         EAcPowerStatus stat = EAcPowerStatus.Unknown;
         switch (ps.AcLineStatus)
         {
            case 0:
               stat = EAcPowerStatus.TurnOff;
               break;
            case 1:
               stat = EAcPowerStatus.TurnOn;
               break;
            case 255:
               stat = EAcPowerStatus.Unknown;
               break;
         }
         return stat;
      }
      /// <summary>
      /// 获取电池状态
      /// </summary>
      /// <returns>获取当前计算机所配备的电池的状态信息。</returns>
      public static EBatteryStatus GetBatteryStatus()
      {
         SPowerStatus ps = new SPowerStatus();
         bool b = GetSystemPowerStatus(ps);
         EBatteryStatus stat = EBatteryStatus.Charging;
         if (Convert.ToBoolean(ps.BatteryFlag) & Convert.ToBoolean(1)) stat = EBatteryStatus.High;
         if (Convert.ToBoolean(ps.BatteryFlag) & Convert.ToBoolean(2)) stat = EBatteryStatus.Low;
         if (Convert.ToBoolean(ps.BatteryFlag) & Convert.ToBoolean(4)) stat = EBatteryStatus.Critical;
         if (Convert.ToBoolean(ps.BatteryFlag) & Convert.ToBoolean(8)) stat = EBatteryStatus.Charging;
         if (Convert.ToBoolean(ps.BatteryFlag) & Convert.ToBoolean(128)) stat = EBatteryStatus.NoSystemBattery;
         return stat;
      }
      /// <summary>
      /// 获取电池电量
      /// </summary>
      /// <returns>获取当前计算机所配备的电池的可用电量，该操作执行后会返回一个整型数据，100表示电量已满，0表示电量归零，255则表示电池电量未知。</returns>
      public static int GetQuantityOfBattery()
      {
         SPowerStatus ps = new SPowerStatus();
         bool b = GetSystemPowerStatus(ps);
         if (ps.BatteryLifePercent == 255) throw new UnknownQuantityOfBatteryException("电池电量未知！");
         return ps.BatteryLifePercent;
      }
      /// <summary>
      /// 获取未充电时的电池可用时间
      /// </summary>
      /// <returns>获取当前计算机在未连接或者未充电的情况下的电池的电量的可用时间，单位为second。</returns>
      public static int GetBatteryLifeTime()
      {
         SPowerStatus ps = new SPowerStatus();
         bool b = GetSystemPowerStatus(ps);
         if (ps.BatteryLifeTime == -1) throw new UnknownBatteryUseTimeSpanException("电池剩余电量的使用时间暂时无法测定！");
         if (GetBatteryStatus() == EBatteryStatus.Charging) throw new UnknownBatteryUseTimeSpanException("无法查看充电状态下的电池电量使用时间！");
         return ps.BatteryLifeTime;
      }
      /// <summary>
      /// 阻止系统休眠，直到线程结束恢复休眠策略
      /// </summary>
      /// <param name="_includeDisplay">是否阻止关闭显示器</param>
      public static void PreventSleep(bool _includeDisplay)
      {
         if (_includeDisplay)
         {
            SetThreadExecutionState(EExecutionFlag.System | EExecutionFlag.Display | EExecutionFlag.Continus);
         }
         else
         {
            SetThreadExecutionState(EExecutionFlag.System | EExecutionFlag.Continus);
         }
      }
      /// <summary>
      /// 恢复系统休眠策略
      /// </summary>
      public static void ResotreSleep()
      {
         SetThreadExecutionState(EExecutionFlag.Continus);
      }
      /// <summary>
      /// 重置系统休眠计时器
      /// </summary>
      /// <param name="_includeDisplay">是否阻止关闭显示器</param>
      public static void ResetSleepTimer(bool _includeDisplay = false)
      {
         if (_includeDisplay)
         {
            SetThreadExecutionState(EExecutionFlag.System | EExecutionFlag.Display);
         }
         else
         {
            SetThreadExecutionState(EExecutionFlag.System);
         }
      }
   }
   /// <summary>
   /// 休眠机制的执行标志。只使用Continus参数时，则是恢复系统休眠策略。不使用Continus参数时，实现阻止系统休眠或显示器关闭一次。组合使用Continus参数时，实现阻止系统休眠或显示器关闭至线程终止
   /// </summary>
   [Flags()]
   public enum EExecutionFlag : uint
   {
      /// <summary>
      /// System执行标志
      /// </summary>
      System = 0x1,
      /// <summary>
      /// Display执行标志
      /// </summary>
      Display = 0x2,
      /// <summary>
      /// Continus执行标志
      /// </summary>
      Continus = 0x80000000u
   }
   /// <summary>
   /// AC电源的状态
   /// </summary>
   public enum EAcPowerStatus : byte
   {
      /// <summary>
      /// 关闭状态
      /// </summary>
      TurnOff = 0,
      /// <summary>
      /// 打开状态
      /// </summary>
      TurnOn = 1,
      /// <summary>
      /// 未知状态
      /// </summary>
      Unknown = 255
   }
   /// <summary>
   /// 电池状态的枚举
   /// </summary>
   public enum EBatteryStatus : byte
   {
      /// <summary>
      /// 电量充足
      /// </summary>
      High = 1,
      /// <summary>
      /// 电量较低
      /// </summary>
      Low = 2,
      /// <summary>
      /// 电量严重不足
      /// </summary>
      Critical = 4,
      /// <summary>
      /// 正在充电
      /// </summary>
      Charging = 8,
      /// <summary>
      /// 无电源
      /// </summary>
      NoSystemBattery = 128
   }
   /// <summary>
   /// 电池使用时间未知时而抛出的异常
   /// </summary>
   [Serializable]
   public class UnknownBatteryUseTimeSpanException : Exception
   {
      public UnknownBatteryUseTimeSpanException() { }
      public UnknownBatteryUseTimeSpanException(string message) : base(message) { }
      public UnknownBatteryUseTimeSpanException(string message, Exception inner) : base(message, inner) { }
      protected UnknownBatteryUseTimeSpanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 不清楚电池电量时而抛出的异常
   /// </summary>
   [Serializable]
   public class UnknownQuantityOfBatteryException : Exception
   {
      public UnknownQuantityOfBatteryException() { }
      public UnknownQuantityOfBatteryException(string message) : base(message) { }
      public UnknownQuantityOfBatteryException(string message, Exception inner) : base(message, inner) { }
      protected UnknownQuantityOfBatteryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
