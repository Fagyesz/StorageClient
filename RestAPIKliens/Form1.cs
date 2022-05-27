using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using RestSharp;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace RestAPIKliens
{
    

    public partial class Form1 : Form
    {
        //788; 458

        //String URL = "http://127.0.0.1:3000/Animals/";
        //String URLuser = "http://127.0.0.1:3000/Users/";
        //bool Loggedin = false;
        //Fields
        private Button currentButton;
        Random random;
        private int tempIndex;
        private Form activeForm;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = String.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void btnGetAll_Click(object sender, EventArgs e)
        {


            /*
            Állatok.Items.Clear();
            var client = new RestClient(URL);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<Animal>> response = client.Execute<List<Animal>>(request);
            foreach(Animal a in response.Data)
            {
                if (a.Pet==1)
                {
                    Állatok.Items.Add("Id: " + a.id + " Név: " + a.Name + " Osztály: " + a.Class + " Lábak száma: " + a.Legs + " Háziállat?: Igen" );
                }
                else
                {
                    Állatok.Items.Add("Id: " + a.id + " Név: " + a.Name + " Osztály: " + a.Class + " Lábak száma: " + a.Legs + " Háziállat?: Nem" );
                }
               
            }
            */

        }


        private void gtnGetById_Click(object sender, EventArgs e)
        {/*
            if (Loggedin)
            {

            
            Állatok.Items.Clear();
            var client = new RestClient(URL);
            String ROUTE = txtGetById.Text;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Animal> response = client.Execute<Animal>(request);
            var content = response.Content;
            //Animal a = new Animal();
            //a = JsonSerializer.Deserialize<Animal>(content);
            Állatok.Items.Add(content);
            }
            else
            {
                notLogedIn();
            }
            */
        }

        private void btnDeleteById_Click(object sender, EventArgs e)
        {/*
            if (Loggedin)
            {


                var client = new RestClient(URL);
                String ROUTE = "delete/" + txtDeleteById.Text;
                var request = new RestRequest(ROUTE, Method.DELETE);
                IRestResponse response = client.Execute(request);
                MessageBox.Show(response.Content);
            }
            else
            {
                notLogedIn();
            }*/
        }

        private void btnPost_Click(object sender, EventArgs e)
        {/*
            if (Loggedin)
            {


                var client = new RestClient(URL);
                String ROUTE = "post";
                var request = new RestRequest(ROUTE, Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(new Animal
                {
                    Name = txtPostName.Text,
                    Class = txtPostAge.Text,
                    Legs = int.Parse(txtPostPos.Text),
                    Pet = int.Parse(txtPostValue.Text)
                });
                IRestResponse response = client.Execute(request);
                MessageBox.Show("Animal succesfully added.");
            }
            else
            {
                notLogedIn();
            }*/
        }

        private void btnPut_Click(object sender, EventArgs e)
        {/*
            if (Loggedin)
            {


                var client = new RestClient(URL);
                String ROUTE = "put/" + txtPutIdText.Text;
                var request = new RestRequest(ROUTE, Method.PUT);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new Animal
                {

                    Name = txtPutName.Text,
                    Class = txtPutAge.Text,
                    Legs = int.Parse(txtPutPosition.Text),
                    Pet = int.Parse(txtPutValue.Text)

                });
                IRestResponse response = client.Execute(request);
                MessageBox.Show(response.Content);
            }
            else
            {
                notLogedIn();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            var client = new RestClient(URLuser);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<User>> response = client.Execute<List<User>>(request);
            foreach (User a in response.Data)
            {
                if (a.Name==username.Text&&a.Password==password.Text)
                {
                    Loggedin = true;
                    Állatok.Items.Clear();
                    Állatok.Items.Add("Sikeres Bejelentkezés!");
                }

            }
            if (Loggedin==false)
            {
                Állatok.Items.Clear();
                Állatok.Items.Add("Hibás Felhasználónév Jelszó kombináció!");
            }
            lblInfo.ForeColor = Color.Green;
            lblInfo.Text = "Succesfully Loaded all the animals.";
            */
        }
        private void notLogedIn()
        {/*
            
                Állatok.Items.Clear();
                Állatok.Items.Add("Nincs bejelentkezve!");
                */

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormRS(), sender);


            this.Width = 1127;
        }

        private void btnDry_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDry(), sender);
            this.Width = 1034;
        }



        //Methods
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
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Verdana", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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
            }
            //lblTitle.Text = childForm.Text;
        }

        /*
        private void btnSetting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSetting(), sender);
        }
        */

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Raktár";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        public class Animal
        {

            public int id { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public int Legs { get; set; }
            public int Pet { get; set; }

        }
        public class RS
        {

            public int id { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public DateTime arrived { get; set; }
            public DateTime butchered { get; set; }
            public string place { get; set; }

        }
        public class Dry
        {

            public int did { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public DateTime arrived { get; set; }
            public string place { get; set; }

        }
        public class Basin
        {

            public int bid { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public DateTime arrived { get; set; }
            public string place { get; set; }
            public DateTime marinadestart { get; set; }
            public DateTime marinadeend { get; set; }
            public DateTime smoking { get; set; }
            public int rsid { get; set; }

        }
        public class FP
        {

            public int fpid { get; set; }
            public int rsid { get; set; }
            public int bid { get; set; }

            public int did { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public string place { get; set; }
            public DateTime arrived { get; set; }

        }
        public class Scrap
        {

            public int scrapid { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public DateTime time { get; set; }
            public int rsid { get; set; }
            public int did { get; set; }

        }
        public class Stat
        {
            public int statid { get; set; }
            public int fpid { get; set; }
            public int rsid { get; set; }
            public int bid { get; set; }
            public int did { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public string place { get; set; }
            public DateTime arrived { get; set; }
            public DateTime marinated { get; set; }
            public DateTime smoked { get; set; }

        }
        public class User
        {

            public int id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }


        }

        private void btnBasin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormBasin(), sender);
            this.Width = 1350;
        }

        private void btnFP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormFP(), sender);
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormStat(), sender);
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormScrap(), sender);
        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void panelTitleBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCloseChildForm_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
    }

    public class RS
    {

        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public DateTime arrived { get; set; }
        public DateTime butchered { get; set; }
        public string place { get; set; }

    }
    public class Dry
    {

        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public DateTime arrived { get; set; }
        public string place { get; set; }

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
    public class BasinMini
    {
        public int weight { get; set; }
        public DateTime marinadestart { get; set; }
        public DateTime marinadeend { get; set; }
    }
        public class FP
    {

        public int id { get; set; }
        public int rsid { get; set; }
        public int bid { get; set; }

        public int did { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public string place { get; set; }
        public DateTime arrived { get; set; }

    }
    public class Scrap
    {

        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public DateTime time { get; set; }
        public int rsid { get; set; }
        public int did { get; set; }

    }
    public class Stat
    {
        public int id { get; set; }
        public int fpid { get; set; }
        public int rsid { get; set; }
        public int bid { get; set; }
        public int did { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public string place { get; set; }
        public DateTime arrived { get; set; }
        public DateTime marinated { get; set; }
        public DateTime smoked { get; set; }

    }
    public class User
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }


    }
}
