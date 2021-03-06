﻿using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 完整姓名的结构体
   /// </summary>
   public struct SCompleteName
   {
      /// <summary>
      /// 姓氏
      /// </summary>
      public string FamilyName;
      /// <summary>
      /// 名称
      /// </summary>
      public string LastName;
      /// <summary>
      /// 显示方式
      /// </summary>
      internal bool DisplayFlag;
      /// <summary>
      /// 构造函数，创建一个非空姓名的结构体实例
      /// </summary>
      /// <param name="_fname">指定的姓氏。</param>
      /// <param name="_lname">指定的名称。</param>
      public SCompleteName(string _fname, string _lname)
      {
         FamilyName = _fname;
         LastName = _lname;
         DisplayFlag = true;
      }
      /// <summary>
      /// 比较两个姓名结构体实例是否一样
      /// </summary>
      /// <param name="_cname">需要被比较的姓名结构体。</param>
      /// <returns>如果其内容一样则返回true，否则返回false。</returns>
      public bool Equals(SCompleteName _cname)
      {
         return (_cname.FamilyName == FamilyName) && (_cname.LastName == LastName);
      }
      /// <summary>
      /// 返回该结构体的String表达形式
      /// </summary>
      /// <param name="_isfmlinfst">决定名称该怎么显示，如果该参数为true，则名称显示方式为姓氏优先，否则就是名称优先。</param>
      /// <returns>该操作返回的是当前实例的字符串表达形式，即一个String实例。</returns>
      public string ToString(bool _isfmlinfst)
      {
         if (SetDisplayMode(ref _isfmlinfst)) return FamilyName + " " + LastName; else return LastName + " " + FamilyName;
      }
      /// <summary>
      /// 设置显示名称的方式，如果参数为true，则姓氏显示在名称前面，否则，姓氏则显示在名称后面
      /// </summary>
      /// <param name="_isfmlinfst">决定名称该怎么显示，如果该参数为true，则名称显示方式为姓氏优先，否则就是名称优先。</param>
      /// <returns>该操作返回一个bool值，这个值决定了名称的显示方式。</returns>
      public bool SetDisplayMode(ref bool _isfmlinfst)
      {
         DisplayFlag = _isfmlinfst;
         return DisplayFlag;
      }
      /// <summary>
      /// 获取当前实例的所包含姓名的显示样式
      /// </summary>
   }
   /// <summary>
   /// 命名系统类
   /// </summary>
   public class NamingSystem
   {
      /// <summary>
      /// 名称国籍
      /// </summary>
      private ENameType nametype;
      /// <summary>
      /// 用于临时存储的姓氏列表
      /// </summary>
      private List<string> t_family_n;
      /// <summary>
      /// 用于临时存储的名称列表
      /// </summary>
      private List<string> t_last_n;
      /// <summary>
      /// 姓名的显示样式
      /// </summary>
      private bool displaystyle = true;
      /// <summary>
      /// 构造函数，初始化一个男性的中国人名称，且临时存储列表设置为空
      /// </summary>
      public NamingSystem()
      {
         //sex = EPeopleSex.Male;
         nametype = ENameType.ChineseName;
         t_family_n = new List<string>();
         t_last_n = new List<string>();
      }
      /// <summary>
      /// 构造函数，初始化一个指定性别和国籍的姓名，且临时存储列表设置为空
      /// </summary>
      /// <param name="_nmtp">指定的国籍。</param>
      public NamingSystem(ENameType _nmtp)
      {
         nametype = _nmtp;
         t_family_n = new List<string>();
         t_last_n = new List<string>();
      }
      /// <summary>
      /// 初始化命名系统的姓名生成器
      /// </summary>
      public void InitializeBuilder()
      {
         string t_family, t_last;
         Encoding ecd = Encoding.GetEncoding("GB2312");
         List<string> tf_list = new List<string>(), tl_list = new List<string>();
         switch (NameType)
         {
            case ENameType.ChineseName:
               t_family = FileOperation.ReadFile(@"namesystem\cn_family.csv", true, ecd);
               t_last = FileOperation.ReadFile(@"namesystem\cn_name.csv", true, ecd);
               break;
            case ENameType.EuramericanName:
               t_family = FileOperation.ReadFile(@"namesystem\en_family.csv", true, ecd);
               t_last = FileOperation.ReadFile(@"namesystem\en_name.csv", true, ecd);
               break;
            case ENameType.JapaneseName:
               t_family = FileOperation.ReadFile(@"namesystem\jp_family.csv", true, ecd);
               t_last = FileOperation.ReadFile(@"namesystem\jp_name.csv", true, ecd);
               break;
            case ENameType.RussianName:
               t_family = FileOperation.ReadFile(@"namesystem\ru_family.csv", true, ecd);
               t_last = FileOperation.ReadFile(@"namesystem\ru_name.csv", true, ecd);
               break;
            case ENameType.SpaniardName:
               t_family = FileOperation.ReadFile(@"namesystem\sp_family.csv", true, ecd);
               t_last = FileOperation.ReadFile(@"namesystem\sp_name.csv", true, ecd);
               break;
            case ENameType.ArabName:
               t_family = FileOperation.ReadFile(@"namesystem\ar_family.csv", true, ecd);
               t_last = FileOperation.ReadFile(@"namesystem\ar_name.csv", true, ecd);
               break;
            case ENameType.KoreanName:
               t_family = FileOperation.ReadFile(@"namesystem\kr_family.csv", true, ecd);
               t_last = FileOperation.ReadFile(@"namesystem\kr_name.csv", true, ecd);
               break;
            default:
               t_family = FileOperation.ReadFile(@"namesystem\cn_family.csv", true, ecd);
               t_last = FileOperation.ReadFile(@"namesystem\cn_name.csv", true, ecd);
               break;
         }
         t_family_n = t_family.Split(',').ToList();
         t_last_n = t_last.Split(',').ToList();
         t_family_n.Sort();
         t_last_n.Sort();
      }
      /// <summary>
      /// 设置姓名的显示样式
      /// </summary>
      /// <param name="_style">一个Boolean参数，用于决定姓名是姓氏显示在前还是名称显示在前。</param>
      public void SetDisplayStyle(ref bool _style)
      {
         displaystyle = _style;
      }
      /// <summary>
      /// 根据指定的数量来随机生成姓名
      /// </summary>
      /// <param name="_maxbuild">最大的生成数量。</param>
      /// <param name="_isfmlinfst">决定名称该怎么显示，如果该参数为true，则名称显示方式为姓氏优先，否则就是名称优先。</param>
      /// <returns>该操作会返回一个随机生成的姓名列表，如果最大生成数量超过了备选名称的数量，则此操作会抛出异常。</returns>
      public List<SCompleteName> RandomBuildNames(int _maxbuild)
      {
         List<SCompleteName> names = new List<SCompleteName>();
         List<string> tf = new List<string>(), tl = new List<string>();
         Random rnd = new Random();
         SCompleteName build;
         if (_maxbuild > t_last_n.Count) throw new ArgumentOutOfRangeException("最大生成数量超过了备选名称数量！");
         for (int i = 0; i < _maxbuild; i++)
         {
            build = new SCompleteName(t_family_n[rnd.Next(0, t_family_n.Count - 1)], t_last_n[rnd.Next(0, t_last_n.Count - 1)]);
            build.SetDisplayMode(ref displaystyle);
            names.Add(build);
         }
         return names;
      }
      /// <summary>
      /// 获取或设置国籍
      /// </summary>
      public ENameType NameType
      {
         get { return nametype; }
         set { nametype = value; }
      }
   }
   /// <summary>
   /// 性别枚举
   /// </summary>
   public enum EPeopleSex : int
   {
      /// <summary>
      /// 男性或者男人
      /// </summary>
      [EnumDescription("男")]
      Male = 0x0000,
      /// <summary>
      /// 女性或者女人
      /// </summary>
      [EnumDescription("女")]
      Famale = 0x0001,
      /// <summary>
      /// 无性或者双性
      /// </summary>
      [EnumDescription("无性或双性")]
      Asexual = 0x0002
   }
   /// <summary>
   /// 名称所属国家
   /// </summary>
   public enum ENameType : ulong
   {
      /// <summary>
      /// 中国人名称
      /// </summary>
      ChineseName = 0x00000000f,
      /// <summary>
      /// 欧美人名称
      /// </summary>
      EuramericanName = 0x0000000ff,
      /// <summary>
      /// 日本人名称
      /// </summary>
      JapaneseName = 0x000000fff,
      /// <summary>
      /// 俄罗斯人名称
      /// </summary>
      RussianName = 0x00000ffff,
      /// <summary>
      /// 西班牙人名称
      /// </summary>
      SpaniardName = 0x0000fffff,
      /// <summary>
      /// 阿拉伯人名称
      /// </summary>
      ArabName = 0x000ffffff,
      /// <summary>
      /// 朝鲜和韩国人名称
      /// </summary>
      KoreanName = 0x00fffffff
   }
}
