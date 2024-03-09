using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace study_0511
{
    public partial class frmDocument2 : Form
    {
        public frmDocument2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmDocument2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textName.Text;

            string connectionString = "User Id=system;Password=1234;Data Source=localhost:1521/xe;";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT gender, age, tel, se, ar, timedate, yo, be, detail3 FROM infor WHERE name = :name";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":name", name));

                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textGen.Text = reader.GetString(0); // gender
                        textAge.Text = reader.GetString(1); // age
                        textTel.Text = reader.GetString(2); // tel
                        textSe.Text = reader.GetString(3); // se
                        textAr.Text = reader.GetString(4); // ar
                        textDate.Text = reader.GetString(5); // timedate
                        textYo.Text = reader.GetString(6); // yo
                        textBox2.Text = textDate.Text;
                        checkBox2.Checked = true;
                        textdetail1.Text = reader.GetString(7); // be
                        textdetail2.Text = reader.GetString(8); // detail3
                    }
                    else
                    {
                        MessageBox.Show("해당 이름의 정보를 찾을 수 없습니다.");
                    }

                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textdetail_5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textdetail1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
