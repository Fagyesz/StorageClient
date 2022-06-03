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
    public partial class Print : Form
    {
        public static string creator;
        private int a;
        private string text;
        public Print(string a)
        {
            InitializeComponent();
            creator = a;
        }
    }
}
