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
   public partial class frmNtpClient : Cabinink.Writer.UI.VsSkinFormBase
   {
      public frmNtpClient()
      {
         InitializeComponent();
      }

      private void frmNtpClient_Load(object sender, EventArgs e)
      {
         cmbServer.Text = @"192.43.244.18";
         txtPort.ReadOnly = !ckbEnableChangedPort.Checked;
      }

      private void ckbEnableChangedPort_CheckedChanged(object sender, EventArgs e)
      {
         txtPort.ReadOnly = !ckbEnableChangedPort.Checked;
      }

      private void btnSync_Click(object sender, EventArgs e)
      {
         NetworkTimeProtocol ntp = new NetworkTimeProtocol(cmbServer.Text, Convert.ToInt32(txtPort.Text));
         ntp.Synchronization();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
