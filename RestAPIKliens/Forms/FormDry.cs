
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
        private static DateTime DataTimePut1 = new DateTime();
        public static FormDry Self;
        public static bool id = false;
        private bool OrderBy=true;
        private bool ColumnChange=true;

        public FormDry()
        {
            InitializeComponent();
            LoadTheme();
            GetData();
            Self = this;
        }
        //drystorage

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

        internal FP GetDataCreateFP()
        {

            FP data = new FP();

            data.id = (int)dataGridDry.SelectedRows[0].Cells[0].Value;
            data.name = (string)dataGridDry.SelectedRows[0].Cells[1].Value;
            data.weight = (int)dataGridDry.SelectedRows[0].Cells[2].Value;
            data.place = (string)dataGridDry.SelectedRows[0].Cells[3].Value;
            data.arrived = (DateTime)dataGridDry.SelectedRows[0].Cells[4].Value;
            return data;
        }

        internal Scrap DataToScrapDry()
        {
            Scrap SC = new Scrap();

            SC.did = (int)dataGridDry.SelectedRows[0].Cells[0].Value;
            SC.name = (string)dataGridDry.SelectedRows[0].Cells[1].Value;
            SC.weight = (int)dataGridDry.SelectedRows[0].Cells[2].Value;
            SC.place = (string)dataGridDry.SelectedRows[0].Cells[3].Value;

            return SC;
        }

        
        private void GetData()
        {

            try { 
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
            GridForming();
            DataGridDateFormating();
                SetColumsName();
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
            int rowIndex = dataGridDry.CurrentCell.RowIndex;
            string tmp = dataGridDry.SelectedRows[0].Cells[0].Value.ToString();
            int currentweight = (int)dataGridDry.SelectedRows[0].Cells[2].Value;
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
                dataGridDry.SelectedRows[0].Cells[2].Value = currentweight - weight;
            }

        }

        internal void GetDataPublicTime(DateTime time)
        {
            throw new NotImplementedException();
        }

        internal void DecreaseBySC(int w)
        {
            try
            {

                int rowIndex = dataGridDry.CurrentCell.RowIndex;
                string tmp = dataGridDry.SelectedRows[0].Cells[0].Value.ToString();


                dataGridDry.SelectedRows[0].Cells[2].Value = w;

            }
            catch
            {

                throw new Exception();
            }
        }

        private void GridForming()
        {
            dataGridDry.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridDry.Columns[4].DefaultCellStyle.Format = "yyyy.MM.dd.";
        }

        internal void GetDataPublicPlace(string text)
        {
            throw new NotImplementedException();
        }

        public void DataList(Dry d)
        {
            DataPost(d);
        }
        private void DataPost(Dry d)
        {
            bool check = false;
            if (d.name == "")
            {
                check = true;
            }/*
            if (a.weight == null)
            {
                check = true;
            }*/
            if (d.weight == 0)
            {

                check = true;

            }


            if (d.place == "")
            {
                check = true;
            }
            if (check)
            {
                MsExeption("Hiányzó adatok ", "Hibás adatok");
            }
            else
            {


                var client = new RestClient(URL);
                String ROUTE = "post";
                var request = new RestRequest(ROUTE, Method.POST);
                request.RequestFormat = DataFormat.Json;

                try
                {
                    request.AddBody(new Dry
                    {
                        name = d.name,
                        weight = d.weight,
                        arrived = d.arrived.AddDays(1),
                        place = d.place,
                        expiration = d.expiration,
                        externalid = d.externalid

                    }) ;
                }
                catch (Exception)
                {

                    MsExeption("Hibás feltöltés", "");
                }

                IRestResponse response = client.Execute(request);
                MessageBox.Show("Succesfully added.");

            }
            GetData();
        }

        internal void GetDataPublicWeight(string text)
        {
            throw new NotImplementedException();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {

           // GetData();


        }

        internal void GetDataPublicName(string text)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridDry, DryList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Dry>> response = client.Execute<List<Dry>>(request);
                foreach (Dry a in response.Data)
                {

                    DryList.Add(a);

                }
                //--------------------------------------------------------//
                //Name Search

                Dry[] RsArray = new Dry[DryList.Count];

                for (int i = 0; i < DryList.Count; i++)
                {
                    RsArray[i] = DryList[i];
                }
                DryList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].name == text)
                    {
                        DryList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridDry.DataSource = DryList;


                 SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges " + e.Message);
            }
        }

        private void gtnGetById_Click(object sender, EventArgs e)
        {
            //GetDataID();

        }
        
        private void GetDataID(string b)
        {
            try { 
            ClearDataGridViewRows(dataGridDry, DryList);

            //dataGridDry.Rows.Clear();


            // dataGridDry.Refresh();
            DryList.Clear();
            var client = new RestClient(URL);
            String ROUTE = b;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Dry> response = client.Execute<Dry>(request);
            var content = response.Content;


            //Animal a = new Animal();
            //a = JsonSerializer.Deserialize<Animal>(content);
            //listcomp.Items.Add(content);

            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            Dry a = new Dry();
            a = JsonConvert.DeserializeObject<Dry>(srt);

            DryList.Add(a);
            dataGridDry.DataSource = DryList;
            GridForming();
            DataGridDateFormating();
                SetColumsName();
            }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges " + e.Message);
            }

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
        

        private void btnPost_Click(object sender, EventArgs e)
        {/*
            bool check = false;
            if (txtPostName.Text == "")
            {
                check = true;
            }
            if (txtPostWeight == null)
            {
                check = true;
            }

            if (txtPostWeight == null)
            {
                check = true;
            }
            if (txtPostPlace.Text == "")
            {
                check = true;
            }
            if (check)
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
            GetData();*/
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormDry_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DataGridDateFormating();
        }
        private void DataGridDateFormating()

        { 
            dataGridDry.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridDry.Columns[5].DefaultCellStyle.Format = "yyyy.MM.dd.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearDataGridViewRows(dataGridDry, DryList);
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
            DateTime time= DateTime.MinValue; 

            DataTimePut1 = (DateTime)dataGridDry.SelectedRows[0].Cells[4].Value;
            if (id)
            {
                time = PutGET();
            }
            else
            {
                time = PutGETid();
            }
            
            

            int rowIndex = dataGridDry.CurrentCell.RowIndex;
            string tmp = dataGridDry.SelectedRows[0].Cells[0].Value.ToString();
            var client = new RestClient(URL);
            String ROUTE = "put/" + (int)dataGridDry.SelectedRows[0].Cells[0].Value;
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Dry
            {

                name = (string)dataGridDry.SelectedRows[0].Cells[1].Value,
                weight = (int)dataGridDry.SelectedRows[0].Cells[2].Value,
                arrived = time,
                place = (string)dataGridDry.SelectedRows[0].Cells[3].Value,
                expiration=(DateTime)dataGridDry.SelectedRows[0].Cells[5].Value,
                externalid=(int)dataGridDry.SelectedRows[0].Cells[6].Value,




            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);

        }

        private static DateTime PutGET()
        {
            // PlusTime();
            int year, month, day;
            year = DataTimePut1.Year; day = DataTimePut1.Day ; month = DataTimePut1.Month;
            DateTime a = new DateTime(year, month, day, 1, 1, 1);
            return a;
        }
        private static DateTime PutGETid()
        {
            // PlusTime();
            int year, month, day;
            year = DataTimePut1.Year; day = DataTimePut1.Day ; month = DataTimePut1.Month;
            DateTime b = new DateTime(year, month, day, 1, 1, 1);
            return b;
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
            if (result.Equals(DialogResult.Yes))
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPostPlace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGetById_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridDry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public void GetDataPublic()
        {

            GetData();
            this.Refresh();
            id = false;
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
                    id = true;
                }
            }
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
        public void MsInfo(string s, string s2)

        {
            if (s2 == "")
            {
                s2 = "Info";
            }
            MessageBox.Show(
                      s,
                      s2,
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information
                     );

        }

        

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

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

        private void dataGridDry_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!ColumnChange)
            {
                Put();
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("Dry"), sender);
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.DryAdd("Dry"), sender);
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.ScrapAdd("Dry"), sender);
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("Dry"), sender);
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.FPCreate("Dry"), sender);
           
        }
        private void SortingMain(int col)
        {
            GetData();
            GetSortingData(col);
            SetColumsName();
        }
        private void SetColumsName()
        {
            ColumnChange = true;
            dataGridDry.Columns[0].HeaderText = "Azonosító";
            dataGridDry.Columns[1].HeaderText = "Megnevezés";
            dataGridDry.Columns[2].HeaderText = "Súly";
            dataGridDry.Columns[3].HeaderText = "Származási hely";
            dataGridDry.Columns[4].HeaderText = "Érkezési idő";
            dataGridDry.Columns[5].HeaderText = "Lejárati idő";
            dataGridDry.Columns[6].HeaderText = "Külső Azonosító";
            ColumnChange = false;
        }

        private void GetSortingData(int col)
        {
            try
            {

                SortingData(DryList.Count, col);

                dataGridDry.DataSource = DryList;
            }
            catch (Exception e)
            {
                MsExeption("Nem megy a node server\n msg:  " + e, "Node Server");
                throw;
            }
        }

        private void SortingData(int a, int col)
        {
            Dry[] RsArray = new Dry[a];
            for (int i = 0; i < a; i++)
            {
                RsArray[i] = DryList[i];
            }

            SortingVAR(RsArray, col);

        }

        private void SortingVAR(Dry[] rsArray, int col)
        {

            dataGridDry.DataSource = null;
            dataGridDry.Rows.Clear();


            IEnumerable<Dry> query;
            if (OrderBy)
            {


                switch (col)
                {
                    case 0:
                        query = rsArray.OrderBy(var => var.id);
                        DryList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderBy(var => var.name);
                        DryList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderBy(var => var.weight);
                        DryList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderBy(var => var.arrived);
                        DryList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderBy(var => var.place);
                        DryList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderBy(var => var.expiration);
                        DryList = query.ToList();
                        break;
                    case 6:
                        query = rsArray.OrderBy(var => var.externalid);
                        DryList = query.ToList();
                        break;

                    default:
                        break;
                }
                OrderBy = !OrderBy;
            }
            else
            {
                switch (col)
                {
                    case 0:
                        query = rsArray.OrderByDescending(var => var.id);
                        DryList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderByDescending(var => var.name);
                        DryList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderByDescending(var => var.weight);
                        DryList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderByDescending(var => var.arrived);
                        DryList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderByDescending(var => var.place);
                        DryList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderByDescending(var => var.expiration);
                        DryList = query.ToList();
                        break;
                    case 6:
                        query = rsArray.OrderByDescending(var => var.externalid);
                        DryList = query.ToList();
                        break;

                    default:
                        break;
                }
                OrderBy = !OrderBy;
            }
        }

        private void dataGridDry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (e.RowIndex == -1)
            {
                SortingMain(col);
            }
        }
    }
}
