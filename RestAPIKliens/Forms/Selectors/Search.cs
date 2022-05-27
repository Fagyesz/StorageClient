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
    public partial class Search : Form
    {

        public static string creator;
        private int a;
        private string text;

        public Search(string a)
        {
            InitializeComponent();
            
            creator = a;
        }
        
        private void LoadTheme()

        {
            
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }



            //label1.ForeColor = ThemeColor.SecondaryColor;
            //label2.ForeColor = ThemeColor.SecondaryColor;
            //.ForeColor = ThemeColor.SecondaryColor;
        }

        private void Search_Load(object sender, EventArgs e)
        {
         //   LoadTheme();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
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

        private void gtnGetById_Click(object sender, EventArgs e)
        {
            
            switch (creator)
            {
                case "FP":
                    FormFP.Self.GetDataPublicId(txtGetById.Text);
                    break;
                case "RS":
                    FormRS.Self.GetDataPublicId(txtGetById.Text);
                    break;
                case "Scrap":
                    FormScrap.Self.GetDataPublicId(txtGetById.Text);
                    break;
                case "Dry":
                    FormDry.Self.GetDataPublicId(txtGetById.Text);
                    break;
                case "Basin":
                    FormBasin.Self.GetDataPublicId(txtGetById.Text);
                    break;
                case "Stat":
                    FormStat.Self.GetDataPublicId(txtGetById.Text);
                    break;
                default:
                    break;
            }
        }
    }
}
