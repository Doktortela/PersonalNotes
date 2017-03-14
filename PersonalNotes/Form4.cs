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
using System.Xml.Serialization;

namespace PersonalNotes
{
    public partial class Form4 : Form
    {
        string path2;
        XDocument doc2 = new XDocument();

        public Form4()
        {
            InitializeComponent();
            path2 = @"..\..\notes.xml";
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (XElement x in doc2.Element("root").Elements("note"))
                comboBox1.Items.Add(x.Attribute("category").Value);

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) // Add category
        {
            string category = textBox1.Text;
            if (category == "")
            {
                MessageBox.Show("You don`t input category.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comboBox1.Items.Add(category);
                doc2.Element("root").Add(
                    new XElement("note",
                    new XAttribute("category", category)));
                doc2.Save(path2);

                textBox1.Clear();

                MessageBox.Show("Category has been saved", "Yes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(null,null,this,textBox1.Text);
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = comboBox1.SelectedItem.ToString();
            string msg = String.Format("Вы собираетесь удалить категорию {{0}}! Согласны?",
                name);
            DialogResult res = MessageBox.Show(msg, "Подтверждаю",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                var c = from x in doc2.Element("root").Elements("note")
                        where x.Attribute("category").Value == name
                        select x;
                c.First().Remove();
                doc2.Save(path2);
                MessageBox.Show("Category delete.", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
