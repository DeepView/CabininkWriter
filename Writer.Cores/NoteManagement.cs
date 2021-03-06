﻿using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 写作笔记管理类
   /// </summary>
   public class NoteManagement : IDisposable
   {
      /// <summary>
      /// 需要被管理的笔记集合
      /// </summary>
      private List<Note> notes;
      /// <summary>
      /// 用于实现管理的数据库操作实例
      /// </summary>
      private DatabaseOperation dbopt;
      /// <summary>
      /// 构造函数，创建一个由空Note列表指定的实例
      /// </summary>
      public NoteManagement()
      {
         notes = new List<Note>();
      }
      /// <summary>
      /// 构造函数，创建一个由非空Note列表指定的实例
      /// </summary>
      /// <param name="_notes">指定的Note实例。</param>
      public NoteManagement(List<Note> _notes)
      {
         if (_notes == null) throw new ObjectDisposedException("不允许空引用的实例！");
         notes = _notes;
      }
      /// <summary>
      /// 获取当前实例的笔记数量
      /// </summary>
      public int Count
      {
         get { return notes.Count; }
      }
      /// <summary>
      /// 获取或设置当前实例指定索引所对应的写作笔记实例
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      /// <returns>如果不抛出任何异常，则将会获取指定索引所对应的那个笔记实例。</returns>
      public Note this[int _index]
      {
         get
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("_index", "索引超出范围！");
            return notes[_index];
         }
         set
         {
            if (_index < 0 || _index > Count) throw new ArgumentOutOfRangeException("_index", "索引超出范围！");
            notes[_index] = value;
         }
      }
      /// <summary>
      /// 初始化管理平台
      /// </summary>
      public void InitializeSupportedDb()
      {
         dbopt = new DatabaseOperation(@"Data Source=databases\notes.db");
         dbopt.InitializeConnection();
         dbopt.Connect();
      }
      /// <summary>
      /// 添加一个笔记实例
      /// </summary>
      /// <param name="_item">需要被添加的笔记实例。</param>
      public void AddNote(Note _item)
      {
         notes.Add(_item);
      }
      /// <summary>
      /// 根据指定索引移除一个笔记实例
      /// </summary>
      /// <param name="_index">指定的索引。</param>
      public void RemoveNote(int _index)
      {
         notes.RemoveAt(_index);
      }
      /// <summary>
      /// 移除与参数相匹配的第一个笔记实例
      /// </summary>
      /// <param name="_item">用于匹配的笔记实例。</param>
      public void RemoveNote(Note _item)
      {
         notes.Remove(_item);
      }
      /// <summary>
      /// 移除与指定记录时间相匹配的笔记实例
      /// </summary>
      /// <param name="_time">用于作为匹配条件的时间实例。</param>
      public void RemoveNote(DateTime _time)
      {
         notes.RemoveAll(delegate (Note _note)
         {
            return _time.Ticks == _note.RecordTime.Ticks;
         });
      }
      /// <summary>
      /// 从数据库中读取所有的笔记并添加到实例中
      /// </summary>
      public void ReadAll()
      {
         SQLiteDataReader reader;
         DateTime note_dt = DateTime.Now;
         ENoteFlag note_flag = ENoteFlag.Normal;
         string note_title = string.Empty, note_body = string.Empty;
         reader = dbopt.InvokeSqlToReader(@"select * from notes");
         while (reader.Read())
         {
            note_dt = new DateTime(reader.GetInt64(reader.GetOrdinal("_time")));
            note_title = reader.GetString(reader.GetOrdinal("_title"));
            note_body = reader.GetString(reader.GetOrdinal("_context"));
            note_flag = (ENoteFlag)reader.GetInt32(reader.GetOrdinal("_flag"));
            AddNote(new Note(note_dt, note_title, note_body, note_flag));
         }
         reader.Close();
      }
      /// <summary>
      /// 保存所有笔记到数据库
      /// </summary>
      public void SaveAll()
      {
         int count = Count;
         for (int i = 0; i < count; i++)
         {
            this[i].InitializeSupportedDb();
            this[i].Save();
            this[i].Dispose();
         }
      }
      /// <summary>
      /// 根据笔记日期来对所有的笔记进行排序
      /// </summary>
      public void Sort()
      {
         notes.Sort(delegate (Note _note1, Note _note2)
         {
            return _note1.RecordTime.Ticks.CompareTo(_note2.RecordTime.Ticks);
         });
      }
      /// <summary>
      /// 在断开对象引用连接的同时断开数据库的连接
      /// </summary>
      public void Dispose()
      {
         dbopt.Disconnect();
      }
   }
}
