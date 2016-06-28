using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class frmVerification : MaterialForm
   {
      public frmVerification()
      {
         InitializeComponent();
         Sizable = false;
         SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
         SkinManager.ColorScheme = new ColorScheme(Primary.Grey600, Primary.Grey700, Primary.Grey700, Accent.Blue400, TextShade.WHITE);
      }
   }
}
