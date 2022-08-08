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
        
        static String URL = "http://127.0.0.1:3000/resourcestorage/";
        String URLbasin = "http://127.0.0.1:3000/basin/";
        private List<RS> RSList = new List<RS>();
        public  List<RS> RSL = new List<RS>();
        
        private List<Basin> BasinList = new List<Basin>();
        public static FormRS Self;
        private List<RS> Rs = new List<RS>();
        private RS singlers = new RS();
        private static DateTime DataTimePut1=new DateTime();

        private List<Short> shList = new List<Short>();
        private List<FP> fpList = new List<FP>();
        public static bool id = false;

        internal FP GetDataCreateFP()
        {
            FP data = new FP();

            data.id = (int)dataGridRS.SelectedRows[0].Cells[0].Value;
            data.name = (string)dataGridRS.SelectedRows[0].Cells[1].Value;
            data.weight= (int)dataGridRS.SelectedRows[0].Cells[2].Value;
            data.place = (string)dataGridRS.SelectedRows[0].Cells[3].Value;
            data.arrived= (DateTime)dataGridRS.SelectedRows[0].Cells[4].Value;
            data.butchered=(DateTime)dataGridRS.SelectedRows[0].Cells[5].Value;
            return data;
        }
        internal RS GetDataCreateRS()
        {
            RS data = new RS();

            data.id = (int)dataGridRS.SelectedRows[0].Cells[0].Value;
            data.name = (string)dataGridRS.SelectedRows[0].Cells[1].Value;
            data.weight = (int)dataGridRS.SelectedRows[0].Cells[2].Value;
            data.place = (string)dataGridRS.SelectedRows[0].Cells[3].Value;
            data.arrived = (DateTime)dataGridRS.SelectedRows[0].Cells[4].Value;
            data.butchered = (DateTime)dataGridRS.SelectedRows[0].Cells[5].Value;
            return data;
        }

        private static DateTime DataTimePut2=new DateTime();
        private bool ColumnChange = true;
        private bool OrderBy = true;

        internal int GetRsID()
        {
            int id = (int)dataGridRS.SelectedRows[0].Cells[0].Value;

            return id;
        }

        public FormRS()
        {
            InitializeComponent();
            LoadTheme();
            GetData();
            Self = this;
            GridFormating();
            
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
            int rowIndex = dataGridRS.CurrentCell.RowIndex;
            string tmp = dataGridRS.SelectedRows[0].Cells[0].Value.ToString();
            int currentweight = (int)dataGridRS.SelectedRows[0].Cells[2].Value;
            if (currentweight<weight)
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
                dataGridRS.SelectedRows[0].Cells[2].Value = currentweight - weight;
            }
           
        }

        internal void DeleteBySC()
        {
            Delete();
            GetData();
        }

        private void GetData()
        {
            id = false;
            try {

            ClearDataGridViewRows(dataGridRS, RSList);

            var client = new RestClient(URL);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<RS>> response = client.Execute<List<RS>>(request);
            foreach (RS a in response.Data)
            {

                RSList.Add(a);

            }
            dataGridRS.DataSource = RSList;

            //dataGridRS.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd.";
            // dataGridRS.Columns[4].DefaultCellStyle.Format = "yyyy.MM.dd.";
            GridFormating();
            }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges " + e.Message);
            }

        }/*
        private void btnGetAll_Click(object sender, EventArgs e)
        {

            GetData();


        }

        private void gtnGetById_Click(object sender, EventArgs e)
        {
            GetDataID();

        }*/
        private static DateTime TimeCreator(DateTime time)
        {
            // PlusTime();
            int year, month, day;
            year = time.Year; day = time.Day; month = time.Month;
            DateTime a = new DateTime(year, month, day, 1, 1, 1);

            return a;
        }
        internal void GetDataPublicTime(DateTime time)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, RSList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<RS>> response = client.Execute<List<RS>>(request);
                foreach (RS a in response.Data)
                {

                    RSList.Add(a);

                }
                //--------------------------------------------------------//
                //place Search

                RS[] RsArray = new RS[RSList.Count];

                for (int i = 0; i < RSList.Count; i++)
                {
                    RsArray[i] = RSList[i];
                }
                RSList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    DateTime tmp = Convert.ToDateTime(RsArray[i].arrived);

                    if (TimeCreator(Convert.ToDateTime(RsArray[i].arrived)) == TimeCreator(time))
                    {
                        RSList.Add(RsArray[i]);
                    }
                    tmp = Convert.ToDateTime(RsArray[i].arrived);
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = RSList;


                SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés: " + e.Message);
            }
        }

        internal void DecreaseBySC(int w)
        {
            try
            {

                int rowIndex = dataGridRS.CurrentCell.RowIndex;
                string tmp = dataGridRS.SelectedRows[0].Cells[0].Value.ToString();


                dataGridRS.SelectedRows[0].Cells[2].Value = w;

            }
            catch
            {

                throw new Exception();
            }
        }

        internal void GetDataPublicPlace(string text)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, RSList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<RS>> response = client.Execute<List<RS>>(request);
                foreach (RS a in response.Data)
                {

                    RSList.Add(a);

                }
                //--------------------------------------------------------//
                //place Search

                RS[] RsArray = new RS[RSList.Count];

                for (int i = 0; i < RSList.Count; i++)
                {
                    RsArray[i] = RSList[i];
                }
                RSList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].place == text)
                    {
                        RSList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = RSList;


                SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés Származási hely:  " + e.Message);
            }
        }

        private void GridFormating()
        {
            try
            {
                dataGridRS.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridRS.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy";
            }
            catch (Exception)
            {

               
            }
            
        }

        private void GetDataID(string b)
        {
            try { 
            ClearDataGridViewRows(dataGridRS, RSList);

            RSList.Clear();
            var client = new RestClient(URL);
            String ROUTE = b;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<RS> response = client.Execute<RS>(request);
            var content = response.Content;

            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            RS a = new RS();
            a = JsonConvert.DeserializeObject<RS>(srt);

            RSList.Add(a);
            dataGridRS.DataSource = RSList;
        }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        internal void GetDataPublicWeight(string text)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, RSList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<RS>> response = client.Execute<List<RS>>(request);
                foreach (RS a in response.Data)
                {

                    RSList.Add(a);

                }
                //--------------------------------------------------------//
                //Name Search

                RS[] RsArray = new RS[RSList.Count];

                for (int i = 0; i < RSList.Count; i++)
                {
                    RsArray[i] = RSList[i];
                }
                RSList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].weight.ToString() == text)
                    {
                        RSList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = RSList;


                GridFormating(); SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés " + e.Message);
            }
        }


        /*
public class RS
{

   public int id { get; set; }
   public string name { get; set; }
   public int weight { get; set; }
   public DateTime arrived { get; set; }
   public DateTime butchered { get; set; }
   public string place { get; set; }

}*/

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
            }*/
        }

        internal void GetDataPublicName(string SearchedName)
        {
            try
            {
                //--------------------------------------------------------//
                //Basic Get

                ClearDataGridViewRows(dataGridRS, RSList);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<RS>> response = client.Execute<List<RS>>(request);
                foreach (RS a in response.Data)
                {

                    RSList.Add(a);

                }
                //--------------------------------------------------------//
                //Name Search

                RS[] RsArray = new RS[RSList.Count];
                
                for (int i = 0; i < RSList.Count; i++)
                {
                    RsArray[i] = RSList[i];
                }
                RSList.Clear();
                for (int i = 0; i < RsArray.Length; i++)
                {
                    if (RsArray[i].name==SearchedName)
                    {
                        RSList.Add(RsArray[i]);
                    }
                }




                //--------------------------------------------------------//
                dataGridRS.DataSource = RSList;

                
                GridFormating(); SetColumsName();

            }
            catch (Exception e)
            {

                MessageBox.Show("Keresés " + e.Message);
            }
        }

        public static void ClearDataGridViewRows(DataGridView dataGridView, List<RS> DryList)
        {
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



            DataTimePut1 = (DateTime)dataGridRS.SelectedRows[0].Cells[4].Value;
            DataTimePut2 = (DateTime)dataGridRS.SelectedRows[0].Cells[5].Value;

            
            DateTime a = DateTime.MinValue, b = DateTime.MinValue;
            PutTime(out a, out b);

            DateTime time = DateTime.MinValue;

            
                a = PutGET();
            
                b = PutGETid();
           /*
            if (id)
            {
                b = PutGET(DataTimePut2);
            }
            else
            {
                b = PutGETid(DataTimePut2);
            }*/

            request.AddJsonBody(new RS
            {

                name = (string)dataGridRS.SelectedRows[0].Cells[1].Value,
                weight = (int)dataGridRS.SelectedRows[0].Cells[2].Value,
                arrived = a,
                butchered = b,
                place = (string)dataGridRS.SelectedRows[0].Cells[3].Value



            });
            IRestResponse response = client.Execute(request);

            MessageBox.Show("Adat sikeresen frissítve");
            Look();
        }
        private static DateTime PutGET()
        {
            // PlusTime();
            int year, month, day;
            year = DataTimePut1.Year; day = DataTimePut1.Day; month = DataTimePut1.Month;
            DateTime a = new DateTime(year, month, day,1,1,1);
            
            return a; 
        }
        private static DateTime PutGETid()
        {
            // PlusTime();
            int year, month, day;
            year = DataTimePut2.Year; day = DataTimePut2.Day; month = DataTimePut2.Month;
            DateTime b = new DateTime(year, month, day, 1, 1, 1);
            return b;
        }
        private static void PutTime(out DateTime a, out DateTime b)
        {
            // PlusTime();
            int year, month, day;
            year = DataTimePut1.Year; day = DataTimePut1.Day ; month = DataTimePut1.Month;
            a = new DateTime(year, month, day);
            year = DataTimePut2.Year; day = DataTimePut2.Day ; month = DataTimePut2.Month;
            b = new DateTime(year, month, day);
        }
        



        private void btnPost_Click_1(object sender, EventArgs e)
        {
           // DataPost();
        }

        private void DataPost(RS a)
        {
            bool check = false;
            if (a.name == "")
            {
                check = true;
            }/*
            if (a.weight == null)
            {
                check = true;
            }*/
            if (a.weight == 0)
            {
                
                check = true;
                
            }
            

            if (a.place == "")
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
                    request.AddBody(new RS
                    {
                        name = a.name,
                        weight = a.weight,
                        arrived = a.arrived.AddDays(1),
                        butchered = a.butchered.AddDays(1),
                        place = a.place
                    });
                }
                catch (Exception)
                {

                    MsExeption("Hibás feltöltés", "");
                }

                IRestResponse response = client.Execute(request);
                MessageBox.Show("Sikeres feltöltés.");

            }
            GetData();
            Look();
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

        private void btnGetAll_Click_1(object sender, EventArgs e)
        {
            //GetData();
        }

        private void gtnGetById_Click_1(object sender, EventArgs e)
        {
            //GetDataID();
        }
        /*
        private void GetDataID(string b)
        {
            ClearDataGridViewRows(dataGridRS, RSList);


            RSList.Clear();
            var client = new RestClient(URL);
            String ROUTE = b;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<RS> response = client.Execute<RS>(request);
            var content = response.Content;

            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            RS a = new RS();
            a = JsonConvert.DeserializeObject<RS>(srt);

            RSList.Add(a);
            dataGridRS.DataSource = RSList;
        }
        */
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            Confirmation();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
          //  BasinbaMethod();
        }

        private void BasinbaMethod(BasinMini b)
        {
            try
            {



                int rowIndex = dataGridRS.CurrentCell.RowIndex;
                string tmp = dataGridRS.SelectedRows[0].Cells[0].Value.ToString();
                int weight = (int)dataGridRS.SelectedRows[0].Cells[2].Value,
                   // w2 = int.Parse(btnBasinw.Text);
                w2 = b.weight;

                if (b.weight == 0)
                {

                    MsInfo("Nulla vagy kissebb súlyt nem lehet tovább küldeni basinba ", "NULL");
                }
                else
                {
                    


                     
                     if (w2 > weight)
                     {
                         MsExeption("Túl nagy Súlyt adott meg", "Túlcsordulás");


                     }
                     else
                     {
                         //Delete();
                         if (weight - w2 == 0)
                         {
                             Delete();
                         }
                         else
                         {
                             dataGridRS.SelectedRows[0].Cells[2].Value = weight - w2;
                         }

                         Basinba(b);


                     }
                    

                }
                GetData();
                Look();
            }
            catch (Exception ex)
            {

                MsExeption("Nem lehet basinba rakni \n" + ex, "Hiba");
            }
        }

        
        private void Basinba(BasinMini b)
        {

            int rowIndex = dataGridRS.CurrentCell.RowIndex;
            string tmp = dataGridRS.SelectedRows[0].Cells[0].Value.ToString();



            var client2 = new RestClient(URLbasin);
            String ROUTE = "post";

            var request = new RestRequest(ROUTE, Method.POST);


            request.RequestFormat = DataFormat.Json;
            



            try
            {/*
                request.AddBody(new Basin
                {
                    name = (string)dataGridRS.SelectedRows[0].Cells[1].Value,
                    weight = (int)dataGridRS.SelectedRows[0].Cells[1].Value,
                    place = (string)dataGridRS.SelectedRows[0].Cells[5].Value,
                    arrived = (DateTime)dataGridRS.SelectedRows[0].Cells[3].Value,
                    marinadestart = theDate3,
                    marinadeend = theDate4,
                    smoking = DateTime.MinValue,
                    rsid = (int)dataGridRS.SelectedRows[0].Cells[0].Value

                }); ;*/


                string name, place;
                int weight, rsid;

                DateTime marinadestart, marinadeend, smoking, arrived;
        
                name = dataGridRS.SelectedRows[0].Cells[1].Value.ToString();
               
                weight = b.weight;
                place = dataGridRS.SelectedRows[0].Cells[3].Value.ToString();
                arrived = (DateTime)dataGridRS.SelectedRows[0].Cells[4].Value;
                try
                {
                    marinadestart = b.marinadestart;
                    marinadeend = b.marinadeend;
                }
                catch (Exception e)
                {

                    throw ;
                }
                
                smoking = DateTime.MinValue;
                rsid = (int)dataGridRS.SelectedRows[0].Cells[0].Value;



                request.AddBody(new Basin
                {
                    name = name,
                    weight = weight,
                    place = place,
                    arrived = TimeCreator(arrived),
                    marinadestart =TimeCreator( marinadestart),
                    marinadeend = TimeCreator(marinadeend),
                    smoking = TimeCreator(smoking),
                    rsid = rsid,

                });


            }
            catch (Exception)
            {

                throw;

            }
            IRestResponse response2 = client2.Execute(request);
            MessageBox.Show("Sikeres Feltöltés.");





        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridRS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Put();


        }

        private void btnBasinw_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void GetDataPublic()
        {
            
            GetData();
            dataGridRS.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridRS.Columns[4].DefaultCellStyle.Format = "yyyy.MM.dd.";
            
            SetColumsName();
        }
        public void GetDataPublicId(string b)
        {
            if (!b.All(char.IsDigit))
            {
                MsExeption("Nem szám", "Hibás bemenet");
            }
            else
            {
                if (b=="")
                {
                    MsExeption("Üres mező", "Hibás bemenet");
                }
                else
                {
                    GetDataID(b);
                    dataGridRS.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd.";
                    dataGridRS.Columns[4].DefaultCellStyle.Format = "yyyy.MM.dd.";
                    this.Refresh();
                    SetColumsName();
                }

            }
            
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

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.BasinAdd("RS"), sender);
        }

        private void FormRS_Load(object sender, EventArgs e)
        {
            Look();
        }

        private void Look()
        {
            LoadTheme();
            DataGridDateFormating();
            SetColumsName();
            Scrollbar();
        }

        private void DataGridDateFormating()
        {
            dataGridRS.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd.";
            dataGridRS.Columns[4].DefaultCellStyle.Format = "yyyy.MM.dd.";
            
        }

        private void SetColumsName()
        {
            ColumnChange = true;
            dataGridRS.Columns[0].HeaderText = "Azonosító";
            dataGridRS.Columns[1].HeaderText = "Megnevezés";
            dataGridRS.Columns[2].HeaderText = "Súly";
            dataGridRS.Columns[3].HeaderText = "Származási hely";
            dataGridRS.Columns[4].HeaderText = "Érkezési idő";
            dataGridRS.Columns[5].HeaderText = "Vágási idő";
            
            ColumnChange = false;
        }

        public void DataList(RS a)
        {
            DataPost(a);
        }
        public void DataBasinba(BasinMini b)
        {
            BasinbaMethod(b);
        }

        private void dataGridRS_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!ColumnChange)
            {
                Put();
            }
            
        }
        private void Scrollbar()
        {
            ScrollableControl ctl;
            ctl = new ScrollableControl();
            //ctl.HorizontalScroll.Visible   // the horizontal scrollbar visibility
            ctl.VerticalScroll.Visible = false;  // the vertical scrollbar visibility
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("RS"), sender);
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.RSAdd("RS"), sender);
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.ScrapAdd("RS"), sender);
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("RS"), sender);
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.BasinAdd("RS"), sender);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.FPCreate("RS"), sender);
        }
        public Scrap DataToScrapRS()
        {
            Scrap SC = new Scrap();
            int rowIndex = dataGridRS.CurrentCell.RowIndex;
            string tmp = dataGridRS.SelectedRows[0].Cells[0].Value.ToString();

            SC.name = (string)dataGridRS.SelectedRows[0].Cells[1].Value;
            SC.rsid = (int)dataGridRS.SelectedRows[0].Cells[0].Value;
            SC.weight= (int)dataGridRS.SelectedRows[0].Cells[2].Value;
            SC.place= (string)dataGridRS.SelectedRows[0].Cells[3].Value;

            return SC;
        }




       
        /*
        public void OrderByEX(bool Order,string s)
        {
            
            List<RS> RSLt = new List<RS>();
             GetOrderData();
                

            int l = RSL.Count();
            RS[] rs = new RS[l];
            
            IEnumerable<RS> query;
            if (Order)
            {
                switch (s)
                {
                    case "name":
                        query = RSL.OrderBy(RS => RS.name);
                        break;
                    case "weight":
                        query = RSL.OrderBy(RS => RS.weight);
                        break;
                    case "place":
                        query = RSL.OrderBy(RS => RS.place);
                        break;
                    case "butchered":
                        query = RSL.OrderBy(RS => RS.butchered);
                        break;
                    case "arrived":
                        query = RSL.OrderBy(RS => RS.arrived);
                        break;
                    case "id":
                        query = RSL.OrderBy(RS => RS.id);
                        break;

                    default:
                        query = RSL.OrderBy(RS => RS.id);
                        break;
                }
                


            }
            else
            {
                switch (s)
                {
                    case "name":
                        query = RSL.OrderByDescending(RS => RS.name);
                        break;
                    case "weight":
                        query = RSL.OrderByDescending(RS => RS.weight);
                        break;
                    case "place":
                        query = RSL.OrderByDescending(RS => RS.place);
                        break;
                    case "butchered":
                        query = RSL.OrderByDescending(RS => RS.butchered);
                        break;
                    case "arrived":
                        query = RSL.OrderByDescending(RS => RS.arrived);
                        break;
                    case "id":
                        query = RSL.OrderByDescending(RS => RS.id);
                        break;

                    default:
                        query = RSL.OrderByDescending(RS => RS.id);
                        break;
                }
                

            }
            
            //query = RSL.OrderByDescending(RS=>RS.weight);
            
            foreach (RS rss in query)
            {
                
                RSLt.Add(rss);
            }
            try
            {
                dataGridRS.DataSource = RSLt;
                GridFormating();

            }
            catch (Exception)
            {

                
            }
            
            
            

        }*/

        private void GetOrderData()
        {
            try
            {

                ClearDataGridViewRows(dataGridRS, RSL);

                var client = new RestClient(URL);
                String ROUTE = "";
                var request = new RestRequest(ROUTE, Method.GET);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<RS>> response = client.Execute<List<RS>>(request);
                foreach (RS a in response.Data)
                {

                    RSL.Add(a);

                }
                
                

            }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges " + e.Message);
            }
        }

        private void dataGridRS_Click(object sender, EventArgs e)
        {
            //CallOrder();
           

        }
        /*
        private void CallOrder()
        {
            int colIndex = dataGridRS.CurrentCell.ColumnIndex;
            //string tmp = dataGridRS.SelectedRows[0].Cells[0].Value.ToString();
            bool order = true;

            switch (colIndex)
            {
                case 0:
                    OrderByEX(order, "id");
                    break;
                case 1:
                    OrderByEX(order, "name");
                    break;
                case 2:
                    OrderByEX(order, "weight");
                    break;
                case 3:
                    OrderByEX(order, "arrived");
                    break;
                case 4:
                    OrderByEX(order, "butchered");
                    break;
                case 5:
                    OrderByEX(order, "place");
                    break;

                default:
                    break;
            }
        }*/

        private void dataGridRS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

                SortingData(RSList.Count, col);

                dataGridRS.DataSource = RSList;
            }
            catch (Exception e)
            {
                MsExeption("Nem megy a node server\n msg:  " + e, "Node Server");
                throw;
            }
        }

        private void SortingData(int a, int col)
        {
            RS[] RsArray = new RS[a];
            for (int i = 0; i < a; i++)
            {
                RsArray[i] = RSList[i];
            }

            SortingVAR(RsArray, col);

        }

        private void SortingVAR(RS[] rsArray, int col)
        {

            dataGridRS.DataSource = null;
            dataGridRS.Rows.Clear();


            IEnumerable<RS> query;
            if (OrderBy)
            {
                switch (col)
                {
                    case 0:
                        query = rsArray.OrderBy(var => var.id);
                        RSList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderBy(var => var.name);
                        RSList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderBy(var => var.weight);
                        RSList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderBy(var => var.arrived);
                        RSList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderBy(var => var.butchered);
                        RSList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderBy(var => var.place);
                        RSList = query.ToList();
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
                        RSList = query.ToList();
                        break;
                    case 1:
                        query = rsArray.OrderByDescending(var => var.name);
                        RSList = query.ToList();
                        break;
                    case 2:
                        query = rsArray.OrderByDescending(var => var.weight);
                        RSList = query.ToList();
                        break;
                    case 3:
                        query = rsArray.OrderByDescending(var => var.place);
                        RSList = query.ToList();
                        break;
                    case 4:
                        query = rsArray.OrderByDescending(var => var.arrived);
                        RSList = query.ToList();
                        break;
                    case 5:
                        query = rsArray.OrderByDescending(var => var.butchered);
                        RSList = query.ToList();
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
            if (e.RowIndex==-1)
            {
                SortingMain(col);
            }
            
        }
    }
}
