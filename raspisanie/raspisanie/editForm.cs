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
    public partial class editForm : MaterialSkin.Controls.MaterialForm
    {
        public editForm()
        {
            InitializeComponent();
        }

        private void editForm_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            teachers teach = new teachers();
            teach.Show();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            groups gr = new groups();
            gr.Show();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            objects obj = new objects();
            obj.Show();
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            kab kb = new kab();
            kb.Show();
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            times tim = new times();
            tim.Show();
        }
    }
}
