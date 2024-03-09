using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace study_0511
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ConnectToDatabase(); // Form 로드 시 데이터베이스에 연결
        }
        private void ConnectToDatabase()
        {
            string connString = "User Id=system; Password=1234; Data Source=localhost:1521/xe";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Successfully connected to Oracle Database");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터베이스 연결에 실패했습니다: " + ex.Message);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text; // 사용자 ID 입력 받기
            string password = textBox2.Text; // 사용자 비밀번호 입력 받기

            // Oracle 데이터베이스 연결 문자열
            string connectionString = "User Id=system;Password=1234;Data Source=localhost:1521/xe;";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open(); // 데이터베이스 연결 열기

                    string query = "SELECT * FROM users WHERE user_id = :userId AND password = :password";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":userId", userId));
                        cmd.Parameters.Add(new OracleParameter(":password", password));

                        OracleDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            MessageBox.Show("아이디와 비밀번호가 확인되었습니다.");
                            Form2 form = new Form2();
                            form.ShowDialog();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("아이디 또는 비밀번호를 찾을 수 없습니다.");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터베이스 오류: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCount form = new FormCount();
            form.ShowDialog();
        }
    }
}