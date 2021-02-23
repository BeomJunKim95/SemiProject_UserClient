using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject.UserControls
{
    public partial class Category_Control : UserControl
    {
        public string Category
        {
            get { return lblCategory.Text; }
            set { lblCategory.Text = value; }
        }

        public int LocHeight 
        {
            get { return this.Height; }
        }

        public int PnlHeight
        {
            get { return panel1.Height; }
        }


        public Category_Control()
        {
            InitializeComponent();
        }
    }
}
