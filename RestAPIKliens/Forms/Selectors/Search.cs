using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestAPIKliens.Forms.Selectors
{
    public partial class Search : Form
    {

        public static string creator;
        private int a;
        private string text;
        private bool settings;
        private int save_p;

        public Search(string a)
        {
            InitializeComponent();
            
            creator = a;
        }
        
        private void LoadTheme()

        {
            
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

        private void Search_Load(object sender, EventArgs e)
        {
            //   LoadTheme();
            CbxRefresh();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            GetALL();

        }

        public static void GetALL()
        {
            switch (creator)
            {
                case "FP":
                    FormFP.Self.GetDataPublic();
                    break;
                case "RS":
                    FormRS.Self.GetDataPublic();
                    break;
                case "Scrap":
                    FormScrap.Self.GetDataPublic();
                    break;
                case "Dry":
                    FormDry.Self.GetDataPublic();
                    break;
                case "Basin":
                    FormBasin.Self.GetDataPublic();
                    break;
                case "Stat":
                    FormStat.Self.GetDataPublic();
                    break;
                default:
                    break;
            }
        }

        private void gtnGetById_Click(object sender, EventArgs e)
        {
            switch (save_p)
            {
                case 1:
                    SearchID();
                    break;
                case 2:
                    SearchName();
                    break;
                case 3:
                    SearchWeight();
                    break;
                case 4:
                    SearchPlace();
                    break;
                case 5:
                    SearchTime();
                    break;

                default:
                    break;
            }
           
        }

        private void SearchTime()
        {
            
            DateTime time = dateTimePicker1.Value;
            switch (creator)
            {
                case "FP":
                    FormFP.Self.GetDataPublicTime(time);
                    break;
                case "RS":
                    FormRS.Self.GetDataPublicTime(time);
                    break;
                case "Scrap":
                    FormScrap.Self.GetDataPublicTime(time);
                    break;
                case "Dry":
                    FormDry.Self.GetDataPublicTime(time);
                    break;
                case "Basin":
                    FormBasin.Self.GetDataPublicTime(time);
                    break;
                case "Stat":
                    FormStat.Self.GetDataPublicTime(time);
                    break;
                default:
                    break;
            }
        }

        private void SearchPlace()
        {
            throw new NotImplementedException();
            switch (creator)
            {
                case "FP":
                    FormFP.Self.GetDataPublicPlace(comboBox4.Text);
                    break;
                case "RS":
                    FormRS.Self.GetDataPublicPlace(comboBox4.Text);
                    break;
                case "Scrap":
                    FormScrap.Self.GetDataPublicSearch(comboBox4.Text,"place");
                    break;
                case "Dry":
                    FormDry.Self.GetDataPublicPlace(comboBox4.Text);
                    break;
                case "Basin":
                    FormBasin.Self.GetDataPublicPlace(comboBox4.Text);
                    break;
                case "Stat":
                    FormStat.Self.GetDataPublicPlace(comboBox4.Text);
                    break;
                default:
                    break;
            }
        }

        private void SearchWeight()
        {
            
            switch (creator)
            {
                case "FP":
                    FormFP.Self.GetDataPublicWeight(comboBox3.Text);
                    break;
                case "RS":
                    FormRS.Self.GetDataPublicWeight(comboBox3.Text);
                    break;
                case "Scrap":
                    FormScrap.Self.GetDataPublicSearch(comboBox3.Text,"weight");
                    break;
                case "Dry":
                    FormDry.Self.GetDataPublicWeight(comboBox3.Text);
                    break;
                case "Basin":
                    FormBasin.Self.GetDataPublicWeight(comboBox3.Text);
                    break;
                case "Stat":
                    FormStat.Self.GetDataPublicWeight(comboBox3.Text);
                    break;
                default:
                    break;
            }
        }

        private void SearchName()
        {
            
            switch (creator)
            {
                case "FP":
                    FormFP.Self.GetDataPublicName(comboBox2.Text);
                    break;
                case "RS":
                    FormRS.Self.GetDataPublicName(comboBox2.Text);
                    break;
                case "Scrap":
                    FormScrap.Self.GetDataPublicSearch(comboBox2.Text,"name");
                    break;
                case "Dry":
                    FormDry.Self.GetDataPublicName(comboBox2.Text);
                    break;
                case "Basin":
                    FormBasin.Self.GetDataPublicName(comboBox2.Text);
                    break;
                case "Stat":
                    FormStat.Self.GetDataPublicName(comboBox2.Text);
                    break;
                default:
                    break;
            }
        }

        private void SearchID()
        {
            switch (creator)
            {
                case "FP":
                    FormFP.Self.GetDataPublicId(comboBox1.Text);
                    break;
                case "RS":
                    FormRS.Self.GetDataPublicId(comboBox1.Text);
                    break;
                case "Scrap":
                    FormScrap.Self.GetDataPublicSearch(comboBox1.Text,"id");
                    break;
                case "Dry":
                    FormDry.Self.GetDataPublicId(comboBox1.Text);
                    break;
                case "Basin":
                    FormBasin.Self.GetDataPublicId(comboBox1.Text);
                    break;
                case "Stat":
                    FormStat.Self.GetDataPublicId(comboBox1.Text);
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            switch (save_p)
            {
               
                case 2:
                    if (comboBox2.Text.All(char.IsLetterOrDigit))
                    {
                        comboBox2.Items.Add(comboBox2.Text);
                        Save("name");
                    }
                    else
                    {
                        MessageBox.Show("Csak számok és betűk fogadhatóak el");
                    }
                    break;
                case 3:
                    if (comboBox3.Text.All(char.IsDigit))
                    {
                        comboBox3.Items.Add(comboBox3.Text);
                        Save("weight");
                    }
                    else
                    {
                        MessageBox.Show("Csak számok fogadhatóak el súllyként");
                    }
                    break;
                case 4:
                    if (comboBox4.Text.All(char.IsLetterOrDigit))
                    {
                        comboBox4.Items.Add(comboBox4.Text);
                        Save("place");
                    }
                    else
                    {
                        MessageBox.Show("Csak számok és betűk fogadhatóak el");
                    }
                    break;
               
                    
                default:
                    break;
            }



            
            CbxRefresh();
        }
       
       

        private void Settings()
        {
            settings = !settings;
            if (settings)
            {
                btnCollection.Visible = true;

                btnClear.Visible = true;
            }
            else
            {
                btnCollection.Visible = false;

                btnClear.Visible = false;
            }
        }
        private void CbxClear()
        {
            string filePath = "";

            DialogResult dialogResult = MessageBox.Show("Biztos törölni akarod a Választási lehetőségeket?\nNem vonhatod utánna vissza", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {



                filePath = "ComboBoxSaves/SearchName.txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                filePath = "ComboBoxSaves/SearchWeight.txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                filePath = "ComboBoxSaves/SearchPlace.txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                
                CbxRefresh();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }
        private void Save()
        {
            Save("name");
            Save("weight");
            Save("place");
        }
        private void Save(string s)
        {
            string sPath = "";
            Directory.CreateDirectory("ComboBoxSaves");
            switch (s)
            {
                case "name":
                    sPath = "ComboBoxSaves/SearchName.txt";


                    break;
                case "weight":
                    sPath = "ComboBoxSaves/SearchWeight.txt";


                    break;
                case "place":
                    sPath = "ComboBoxSaves/SearchPlace.txt";


                    break;
                default:
                    break;
            }


            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            switch (s)
            {


                case "weight":
                    foreach (var item in comboBox3.Items)
                    {
                        SaveFile.WriteLine(item);
                    }
                    break;
                case "name":
                    foreach (var item in comboBox2.Items)
                    {
                        SaveFile.WriteLine(item);
                    }
                    break;
                case "place":
                    foreach (var item in comboBox4.Items)
                    {
                        SaveFile.WriteLine(item);
                    }
                    break;

                default:
                    break;
            }


            SaveFile.Close();

            MessageBox.Show("Sikeresen hozzáadva");
            CbxRefresh();
        }

        private void CbxRefresh()
        {
            string filePath;


            comboBox2.Items.Clear();
            filePath = "ComboBoxSaves/SearchName.txt";
            if (File.Exists(filePath))
            {

                comboBox2.Items.AddRange(File.ReadAllLines(filePath));
            }

            comboBox3.Items.Clear();
            filePath = "ComboBoxSaves/SearchWeight.txt";
            if (File.Exists(filePath))
            {

                comboBox3.Items.AddRange(File.ReadAllLines(filePath));
            }

            comboBox4.Items.Clear();
            filePath = "ComboBoxSaves/SearchPlace.txt";
            if (File.Exists(filePath))
            {

                comboBox4.Items.AddRange(File.ReadAllLines(filePath));
            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            save_p = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            save_p = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            save_p = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            save_p = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            save_p = 5;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CbxClear();
        }
    }
}
