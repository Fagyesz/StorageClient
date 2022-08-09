using Newtonsoft.Json;
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
    public partial class FPCreate : Form
    {
        public static string creator;
        private List<FP> FPList = new List<FP>();
        FP fp = new FP();
        private List<Short> ShortList = new List<Short>();
        private bool ColumnChange;
        String URLr = "http://127.0.0.1:3000/resourcestorage/";
        String URLd = "http://127.0.0.1:3000/drystorage/";
        String URLb = "http://127.0.0.1:3000/basin/";
        RS rs = new RS();
        Dry dry = new Dry();
        Basin b = new Basin();
        int fpWeight = 0;
        
        FP fpcreator = new FP();
        bool CreatorRS=false,CreatorDry=false,CreatorBasin=false;

        public FPCreate(string a)
        {
            InitializeComponent();
            creator = a;
        }
        public static void ClearDataGridViewRows(DataGridView dataGridView, List<RS> DryList)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            DryList.Clear();
        }
        private void Delete(string URL,int id)
        {

            var client = new RestClient(URL);
            String ROUTE = "delete/" + id;
            var request = new RestRequest(ROUTE, Method.DELETE);
            IRestResponse response = client.Execute(request);
            //  MessageBox.Show(response.Content);
        }
        private static DateTime TimeCreator(DateTime time)
        {
            // PlusTime();
            int year, month, day;
            year = time.Year; day = time.Day; month = time.Month;
            DateTime a = new DateTime(year, month, day, 1, 1, 1);

            return a;
        }
        private void Put(string URL,int id,int realweight,string type)
        {


            var client = new RestClient(URL);
            String ROUTE = "put/" + id;
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            GetDataID(id, type);
           
            
            switch (type)
            {
                case "RS":

                    request.AddJsonBody(new RS
                    {

                        name = rs.name,
                        weight = realweight,
                        arrived = TimeCreator(rs.arrived),
                        butchered = TimeCreator(rs.butchered),
                        place = rs.place




                    }); ; ;

                    break;
                case "Dry":
                    request.AddJsonBody(new Dry
                    {


                        name = dry.name,
                        weight = realweight,
                        arrived = TimeCreator( dry.arrived),
                        place = dry.place,
                        expiration = TimeCreator(dry.expiration),
                        externalid = dry.externalid,



                    });
                    break;
                case "Basin":
                    request.AddJsonBody(new Basin
                    {


                        name = b.name,
                        weight = realweight,
                        place = b.place,
                        arrived = TimeCreator(b.arrived),
                        marinadestart = TimeCreator(b.marinadestart),
                        marinadeend = TimeCreator(b.marinadeend),
                        smoking = TimeCreator(b.smoking),
                        rsid = b.rsid,


                    });
                    break;
                default:
                    break;
            }
            IRestResponse response = client.Execute(request);





        }

        private DateTime time(DateTime time)
        {
            int year, month, day;
            year = time.Year; day = time.Day; month = time.Month;
          
           // day = day + 2;
            time = new DateTime(year, month, day);
            return time;
        }

        private void btnPrepToPrint_Click(object sender, EventArgs e)
        {
            AddToPrep();
        }
        private void GetDataID(int id)
        {
            GetDataID(id,"RS");
            GetDataID(id,"Dry");
            GetDataID(id,"Basin");
            GetDataID(id, "Basin");
        }
        private void GetDataID(int id,string type)
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
        {/*
            var client = new RestClient(URLd);
            String ROUTE = id.ToString();
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;
            IRestResponse < List < Dry >> response = client.Execute<List<Dry>>(request);
            */
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
        {/*
            var client = new RestClient(URLr);
            String ROUTE = id.ToString();
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<RS> response = client.Execute<RS>(request);
            var content = response.Content;
            string srt;
            srt = content;
            srt = srt.Substring(1, srt.Length - 2);
            */
            

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
                        
                        switch (creator)
                        {

                            case "RS":

                                fp = FormRS.Self.GetDataCreateFP();
                                if (fp.weight>=sh.weight)
                                {
                                    sh.name = fp.name;
                                    sh.id = fp.id;

                                    sh.Class = "Nyersanyag";
                                    ShortList.Add(sh);
                                    FPList.Add(fp);
                                    fp = null;
                                    sh = null;
                                    ClearGrid();
                                    dataGridView.DataSource = ShortList;

                                }
                                else
                                {
                                    MessageBox.Show("Nem lehet nagyobb a meglévőnél");
                                }


                                break;

                            case "Dry":

                                fp = FormDry.Self.GetDataCreateFP();
                                if (fp.weight >= sh.weight)
                                {
                                    sh.name = fp.name;
                                    sh.id = fp.id;

                                    sh.Class = "Száraz";
                                    ShortList.Add(sh);
                                    FPList.Add(fp);
                                    fp = null;
                                    sh = null;
                                    //Form1.Self.DataRefreshFP(ShortList, FPList);
                                }
                                else
                                {
                                    MessageBox.Show("Nem lehet nagyobb a meglévőnél");
                                }
                                break;
                            case "Basin":
                                fp = FormBasin.Self.GetDataCreateFP();
                                if (fp.weight >= sh.weight)
                                {
                                    fp = FormBasin.Self.GetDataCreateFP();

                                    sh.name = fp.name;
                                    sh.id = fp.id;

                                    sh.Class = "Basin";
                                    ShortList.Add(sh);
                                    FPList.Add(fp);
                                    fp = null;
                                    sh = null;
                                    //Form1.Self.DataRefreshFP(ShortList, FPList);
                                }
                                else
                                {
                                    MessageBox.Show("Nem lehet nagyobb a meglévőnél");
                                }
                                break;

                            default:
                                break;
                        }
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



           

            
            Save();
            RefreshGrid();
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

            //MessageBox.Show("Sikeresen hozzáadva");
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
                    fp.bid = int.Parse(tmp[2]);
                    fp.rsid = int.Parse(tmp[1]);
                    fp.name = tmp[4];
                    fp.did = int.Parse(tmp[3]);
                    fp.place = tmp[6];
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
            
            PutOrDel();
            RefreshGrid();
            GetAllCreatorGrid();
            DelAll();

        }

        private static void GetAllCreatorGrid()
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

        private void PutOrDel()
        {
            int[] fpWeight; int[] shWeight;
            string filePath = "";
            fpcreator = null;
            fpcreator = new FP();
            CreatorBasin = false;
            CreatorDry=false;
            CreatorRS=false;

            filePath = "FpCreate/Short.txt";
            if (File.Exists(filePath))
            {
                string[] FPArray = File.ReadAllLines(filePath);
                shWeight =  new int [FPArray.Length];
                int [] id = new int[FPArray.Length];
                string[] url = new string[FPArray.Length];
                for (int i = 0; i < FPArray.Length; i++)
                {
                    string[] tmp = FPArray[i].Split(',');
                    shWeight[i] = int.Parse(tmp[2]);
                    id[i] = int.Parse(tmp[0]);
                    url[i] = tmp[3];


                }
                filePath = "FpCreate/FP.txt";
                
                string[] FPArray2 = File.ReadAllLines(filePath);
                    fpWeight = new int[FPArray.Length];

                for (int i = 0; i < FPArray2.Length; i++)
                {
                    string[] tmp = FPArray2[i].Split(',');
                    fpWeight[i] = int.Parse(tmp[5]);



                }
                for (int i = 0; i < fpWeight.Length; i++)
                {
                    if (fpWeight[i] >= shWeight[i])
                    {
                        int realWeight=fpWeight[i]-shWeight[i];
                        if (realWeight==0)
                        {
                            switch (url[i])
                            {
                                case "Nyersanyag":
                                  
                                    PostFPCreator(URLr, id[i], shWeight[i], "RS", fpWeight.Length,i);
                                    Delete(URLr, id[i]);
                                    break;
                                case "Száraz":
                                    
                                    PostFPCreator(URLd, id[i], shWeight[i], "Dry", fpWeight.Length,i);
                                    Delete(URLd, id[i]);

                                    break;
                                case "Basin":
                                    
                                    PostFPCreator(URLb,id[i], shWeight[i], "Basin", fpWeight.Length,i);
                                    Delete(URLb, id[i]);

                                    break;
                                default:
                                    break;
                            }
                            
                        }
                        else
                        {
                            switch (url[i])
                            {
                                case "Nyersanyag":
                                    Put(URLr, id[i],realWeight,"RS");
                                    PostFPCreator(URLr, id[i], shWeight[i], "RS", fpWeight.Length,i);
                                    break;
                                case "Száraz":
                                    Put(URLd, id[i], realWeight,"Dry");
                                    PostFPCreator(URLd, id[i], shWeight[i], "Dry", fpWeight.Length,i);
                                    break;
                                case "Basin":
                                    Put(URLb, id[i], realWeight,"Basin");
                                    PostFPCreator(URLb, id[i], shWeight[i],"Basin", fpWeight.Length,i);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

            }

            
            
            
        }

        private void PostFPCreator(string URL,int id, int weight, string type,int length,int interation)
        {
            fpWeight += weight;
            switch (type)
                {
                    case "RS":
                        GetDataID(id, type);
                        

                        fpcreator.rsid = rs.id;
                        //fp.name = rs.name;
                        fpcreator.weight = fpWeight;
                        fpcreator.place = rs.place;
                        fpcreator.arrived = TimeCreator(rs.arrived);
                        fpcreator.butchered = TimeCreator(rs.butchered);
                        /*
                        fp.bid = 0;
                        fp.did = 0;
                        fp.externalid = 0;
                        fp.marinated = DateTime.MinValue;
                        fp.smoked=DateTime.MinValue;
                        */
                        CreatorRS = true;
                        break;
                    case "Dry":

                    GetDataID(id, type);
                    fpcreator.did = dry.id;
                        fpcreator.externalid = dry.externalid;
                        //fp.name=dry.name;
                        fpcreator.weight = fpWeight;
                       // fpcreator.place = dry.place;
                      //  fpcreator.arrived = TimeCreator(dry.arrived);
                        /*
                        fp.rsid = 0;
                        fp.bid = 0;
                        fp.butchered = DateTime.MinValue;
                        fp.marinated = DateTime.MinValue;
                        fp.smoked = DateTime.MinValue;
                        */
                        CreatorDry=true;
                        break;
                    case "Basin":
                    GetDataID(id, type);
                    fpcreator.rsid = b.rsid;
                        fpcreator.bid = b.id;
                        // fp.name=b.name;
                        fpcreator.weight = fpWeight;
                        fpcreator.place = b.place;
                        fpcreator.arrived = TimeCreator(b.arrived);
                        fpcreator.marinated = TimeCreator(b.marinadeend);
                        fpcreator.smoked = TimeCreator(b.smoking);
                        fpcreator.butchered= TimeCreator(b.butchered);
                    /*
                    fp.butchered = DateTime.MinValue;
                    fp.did = 0;
                    */
                    CreatorBasin =true;
                        break;
                    default:
                        break;
                }
            




            if (interation == length - 1)
            {
                
                if (!CreatorRS)
                {

                    if (!CreatorDry)
                    {
                        fpcreator.did = 0;
                        fpcreator.externalid = 0;
                    }
                    if (!CreatorBasin)
                    {
                        fpcreator.bid = 0;
                        fpcreator.marinated = DateTime.MinValue;
                        fpcreator.smoked = DateTime.MinValue;
                    }
                }
                if (!CreatorDry)
                {
                   
                    if (!CreatorBasin)
                    {
                        fpcreator.bid = 0;
                        fpcreator.marinated = DateTime.MinValue;
                    }
                    if (!CreatorBasin&&!CreatorRS)
                    {
                        fpcreator.butchered = DateTime.MinValue;
                        fpcreator.rsid = 0;
                        fpcreator.smoked = DateTime.MinValue;
                    }
                }
                if (!CreatorBasin)
                {
                    if (!CreatorRS)
                    {
                        fpcreator.butchered = DateTime.MinValue;
                    }
                    if (!CreatorDry)
                    {
                        fpcreator.did = 0;
                    }
                    
                }
                if (!CreatorBasin && !CreatorRS)
                {
                    GetDataID(id, "Dry");
                    if (dry.place!=null)
                    {
                        fpcreator.place = dry.place;
                        fpcreator.arrived = TimeCreator(dry.arrived);
                    }
                    else
                    {
                        fpcreator.place = "Hiány";
                        fpcreator.arrived = DateTime.Now;
                    }
                    
                }
                if (cmbName.Text.All(char.IsLetterOrDigit))
                {
                    
                    
                    if (cmbName.Text=="")
                    {
                        
                        fpcreator.name = "Hiány";
                    }
                    else
                    {
                        fpcreator.name = cmbName.Text;
                    }
                    DataPost(fpcreator, URL);
                }
                else
                {
                    MessageBox.Show("Csak szám és betű lehet a név");
                }
                
            }
            else
            {
                
            }
        }

        private void DataPost(FP a,string URL)
        {
            bool check = false;
            if (a.name == "")
            {
                check = true;
            }/*
            if (a.weight == null)
            {
                check = true;
            }*/
            if (a.weight == 0)
            {

                check = true;

            }


            if (a.place == "")
            {
                check = true;
            }
            if (check)
            {
                MessageBox.Show("Hiányzó adatok ", "Hibás adatok");
            }
            else
            {
                URL = "http://127.0.0.1:3000/finalproduct/";

                var client = new RestClient(URL);
                String ROUTE = "post";
                var request = new RestRequest(ROUTE, Method.POST);
                request.RequestFormat = DataFormat.Json;
                //DateTime time = TimeCreator();
                try
                {
                    request.AddBody(new FP
                    {
                        id = a.id,
                        rsid = a.rsid,
                        bid = a.bid,
                        did = a.did,
                        externalid = a.externalid,
                        name = a.name,
                        weight = a.weight,
                        place = a.place,
                        arrived = TimeCreator(a.arrived),
                        butchered = TimeCreator(a.butchered),
                        marinated = TimeCreator(a.marinated),
                        smoked = TimeCreator(a.smoked),

                    }) ;
                }
                catch (Exception)
                {

                    MessageBox.Show("Hibás feltöltés", "");
                }

                IRestResponse response = client.Execute(request);
                MessageBox.Show("Sikeresen Hozzáadva.");
                GetAllCreatorGrid();
            }
            
        }

        private void btnDelFromPrepToPrint_Click_1(object sender, EventArgs e)
        {
            DeleteFromPrep();
        }

        private void DeleteFromPrep()
        {
            try
            {

            
            string filePath = "FpCreate/Short.txt";


            int rowIndex = 0;
            rowIndex = dataGridView.CurrentCell.RowIndex;

            string[] FPArray = File.ReadAllLines(filePath);
            FPArray[rowIndex] = null;
            string[] tmp=new string[FPArray.Length-1];
            int k=0;
            for (int i = 0; i < FPArray.Length; i++)
            {
                
                if (FPArray[i]!=null)
                {
                    tmp[k] = FPArray[i];
                    k++;
                }
            }
            File.WriteAllLines(filePath,tmp);
            
            int h = 0;
          
            filePath = "FpCreate/FP.txt";
            string[] FPArray2 = File.ReadAllLines(filePath);
            FPArray2[rowIndex] = null; string[] tmp2 = new string[FPArray2.Length - 1];
            for (int i = 0; i < FPArray2.Length; i++)
            {

                if (FPArray[i] != null)
                {
                    tmp2[h] = FPArray2[i];
                    h++;
                }
            }
            File.WriteAllLines(filePath, tmp2);
            RefreshGrid();
            }
            catch (Exception)
            {

                MessageBox.Show("Semmit nem lehet törölni");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetDataID(6);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DelAll();
        }

        private void DelAll()
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
