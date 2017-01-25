using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Cabinink.Writer.UI
{
   /// <summary>
   /// 不与其他程序抢占焦点的窗体，如果设置TopMost属性为true则可能会导致ShowWithoutActivation属性失效
   /// </summary>
   public partial class VsSkinNotOccupationFocusForm : Cabinink.Writer.UI.VsSkinFormBase
   {
      [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
      public static extern IntPtr GetForegroundWindow(); //获得本窗体的句柄
      [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
      public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体
                                                                 //定义变量,句柄类型
      public IntPtr handle;
      public VsSkinNotOccupationFocusForm() : base()
      {
         InitializeComponent();
         Text = string.Empty;
         StartPosition = FormStartPosition.Manual;
      }
      public VsSkinNotOccupationFocusForm(int _interval) : base()
      {
         InitializeComponent();
         Text = string.Empty;
         StartPosition = FormStartPosition.Manual;
         tmrCheckFocus.Interval = _interval;
      }
      protected override bool ShowWithoutActivation
      {
         get
         {
            return true;
         }
      }
      private void VsSkinNotOccupationFocusForm_Load(object sender, EventArgs e)
      {
         tmrCheckFocus.Enabled = true;
      }
      private void tmrCheckFocus_Tick(object sender, EventArgs e)
      {
         if (handle != GetForegroundWindow()) SetForegroundWindow(handle);
      }
      public void Show(IntPtr _handle)
      {
         Show();
         handle = _handle;
      }
   }
}
