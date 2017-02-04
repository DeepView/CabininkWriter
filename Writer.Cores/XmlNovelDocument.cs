using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cabinink.Writer.Middle;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 主体部分XML存取类
   /// </summary>
   public class XmlNovelDocument
   {
      /// <summary>
      /// 需要存取的Novel实例
      /// </summary>
      private Project project;
      /// <summary>
      /// XML文档的文件地址
      /// </summary>
      private string documenturl;
      /// <summary>
      /// XML文档操作类
      /// </summary>
      private XmlDocument document;
      /// <summary>
      /// 构造函数，创建一个空XML文档的作品主体XML存取类
      /// </summary>
      /// <param name="_proj">用来存储和其他操作的Novel实例。</param>
      public XmlNovelDocument(Project _proj)
      {
         project = _proj;
         documenturl = string.Empty;
         document = new XmlDocument();
      }
      /// <summary>
      /// 构造函数，创建一个非空路径的作品主体XML存取类
      /// </summary>
      /// <param name="_proj">用来存储和其他操作的Project实例。</param>
      /// <param name="_docurl">用于存取作品主体的XML文档。</param>
      public XmlNovelDocument(Project _proj, string _docurl)
      {
         project = _proj;
         documenturl = _docurl;
         document = new XmlDocument();
      }
      /// <summary>
      /// 构造函数，创建一个指定XML文档和指定XML文件路径的作品主体XML存取类
      /// </summary>
      /// <param name="_proj">用来存储和其他操作的Project实例。</param>
      /// <param name="_docurl">用于存取作品主体的XML文档。</param>
      /// <param name="_xmldoc">用于将数据暂时存储于内存中进行操作的XML文档实例。</param>
      public XmlNovelDocument(Project _proj, string _docurl, XmlDocument _xmldoc)
      {
         project = _proj;
         documenturl = _docurl;
         document = _xmldoc;
      }
      /// <summary>
      /// 获取或设置当前实例的作品项目
      /// </summary>
      public Project CurrentProject
      {
         get { return project; }
         internal set { project = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的文档路径
      /// </summary>
      public string DocumentUrl
      {
         get { return documenturl; }
         internal set { documenturl = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的XML文档实例
      /// </summary>
      public XmlDocument Document
      {
         get { return document; }
         internal set { document = value; }
      }
      /// <summary>
      /// 根据已经设定的XML文件地址将该文件内容加载到XML文档实例中，如果文件地址无效则将会抛出一个NotFoundFileException异常
      /// </summary>
      public void LoadDocument()
      {
         if (!FileOperation.FileExists(DocumentUrl)) throw new NotFoundFileException("指定的XML文件不存在！");
         Document.PreserveWhitespace = true;
         Document.Load(@documenturl);
      }
      /// <summary>
      /// 将已经设定的XML文件通过流式文件读取方式读取到内存中，然后再加载到XML实例文档中，如果文件地址无效则将会抛出一个NotFoundFileException异常
      /// </summary>
      public void LoadDocumentFromXmlString()
      {
         LoadDocumentFromXmlString(DocumentUrl, Encoding.GetEncoding("GB2312"));
      }
      /// <summary>
      /// 将已经设定的XML文件通过流式文件读取方式按照指定的编码格式读取到内存中，然后再加载到XML实例文档中，如果文件地址无效则将会抛出一个NotFoundFileException异常
      /// </summary>
      /// <param name="_encoding">指定的编码格式。</param>
      public void LoadDocumentFromXmlString(Encoding _encoding)
      {
         LoadDocumentFromXmlString(DocumentUrl, _encoding);
      }
      /// <summary>
      /// 通过指定的XML文件将其利用流式文件读取方式读取到内存中，然后再加载到XML实例文档中，如果文件地址无效则将会抛出一个NotFoundFileException异常
      /// </summary>
      /// <param name="_docurl">指定的XML文件地址。</param>
      /// <param name="_encoding">指定的编码格式。</param>
      public void LoadDocumentFromXmlString(string _docurl, Encoding _encoding)
      {
         DocumentUrl = _docurl;
         Document.PreserveWhitespace = true;
         Document.LoadXml(FileOperation.ReadFile(_docurl, true, _encoding));
      }
      /// <summary>
      /// 根据现有作品项目创建一个只有根节点的XML文档
      /// </summary>
      /// <param name="_savedurl">XML文档的存储路径。</param>
      public void CreateXmlDocument(string _savedurl)
      {
         CreateXmlDocument(_savedurl, "1.0", "GB2312", "no");
      }
      /// <summary>
      /// 根据现有作品项目创建一个制定编码格式，且只有根节点的XML文档
      /// </summary>
      /// <param name="_savedurl">XML文档的存储路径。</param>
      /// <param name="_encoding">编码属性的值，这是当将XmlDocument保存到文件或流时使用的编码方式，因此必须将其设置为Encoding类支持的字符串，否则Save方法将会失败，如果这是null或 String.Empty，则Save方法不在XML声明上写出编码方式特性，因此将使用默认的编码方式UTF-8，另外如果将XmlDocument保存到TextWriter 或XmlTextWriter，则放弃该编码值，而改用TextWriter或XmlTextWriter的编码方式，这会确保可以使用正确的编码读回写出的XML。</param>
      public void CreateXmlDocument(string _savedurl, string _encoding)
      {
         CreateXmlDocument(_savedurl, "1.0", _encoding, "no");
      }
      /// <summary>
      /// 通过指定的XML文档版本、编码属性和独立特性来根据现有作品项目创建一个只有根节点的XML文档
      /// </summary>
      /// <param name="_savedurl">XML文档的存储路径。</param>
      /// <param name="_version">指定的XML文档版本，该字符串的值必须为“1.0”。</param>
      /// <param name="_encoding">编码属性的值，这是当将XmlDocument保存到文件或流时使用的编码方式，因此必须将其设置为Encoding类支持的字符串，否则Save方法将会失败，如果这是null或 String.Empty，则Save方法不在XML声明上写出编码方式特性，因此将使用默认的编码方式UTF-8，另外如果将XmlDocument保存到TextWriter 或XmlTextWriter，则放弃该编码值，而改用TextWriter或XmlTextWriter的编码方式，这会确保可以使用正确的编码读回写出的XML。</param>
      /// <param name="_standalone">指定的独立特性，该值必须是“yes”或“no”，如果这是null或String.Empty，Save方法不在XML声明上写出独立特性。</param>
      public void CreateXmlDocument(string _savedurl, string _version, string _encoding, string _standalone)
      {
         Document.AppendChild(Document.CreateXmlDeclaration(_version, _encoding, _standalone));
         XmlElement root = Document.CreateElement("novel");
         root.SetAttribute("dburl", @CurrentProject.Database.SourceUri);
         Document.AppendChild(root);
         Document.Save(_savedurl);
      }
      /// <summary>
      /// 将作品项目中的所有分卷信息存储到XML文档中，但不会存储这些分卷包含的章节集合
      /// </summary>
      /// <param name="_exceptional">指示该操作的Subsection属性值获取的过程是否抛出异常。</param>
      /// <param name="_exception_info">如果_exceptional为true，则该字符串包含了这个异常的详细信息。</param>
      public void WriteAllSubsections(ref bool _exceptional, ref string _exception_info)
      {
         XmlNode root = Document.GetElementsByTagName("novel")[0];
         Subsection subsection;
         bool is_exceptional = false;
         string title = string.Empty, serial = string.Empty, excepinfo = string.Empty;
         for (int i = 0; i < CurrentProject.CurrentNovel.Count; i++)
         {
            try
            {
               subsection = CurrentProject.CurrentNovel[i];
               AppendSubsection(subsection, ref excepinfo);
            }
            catch
            {
               is_exceptional = true;
               break;
            }
         }
         _exceptional = is_exceptional;
         _exception_info = excepinfo;
      }
      /// <summary>
      /// 将指定的分卷信息存储到XML文档中，但不会存储该分卷包含的章节集合
      /// </summary>
      /// <param name="_subsection">分卷实例，被用来提取分卷信息并存储。</param>
      /// <param name="_exception_info">获取该操作的Subsection属性值获取的过程已抛出异常的异常信息。</param>
      public void AppendSubsection(Subsection _subsection, ref string _exception_info)
      {
         XmlNode root = Document.GetElementsByTagName("novel")[0];
         XmlElement element;
         long ctime = 0, btime = 0;
         string title = string.Empty, serial = string.Empty, excepinfo = string.Empty;
         try
         {
            int sn_mode = (int)_subsection.SubsectionNumber.SubsectionNumberMode;
            if (sn_mode < 2) serial = ChineseNumber.ConvertToArab(_subsection.SubsectionNumber.SubsectionNumber);
            else serial = _subsection.SubsectionNumber.SubsectionNumber;
            ctime = _subsection.CreationTime.Ticks;
            btime = _subsection.BreakupTime.Ticks;
            title = _subsection.Title;
         }
         catch (Exception ex)
         {
            excepinfo = ex.Message + "\n\n" + ex.StackTrace;
         }
         element = Document.CreateElement("subsection");
         element.SetAttribute("serial", serial);
         element.SetAttribute("name", title);
         element.SetAttribute("creation_time", Convert.ToString(ctime));
         element.SetAttribute("breakup_time", Convert.ToString(btime));
         root.AppendChild(element);
         Document.Save(DocumentUrl);
         _exception_info = excepinfo;
      }
      /// <summary>
      /// 将一个分卷的所有章节的对应信息存储到已经指定的XML文档中，但不包含章节的主体内容
      /// </summary>
      /// <param name="_subsection">存储的目标分卷。</param>
      /// <param name="_exceptional">指示该操作的Subsection属性值获取的过程是否抛出异常。</param>
      /// <param name="_exception_info">获取该操作的Subsection属性值获取的过程已抛出异常的异常信息。</param>
      public void WriteChaptersFromSubsection(Subsection _subsection, ref bool _exceptional, ref string _exception_info)
      {
         string serial = string.Empty, title = string.Empty;
         int sn_mode = (int)_subsection.SubsectionNumber.SubsectionNumberMode;
         if (sn_mode < 2) serial = ChineseNumber.ConvertToArab(_subsection.SubsectionNumber.SubsectionNumber);
         else serial = _subsection.SubsectionNumber.SubsectionNumber;
         XmlNode sstnode = Document.GetElementsByTagName("subsection")[Convert.ToInt32(serial)];
         for (int i = 0; i < _subsection.Count; i++)
         {
            try
            {
               AppendChapter(_subsection, _subsection[i], ref _exception_info);
            }
            catch
            {
               _exceptional = true;
               break;
            }
         }
      }
      /// <summary>
      /// 把一个指定的分卷的对应信息存储到指定的分卷节点之中，但不包含章节的主体内容
      /// </summary>
      /// <param name="_subsection">存储的目标分卷。</param>
      /// <param name="_chapter">需要被存储其对应信息的章节。</param>
      /// <param name="_exception_info">获取该操作的Subsection属性值获取的过程已抛出异常的异常信息。</param>
      public void AppendChapter(Subsection _subsection, Chapter _chapter, ref string _exception_info)
      {
         XmlElement element;
         string serial = string.Empty, title = string.Empty;
         long ctime = 0, btime = 0;
         int cn_mode = 0, sn_mode = (int)_subsection.SubsectionNumber.SubsectionNumberMode;
         if (sn_mode < 2) serial = ChineseNumber.ConvertToArab(_subsection.SubsectionNumber.SubsectionNumber);
         else serial = _subsection.SubsectionNumber.SubsectionNumber;
         XmlNode sstnode = Document.GetElementsByTagName("subsection")[Convert.ToInt32(serial)];
         try
         {
            cn_mode = (int)_chapter.ChapterNumber.ChapterNumberMode;
            if (cn_mode >= 6) serial = ChineseNumber.ConvertToArab(_chapter.ChapterNumber.ChapterNumber);
            else serial = _chapter.ChapterNumber.ChapterNumber;
            ctime = _chapter.CreationTime.Ticks;
            btime = _chapter.BreakupTime.Ticks;
            title = _chapter.Title;
         }
         catch (Exception ex)
         {
            _exception_info = ex.Message + "\n\n" + ex.StackTrace;
         }
         element = Document.CreateElement("chapter");
         element.SetAttribute("serial", serial);
         element.SetAttribute("name", title);
         element.SetAttribute("creation_time", Convert.ToString(ctime));
         element.SetAttribute("breakup_time", Convert.ToString(btime));
         sstnode.AppendChild(element);
         Document.Save(DocumentUrl);
      }
      /// <summary>
      /// 移除所有的分卷节点，相应的其分卷下的所有章节也将会被移除
      /// </summary>
      public void RemoveAllSubsections()
      {
         XmlElement root = (XmlElement)Document.SelectSingleNode("novel");
         root.RemoveAll();
      }
      /// <summary>
      /// 移除指定的分卷节点，相应的，其这个分卷节点下的所有章节也会被移除
      /// </summary>
      /// <param name="_element">需要被移除的分卷节点。</param>
      public void RemoveSubsection(XmlElement _element)
      {
         XmlElement root = (XmlElement)Document.SelectSingleNode("novel");
         XmlNode will_removed;
         XmlNodeList nodes = root.ChildNodes;
         Parallel.ForEach(CurrentProject.CurrentNovel.Subsections, (subsection, interrupt) =>
         {
            string serial_n = string.Empty;
            int sn_mode = (int)subsection.SubsectionNumber.SubsectionNumberMode;
            if (sn_mode < 2) serial_n = ChineseNumber.ConvertToArab(subsection.SubsectionNumber.SubsectionNumber);
            else serial_n = subsection.SubsectionNumber.SubsectionNumber;
            if (serial_n == _element.GetAttribute("serial"))
            {
               will_removed = root.GetAttributeNode("serial", serial_n);
               root.RemoveChild(_element);
               interrupt.Stop();
            }
         });
      }
      /// <summary>
      /// 更新指定的分卷节点
      /// </summary>
      /// <param name="_serial">需要被更新的分卷节点序列，这个序列主要用于检索匹配节点，从而来更新符合条件的节点，另外这个节点序列是阿拉伯数字的字符串形式。</param>
      /// <param name="_update_source">用于更新分卷节点的源分卷实例。</param>
      public void UpdateSubsection(string _serial, Subsection _update_source)
      {

      }
   }
}
