using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sql_Bot;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        CRUD crud = new CRUD();
        public Form1()
        {
            InitializeComponent();
            READ();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // soll makierten eintrag aus daten bank löschen
            DELETE();
            READ();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // string aus der textbox in datenbase einfügen 
            CREATE();
            READ();
        }



        // read
        public void READ()
        {
            dataGridView1.DataSource = null;
            crud.Read_data();
            dataGridView1.DataSource = crud.dt;

        }
        // create
        public void CREATE()
        {

            crud.eintrag = eintragtxt.Text;

            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.eintrag = eintragtxt.Text;
            crud.id = ((int)id.Value);
            crud.Update_data();

        }

        public void DELETE()
        {
            crud.id = ((int)id.Value);
            crud.Delete_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // get data
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    eintragtxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    id.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch
            {

                MessageBox.Show("Irgendwas stimmt da nicht!");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UPDATE();
            READ();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
