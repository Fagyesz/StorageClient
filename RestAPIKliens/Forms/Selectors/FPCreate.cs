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
    public partial class FPCreate : Form
    {
        public static string creator;
        private List<FP> FPList = new List<FP>();
        FP fp=new FP();
        private List<Short> ShortList = new List<Short>();

        public FPCreate(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void btnPrepToPrint_Click(object sender, EventArgs e)
        {
            AddToPrep();
        }

        private void AddToPrep()
        {
            Short sh = new Short();
            if (cmbWeight.Text.All(char.IsNumber))
            {
                try
                {
                    if (int.Parse(cmbWeight.Text) != 0)
                    {
                        sh.weight = int.Parse(cmbWeight.Text);


                    }
                    else
                    {
                        MessageBox.Show("Súly nem lehet nulla");
                    }
                }
                catch (Exception)
                {

                    
                }
                
            }
            else
            {
                MessageBox.Show("Súly csak szám lehet");
            }



            switch (creator)
            {

                case "RS":

                    fp = FormRS.Self.GetDataCreateFP();
                    sh.name = fp.name;
                    sh.id = fp.id;
                    
                    sh.Class = "Nyersanyag";
                    ShortList.Add(sh);
                    FPList.Add(fp);
                    fp = null;
                    sh = null;
                    ClearGrid();
                    dataGridView.DataSource = ShortList;
                    

                    break;

                case "Dry":

                    fp = FormDry.Self.GetDataCreateFP();

                    sh.name = fp.name;
                    sh.id = fp.id;
                    
                    sh.Class = "Száraz";
                    ShortList.Add(sh);
                    FPList.Add(fp);
                    fp = null;
                    sh = null;
                    //Form1.Self.DataRefreshFP(ShortList, FPList);
                    break;
                case "Basin":

                    fp = FormBasin.Self.GetDataCreateFP();

                    sh.name = fp.name;
                    sh.id = fp.id;
                   
                    sh.Class = "Basin";
                    ShortList.Add(sh);
                    FPList.Add(fp);
                    fp = null;
                    sh = null;
                    //Form1.Self.DataRefreshFP(ShortList, FPList);
                    break;

                default:
                    break;
            }

            // RefreshGrid();
            Save();

        }
        private void Save()
        {
            Save("short");
            Save("fp");
        
        }
            private void Save(string s)
        {
            string sPath = "";
            Directory.CreateDirectory("FpCreate");
            switch (s)
            {
                case "short":
                    sPath = "FpCreate/Short.txt";
                    break;
                case "fp":
                    sPath = "FpCreate/FP.txt";

                    break;
                case "weight":
                    sPath = "FpCreate/FPWeight.txt";

                    break;
                default:
                    break;
            }


            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            switch (s)
            {
                case "short":
                    for (int i = 0; i < ShortList.Count; i++)
                    {
                        SaveFile.WriteLine(ShortList[i].id+","+ShortList[i].name+","+ ShortList[i].weight+","+ ShortList[i].Class);
                    }
                    break;
                case "fp":
                    for (int i = 0; i < FPList.Count; i++)
                    {
                        SaveFile.WriteLine(FPList[i].id + ","+FPList[i].rsid + ","+FPList[i].bid + ","+FPList[i].did + ","+FPList[i].name + ","+FPList[i].weight + ","+FPList[i].place);
                    }
                    break;
                case "weight":
                    foreach (var item in cmbWeight.Items)
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
            cmbWeight.Items.Clear();
            string filePath = "FpCreate/RSWeight.txt";
            if (File.Exists(filePath))
            {

                cmbWeight.Items.AddRange(File.ReadAllLines(filePath));
            }


        }
        private void RefreshGrid()
        {
           // Save();
            ClearGrid();
          // ShortList=Form1.Self.DataRefreshFPGetsh();
           //FPList = Form1.Self.DataRefreshFPGetfp();
           ShortList.Clear();
            FPList.Clear();
            string filePath = "FpCreate/FP.txt";
            if (File.Exists(filePath))
            {
                string[] FPArray =File.ReadAllLines(filePath);
                for (int i = 0; i < FPArray.Length; i++)
                {

                    string[] tmp = FPArray[i].Split(',');

                    FP fp = new FP();
                    int id = int.Parse(tmp[0]);
                    fp.id = id;
                    fp.weight = int.Parse(tmp[5]);
                    FPList.Add(fp);
                    fp = null;


                }
            }
            filePath = "FpCreate/Short.txt";
            if (File.Exists(filePath))
            {
                
                string[] ShortArray = File.ReadAllLines(filePath);
                for (int i = 0; i < ShortArray.Length; i++)
                {
                    Short sh = new Short();
                    string[] tmp = ShortArray[i].Split(',');

                    sh.id = int.Parse(tmp[0]);
                    sh.name = tmp[1].ToString();
                    sh.weight = int.Parse(tmp[2]);
                    sh.Class = tmp[3].ToString();
                    ShortList.Add(sh);
                    sh = null;

                }

            }
           // MessageBox.Show("shlist 0: "+ShortList[0]);
            dataGridView.DataSource = ShortList;
        }

        private void ClearGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
        }

        private void FPCreate_Load(object sender, EventArgs e)
        {
            dataGridView.RowHeadersVisible=false;
            RefreshGrid();
        }

        private void btnDelFromPrepToPrint_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void btnPrepToPrint_Click_1(object sender, EventArgs e)
        {
            AddToPrep();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnDelFromPrepToPrint_Click_1(object sender, EventArgs e)
        {
            DeleteFromPrep();
        }

        private void DeleteFromPrep()
        {

             int rowIndex = dataGridView.CurrentCell.RowIndex;
            
             int PrepId = (int)dataGridView.Rows[rowIndex].Cells[0].Value;
            
            
                
            //string tmp = dataGridView.SelectedRows[0].Cells[0].Value.ToString();

            int idInList = 0;
           
            foreach (var sh in ShortList)
            {


                if (sh.id == PrepId)
                {
                    ShortList.RemoveAt(idInList);
                    FPList.RemoveAt(idInList);
                    break;
                }
                idInList++;
            }

            RefreshGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = "FpCreate/Short.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            filePath = "FpCreate/FP.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            RefreshGrid();
        }
    }
}
