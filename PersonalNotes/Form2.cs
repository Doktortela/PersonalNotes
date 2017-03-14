using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace PersonalNotes
{
    public partial class Form2 : Form
    {
        Form1 f1;
        Form4 f4;
        public Form2(Form1 fr1, string s1, Form4 fr4, string s4)
        {
            InitializeComponent();
            this.f1 = fr1;
            this.f4 = fr4;
            label2.Text = s1;
            textBox1.Text = s4;
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
