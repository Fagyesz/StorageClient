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
    public partial class Smoker : Form
    {

        public static string creator;


        public Smoker(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void Smoker_Load(object sender, EventArgs e)
        {

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            switch (creator)
            {
                case "Basin":
                    SmokingDataToBasin();
                    break;
                case "RS":
                    SmokingDataToRS();
                    break;

                default:
                    break;
            }
            
        }

        private void SmokingDataToRS()
        {
            FormRS.Self.SmokingSomeData(dateTimePicker1.Value);
        }

        private void SmokingDataToBasin()
        {
           
            FormBasin.Self.SmokingSomeData(dateTimePicker1.Value);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
