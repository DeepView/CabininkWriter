using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class HaveLabelTextBox : UserControl
   {
      public HaveLabelTextBox()
      {
         InitializeComponent();
      }
      [Category("Appearance"), Description("获取或设置当前实例的文本框内容。"), DefaultValue(@"Context")]
      public string Context
      {
         get { return txtContext.Text; }
         set { txtContext.Text = value; }
      }
      [Category("Appearance"), Description("获取或设置当前实例的说明性文字。"), DefaultValue(@"Description")]
      public string Description
      {
         get { return lblLabel.Text; }
         set { lblLabel.Text = value; }
      }
   }
}
