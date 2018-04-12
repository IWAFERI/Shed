﻿using System;
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
    public partial class kab : MaterialSkin.Controls.MaterialForm
    {
        public kab()
        {
            InitializeComponent();
        }

        static MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='shed';username=root;password=41Elaset");

        private void kab_Load(object sender, EventArgs e)
        {
            down();
        }

        public void down()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("slkab", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            materialSingleLineTextField1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            materialSingleLineTextField2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            materialSingleLineTextField3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            materialSingleLineTextField4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            materialSingleLineTextField5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string myConnection = "server=localhost;user=root;database=shed;port=3306;password=41Elaset;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();
            MySqlCommand cmd = new MySqlCommand("call addkab(@num, @tp, @count, @obid)", myConn);

            MySqlParameter MC = new MySqlParameter();
            MC = cmd.Parameters.Add("num", MySqlDbType.VarChar, 45);
            MC.Direction = ParameterDirection.Input;
            MC.Value = Convert.ToString(materialSingleLineTextField2.Text);

            MySqlParameter QT = new MySqlParameter();
            QT = cmd.Parameters.Add("tp", MySqlDbType.VarChar, 45);
            QT.Direction = ParameterDirection.Input;
            QT.Value = Convert.ToString(materialSingleLineTextField3.Text);

            MySqlParameter Q = new MySqlParameter();
            Q = cmd.Parameters.Add("count", MySqlDbType.VarChar, 45);
            Q.Direction = ParameterDirection.Input;
            Q.Value = Convert.ToString(materialSingleLineTextField3.Text);

            MySqlParameter QR = new MySqlParameter();
            QR = cmd.Parameters.Add("obid", MySqlDbType.VarChar, 45);
            QR.Direction = ParameterDirection.Input;
            QR.Value = Convert.ToString(materialSingleLineTextField3.Text);

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
            MySqlCommand cmd = new MySqlCommand("call dellkab(@id)", myConn);

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
            MySqlCommand cmd = new MySqlCommand("call updkabs(@id, @num, @tip, @count, @obid)", myConn);

            MySqlParameter MC = new MySqlParameter();
            MC = cmd.Parameters.Add("id", MySqlDbType.Int32);
            MC.Direction = ParameterDirection.Input;
            MC.Value = Convert.ToString(materialSingleLineTextField1.Text);

            MySqlParameter MS = new MySqlParameter();
            MS = cmd.Parameters.Add("num", MySqlDbType.VarChar, 45);
            MS.Direction = ParameterDirection.Input;
            MS.Value = Convert.ToString(materialSingleLineTextField1.Text);

            MySqlParameter DC = new MySqlParameter();
            DC = cmd.Parameters.Add("tip", MySqlDbType.VarChar, 45);
            DC.Direction = ParameterDirection.Input;
            DC.Value = Convert.ToString(materialSingleLineTextField1.Text);

            MySqlParameter D = new MySqlParameter();
            D = cmd.Parameters.Add("count", MySqlDbType.VarChar, 45);
            D.Direction = ParameterDirection.Input;
            D.Value = Convert.ToString(materialSingleLineTextField1.Text);

            MySqlParameter Dw = new MySqlParameter();
            Dw = cmd.Parameters.Add("obid", MySqlDbType.VarChar, 45);
            Dw.Direction = ParameterDirection.Input;
            Dw.Value = Convert.ToString(materialSingleLineTextField1.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Данные обновлены");

            myConn.Close();
            down();
        }
    }
}
