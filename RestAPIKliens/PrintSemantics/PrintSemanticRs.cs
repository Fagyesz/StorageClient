using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace RestAPIKliens.Print_Semantics
{
    public partial class PrintSemanticRs : Form
    {
        RS[] RSarray;
        List<RS> RSlist;

        Bitmap MemoryImage;
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog previewdlg = new PrintPreviewDialog();

        public PrintSemanticRs(List<RS> RsOrigin)
        {
            InitializeComponent();
            RSlist = RsOrigin;
            RSarray = RSlist.ToArray();
            printDocument1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
           
        }

        private void PrintSemanticRs_Load(object sender, EventArgs e)
        {
            LoadDataToSemantics();
            PrintThisPanel();
        }

        private void LoadDataToSemantics()
        {
            for (int i = 0; i < RSlist.Count; i++)
            {
                if (RSlist.Count!=0)
                {
                    if (RSlist.Count>=1)
                    {
                        id1.Text = RSarray[0].id.ToString();
                        name1.Text = RSarray[0].name;
                        weight1.Text = RSarray[0].weight.ToString();
                        place1.Text = RSarray[0].place;
                        arrived1.Text = TimeCreator(RSarray[0].arrived).ToString("yyyy/MM/dd");
                        butchered1.Text = TimeCreator(RSarray[0].butchered).ToString("yyyy/MM/dd");
                    }
                    if (RSlist.Count >= 2)
                    {
                       id2.Text = RSarray[1].id.ToString();
                        name2.Text = RSarray[1].name;
                        weight2.Text = RSarray[1].weight.ToString();
                        place2.Text = RSarray[1].place;
                        arrived2.Text = TimeCreator(RSarray[1].arrived).ToString("yyyy/MM/dd");
                        butcherd2.Text = TimeCreator(RSarray[1].butchered).ToString("yyyy/MM/dd");
                    }
                    if (RSlist.Count >= 3)
                    {
                        id3.Text = RSarray[2].id.ToString();
                        name3.Text = RSarray[2].name;
                        weight3.Text = RSarray[2].weight.ToString();
                        place3.Text = RSarray[2].place;
                        arrived3.Text = TimeCreator(RSarray[2].arrived).ToString("yyyy/MM/dd");
                        butcherd3.Text = TimeCreator(RSarray[2].butchered).ToString("yyyy/MM/dd");
                    }
                    if (RSlist.Count >= 4)
                    {
                        id4.Text = RSarray[3].id.ToString();
                        name4.Text = RSarray[3].name;
                        weight4.Text = RSarray[3].weight.ToString();
                        place4.Text = RSarray[3].place;
                        arrived4.Text = TimeCreator(RSarray[3].arrived).ToString("yyyy/MM/dd");
                        butcherd4.Text = TimeCreator(RSarray[3].butchered).ToString("yyyy/MM/dd");
                    }
                }
                
            }

        }
        private static DateTime TimeCreator(DateTime time)
        {
            // PlusTime();
            int year, month, day;
            year = time.Year; day = time.Day; month = time.Month;
            DateTime a = new DateTime(year, month, day, 0, 0, 0);

            return a;
        }
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        public void Print(Panel pnl)
        {
            Panel pannel = pnl;
            GetPrintArea(pnl);

            previewdlg.Document = printDocument1;
            previewdlg.ShowDialog();
        }
        public void PrintThisPanel()
        {
           Print(this.panel1);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
                Print(this.panel1);
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
