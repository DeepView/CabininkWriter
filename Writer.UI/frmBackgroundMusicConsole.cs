using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using Cabinink.Properties;

namespace Cabinink.Writer.UI
{
   public partial class frmBackgroundMusicConsole : Cabinink.Writer.UI.VsSkinFormBase
   {
      private PlayQueue playList;
      private frmMainInterface owner;
      public frmBackgroundMusicConsole(frmMainInterface _owner)
      {
         InitializeComponent();
         playList = new PlayQueue();
         owner = _owner;
      }

      private void btnVolumn_Click(object sender, EventArgs e)
      {
         if (tmrShowVol.Enabled == false) tmrShowVol.Enabled = true;
         else tmrShowVol.Enabled = false;
         trbVolumn.Visible = true;
      }

      private void tmrShowVol_Tick(object sender, EventArgs e)
      {
         if (trbVolumn.Visible == true) trbVolumn.Visible = false;
      }

      private void 添加文件ToolStripMenuItem_Click(object sender, EventArgs e)
      {

         if (ofdOpenFile.ShowDialog() == DialogResult.OK)
         {
            playList.AddSound(new Sound(ofdOpenFile.FileName, Handle));
            lstPlayList.Items.Clear();
            lstPlayList.Items.AddRange(playList.PlayList.ToArray());

         }
      }

      private void lstPlayList_DoubleClick(object sender, EventArgs e)
      {
         playList.StartPlay(lstPlayList.SelectedIndex);
         btnPlayAndPause.BackgroundImage = Resources.m_pause;
         lblPlaying.Text = playList[playList.Playing].ToString();
      }

      private void lstPlayList_MouseDown(object sender, MouseEventArgs e)
      {
         try
         {
            if (e.Button == MouseButtons.Right)
            {
               int ht = lstPlayList.ItemHeight;
               Rectangle rect = new Rectangle(0, 0, lstPlayList.ClientSize.Width, ht);
               for (int SelectListItem = 0; SelectListItem <= lstPlayList.Items.Count - 1; SelectListItem++)
               {
                  if (rect.Contains(e.Location))
                  {
                     lstPlayList.SelectedIndex = SelectListItem + lstPlayList.TopIndex;
                     lstPlayList.SetSelected(lstPlayList.SelectedIndex, true);
                     break;
                  }
                  else
                  {
                     rect.Y += ht;
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void frmBackgroundMusicConsole_FormClosing(object sender, FormClosingEventArgs e)
      {
         e.Cancel = true;
         Visible = false;
      }

      private void frmBackgroundMusicConsole_Load(object sender, EventArgs e)
      {
         if (playList.Playing >= 0)
         {
            if (playList[playList.Playing].Status == EPlayStatus.Playing)
            {
               btnPlayAndPause.BackgroundImage = Resources.m_pause;
            }
            else
            {
               btnPlayAndPause.BackgroundImage = Resources.m_play;
            }
            lblPlaying.Text = playList[playList.Playing].ToString();
         }
         lstPlayList.Items.AddRange(playList.PlayList.ToArray());

      }

      private void lstPlayList_DataSourceChanged(object sender, EventArgs e)
      {
         owner.BackgroundMusicList = playList;
      }

      private void frmBackgroundMusicConsole_VisibleChanged(object sender, EventArgs e)
      {
         playList = owner.BackgroundMusicList;
         lstPlayList.Items.AddRange(playList.PlayList.ToArray());
         if (playList.Playing >= 0)
         {
            if (playList[playList.Playing].Status == EPlayStatus.Playing)
            {
               btnPlayAndPause.BackgroundImage = Resources.m_pause;
            }
            else
            {
               btnPlayAndPause.BackgroundImage = Resources.m_play;
            }
            lblPlaying.Text = playList[playList.Playing].ToString();
         }
      }

      private void tmrProcessTick_Tick(object sender, EventArgs e)
      {
         if (playList.Playing >= 0)
         {
            double process = playList.PlayingExample.PlayingAccomplishment;
            trbPlayingProcess.Value = (int)(trbPlayingProcess.Maximum * process);
            if (process == 1)
            {
               Thread.Sleep(1000);
               playList.Next();
               lblPlaying.Text = playList.PlayingExample.ToString();
            }
            Text = "背景音乐控制台 " + playList.PlayingExample.GetChannelLevel().ToString();
         }
      }

      private void trbPlayingProcess_ValueChanged(object sender, EventArgs e)
      {
         //if (playList.Playing >= 0 && MouseButtons == MouseButtons.Left)
         //{
         //   double process = trbPlayingProcess.Value / trbPlayingProcess.Maximum;
         //   playList[playList.Playing].PlayingAccomplishment = process;
         //}
      }

      private void trbVolumn_ValueChanged(object sender, EventArgs e)
      {
         if (playList.Playing >= 0)
         {
            playList[playList.Playing].PlayingVolume = trbVolumn.Value / trbVolumn.Maximum;
         }
      }

      private void btnPlayAndPause_Click(object sender, EventArgs e)
      {
         if (playList[playList.Playing].Status == EPlayStatus.Playing)
         {
            playList[playList.Playing].InterruptPlay();
            btnPlayAndPause.BackgroundImage = Resources.m_play;
         }
         else
         {
            playList[playList.Playing].ContinuePlay();
            btnPlayAndPause.BackgroundImage = Resources.m_pause;
         }
         if (playList.Playing < 0 && playList.Count > 0) playList.StartPlay(0);
      }
      private void btnStop_Click(object sender, EventArgs e)
      {
         playList.Stop();
      }

      private void btnNext_Click(object sender, EventArgs e)
      {
         if (playList.Playing >= 0)
         {
            playList.Next();
            lblPlaying.Text = playList[playList.Playing].ToString();
            lstPlayList.SetSelected(playList.Playing, true);
         }
      }

      private void btnPrevious_Click(object sender, EventArgs e)
      {
         if (playList.Playing >= 0)
         {
            playList.Previous();
            lblPlaying.Text = playList[playList.Playing].ToString();
            lstPlayList.SetSelected(playList.Playing, true);
         }
      }

      private void 添加文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         List<string> files = new List<string>();
         string[] types = new string[] { ".mp4", ".m4a", ".wma", ".wav", ".ape", ".aac", ".flac" };
         if (bpdBrowserPath.ShowDialog(this) == DialogResult.OK)
         {
            files = FileOperation.GetFiles(bpdBrowserPath.DirectoryPath, types);
            for (int i = 0; i < files.Count; i++)
            {
               playList.AddSound(new Sound(files[i], Handle));
            }
            lstPlayList.Items.Clear();
            lstPlayList.Items.AddRange(playList.PlayList.ToArray());
         }
      }
   }
}
