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
    public partial class DryAdd : Form
    {
        public static string creator;
        private int a;
        private string text;
        private Dry Dry = new Dry();
        public DryAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            DryPost();
        }
        private void DryPost()
        {
            DateTime theDate = dateTimePicker1.Value.Date;
            
            

            if (!txtPostWeight.Text.All(char.IsDigit))
            {
                MessageBox.Show("Hibás érték");
            }
            else
            {
                Dry.name= txtPostName.Text;
                Dry.weight = int.Parse(txtPostWeight.Text);
                Dry.arrived = theDate;
                Dry.place = txtPostPlace.Text;
                /*
                            RS.Add(new RS() { 
                                        name = txtPostName.Text,
                                        weight = int.Parse(txtPostWeight.Text),
                                        arrived = theDate,
                                        butchered = theDate2,
                                        place = txtPostPlace.Text
                            });
                */
                FormDry.Self.DataList(Dry);
            }


        }

        
    }
}
