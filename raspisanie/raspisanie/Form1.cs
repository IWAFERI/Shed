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
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        

         MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='shed';username=root;password=41Elaset");
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            shedule shed = new shedule();
            shed.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            shedule shed = new shedule();
            shed.Show();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            editForm eForm = new editForm();
            eForm.Show();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            
        }
    }

    

        
        
    
}
