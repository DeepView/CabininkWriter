﻿using System;
using System.Collections.Generic;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 播放列表类
   /// </summary>
   public class PlayQueue
   {
      /// <summary>
      /// 当前实例的播放列表
      /// </summary>
      private List<Sound> queue;
      /// <summary>
      /// 构造函数，创建一个空列表的实例
      /// </summary>
      public PlayQueue() : base()
      {
         queue = new List<Sound>();
      }
      /// <summary>
      /// 构造函数，创建一个指定List实例的播放列表实例
      /// </summary>
      /// <param name="_queue">需要被播放的声音列表。</param>
      public PlayQueue(List<Sound> _queue)
      {
         if (_queue == null) throw new ObjectDisposedException("找不到列表实例！");
         queue = _queue;
      }
      /// <summary>
      /// 构造函数，创建一个指定文件地址集合和播放窗体句柄的播放列表实例
      /// </summary>
      /// <param name="_furls">需要被播放的声音集合的文件地址列表。</param>
      /// <param name="_handle">播放声音的窗体句柄。</param>
      public PlayQueue(List<string> _furls, IntPtr _handle, double _vol)
      {
         if (_furls == null) throw new ObjectDisposedException("找不到列表实例！");
         for (int i = 0; i < Count; i++) AddSound(new Sound(_furls[i], _handle, _vol));
      }
      /// <summary>
      /// 获取当前实例的声音文件数量
      /// </summary>
      public int Count
      {
         get { return PlayList.Count; }
      }
      /// <summary>
      /// 获取或设置当前实例中指定索引所对应的声音实例
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      /// <returns>如果无异常抛出，则将会返回指定索引所对应的那个声音实例。</returns>
      public Sound this[int _index]
      {
         get
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("_index", "索引超出范围！");
            return PlayList[_index];
         }
         set
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("_index", "索引超出范围！");
            PlayList[_index] = value;
         }
      }
      /// <summary>
      /// 获取当前实例的播放列表
      /// </summary>
      public List<Sound> PlayList
      {
         get { return queue; }
      }
      /// <summary>
      /// 获取当前实例中正在播放的声音实例在列表中的索引，如果无任何声音文件播放则返回-1
      /// </summary>
      public int Playing
      {
         get
         {
            int playing = -1;
            bool ispaused = false;
            bool isplaying = false;
            for (int i = 0; i < Count; i++)
            {
               ispaused = PlayList[i].Status == EPlayStatus.Paused;
               isplaying = PlayList[i].Status == EPlayStatus.Playing;
               if (ispaused || isplaying) playing = i;
            }
            return playing;
         }
      }
      /// <summary>
      /// 获取当前实例中正在播放的声音实例，如果没有任何声音文件播放则返回null
      /// </summary>
      public Sound PlayingExample
      {
         get
         {
            Sound playing;
            if (Playing >= 0) playing = this[Playing];
            else playing = null;
            return playing;
         }
      }
      /// <summary>
      /// 向列表中添加一个声音实例
      /// </summary>
      /// <param name="_item">被添加的声音实例。</param>
      public void AddSound(Sound _item)
      {
         PlayList.Add(_item);
      }
      /// <summary>
      /// 从列表中移除一个声音实例
      /// </summary>
      /// <param name="_index">被移除的声音实例的索引。</param>
      public void RemoveSound(int _index)
      {
         PlayList.RemoveAt(_index);
      }
      /// <summary>
      /// 从列表中移除一个声音实例
      /// </summary>
      /// <param name="_item">被移除的声音实例，操作结果则是在列表中检索出的第一个相匹配的声音实例。</param>
      public void RemoveSound(Sound _item)
      {
         PlayList.Remove(_item);
      }
      /// <summary>
      /// 开始播放
      /// </summary>
      /// <param name="_index">即将开始播放的声音文件的索引。</param>
      public void StartPlay(int _index)
      {
         if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("_index", "索引超出范围！");
         if (Count != 0)
         {
            if (Playing >= 0) this[Playing].FinalizePlay();
            this[_index].ResetPlay();
         }
      }
      /// <summary>
      /// 暂停播放
      /// </summary>
      public void Pause()
      {
         if (Count != 0) this[Playing].InterruptPlay();
      }
      /// <summary>
      /// 继续播放
      /// </summary>
      public void Continue()
      {
         if (Count != 0) this[Playing].ContinuePlay();
      }
      /// <summary>
      /// 停止播放
      /// </summary>
      public void Stop()
      {
         if (Count != 0) this[Playing].FinalizePlay();
      }
      /// <summary>
      /// 播放上一个声音实例
      /// </summary>
      public void Previous()
      {
         Pause();
         if (Playing == 0)
         {
            StartPlay(Count - 1);
            this[0].FinalizePlay();
         }
         else
         {
            StartPlay(Playing - 1);
            this[Playing + 1].FinalizePlay();
         }
      }
      /// <summary>
      /// 播放下一个声音实例
      /// </summary>
      public void Next()
      {
         Pause();
         if (Playing == Count - 1)
         {
            StartPlay(0);
            this[Count - 1].FinalizePlay();
         }
         else
         {
            StartPlay(Playing + 1);
            this[Playing - 1].FinalizePlay();
         }
      }
   }
}
