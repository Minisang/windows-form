using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace study_0511
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string userId = textId.Text; // id
            string password = textPw.Text; // pw

            string connectionString = "User Id=system;Password=1234;Data Source=localhost:1521/xe;";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "delete from users where user_id=:userId and password=:password";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":userId", userId));
                        cmd.Parameters.Add(new OracleParameter(":password", password));

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("아이디와 비밀번호가 성공적으로 삭제되었습니다.");
                        }
                        else
                        {
                            MessageBox.Show("아이디와 비밀번호를 삭제하는데 실패하였습니다.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터베이스 오류: " + ex.Message);
                }
            }
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
        }
    }
}
