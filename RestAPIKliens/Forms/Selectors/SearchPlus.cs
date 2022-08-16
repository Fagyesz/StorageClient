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
    public partial class SearchPlus : Form
    {
        public static string creator; private string type;

        public SearchPlus(string a)
        {
            InitializeComponent();
            creator = a;
            this.AcceptButton = button1;
        }

        private void SearchPlus_Load(object sender, EventArgs e)
        {
            switch (creator)
            {
                case "FP":
                    radioButcherd.Visible = true;
                    tpButcher1.Visible = true;
                    tpButcher2.Visible = true;

                    radioMarinate.Visible = true;
                    tpMarinate1.Visible = true;
                    tpMarinate2.Visible = true;

                    radiosmoke1.Visible = true;
                    tpSmoked1_1.Visible = true;
                    tpSmoked1_2.Visible = true;

                    break;
                case "Scrap":
                    
                    break;
                case "Dry":
                    tpExpiration1.Visible = true;
                    tpExpiration2.Visible = true;
                    radioExpiration.Visible = true;

                    break;
                case "Basin":
                    radioButcherd.Visible = true;
                    tpButcher1.Visible = true;
                    tpButcher2.Visible = true;

                    radioMarinate.Visible = true;
                    tpMarinate1.Visible = true;
                    tpMarinate2.Visible = true;

                    radioMarinatedend.Visible = true;
                    tpMarinatedend1.Visible = true;
                    tpMarinatedend2.Visible = true;

                    radiosmoke2.Visible = true;
                    tpSmoked2_1.Visible = true;
                    tpSmoked2_2.Visible = true;

                    break;
                case "Stat":
                    radioButcherd.Visible = true;
                    tpButcher1.Visible = true;
                    tpButcher2.Visible = true;

                    radioMarinate.Visible = true;
                    tpMarinate1.Visible = true;
                    tpMarinate2.Visible = true;

                    radiosmoke1.Visible = true;
                    tpSmoked1_1.Visible = true;
                    tpSmoked1_2.Visible = true;

                    radioExport.Visible = true;
                    tpExport1.Visible = true;
                    tpExport2.Visible = true;


                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Datee();
        }

        private void Datee()
        {
            DateTime[,] FP = new DateTime[3, 2];
            DateTime[,] Basin = new DateTime[4, 2];
            DateTime[,] Dry = new DateTime[2, 2];
            DateTime[,] Stat = new DateTime[4, 2];
            switch (creator)
            {

                case "FP":

                    FP[0, 0] = tpButcher1.Value;
                    FP[0, 1] = tpButcher2.Value;
                    FP[1, 0] = tpMarinate1.Value;
                    FP[1, 1] = tpMarinate2.Value;
                    FP[2, 0] = tpSmoked1_1.Value;
                    FP[2, 1] = tpSmoked1_2.Value;

                    FormFP.Self.GetDataPublicTime(FP, type);
                    break;
                case "Scrap":

                    break;
                case "Dry":
                    
                    Dry[0, 0] = tpExpiration1.Value;
                    Dry[0, 1] = tpExpiration2.Value;

                    FormDry.Self.GetDataPublicTime(Dry, type);

                    break;
                case "Basin":


                    Basin[0, 0] = tpButcher1.Value;
                    Basin[0, 1] = tpButcher2.Value;
                    Basin[1, 0] = tpMarinate1.Value;
                    Basin[1, 1] = tpMarinate2.Value;
                    Basin[2, 0] = tpMarinatedend1.Value;
                    Basin[2, 1] = tpMarinatedend2.Value;
                    Basin[3, 0] = tpSmoked2_1.Value;
                    Basin[3, 1] = tpSmoked2_2.Value;
                    FormBasin.Self.GetDataPublicTime(Basin, type);

                    break;
                case "Stat":

                    Stat[0, 0] = tpButcher1.Value;
                    Stat[0, 1] = tpButcher2.Value;
                    Stat[1, 0] = tpMarinate1.Value;
                    Stat[1, 1] = tpMarinate2.Value;
                    Stat[2, 0] = tpSmoked1_1.Value;
                    Stat[2, 1] = tpSmoked1_2.Value;
                    Stat[3, 0] = tpExport1.Value;
                    Stat[3, 1] = tpExport2.Value;
                    FormStat.Self.GetDataPublicTime(Stat, type);


                    break;
                default:
                    break;
            }
        }

        private void radioButcherd_CheckedChanged(object sender, EventArgs e)
        {
            type = "B";
        }

        private void radioMarinate_CheckedChanged(object sender, EventArgs e)
        {
            type = "M";
        }

        private void radiosmoke1_CheckedChanged(object sender, EventArgs e)
        {
            type="S";
        }

        private void radiosmoke2_CheckedChanged(object sender, EventArgs e)
        {
            type = "S";
        }

        private void radioExport_CheckedChanged(object sender, EventArgs e)
        {
            type = "E";
        }

        private void radioMarinatedend_CheckedChanged(object sender, EventArgs e)
        {
            type = "MV";
        }

        private void radioExpiration_CheckedChanged(object sender, EventArgs e)
        {
            type = "EX";
        }
    }
}
