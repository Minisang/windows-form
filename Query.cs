using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace study_0511
{
    public partial class Query : Form
    {
        public Query()
        {
            InitializeComponent();
        }

        private void Query_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=system;Password=1234;Data Source=localhost:1521/xe;";
            string userName = textBox1.Text.Trim();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT name AS ""이름"", gender AS ""성별"", age AS ""나이"", tel AS ""전화번호"", 
                             se AS ""주민번호"", ar AS ""주소"", timedate AS ""날짜"" 
                             FROM infor WHERE name = :userName";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("userName", userName));

                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = table;
                        }
                        else
                        {
                            MessageBox.Show("해당 이름의 정보를 찾을 수 없습니다.");
                            dataGridView1.DataSource = null; // 데이터가 없을 경우 DataGridView를 비웁니다.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터베이스 연결에 실패했습니다: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void oracleDataAdapter1_RowUpdated(object sender, OracleRowUpdatedEventArgs e)
        {

        }
    }
}
