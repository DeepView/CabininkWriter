using System.Drawing;
using System.Windows.Forms;
namespace Cabinink.Writer.UI
{
   public class FunctionIconButton : Button
   {
      public FunctionIconButton()
      {
         Size = new Size(54, 40);
         FlatAppearance.BorderSize = 0;
         FlatStyle = FlatStyle.Flat;
         Text = string.Empty;
         BackColor = Color.FromArgb(64, 64, 64);
         BackgroundImageLayout = ImageLayout.Zoom;
      }
   }
}
