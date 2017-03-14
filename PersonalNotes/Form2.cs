using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersonalNotes
{
    public partial class Form2 : Form
    {
        Form1 f1;
        public Form2(Form1 f,string l)
        {
            InitializeComponent();
            f1 = f;
            label2.Text = l;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Close();
        }
    }
}
