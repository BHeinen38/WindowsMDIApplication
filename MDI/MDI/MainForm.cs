using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class MainForm : Form
    {
        private int _counter = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new ChildForm();
            childForm.MdiParent = this;
            _counter++;
            childForm.Text = "New Document " + _counter.ToString(); 
            childForm.Show();
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Rich text files|*.rtf";
            var result = dialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                var childForm = new ChildForm();
                childForm.DocumentTextBox.LoadFile(dialog.FileName);
                childForm.Text = dialog.FileName;
                childForm.MdiParent = this;
                childForm.Show();
            }

        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Redo();
            }

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Cut();
            }

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Copy();
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Paste();
            }

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.SelectAll();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)this.ActiveMdiChild;

                var dialog = new SaveFileDialog();
                dialog.Filter = "Rich text files|*.rtf";
                dialog.AddExtension = true;
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    childForm.DocumentTextBox.SaveFile(dialog.FileName);
                    childForm.Text = dialog.FileName;
                }

            }

        }
    }
}
