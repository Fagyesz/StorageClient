﻿using System;
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
    public partial class RSAdd : Form
    {
        public static string creator;
        private int a;
        private string text;
        private RS RS = new RS();
        private bool settings = false;

        public RSAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void RSAdd_Load(object sender, EventArgs e)
        {
            CbxRefresh();
            this.AcceptButton = btnPost;
        }
        private void RSPost()
        {
            DateTime theDate = dateTimePicker1.Value.Date;
            DateTime theDate2 = dateTimePicker2.Value.Date;
            RS.name = txtPostName.Text;

            if (!txtPostWeight.Text.All(char.IsDigit))
            {
                MessageBox.Show("Hibás érték");
            }
            else
            {

                RS.weight = int.Parse(txtPostWeight.Text);
                RS.arrived = theDate;
                RS.butchered = theDate2;
                RS.place = txtPostPlace.Text;
                /*
                            RS.Add(new RS() { 
                                        name = txtPostName.Text,
                                        weight = int.Parse(txtPostWeight.Text),
                                        arrived = theDate,
                                        butchered = theDate2,
                                        place = txtPostPlace.Text
                            });
                */
                FormRS.Self.DataList(RS);
            }


        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            RSPost();
        }

        private void button2_Click(object sender, EventArgs e)
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
                btnCollection2.Visible = true;
                btnCollection3.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnCollection.Visible = false;
                btnCollection2.Visible = false;
                btnCollection3.Visible = false;
                btnClear.Visible=false;
            }
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            if (txtPostName.Text.All(char.IsLetterOrDigit))
            {
                txtPostName.Items.Add(txtPostName.Text);
                Save("name");
            }
            else
            {
                MessageBox.Show("Csak Betűk és számok az elfogadottak");
            }


        }

        private void btnCollection2_Click(object sender, EventArgs e)
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
        private void btnCollection3_Click(object sender, EventArgs e)
        {
            if (txtPostPlace.Text.All(char.IsLetterOrDigit))
            {
                txtPostPlace.Items.Add(txtPostPlace.Text);
                Save("place");
            }
            else
            {
                MessageBox.Show("Csak Betűk és számok az elfogadottak");
            }
            CbxRefresh();
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
                    sPath = "ComboBoxSaves/RSNames.txt";


                    break;
                case "weight":
                    sPath = "ComboBoxSaves/RSWeight.txt";


                    break;
                case "place":
                    sPath = "ComboBoxSaves/RSPlace.txt";


                    break;
                default:
                    break;
            }


            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            switch (s)
            {
                case "name":
                    foreach (var item in txtPostName.Items)
                    {
                        SaveFile.WriteLine(item);
                    }
                    break;
                case "weight":
                    foreach (var item in txtPostWeight.Items)
                    {
                        SaveFile.WriteLine(item);
                    }
                    break;
                case "place":
                    foreach (var item in txtPostPlace.Items)
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
            txtPostName.Items.Clear();
            string filePath = "ComboBoxSaves/RSNames.txt";
            if (File.Exists(filePath))
            {

                txtPostName.Items.AddRange(File.ReadAllLines(filePath));
            }


            txtPostWeight.Items.Clear();
            filePath = "ComboBoxSaves/RSWeight.txt";
            if (File.Exists(filePath))
            {

                txtPostWeight.Items.AddRange(File.ReadAllLines(filePath));
            }


            txtPostPlace.Items.Clear();
            filePath = "ComboBoxSaves/RSPlace.txt";
            if (File.Exists(filePath))
            {

                txtPostPlace.Items.AddRange(File.ReadAllLines(filePath));
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            CbxRefresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CbxClear();
        }

        private void CbxClear()
        {
            string filePath = "";

            DialogResult dialogResult = MessageBox.Show("Biztos törölni akarod a Választási lehetőségeket?\nNem vonhatod utánna vissza", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                filePath = "ComboBoxSaves/RSPlace.txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                filePath = "ComboBoxSaves/RSNames.txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                filePath = "ComboBoxSaves/RSWeight.txt";
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

    }
}

