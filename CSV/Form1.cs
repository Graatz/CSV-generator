using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSV.Model;

namespace CSV
{
    public partial class Form1 : Form
    {
        Generator generator;
        public Form1()
        {
            InitializeComponent();
            generator = new Generator(panel1, panel2, columnsControl, recordsControl, generateControl);
        }
    }
}
