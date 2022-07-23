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
        public static Form1 Self;
        private int tempIndex;
        private Form activeForm;


        private List<Short> shList = new List<Short>();
        private List<FP> fpList = new List<FP>();

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


 
        private void label1_Click(object sender, EventArgs e)
        {

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

        internal void DataRefreshFP(List<Short> shortList, List<FP> fPList)
        {
            shList = shortList; fpList = fPList;
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

        internal List<FP> DataRefreshFPGetfp()
        {
            return fpList;
        }

        internal List<Short> DataRefreshFPGetsh()
        {
           return shList;
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
               
                case "FormBasin":
                    lblTitle.Text = "Basin";
                    break;
                case "FormScrap":
                    lblTitle.Text = "Selejt";
                    break;
                case "FormStat":
                    lblTitle.Text = "Statisztika";
                    break;
                case "FormF":
                    lblTitle.Text = "Kész termék";
                    break;

                default:
                    lblTitle.Text = "Kész termék";
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



        

        private void btnBasin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormBasin(), sender);
            this.Width = 1411;
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormRS(), sender);


            this.Width = 1127;
        }

        private void btnDry_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDry(), sender);
            this.Width = 1233;
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormStat(), sender);
            this.Width = 1815;
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormScrap(), sender);
            this.Width = 1327;
        }
        private void FPbtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormFP(), sender);
            this.Width = 1733;
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

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class RS
    {

        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public string place { get; set; }
        public DateTime arrived { get; set; }
        public DateTime butchered { get; set; }


    }
    public class Dry
    {

        public int id { get; set; }
        public string name { get; set; }

        public int weight { get; set; }

        public string place { get; set; }
        public DateTime arrived { get; set; }

        public DateTime expiration { get; set; }
        public int externalid { get; set; }

    }
    public class Basin
    {

        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public string place { get; set; }
        public DateTime arrived { get; set; }
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
        
        public int externalid { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public string place { get; set; }
        public DateTime arrived { get; set; }
        public DateTime butchered { get; set; }
        public DateTime marinated { get; set; }
        public DateTime smoked { get; set; }

    }
    public class Scrap
    {

        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public string place { get; set; }
        public DateTime time { get; set; }
        public int rsid { get; set; }
        public int did { get; set; }
        public int bid { get; set; }


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
        public DateTime butchered { get; set; }
        public DateTime marinated { get; set; }
        public DateTime smoked { get; set; }
        public DateTime stated { get; set; }

    }
    
    public class User
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }


    }
    public class Short
    {

        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public string Class { get; set; }



    }
}
