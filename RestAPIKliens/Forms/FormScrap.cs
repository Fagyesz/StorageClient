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
    public partial class FormScrap : Form
    {
        public static FormScrap Self;
        public FormScrap()
        {
            InitializeComponent();
            Self = this;
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
