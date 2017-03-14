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
using System.Security.Cryptography;
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

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = comboBox1.Text;
            string pass = GetMd5Hash(MD5.Create(), textBox1.Text);
            if (login == String.Empty)
            {
                MessageBox.Show("You don`t input login.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comboBox1.Items.Add(login);
                doc1.Element("root").Add(
                    new XElement("autorization",
                    new XAttribute("login", login),
                    new XAttribute("password",pass)));
                doc1.Save(path1);

                textBox1.Clear();

                MessageBox.Show("Login has been saved", "Yes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != String.Empty||textBox1.Text!=String.Empty)
            {
                var l = from x in doc1.Element("root").Elements("autorization")
                             where x.Attribute("login").Value == comboBox1.Text &&
                             VerifyMd5Hash(MD5.Create(), textBox1.Text, x.Attribute("password").Value)
                        select x;
                if (l.Any())
                {
                    Form2 f2 = new Form2(this, comboBox1.Text);
                    f2.Show();
                    this.Hide();
                }                                         
            }
        }
    }
}
