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
    public partial class BasinAdd : Form
    {
        public static string creator;
        private int a;
        private string text;
        private BasinMini b=new BasinMini();
        private bool settings=false;

        public BasinAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void BasinAdd_Load(object sender, EventArgs e)
        {
            CbxRefresh();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DateTime theDate = dateTimePicker4.Value.Date;
            DateTime theDate2 = dateTimePicker3.Value.Date;
            b.weight = int.Parse(btnBasinw.Text);
            b.marinadestart = theDate;
            b.marinadeend = theDate2;
            
            FormRS.Self.DataBasinba(b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void Settings()
        {
            if (settings)
            {
                settings = false;
            }
            else
                settings = true;
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

        private void btnCollection_Click(object sender, EventArgs e)
        {
            if (btnBasinw.Text.All(char.IsDigit))
            {
                btnBasinw.Items.Add(btnBasinw.Text);
                Save("weight");
            }
            else
            {
                MessageBox.Show("Csak számok fogadhatóak el súllyként");
            }
            CbxRefresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CbxClear();
        }
        private void CbxClear()
        {
            string filePath = "";

            DialogResult dialogResult = MessageBox.Show("Biztos törölni akarod a Választási lehetőségeket?\nNem vonhatod utánna vissza", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

               

                filePath = "ComboBoxSaves/BasinWeight.txt";
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

                case "weight":
                    sPath = "ComboBoxSaves/BasinWeight.txt";

                    break;
                default:
                    break;
            }


            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            switch (s)
            {
                
                case "weight":
                    foreach (var item in btnBasinw.Items)
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

            btnBasinw.Items.Clear();
             string filePath = "ComboBoxSaves/BasinWeight.txt";
            if (File.Exists(filePath))
            {

                btnBasinw.Items.AddRange(File.ReadAllLines(filePath));
            }

        }
    }
}
