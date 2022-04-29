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
    public partial class FormRS : Form
    {
        String URL = "http://127.0.0.1:3000/drystorage/";
        private List<RS> DryList = new List<RS>();

        public FormRS()
        {
            InitializeComponent();
            LoadTheme();
            GetData();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn= (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            //label1.ForeColor = ThemeColor.SecondaryColor;
            //label2.ForeColor = ThemeColor.SecondaryColor;
            //.ForeColor = ThemeColor.SecondaryColor;
        }

        private void GetData()
        {


            ClearDataGridViewRows(dataGridDry, DryList);

            var client = new RestClient(URL);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<RS>> response = client.Execute<List<RS>>(request);
            foreach (RS a in response.Data)
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
            IRestResponse<RS> response = client.Execute<RS>(request);
            var content = response.Content;


            //Animal a = new Animal();
            //a = JsonSerializer.Deserialize<Animal>(content);
            //listcomp.Items.Add(content);

            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            RS a = new RS();
            a = JsonConvert.DeserializeObject<RS>(srt);

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

        public class RS
        {

            public int id { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public DateTime arrived { get; set; }
            public DateTime butchered { get; set; }
            public string place { get; set; }

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (txtPostName.Text == "")
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
                    request.AddBody(new RS
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

        public static void ClearDataGridViewRows(DataGridView dataGridView, List<RS> DryList)
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
            request.AddJsonBody(new RS
            {

                name = (string)dataGridDry.SelectedRows[0].Cells[1].Value,
                weight = (int)dataGridDry.SelectedRows[0].Cells[2].Value,
                arrived = (DateTime)dataGridDry.SelectedRows[0].Cells[3].Value,
                place = (string)dataGridDry.SelectedRows[0].Cells[4].Value



            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
