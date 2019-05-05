using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema
{
    public partial class addkino : Form
    {
        public static int ob=0;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;
        BindingSource bis;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        int prov = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
            }
        
        public addkino()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=USERPC\SQLEXPRESS;Initial Catalog=dbcin;Integrated Security=True;Pooling=False");
            comboBox4.Visible = false;
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            timer = new Timer() { Interval = 100 };
            //     timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();

            label25.Visible = false;
            label24.Visible = false;
            comboBox7.Visible = false;
            comboBox8.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            comboBox5.Visible = false;
            checkBox1.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            textBox1.Visible = false;

            textBox3.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;

            label1.Visible = false;
            comboBox4.Visible = false;
            textBox2.Visible = false;
            label2.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
        }

        public string   jn;
        public int index;

        public void filmakter()
        {

            con.Open();
          //  indexf();
            cmd = new SqlCommand("SELECT DISTINCT film.fname,akter.name   FROM film,akter,uchastniki where  uchastniki.id_film=film.id_film and uchastniki.id_akter=akter.id_akter ");

            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView1.DataSource = bSource;
            da.Update(dt);
            // dt2();
            dataGridView1.Columns[0].HeaderText = "Фильм";
            dataGridView1.Columns[1].HeaderText = "В ролях";
            con.Close();
        }

        public void film()
        {

            con.Open();
            cmd = new SqlCommand("SELECT fname FROM film ");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView5.DataSource = bSource;
            //  index = Convert.ToInt16(dataGridView3.Rows[0].Cells[0].Value);
            //label6.Text = index.ToString();
            da.Update(dt);

            con.Close();
            comboBox4.Items.Clear();
            for (int i = 0; i < dataGridView5.RowCount - 1; i++)
            { comboBox4.Items.Add(dataGridView5.Rows[i].Cells[0].Value); }
        }

        public void janr()
        {

            con.Open();
            cmd = new SqlCommand("SELECT janr FROM janr ");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView4.DataSource = bSource;
            da.Update(dt);
           
                con.Close();
                comboBox2.Items.Clear();
             for (int i = 0; i < dataGridView4.RowCount-1; i++)
              { comboBox2.Items.Add(dataGridView4.Rows[i].Cells[0].Value); }
        }

        public void indexf()
        {
           
            string fname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            cmd = new SqlCommand("SELECT id_film   FROM film where  film.fname= '" + fname + "' ");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView3.DataSource = bSource;
            index = Convert.ToInt16(dataGridView3.Rows[0].Cells[0].Value);
            label6.Text = index.ToString();
            da.Update(dt);
          
        }
        public void akter()
        {
            con.Open();
            indexf();
            cmd = new SqlCommand("SELECT DISTINCT akter.name   FROM film,akter,uchastniki where  uchastniki.id_film='" + index + "' and uchastniki.id_akter=akter.id_akter ");
           
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView2.DataSource = bSource;
            da.Update(dt);
           // dt2();
            dataGridView2.Columns[0].HeaderText = "В ролях";
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true)
            {
                if (radioButton1.Checked)
                {
                    if (textBox1.Text != "" && comboBox7.Text != "" && comboBox8.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                    {
                        ob = 1;
                        con.Open();



                        cmd = new SqlCommand("SELECT DISTINCT vozrast.id_vozrast FROM vozrast where  vozrast.vozrast='" + comboBox1.Text + "'");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        BindingSource bSource = new BindingSource();
                        bSource.DataSource = dt;
                        label13.Text = dt.Rows[0]["id_vozrast"].ToString().Trim();
                        da.Update(dt);

                        cmd = new SqlCommand("SELECT DISTINCT janr.id_janr FROM janr where  janr.janr='" + comboBox2.Text + "'");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        bSource.DataSource = dt;
                        label14.Text = dt.Rows[0]["id_janr"].ToString().Trim();
                        da.Update(dt);

                        cmd = new SqlCommand("SELECT strana.proizvodstva FROM strana ");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        bSource.DataSource = dt;
                        dataGridView6.DataSource = bSource;
                        da.Update(dt);
                        prov = 0;
                        for (int i = 0; i < dataGridView6.RowCount; i++)
                        {
                            if (dataGridView6.Rows[i].Cells[0].Value.ToString() == textBox7.Text)
                            {
                                cmd = new SqlCommand("SELECT DISTINCT strana.id_proizvodstva FROM strana where  strana.proizvodstva='" + textBox7.Text + "'");
                                cmd.Connection = con;
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                bSource.DataSource = dt;
                                label15.Text = dt.Rows[0]["id_proizvodstva"].ToString().Trim();
                                da.Update(dt);
                                prov = 1;
                            }
                            else
                            {
                                if (i == dataGridView6.RowCount - 1 && prov != 1)
                                {
                                    cmd = new SqlCommand("insert into strana (proizvodstva)  values ('" + textBox7.Text + "')");
                                    cmd.Connection = con;
                                    da = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    da.Fill(dt);
                                    bSource.DataSource = dt;
                                    da.Update(dt);

                                    cmd = new SqlCommand("SELECT DISTINCT strana.id_proizvodstva FROM strana where  strana.proizvodstva='" + textBox7.Text + "'");
                                    cmd.Connection = con;
                                    da = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    da.Fill(dt);
                                    bSource.DataSource = dt;
                                    label15.Text = dt.Rows[0]["id_proizvodstva"].ToString().Trim();
                                    da.Update(dt);
                                }
                            }
                        }
                        prov = 0;

                        for (int i = 0; i < dataGridView6.RowCount; i++)
                        {
                            if (dataGridView6.Rows[i].Cells[0].Value.ToString() == textBox7.Text)
                            {
                                cmd = new SqlCommand("SELECT DISTINCT produser.id_produser FROM produser where  produser.name='" + textBox8.Text + "'");
                                cmd.Connection = con;
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                bSource.DataSource = dt;
                                label16.Text = dt.Rows[0]["id_produser"].ToString().Trim();
                                da.Update(dt);
                                prov = 1;
                            }
                            else
                            {
                                if (i == dataGridView6.RowCount - 1 && prov != 1)
                                {
                                    cmd = new SqlCommand("insert into produser (name)  values ('" + textBox8.Text + "')");
                                    cmd.Connection = con;
                                    da = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    da.Fill(dt);
                                    bSource.DataSource = dt;
                                    da.Update(dt);

                                    cmd = new SqlCommand("SELECT DISTINCT produser.id_produser FROM produser where  produser.name='" + textBox8.Text + "'");
                                    cmd.Connection = con;
                                    da = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    da.Fill(dt);
                                    bSource.DataSource = dt;
                                    label16.Text = dt.Rows[0]["id_produser"].ToString().Trim();
                                    da.Update(dt);
                                    con.Close();
                                }
                            }
                        }

                        cmd = new SqlCommand("SELECT DISTINCT format.id_format FROM format where format.format='" + comboBox3.Text + "'");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        bSource.DataSource = dt;
                        label17.Text = dt.Rows[0]["id_format"].ToString().Trim();
                        da.Update(dt);


                        label22.Text = dateTimePicker1.Value.ToShortDateString();
                        label23.Text = dateTimePicker2.Value.ToShortDateString();


                        cmd = new SqlCommand("insert into film (fname,long,start,finish,cost,id_vozrastogr,id_janr,id_strana,id_produser,id_format,description) values ('" + textBox1.Text + "','" + comboBox7.Text + ":" + comboBox8.Text + ":00" + "','" + label22.Text + "','" + label23.Text + "','" + textBox3.Text + "','" + label13.Text + "','" + label14.Text + "','" + label15.Text + "','" + Convert.ToInt16(label16.Text) + "','" + Convert.ToInt16(label17.Text) + "','" + textBox4.Text + "')");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        bSource.DataSource = dt;
                        da.Update(dt);

                        cmd = new SqlCommand("SELECT fname , long, start, finish, cost, vozrast,  janr,  proizvodstva , produser.name,format,description  FROM film,vozrast,janr,strana,produser,format where film.id_vozrastogr=vozrast.id_vozrast and  film.id_janr=janr.id_janr and film.id_strana=strana.id_proizvodstva and film.id_produser=produser.id_produser and film.id_format=format.id_format ");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        bSource.DataSource = dt;
                        dataGridView1.DataSource = bSource;
                        da.Update(dt);
                        con.Close();
                    }
                    else { MessageBox.Show("Введите данные !"); }
                }
                if (radioButton2.Checked)
                {
                    if (comboBox7.Text != "" && comboBox8.Text != "" && comboBox4.Text != "")
                    {
                        con.Open();



                        cmd = new SqlCommand("SELECT DISTINCT film.id_film FROM film where  film.fname='" + comboBox4.Text + "'");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        BindingSource bSource = new BindingSource();
                        bSource.DataSource = dt;
                        label11.Text = dt.Rows[0]["id_film"].ToString().Trim();
                        da.Update(dt);

                        label12.Text = dateTimePicker1.Value.ToShortDateString();
                        cmd = new SqlCommand("insert into seansi(date,time,id_film) values ('" + label12.Text + "','" + comboBox7.Text + ":" + comboBox8.Text + ":00" + "','" + Convert.ToInt16(label11.Text) + "')");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        da.Update(dt);

                        cmd = new SqlCommand("SELECT film.fname,seansi.date ,seansi.time  FROM film,seansi where film.id_film=seansi.id_film ");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        bSource.DataSource = dt;
                        dataGridView1.DataSource = bSource;
                        da.Update(dt);

                        con.Close();
                    }
                    else { MessageBox.Show("Введите данные !"); }
                }

                if (radioButton4.Checked)
                {

                    if (comboBox4.Text != "" && textBox2.Text != "")
                    {
                        con.Open();
                        con.Close();
                        con.Close();
                        con.Open();
                        ob = 1;





                        cmd = new SqlCommand("SELECT DISTINCT akter.name   FROM film,akter,uchastniki ");

                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        BindingSource bSource = new BindingSource();
                        bSource.DataSource = dt;
                        dataGridView8.DataSource = bSource;
                        da.Update(dt);
                        // dt2();
                        //  dataGridView2.Columns[0].HeaderText = "В ролях";

                        for (int i = 0; i < dataGridView8.RowCount; i++)
                        {
                            if (dataGridView8.Rows[i].Cells[0].Value.ToString() == textBox2.Text)
                            { break; }
                            else
                            {
                                if (i == dataGridView8.RowCount - 1)
                                {
                                    cmd = new SqlCommand("insert into akter (name) values ('" + textBox2.Text + "')");
                                    cmd.Connection = con;
                                    da = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    da.Fill(dt);
                                    //BindingSource bSource = new BindingSource();
                                    bSource.DataSource = dt;
                                    dataGridView1.DataSource = bSource;
                                    da.Update(dt);
                                }
                            }
                        }
                        cmd = new SqlCommand("SELECT DISTINCT film.id_film FROM film where  film.fname='" + comboBox4.Text + "'");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        bSource.DataSource = dt;
                        label11.Text = dt.Rows[0]["id_film"].ToString().Trim();
                        da.Update(dt);

                        cmd = new SqlCommand("SELECT DISTINCT akter.id_akter FROM akter where  akter.name = '" + textBox2.Text + "'");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        label12.Text = dt.Rows[0]["id_akter"].ToString().Trim();
                        da.Update(dt);


                        // dataGridView8.RowCount = 0;
                        cmd = new SqlCommand("SELECT  *   FROM uchastniki ");
                        cmd.Connection = con;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        // BindingSource bSource = new BindingSource();
                        bSource.DataSource = dt;
                        dataGridView8.DataSource = bSource;
                        da.Update(dt);

                        for (int i = 0; i < dataGridView8.RowCount; i++)
                        {
                            if (dataGridView8.Rows[i].Cells[0].Value.ToString() == label11.Text && dataGridView8.Rows[i].Cells[1].Value.ToString() == label12.Text)
                            { break; }
                            else
                            {
                                if (i == dataGridView8.RowCount - 1)
                                {

                                    cmd = new SqlCommand("insert into uchastniki values ('" + label11.Text + "','" + label12.Text + "')");
                                    cmd.Connection = con;
                                    da = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    da.Fill(dt);
                                    da.Update(dt);
                                    con.Close();
                                    filmakter();
                                }
                            }
                        }

                    }
                    else { MessageBox.Show("Введите данные !"); }
                    con.Close();

                }

            }
            else { MessageBox.Show("Не выбрана операция"); }
        }
        private void button2_Click(object sender, EventArgs e)
        {

             if (radioButton1.Checked)
           {
               con.Open();
               ob = 1;
               
              cmd = new SqlCommand("SELECT DISTINCT film.id_film FROM film where  film.fname='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               BindingSource bSource = new BindingSource();
               bSource.DataSource = dt;
               label11.Text = dt.Rows[0]["id_film"].ToString().Trim();
               da.Update(dt);

               cmd = new SqlCommand("  SELECT  seansi.id_seansi,film.fname,seansi.date ,seansi.time  FROM film,seansi where film.id_film=seansi.id_film and seansi.id_film='" + label11.Text + "' ");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               bSource.DataSource = dt;
               dataGridView7.DataSource = bSource;
               da.Update(dt);

               if (dataGridView7.RowCount != 0)
               {
                   for (int i = 0; i < dataGridView7.RowCount; i++)
                   {
                       cmd = new SqlCommand("delete  from bilet where bilet.id_seans='" + dataGridView7.Rows[i].Cells[0].Value.ToString() + "'");
                       cmd.Connection = con;
                       da = new SqlDataAdapter(cmd);
                       dt = new DataTable();
                       da.Fill(dt);
                       da.Update(dt);
                   }
                   cmd = new SqlCommand("delete from seansi where id_film='" + label11.Text + "'");
                   cmd.Connection = con;
                   da = new SqlDataAdapter(cmd);
                   dt = new DataTable();
                   da.Fill(dt);
                   da.Update(dt);

                   cmd = new SqlCommand("delete from uchastniki where id_film='" + label11.Text + "'");
                   cmd.Connection = con;
                   da = new SqlDataAdapter(cmd);
                   dt = new DataTable();
                   da.Fill(dt);
                   da.Update(dt);
               }
               cmd = new SqlCommand("delete from film where id_film='" + label11.Text + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               da.Update(dt);

            
               cmd = new SqlCommand("SELECT fname , long, start, finish, cost, vozrast,  janr,  proizvodstva , produser.name,format,description  FROM film,vozrast,janr,strana,produser,format where film.id_vozrastogr=vozrast.id_vozrast and  film.id_janr=janr.id_janr and film.id_strana=strana.id_proizvodstva and film.id_produser=produser.id_produser and film.id_format=format.id_format ");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               bSource.DataSource = dt;
               dataGridView1.DataSource = bSource;
               da.Update(dt);
               con.Close();

             }
           if (radioButton2.Checked)
           {
               con.Open();

               cmd = new SqlCommand("SELECT DISTINCT film.id_film FROM film where  film.fname='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               BindingSource bSource = new BindingSource();
               bSource.DataSource = dt;
               label11.Text = dt.Rows[0]["id_film"].ToString().Trim();
               da.Update(dt);

               cmd = new SqlCommand("SELECT DISTINCT seansi.id_seansi FROM seansi,film where seansi.id_film = '" + label11.Text + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               label12.Text = dt.Rows[0]["id_seansi"].ToString().Trim();
               da.Update(dt);

               cmd = new SqlCommand("delete from bilet where id_seans='" + label12.Text + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               da.Update(dt);

               cmd = new SqlCommand("delete from seansi where id_seansi='" + label12.Text + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               da.Update(dt);

               cmd = new SqlCommand("SELECT film.fname,seansi.date ,seansi.time  FROM film,seansi where film.id_film=seansi.id_film ");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               bSource.DataSource = dt;
               dataGridView1.DataSource = bSource;
               da.Update(dt);

               con.Close();

           }
           if (radioButton3.Checked)
           {
               con.Open();



               cmd = new SqlCommand("SELECT DISTINCT mesto.id_mesto FROM mesto where  mesto.mesto='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "' and mesto.rad='" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "' ");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               BindingSource bSource = new BindingSource();

               bSource.DataSource = dt;
               label11.Text = dt.Rows[0]["id_mesto"].ToString().Trim();
               da.Update(dt);
              
               
               cmd = new SqlCommand("delete from bilet where id_mesto='" + label11.Text + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               da.Update(dt);

               cmd = new SqlCommand("SELECT  DISTINCT  film.fname,seansi.date ,seansi.time,sostojanie.sostojanie,mesto.rad,mesto.mesto  FROM film,sostojanie,seansi,bilet,mesto where  film.id_film=seansi.id_film and  seansi.id_seansi=bilet.id_seans and bilet.id_sostojanie=sostojanie.id_sostojanie and bilet.id_mesto=mesto.id_mesto ");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               bSource.DataSource = dt;
               dataGridView1.DataSource = bSource;
               da.Update(dt);
               con.Close();
           
           }
           if (radioButton4.Checked)
           {
               con.Open();

               ob = 1;
               cmd = new SqlCommand("SELECT DISTINCT film.id_film FROM film where  film.fname='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               BindingSource bSource = new BindingSource();
               bSource.DataSource = dt;
               label11.Text = dt.Rows[0]["id_film"].ToString().Trim();
               da.Update(dt);

               cmd = new SqlCommand("SELECT DISTINCT akter.id_akter FROM akter where  akter.name = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               label12.Text = dt.Rows[0]["id_akter"].ToString().Trim();
               da.Update(dt);

               cmd = new SqlCommand("delete from uchastniki where id_film='" + label11.Text + "' and id_akter='" + label12.Text + "'");
               cmd.Connection = con;
               da = new SqlDataAdapter(cmd);
               dt = new DataTable();
               da.Fill(dt);
               da.Update(dt);
               con.Close();

               filmakter();

              
           }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            label25.Visible = true;
            label24.Visible = true;
            comboBox7.Visible = true;
            comboBox8.Visible = true;
            label20.Visible = false;
            label21.Visible = false;
            comboBox5.Visible = false;
            checkBox1.Visible = false;
            button1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            label2.Text = "Продолжительность сеанса";
            label3.Text = "Дата начала проката";
            label4.Text = "Дата окончания проката";
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            button2.Visible = true;
            label10.Visible = true;
            dataGridView2.Visible = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            comboBox4.Visible = false;
            con.Open();
            cmd = new SqlCommand("SELECT fname , long, start, finish, cost, vozrast,  janr,  proizvodstva , produser.name,format,description  FROM film,vozrast,janr,strana,produser,format where film.id_vozrastogr=vozrast.id_vozrast and  film.id_janr=janr.id_janr and film.id_strana=strana.id_proizvodstva and film.id_produser=produser.id_produser and film.id_format=format.id_format ");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView1.DataSource = bSource;
            da.Update(dt);
            dataGridView1.Columns[0].HeaderText = "Название фильма";
            dataGridView1.Columns[1].HeaderText = "Длительность";
            dataGridView1.Columns[2].HeaderText = "Дата начала проката";
            dataGridView1.Columns[3].HeaderText = "Дата окончания проката";
            dataGridView1.Columns[4].HeaderText = "Цена билета";
            dataGridView1.Columns[5].HeaderText = "Возрастное ограничение";
            dataGridView1.Columns[6].HeaderText = "Жанр";
            dataGridView1.Columns[7].HeaderText = "Производство";
            dataGridView1.Columns[8].HeaderText = "Продюсер";
            dataGridView1.Columns[9].HeaderText = "Формат";
            dataGridView1.Columns[10].HeaderText = "Описание";
            
            con.Close();
            janr();
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            label25.Visible = false;
            label24.Visible = true;
            comboBox7.Visible = true;
            comboBox8.Visible = true;
            label20.Visible = false;
            label21.Visible = false;
            comboBox5.Visible = false;
            checkBox1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            button1.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = false;
            textBox3.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = true;
            label3.Text = "Дата начала сеанса";
            label2.Text = "Время начала сеанса";
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            dataGridView2.Visible = false;
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            textBox4.Visible = false;
            button2.Visible = true;
            con.Open();
            cmd = new SqlCommand("SELECT film.fname,seansi.date ,seansi.time  FROM film,seansi where film.id_film=seansi.id_film ");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView1.DataSource = bSource;
            da.Update(dt);

            dataGridView1.Columns[0].HeaderText = "Название фильма";
            dataGridView1.Columns[1].HeaderText = "Дата начала сеанса";
            dataGridView1.Columns[2].HeaderText = "Время начала сеанса";

            con.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label25.Visible = false;
            label20.Visible = true;
            label21.Visible = true;
            comboBox5.Visible = true;
            checkBox1.Visible = true;
            label24.Visible = false;
            comboBox7.Visible = false;
            comboBox8.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Visible = false;
            dataGridView2.Visible = false;
            radioButton2.Checked = false;
            radioButton1.Checked = false;
            comboBox4.Visible = false;
            button2.Visible = true;
            con.Open();
            cmd = new SqlCommand("SELECT  DISTINCT  film.fname,seansi.date ,seansi.time,sostojanie.sostojanie,mesto.rad,mesto.mesto  FROM film,sostojanie,seansi,bilet,mesto where  film.id_film=seansi.id_film and  seansi.id_seansi=bilet.id_seans and bilet.id_sostojanie=sostojanie.id_sostojanie and bilet.id_mesto=mesto.id_mesto ");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView1.DataSource = bSource;
            da.Update(dt);
          
            dataGridView1.Columns[0].HeaderText = "Название фильма";
            dataGridView1.Columns[1].HeaderText = "Дата начала сеанса";
            dataGridView1.Columns[2].HeaderText = "Время начала сеанса";
            dataGridView1.Columns[3].HeaderText = "Состояние";
            dataGridView1.Columns[4].HeaderText = "Ряд";
            dataGridView1.Columns[5].HeaderText = "Место";
            
            con.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            akter();
        }

        private void comboBox4_MouseDown(object sender, MouseEventArgs e)
        {
            film();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            filmakter();
            label25.Visible = false;
            label24.Visible = false;
            comboBox7.Visible = false;
            comboBox8.Visible = false;
            label1.Visible = true;
            comboBox4.Visible = true;
            textBox2.Visible = true;
            label2.Visible = true;
            label2.Text = "Актер";
            button1.Visible = true;
            button2.Visible = true;

            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            textBox1.Visible = false;
          
            textBox3.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
           
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            
            dataGridView2.Visible = false;
            radioButton2.Checked = false;
            radioButton1.Checked = false;

            label20.Visible = false;
            label21.Visible = false;
            comboBox5.Visible = false;
            checkBox1.Visible = false;
            
        }

        private void comboBox5_MouseDown(object sender, MouseEventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("SELECT fname FROM film ");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView5.DataSource = bSource;
          
            da.Update(dt);

            con.Close();
            comboBox5.Items.Clear();
            for (int i = 0; i < dataGridView5.RowCount - 1; i++)
            { comboBox5.Items.Add(dataGridView5.Rows[i].Cells[0].Value); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                con.Open();
                cmd = new SqlCommand("SELECT  DISTINCT  film.fname,seansi.date ,seansi.time,sostojanie.sostojanie,mesto.rad,mesto.mesto  FROM film,sostojanie,seansi,bilet,mesto where  film.id_film=seansi.id_film and  seansi.id_seansi=bilet.id_seans and bilet.id_sostojanie=sostojanie.id_sostojanie and bilet.id_mesto=mesto.id_mesto ");
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dt;
                dataGridView1.DataSource = bSource;
                da.Update(dt);
                con.Close();
            }
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT  DISTINCT  film.fname,seansi.date ,seansi.time,sostojanie.sostojanie,mesto.rad,mesto.mesto  FROM film,sostojanie,seansi,bilet,mesto where  film.id_film=seansi.id_film and  seansi.id_seansi=bilet.id_seans and bilet.id_sostojanie=sostojanie.id_sostojanie and bilet.id_mesto=mesto.id_mesto and film.fname= '" + comboBox5.Text + "' ");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView1.DataSource = bSource;
            da.Update(dt);
            con.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && !((e.KeyChar == '.' )))
            {
                e.Handled = true;
            }
        }
    }
}
