using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 压缩文件操作类
   /// </summary>
   public class CompressedOperation
   {
      /// <summary>
      /// 压缩指定的文件夹
      /// </summary>
      /// <param name="_dir">需要被压缩的文件夹。</param>
      /// <param name="_zipedfile">压缩后的文件。</param>
      /// <param name="_level">压缩级别。</param>
      /// <returns>该操作如果成功则返回true，否则返回false。</returns>
      public static bool CompressDirectory(string _dir, string _zipedfile, int _level)
      {
         if (Directory.Exists(_dir)) return CompressDictory(_dir, _zipedfile, _level);
         else if (File.Exists(_dir)) return CompressFile(_dir, _zipedfile, _level);
         else return false;
      }
      /// <summary>
      /// 解压指定的文件夹
      /// </summary>
      /// <param name="_unziped">待解压的文件。</param>
      /// <param name="_target">解压目标存放目录。</param>
      public static void UncompressDirectory(string _unziped, string _target)
      {
         if (!File.Exists(_unziped)) return;
         if (!Directory.Exists(_target)) Directory.CreateDirectory(_target);
         ZipInputStream s = null;
         ZipEntry theEntry = null;
         string fileName;
         FileStream streamWriter = null;
         try
         {
            s = new ZipInputStream(File.OpenRead(_unziped));
            while ((theEntry = s.GetNextEntry()) != null)
            {
               if (theEntry.Name != String.Empty)
               {
                  fileName = Path.Combine(_target, theEntry.Name);
                  if (fileName.EndsWith("/") || fileName.EndsWith("\\"))
                  {
                     Directory.CreateDirectory(fileName);
                     continue;
                  }
                  streamWriter = File.Create(fileName);
                  int size = 2048;
                  byte[] data = new byte[2048];
                  while (true)
                  {
                     size = s.Read(data, 0, data.Length);
                     if (size > 0) streamWriter.Write(data, 0, size); else break;
                  }
               }
            }
         }
         finally
         {
            if (streamWriter != null)
            {
               streamWriter.Close();
               streamWriter = null;
            }
            if (theEntry != null) theEntry = null;
            if (s != null)
            {
               s.Close();
               s = null;
            }
            GC.Collect();
            GC.Collect(1);
         }
      }
      /// <summary>
      /// 递归方式压缩文件夹
      /// </summary>
      /// <param name="_foldertozip">被压缩的文件夹。</param>
      /// <param name="_outputstream">指定的压缩流。</param>
      /// <param name="_pfolder">父文件夹。</param>
      /// <returns>该操作如果成功则返回true，否则返回false。</returns>
      private static bool CompressDictory(string _foldertozip, ZipOutputStream _outputstream, string _pfolder)
      {
         bool res = true;
         string[] folders, filenames;
         ZipEntry entry = null;
         FileStream fs = null;
         Crc32 crc = new Crc32();
         try
         {
            entry = new ZipEntry(Path.Combine(_pfolder, Path.GetFileName(_foldertozip) + "/"));
            _outputstream.PutNextEntry(entry);
            _outputstream.Flush();
            filenames = Directory.GetFiles(_foldertozip);
            foreach (string file in filenames)
            {
               fs = File.OpenRead(file);
               byte[] buffer = new byte[fs.Length];
               fs.Read(buffer, 0, buffer.Length);
               entry = new ZipEntry(Path.Combine(_pfolder, Path.GetFileName(_foldertozip) + "/" + Path.GetFileName(file)));
               entry.DateTime = DateTime.Now;
               entry.Size = fs.Length;
               fs.Close();
               crc.Reset();
               crc.Update(buffer);
               entry.Crc = crc.Value;
               _outputstream.PutNextEntry(entry);
               _outputstream.Write(buffer, 0, buffer.Length);
            }
         }
         catch
         {
            res = false;
         }
         finally
         {
            if (fs != null)
            {
               fs.Close();
               fs = null;
            }
            if (entry != null) entry = null;
            GC.Collect();
            GC.Collect(1);
         }
         folders = Directory.GetDirectories(_foldertozip);
         foreach (string folder in folders)
         {
            if (!CompressDictory(folder, _outputstream, Path.Combine(_pfolder, Path.GetFileName(_foldertozip)))) return false;
         }
         return res;
      }
      /// <summary>
      /// 压缩指定的文件夹
      /// </summary>
      /// <param name="_foldertozip">需要被压缩的文件夹。</param>
      /// <param name="_zipedfile">压缩后的文件。</param>
      /// <param name="_level">压缩级别。</param>
      /// <returns>该操作如果成功则返回true，否则返回false。</returns>
      private static bool CompressDictory(string _foldertozip, string _zipedfile, int _level)
      {
         bool res;
         if (!Directory.Exists(_foldertozip)) return false;
         ZipOutputStream s = new ZipOutputStream(File.Create(_zipedfile));
         s.SetLevel(_level);
         res = CompressDictory(_foldertozip, s, "");
         s.Finish();
         s.Close();
         return res;
      }
      /// <summary>
      /// 压缩文件
      /// </summary>
      /// <param name="_filetozip">要进行压缩的文件名</param>
      /// <param name="_zipedfile">压缩后生成的压缩文件名</param>
      /// <param name="_level">压缩级别。</param>
      /// <returns>该操作如果成功则返回true，否则返回false。</returns>
      private static bool CompressFile(string _filetozip, string _zipedfile, int _level)
      {
         if (!File.Exists(_filetozip)) throw new FileNotFoundException("需要被压缩的文件不存在!");
         FileStream zipFile = null;
         ZipOutputStream zipStream = null;
         ZipEntry zipEntry = null;
         bool res = true;
         try
         {
            zipFile = File.OpenRead(_filetozip);
            byte[] buffer = new byte[zipFile.Length];
            zipFile.Read(buffer, 0, buffer.Length);
            zipFile.Close();
            zipFile = File.Create(_zipedfile);
            zipStream = new ZipOutputStream(zipFile);
            zipEntry = new ZipEntry(Path.GetFileName(_filetozip));
            zipStream.PutNextEntry(zipEntry);
            zipStream.SetLevel(_level);
            zipStream.Write(buffer, 0, buffer.Length);
         }
         catch
         {
            res = false;
         }
         finally
         {
            if (zipEntry != null) zipEntry = null;
            if (zipStream != null)
            {
               zipStream.Finish();
               zipStream.Close();
            }
            if (zipFile != null)
            {
               zipFile.Close();
               zipFile = null;
            }
            GC.Collect();
            GC.Collect(1);
         }
         return res;
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.CompressedFileOperation";
      }
   }
}
