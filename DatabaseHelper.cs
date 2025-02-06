using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaVote
{
    internal class DatabaseHelper
    {
        private readonly SqlConnection conn = new SqlConnection("Data Source = SASA; Initial Catalog=EsemkaVote; Integrated Security=true");
        public string photoPath = @"D:\CHARISAMF\ITSSB\04022025\assets\";

        public DataTable GetNama()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Description FROM [dbo].[VotingHeader]", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        private DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    DataTable dt = new DataTable();
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    return dt;
                }

            }
        }

        public DataTable GetReason(string voteCandidateId)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Reason FROM [dbo].[VotingDetail] WHERE VotedCandidateId = @id", conn);
                cmd.Parameters.AddWithValue("@id", voteCandidateId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable GetVotting(string voteCandidateId)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT d.Name AS DivisionName, COUNT(vd.Id) AS VoteCount FROM VotingDetail vd JOIN Employee e ON vd.EmployeeId = e.Id JOIN Division d ON e.DivisionId = d.Id JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId WHERE vc.VotingHeaderId = @votedCandidateId GROUP BY d.Name ORDER BY VoteCount DESC;", conn);

                cmd.Parameters.AddWithValue("@votedCandidateId", voteCandidateId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            if (dt.Rows.Count > 0)
            {
                int totalVotes = dt.AsEnumerable().Sum(row => row.Field<int>("VoteCount"));
                if (!dt.Columns.Contains("Percentage"))
                {
                    dt.Columns.Add("Percentage", typeof(string));
                }
                foreach (DataRow row in dt.Rows)
                {
                    int voteCount = row.Field<int>("VoteCount");
                    double percentage = totalVotes > 0 ? (voteCount * 100.0) / totalVotes : 0;
                    row["Percentage"] = $"{percentage:F2}%";
                }
            }

            return dt;
        }

        public string[] GetVote(string voteCandidateId, PictureBox pictureBox)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT vc.EmployeeId, e.Name AS NamaEmployee, e.Photo, COUNT(vd.Id) AS VoteCount FROM VotingDetail vd JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId JOIN Employee e ON e.Id = vc.EmployeeId WHERE  vc.VotingHeaderId = @votedCandidateId GROUP BY vc.EmployeeId, e.Name, e.Photo", conn);

                cmd.Parameters.AddWithValue("@votedCandidateId", voteCandidateId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                int totalVotes = dt.AsEnumerable().Sum(row => row.Field<int>("VoteCount"));
                if (!dt.Columns.Contains("WinnerPercentage"))
                {
                    dt.Columns.Add("WinnerPercentage", typeof(string));
                }

                var winner = dt.AsEnumerable().OrderByDescending(row => row.Field<int>("VoteCount")).First();

                string name = winner["NamaEmployee"].ToString();
                int voteCount = winner.Field<int>("VoteCount");

                string percentage = totalVotes > 0 ? ((double)voteCount / totalVotes * 100).ToString("F2") + "%" : "0%";
                string per = $"({voteCount}/{totalVotes})";
                SetImage(pictureBox, winner["Photo"].ToString());
                return [name, percentage, per];

            }
            else
            {

                pictureBox.ImageLocation = Path.Combine(photoPath, "Blank.jpg");
                return new string[] { "[Name Winner]", "0%", "(0/0)" };
            }


        }

        private void SetImage(PictureBox pictureBox, string fileName)
        {
            string fullPath = Path.Combine(photoPath, fileName ?? "default.jpg");
            pictureBox.ImageLocation = File.Exists(fullPath) ? fullPath : Path.Combine(photoPath, "default.jpg");
        }

    }
}
