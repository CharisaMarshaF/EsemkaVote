using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EsemkaVote
{
    public partial class Form1 : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=SASA; Initial Catalog=EsemkaVote; Integrated Security=true");
        public Form1()
        {
            InitializeComponent();
            DataNama();
            getTable();
            LoadData("1");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getTable()
        {

        }

        private void DataNama()
        {
            using (SqlConnection conn = new SqlConnection(koneksi.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Id, Name, Description FROM [dbo].[VotingHeader]", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        comboBox1.DataSource = dataTable;
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "Id";
                    }
                }
            }
        }


        private void LoadData(string votedCandidateId)
        {
            flowLayoutPanel1.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(koneksi.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Reason FROM [dbo].[VotingDetail] WHERE VotedCandidateId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", votedCandidateId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            flowLayoutPanel1.Controls.Add(new RichTextBox
                            {
                                Text = reader["Reason"].ToString(),
                                Width = 300,
                                Height = 80,
                                ReadOnly = true,
                                BorderStyle = BorderStyle.FixedSingle
                            });
                        }
                    }
                }
                conn.Close();


                conn.Open();
                SqlCommand queryPersen = new SqlCommand("WITH VoteCounts AS (SELECT vc.EmployeeId AS CandidateId, e.Name AS NameEmployee, e.Photo, COUNT(vd.Id) AS VoteCount, vh.Name AS VotingName, vh.StartDate, vh.EndDate, (SELECT COUNT(*) FROM VotingCandidate WHERE VotingHeaderId = vc.VotingHeaderId) AS TotalCandidates FROM VotingDetail vd JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId JOIN VotingHeader vh ON vh.Id = vc.VotingHeaderId     JOIN Employee e ON e.Id = vc.EmployeeId WHERE vh.Id ="+votedCandidateId+" GROUP BY vc.EmployeeId, vh.Name, e.Name, e.Photo, vh.StartDate, vh.EndDate, vc.VotingHeaderId), Winner AS (SELECT TOP 1 *, SUM(VoteCount) OVER () AS TotalVotes FROM VoteCounts ORDER BY VoteCount DESC) SELECT CandidateId, NameEmployee, Photo, VoteCount, VotingName, StartDate, EndDate, (VoteCount * 100.0 / TotalVotes) AS WinnerPercentage, CONCAT(VoteCount, '/', TotalVotes) AS VoteFraction FROM Winner;", conn);

                SqlDataReader readerPersen = queryPersen.ExecuteReader();
                if (readerPersen.Read())
                {
                    name.Text = readerPersen["NameEmployee"].ToString();
                    totalvote.Text = "(" + readerPersen["VoteFraction"].ToString() + ")";
                    persentase.Text = Convert.ToDecimal(readerPersen["WinnerPercentage"]).ToString("F2") + "%";



                    string photoPath = @"D:\CHARISAMF\ITSSB\04022025\assets\";

                    if (readerPersen["Photo"] != DBNull.Value)
                    {
                        string fullPath = Path.Combine(photoPath, readerPersen["Photo"].ToString());
                        if (File.Exists(fullPath))
                        {
                            pictureBox1.ImageLocation = fullPath;
                        }
                        else
                        {
                            pictureBox1.ImageLocation = Path.Combine(photoPath, "Blank.jpg");
                        }
                    }
                    else
                    {
                        pictureBox1.ImageLocation = Path.Combine(photoPath, "Blank.jpg");
                    }

                }
                else
                {
                    name.Text = "Nama";
                    totalvote.Text = " (0/0)";
                    persentase.Text = "0%";
                    pictureBox1.ImageLocation = @"D:\CHARISAMF\ITSSB\04022025\assets\Blank.jpg";
                }

                conn.Close();


                conn.Open();
                SqlCommand queryVote = new SqlCommand(@"SELECT d.Name AS DivisionName, COUNT(vd.Id) AS VoteCount, FORMAT(COUNT(vd.Id) * 100.0 / (SELECT COUNT(*) FROM VotingDetail WHERE VotingHeaderId = vc.VotingHeaderId), 'N2') + ' %' AS Percentage FROM VotingDetail vd JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId JOIN VotingHeader vh ON vh.Id = vc.VotingHeaderId JOIN Employee e ON e.Id = vc.EmployeeId JOIN Division d ON d.Id = e.DivisionId WHERE vh.Id = @Id GROUP BY d.Name, vc.VotingHeaderId ORDER BY VoteCount DESC;", conn);
                queryVote.Parameters.AddWithValue("@Id", votedCandidateId);
                SqlDataAdapter adapter = new SqlDataAdapter(queryVote);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();





            }
        }

        //private void judul()
        //{

        //}


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
