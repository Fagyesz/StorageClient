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
    public partial class FormStat : Form
    {
        public static FormStat Self;
        String URL = "http://127.0.0.1:3000/statistics/";
        private List<Stat> StatList = new List<Stat>();
        private bool OrderBy = true;
        private bool ColumnChange = true;

        public FormStat()
        {
            InitializeComponent();
            Self = this;
            LoadTheme();
            GetData(); 
        }
        public void GetDataPublic()
        {

            GetData();
            this.Refresh();
        }
        public void GetDataPublicId(string s)
        {

            if (!s.All(char.IsDigit))
            {
                MessageBox.Show("Nem szám", "Hibás bemenet");
            }
            else
            {
                if (s == "")
                {
                    MessageBox.Show("Üres mező", "Hibás bemenet");
                }
                else
                {
                    GetDataID(s);
                    this.Refresh();
                }
            }
            
        }

        private void FormScrap_Load(object sender, EventArgs e)
        {
            LoadTheme();
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

        private void GetData()
        {
            try
            {
            ClearDataGridViewRows(dataGridRS, StatList);

            var client = new RestClient(URL);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<Stat>> response = client.Execute<List<Stat>>(request);
            foreach (Stat a in response.Data)
            {

                StatList.Add(a);

            }
            dataGridRS.DataSource = StatList;
            }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges "+e.Message);
            }
            DataGridDateFormating();
            SetColumsName();
        }
        private void GetDataID(string b)
        {
            try
            {



                ClearDataGridViewRows(dataGridRS, StatList);

                StatList.Clear();
                var client = new RestClient(URL);
                String ROUTE = b;
                var request = new RestRequest(ROUTE, Method.GET);
                IRestResponse<Stat> response = client.Execute<Stat>(request);
                var content = response.Content;

                string srt;
                srt = content;
                srt = srt.Substring(1, srt.Length - 2);
                Stat a = new Stat();
                a = JsonConvert.DeserializeObject<Stat>(srt);

                StatList.Add(a);
                dataGridRS.DataSource = StatList;
                SetColumsName();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                
            }
            DataGridDateFormating();
        }

        internal void GetDataPublicTime(DateTime time)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, StatList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Stat>> response = client.Execute<List<Stat>>(request);
                foreach (Stat a in response.Data)
                {

                    StatList.Add(a);

                }
                //--------------------------------------------------------//
                //place Search

                Stat[] RsArray = new Stat[StatList.Count];

                for (int i = 0; i < StatList.Count; i++)
                {
                    RsArray[i] = StatList[i];
                }
                StatList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    DateTime tmp = Convert.ToDateTime(RsArray[i].arrived);

                    if (TimeCreator(Convert.ToDateTime(RsArray[i].arrived)) == TimeCreator(time))
                    {
                        StatList.Add(RsArray[i]);
                    }
                    tmp = Convert.ToDateTime(RsArray[i].arrived);
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = StatList;


                SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés: " + e.Message);
            }
        }
        private static DateTime TimeCreator(DateTime time)
        {
            // PlusTime();
            int year, month, day;
            year = time.Year; day = time.Day; month = time.Month;
            DateTime a = new DateTime(year, month, day, 1, 1, 1);

            return a;
        }
        public static void ClearDataGridViewRows(DataGridView dataGridView, List<Stat> StatList)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            StatList.Clear();
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

        internal void GetDataPublicPlace(string text)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, StatList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Stat>> response = client.Execute<List<Stat>>(request);
                foreach (Stat a in response.Data)
                {

                    StatList.Add(a);

                }
                //--------------------------------------------------------//
                //place Search

                Stat[] RsArray = new Stat[StatList.Count];

                for (int i = 0; i < StatList.Count; i++)
                {
                    RsArray[i] = StatList[i];
                }
                StatList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].place == text)
                    {
                        StatList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = StatList;


                SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés " + e.Message);
            }
        }

        private void Delete()
        {
            int rowIndex = dataGridRS.CurrentCell.RowIndex;
            string tmp = dataGridRS.SelectedRows[0].Cells[0].Value.ToString();


            var client = new RestClient(URL);
            String ROUTE = "delete/" + tmp;
            var request = new RestRequest(ROUTE, Method.DELETE);
            IRestResponse response = client.Execute(request);
            //  MessageBox.Show(response.Content);
        }
        private void Put()
        {
            int rowIndex = dataGridRS.CurrentCell.RowIndex;
            string tmp = dataGridRS.SelectedRows[0].Cells[0].Value.ToString();




            var client = new RestClient(URL);
            String ROUTE = "put/" + (int)dataGridRS.SelectedRows[0].Cells[0].Value;
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;



            request.AddJsonBody(new Stat
            {

                fpid = (int)dataGridRS.SelectedRows[0].Cells[1].Value,
                rsid = (int)dataGridRS.SelectedRows[0].Cells[2].Value,
                bid = (int)dataGridRS.SelectedRows[0].Cells[3].Value,
                did = (int)dataGridRS.SelectedRows[0].Cells[4].Value,
                name = (string)dataGridRS.SelectedRows[0].Cells[5].Value,
                weight = (int)dataGridRS.SelectedRows[0].Cells[6].Value,
                place = (string)dataGridRS.SelectedRows[0].Cells[7].Value,
                butchered = TimeCreator((DateTime)dataGridRS.SelectedRows[0].Cells[8].Value),
                arrived = TimeCreator((DateTime)dataGridRS.SelectedRows[0].Cells[9].Value),
                marinated = TimeCreator((DateTime)dataGridRS.SelectedRows[0].Cells[10].Value),
                smoked = TimeCreator((DateTime)dataGridRS.SelectedRows[0].Cells[11].Value),
                stated = TimeCreator((DateTime)dataGridRS.SelectedRows[0].Cells[12].Value)



            }) ;
            IRestResponse response = client.Execute(request);

            MessageBox.Show("Sikeres frissítés");
        }

        internal void GetDataPublicWeight(string text)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, StatList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Stat>> response = client.Execute<List<Stat>>(request);
                foreach (Stat a in response.Data)
                {

                    StatList.Add(a);

                }
                //--------------------------------------------------------//
                //w Search

                Stat[] RsArray = new Stat[StatList.Count];

                for (int i = 0; i < StatList.Count; i++)
                {
                    RsArray[i] = StatList[i];
                }
                StatList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].weight.ToString() == text)
                    {
                        StatList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = StatList;


                SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés:  " + e.Message);
            }
        }

        internal void GetDataPublicName(string text)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, StatList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Stat>> response = client.Execute<List<Stat>>(request);
                foreach (Stat a in response.Data)
                {

                    StatList.Add(a);

                }
                //--------------------------------------------------------//
                //Name Search

                Stat[] RsArray = new Stat[StatList.Count];

                for (int i = 0; i < StatList.Count; i++)
                {
                    RsArray[i] = StatList[i];
                }
                StatList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].name == text)
                    {
                        StatList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = StatList;


                SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés:  " + e.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("Stat"), sender);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.RSAdd("Stat"), sender);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.ScrapAdd("Stat"), sender);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("Stat"), sender);
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

        private void dataGridRS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!ColumnChange)
            {
                Put();
            }
        }

       

        private void FormStat_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DataGridDateFormating();
        }
        private void DataGridDateFormating()
        {
            
            dataGridRS.Columns[8].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridRS.Columns[9].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridRS.Columns[10].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridRS.Columns[11].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridRS.Columns[12].DefaultCellStyle.Format = "yyyy.MM.dd.";
        }
        private void SetColumsName()
        {
            ColumnChange = true;
            dataGridRS.Columns[0].HeaderText = "Azonosító";
            dataGridRS.Columns[1].HeaderText = "KészTermék ID";
            dataGridRS.Columns[2].HeaderText = "Nyersanyag ID";
            dataGridRS.Columns[3].HeaderText = "Basin ID";
            dataGridRS.Columns[4].HeaderText = "SzárazRaktár ID";
            dataGridRS.Columns[5].HeaderText = "Megnevezés";
            dataGridRS.Columns[6].HeaderText = "Súly";
            dataGridRS.Columns[7].HeaderText = "Származási hely";
            dataGridRS.Columns[8].HeaderText = "Érkezési ideje";
            dataGridRS.Columns[9].HeaderText = "Vágás ideje";
            dataGridRS.Columns[10].HeaderText = "Érlelés ideje";
            dataGridRS.Columns[11].HeaderText = "Füstölés ideje";
            dataGridRS.Columns[12].HeaderText = "Archiválás ideje";

            ColumnChange = false;
        }

        private void radioButton1_CheckedChanged_2(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("Stat"), sender);
        }

        private void radioButton4_CheckedChanged_2(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("Stat"), sender);
        }


        private void SortingMain(int col)
        {
          
            GetSortingData(col);
            SetColumsName();
        }

        private void GetSortingData(int col)
        {
            try
            {

                SortingData(StatList.Count, col);

                dataGridRS.DataSource = StatList;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nem megy a node server\n msg:  " + e, "Node Server");
                throw;
            }
        }

        private void SortingData(int a, int col)
        {
            Stat[] RsArray = new Stat[a];
            for (int i = 0; i < a; i++)
            {
                RsArray[i] = StatList[i];
            }

            SortingVAR(RsArray, col);

        }

        private void SortingVAR(Stat[] rsArray, int col)
        {

            dataGridRS.DataSource = null;
            dataGridRS.Rows.Clear();


            IEnumerable<Stat> query;

            if (OrderBy)
            {

                switch (col)
                {
                    case 0:
                        query = rsArray.OrderBy(var => var.id);
                        StatList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderBy(var => var.fpid);
                        StatList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderBy(var => var.rsid);
                        StatList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderBy(var => var.bid);
                        StatList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderBy(var => var.did);
                        StatList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderBy(var => var.name);
                        StatList = query.ToList();
                        break;
                    case 6:
                        query = rsArray.OrderBy(var => var.weight);
                        StatList = query.ToList();
                        break;
                    case 7:
                        query = rsArray.OrderBy(var => var.place);
                        StatList = query.ToList();
                        break;
                    case 8:
                        query = rsArray.OrderBy(var => var.arrived);
                        StatList = query.ToList();
                        break;
                    case 9:
                        query = rsArray.OrderBy(var => var.butchered);
                        StatList = query.ToList();
                        break;
                    case 10:
                        query = rsArray.OrderBy(var => var.marinated);
                        StatList = query.ToList();
                        break;
                    case 11:
                        query = rsArray.OrderBy(var => var.smoked);
                        StatList = query.ToList();
                        break;
                    case 12:
                        query = rsArray.OrderBy(var => var.stated);
                        StatList = query.ToList();
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
                        StatList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderByDescending(var => var.fpid);
                        StatList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderByDescending(var => var.rsid);
                        StatList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderByDescending(var => var.bid);
                        StatList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderByDescending(var => var.did);
                        StatList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderByDescending(var => var.name);
                        StatList = query.ToList();
                        break;
                    case 6:
                        query = rsArray.OrderByDescending(var => var.weight);
                        StatList = query.ToList();
                        break;
                    case 7:
                        query = rsArray.OrderByDescending(var => var.place);
                        StatList = query.ToList();
                        break;
                    case 8:
                        query = rsArray.OrderByDescending(var => var.arrived);
                        StatList = query.ToList();
                        break;
                    case 9:
                        query = rsArray.OrderByDescending(var => var.butchered);
                        StatList = query.ToList();
                        break;
                    case 10:
                        query = rsArray.OrderByDescending(var => var.marinated);
                        StatList = query.ToList();
                        break;
                    case 11:
                        query = rsArray.OrderByDescending(var => var.smoked);
                        StatList = query.ToList();
                        break;
                    case 12:
                        query = rsArray.OrderByDescending(var => var.stated);
                        StatList = query.ToList();
                        break;
                    default:
                        break;

                }
                OrderBy = !OrderBy;
            }
        }

        private void dataGridRS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (e.RowIndex == -1)
            {
                SortingMain(col);
            }
        }

        private void dataGridRS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
