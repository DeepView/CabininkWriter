using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cabinink.Writer.UI
{
   public partial class frmNotesOrResources : Cabinink.Writer.UI.VsSkinFormBase
   {
      private frmMainInterface owner;
      public void Display(frmMainInterface _owner)
      {
         owner = _owner;
         Show();
      }
      public frmNotesOrResources()
      {
         InitializeComponent();
      }

      private void cmlNoteExplorer_Click(object sender, EventArgs e)
      {
         frmNotes notes = new frmNotes();
         notes.Show();
         Close();
      }

      private void cmlResExplorer_Click(object sender, EventArgs e)
      {
         frmResources res = new frmResources();
         res.Display(owner);
         Close();
      }
   }
}
