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
    public partial class RSAdd : Form
    {
        public static string creator;
        private int a;
        private string text;
        private RS RS =new RS();

        public RSAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void RSAdd_Load(object sender, EventArgs e)
        {

        }
        private void RSPost()
        {
            DateTime theDate = dateTimePicker1.Value.Date;
            DateTime theDate2 = dateTimePicker1.Value.Date;
            RS.name = txtPostName.Text;
            RS.weight = int.Parse(txtPostWeight.Text);
            RS.arrived = theDate;
            RS.butchered = theDate2;
            RS.place = txtPostPlace.Text;
/*
            RS.Add(new RS() { 
                        name = txtPostName.Text,
                        weight = int.Parse(txtPostWeight.Text),
                        arrived = theDate,
                        butchered = theDate2,
                        place = txtPostPlace.Text
            });
*/
            FormRS.Self.DataList(RS);

    }

        private void btnPost_Click(object sender, EventArgs e)
        {
            RSPost();
        }
    }
}
