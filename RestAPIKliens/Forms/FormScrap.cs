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
        private void DataGridDateFormating()
        {
            dataGridRS.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd.";
            
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
            }
            catch (Exception e)
            {

                MessageBox.Show("Node server nem fut Kijelentkezés szükséges "+e.Message);
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
        }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
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
                time = (DateTime)dataGridRS.SelectedRows[0].Cells[3].Value,
                rsid=(int)dataGridRS.SelectedRows[0].Cells[4].Value,
                did= (int)dataGridRS.SelectedRows[0].Cells[5].Value




            });
            IRestResponse response = client.Execute(request);

            MessageBox.Show(response.Content);
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
            Put();
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
                MessageBox.Show("Succesfully added.");

            }
            GetData();
        }
    }
}
