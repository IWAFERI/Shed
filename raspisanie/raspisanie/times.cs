using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace raspisanie
{
    public partial class times : MaterialSkin.Controls.MaterialForm
    {
        public times()
        {
            InitializeComponent();
        }

        private void times_Load(object sender, EventArgs e)
        {
            down();
        }

        static MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='shed';username=root;password=41Elaset");

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            materialSingleLineTextField1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            materialSingleLineTextField2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            materialSingleLineTextField3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
        }

        public void down()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("sltime", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string myConnection = "server=localhost;user=root;database=shed;port=3306;password=41Elaset;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();
            MySqlCommand cmd = new MySqlCommand("call addtime(@nach, @kon)", myConn);

            MySqlParameter MC = new MySqlParameter();
            MC = cmd.Parameters.Add("nach", MySqlDbType.VarChar, 45);
            MC.Direction = ParameterDirection.Input;
            MC.Value = Convert.ToString(materialSingleLineTextField2.Text);

            MySqlParameter QT = new MySqlParameter();
            QT = cmd.Parameters.Add("kon", MySqlDbType.VarChar, 45);
            QT.Direction = ParameterDirection.Input;
            QT.Value = Convert.ToString(materialSingleLineTextField3.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Данные добавлены");

            myConn.Close();
            down();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            string myConnection = "server=localhost;user=root;database=shed;port=3306;password=41Elaset;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();
            MySqlCommand cmd = new MySqlCommand("call delltime(@id)", myConn);

            MySqlParameter MC = new MySqlParameter();
            MC = cmd.Parameters.Add("id", MySqlDbType.VarChar, 45);
            MC.Direction = ParameterDirection.Input;
            MC.Value = Convert.ToString(materialSingleLineTextField1.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Данные удалены");

            myConn.Close();
            down();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            string myConnection = "server=localhost;user=root;database=shed;port=3306;password=41Elaset;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();
            MySqlCommand cmd = new MySqlCommand("call updkabs(@id, @nach, @kon)", myConn);

            MySqlParameter MC = new MySqlParameter();
            MC = cmd.Parameters.Add("id", MySqlDbType.Int32);
            MC.Direction = ParameterDirection.Input;
            MC.Value = Convert.ToString(materialSingleLineTextField1.Text);

            MySqlParameter MS = new MySqlParameter();
            MS = cmd.Parameters.Add("nach", MySqlDbType.VarChar, 45);
            MS.Direction = ParameterDirection.Input;
            MS.Value = Convert.ToString(materialSingleLineTextField1.Text);

            MySqlParameter DC = new MySqlParameter();
            DC = cmd.Parameters.Add("kon", MySqlDbType.VarChar, 45);
            DC.Direction = ParameterDirection.Input;
            DC.Value = Convert.ToString(materialSingleLineTextField1.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Данные обновлены");

            myConn.Close();
            down();
        }
    }
}
