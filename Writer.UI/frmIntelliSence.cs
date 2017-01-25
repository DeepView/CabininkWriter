using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using app = Cabinink.Program;
using System.Runtime.InteropServices;

namespace Cabinink.Writer.UI
{
   public partial class frmIntelliSence : Cabinink.Writer.UI.VsSkinNotOccupationFocusForm
   {
      private List<string> q_result = new List<string>();
      private string keyword = string.Empty;
      #region 得到光标在屏幕上的位置 
      [DllImport("user32")]
      public static extern bool GetCaretPos(out Point lpPoint);
      [DllImport("user32.dll")]
      private static extern new IntPtr GetForegroundWindow();
      [DllImport("user32.dll")]
      private static extern IntPtr GetFocus();
      [DllImport("user32.dll")]
      private static extern IntPtr AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, int fAttach);
      [DllImport("user32.dll")]
      private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
      [DllImport("kernel32.dll")]
      private static extern IntPtr GetCurrentThreadId();
      [DllImport("user32.dll")]
      private static extern void ClientToScreen(IntPtr hWnd, ref Point p);
      public Point CaretPosition()
      {
         IntPtr ptr = handle;
         Point p = new Point();
         //得到Caret在屏幕上的位置
         if (ptr.ToInt32() != 0)
         {
            IntPtr targetThreadID = GetWindowThreadProcessId(ptr, IntPtr.Zero);
            IntPtr localThreadID = GetCurrentThreadId();
            if (localThreadID != targetThreadID)
            {
               AttachThreadInput(localThreadID, targetThreadID, 1);
               ptr = GetFocus();
               if (ptr.ToInt32() != 0)
               {
                  GetCaretPos(out p);
                  ClientToScreen(ptr, ref p);
               }
               AttachThreadInput(localThreadID, targetThreadID, 0);
            }
         }
         return p;
      }
      #endregion

      public frmIntelliSence()
      {
         InitializeComponent();
         TopMost = true;
      }
      public frmIntelliSence(int _interval) : base(_interval)
      {
         InitializeComponent();
         TopMost = true;
      }
      public frmIntelliSence(int _interval, string _key) : base(_interval)
      {
         InitializeComponent();
         TopMost = true;
         keyword = _key;
      }
      public List<string> QueryResult(List<string> _sources, string _key)
      {
         IntelligentizedSence isc = new IntelligentizedSence(_sources);
         bool inited = isc.InitializeDataSource();
         if (inited == false)
         {
            VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("异常", "数据源初始化失败，因此本次操作将无法继续！", EMessageLevel.Error);
            msg.Display(this);
            isc.DisposeDataSources();
            return null;
         }
         else
         {
            isc.DisposeDataSources();
            return isc.GetContentAccessSearchForAdvanced(_key);
         }
      }
      public void UpdateResultList(List<string> _results)
      {
         try
         {
            lstIntelliSence.Items.Clear();
            for (int i = 0; i < _results.Count; i++) lstIntelliSence.Items.Add(_results[i]);
            lstIntelliSence.SetSelected(0, true);
            lblRemarks.Text = "详细：\n\n" + lstIntelliSence.SelectedItem.ToString();

         }
         catch (Exception)
         {
         }
      }
      public void DoQuery()
      {
         app.IntelliSenceSources.Add("Data Source=databases\\intellisence.db");
         UpdateResultList(QueryResult(app.IntelliSenceSources, keyword));
         //Location = CaretPosition();
      }
      public void frmIntelliSence_Load(object sender, EventArgs e)
      {
         DoQuery();
      }

      private void frmIntelliSence_FormClosing(object sender, FormClosingEventArgs e)
      {

      }

      private void lstIntelliSence_Click(object sender, EventArgs e)
      {
      }

      private void lstIntelliSence_SelectedIndexChanged(object sender, EventArgs e)
      {
         lblRemarks.Text = "详细：\n\n" + lstIntelliSence.SelectedItem.ToString();
      }
   }
}
