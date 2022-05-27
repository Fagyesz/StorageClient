using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestAPIKliens.Forms
{
    public partial class FormStat : Form
    {
        public static FormStat Self;
        public FormStat()
        {
            InitializeComponent();
            Self = new FormStat();
        }
        public void GetDataPublic()
        {

            //GetData();
            this.Refresh();
        }
        public void GetDataPublicId(string b)
        {
            //GetDataID(b);
            this.Refresh();
        }
    }
}
