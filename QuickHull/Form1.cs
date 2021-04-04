using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickHull
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void QuickHullBtn_Click(object sender, EventArgs e)
        {
            Hide();
            QuickHullForm quickHullForm = new QuickHullForm();
            quickHullForm.Closed += (s, args) => Close();
            quickHullForm.Show();
        }

        private void MergeBtn_Click(object sender, EventArgs e)
        {
            Hide();
            DivideAndConquerForm mergeForm = new DivideAndConquerForm();
            mergeForm.Closed += (s, args) => Close();
            mergeForm.Show();
        }
    }
}
