using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Dynamic;
using TeamProjectVO;
using TeamProjectDAC;

namespace TeamProject
{
    public partial class ProductFeature : UserControl
    {

        private dynamic info = new ExpandoObject();
        public dynamic Info { get => info; set => info = value; }
        public event EventHandler ChangedCombox;

        public ProductFeature()
        {
            InitializeComponent();
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            //BaindingCombox(1);
            //this.Size = new Size(616, 108);
        }


        public void BaindingCombox(int Category_ID)
        {
            PnlFeatures.Controls.Clear();

            Valuez_Service service = new Valuez_Service();
            List<ValuezcConnFeatureVO> vs = service.GetValuezcConns(Category_ID);

            var distens = (from pa in vs
                           group pa by pa.Feature_Name).ToList();

            for (int i = 0; i < distens.Count; i++)
            {
                ComboBox box = new ComboBox
                {
                    Name = distens[i].Key,
                    Size = new Size(135, 23),
                    Location = new Point(5 + (141 * (i % 3)), 8 + (32 * (i / 3))),
                    Text = distens[i].Key
                };
                PnlFeatures.Controls.Add(box);
                List<ValuezcConnFeatureVO> data = new List<ValuezcConnFeatureVO>();
                data.Add(new ValuezcConnFeatureVO { Value_ID = 0, Value_Name = distens[i].Key });
                foreach (ValuezcConnFeatureVO temp in distens[i])
                {
                    data.Add(temp);
                }
                box.DataSource = data;
                box.ValueMember = "Value_ID";
                box.DisplayMember = "Value_Name";
                box.SelectedIndexChanged += (boxsender, boxe) =>
                {
                    ChangedCombox?.Invoke(boxsender, boxe);
                };
            }
        }

        private void PnlFeatures_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
