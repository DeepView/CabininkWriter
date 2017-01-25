using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 数据表字段默认值规则结构
   /// </summary>
   public struct SFieldDefaultRule
   {
      /// <summary>
      /// 指示一个字段是否拥有默认值，如果有默认值，则DefaultValue字段有效
      /// </summary>
      public bool HasDefault;
      /// <summary>
      /// 指定字段的默认值，如果HasDefault值为false，则该字段无效
      /// </summary>
      public string DefaultValue;
      /// <summary>
      /// 构造函数，创建一个指定默认值指示和默认值内容的SFieldDefaultRule结构实例
      /// </summary>
      /// <param name="_hasdef">指定的字段默认值指示。</param>
      /// <param name="_defval">指定的字段默认值内容，若_hasdef参数值为false，则该参数无效。</param>
      public SFieldDefaultRule(bool _hasdef, string _defval)
      {
         if (!_hasdef)
         {
            HasDefault = _hasdef;
            DefaultValue = _defval;
         }
         else
         {
            HasDefault = false;
            DefaultValue = string.Empty;
         }
      }
   }
   /// <summary>
   /// 数据表结构成员透视类
   /// </summary>
   public class DbTableFieldStructure
   {
      /// <summary>
      /// 字段名称
      /// </summary>
      private string field_name;
      /// <summary>
      /// 字段的数据类型
      /// </summary>
      private string field_datatype;
      /// <summary>
      /// 字段的数据条件
      /// </summary>
      private string field_condition;
      /// <summary>
      /// 字段的排序规则
      /// </summary>
      private string field_sortrule;
      /// <summary>
      /// 是否允许字段为空
      /// </summary>
      private bool field_isnull;
      /// <summary>
      /// 该字段是否为主键
      /// </summary>
      private bool field_isprimary;
      /// <summary>
      /// 该字段是否满足唯一性条件
      /// </summary>
      private bool field_isonlyone;
      /// <summary>
      /// 该字段是否为外键
      /// </summary>
      private bool field_isforeign;
      /// <summary>
      /// 字段的默认值规则
      /// </summary>
      private SFieldDefaultRule field_defrule;
      /// <summary>
      /// 构造函数，创建一个指定字段名称和字段类型的实例
      /// </summary>
      /// <param name="_name">指定的字段名称。</param>
      /// <param name="_category">指定的字段数据类型。</param>
      public DbTableFieldStructure(string _name, string _category)
      {
         if (string.IsNullOrEmpty(_name) || string.IsNullOrWhiteSpace(_name))
         {
            throw new FieldNameIsEmptyOrNullException("字段名称不能为空！");
         }
         field_name = _name;
         field_datatype = _category;
         field_condition = string.Empty;
         field_sortrule = string.Empty;
         field_isnull = false;
         field_isprimary = false;
         field_isonlyone = false;
         field_isforeign = false;
         field_defrule = new SFieldDefaultRule(false, string.Empty);
      }
      /// <summary>
      /// 构造函数，创建一个指定字段名称、数据类型、空字段指示、主键指示和外键指示的实例
      /// </summary>
      /// <param name="_name">指定的字段名称。</param>
      /// <param name="_category">指定的字段数据类型。</param>
      /// <param name="_isnull">指示该字段是否允许空值存在。</param>
      /// <param name="_ispri">指示该字段是否为主键。</param>
      /// <param name="_isfrg">指示该字段是否是外键。</param>
      public DbTableFieldStructure(string _name, string _category, bool _isnull, bool _ispri, bool _isfrg)
      {
         if (string.IsNullOrEmpty(_name) || string.IsNullOrWhiteSpace(_name))
         {
            throw new FieldNameIsEmptyOrNullException("字段名称不能为空！");
         }
         field_name = _name;
         field_datatype = _category;
         field_condition = string.Empty;
         field_sortrule = string.Empty;
         field_isnull = _isnull;
         field_isprimary = _ispri;
         field_isonlyone = false;
         field_isforeign = _isfrg;
         field_defrule = new SFieldDefaultRule(false, string.Empty);
      }
      /// <summary>
      /// 构造函数，创建一个指定字段名称、数据类型、空字段指示、主键指示、外键指示和默认值规则的实例
      /// </summary>
      /// <param name="_name">指定的字段名称。</param>
      /// <param name="_category">指定的字段数据类型。</param>
      /// <param name="_isnull">指示该字段是否允许空值存在。</param>
      /// <param name="_ispri">指示该字段是否为主键。</param>
      /// <param name="_isfrg">指示该字段是否是外键。</param>
      /// <param name="_defrule">指定的字段默认值规则结构实例。</param>
      public DbTableFieldStructure(string _name, string _category, bool _isnull, bool _ispri, bool _isfrg, SFieldDefaultRule _defrule)
      {
         if (string.IsNullOrEmpty(_name) || string.IsNullOrWhiteSpace(_name))
         {
            throw new FieldNameIsEmptyOrNullException("字段名称不能为空！");
         }
         field_name = _name;
         field_datatype = _category;
         field_condition = string.Empty;
         field_sortrule = string.Empty;
         field_isnull = _isnull;
         field_isprimary = _ispri;
         field_isonlyone = false;
         field_isforeign = _isfrg;
         field_defrule = _defrule;
      }
      /// <summary>
      /// 构造函数，创建一个指定字段名称、数据类型、字段约束条件、排序规则、空字段指示、主键指示、唯一性条件指示、外键指示和默认值规则的实例
      /// </summary>
      /// <param name="_name">指定的字段名称。</param>
      /// <param name="_category">指定的字段数据类型。</param>
      /// <param name="_condition">指定的字段约束条件。</param>
      /// <param name="_sortrule">指定的字段排序规则。</param>
      /// <param name="_isnull">指示该字段是否允许空值存在。</param>
      /// <param name="_ispri">指示该字段是否为主键。</param>
      /// <param name="_isonlyone">指示该字段是否满足唯一性条件。</param>
      /// <param name="_isfrg">指示该字段是否是外键。</param>
      /// <param name="_defrule">指定的字段默认值规则结构实例。</param>
      public DbTableFieldStructure(string _name, string _category, string _condition, string _sortrule, bool _isnull, bool _ispri, bool _isonlyone, bool _isfrg, SFieldDefaultRule _defrule)
      {
         if (string.IsNullOrEmpty(_name) || string.IsNullOrWhiteSpace(_name))
         {
            throw new FieldNameIsEmptyOrNullException("字段名称不能为空！");
         }
         field_name = _name;
         field_datatype = _category;
         field_condition = _condition;
         field_sortrule = _sortrule;
         field_isnull = _isnull;
         field_isprimary = _ispri;
         field_isonlyone = _isonlyone;
         field_isforeign = _isfrg;
         field_defrule = _defrule;
      }
      /// <summary>
      /// 
      /// </summary>
      public string Name
      {
         get { return field_name; }
         set
         {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
               throw new FieldNameIsEmptyOrNullException("字段名称不能为空！");
            }
            field_name = value;
         }
      }
      public string DataType
      {
         get { return field_datatype; }
         set { field_datatype = value; }
      }
      public string Condition
      {
         get { return field_condition; }
         set { field_condition = value; }
      }
      public string SortRule
      {
         get { return field_sortrule; }
         set { field_sortrule = value; }
      }
      public bool IsNull
      {
         get { return field_isnull; }
         set { field_isnull = value; }
      }
      public bool IsPrimary
      {
         get { return field_isprimary; }
         set { field_isprimary = value; }
      }
      public bool IsOnlyOne
      {
         get { return field_isonlyone; }
         set { field_isonlyone = value; }
      }
      public bool IsForeign
      {
         get { return field_isforeign; }
         set { field_isforeign = value; }
      }
      public SFieldDefaultRule DefaultRule
      {
         get { return field_defrule; }
         set { field_defrule = value; }
      }
   }
   /// <summary>
   /// 当字段名称为空的时候引发的异常
   /// </summary>
   [Serializable]
   public class FieldNameIsEmptyOrNullException : Exception
   {
      public FieldNameIsEmptyOrNullException() { }
      public FieldNameIsEmptyOrNullException(string message) : base(message) { }
      public FieldNameIsEmptyOrNullException(string message, Exception inner) : base(message, inner) { }
      protected FieldNameIsEmptyOrNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
