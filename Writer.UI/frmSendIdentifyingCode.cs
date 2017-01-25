using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;

namespace Cabinink.Writer.UI
{
   public partial class frmSendIdentifyingCode : Cabinink.Writer.UI.VsSkinFormBase
   {
      private frmLogon owner;
      private long sendtime;//发送验证邮件的时间
      private long flowtime;//验证邮件失效的时间
      private int idcode = 0;

      private int tick_s = 0;

      public frmSendIdentifyingCode()
      {
         InitializeComponent();
         
      }

      private void btnSend_Click(object sender, EventArgs e)
      {
         int ft = 30;
         idcode = owner.credential.GenerateIdentifyingCode();
         owner.credential.SendValidatedMail(idcode, ref ft);
         sendtime = DateTime.Now.Ticks;
         flowtime = new DateTime(sendtime).AddMinutes(ft).Ticks;
         tmrTicksCheck.Enabled = true;
         btnSend.Enabled = false;
      }
      public DialogResult DisplayDialog(frmLogon _owner)
      {
         owner = _owner;
         return ShowDialog();
      }

      private void tmrTicksCheck_Tick(object sender, EventArgs e)
      {
         tick_s += 1;
         if (tick_s >= 60) btnSend.Enabled = true;
         if (DateTime.Now.Ticks >= flowtime)
         {
            VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("验证失败", "验证邮件已失效，请重新发送！", EMessageLevel.Warning);
            msg.Display(this);
            tmrTicksCheck.Enabled = false;
         }
      }

      private void btnDone_Click(object sender, EventArgs e)
      {
         if (txtIdentifyingCode.Text == idcode.ToString())
         {
            owner.iscomplate = true;
            Close();
         }
         else
         {
            VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("验证失败", "验证码不正确，请尝试重新输入，或者稍后重新发送验证邮件！", EMessageLevel.Error);
            msg.Display(this);
         }
      }
   }
}
