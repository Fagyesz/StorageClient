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
        
        String URL = "http://127.0.0.1:3000/resourcestorage/";
        String URLbasin = "http://127.0.0.1:3000/basin/";
        private List<RS> RSList = new List<RS>();
        private List<Basin> BasinList = new List<Basin>();
        public static FormRS Self;
        private List<RS> Rs = new List<RS>();
        private RS singlers = new RS();
     public FormRS()
        {
            InitializeComponent();
            LoadTheme();
            GetData();
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

        private void GetData()
        {


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



        }/*
        private void btnGetAll_Click(object sender, EventArgs e)
        {

            GetData();


        }

        private void gtnGetById_Click(object sender, EventArgs e)
        {
            GetDataID();

        }*/

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
        {
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

            DateTime theDate = dateTimePicker1.Value.Date;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            var client = new RestClient(URL);
            String ROUTE = "put/" + (int)dataGridRS.SelectedRows[0].Cells[0].Value;
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            /*
            int weight = 0;
            if (btnBasinw.Text != "")
            {
                weight = int.Parse(btnBasinw.Text);
            }
            
            if (weight<=0)
            {
                MsInfo("Nulla vagy kissebb súlyt nem lehet tovább küldeni basinba ","NULL");
               
            }
            else
            {
                if (weight>(int)dataGridRS.SelectedRows[0].Cells[2].Value)
                {
                    MsExeption("Túl nagy Súlyt adott meg","Túlcsordulás");MsInfo("Nulla vagy kissebb súlyt nem lehet tovább küldeni basinba ","NULL");
                }
                else
                {
                    
                }
            }
            */
            request.AddJsonBody(new RS
            {

                name = (string)dataGridRS.SelectedRows[0].Cells[1].Value,
                weight = (int)dataGridRS.SelectedRows[0].Cells[2].Value,
                arrived = (DateTime)dataGridRS.SelectedRows[0].Cells[3].Value,
                butchered = (DateTime)dataGridRS.SelectedRows[0].Cells[4].Value,
                place = (string)dataGridRS.SelectedRows[0].Cells[5].Value



            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
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

                DateTime theDate = dateTimePicker1.Value.Date;
                DateTime theDate2 = dateTimePicker1.Value.Date;
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
                        arrived = a.arrived,
                        butchered = a.butchered,
                        place = a.place
                    });
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
            }
            catch (Exception ex)
            {

                MsExeption("Nem lehet basinba rakni \n" + ex, "Hiba");
            }
        }

        public class Basin
        {
            public int id { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public DateTime arrived { get; set; }
            public string place { get; set; }
            public DateTime marinadestart { get; set; }
            public DateTime marinadeend { get; set; }
            public DateTime smoking { get; set; }
            public int rsid { get; set; }

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
                /*
                name = "test";//dataGridRS.SelectedRows[0].Cells[1].Value.ToString();
                weight = 2;//(int)dataGridRS.SelectedRows[0].Cells[2].Value;
                place = "test";//dataGridRS.SelectedRows[0].Cells[5].Value.ToString();
                arrived = DateTime.MinValue;
                marinadestart = DateTime.MinValue;
                marinadeend = DateTime.MinValue;
                smoking = DateTime.MinValue;
                rsid = 3;
                */

                name = dataGridRS.SelectedRows[0].Cells[1].Value.ToString();
                //weight = (int)dataGridRS.SelectedRows[0].Cells[2].Value;
                weight = b.weight;
                place = dataGridRS.SelectedRows[0].Cells[5].Value.ToString();
                arrived = (DateTime)dataGridRS.SelectedRows[0].Cells[3].Value;
                marinadestart = b.marinadestart;
                marinadeend = b.marinadeend;
                smoking = DateTime.MinValue;
                rsid = (int)dataGridRS.SelectedRows[0].Cells[0].Value;



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


            }
            catch (Exception)
            {

                throw;

            }
            IRestResponse response2 = client2.Execute(request);
            MessageBox.Show("Succesfully added.");





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

        private void dataGridRS_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            this.Refresh();
        }
        public void GetDataPublicId(string b)
        {
            GetDataID(b);
            this.Refresh();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("RS"), sender);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.RSAdd("RS"), sender);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.FPAdd("RS"), sender);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.FPAdd("RS"), sender);
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
            LoadTheme();
        }
        public void DataList(RS a)
        {
            DataPost(a);
        }
        public void DataBasinba(BasinMini b)
        {
            BasinbaMethod(b);
        }

    }
}
