using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestAPIKliens.PrintSemantics
{
    public partial class PrintSemanticFP : Form
    {
        FP[] Printarray;
        List<FP> Printlist;

        Bitmap MemoryImage;
        private PrintDocument printDocument3 = new PrintDocument();
        private PrintPreviewDialog previewdlg = new PrintPreviewDialog();
        int type = 0;
        public PrintSemanticFP(List<FP> RsOrigin, int type2)
        {
            InitializeComponent();
            Printlist = RsOrigin;
            Printarray = Printlist.ToArray();
            printDocument3.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
            type = type2;
        }

        private void PrintSemanticFP_Load(object sender, EventArgs e)
        {
            Hide();
            LoadDataToSemantics();
            PrintThisPanel(type);
            Size = new Size(1, 1);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        private void LoadDataToSemantics()
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel3.Visible = false;
            tableLayoutPanel4.Visible = false;
            for (int i = 0; i < Printlist.Count; i++)
            {

                if (Printlist.Count != 0)
                {
                    if (Printlist.Count >= 1)
                    {
                        txt_id1.Text = Printarray[0].id.ToString();
                        txt_name1.Text = Printarray[0].name;
                        txt_weight1.Text = Printarray[0].weight.ToString();
                        txt_place1.Text = Printarray[0].place;
                        txt_arrived1.Text = TimeCreator(Printarray[0].arrived).ToString("yyyy/MM/dd");
                        txt_butchered1.Text = TimeCreator(Printarray[0].butchered).ToString("yyyy/MM/dd");
                        marinated1.Text= TimeCreator(Printarray[0].marinated).ToString("yyyy/MM/dd");
                        smoked1.Text = TimeCreator(Printarray[0].smoked).ToString("yyyy/MM/dd");
                        rs1.Text= Printarray[0].rsid.ToString();
                        d1.Text = Printarray[0].did.ToString();
                        bs1.Text = Printarray[0].bid.ToString();



                        tableLayoutPanel1.Visible = true;
                    }
                    if (Printlist.Count >= 2)
                    {
                        id2.Text = Printarray[1].id.ToString();
                        name2.Text = Printarray[1].name;
                        weight2.Text = Printarray[1].weight.ToString();
                        place2.Text = Printarray[1].place;
                        arrived2.Text = TimeCreator(Printarray[1].arrived).ToString("yyyy/MM/dd");
                        butcherd2.Text = TimeCreator(Printarray[1].butchered).ToString("yyyy/MM/dd");
                        marinated2.Text = TimeCreator(Printarray[1].marinated).ToString("yyyy/MM/dd");
                        label32.Text = TimeCreator(Printarray[1].smoked).ToString("yyyy/MM/dd");
                        rs2.Text = Printarray[1].rsid.ToString();
                        d2.Text = Printarray[1].did.ToString();
                        bs2.Text = Printarray[1].bid.ToString();

                        tableLayoutPanel2.Visible = true;
                    }
                    if (Printlist.Count >= 3)
                    {
                        id3.Text = Printarray[2].id.ToString();
                        name3.Text = Printarray[2].name;
                        weight3.Text = Printarray[2].weight.ToString();
                        place3.Text = Printarray[2].place;
                        arrived3.Text = TimeCreator(Printarray[2].arrived).ToString("yyyy/MM/dd");
                        butcherd3.Text = TimeCreator(Printarray[2].butchered).ToString("yyyy/MM/dd");
                        marinated3.Text = TimeCreator(Printarray[2].marinated).ToString("yyyy/MM/dd");
                        label16.Text = TimeCreator(Printarray[2].smoked).ToString("yyyy/MM/dd");
                        rs3.Text = Printarray[2].rsid.ToString();
                        d3.Text = Printarray[2].did.ToString();
                        bs3.Text = Printarray[2].bid.ToString();
                        tableLayoutPanel3.Visible = true;
                    }
                    if (Printlist.Count >= 4)
                    {
                        id4.Text = Printarray[3].id.ToString();
                        name4.Text = Printarray[3].name;
                        weight4.Text = Printarray[3].weight.ToString();
                        place4.Text = Printarray[3].place;
                        arrived4.Text = TimeCreator(Printarray[3].arrived).ToString("yyyy/MM/dd");
                        butcherd4.Text = TimeCreator(Printarray[3].butchered).ToString("yyyy/MM/dd");
                        marinated4.Text = TimeCreator(Printarray[3].marinated).ToString("yyyy/MM/dd");
                        label24.Text = TimeCreator(Printarray[3].smoked).ToString("yyyy/MM/dd");
                        rs4.Text = Printarray[3].rsid.ToString();
                        d4.Text = Printarray[3].did.ToString();
                        bs4.Text = Printarray[3].bid.ToString();
                        tableLayoutPanel4.Visible = true;
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
        public void Print(Panel pnl, int type)
        {
            Panel pannel = pnl;
            GetPrintArea(pnl);


            switch (type)
            {
                case 0:
                    previewdlg.Document = printDocument3;
                    previewdlg.ShowDialog();
                    break;
                case 1:
                    PrintSimple();
                    break;
                case 2:
                    PrintAdvanced();
                    break;
                default:
                    break;
            }

            Close();
        }

        private void PrintSimple()
        {
            printDocument3.Print();

        }

        private void PrintAdvanced()
        {
            printDialog1.Document = printDocument3;
            DialogResult result = printDialog1.ShowDialog();
            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                printDocument3.Print();
            }
        }

        public void PrintThisPanel(int type)
        {
            Print(this.panel1, type);
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
