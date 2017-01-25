using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class frmRoleDetails : Cabinink.Writer.UI.VsSkinFormBase
   {
      private bool isviewrole;
      public frmRoleDetails()
      {
         InitializeComponent();
      }
      public frmRoleDetails(string _details)
      {
         InitializeComponent();
         rtbRoleDetails.Text = _details;
         isviewrole = true;
      }
      public frmRoleDetails(string _details,bool _isviewrole)
      {
         InitializeComponent();
         rtbRoleDetails.Text = _details;
         isviewrole = _isviewrole;
      }

      private void frmRoleDetails_Load(object sender, EventArgs e)
      {
         if(!isviewrole )
         {
            Text = @"故事线详细信息";
         }
      }
   }
}
