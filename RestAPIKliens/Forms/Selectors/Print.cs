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
        Stat stat = new Stat();

        private List<RS> PrintListRS = new List<RS>();
        private List<Basin> PrintListBasin = new List<Basin>();
        private List<Dry> PrintListDry = new List<Dry>();
        private List<FP> PrintListFP = new List<FP>();
        String URLr = "http://127.0.0.1:3000/resourcestorage/";
        String URLd = "http://127.0.0.1:3000/drystorage/";
        String URLb = "http://127.0.0.1:3000/basin/";
        String URLfp = "http://127.0.0.1:3000/finalproduct/";
        String URLs = "http://127.0.0.1:3000/statistics/";
        int PrintMaxInt=0;
        int print = 0;
        private bool ColumnChange;
        private int PrintType;

        public Print(string a)
        {
            InitializeComponent();
            creator = a;
        }

       

        private void Print_Load(object sender, EventArgs e)
        {
            dataGridView.RowHeadersVisible = false;
          //  panel3.BackColor = Color.Transparent;
            RefreshGrid();
            //TestData();
            


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
            PrintType = 1;
            PreviewHub(PrintType);

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
                case "FP":

                    sh.id = fp.id;
                    sh.name = fp.name;
                    sh.weight = fp.weight;
                    sh.Class = "FP";

                    break;
                case "Stat":

                    sh.id = stat.id;
                    sh.name = stat.name;
                    sh.weight = stat.weight;
                    sh.Class = "Stat";

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
                case "FP":

                    id = FormFP.Self.GetFPID();

                    break;
                case "Stat":

                    id = FormStat.Self.GetStatID();

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
            GetDataID(id, "FP");
            GetDataID(id, "Stat");
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
                    case "FP":

                        fp = GetFPByID(id);

                        break;
                    case "Stat":

                        stat = GetStatByID(id);

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

        private Stat GetStatByID(int id)
        {
            var client = new RestClient(URLs);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<Stat>> response = client.Execute<List<Stat>>(request);

            Stat t = new Stat();
            foreach (Stat a in response.Data)
            {
                if (a.id == id)
                {
                    t = a;
                }


            }
            return t; 
        }

        private FP GetFPByID(int id)
        {
            var client = new RestClient(URLfp);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<FP>> response = client.Execute<List<FP>>(request);

            FP t = new FP();
            foreach (FP a in response.Data)
            {
                if (a.id == id)
                {
                    t = a;
                }


            }
            return t;
        }

        private Basin GetBasinByID(int id)
        {
            var client = new RestClient(URLb);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<Basin>> response = client.Execute<List<Basin>>(request);

            Basin t = new Basin();
            foreach (Basin a in response.Data)
            {
                if (a.id == id)
                {
                    t = a;
                }


            }
            return t;
        }

        private Dry GetDryByID(int id)
        {
            var client = new RestClient(URLd);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<Dry>> response = client.Execute<List<Dry>>(request);

            Dry t = new Dry();
            foreach (Dry a in response.Data)
            {
                if (a.id == id)
                {
                    t = a;
                }


            }
            return t;
        }

        private RS GetRsByID(int id)
        {
            var client = new RestClient(URLr);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<RS>> response = client.Execute<List<RS>>(request);
            RS t = new RS();
            foreach (RS a in response.Data)
            {
                if (a.id == id)
                {
                    t = a;
                }


            }
            return t;
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
            try
            {
                DeletAt();
            }
            catch (Exception)
            {

                MessageBox.Show("Semmit nem lehet törölni");
            }
            
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
            PrintType = 0;
            PreviewHub(PrintType);
        }

        private void PreviewHub(int PrintType)
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
                    
                    Print_Semantics.PrintSemanticRs psRS = new Print_Semantics.PrintSemanticRs(list,PrintType);
                   
                    psRS.ShowDialog();
                    
                        
                    
                    //PrintPreview();

                    break;
                case "Dry":
                    // dry = GetDryByID(id);
                    List<Dry> drylist = new List<Dry>();
                    for (int i = 0; i < ShortList.Count; i++)
                    {
                        id = ShortList[i].id;

                        GetDataID(id);
                        drylist.Add(dry);


                    }
                    PrintSemantics.PrintSemanticDry psD = new PrintSemantics.PrintSemanticDry(drylist, PrintType);
                    //Basin


                    psD.ShowDialog();

                    break;
                case "Basin":
                   
                    List<Basin> blist = new List<Basin>();
                    for (int i = 0; i < ShortList.Count; i++)
                    {
                        id = ShortList[i].id;

                        GetDataID(id);
                        blist.Add(b);
                      

                    }
                    PrintSemantics.PrintSemanticT psB = new PrintSemantics.PrintSemanticT(blist, PrintType);
                    //Basin

                    
                    psB.ShowDialog();
                  //  PrintSemantics.PrintSemanticT psB2 = new PrintSemantics.PrintSemanticT(blist, PrintType);
                    //b = GetBasinByID(id);
                    //psB2.ShowDialog();

                    break;
                case "FP":
                    // dry = GetDryByID(id);
                    List<FP> FPlist = new List<FP>();
                    for (int i = 0; i < ShortList.Count; i++)
                    {
                        id = ShortList[i].id;

                        GetDataID(id);
                        FPlist.Add(fp);


                    }
                    
                    PrintSemantics.PrintSemanticFP psF = new PrintSemantics.PrintSemanticFP(FPlist, PrintType);


                    psF.ShowDialog();

                    break;
                case "Stat":
                    // dry = GetDryByID(id);
                    List<Stat> Statlist = new List<Stat>();
                    for (int i = 0; i < ShortList.Count; i++)
                    {
                        id = ShortList[i].id;

                        GetDataID(id);
                        Statlist.Add(stat);


                    }
                    
                   // PrintSemantics.PrintSemanticExport psE = new PrintSemantics.ExportSemantics(Statlist, PrintType);
                    


                    //psE.ShowDialog();

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
            PrintType = 2;
            PreviewHub(PrintType);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
