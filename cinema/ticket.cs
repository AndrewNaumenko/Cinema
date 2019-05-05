using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema
{
    public partial class ticket : Form
    {
        Bitmap ticketimage;
        public ticket(string name, string time, string date, int cost,  int rad, int mesto)
        {
            InitializeComponent();
            ticketimage = new Bitmap("Билет2.jpg");
            pictureBox1.Size = ticketimage.Size;
            CreateGraphics().DrawImage(ticketimage, new Point(0, 0));
            drawticket(name, time, date, cost, rad, mesto);
        }

        private void drawticket(string name, string time, string date, int cost,  int rad, int mesto)
        {
            Graphics g = Graphics.FromImage(ticketimage);
            g.DrawString(name, new Font("Microsoft Sans Serif", 8f), new SolidBrush(Color.Black), new PointF(340f, 40f));
           // g.DrawString(Convert.ToString(Count), new Font("Microsoft Sans Serif", 8f), new SolidBrush(Color.Black), new PointF(220f, 62f));
            g.DrawString(time, new Font("Microsoft Sans Serif", 8f), new SolidBrush(Color.Black), new PointF(324f, 85f));
            g.DrawString(date, new Font("Microsoft Sans Serif", 8f), new SolidBrush(Color.Black), new PointF(150f, 160f));
            g.DrawString(Convert.ToString(cost), new Font("Microsoft Sans Serif", 8f), new SolidBrush(Color.Black), new PointF(200f, 114f));
            g.DrawString(Convert.ToString(rad), new Font("Microsoft Sans Serif", 8f), new SolidBrush(Color.Black), new PointF(178f, 88f));
            g.DrawString(Convert.ToString(mesto), new Font("Microsoft Sans Serif", 8f), new SolidBrush(Color.Black), new PointF(242f, 88f));
            g.DrawString("Кинотеатр Беларусь", new Font("Microsoft Sans Serif", 8f), new SolidBrush(Color.Black), new PointF(280f, 160f));
            pictureBox1.Image = ticketimage;
        }
/*
         private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(ticketimage, new Point(0, 0));
        }
        */

        private void печатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(ticketimage, new Point(0, 0));
        }
    }
}


       
       