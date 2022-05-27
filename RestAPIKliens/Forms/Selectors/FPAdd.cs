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
    public partial class FPAdd : Form
    {
        public static string creator;
        private int a;
        private string text;
        public FPAdd(string a)
        {
            InitializeComponent();
            creator = a;
        }

        private void FPAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
