﻿using System;
using System.Reflection;
using System.Diagnostics;
namespace Cabinink.Writer.Middle
{
   /// <summary>
   /// 该类用于获取当前程序集的基础程序集信息
   /// </summary>
   public sealed class AssemblyInformation
   {
      /// <summary>
      /// 获取当前应用程序的友好名称
      /// </summary>
      public static string ApplicationName { get { return CurrentAssembly.GetName().Name; } }
      /// <summary>
      /// 获取当前应用程序的完全限定名称
      /// </summary>
      public static string AssemblyFullName { get { return CurrentAssembly.FullName; } }
      /// <summary>
      /// 获取支持当前程序集运行的公共语言运行时版本的字符串表达形式
      /// </summary>
      public static string RuntimeVersion { get { return CurrentAssembly.ImageRuntimeVersion.Substring(1); } }
      /// <summary>
      /// 获取当前程序集的文件版本的字符串表达形式
      /// </summary>
      public static string FileVersion { get { return FileVersionInfo.GetVersionInfo(CurrentAssembly.Location).FileVersion; } }
      /// <summary>
      /// 获取当前程序集的产品版本的字符串表达形式
      /// </summary>
      public static string ProductionVersion { get { return FileVersionInfo.GetVersionInfo(CurrentAssembly.Location).ProductVersion; } }
      /// <summary>
      /// 获取编码与生成当前应用程序或者程序集的集成开发环境的名称
      /// </summary>
      public static string IdeName { get { return @"Microsoft Visual Studio Enterprise 2015"; } }
      /// <summary>
      /// 获取当前程序集的版权信息
      /// </summary>
      public static string Copyright { get { return ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(CurrentAssembly, typeof(AssemblyCopyrightAttribute))).Copyright; } }
      /// <summary>
      /// 获取当前应用程序所在的目录
      /// </summary>
      public static string AssemblyDirectory { get { return Environment.CurrentDirectory; } }
      /// <summary>
      /// 获取包含当前执行的代码的程序集
      /// </summary>
      private static Assembly CurrentAssembly { get { return Assembly.GetExecutingAssembly(); } }
   }
}
