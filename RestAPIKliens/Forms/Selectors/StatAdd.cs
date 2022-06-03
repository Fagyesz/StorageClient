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

namespace RestAPIKliens.Forms.Selectors
{
    public partial class StatAdd : Form
    {
        public static string creator;
        String URL = "http://127.0.0.1:3000/statistics/";
        private string text;
        Stat ST = new Stat();
        int currentweight;
        public StatAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void StatAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            switch (creator)
            {
                case "FP":
                    ST = FormFP.Self.DataToStatFP();
                    
                    break;
                case "RS":
                   // ST = FormRS.Self.DataToStatRS();
                    break;

                case "Dry":
                   // ST = FormDry.Self.DataToStatDry();
                    break;
                case "Basin":
                   // ST = FormBasin.Self.DataToStatBasin();
                    break;
                default:
                    break;
            }
            StatmAdd();
        }
        private void StatmAdd()
        {
            
            if (!txtPostWeight.Text.All(char.IsDigit))
            {
                MessageBox.Show("Hibás érték");
            }
            else
            {
                currentweight = ST.weight;
                ST.weight = int.Parse(txtPostWeight.Text);
                ST.stated = dateTimePicker1.Value;
                if (currentweight < ST.weight)
                {
                    MessageBox.Show("Rossz súly érték \nNem lehet nagyob a meglévőnél");
                }
                else
                {
                    if (currentweight == ST.weight)
                    {
                        switch (creator)
                        {
                            case "FP":
                                FormFP.Self.DeleteByST();
                                break;
                            case "RS":
                               // FormRS.Self.DeleteByST();
                                break;

                            case "Dry":
                               // FormDry.Self.DeleteByST();
                                break;
                            case "Basin":
                              //  FormBasin.Self.DeleteByST();
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        int w = currentweight - ST.weight;
                        switch (creator)
                        {
                            case "FP":
                                FormFP.Self.DecreaseByST(w);
                                break;
                            case "RS":
                               // FormRS.Self.DecreaseByST(w);
                                break;

                            case "Dry":
                                //FormDry.Self.DecreaseByST(w);
                                break;
                            case "Basin":
                                //FormBasin.Self.DecreaseByST(w);
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
            if (ST.name == "")
            {
                check = true;
            }
            if (ST.weight == 0)
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
                    request.AddBody(new Stat
                    {
                        fpid = ST.fpid,
                        rsid = ST.rsid,
                        did = ST.did,
                        bid = ST.bid,
                        name = ST.name,
                        weight = ST.weight,
                        place = ST.place,
                        arrived = ST.arrived,
                        marinated = ST.marinated,
                        smoked = ST.smoked,
                        stated = ST.stated
                        
                    });
                }
                catch (Exception)
                {

                    MessageBox.Show("Hibás feltöltés", "");
                }

                IRestResponse response = client.Execute(request);
                MessageBox.Show("Succesfully added.");

            }


        }
    }
}
