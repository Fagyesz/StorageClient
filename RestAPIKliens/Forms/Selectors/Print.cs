using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawPrint;

namespace RestAPIKliens.Forms.Selectors
{
    public partial class Print : Form
    {
        public static string creator;
        private int a;
        private List<string> Printers=new List<string>();




        private List<FP> PrintList = new List<FP>();


        public Print(string a)
        {
            InitializeComponent();
            creator = a;
        }

       

        private void Print_Load(object sender, EventArgs e)
        {

           
        }

       

        private void dataGridSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Printing();

        }

        private void btnPrepToPrint_Click(object sender, EventArgs e)
        {
            AddToPrintList();
        }

        private void AddToPrintList()
        {

            throw new NotImplementedException();



        }

        private void btnDelFromPrepToPrint_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
        private void Printing()
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
            printPreviewDialog1.ShowDialog();
        }
    }
}
