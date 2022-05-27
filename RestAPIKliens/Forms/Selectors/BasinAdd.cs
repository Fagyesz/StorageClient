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
    public partial class BasinAdd : Form
    {
        public static string creator;
        private int a;
        private string text;
        private BasinMini b=new BasinMini();
        public BasinAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void BasinAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DateTime theDate = dateTimePicker4.Value.Date;
            DateTime theDate2 = dateTimePicker3.Value.Date;
            b.weight = int.Parse(btnBasinw.Text);
            b.marinadestart = theDate;
            b.marinadeend = theDate2;
            FormRS.Self.DataBasinba(b);
        }
    }
}
