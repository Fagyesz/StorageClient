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

    public partial class FormBasin : Form
    {
        String URL = "http://127.0.0.1:3000/basin/";
        private List<Basin> RSList = new List<Basin>();
        private static DateTime DataTimePut1 = new DateTime();
        public static FormBasin Self;

        public FormBasin()
        {
            InitializeComponent();
            GetData();
            LoadTheme();
            Self = this;
        }
        private void LoadTheme()
        {
            panelSelector.BackColor = ThemeColor.SecondaryColor;
            panelSelector.ForeColor = Color.White;
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
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

        internal Scrap DataToScrapBasin()
        {

            Scrap SC = new Scrap();

            SC.bid = (int)dataGridBasin.SelectedRows[0].Cells[0].Value;
            SC.name = (string)dataGridBasin.SelectedRows[0].Cells[1].Value;
            SC.weight = (int)dataGridBasin.SelectedRows[0].Cells[2].Value;

            return SC;
        }
        

       

        private void GetData()
        {
            try { 

            ClearDataGridViewRows(dataGridBasin, RSList);

            var client = new RestClient(URL);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<Basin>> response = client.Execute<List<Basin>>(request);
            foreach (Basin a in response.Data)
            {

                RSList.Add(a);

            }
            dataGridBasin.DataSource = RSList;
                DataGridDateFormating();
            }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges " + e.Message);
            }


        }

        internal void DeleteBySC()
        {
            Delete();
        }

        internal void ScrapDel(int weight)
        {
            int rowIndex = dataGridBasin.CurrentCell.RowIndex;
            string tmp = dataGridBasin.SelectedRows[0].Cells[0].Value.ToString();
            int currentweight = (int)dataGridBasin.SelectedRows[0].Cells[2].Value;
            if (currentweight < weight)
            {
                MsExeption("Súly hiba", "Súly hiba");
            }
            else
                if (currentweight == weight)
            {
                Delete();
            }
            else
            {
                dataGridBasin.SelectedRows[0].Cells[2].Value = currentweight - weight;
            }

        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            //GetData();
        }

        internal void DecreaseBySC(int w)
        {
            try
            {

                int rowIndex = dataGridBasin.CurrentCell.RowIndex;
                string tmp = dataGridBasin.SelectedRows[0].Cells[0].Value.ToString();


                dataGridBasin.SelectedRows[0].Cells[2].Value = w;

            }
            catch
            {

                throw new Exception();
            }
        }

        private void gtnGetById_Click(object sender, EventArgs e)
        {
           // GetDataID();
        }
        
        private void GetDataID(string b)
        {
            try { 
            ClearDataGridViewRows(dataGridBasin, RSList);

            RSList.Clear();
            var client = new RestClient(URL);
            String ROUTE = b;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Basin> response = client.Execute<Basin>(request);
            var content = response.Content;

            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            Basin a = new Basin();
            a = JsonConvert.DeserializeObject<Basin>(srt);

            RSList.Add(a);
            dataGridBasin.DataSource = RSList;
                DataGridDateFormating();
            }
            catch (Exception e)
            {

                MessageBox.Show( e.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Confirmation();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {




            var client2 = new RestClient(URL);
            String ROUTE = "post";

            var request = new RestRequest(ROUTE, Method.POST);
            request.RequestFormat = DataFormat.Json;



            try
            {
                request.AddBody(new Basin
                {
                    name = "nem",
                    weight = 2,
                    place = "nem",
                    arrived = DateTime.MinValue,
                    marinadestart = DateTime.MinValue,
                    marinadeend = DateTime.MinValue,
                    smoking = DateTime.MinValue,
                    rsid = 1

                }); ;

            }
            catch (Exception)
            {
                MsExeption("Töltsd ki az adatokat!! ", "Hiányzó adatok");

            }
            IRestResponse response2 = client2.Execute(request);
            MessageBox.Show("Succesfully added.");



        }
        public static void ClearDataGridViewRows(DataGridView dataGridView, List<Basin> DryList)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            DryList.Clear();
        }
        private void Confirmation()
        {
            DialogResult result = MessageBox.Show("Biztos Törölni akarod?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
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
            int rowIndex = dataGridBasin.CurrentCell.RowIndex;
            string tmp = dataGridBasin.SelectedRows[0].Cells[0].Value.ToString();


            var client = new RestClient(URL);
            String ROUTE = "delete/" + tmp;
            var request = new RestRequest(ROUTE, Method.DELETE);
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
        }
        public void MsExeption(string s, string s2)

        {
            if (s2 == "")
            {
                s2 = "Hiba";
            }
            MessageBox.Show(
                      s,
                      s2,
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error
                     );

        }

        private void dataGridDry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Put();
            try
            {
                
            }
            catch (Exception ex)
            {

                MsExeption("Basin hiba \n " + ex, "BasinHiba");
            }

        }
        private void Put()
        {
            int rowIndex = dataGridBasin.CurrentCell.RowIndex;
            string tmp = dataGridBasin.SelectedRows[0].Cells[0].Value.ToString();

          //  DateTime theDate = dateTimePicker1.Value.Date;

            var client = new RestClient(URL);
            String ROUTE = "put/" + (int)dataGridBasin.SelectedRows[0].Cells[0].Value;
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;


            


                string name, place;
                int weight, rsid;
                DateTime marinadestart, marinadeend, smoking, arrived;
           // DateTime time = DateTime.MinValue;

           // DataTimePut1 = (DateTime)dataGridBasin.SelectedRows[0].Cells[3].Value;

                name = dataGridBasin.SelectedRows[0].Cells[1].Value.ToString();
                weight = (int)dataGridBasin.SelectedRows[0].Cells[2].Value;
                place = dataGridBasin.SelectedRows[0].Cells[3].Value.ToString();
                arrived = (DateTime)dataGridBasin.SelectedRows[0].Cells[4].Value;
                marinadestart = (DateTime)dataGridBasin.SelectedRows[0].Cells[5].Value;
                marinadeend = (DateTime)dataGridBasin.SelectedRows[0].Cells[6].Value;
                smoking = (DateTime)dataGridBasin.SelectedRows[0].Cells[7].Value;
                rsid = (int)dataGridBasin.SelectedRows[0].Cells[8].Value;



                request.AddBody(new Basin
                {
                    name = name,
                    weight = weight,
                    place = place,
                    arrived = arrived,
                    marinadestart = marinadestart,
                    marinadeend = marinadeend,
                    smoking = smoking,
                    rsid = rsid,

                });


           




            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);





        }

        public void GetDataPublic()
        {

            GetData();
            this.Refresh();
        }
        public void GetDataPublicId(string b)
        {
            if (!b.All(char.IsDigit))
            {
                MsExeption("Nem szám", "Hibás bemenet");
            }
            else
            {
                if (b == "")
                {
                    MsExeption("Üres mező", "Hibás bemenet");
                }
                else
                {
                    GetDataID(b);
                    this.Refresh();
                }
            }
        }

        private void FormBasin_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void DataGridDateFormating()

        {
            dataGridBasin.Columns[4].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridBasin.Columns[5].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridBasin.Columns[6].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridBasin.Columns[7].DefaultCellStyle.Format = "yyyy.MM.dd.";
        }


        private void OpenChildForm(Form childForm, object btnSender)
        {

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelFill.Controls.Add(childForm);
            this.panelFill.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void dataGridBasin_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Put();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("Basin"), sender);
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.ScrapAdd("Basin"), sender);
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("Basin"), sender);
        }
    }
}

