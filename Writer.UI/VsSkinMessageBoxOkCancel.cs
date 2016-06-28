using System;
namespace Cabinink.Writer.UI
{
   public partial class VsSkinMessageBoxOkCancel : Cabinink.Writer.UI.VsSkinMessageBoxBase
   {
      private DownButton b_ok;
      private DownButton b_cancel;
      public VsSkinMessageBoxOkCancel()
      {
         InitializeComponent();
      }
      public VsSkinMessageBoxOkCancel(string _caption, string _tipstr, EMessageLevel _level, Action _ok,Action _cancel) : base(_caption, _tipstr, _level)
      {
         InitializeComponent();
         Text = _caption;
         b_ok = new DownButton(_ok);
         b_cancel = new DownButton(_cancel);
      }

      private void btnOk_Click(object sender, EventArgs e)
      {
         b_ok.Invoke();
         Close();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         b_cancel.Invoke();
         Close();
      }
   }
}
