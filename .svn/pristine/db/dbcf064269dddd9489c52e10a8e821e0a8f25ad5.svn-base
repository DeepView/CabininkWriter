using CCWin;
using System;
using System.Drawing;
using Cabinink.Properties;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class VsSkinFormBase : CCSkinMain
   {
      public VsSkinFormBase()
      {
         InitializeComponent();
         ChangeSkin();
      }
      private void ChangeSkin()
      {
         AutoScaleDimensions = new SizeF(6F, 12F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.FromArgb(64, 64, 64);
         BorderColor = Color.FromArgb(0, 121, 203);
         CaptionBackColorBottom = Color.FromArgb(45, 45, 48);
         CaptionBackColorTop = Color.FromArgb(45, 45, 48);
         CaptionHeight = 35;
         ClientSize = new Size(284, 262);
         CloseBoxSize = new Size(34, 26);//34,26
         CloseDownBack = Resources.Dark_CloseDown;
         CloseMouseBack = Resources.Dark_CloseMouse;
         CloseNormlBack = Resources.Dark_CloseNorml;
         ControlBoxOffset = new Point(0, 0);
         EffectCaption = TitleType.Title;

         Icon = Resources.ciw;
         InnerBorderColor = Color.Transparent;
         MaxDownBack = Resources.Dark_MaxDown;
         MaxMouseBack = Resources.Dark_MaxMouse;
         MaxNormlBack = Resources.Dark_MaxNorml;
         MaxSize = new Size(34, 26);
         MiniDownBack = Resources.Dark_MinDown;
         MiniMouseBack = Resources.Dark_MinMouse;
         MiniNormlBack = Resources.Dark_MinNorml;
         MiniSize = new Size(34, 26);

         Name = "VsSkinFormBase";
         RestoreDownBack = Resources.Dark_RestoreDown;
         RestoreMouseBack = Resources.Dark_RestoreMouse;
         RestoreNormlBack = Resources.Dark_RestoreNorml;
         RoundStyle = CCWin.SkinClass.RoundStyle.None;
         ShadowColor = Color.FromArgb(0, 121, 203);
         StartPosition = FormStartPosition.CenterScreen;
         Text = "Cabinink Writer";
         TitleColor = Color.FromArgb(160, 160, 160);
         ResumeLayout(false);


      }
      public Action DoNothing { get { return delegate {; }; } }
   }
}
