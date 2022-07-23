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
    public partial class FormFP : Form
    {
        String URL = "http://127.0.0.1:3000/finalproduct/";
        String URLuser = "http://127.0.0.1:3000/Users/";
        private List<FP> FPList = new List<FP>();
        private Button currentButton;
        Random random;
        private int tempIndex;
        private Form activeForm;
        private static bool searchbool = false;
        public static FormFP Self;

        private bool ColumnChange =true;
        private bool OrderBy=true;

        internal FP GetDataCreateFP()
        {
            throw new NotImplementedException();
        }

        public FormFP()
        {
            
            InitializeComponent();
            LoadTheme();
            Self = this;
            random = new Random();
            
            this.Text = String.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            GetData();
            
        }

        internal Stat DataToStatFP()
        {
            Stat ST = new Stat();

            ST.name=(string)dataGridFP.SelectedRows[0].Cells[4].Value;
            ST.weight = (int)dataGridFP.SelectedRows[0].Cells[5].Value;
            ST.fpid = (int)dataGridFP.SelectedRows[0].Cells[0].Value;
            ST.rsid = (int)dataGridFP.SelectedRows[0].Cells[1].Value;
            ST.bid = (int)dataGridFP.SelectedRows[0].Cells[2].Value;
            ST.did = (int)dataGridFP.SelectedRows[0].Cells[3].Value;
            ST.place = (string)dataGridFP.SelectedRows[0].Cells[6].Value;
            ST.arrived=(DateTime)dataGridFP.SelectedRows[0].Cells[7].Value;
            ST.marinated = (DateTime)dataGridFP.SelectedRows[0].Cells[9].Value; 
            ST.smoked = (DateTime)dataGridFP.SelectedRows[0].Cells[10].Value; 

            

           

            return ST;
        }

        private DateTime[] GetBasinData(string b)
        {
            DateTime[] d=new DateTime[2];

            try
            {
                
                var client = new RestClient(URL);
                String ROUTE =b ;
                var request = new RestRequest(ROUTE, Method.GET);
                IRestResponse<Basin> response = client.Execute<Basin>(request);
                var content = response.Content;


                string srt;
                srt = content;
                srt = srt.Substring(1, srt.Length - 2);
                Basin a = new Basin();
                a = JsonConvert.DeserializeObject<Basin>(srt);

                d[0] = a.marinadeend;
                d[1] = a.smoking;
                
                this.Refresh();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return d;
        }

        internal Scrap DataToScrapFP()
        {
            Scrap SC = new Scrap();

           // SC.fid = (int)dataGridFP.SelectedRows[0].Cells[0].Value;
            SC.name = (string)dataGridFP.SelectedRows[0].Cells[1].Value;
            SC.weight = (int)dataGridFP.SelectedRows[0].Cells[2].Value;

            return SC;

            //Scrap nem tartalmaz Kész terméket Az adatbázisban 
            // szükség szerint bővíthető
            
        }

        internal void GetDataPublicTime(DateTime time)
        {
            throw new NotImplementedException();
        }

        internal void DeleteByST()
        {
            Delete();
        }
        private void CallColumns()
        {
            try
            {
                SetColumsName();
            }
            catch (Exception)
            {

                
            }
                
                
            
           
        }
        private void SetColumsName()
        {
            ColumnChange = true;
            dataGridFP.Columns[0].HeaderText = "Azonosító";
            dataGridFP.Columns[1].HeaderText = "Nyersanyag ID";
            dataGridFP.Columns[2].HeaderText = "Basin ID";
            dataGridFP.Columns[3].HeaderText = "Száraz ID";
            dataGridFP.Columns[4].HeaderText = "Külső ID";
            dataGridFP.Columns[5].HeaderText = "Megnevezés";
            dataGridFP.Columns[6].HeaderText = "Súly";
            dataGridFP.Columns[7].HeaderText = "Származási hely";
            dataGridFP.Columns[8].HeaderText = "Érkezési idő";
            dataGridFP.Columns[9].HeaderText = "Vágás ideje";
            dataGridFP.Columns[10].HeaderText = "Érlelés ideje";
            dataGridFP.Columns[11].HeaderText = "Füstölés ideje";
            ColumnChange = false;
        }

        internal void GetDataPublicPlace(string text)
        {
            throw new NotImplementedException();
        }

        internal void DecreaseByST(int w)
        {
            try
            {

                int rowIndex = dataGridFP.CurrentCell.RowIndex;
                string tmp = dataGridFP.SelectedRows[0].Cells[0].Value.ToString();


                dataGridFP.SelectedRows[0].Cells[5].Value = w;

            }
            catch
            {

                throw new Exception();
            }
        }

        internal void GetDataPublicWeight(string text)
        {
            throw new NotImplementedException();
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

        internal void ScrapDel(int weight)
        {
            int rowIndex = dataGridFP.CurrentCell.RowIndex;
            string tmp = dataGridFP.SelectedRows[0].Cells[0].Value.ToString();
            int currentweight = (int)dataGridFP.SelectedRows[0].Cells[5].Value;
            if (currentweight < weight)
            {
                MessageBox.Show("Súly hiba", "Súly hiba");
            }
            else
                if (currentweight == weight)
            {
                Delete();
            }
            else
            {
                dataGridFP.SelectedRows[0].Cells[5].Value = currentweight - weight;
            }

        }

        internal void GetDataPublicName(string text)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridFP, FPList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<FP>> response = client.Execute<List<FP>>(request);
                foreach (FP a in response.Data)
                {

                    FPList.Add(a);

                }
                //--------------------------------------------------------//
                //Name Search

                FP[] RsArray = new FP[FPList.Count];

                for (int i = 0; i < FPList.Count; i++)
                {
                    RsArray[i] = FPList[i];
                }
                FPList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].name == text)
                    {
                        FPList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridFP.DataSource = FPList;


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

        private void GetData()
        {

            try { 
            ClearDataGridViewRows(dataGridFP, FPList);

            var client = new RestClient(URL);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<FP>> response = client.Execute<List<FP>>(request);
            foreach (FP a in response.Data)
            {

                FPList.Add(a);
                //listcomp.Items.Add("Id: " + a.id + " Név: " + a.name + " Súly: " + a.weight + " Érkezési idő: " + a.arrived + "Honnan érkezett:" + a.place  );


            }
            dataGridFP.DataSource = FPList;

                CallColumns();
        }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges "+e.Message);
            }

}

        internal void DecreaseBySC(int w)
        {
            try
            {

                int rowIndex = dataGridFP.CurrentCell.RowIndex;
                string tmp = dataGridFP.SelectedRows[0].Cells[0].Value.ToString();


                dataGridFP.SelectedRows[0].Cells[5].Value = w;

            }
            catch
            {

                throw new Exception();
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            GetData();
        }

         public static void ClearDataGridViewRows(DataGridView dataGridView, List<FP> DryList)
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

      
  
        private void Delete()
        {
            int rowIndex = dataGridFP.CurrentCell.RowIndex;
            string tmp = dataGridFP.SelectedRows[0].Cells[0].Value.ToString();


            var client = new RestClient(URL);
            String ROUTE = "delete/" + tmp;
            var request = new RestRequest(ROUTE, Method.DELETE);
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
        }

        private void Put()
        {
            int rowIndex = dataGridFP.CurrentCell.RowIndex;
            string tmp = dataGridFP.SelectedRows[0].Cells[0].Value.ToString();

            var client = new RestClient(URL);
            String ROUTE = "put/" + (int)dataGridFP.SelectedRows[0].Cells[0].Value;
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new FP
            {
                rsid = (int)dataGridFP.SelectedRows[0].Cells[1].Value,
                bid = (int)dataGridFP.SelectedRows[0].Cells[2].Value,
                did = (int)dataGridFP.SelectedRows[0].Cells[3].Value,
                name = (string)dataGridFP.SelectedRows[0].Cells[4].Value,
                weight = (int)dataGridFP.SelectedRows[0].Cells[5].Value,
                place = (string)dataGridFP.SelectedRows[0].Cells[6].Value,
                arrived = (DateTime)dataGridFP.SelectedRows[0].Cells[7].Value,
                butchered = (DateTime)dataGridFP.SelectedRows[0].Cells[8].Value,
                marinated = (DateTime)dataGridFP.SelectedRows[0].Cells[9].Value,
                smoked = (DateTime)dataGridFP.SelectedRows[0].Cells[10].Value




            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
            GetData();
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
           // ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelFill.Controls.Add(childForm);
            this.panelFill.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();/*
            switch (childForm.Text)
            {
                case "FormRS":
                    lblTitle.Text = "Nyersanyag raktár";
                    break;
                case "FormDry":
                    lblTitle.Text = "Száraz raktár";
                    break;
                case "FormFP":
                    lblTitle.Text = "Kész termék";
                    break;
                case "FormBasin":
                    lblTitle.Text = "Basin";
                    break;
                case "FormScrap":
                    lblTitle.Text = "Selejt";
                    break;
                case "FormStat":
                    lblTitle.Text = "Statisztika";
                    break;
                default:

                    break;
            }*/
            //lblTitle.Text = childForm.Text;
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Verdana", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    
                    
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    
                }
            }
        }
        

        private Color SelectThemeColor()
        {


            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        

        private void FormFP_Load(object sender, EventArgs e)
        {

            LoadTheme();

            this.dataGridFP.AllowUserToOrderColumns = true;
            
            
           
            
            DataGridDateFormating();
        }
        private void DataGridDateFormating()
        {
            dataGridFP.Columns[7].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridFP.Columns[8].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridFP.Columns[9].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridFP.Columns[10].DefaultCellStyle.Format = "yyyy.MM.dd.";
        }

        public void GetDataPublic()
        {

            GetData();
            
        }
        public void GetDataPublicId(string b)
        {
            if (!b.All(char.IsDigit))
            {
                MessageBox.Show("Nem szám", "Hibás bemenet");
            }
            else
            {
                if (b == "")
                {
                    MessageBox.Show("Üres mező", "Hibás bemenet");
                }
                else
                {
                    GetDataID(b);
                    this.Refresh();
                    CallColumns();
                }
            }
        }

        private void GetDataID(string b)
        {
            try { 
            ClearDataGridViewRows(dataGridFP, FPList);

            FPList.Clear();
            var client = new RestClient(URL);
            String ROUTE = b;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Dry> response = client.Execute<Dry>(request);
            var content = response.Content;


            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            FP a = new FP();
            a = JsonConvert.DeserializeObject<FP>(srt);

            FPList.Add(a);
            dataGridFP.DataSource = FPList;
            b = "";

            this.Refresh();
        }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            CallColumns();
        }


        private void dataGridDry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!ColumnChange)
            {
                Put();
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("FP"), sender);
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.FPAdd("FP"), sender);
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.ScrapAdd("FP"), sender);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("FP"), sender);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.StatAdd("FP"), sender);
        }

        private void dataGridFP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (e.RowIndex == -1)
            {
                SortingMain(col);
            }

        }

        private void Sorting()
        {
           
        }

        private void dataGridFP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSelector_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SortingMain(int col)
        {
            GetData();
            GetSortingData(col);
            SetColumsName();
        }

        private void GetSortingData(int col)
        {
            try
            {

                SortingData(FPList.Count, col);

                dataGridFP.DataSource = FPList;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nem megy a node server\n msg:  " + e, "Node Server");
                throw;
            }
        }

        private void SortingData(int a, int col)
        {
            FP[] RsArray = new FP[a];
            for (int i = 0; i < a; i++)
            {
                RsArray[i] = FPList[i];
            }

            SortingVAR(RsArray, col);

        }

        private void SortingVAR(FP[] rsArray, int col)
        {

            dataGridFP.DataSource = null;
            dataGridFP.Rows.Clear();


            IEnumerable<FP> query;

            if (OrderBy)
            {


                switch (col)
                {
                    case 0:
                        query = rsArray.OrderBy(var => var.id);
                        FPList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderBy(var => var.rsid);
                        FPList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderBy(var => var.bid);
                        FPList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderBy(var => var.did);
                        FPList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderBy(var => var.name);
                        FPList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderBy(var => var.weight);
                        FPList = query.ToList();
                        break;
                    case 6:
                        query = rsArray.OrderBy(var => var.place);
                        FPList = query.ToList();
                        break;
                    case 7:
                        query = rsArray.OrderBy(var => var.arrived);
                        FPList = query.ToList();
                        break;
                    case 8:
                        query = rsArray.OrderBy(var => var.butchered);
                        FPList = query.ToList();
                        break;
                    case 9:
                        query = rsArray.OrderBy(var => var.marinated);
                        FPList = query.ToList();
                        break;
                    case 10:
                        query = rsArray.OrderBy(var => var.smoked);
                        FPList = query.ToList();
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
                        FPList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderByDescending(var => var.rsid);
                        FPList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderByDescending(var => var.bid);
                        FPList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderByDescending(var => var.did);
                        FPList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderByDescending(var => var.name);
                        FPList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderByDescending(var => var.weight);
                        FPList = query.ToList();
                        break;
                    case 6:
                        query = rsArray.OrderByDescending(var => var.place);
                        FPList = query.ToList();
                        break;
                    case 7:
                        query = rsArray.OrderByDescending(var => var.arrived);
                        FPList = query.ToList();
                        break;
                    case 8:
                        query = rsArray.OrderByDescending(var => var.butchered);
                        FPList = query.ToList();
                        break;
                    case 9:
                        query = rsArray.OrderByDescending(var => var.marinated);
                        FPList = query.ToList();
                        break;
                    case 10:
                        query = rsArray.OrderByDescending(var => var.smoked);
                        FPList = query.ToList();
                        break;

                    default:
                        break;
                }
                OrderBy = !OrderBy;
            }
        }

    }
}
