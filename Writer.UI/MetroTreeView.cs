using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Cabinink.Writer.UI
{
   partial class MetroTreeView : System.Windows.Forms.TreeView
   {
      public MetroTreeView()
      {
         InitializeComponent();
      }

      public MetroTreeView(IContainer container)
      {
         container.Add(this);

         InitializeComponent();
      }
   }

}
