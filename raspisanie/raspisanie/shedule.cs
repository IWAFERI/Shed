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
    public partial class shedule: MaterialSkin.Controls.MaterialForm
    {
        static List<sh> list = new List<sh>();
        List<sh> list2 = new List<sh>();
        List<sh> list3 = new List<sh>();



        public shedule()
        {
            InitializeComponent();
            string query = "select fio, name from teachers, objects where idobjects = idteachers";
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();

            
            while (reader.Read())
                list.Add(new sh((string)reader["fio"], (string)reader["name"]));
            
            

            while (reader.Read())
                list2.Add(new sh((string)reader["fio"], (string)reader["name"]));

            while(reader.Read())
                list3.Add(new sh((string)reader["fio"], (string)reader["name"]));
            reader.Close();
            con.Close();
        }

       

        static MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='shed';username=root;password=41Elaset");

        private void shedule_Load(object sender, EventArgs e)
        {


            listView1.View = View.Details;
            listView1.Columns.Add("fio");
            listView1.Columns.Add("name");
            listView1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                listView1.Items.Add(list[i].Fio);
                listView1.Items[i].SubItems.Add(list[i].Name);
            }

            

            listView2.View = View.Details;
            listView2.Columns.Add("fio");
            listView2.Columns.Add("name");
            listView2.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                listView2.Items.Add(list[i].Fio);
                listView2.Items[i].SubItems.Add(list[i].Name);
            }


            //listView3.View = View.Details;
            //listView3.Columns.Add("fio");
            //listView3.Columns.Add("name");
            //listView3.Items.Clear();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    listView3.Items.Add(list[i].Fio);
            //    listView3.Items[i].SubItems.Add(list[i].Name);
            //}
        }

        public class sh
        {
            public string Fio;
            public string Name;
            public sh(string fio, string name)
            {
                Fio = fio;
                Name = name;
            }
        }

        public class Permutations
        {
            //Список перестановок
            private List<List<sh>> _permutationsList;
            private List<sh> _str;

            
            /// Добавляет новую перестановку в список
            
            private void AddToList(List<sh> a, bool repeat = true)
            {
                var bufer = new List<sh>();
                for (int i = 0; i < a.Count(); i++)
                {
                    bufer.Add(a[i]);
                }
                if (repeat || !_permutationsList.Contains(bufer))
                {
                    _permutationsList.Add(bufer);
                }

            }

            
            /// Рекурсивный поиск всех перестановок
            
            private void RecPermutation(List<sh> a, int n, bool repeat = true)
            {
                for (var i = 0; i < n; i++)
                {
                    var temp = a[n - 1];
                    for (var j = n - 1; j > 0; j--)
                    {
                        a[j] = a[j - 1];
                    }
                    a[0] = temp;
                    if (i < n - 1) AddToList(a, repeat);
                    if (n > 0) RecPermutation(a, n - 1, repeat);
                }
            }

            public Permutations()
            {
                _str = null; //
            }

            public Permutations(List<sh> str)
            { 
                _str = str; //
            }

            public void PermutArray()
            {
                int[] PermutVariction = new int[3] { 0, 0, 0 };
                for (int i = 0; i < PermutVariction.Length; i++)
                {
                    
                }
            }

            /// Строка, на основе которой строятся перестановки

            public List<sh>  PermutationStr
            {
                get
                {
                    return _str; //
                }
                set
                {
                    _str = value; //
                }
            }
            
            /// Получает список всех перестановок
            
            public List<List<sh>> GetPermutationsList(bool repeat = true)
            {
                _permutationsList = new List<List<sh>> { _str };
                RecPermutation(_str, _str.Count, repeat);
                return _permutationsList;
            }
            
            /// Получает отсортированный список всех перестановок
            
            public List<List<sh>> GetPermutationsSortList(bool repeat = true)
            {
                GetPermutationsList(repeat).Sort();
                return _permutationsList;
            }
        }

        public void PermutArr()
        {

            for (int i = 0; i < _permutationList.count; i++)
            {
                if (_permutationList[i] = list)
                {
                    numbers[i] = 0;
                }
                else {
                    numbers[i] += i;
                }
            }
        }

        public void ArrNum()
        {
            int[] numbers = new int[] { 0, 0, 0 };
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == 5)
                    {

                    }

                }
                Console.ReadLine();
        }

        public int intParam(int arrNum)
        {
            arrNum = numbers;
            return arrNum;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            
        }
    }

    
}
