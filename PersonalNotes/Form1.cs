using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace PersonalNotes
{
    public partial class Form1 : Form
    {
        string path1;
        XDocument doc1 = new XDocument();

        public Form1()
        {
            InitializeComponent();
            path1 = @"..\..\data.xml";
            doc1 = XDocument.Load(path1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (XElement l in doc1.Element("root").Elements("autorization"))
                comboBox1.Items.Add(l.Attribute("login").Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            if (login == "")
            {
                MessageBox.Show("You don`t input login.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comboBox1.Items.Add(login);
                doc1.Element("root").Add(
                    new XElement("autorization",
                    new XAttribute("login", login)));
                doc1.Save(path1);

                textBox1.Clear();

                MessageBox.Show("Login has been saved", "Yes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string h = this.comboBox1.SelectedItem.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
               Form2 f2 = new Form2(this,comboBox1.Text,null,null);
               f2.Show();
               this.Hide();
        }
    }
}
