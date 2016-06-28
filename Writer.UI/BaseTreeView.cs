using System;
using System.Windows.Forms;
using System.Drawing;
using Cabinink.Properties;

namespace Cabinink.Writer.UI
{
   public partial class BaseTreeView : TreeView
   {

      Color drawTextColor = Color.FromArgb(255, 255, 255);

      public BaseTreeView()
      {
         InitializeComponent();

         this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
         this.FullRowSelect = true;
         this.ItemHeight = 23;
         this.HotTracking = true;
         this.ShowLines = true;

      }

      protected override void OnDrawNode(DrawTreeNodeEventArgs e)
      {
         base.OnDrawNode(e);

         //节点背景绘制
         if (e.Node.IsSelected)
         {
            e.Graphics.DrawImage(Resources.tree_Selected, e.Bounds);
         }
         else if ((e.State & TreeNodeStates.Hot) != 0)//|| currentMouseMoveNode == e.Node)
         {
            e.Graphics.DrawImage(Resources.tree_Hover, e.Bounds);
         }
         else
         {
            //Brushes br = new Brushes();
            //Brushes.
            e.Graphics.FillRectangle(Brushes.DimGray, e.Bounds);
         }

         //节点头图标绘制
         if (e.Node.IsExpanded)
         {
            e.Graphics.DrawImage(Resources.tree_NodeExpend, e.Node.Bounds.X - 18, e.Node.Bounds.Y + 9);
         }
         else if (e.Node.IsExpanded == false && e.Node.Nodes.Count > 0)
         {
            e.Graphics.DrawImage(Resources.tree_NodeCollaps, e.Node.Bounds.X - 18, e.Node.Bounds.Y + 9);
         }

         //文本绘制
         using (Font foreFont = new Font(this.Font, FontStyle.Regular))
         using (Brush drawTextBrush = new SolidBrush(drawTextColor))
         {
            e.Graphics.DrawString(e.Node.Text, foreFont, drawTextBrush, e.Node.Bounds.Left + 5, e.Node.Bounds.Top + 5);
         }
      }

      protected override void OnMouseDoubleClick(MouseEventArgs e)
      {
         base.OnMouseDoubleClick(e);
         TreeNode tn = this.GetNodeAt(e.Location);
         //调整【点击测试区域】大小，包括图标
         Rectangle bounds = new Rectangle(tn.Bounds.Left - 12, tn.Bounds.Y, tn.Bounds.Width - 5, tn.Bounds.Height);
         if (tn != null && bounds.Contains(e.Location) == false)
         {
            if (tn.IsExpanded == false)
               tn.Expand();
            else
               tn.Collapse();
         }
      }

      protected override void OnMouseClick(MouseEventArgs e)
      {
         base.OnMouseClick(e);
         TreeNode tn = this.GetNodeAt(e.Location);
         this.SelectedNode = tn;
      }

      TreeNode currentNode = null;
      protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);
         TreeNode tn = this.GetNodeAt(e.Location);
         Graphics g = this.CreateGraphics();
         if (currentNode != tn)
         {
            //绘制当前节点的hover背景
            if (tn != null)
               OnDrawNode(new DrawTreeNodeEventArgs(g, tn, new Rectangle(0, tn.Bounds.Y, this.Width, tn.Bounds.Height), TreeNodeStates.Hot));

            //取消之前hover的节点背景
            if (currentNode != null)
               OnDrawNode(new DrawTreeNodeEventArgs(g, currentNode, new Rectangle(0, currentNode.Bounds.Y, this.Width, currentNode.Bounds.Height), TreeNodeStates.Default));
         }
         currentNode = tn;
         g.Dispose();
      }


      protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         //移出控件时取消Hover背景
         if (currentNode != null)
         {
            Graphics g = this.CreateGraphics();
            OnDrawNode(new DrawTreeNodeEventArgs(g, currentNode, new Rectangle(0, currentNode.Bounds.Y, this.Width, currentNode.Bounds.Height), TreeNodeStates.Default));
         }
      }
      public void ON_PAINT(PaintEventArgs e)
      {
         OnPaint(e);
      }
   }
}
