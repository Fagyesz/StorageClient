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
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                
            }
            DataGridDateFormating();
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
                arrived = (DateTime)dataGridRS.SelectedRows[0].Cells[8].Value,
                marinated = (DateTime)dataGridRS.SelectedRows[0].Cells[9].Value,
                smoked = (DateTime)dataGridRS.SelectedRows[0].Cells[10].Value



            });
            IRestResponse response = client.Execute(request);

            MessageBox.Show(response.Content);
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
            Put();
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
        } 

        private void radioButton1_CheckedChanged_2(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("Stat"), sender);
        }

        private void radioButton4_CheckedChanged_2(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Print("Stat"), sender);
        }
    }
}
