using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EsemkaVote
{
    public partial class Form1 : Form
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();
        public Form1()
        {
            InitializeComponent();
            getTable();
            LoadNama();
            LoadData("1");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getTable()
        {

        }

        private void LoadNama()
        {

            DataTable dt = dbHelper.GetNama();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }



        private void LoadData(string voteCandidateId)
        {
            flowLayoutPanel1.Controls.Clear();

            DataTable reason = dbHelper.GetReason(voteCandidateId);

            foreach (DataRow dr in reason.Rows)
            {
                flowLayoutPanel1.Controls.Add(new RichTextBox
                {
                    Text = dr["Reason"].ToString(),
                    Width = 300,
                    Height = 80,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.FixedSingle
                });
            }

            DataTable voting = dbHelper.GetVotting(voteCandidateId);
            dataGridView1.DataSource = voting;

            string[] canvote = dbHelper.GetVote(voteCandidateId, pictureBox1);

            name.Text = canvote[0];
            persentase.Text = canvote[1];
            totalvote.Text = canvote[2];


        }





        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && !(comboBox1.SelectedValue is System.Data.DataRowView))
            {
                string selectedId = comboBox1.SelectedValue.ToString();
                LoadData(selectedId);

            }


            if (comboBox1.SelectedItem is DataRowView row)
            {
                judul.Text = row["Name"].ToString();
                subjudul.Text = row["Description"].ToString();


                if (comboBox1.SelectedValue is string selectedId)
                {
                    LoadData(selectedId);
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void judul_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void persentase_Click(object sender, EventArgs e)
        {

        }

        private void totalvote_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
