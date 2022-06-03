﻿using RestSharp;
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
    public partial class ScrapAdd : Form
    {
        public static string creator;
        String URL = "http://127.0.0.1:3000/scrap/";
        private string text;
        Scrap SC=new Scrap();
        int currentweight;

        public ScrapAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void ScrapAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            switch (creator)
            {
                case "FP":
                    //SC = FormFP.Self.DataToScrapFP();
                    //Selejt adatbázis nem tartalmaz kész terméket 
                    //DB bővítés szükséges
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
                SC.time=dateTimePicker1.Value;
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

            
        }

    }
}
