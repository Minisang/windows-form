using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace study_0511
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDocument childForm = new frmDocument();
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Location = new Point((this.ClientSize.Width - childForm.Width),
                                            (this.ClientSize.Height - childForm.Height) / 2);
            childForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDocument2 form = new frmDocument2();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Query form = new Query();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCount form = new FormCount();
            form.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
