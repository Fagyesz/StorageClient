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
    public partial class FormScrap : Form
    {
        public static FormScrap Self;
        String URL = "http://127.0.0.1:3000/scrap/";
        private List<Scrap> ScrapList = new List<Scrap>();
        private Scrap SC = new Scrap();
        private bool OrderBy = true;
        private bool ColumnChange = true;

        public FormScrap()
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
            SetColumsName();
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
                    SetColumsName();
                }
            }
        }

        private void FormScrap_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void DataGridDateFormating()
        {
            dataGridRS.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd.";
            
        }
        private void SetColumsName()
        {
            ColumnChange = true;
            dataGridRS.Columns[0].HeaderText = "Azonosító";
            dataGridRS.Columns[1].HeaderText = "Megnevezés";
            dataGridRS.Columns[2].HeaderText = "Súly";
            dataGridRS.Columns[3].HeaderText = "Származási hely";
            dataGridRS.Columns[4].HeaderText = "Érkezési ideje";
            dataGridRS.Columns[5].HeaderText = "Nyersanyag ID";
            dataGridRS.Columns[6].HeaderText = "SzárazRaktár ID";
            dataGridRS.Columns[7].HeaderText = "Basin ID";
            ColumnChange = false;
        }

        internal int DoNothing()
        {
            int a = 0;
            return a;
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

        internal void DataToScrap(Scrap sC, string v)
        {
            DataPost();
            switch (v)
            {
                case "FP":
                    FormFP.Self.ScrapDel(sC.weight);
                    break;
                case "RS":
                    FormRS.Self.ScrapDel(sC.weight);
                    break;
                case "Dry":
                    FormDry.Self.ScrapDel(sC.weight);
                    break;
                case "Basin":
                    FormBasin.Self.ScrapDel(sC.weight);
                    break;
                default:
                    break;
            }
            
        }

        internal void GetDataPublicTime(DateTime time)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, ScrapList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Scrap>> response = client.Execute<List<Scrap>>(request);
                foreach (Scrap a in response.Data)
                {

                    ScrapList.Add(a);

                }
                //--------------------------------------------------------//
                //place Search

                Scrap[] RsArray = new Scrap[ScrapList.Count];

                for (int i = 0; i < ScrapList.Count; i++)
                {
                    RsArray[i] = ScrapList[i];
                }
                ScrapList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    DateTime tmp = Convert.ToDateTime(RsArray[i].time);

                    if (TimeCreator(Convert.ToDateTime(RsArray[i].time)) == TimeCreator(time))
                    {
                        ScrapList.Add(RsArray[i]);
                    }
                    tmp = Convert.ToDateTime(RsArray[i].time);
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = ScrapList;


                SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés idő " + e.Message);
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
        private void GetData()
        {

            try
            {


                ClearDataGridViewRows(dataGridRS, ScrapList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Scrap>> response = client.Execute<List<Scrap>>(request);
                foreach (Scrap a in response.Data)
                {

                    ScrapList.Add(a);

                }
                dataGridRS.DataSource = ScrapList;
                DataGridDateFormating();
                SetColumsName();
            }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges " + e.Message);
            }

        }

        internal void GetDataPublicPlace(string text)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, ScrapList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Scrap>> response = client.Execute<List<Scrap>>(request);
                foreach (Scrap a in response.Data)
                {

                    ScrapList.Add(a);

                }
                //--------------------------------------------------------//
                //place Search

                Scrap[] RsArray = new Scrap[ScrapList.Count];

                for (int i = 0; i < ScrapList.Count; i++)
                {
                    RsArray[i] = ScrapList[i];
                }
                ScrapList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].place == text)
                    {
                        ScrapList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = ScrapList;


                SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés Származási hely:  " + e.Message);
            }
        }

        private void GetDataID(string b)
        {
            try { 
            ClearDataGridViewRows(dataGridRS, ScrapList);

            ScrapList.Clear();
            var client = new RestClient(URL);
            String ROUTE = b;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Scrap> response = client.Execute<Scrap>(request);
            var content = response.Content;

            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            Scrap a = new Scrap();
            a = JsonConvert.DeserializeObject<Scrap>(srt);

            ScrapList.Add(a);
            dataGridRS.DataSource = ScrapList;
                DataGridDateFormating();
                SetColumsName();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
}

        internal void GetDataPublicWeight(string text)
        {
            throw new NotImplementedException();
        }

        public static void ClearDataGridViewRows(DataGridView dataGridView, List<Scrap> ScrapList)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            ScrapList.Clear();
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

        internal void GetDataPublicSearch(string text,string SortType)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, ScrapList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<Scrap>> response = client.Execute<List<Scrap>>(request);
                foreach (Scrap a in response.Data)
                {

                    ScrapList.Add(a);

                }
                //--------------------------------------------------------//
                //Name Search

                Scrap[] RsArray = new Scrap[ScrapList.Count];

                for (int i = 0; i < ScrapList.Count; i++)
                {
                    RsArray[i] = ScrapList[i];
                }
                ScrapList.Clear();

                for (int i = 0; i < RsArray.Length; i++)
                {
                    switch (SortType)
                    {
                        case "id":
                            if (RsArray[i].id == int.Parse(text))
                            {
                                ScrapList.Add(RsArray[i]);
                            }
                            break;
                        case "name":
                            if (RsArray[i].name == text)
                            {
                                ScrapList.Add(RsArray[i]);
                            }
                            break;
                        case "weight":
                            if (RsArray[i].weight == int.Parse(text))
                            {
                                ScrapList.Add(RsArray[i]);
                            }
                            break;
                        case "place":
                            if (RsArray[i].place == text)
                            {
                                ScrapList.Add(RsArray[i]);
                            }
                            break;

                        default:
                            break;
                    }
                    


                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = ScrapList;


                 SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés:  " + e.Message);
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
            

            
            request.AddJsonBody(new Scrap
            {

                name = (string)dataGridRS.SelectedRows[0].Cells[1].Value,
                weight = (int)dataGridRS.SelectedRows[0].Cells[2].Value,
                place = (string)dataGridRS.SelectedRows[0].Cells[3].Value,
                time =TimeCreator( (DateTime)dataGridRS.SelectedRows[0].Cells[4].Value),
                rsid=(int)dataGridRS.SelectedRows[0].Cells[5].Value,
                did= (int)dataGridRS.SelectedRows[0].Cells[6].Value




            });
            IRestResponse response = client.Execute(request);

            MessageBox.Show("Sikeres frissítés");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("Scrap"), sender);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.RSAdd("Scrap"), sender);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.ScrapAdd("Scrap"), sender);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("Scrap"), sender);
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


        private void radioButton1_CheckedChanged_2(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("Scrap"), sender);
        }

        private void radioButton4_CheckedChanged_2(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("Scrap"), sender);
        }
        
        private void DataPost()
        {
            bool check = false;
            if (SC.name == "")
            {
                check = true;
            }/*
            if (a.weight == null)
            {
                check = true;
            }*/
            if (SC.weight == 0)
            {

                check = true;

            }
            if (check)
            {
                MessageBox.Show("Hiányzó adatok ", "Hibás adatok");
            }
            else
            {


                var client = new RestClient(URL);
                String ROUTE = "post";
                var request = new RestRequest(ROUTE, Method.POST);
                request.RequestFormat = DataFormat.Json;

                try
                {
                    request.AddBody(new Scrap
                    {
                        name = SC.name,
                        weight = SC.weight,
                        time=SC.time,
                        rsid = SC.rsid,
                        did = SC.did,
                        bid = SC.bid
                    });
                }
                catch (Exception)
                {

                    MessageBox.Show("Hibás feltöltés", "");
                }

                IRestResponse response = client.Execute(request);
                MessageBox.Show("Sikeres feltöltés.");

            }
            GetData();
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

                SortingData(ScrapList.Count, col);

                dataGridRS.DataSource = ScrapList;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nem megy a node server\n msg:  " + e, "Node Server");
                throw;
            }
        }

        private void SortingData(int a, int col)
        {
            Scrap[] RsArray = new Scrap[a];
            for (int i = 0; i < a; i++)
            {
                RsArray[i] = ScrapList[i];
            }

            SortingVAR(RsArray, col);

        }

        private void SortingVAR(Scrap[] rsArray, int col)
        {

            dataGridRS.DataSource = null;
            dataGridRS.Rows.Clear();


            IEnumerable<Scrap> query;
            if(OrderBy)
            {
                switch (col)
                {
                    case 0:
                        query = rsArray.OrderBy(var => var.id);
                        ScrapList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderBy(var => var.name);
                        ScrapList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderBy(var => var.weight);
                        ScrapList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderBy(var => var.time);
                        ScrapList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderBy(var => var.rsid);
                        ScrapList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderBy(var => var.did);
                        ScrapList = query.ToList();
                        break;
                    case 6:
                        query = rsArray.OrderBy(var => var.bid);
                        ScrapList = query.ToList();
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
                        ScrapList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderByDescending(var => var.name);
                        ScrapList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderByDescending(var => var.weight);
                        ScrapList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderByDescending(var => var.time);
                        ScrapList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderByDescending(var => var.rsid);
                        ScrapList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderByDescending(var => var.did);
                        ScrapList = query.ToList();
                        break;
                    case 6:
                        query = rsArray.OrderByDescending(var => var.bid);
                        ScrapList = query.ToList();
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
    }
}
