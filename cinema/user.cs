using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace cinema
{
    public partial class user : Form
    {
        public static List<registrationclass> rg = new List<registrationclass>();
        XmlSerializer formatter = new XmlSerializer(typeof(List<registrationclass>));

        public user()
        {
            InitializeComponent();
            if (Form1.a == 0) { menuStrip1.Visible = false; }
            if (Form1.a == 1) { menuStrip1.Visible = true; }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("pas", FileMode.OpenOrCreate))
            {
                rg = (List<registrationclass>)formatter.Deserialize(fs);

                foreach (registrationclass rgn in rg)
                {
                    if (textBox1.Text == rgn.Login && textBox2.Text == rgn.Password)
                    {
                        MessageBox.Show("Авторизация прошла успешно");

                        Form1.a = 1;
                        menuStrip1.Visible = true;

                    }
                    else { MessageBox.Show("Авторизация не прошла"); }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.a = 0;
            button3.Visible = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Password = textBox2.Text;
            rg.Clear();
            rg.Add(new registrationclass(Login, Password));


            using (FileStream fs = new FileStream("pas", FileMode.Create))
            {
                formatter.Serialize(fs, rg);
                fs.Close();
            }
        }

        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введите новые параметры");
            foreach (registrationclass rgn in rg)
            {
                textBox1.Text = rgn.Login;
                textBox2.Text = rgn.Password;
                button3.Visible = true;
            }
        }
    }
}
