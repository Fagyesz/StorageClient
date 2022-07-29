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
using Newtonsoft.Json;
using RawPrint;
using RestSharp;

namespace RestAPIKliens.Forms.Selectors
{
    public partial class Print : Form
    {
        public static string creator;
        private int a;
        private List<string> Printers=new List<string>();
        List<Short> ShortList=new List<Short>();
        Short sh;
        RS rs = new RS();
        Dry dry = new Dry();
        Basin b = new Basin();
        FP fp = new FP();

        private List<RS> PrintListRS = new List<RS>();
        private List<Basin> PrintListBasin = new List<Basin>();
        private List<Dry> PrintListDry = new List<Dry>();
        private List<FP> PrintListFP = new List<FP>();
        String URLr = "http://127.0.0.1:3000/resourcestorage/";
        String URLd = "http://127.0.0.1:3000/drystorage/";
        String URLb = "http://127.0.0.1:3000/basin/";
        int PrintMaxInt=0;
        int print = 0;
        private bool ColumnChange;

        public Print(string a)
        {
            InitializeComponent();
            creator = a;
        }

       

        private void Print_Load(object sender, EventArgs e)
        {
            dataGridView.RowHeadersVisible = false;

            RefreshGrid();
            TestData();
            


        }

        private void TestData()
        {
            List<Short> list = new List<Short>();
            Short test;
            for (int i = 0; i < 3; i++)
            {
                test = null;
                test= new Short();
                test.id = 0;
                test.name = "Hiba";
                test.weight = 0;
                test.Class = "Hiba";
                list.Add(test);
            }
            ClearGrid();
            dataGridView.DataSource = list;
            SetColumsName();

        }

        private bool PrintMax(int max)
        {
            if (max>=4)
            {
                return true;
            }
            else
                return false;
        }
       

        private void dataGridSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Printing(1);

        }

        private void btnPrepToPrint_Click(object sender, EventArgs e)
        {
            if (!PrintMax(print))
            {
                AddToPrintList();
            }
            else
            {
                MessageBox.Show("Max 4 Nyomtatást lehet előkészíteni");
            }
            
        }

        private void AddToPrintList()
        {
            GetDataID(GetIDFromOrigin());
            DataToShort();
            RefreshGrid();

        }

       

        private void DataToShort()
        {

            
           // sh = null;
            sh= new Short();
            switch (creator)
            {
                case "RS":
                    
                    sh.id = rs.id;
                    sh.name = rs.name;
                    sh.weight = rs.weight;
                    sh.Class = "Nyersanyag";

                    break;
                case "Dry":
                    sh.id = dry.id;
                    sh.name = dry.name;
                    sh.weight = dry.weight;
                    sh.Class = "Száraz";

                    break;
                case "Basin":

                    sh.id = b.id;
                    sh.name = b.name;
                    sh.weight = b.weight;
                    sh.Class = "Basin";

                    break;
                default:
                    sh.id = 0;
                    sh.name = "Hiba";
                    sh.weight = 0;
                    sh.Class = "Hiba";
                    break;
            }

            ShortList.Add(sh);
            print++;
        }

        private int GetIDFromOrigin()
        {
            int id = 0;
            switch (creator)
            {
                case "RS":
                    id=FormRS.Self.GetRsID();

                    break;
                case "Dry":
                    id = FormDry.Self.GetDryID();

                    break;
                case "Basin":

                    id = FormBasin.Self.GetBasinID();

                    break;
                default:
                    break;
            }
            return id;
        }

        

        private void GetDataID(int id)
        {

            GetDataID(id, "RS");
            GetDataID(id, "Dry");
            GetDataID(id, "Basin");
        }
        private void GetDataID(int id, string type)
        {

            try
            {

                switch (type)
                {
                    case "RS":
                        rs = GetRsByID(id);

                        break;
                    case "Dry":
                        dry = GetDryByID(id);

                        break;
                    case "Basin":

                        b = GetBasinByID(id);

                        break;
                    default:
                        break;
                }



            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private Basin GetBasinByID(int id)
        {
            var client = new RestClient(URLb);
            String ROUTE = id.ToString();
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Basin> response = client.Execute<Basin>(request);
            var content = response.Content;
            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            Basin a = new Basin();
            a = JsonConvert.DeserializeObject<Basin>(srt);
            return a;
        }

        private Dry GetDryByID(int id)
        {
            var client = new RestClient(URLd);
            String ROUTE = id.ToString();
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<Dry> response = client.Execute<Dry>(request);
            var content = response.Content;
            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            Dry a = new Dry();
            a = JsonConvert.DeserializeObject<Dry>(srt);
            return a;
        }

        private RS GetRsByID(int id)
        {
            var client = new RestClient(URLr);
            String ROUTE = id.ToString();
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<RS> response = client.Execute<RS>(request);
            var content = response.Content;
            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            RS a = new RS();
            a = JsonConvert.DeserializeObject<RS>(srt);
            return a;
        }


        private void SelectOrigin()
        {
            Short sh = new Short();

            try
            {


                switch (creator)
                {

                    case "RS":

                        rs = FormRS.Self.GetDataCreateRS();
                        sh.name = rs.name;
                        sh.weight = rs.weight;
                        sh.Class = "Nyersanyag Raktár";



                        break;

                    case "Dry":

                        dry = FormDry.Self.GetDataCreateDry();
                        
                        sh.name = dry.name;
                        sh.weight = dry.weight;
                        sh.Class = "Száraz Raktár";

                        break;
                    case "Basin":
                        b = FormBasin.Self.GetDataCreateBasin();

                        sh.name = b.name;
                        sh.weight = b.weight;
                        sh.Class = "Basin";
                        break;
                    case "FP":
                        //fp = FormFP.Self.GetDataCreateFP();

                        sh.name = fp.name;
                        sh.weight = fp.weight;
                        sh.Class = "Kész termék";
                        break;

                    default:
                        break;
                }
                Save();
                RefreshGrid();

            }
            catch (Exception)
            {


            }


            
        }
        private void Save()
        {
            Save("short");
            Save("print");

        }
        private void Save(string s)
        {
            string sPath = "";
            Directory.CreateDirectory("Print");
            switch (s)
            {
                case "short":
                    sPath = "Print/Short.txt";
                    break;
                case "fp":
                    sPath = "Print/Print.txt";
                    break;
                case "Dry":
                    sPath = "Print/Dry.txt";
                    break;
                case "RS":
                    sPath = "Print/Print.txt";
                    break;
                case "Basin":
                    sPath = "Print/Basin.txt";
                    break;


                default:
                    break;
            }


            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            switch (s)
            {
                case "short":
                    for (int i = 0; i < print; i++)
                    {
                       // SaveFile.WriteLine(ShortList[i].id + "," + ShortList[i].name + "," + ShortList[i].weight + "," + ShortList[i].Class);
                    }
                    break;
                case "RS":
                    for (int i = 0; i < print; i++)
                    {
                        // SaveFile.WriteLine(ShortList[i].id + "," + ShortList[i].name + "," + ShortList[i].weight + "," + ShortList[i].Class);
                    }
                    break;
                case "fp":
                    for (int i = 0; i < print; i++)
                    {
                       // SaveFile.WriteLine(FPList[i].id + "," + FPList[i].rsid + "," + FPList[i].bid + "," + FPList[i].did + "," + FPList[i].name + "," + FPList[i].weight + "," + FPList[i].place);
                    }
                    break;
               

                default:
                    break;
            }


            SaveFile.Close();

            //MessageBox.Show("Sikeresen hozzáadva");
            CbxRefresh();
        }
        private void CbxRefresh()
        {/*
            cmbWeight.Items.Clear();
            string filePath = "FpCreate/RSWeight.txt";
            if (File.Exists(filePath))
            {

                cmbWeight.Items.AddRange(File.ReadAllLines(filePath));
            }
            */

        }
        private void RefreshGrid()
        {
            
            ClearGrid();
            dataGridView.DataSource = ShortList;
            SetColumsName();
        }

        private void ClearGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
        }

        private void SetColumsName()
        {
            ColumnChange = true;
            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Név";
            dataGridView.Columns[2].HeaderText = "Súly";
            dataGridView.Columns[3].HeaderText = "Raktár";


            ColumnChange = false;
        }
        private void btnDelFromPrepToPrint_Click(object sender, EventArgs e)
        {
            DeletAt();
        }

        private void DeletAt()
        {
            DelById(dataGridView.CurrentCell.RowIndex);
            RefreshGrid();
            print--;
        }

        private void DelById(int id)
        {
            ShortList.RemoveAt(id);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
        private void Printing(int v)
        {

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print();
            }

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreviewHub();
        }

        private void PreviewHub()
        {
            int id=0;
            switch (creator)
            {
                case "RS":
                    RS[] rS=new RS[4];
                    List<RS> list =new List<RS>();

                    for (int i = 0; i < ShortList.Count; i++)
                    {
                        id = ShortList[i].id;
                       
                        GetDataID(id);
                        list.Add(rs);
                        /*rS[i].id = rs.id;
                        rS[i].name = rs.name;
                        rS[i].weight = rs.weight;
                        rS[i].place = rs.place;
                        rS[i].arrived = rs.arrived;
                        rS[i].butchered = rs.butchered;*/

                    }
                    
                    Print_Semantics.PrintSemanticRs psRS = new Print_Semantics.PrintSemanticRs(list,0);
                    
                    psRS.ShowDialog();
                    
                        
                    
                    //PrintPreview();

                    break;
                case "Dry":
                   // dry = GetDryByID(id);

                    break;
                case "Basin":
                    Print_Semantics.PrintSemanticBasin psB = new Print_Semantics.PrintSemanticBasin(list, 0);
                    //b = GetBasinByID(id);

                    break;
                default:
                    break;
            }
        }

        private void PrintPreview()
        {
           
               
            printPreviewDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteAll();
        }

        private void DeleteAll()
        {
            ShortList.Clear();
            RefreshGrid();
            print = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Printing(2);
        }
    }
}
