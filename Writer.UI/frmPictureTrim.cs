using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class frmPictureTrim : Cabinink.Writer.UI.VsSkinFormBase
   {
      private Image image;
      private Graphics graphics;
      private Graphics preview;
      public frmPictureTrim(ref Image _image)
      {
         InitializeComponent();
         image = _image;
         graphics = picAvater.CreateGraphics();
         preview = picPreview.CreateGraphics();
      }

      private void frmPictureTrim_Load(object sender, EventArgs e)
      {
         picAvater.Image = image;
         picAvater.SizeMode = PictureBoxSizeMode.Zoom;
         //graphics.DrawImage(image, new Rectangle(new Point(0, 0), picAvater.Size));
         Rectangle rect = new Rectangle(new Point(50, 50), new Size(tkbAreaSize.Value, tkbAreaSize.Value));
         graphics.DrawRectangle(Pens.Azure, rect);
      }

      private void picAvater_MouseMove(object sender, MouseEventArgs e)
      {
         Bitmap bmp = new Bitmap(picAvater.Image);
         if (MouseButtons == MouseButtons.Left)
         {
            picAvater.Image = image;
            Rectangle rect = new Rectangle(new Point(MousePosition.X - Left - tkbAreaSize.Value / 2, MousePosition.Y - Top - tkbAreaSize.Value / 2 - 40), new Size(tkbAreaSize.Value, tkbAreaSize.Value));
            graphics.DrawRectangle(Pens.Azure, rect);
            picPreview.Image = bmp.Clone(rect, image.PixelFormat);
            preview.DrawImage(picPreview.Image, new Rectangle(new Point(MousePosition.X - Left - tkbAreaSize.Value / 2, MousePosition.Y - Top - tkbAreaSize.Value / 2 - 40), picPreview.Size));
         }
         bmp.Dispose();
         //GC.Collect();
      }
   }
}
