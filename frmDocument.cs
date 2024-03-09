using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Windows.Forms;

namespace study_0511
{
    public partial class frmDocument : Form
    {
        Hashtable ht = new Hashtable();
        public frmDocument()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void frmDocument_Load(object sender, EventArgs e)
        {

        }

        private void text_Click(object sender, EventArgs e)
        {
            string name = textName.Text;

            string connectionString = "User Id=system;Password=1234;Data Source=localhost:1521/xe;";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM infor WHERE name = :name";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":name", name));

                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textG.Text = reader.GetString(1); // gender
                        textAge.Text = reader.GetString(2); // age
                        textTel.Text = reader.GetString(3); // tel
                        textSe.Text = reader.GetString(4); // se
                        textAr.Text = reader.GetString(5); // ar
                        textdetail1.Text = reader.GetString(6); // detail1
                        textdetail2.Text = reader.GetString(7); // detail2
                        textDate.Text = reader.GetString(8); // date;
                        textYo.Text = reader.GetString(9); // yo
                    }
                    else
                    {
                        MessageBox.Show("해당 이름의 정보를 찾을 수 없습니다.");
                    }

                }
            }
        }

        private void addBt_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string gender = textG.Text;
            string age = textAge.Text;
            string tel = textTel.Text;
            string se = textSe.Text;
            string ar = textAr.Text;
            string detail1 = textdetail1.Text;
            string detail2 = textdetail2.Text;
            string timedate = textDate.Text;
            string yo = textYo.Text;

            string connectionString = "User Id=system;Password=1234;Data Source=localhost:1521/xe;";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO infor (name, gender, age, tel, se, ar, detail, detail2, timedate, yo) VALUES (:name, :gender, :age, :tel, :se, :ar, :detail, :detail2, :timedate, :yo)";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":name", name));
                    cmd.Parameters.Add(new OracleParameter(":gender", gender));
                    cmd.Parameters.Add(new OracleParameter(":age", age));
                    cmd.Parameters.Add(new OracleParameter(":tel", tel));
                    cmd.Parameters.Add(new OracleParameter(":se", se));
                    cmd.Parameters.Add(new OracleParameter(":ar", ar));
                    cmd.Parameters.Add(new OracleParameter(":detail", detail1));
                    cmd.Parameters.Add(new OracleParameter(":detail2", detail2));
                    cmd.Parameters.Add(new OracleParameter(":timedate", timedate));
                    cmd.Parameters.Add(new OracleParameter(":yo", yo));
                    //cmd.Parameters.Add(new OracleParameter(":date", dateTimePicker2));

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("정보가 성공적으로 추가되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("정보를 추가하는데 실패하였습니다.");
                    }
                }
            }

            // 텍스트 박스 초기화
            textName.Text = "";
            textG.Text = "";
            textAge.Text = "";
            textTel.Text = "";
            textSe.Text = "";
            textAr.Text = "";
            textdetail1.Text = "";
            textdetail2.Text = "";
            textYo.Text = "";
            textDate.Text = "";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}