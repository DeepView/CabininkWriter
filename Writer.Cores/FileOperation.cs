﻿using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 这个类实现了最常用的文件操作
   /// </summary>
   public class FileOperation
   {
      /// <summary>
      /// 根据指定的访问权限和共享模式创建文件
      /// </summary>
      /// <param name="_furl">需要被创建的文件地址。</param>
      /// <param name="_access">文件的访问权限。</param>
      /// <param name="_share">文件的共享模式。</param>
      public static void CreateFile(string _furl, FileAccess _access, FileShare _share)
      {
         if (FileExists(_furl)) throw new FileIsExistedException("指定的文件已存在！");
         try
         {
            GetFatherDirectory(_furl);
         }
         catch (DirectoryNotFoundException ex)
         {
            throw new NotFoundDirectoryException("找不到这个父路径！", ex);
         }
         FileStream fs = new FileStream(_furl, FileMode.CreateNew, _access, _share);
         fs.Close();
      }
      /// <summary>
      /// 将指定文件的内容以文本方式读取
      /// </summary>
      /// <param name="_furl">需要被读取内容的文件的地址。</param>
      /// <param name="_isreadtoend">指示是否读取到文件末尾，true表示读取到文件末尾，false表示只读取一行。</param>
      /// <param name="_encoding">以什么编码方式来组织读取的文本。</param>
      /// <returns>该方法会返回一个字符串，这个字符串存储了这个文件所读取出来的文本内容。</returns>
      public static string ReadFile(string _furl, bool _isreadtoend, Encoding _encoding)
      {
         if (FileExists(_furl) == false) throw new NotFoundFileException("找不到指定的文件");
         string fcon = String.Empty;
         StreamReader srr = new StreamReader(_furl, _encoding);
         if (_isreadtoend) fcon = srr.ReadToEnd(); else fcon = srr.ReadLine();
         srr.Close();
         return fcon;
      }
      /// <summary>
      /// 将指定的文本内容写入指定的文件
      /// </summary>
      /// <param name="_furl">指定的文件路径。</param>
      /// <param name="_fcon">需要写入文件的文本内容。</param>
      /// <param name="_isappend">指示是否把当前要写入的文本内容追加到文件末尾。</param>
      /// <param name="_isapdlmark">指示是否在文本内容后追加一个换行符。</param>
      /// <param name="_encoding">指定的文本编码。</param>
      public static void WriteFile(string _furl, string _fcon, bool _isappend, bool _isapdlmark, Encoding _encoding)
      {
         if (FileExists(_furl) == false) throw new NotFoundFileException("找不到指定的文件");
         StreamWriter srw = new StreamWriter(_furl, _isappend, _encoding);
         if (_isapdlmark) srw.WriteLine(_fcon); else srw.Write(_fcon);
         srw.Close();
      }
      /// <summary>
      /// 删除指定的文件，如果文件不存在则引发异常
      /// </summary>
      /// <param name="_furl">需要被删除的文件的地址。</param>
      public static void DeleteFile(string _furl)
      {
         if (FileExists(_furl) == false) throw new NotFoundFileException("指定的文件找不到！");
         File.Delete(_furl);
      }
      /// <summary>
      /// 检查指定的文件是否存在
      /// </summary>
      /// <param name="_furl">指定文件的地址。</param>
      /// <returns>如果文件存在则返回true，否则返回false。</returns>
      public static bool FileExists(string _furl)
      {
         return File.Exists(_furl);
      }
      /// <summary>
      /// 创建指定的目录
      /// </summary>
      /// <param name="_dir">需要被创建的目录。</param>
      public static void CreateDirectory(string _dir)
      {
         if (DirectoryExists(_dir)) throw new DirectoryIsExistedException("指定的目录已存在！");
         Directory.CreateDirectory(_dir);
      }
      /// <summary>
      /// 删除一个指定的空目录
      /// </summary>
      /// <param name="_dir">需要被删除的空目录。</param>
      public static void DeleteEmptyDirectory(string _dir)
      {
         if (Directory.GetDirectories(_dir).GetLength(0) != 0) throw new IsNotEmptyDirectoryException("目录下面仍存在其他目录！");
         if (DirectoryExists(_dir) == false) throw new NotFoundDirectoryException("指定的目录已存在！");
         Directory.Delete(_dir);
      }
      /// <summary>
      /// 获取一个不包含后缀名的文件名
      /// </summary>
      /// <param name="_furl">需要被获取文件名的文件的本地地址。</param>
      /// <returns>如果不抛出任何异常，则该操作会返回一个不包含目录和后缀名的文件名。</returns>
      public static string GetFileNameWithoutExtension(string _furl)
      {
         return Path.GetFileNameWithoutExtension(_furl);
      }
      /// <summary>
      /// 获取一个包含后缀名的文件名
      /// </summary>
      /// <param name="_furl">需要被获取文件名的文件的本地地址。</param>
      /// <returns>如果不抛出任何异常，则该操作会返回一个不包含目录的文件名。</returns>
      public static string GetFileName(string _furl)
      {
         return GetFileNameWithoutExtension(_furl) + GetFileExtension(_furl);
      }
      /// <summary>
      /// 获取一个文件的后缀名
      /// </summary>
      /// <param name="_furl">用于被获取后缀名的文件地址。</param>
      /// <returns>如果没有异常发生，则将返回这个文件的后缀名，假设一个文件地址为C:\Windows\System32\cmd.exe，则这个操作返回的文件后缀名为.exe，而非exe。</returns>
      public static string GetFileExtension(string _furl)
      {
         return new FileInfo(_furl).Extension;
      }
      /// <summary>
      /// 获取指定目录下面的所有文件名（包含路径和扩展名）
      /// </summary>
      /// <param name="_dir">指定的目录。</param>
      /// <returns>如果不产生异常，该操作则会返回一个包含文件名集合的列表，如果该目录下没有任何文件则返回一个空列表。</returns>
      public static List<string> GetFiles(string _dir)
      {
         List<string> flist = new List<string>();
         if (DirectoryExists(_dir) == false) throw new NotFoundDirectoryException("指定的目录找不到");
         string[] arrlist = Directory.GetFiles(_dir);
         flist.AddRange(arrlist);
         return flist;
      }
      /// <summary>
      /// 获取指定目录下符合类型筛选的所有文件名（包含路径和扩展名）
      /// </summary>
      /// <param name="_dir">指定的目录。</param>
      /// <param name="_types">指定的类型集合，比如说：new string[] { ".doc", ".docx" }。</param>
      /// <returns>如果不产生异常，该操作则会返回一个包含符合类型筛选的文件名集合的列表，如果该目录下没有任何文件则返回一个空列表。</returns>
      public static List<string> GetFiles(string _dir, string[] _types)
      {
         List<string> flist = new List<string>();
         List<string> temp = GetFiles(_dir);
         for (int i = 0; i < temp.Count; i++)
         {
            for (int j = 0; j < _types.Count(); j++)
            {
               if (GetFileExtension(temp[i]) == _types[j]) flist.Add(temp[i]);
            }
         }
         return flist;
      }
      /// <summary>
      /// 获取指定目录下的所有子目录的名称
      /// </summary>
      /// <param name="_dir">指定的目录。</param>
      /// <returns>如果不产生异常，则该操作会返回一个包含子目录集合的列表，如果该目录下没有任何子目录，则将会返回一个空列表。</returns>
      public static List<string> GetFolders(string _dir)
      {
         if (DirectoryExists(_dir) == false) throw new NotFoundDirectoryException("指定的目录找不到");
         return Directory.GetDirectories(_dir).ToList();
      }
      /// <summary>
      /// 获取指定文件夹的名称，但不会返回完整名称
      /// </summary>
      /// <param name="_dir">指定的目录。</param>
      /// <returns>操作成功之后将会返回一个文件夹名称字符串。</returns>
      public static string GetFolderName(string _dir)
      {
         return new DirectoryInfo(_dir).Name;
      }
      /// <summary>
      /// 检查指定的目录是否存在
      /// </summary>
      /// <param name="_dir">指定的目录。</param>
      /// <returns>如果目录存在则返回true，否则返回false。</returns>
      public static bool DirectoryExists(string _dir)
      {
         return Directory.Exists(_dir);
      }
      /// <summary>
      /// 获取指定文件所在的目录
      /// </summary>
      /// <param name="_furl">需要被获取目录的文件地址。</param>
      /// <returns>这个操作会返回一个字符串，该字符串存储了这个操作所获取的目录，如果操作失败可能会引发相关的异常。</returns>
      public static string GetFatherDirectory(string _furl)
      {
         return Directory.GetParent(_furl).FullName;
      }
   }
   /// <summary>
   /// 文件已存在时抛出的异常
   /// </summary>
   [Serializable]
   public class FileIsExistedException : Exception
   {
      public FileIsExistedException() { }
      public FileIsExistedException(string message) : base(message) { }
      public FileIsExistedException(string message, Exception inner) : base(message, inner) { }
      protected FileIsExistedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 文件不存在时抛出的异常
   /// </summary>
   [Serializable]
   public class NotFoundFileException : Exception
   {
      public NotFoundFileException() { }
      public NotFoundFileException(string message) : base(message) { }
      public NotFoundFileException(string message, Exception inner) : base(message, inner) { }
      protected NotFoundFileException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 目录已存在时抛出的异常
   /// </summary>
   [Serializable]
   public class DirectoryIsExistedException : Exception
   {
      public DirectoryIsExistedException() { }
      public DirectoryIsExistedException(string message) : base(message) { }
      public DirectoryIsExistedException(string message, Exception inner) : base(message, inner) { }
      protected DirectoryIsExistedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 找不到目录时抛出的异常
   /// </summary>
   [Serializable]
   public class NotFoundDirectoryException : Exception
   {
      public NotFoundDirectoryException() { }
      public NotFoundDirectoryException(string message) : base(message) { }
      public NotFoundDirectoryException(string message, Exception inner) : base(message, inner) { }
      protected NotFoundDirectoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 当指定目录是非空目录时抛出的异常
   /// </summary>
   [Serializable]
   public class IsNotEmptyDirectoryException : Exception
   {
      public IsNotEmptyDirectoryException() { }
      public IsNotEmptyDirectoryException(string message) : base(message) { }
      public IsNotEmptyDirectoryException(string message, Exception inner) : base(message, inner) { }
      protected IsNotEmptyDirectoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
