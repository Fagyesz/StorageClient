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
       
        

        public FormFP()
        {
            
            InitializeComponent();
            Self = this;
            random = new Random();
            
            this.Text = String.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //GetData();
            
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


            ClearDataGridViewRows(dataGridDry, FPList);

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
            dataGridDry.DataSource = FPList;



        }
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void gtnGetById_Click(object sender, EventArgs e)
        {
            ClearDataGridViewRows(dataGridDry, FPList);

            FPList.Clear();
            var client = new RestClient(URL);
            String ROUTE = txtGetById.Text;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Dry> response = client.Execute<Dry>(request);
            var content = response.Content;


            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            FP a = new FP();
            a = JsonConvert.DeserializeObject<FP>(srt);

            FPList.Add(a);
            dataGridDry.DataSource = FPList;
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

        private void btnPost_Click(object sender, EventArgs e)
        {
            DataPost();
        }

        private void DataPost()
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
            request.AddJsonBody(new Dry
            {

                name = (string)dataGridDry.SelectedRows[0].Cells[1].Value,
                weight = (int)dataGridDry.SelectedRows[0].Cells[2].Value,
                arrived = (DateTime)dataGridDry.SelectedRows[0].Cells[3].Value,
                place = (string)dataGridDry.SelectedRows[0].Cells[4].Value



            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
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

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.FPAdd("FP"), sender);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.Search("FP"), sender);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.FPAdd("FP"), sender);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Selectors.ScrapAdd("FP"), sender);
        }

        private void FormFP_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void fillTxt()
        {
            txtGetById.Text = "yes";
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

        private void GetDataID(string b)
        {
            ClearDataGridViewRows(dataGridDry, FPList);

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
            dataGridDry.DataSource = FPList;
            b = "";
            this.Refresh();
        }


    }
}
