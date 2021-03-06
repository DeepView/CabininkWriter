﻿using System.IO;
using System.Media;
using Cabinink.Properties;
using System.Windows.Forms;
namespace Cabinink.Writer.UI
{
   public delegate void DownButton();
   public partial class VsSkinMessageBoxBase : Cabinink.Writer.UI.VsSkinFormBase
   {
      public VsSkinMessageBoxBase()
      {
         InitializeComponent();
      }
      public VsSkinMessageBoxBase(string _caption, string _tipstr, EMessageLevel _level)
      {
         InitializeComponent();
         Text = _caption;
         lblTipString.Text = _tipstr;
         SetMessageBoxSkin(_level);
      }
      public void Display()
      {
         ShowDialog();
      }
      public void Display(IWin32Window _owner)
      {
         ShowDialog(_owner);
      }
      private void SetMessageBoxSkin(EMessageLevel _level)
      {
         switch (_level)
         {
            case EMessageLevel.Default:
               Icon = Resources.ciw;
               PlaySound(Resources.s_def);
               break;
            case EMessageLevel.Information:
               Icon = Resources.i_info;
               PlaySound(Resources.s_info);
               break;
            case EMessageLevel.Warning:
               Icon = Resources.i_war;
               PlaySound(Resources.s_war);
               break;
            case EMessageLevel.Question:
               Icon = Resources.i_ques;
               PlaySound(Resources.s_ques);
               break;
            case EMessageLevel.Error:
               Icon = Resources.i_err;
               PlaySound(Resources.s_err);
               break;
            default:
               Icon = Resources.ciw;
               PlaySound(Resources.s_def);
               break;
         }
      }
      private void PlaySound(UnmanagedMemoryStream _sound)
      {
         SoundPlayer player = new SoundPlayer(_sound);
         player.Play();
      }
   }
   /// <summary>
   /// 提示框的消息级别
   /// </summary>
   public enum EMessageLevel : int
   {
      Default = 0x0000,
      Information = 0x0001,
      Warning = 0x0002,
      Question = 0x0003,
      Error = 0x0004
   }
}
