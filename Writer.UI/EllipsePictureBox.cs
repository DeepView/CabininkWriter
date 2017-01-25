using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Cabinink.Writer.UI
{
   public class EllipsePictureBox : PictureBox
   {
      protected override void OnCreateControl()
      {
         GraphicsPath gp = new GraphicsPath();
         //gp.FillMode = FillMode.Winding;
         gp.AddEllipse(ClientRectangle);
         Region region = new Region(gp);
         Region = region;
         gp.Dispose();
         region.Dispose();
         //Graphics g = CreateGraphics();
         //g.SmoothingMode = SmoothingMode.HighQuality;
         //Image = g.Image;
         base.OnCreateControl();
      }
   }
}
