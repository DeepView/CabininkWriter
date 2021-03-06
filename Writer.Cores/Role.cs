﻿using System.Diagnostics;
using System.Collections.Generic;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 用于构建角色的类
   /// </summary>
   [DebuggerDisplay("RoleFamilyName = {Name.FamilyName}, RoleLastName = {Name.LastName}")]
   public class Role : ICsvFormater
   {
      /// <summary>
      /// 角色的完整姓名
      /// </summary>
      private SCompleteName name;
      /// <summary>
      /// 角色的其他称谓或者昵称
      /// </summary>
      private List<string> appellation;
      /// <summary>
      /// 角色的性别
      /// </summary>
      private EPeopleSex sex;
      /// <summary>
      /// 角色的出场年龄或者初始年龄
      /// </summary>
      private uint initage;
      /// <summary>
      /// 角色的分类或者定位
      /// </summary>
      private ERoleCategory category;
      /// <summary>
      /// 角色的所属阵营或者国籍
      /// </summary>
      private string camp;
      /// <summary>
      /// 角色的职业或者是干什么的
      /// </summary>
      private string occupation;
      /// <summary>
      /// 角色的外貌描写
      /// </summary>
      private string appearance;
      /// <summary>
      /// 角色的性格特征
      /// </summary>
      private string character;
      /// <summary>
      /// 角色的惯用语或者口头禅
      /// </summary>
      private string petphrase;
      /// <summary>
      /// 角色的其他相关信息或者其他备注信息
      /// </summary>
      private string other;
      /// <summary>
      /// 构造函数，创建一个空的角色实例
      /// </summary>
      public Role()
      {
         name = new SCompleteName(string.Empty, string.Empty);
         appellation = new List<string>();
         sex = EPeopleSex.Male;
         initage = 0;
         category = ERoleCategory.Passerby;
         camp = string.Empty;
         occupation = string.Empty;
         appearance = string.Empty;
         character = string.Empty;
         petphrase = string.Empty;
         other = string.Empty;

      }
      /// <summary>
      /// 构造函数，创建一个只有名称的男性路人角色
      /// </summary>
      /// <param name="_name">指定的姓名。</param>
      public Role(SCompleteName _name)
      {
         name = _name;
         appellation = new List<string>();
         sex = EPeopleSex.Male;
         initage = 0;
         category = ERoleCategory.Passerby;
         camp = string.Empty;
         occupation = string.Empty;
         appearance = string.Empty;
         character = string.Empty;
         petphrase = string.Empty;
         other = string.Empty;
      }
      /// <summary>
      /// 构造函数，创建一个指定姓名、性别和初始年龄的路人角色
      /// </summary>
      /// <param name="_name">指定的姓名。</param>
      /// <param name="_sex">指定的性别。</param>
      /// <param name="_initage">指定的初始年龄。</param>
      public Role(SCompleteName _name, EPeopleSex _sex, uint _initage)
      {
         name = _name;
         appellation = new List<string>();
         sex = _sex;
         initage = _initage;
         category = ERoleCategory.Passerby;
         camp = string.Empty;
         occupation = string.Empty;
         appearance = string.Empty;
         character = string.Empty;
         petphrase = string.Empty;
         other = string.Empty;
      }
      /// <summary>
      /// 构造函数，创建一个指定姓名、性别、初始年龄和角色定位的角色
      /// </summary>
      /// <param name="_name">指定的姓名。</param>
      /// <param name="_sex">指定的性别。</param>
      /// <param name="_initage">指定的初始年龄。</param>
      /// <param name="_category">指定的角色定位。</param>
      public Role(SCompleteName _name, EPeopleSex _sex, uint _initage, ERoleCategory _category)
      {
         name = _name;
         appellation = new List<string>();
         sex = _sex;
         initage = _initage;
         category = _category;
         camp = string.Empty;
         occupation = string.Empty;
         appearance = string.Empty;
         character = string.Empty;
         petphrase = string.Empty;
         other = string.Empty;
      }
      /// <summary>
      /// 构造函数，创建一个指定姓名、别称（或者昵称）、性别、初始年龄、角色定位和所属势力的角色
      /// </summary>
      /// <param name="_name">指定的姓名。</param>
      /// <param name="_appellation">指定的别称的集合。</param>
      /// <param name="_sex">指定的性别。</param>
      /// <param name="_initage">指定的初始年龄。</param>
      /// <param name="_category">指定的角色定位。</param>
      /// <param name="_camp">指定的所属势力或者阵营。</param>
      public Role(SCompleteName _name, List<string> _appellation, EPeopleSex _sex, uint _initage, ERoleCategory _category, string _camp)
      {
         name = _name;
         appellation = _appellation;
         sex = _sex;
         initage = _initage;
         category = _category;
         camp = _camp;
         occupation = string.Empty;
         appearance = string.Empty;
         character = string.Empty;
         petphrase = string.Empty;
         other = string.Empty;
      }
      /// <summary>
      /// 构造函数，创建一个指定姓名、性别、初始年龄、角色定位、所属势力、职业、外貌描写、性格特征、口头禅（或者惯用语）和其他信息的角色
      /// </summary>
      /// <param name="_name">指定的姓名。</param>
      /// <param name="_sex">指定的性别。</param>
      /// <param name="_initage">指定的初始年龄。</param>
      /// <param name="_category">指定的角色定位。</param>
      /// <param name="_camp">指定的所属势力或者阵营。</param>
      /// <param name="_occupation">指定的角色职业。</param>
      /// <param name="_appearance">指定的角色外貌描写。</param>
      /// <param name="_character">指定的性格特征。</param>
      /// <param name="_petphrase">指定的角色惯用语或者口头禅。</param>
      /// <param name="_other">指定的其他角色信息。</param>
      public Role(SCompleteName _name, EPeopleSex _sex, uint _initage, ERoleCategory _category, string _camp, string _occupation, string _appearance, string _character, string _petphrase, string _other)
      {
         name = _name;
         appellation = new List<string>();
         sex = _sex;
         initage = _initage;
         category = _category;
         camp = _camp;
         occupation = _occupation;
         appearance = _appearance;
         character = _character;
         petphrase = _petphrase;
         other = _other;
      }
      /// <summary>
      /// 构造函数，创建一个由指定命名系统指定的姓名和性别、以及由指定的别称集合、性别、初始年龄、角色定位、所属势力、职业、外貌描写、性格特征、惯用语和其他角色信息的角色
      /// </summary>
      /// <param name="_namingsys">指定的命名系统。</param>
      /// <param name="_sex">指定的性别。</param>
      /// <param name="_appellation">指定的别称的集合。</param>
      /// <param name="_initage">指定的初始年龄。</param>
      /// <param name="_category">指定的角色定位。</param>
      /// <param name="_camp">指定的所属势力或者阵营。</param>
      /// <param name="_occupation">指定的角色职业。</param>
      /// <param name="_appearance">指定的角色外貌描写。</param>
      /// <param name="_character">指定的性格特征。</param>
      /// <param name="_petphrase">指定的角色惯用语或者口头禅。</param>
      /// <param name="_other">指定的其他角色信息。</param>
      public Role(NamingSystem _namingsys, EPeopleSex _sex, List<string> _appellation, uint _initage, ERoleCategory _category, string _camp, string _occupation, string _appearance, string _character, string _petphrase, string _other)
      {
         _namingsys.InitializeBuilder();
         name = _namingsys.RandomBuildNames(1)[0];
         appellation = _appellation;
         sex = _sex;
         initage = _initage;
         category = _category;
         camp = _camp;
         occupation = _occupation;
         appearance = _appearance;
         character = _character;
         petphrase = _petphrase;
         other = _other;
      }
      /// <summary>
      /// 构造函数，创建一个指定姓名、别称集合、性别、初始年龄、角色定位、所属势力、职业、外貌描写、性格特征、惯用语和其他角色信息的角色
      /// </summary>
      /// <param name="_name">指定的姓名。</param>
      /// <param name="_appellation">指定的别称的集合。</param>
      /// <param name="_sex">指定的性别。</param>
      /// <param name="_initage">指定的初始年龄。</param>
      /// <param name="_category">指定的角色定位。</param>
      /// <param name="_camp">指定的所属势力或者阵营。</param>
      /// <param name="_occupation">指定的角色职业。</param>
      /// <param name="_appearance">指定的角色外貌描写。</param>
      /// <param name="_character">指定的性格特征。</param>
      /// <param name="_petphrase">指定的角色惯用语或者口头禅。</param>
      /// <param name="_other">指定的其他角色信息。</param>
      public Role(SCompleteName _name, List<string> _appellation, EPeopleSex _sex, uint _initage, ERoleCategory _category, string _camp, string _occupation, string _appearance, string _character, string _petphrase, string _other)
      {
         name = _name;
         appellation = _appellation;
         sex = _sex;
         initage = _initage;
         category = _category;
         camp = _camp;
         occupation = _occupation;
         appearance = _appearance;
         character = _character;
         petphrase = _petphrase;
         other = _other;
      }
      /// <summary>
      /// 获取或设置当前实例的完整姓名
      /// </summary>
      public SCompleteName Name
      {
         get { return name; }
         set { name = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色别称或者昵称
      /// </summary>
      public List<string> Appellation
      {
         get { return appellation; }
         set { appellation = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色性别
      /// </summary>
      public EPeopleSex Sex
      {
         get { return sex; }
         set { sex = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色初始年龄或者角色出场年龄
      /// </summary>
      public uint InitializeAge
      {
         get { return initage; }
         set { initage = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色定位或者角色分类
      /// </summary>
      public ERoleCategory Category
      {
         get { return category; }
         set { category = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色所属势力或者角色的所属阵营
      /// </summary>
      public string Camp
      {
         get { return camp; }
         set { camp = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色职业或者角色是做什么的
      /// </summary>
      public string Occupation
      {
         get { return occupation; }
         set { occupation = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色外貌描写
      /// </summary>
      public string Appearance
      {
         get { return appearance; }
         set { appearance = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色性格特征
      /// </summary>
      public string Character
      {
         get { return character; }
         set { character = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的角色惯用语或者这个角色的口头禅
      /// </summary>
      public string PetPhrase
      {
         get { return petphrase; }
         set { petphrase = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的其他信息或者备注资料
      /// </summary>
      public string OtherInformation
      {
         get { return other; }
         set { other = value; }
      }
      /// <summary>
      /// 向角色别称集合里面增加一个项目
      /// </summary>
      /// <param name="_item">需要被添加到别称集合里面的项目。</param>
      /// <returns>如果操作成功，则会返回该操作结束后角色别称集合的实际元素数量。</returns>
      public int AddAppellation(string _item)
      {
         Appellation.Add(_item);
         return Appellation.Count;
      }
      /// <summary>
      /// 从角色别称集合里面移除一个指定索引的项目
      /// </summary>
      /// <param name="_index">需要被移除的项目的索引。</param>
      /// <returns>如果操作成功，则会返回该操作结束后角色别称集合的实际元素数量。</returns>
      public int RemoveAppellation(int _index)
      {
         Appellation.RemoveAt(_index);
         return Appellation.Count;
      }
      /// <summary>
      /// 获取别称集合的CSV文件格式字符串
      /// </summary>
      /// <returns>方法若执行成功，则将返回一个CSV文件格式的字符串，CSV格式文件的内容是将每一个元素通过英文逗号来分割并加以识别的。</returns>
      public string GetCsvFormatString()
      {
         string csv = string.Empty;
         for (int i = 0; i < Appellation.Count; i++) csv = Appellation[i] + ",";
         csv = csv.Substring(0, csv.Length - 1);
         return csv;
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return Name.ToString(true)+@"[Sex="+Sex.ToString()+"]";
      }
   }
   /// <summary>
   /// 角色类型枚举
   /// </summary>
   public enum ERoleCategory : int
   {
      /// <summary>
      /// 主角
      /// </summary>
      [EnumDescription("主角")]
      Protagonist = 0x0000,
      /// <summary>
      /// 配角
      /// </summary>
      [EnumDescription("配角")]
      Supporting = 0x0001,
      /// <summary>
      /// 路人
      /// </summary>
      [EnumDescription("路人")]
      Passerby = 0x0002,
      /// <summary>
      /// 反派
      /// </summary>
      [EnumDescription("反派")]
      Villain = 0x0003
   }
}
