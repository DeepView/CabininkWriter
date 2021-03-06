﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mime;
using System.Net.Mail;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 发送邮件密封类
   /// </summary>
   public class MailSender
   {
      /// <summary>
      /// 主要处理发送邮件的内容（如：收发人地址、标题、主体、图片等等）
      /// </summary>
      private MailMessage mailmsg;
      /// <summary>
      /// 主要处理用smtp方式发送此邮件的配置信息（如：邮件服务器、发送端口号、验证方式等等）
      /// </summary>
      private SmtpClient smtpclient;
      /// <summary>
      /// 发送邮件所用的端口号（htmp协议默认为25）
      /// </summary>
      private int port;
      /// <summary>
      /// 发件箱的邮件服务器地址（IP形式或字符串形式均可）
      /// </summary>
      private string server;
      /// <summary>
      /// 发件箱的密码
      /// </summary>
      private string senderpasswd;
      /// <summary>
      /// 发件箱的用户名（即@符号前面的字符串，例如：hello@163.com，用户名为：hello）
      /// </summary>
      private string senderusr;
      /// <summary>
      /// 是否对邮件内容进行socket层加密传输
      /// </summary>
      private bool enablessl;
      /// <summary>
      /// 是否对发件人邮箱进行密码验证
      /// </summary>
      private bool authentication;
      ///<summary>
      /// 构造函数
      ///</summary>
      ///<param name="_server">发件箱的邮件服务器地址。</param>
      ///<param name="_to">收件人地址（可以是多个收件人，程序中是以“;"进行区分的）。</param>
      ///<param name="_from">发件人地址。</param>
      ///<param name="_subject">邮件标题。</param>
      ///<param name="_body">邮件内容（可以以html格式进行设计）。</param>
      ///<param name="_username">发件箱的用户名（即@符号前面的字符串，例如：hello@163.com，用户名为：hello）。</param>
      ///<param name="_password">发件人邮箱密码。</param>
      ///<param name="_port">发送邮件所用的端口号（stmp协议默认为25）。</param>
      ///<param name="_ssl">true表示对邮件内容进行socket层加密传输，false表示不加密。</param>
      ///<param name="_pswchecked">true表示对发件人邮箱进行密码验证，false表示不对发件人邮箱进行密码验证。</param>
      public MailSender(string _server, string _to, string _from, string _subject, string _body, string _username, string _password, string _port, bool _ssl, bool _pswchecked)
      {
         try
         {
            mailmsg = new MailMessage();
            mailmsg.To.Add(_to);
            mailmsg.From = new MailAddress(_from);
            mailmsg.Subject = _subject;
            mailmsg.Body = _body;
            mailmsg.IsBodyHtml = true;
            mailmsg.BodyEncoding = Encoding.UTF8;
            mailmsg.Priority = MailPriority.Normal;
            server = _server;
            senderusr = _username;
            senderpasswd = _password;
            port = Convert.ToInt32(_port);
            enablessl = _ssl;
            authentication = _pswchecked;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.ToString());
         }
      }
      ///<summary>
      /// 添加附件
      ///</summary>
      ///<param name="_attachments">附件的路径集合，以分号分隔。</param>
      public void AddAttachments(string _attachments)
      {
         try
         {
            string[] path = _attachments.Split(';');
            Attachment data;
            ContentDisposition disposition;
            for (int i = 0; i < path.Length; i++)
            {
               data = new Attachment(path[i], MediaTypeNames.Application.Octet);
               disposition = data.ContentDisposition;
               disposition.CreationDate = File.GetCreationTime(path[i]);
               disposition.ModificationDate = File.GetLastWriteTime(path[i]);
               disposition.ReadDate = File.GetLastAccessTime(path[i]);
               mailmsg.Attachments.Add(data);
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.ToString());
         }
      }
      ///<summary>
      /// 发送一封邮件
      ///</summary>
      public void Send()
      {
         try
         {
            if (mailmsg != null)
            {
               smtpclient = new SmtpClient();
               smtpclient.Host = server;
               smtpclient.Port = port;
               smtpclient.UseDefaultCredentials = false;
               smtpclient.EnableSsl = enablessl;
               if (authentication)
               {
                  NetworkCredential nc = new NetworkCredential(senderusr, senderpasswd);
                  smtpclient.Credentials = nc.GetCredential(smtpclient.Host, smtpclient.Port, "NTLM");
               }
               else
               {
                  smtpclient.Credentials = new NetworkCredential(senderusr, senderpasswd);
               }
               smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
               smtpclient.Send(mailmsg);
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine("\n\nMail Exception\n" + ex.Message + "\n" + ex.StackTrace + "\n\n");
            throw new CannotSendMailException("电子邮件发送失败！");
         }
      }
      /// <summary>
      /// 发送一封邮件
      /// </summary>
      /// <param name="_server">服务器地址。</param>
      /// <param name="_sender">邮件寄件人的地址。</param>
      /// <param name="_recipient">邮件收件人的地址</param>
      /// <param name="_subject">邮件主题。</param>
      /// <param name="_body">邮件正文，即主体部分。</param>
      /// <param name="_isbodyhtml">邮件正文是否为Html格式。</param>
      /// <param name="_encoding">邮件正文编码格式。</param>
      /// <param name="_authenticated">邮件的认证标记。</param>
      /// <param name="_files">邮件的附加文件。</param>
      [Obsolete("It maybe throwed exceptions.")]
      public static void Send(string _server, string _sender, string _recipient, string _subject, string _body, bool _isbodyhtml, Encoding _encoding, bool _authenticated, params string[] _files)
      {
         SmtpClient smtpClient = new SmtpClient(_server);
         MailMessage message = new MailMessage(_sender, _recipient);
         message.IsBodyHtml = _isbodyhtml;
         message.SubjectEncoding = _encoding;
         message.BodyEncoding = _encoding;
         message.Subject = _subject;
         message.Body = _body;
         message.Attachments.Clear();
         if (_files != null && _files.Length != 0)
         {
            for (int i = 0; i < _files.Length; ++i)
            {
               Attachment attach = new Attachment(_files[i]);
               message.Attachments.Add(attach);
            }
         }
         if (_authenticated == true)
         {
            smtpClient.Credentials = new NetworkCredential(SmtpConfigure.Create().SmtpInformation.User,
                SmtpConfigure.Create().SmtpInformation.Password);
         }
         smtpClient.Send(message);
      }
      /// <summary>
      /// 发送一封邮件
      /// </summary>
      /// <param name="_recipient">邮件收件人的地址</param>
      /// <param name="_subject">邮件主题。</param>
      /// <param name="_body">邮件正文，即主体部分。</param>
      [Obsolete("It maybe throwed exceptions.")]
      public static void Send(string _recipient, string _subject, string _body)
      {
         Send(SmtpConfigure.Create().SmtpInformation.Server,
            SmtpConfigure.Create().SmtpInformation.Sender,
            _recipient, _subject, _body, true, Encoding.Default, true, null);
      }
      /// <summary>
      /// 发送一封邮件
      /// </summary>
      /// <param name="_recipient">邮件收件人的地址</param>
      /// <param name="_sender">邮件寄件人的地址。</param>
      /// <param name="_subject">邮件主题。</param>
      /// <param name="_body">邮件正文，即主体部分。</param>
      [Obsolete("It maybe throwed exceptions.")]
      public static void Send(string _recipient, string _sender, string _subject, string _body)
      {
         Send(SmtpConfigure.Create().SmtpInformation.Server,
            _sender, _recipient, _subject, _body, true, Encoding.UTF8, true, null);
      }
      /// <summary>
      /// 发送一封邮件
      /// </summary>
      /// <param name="_subject">邮件主题。</param>
      /// <param name="_body">邮件正文，即主体部分。</param>
      /// <param name="_sender">邮件寄件人的地址。</param>
      /// <param name="_addrs">邮件地址列表。</param>
      /// <param name="_host">主机地址。</param>
      /// <returns>如果发送邮件失败则返回false，否则返回true。</returns>
      [Obsolete("It maybe throwed exceptions.")]
      public static bool Send(string _subjct, string _body, string _sender, List<string> _addrs, string _host)
      {
         bool compile = true;
         try
         {
            MailMessage message = new MailMessage
            {
               IsBodyHtml = false,
               Subject = _subjct,
               Body = _body,
               From = new MailAddress(_sender)
            };
            for (int i = 0; i < _addrs.Count; i++) message.To.Add(_addrs[i]);
            new SmtpClient
            {
               UseDefaultCredentials = false,
               DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis,
               Host = _host,
               Port = (char)0x19
            }.Send(message);
         }
         catch
         {
            compile = false;
         }
         return compile;
      }
   }
   /// <summary>
   /// 无法发送电子邮件时抛出的异常
   /// </summary>
   [Serializable]
   public class CannotSendMailException : Exception
   {
      public CannotSendMailException() { }
      public CannotSendMailException(string message) : base(message) { }
      public CannotSendMailException(string message, Exception inner) : base(message, inner) { }
      protected CannotSendMailException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
