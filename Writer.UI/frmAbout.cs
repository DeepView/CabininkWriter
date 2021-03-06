﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Cabinink.Properties;
using MetroFramework.Forms;
using System.Windows.Forms;
using Cabinink.Writer.Middle;
using System.Diagnostics;
using app = Cabinink.Program;

namespace Cabinink.Writer.UI
{
   public partial class frmAbout : VsSkinFormBase
   {
      public frmAbout()
      {
         InitializeComponent();
      }

      private void frmAbout_Load(object sender, EventArgs e)
      {
         Icon = Resources.ciw;
         lblAssemblyName.Text += AssemblyInformation.ApplicationName;
         lblAssemblyVersion.Text += AssemblyInformation.ProductionVersion + app.AppBuildingProcessFlag;
         lblAssemblyFullName.Text += AssemblyInformation.AssemblyFullName;
         lblFileVersion.Text += AssemblyInformation.FileVersion;
         lblCopyright.Text = AssemblyInformation.Copyright;
         lblIdeName.Text += AssemblyInformation.IdeName;
         lblClrVersion.Text += AssemblyInformation.RuntimeVersion;
         lstComInfo.SetSelected(0, true);
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void metroLink1_Click(object sender, EventArgs e)
      {
         Process.Start("http://bbs.cskin.net/forum.php");
      }

      private void metroLink2_Click(object sender, EventArgs e)
      {
         Process.Start("https://msdn.microsoft.com/zh-cn");
      }

      private void btnSysInfo_Click(object sender, EventArgs e)
      {
         Process.Start("winver");
      }

      private void btnDxInfo_Click(object sender, EventArgs e)
      {
         Process.Start("dxdiag");
      }
   }
}
