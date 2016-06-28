using System;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Aac;
using Un4seen.Bass.AddOn.Ape;
using Un4seen.Bass.AddOn.Wma;
using Un4seen.Bass.AddOn.Flac;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 立体声声道电平采样数据结构体
   /// </summary>
   public struct SChannelLevel
   {
      /// <summary>
      /// 左声道电平采样数据
      /// </summary>
      public int LeftLevel;
      /// <summary>
      /// 右声道电平采样数据
      /// </summary>
      public int RightLevel;
      /// <summary>
      /// 构造函数，创建一个指定左右声道电平采样数据的结构体实例
      /// </summary>
      /// <param name="_left">左声道电平采样数据。</param>
      /// <param name="_right">右声道电平采样数据。</param>
      public SChannelLevel(int _left, int _right)
      {
         LeftLevel = _left;
         RightLevel = _right;
      }
      /// <summary>
      /// 获取当前结构体实例的字符串表达形式
      /// </summary>
      /// <returns>该操作会返回当前结构体实例的字符串表达形式。</returns>
      public override string ToString()
      {
         return "[ L=" + LeftLevel + "; R=" + RightLevel + " ]";
      }
   }
   /// <summary>
   /// 声音文件播放类
   /// </summary>
   public class Sound : IDisposable
   {
      /// <summary>
      /// 需要被播放的声音文件
      /// </summary>
      private string mediauri;
      /// <summary>
      /// 声音文件的文件类型，即文件格式
      /// </summary>
      private ESoundCategory category;
      /// <summary>
      /// 播放声音的窗体的句柄
      /// </summary>
      private IntPtr srchwnd;
      /// <summary>
      /// 声音句柄
      /// </summary>
      private int soundhwnd;
      /// <summary>
      /// 播放通道是否正在运行
      /// </summary>
      private bool isplaying;
      /// <summary>
      /// 播放通道是否已停止
      /// </summary>
      private bool isstoped;
      /// <summary>
      /// 播放进度
      /// </summary>
      private double schedule;
      /// <summary>
      /// 检测冗余调用
      /// </summary>
      private bool disposedval = false;
      /// <summary>
      /// 构造函数，创建一个指定文件路径的实例
      /// </summary>
      /// <param name="_furl">需要被播放的声音文件。</param>
      /// <param name="_handle">播放声音文件的窗口句柄。</param>
      public Sound(string _furl, IntPtr _handle)
      {
         if (FileOperation.FileExists(_furl) == false) throw new NotFoundFileException("文件不存在！");
         mediauri = _furl;
         SetSoundCategory();
         srchwnd = _handle;
         isstoped = true;
         isplaying = false;
         if (!(Bass.BASS_Init(-1, 192000, BASSInit.BASS_DEVICE_CPSPEAKERS, srchwnd)) == true)
         {
            Console.WriteLine("设备初始化出现异常！发生时间：" + DateTime.Now);
         }
      }
      /// <summary>
      /// 构造函数，创建一个指定文件路径的实例
      /// </summary>
      /// <param name="_furl">需要被播放的声音文件。</param>
      /// <param name="_handle">播放声音文件的窗口句柄。</param>
      /// <param name="_vol">设置的音量。</param>
      public Sound(string _furl, IntPtr _handle, double _vol)
      {
         if (FileOperation.FileExists(_furl) == false) throw new NotFoundFileException("文件不存在！");
         mediauri = _furl;
         SetSoundCategory();
         srchwnd = _handle;
         isstoped = true;
         isplaying = false;
         PlayingVolume = _vol;
         if (!(Bass.BASS_Init(-1, 192000, BASSInit.BASS_DEVICE_CPSPEAKERS, srchwnd)) == true)
         {
            Console.WriteLine("设备初始化出现异常！发生时间：" + DateTime.Now);
         }
      }
      /// <summary>
      /// 获取或设置当前实例的声音文件地址
      /// </summary>
      public string MediaUri
      {
         get { return mediauri; }
         set
         {
            if (FileOperation.FileExists(value) == false) throw new NotFoundFileException("文件不存在！");
            mediauri = value;
            SetSoundCategory();
         }
      }
      /// <summary>
      /// 获取当前实例的声音文件格式
      /// </summary>
      public ESoundCategory SoundCategory
      {
         get { return category; }
      }
      /// <summary>
      /// 获取当前实例的播放设备句柄
      /// </summary>
      public int SoundHandle
      {
         get { return soundhwnd; }
         set { soundhwnd = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的播放进度（用0到1之间的浮点数表示）
      /// </summary>
      public double PlayingAccomplishment
      {
         get
         {
            if (SoundHandle == 0 || Bass.BASS_ChannelBytes2Seconds(
               SoundHandle,
               Bass.BASS_ChannelGetPosition(SoundHandle)
            ) == -1)
            {
               schedule = 0;
            }
            else
            {
               schedule = Bass.BASS_ChannelBytes2Seconds(
                  SoundHandle,
                  Bass.BASS_ChannelGetPosition(SoundHandle)) / Bass.BASS_ChannelBytes2Seconds(
                     SoundHandle,
                     Bass.BASS_ChannelGetLength(SoundHandle)
               );
            }
            return schedule;
         }
         set
         {
            schedule = value;
            double temp = schedule * Bass.BASS_ChannelBytes2Seconds(
               SoundHandle,
               Bass.BASS_ChannelGetLength(SoundHandle)
            );
            Bass.BASS_ChannelSetPosition(SoundHandle, Bass.BASS_ChannelSeconds2Bytes(SoundHandle, temp));
         }
      }
      /// <summary>
      /// 获取或设置当前实例的播放音量（用0到1之间的浮点数表示）
      /// </summary>
      public double PlayingVolume
      {
         get { return Bass.BASS_GetVolume(); }
         set { Bass.BASS_SetVolume((float)value); }
      }
      /// <summary>
      /// 获取当前实例的播放状态
      /// </summary>
      public EPlayStatus Status
      {
         get
         {
            EPlayStatus stat = EPlayStatus.Paused;
            if (isstoped) stat = EPlayStatus.Stoped;
            if (isplaying) stat = EPlayStatus.Playing;
            if (isplaying == false && isstoped == false) stat = EPlayStatus.Paused;
            return stat;
         }
      }
      /// <summary>
      /// 重新开始播放，即重头开始播放
      /// </summary>
      public void ResetPlay()
      {
         BASSFlag flags = BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_DEFAULT | BASSFlag.BASS_STREAM_AUTOFREE;
         switch (SoundCategory)
         {
            case ESoundCategory.Mpeg:
               SoundHandle = Bass.BASS_StreamCreateFile(MediaUri, 0, 0, flags);
               break;
            case ESoundCategory.Aac:
               SoundHandle = BassAac.BASS_AAC_StreamCreateFile(MediaUri, 0, 0, flags);
               break;
            case ESoundCategory.Ape:
               SoundHandle = BassApe.BASS_APE_StreamCreateFile(MediaUri, 0, 0, flags);
               break;
            case ESoundCategory.Flac:
               SoundHandle = BassFlac.BASS_FLAC_StreamCreateFile(MediaUri, 0, 0, flags);
               break;
            case ESoundCategory.Wave:
               SoundHandle = BassWma.BASS_WMA_StreamCreateFile(MediaUri, 0, 0, flags);
               break;
            default:
               throw new FormatNotSupportedException("文件格式不支持！");
         }
         isstoped = false;
         isplaying = true;
         Bass.BASS_ChannelPlay(SoundHandle, !isstoped);
      }
      /// <summary>
      /// 暂停（中断）播放
      /// </summary>
      public void InterruptPlay()
      {
         Bass.BASS_ChannelPause(SoundHandle);
         isstoped = false;
         isplaying = false;
      }
      /// <summary>
      /// 继续播放
      /// </summary>
      public void ContinuePlay()
      {
         Bass.BASS_ChannelPlay(SoundHandle, isstoped);
         isplaying = true;
      }
      /// <summary>
      /// 停止播放
      /// </summary>
      public void FinalizePlay()
      {
         Bass.BASS_ChannelStop(SoundHandle);
         Bass.BASS_ChannelSetPosition(SoundHandle, 0, 0);
         isstoped = true;
         isplaying = false;
      }
      /// <summary>
      /// 获取当前实例的立体声声道电平采样数据
      /// </summary>
      /// <returns>该操作如果无异常发生，则将会返回一个立体声声道电平采样数据结构体实例。</returns>
      public SChannelLevel GetChannelLevel()
      {
         int level = Bass.BASS_ChannelGetLevel(srchwnd.ToInt32());
         return new SChannelLevel(Utils.LowWord32(level), Utils.HighWord32(level));
      }
      /// <summary>
      /// 设置声音文件的格式
      /// </summary>
      internal void SetSoundCategory()
      {
         string exname = FileOperation.GetFileExtension(MediaUri);
         switch (exname)
         {
            case ".m4a":
            case ".mp3":
               category = ESoundCategory.Mpeg;
               break;
            case ".aac":
               category = ESoundCategory.Aac;
               break;
            case ".wav":
            case ".wma":
               category = ESoundCategory.Wave;
               break;
            case ".ape":
               category = ESoundCategory.Ape;
               break;
            case ".flac":
               category = ESoundCategory.Flac;
               break;
            default:
               throw new FormatNotSupportedException("文件格式不支持！");
         }
      }
      /// <summary>
      /// 获取当前实例的字符串表达形式
      /// </summary>
      /// <returns>该操作将会返回当前实例的文件路径的文件名（不包含文件后缀名）。</returns>
      public override string ToString()
      {
         return FileOperation.GetFileNameWithoutExtension(MediaUri);
      }
      /// <summary>
      /// 释放当前实例使用的未托管资源，同时还可以根据需要释放托管资源
      /// </summary>
      /// <param name="_disposing">决定该方法如何释放资源，若为true则释放托管资源和非托管资源，否则仅释放非托管资源。</param>
      protected virtual void Dispose(bool disposing)
      {
         if (!disposedval)
         {
            if (disposing)
            {
               mediauri = null;
               srchwnd = IntPtr.Zero;
            }
            Bass.BASS_Free();
            disposedval = true;
         }
      }
      /// <summary>
      /// 清理实例内部的所有资源所占用的托管内存，注意若实例外部代码存在断开托管堆引用的代码，则此操作可能会引发一些异常的清理操作
      /// </summary>
      ~Sound()
      {
         Dispose(false);
      }
      /// <summary>
      /// 释放由当前对象占用的所有资源
      /// </summary>
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
   }
   /// <summary>
   /// 声音文件的格式类型枚举
   /// </summary>
   public enum ESoundCategory : int
   {
      /// <summary>
      /// MPEG类型
      /// </summary>
      Mpeg = 0x0000,
      /// <summary>
      /// AAC类型
      /// </summary>
      Aac = 0x0001,
      /// <summary>
      /// APE类型
      /// </summary>
      Ape = 0x0002,
      /// <summary>
      /// FLAC类型
      /// </summary>
      Flac = 0x0003,
      /// <summary>
      /// 波形声音类型
      /// </summary>
      Wave = 0x0004
   }
   /// <summary>
   /// 播放状态枚举
   /// </summary>
   public enum EPlayStatus : int
   {
      /// <summary>
      /// 正在播放
      /// </summary>
      Playing = 0x0000,
      /// <summary>
      /// 已暂停
      /// </summary>
      Paused = 0x0001,
      /// <summary>
      /// 已停止
      /// </summary>
      Stoped = 0x0002
   }
   /// <summary>
   /// 文件格式不支持时而抛出的异常
   /// </summary>
   [Serializable]
   public class FormatNotSupportedException : Exception
   {
      public FormatNotSupportedException() { }
      public FormatNotSupportedException(string message) : base(message) { }
      public FormatNotSupportedException(string message, Exception inner) : base(message, inner) { }
      protected FormatNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// BASS初始化失败时抛出的异常
   /// </summary>
   [Serializable]
   public class BassInitializeFialException : Exception
   {
      public BassInitializeFialException() { }
      public BassInitializeFialException(string message) : base(message) { }
      public BassInitializeFialException(string message, Exception inner) : base(message, inner) { }
      protected BassInitializeFialException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
