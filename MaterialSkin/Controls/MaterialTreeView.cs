using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;

namespace MaterialSkin.Controls
{
    public class MaterialTreeView : TreeView, IMaterialControl
    {
        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public MaterialSkinManager SkinManager { get { return MaterialSkinManager.Instance; } }
        [Browsable(false)]
        public MouseState MouseState { get; set; }

        [Category("Appearance")]
        [Description("Sets tree view to display checkboxes or not.")]
        [DefaultValue(false)]
        public new bool CheckBoxes
        {
            get { return _bCheckBoxesVisible; }
            set
            {
                _bCheckBoxesVisible = value;
                base.CheckBoxes = _bCheckBoxesVisible;
                this.StateImageList = _bCheckBoxesVisible ? _ilStateImages : null;
            }
        }

        [Browsable(false)]
        public new ImageList StateImageList
        {
            get { return base.StateImageList; }
            set { base.StateImageList = value; }
        }

        [Category("Appearance")]
        [Description("Sets tree view to use tri-state checkboxes or not.")]
        [DefaultValue(true)]
        public bool CheckBoxesTriState
        {
            get { return _bUseTriState; }
            set { _bUseTriState = value; }
        }


        ImageList _ilStateImages;
        bool _bUseTriState;
        bool _bCheckBoxesVisible;
        bool _bPreventCheckEvent;

        public MaterialTreeView() : base()
        {
            HotTracking = true;
            HideSelection = false;
            SelectedImageIndex = ImageIndex;

            BackColor = System.Drawing.Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Font = new System.Drawing.Font("微软雅黑", 9.7F);
            FullRowSelect = true;

            _ilStateImages = new ImageList();
            CheckBoxState cbsState = CheckBoxState.UncheckedNormal;
            Graphics gfxCheckBox;
            Bitmap bmpCheckBox;
            for (int i = 0; i <= 2; i++)
            {
                bmpCheckBox = new Bitmap(16, 16);
                gfxCheckBox = Graphics.FromImage(bmpCheckBox);
                switch (i)
                {
                    case 0: cbsState = CheckBoxState.UncheckedNormal; break;
                    case 1: cbsState = CheckBoxState.CheckedNormal; break;
                    case 2: cbsState = CheckBoxState.MixedNormal; break;
                }
                CheckBoxRenderer.DrawCheckBox(gfxCheckBox, new Point(2, 2), cbsState);
                gfxCheckBox.Save();
                _ilStateImages.Images.Add(bmpCheckBox);

                _bUseTriState = true;
            }
        }

        public override void Refresh()
        {
            Stack<TreeNode> stNodes;
            TreeNode tnStacked;

            base.Refresh();

            if (!CheckBoxes)                                                // nothing to do here if
                return;                                                     // checkboxes are hidden.

            base.CheckBoxes = false;                                        // hide normal checkboxes...

            stNodes = new Stack<TreeNode>(this.Nodes.Count);                // create a new stack and
            foreach (TreeNode tnCurrent in this.Nodes)                      // push each root node.
                stNodes.Push(tnCurrent);

            while (stNodes.Count > 0)
            {                                       // let's pop node from stack,
                tnStacked = stNodes.Pop();                                  // set correct state image
                if (tnStacked.StateImageIndex == -1)                        // index if not already done
                    tnStacked.StateImageIndex = tnStacked.Checked ? 1 : 0;  // and push each child to stack
                for (int i = 0; i < tnStacked.Nodes.Count; i++)             // too until there are no
                    stNodes.Push(tnStacked.Nodes[i]);                       // nodes left on stack.
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            Refresh();
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);

            foreach (TreeNode tnCurrent in e.Node.Nodes)                    // set tree state image
                if (tnCurrent.StateImageIndex == -1)                        // to each child node...
                    tnCurrent.StateImageIndex = tnCurrent.Checked ? 1 : 0;
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);

            if (_bPreventCheckEvent)
                return;

            OnNodeMouseClick(new TreeNodeMouseClickEventArgs(e.Node, MouseButtons.None, 0, 0, 0));
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            Stack<TreeNode> stNodes;
            TreeNode tnBuffer;
            bool bMixedState;
            int iSpacing;
            int iIndex;

            base.OnNodeMouseClick(e);

            _bPreventCheckEvent = true;

            iSpacing = ImageList == null ? 0 : 18;                          // if user clicked area
            if ((e.X > e.Node.Bounds.Left - iSpacing ||                     // *not* used by the state
                 e.X < e.Node.Bounds.Left - (iSpacing + 16)) &&             // image we can leave here.
                 e.Button != MouseButtons.None)
            { return; }

            tnBuffer = e.Node;                                              // buffer clicked node and
            if (e.Button == MouseButtons.Left)                              // flip its check state.
                tnBuffer.Checked = !tnBuffer.Checked;

            tnBuffer.StateImageIndex = tnBuffer.Checked ?                   // set state image index
                                        1 : tnBuffer.StateImageIndex;       // correctly.

            OnAfterCheck(new TreeViewEventArgs(tnBuffer, TreeViewAction.ByMouse));

            stNodes = new Stack<TreeNode>(tnBuffer.Nodes.Count);            // create a new stack and
            stNodes.Push(tnBuffer);                                         // push buffered node first.
            do
            {                                                           // let's pop node from stack,
                tnBuffer = stNodes.Pop();                                   // inherit buffered node's
                tnBuffer.Checked = e.Node.Checked;                          // check state and push
                for (int i = 0; i < tnBuffer.Nodes.Count; i++)              // each child on the stack
                    stNodes.Push(tnBuffer.Nodes[i]);                        // until there is no node
            } while (stNodes.Count > 0);                                    // left.

            bMixedState = false;
            tnBuffer = e.Node;                                              // re-buffer clicked node.
            while (tnBuffer.Parent != null)
            {                               // while we get a parent we
                foreach (TreeNode tnChild in tnBuffer.Parent.Nodes)         // determine mixed check states
                    bMixedState |= (tnChild.Checked != tnBuffer.Checked |   // and convert current check
                                    tnChild.StateImageIndex == 2);          // state to state image index.
                iIndex = (int)Convert.ToUInt32(tnBuffer.Checked);           // set parent's check state and
                tnBuffer.Parent.Checked = bMixedState || (iIndex > 0);      // state image in dependency
                if (bMixedState)                                            // of mixed state.
                    tnBuffer.Parent.StateImageIndex = CheckBoxesTriState ? 2 : 1;
                else
                    tnBuffer.Parent.StateImageIndex = iIndex;
                tnBuffer = tnBuffer.Parent;                                 // finally buffer parent and
            }                                                               // loop here.

            _bPreventCheckEvent = false;
        }
    }
}
