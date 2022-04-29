
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestAPIKliens.Forms
{
    public partial class FormDry : Form
    {
        String URL = "http://127.0.0.1:3000/drystorage/";
        String URLuser = "http://127.0.0.1:3000/Users/";
        private List<Dry> DryList = new List<Dry>();
        public FormDry()
        {
            InitializeComponent();
            GetData();
        }
        //drystorage

        private void GetData()
        {
            
            
                ClearDataGridViewRows(dataGridDry, DryList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Dry>> response = client.Execute<List<Dry>>(request);
                foreach (Dry a in response.Data)
                {

                    DryList.Add(a);
                    //listcomp.Items.Add("Id: " + a.id + " Név: " + a.name + " Súly: " + a.weight + " Érkezési idő: " + a.arrived + "Honnan érkezett:" + a.place  );


                }
                dataGridDry.DataSource = DryList;
            
            

        }
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            
            GetData();


        }

        private void gtnGetById_Click(object sender, EventArgs e)
        {
            ClearDataGridViewRows(dataGridDry, DryList);
            
            //dataGridDry.Rows.Clear();
            
            
            // dataGridDry.Refresh();
            DryList.Clear();
            var client = new RestClient(URL);
            String ROUTE = txtGetById.Text;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Dry> response = client.Execute<Dry>(request);
            var content = response.Content;


            //Animal a = new Animal();
            //a = JsonSerializer.Deserialize<Animal>(content);
            //listcomp.Items.Add(content);

            string srt;
            srt= content;
            srt = srt.Substring(1, srt.Length - 2);
            Dry a = new Dry();
            a = JsonConvert.DeserializeObject<Dry>(srt);
            
            DryList.Add(a); 
            dataGridDry.DataSource = DryList;

            /*
            List<string> ContentList = new List<string>();
            ContentList = content.Split(':').ToList();
            //listcomp.Items.Add(content);
            Dry dry = new Dry();
           // dry.name = ContentList[0];
            
            listcomp.Items.Add(content);
            dataGridDry.DataSource = content;
            dataGridDry.Refresh();
            //DryList.Add(content);
            */

        }

        private void btnDeleteById_Click(object sender, EventArgs e)
        {/*
            var client = new RestClient(URL);
            String ROUTE = "delete/" + txtDeleteById.Text;
            var request = new RestRequest(ROUTE, Method.DELETE);
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);*/
        }
        public class Animal
        {

            public int id { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public int Legs { get; set; }
            public int Pet { get; set; }

        }
        public class Dry
        {

            public int id { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public DateTime arrived { get; set; }
            public string place { get; set; }

           
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            bool check=false;
            if (txtPostName.Text==""  )
            {

            }
            if (txtPostWeight == null)
            {

            }
            
            if (txtPostWeight == null)
            {

            }
            if (txtPostPlace.Text == "")
            {

            }
            if (!check)
            {
                Console.WriteLine("hiba");
            }
            else
            {


                var client = new RestClient(URL);
                String ROUTE = "post";
                var request = new RestRequest(ROUTE, Method.POST);
                request.RequestFormat = DataFormat.Json;
                DateTime theDate = dateTimePicker1.Value.Date;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                MessageBox.Show("Selected Date: " + dateTimePicker1.Text, "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    request.AddBody(new Dry
                    {
                        name = txtPostName.Text,
                        weight = int.Parse(txtPostWeight.Text),
                        arrived = theDate,
                        place = txtPostPlace.Text
                    });
                }
                catch (Exception)
                {

                    MessageBox.Show(
                      " Töltsd ki az adatokat!! ",
                      "Hiányzó adatok",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error
                     );
                }

                IRestResponse response = client.Execute(request);
                MessageBox.Show("Succesfully added.");
            }
        }

        private void btnPut_Click(object sender, EventArgs e)
        {/*
            DateTime theDate = dateTimePicker1.Value.Date;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            var client = new RestClient(URL);
            String ROUTE = "put/" + txtPutIdText.Text;
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Dry
            {

                name = txtPutName.Text,
                weight = int.Parse(txtPutAge.Text),
                arrived = theDate,
                place = txtPutValue.Text

                

            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);*/
        }

        private void dataGridRS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormDry_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearDataGridViewRows(dataGridDry,DryList);
        }
        public static void ClearDataGridViewRows(DataGridView dataGridView, List<Dry> DryList)
         {/*
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
              if (dataGridView.Rows.Count == 1) continue;
              dataGridView.Rows.RemoveAt(dataGridView.Rows.Count - 1);
            }*/
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            DryList.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void Delete()
        {
            int rowIndex = dataGridDry.CurrentCell.RowIndex;
            string tmp = dataGridDry.SelectedRows[0].Cells[0].Value.ToString();
            

            var client = new RestClient(URL);
            String ROUTE = "delete/" + tmp;
            var request = new RestRequest(ROUTE, Method.DELETE);
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
        }

        private void Put()
        {
            int rowIndex = dataGridDry.CurrentCell.RowIndex;
            string tmp = dataGridDry.SelectedRows[0].Cells[0].Value.ToString();

            DateTime theDate = dateTimePicker1.Value.Date;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            var client = new RestClient(URL);
            String ROUTE = "put/" + (int)dataGridDry.SelectedRows[0].Cells[0].Value;
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Dry
            {

                name = (string)dataGridDry.SelectedRows[0].Cells[1].Value,
                weight = (int)dataGridDry.SelectedRows[0].Cells[2].Value,
                arrived = (DateTime)dataGridDry.SelectedRows[0].Cells[3].Value,
                place = (string)dataGridDry.SelectedRows[0].Cells[4].Value



            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
        }

        private void dataGridDry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Put(); 
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Confirmation();
        }
        private void Confirmation()
        {
            DialogResult result = MessageBox.Show("Biztos Törölni akarod?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                Delete();
            }
            else
            {
                MessageBox.Show("Nem lett törölve");
            }
        }
        private void txtPostWeight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
