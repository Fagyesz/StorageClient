using RestSharp;
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
    public partial class ScrapAdd : Form
    {
        public static string creator;
        String URL = "http://127.0.0.1:3000/scrap/";
        private string text;
        Scrap SC = new Scrap();
        int currentweight;
        private bool settings;

        public ScrapAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void ScrapAdd_Load(object sender, EventArgs e)
        {
            CbxRefresh();
            this.AcceptButton = btnPost;
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            switch (creator)
            {
                case "FP":
                    SC = FormFP.Self.DataToScrapFP();
                    break;
                case "RS":
                    SC = FormRS.Self.DataToScrapRS();
                    break;

                case "Dry":
                    SC = FormDry.Self.DataToScrapDry();
                    break;
                case "Basin":
                    SC = FormBasin.Self.DataToScrapBasin();
                    break;
                default:
                    break;
            }
            SCmAdd();
        }
        private void SCmAdd()
        {
            SC.time = dateTimePicker1.Value;
            if (!txtPostWeight.Text.All(char.IsDigit))
            {
                MessageBox.Show("Hibás érték");
            }
            else
            {
                currentweight = SC.weight;
                SC.weight = int.Parse(txtPostWeight.Text);
                SC.time = dateTimePicker1.Value;
                if (currentweight < SC.weight)
                {
                    MessageBox.Show("Rossz súly érték \nNem lehet nagyob a meglévőnél");
                }
                else
                {
                    if (currentweight == SC.weight)
                    {
                        switch (creator)
                        {
                            case "FP":
                                FormFP.Self.DeleteBySC();
                                break;
                            case "RS":
                                FormRS.Self.DeleteBySC();
                                break;

                            case "Dry":
                                FormDry.Self.DeleteBySC();
                                break;
                            case "Basin":
                                FormBasin.Self.DeleteBySC();
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        int w = currentweight - SC.weight;
                        switch (creator)
                        {
                            case "FP":
                                FormFP.Self.DecreaseBySC(w);
                                break;
                            case "RS":
                                FormRS.Self.DecreaseBySC(w);
                                break;

                            case "Dry":
                                FormDry.Self.DecreaseBySC(w);
                                break;
                            case "Basin":
                                FormBasin.Self.DecreaseBySC(w);
                                break;
                            default:
                                break;
                        }
                    }
                    DataPost();
                }
            }
        }
        private void DataPost()
        {
            bool check = false;
            if (SC.name == "")
            {
                check = true;
            }
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
                        place = SC.place,
                        time = SC.time,
                        rsid = SC.rsid,
                        did = SC.did,
                        bid = SC.bid,
                        fpid=SC.fpid,
                    });
                }
                catch (Exception)
                {

                    MessageBox.Show("Hibás feltöltés", "");
                }

                IRestResponse response = client.Execute(request);
                //MessageBox.Show("sikeres feltöltés");

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CbxClear();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            if (txtPostWeight.Text.All(char.IsDigit))
            {
                txtPostWeight.Items.Add(txtPostWeight.Text);
                Save("weight");
            }
            else
            {
                MessageBox.Show("Csak számok fogadhatóak el súllyként");
            }
            CbxRefresh();
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
        private void CbxClear()
        {
            string filePath = "";

            DialogResult dialogResult = MessageBox.Show("Biztos törölni akarod a Választási lehetőségeket?\nNem vonhatod utánna vissza", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

               

                filePath = "ComboBoxSaves/ScrapWeight.txt";
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
                    sPath = "ComboBoxSaves/DryNames.txt";


                    break;
                case "weight":
                    sPath = "ComboBoxSaves/ScrapWeight.txt";


                    break;
                case "place":
                    sPath = "ComboBoxSaves/DryPlace.txt";


                    break;
                default:
                    break;
            }


            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            switch (s)
            {
                
                    
                case "weight":
                    foreach (var item in txtPostWeight.Items)
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
            


            txtPostWeight.Items.Clear();
            string filePath = "ComboBoxSaves/ScrapWeight.txt";
            if (File.Exists(filePath))
            {

                txtPostWeight.Items.AddRange(File.ReadAllLines(filePath));
            }


           

        }
    }

}
