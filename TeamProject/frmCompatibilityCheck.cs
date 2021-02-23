using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TeamProjectVO;

namespace TeamProject
{
    public partial class frmCompatibilityCheck : Form
	{
		Dictionary<string, List<ProductListVO>> vo;

        public frmCompatibilityCheck()
        {
			InitializeComponent();
		}
		
		public frmCompatibilityCheck(Dictionary<string, List<ProductListVO>> Vo)
		{
			InitializeComponent();
			vo = Vo;
		}

        private void frmCompatibilityCheck_Load(object sender, EventArgs e)
        {
			if (vo.Count < 1)
				return;
			if (!vo.ContainsKey("Mainboard"))
				return;
			Point point =  new Point(30, 35);
			
			if (vo.ContainsKey("CPU"))
            {
				vo["CPU"].ForEach((cpu) =>
				{
					vo["Mainboard"].ForEach((mainboard) =>
					{
						if(!(cpu.Product_Info.Split('/')[2] == mainboard.Product_Info.Split('/')[1]))
                        {
							tabPage1.Controls.Add(new CompatibilityCheck
							{
								Name = cpu.Product_ID.ToString() + mainboard.Product_ID.ToString(),
								Size = new Size(515, 100),
								Location = point,
								product_item1 = "CPU",
								product_item2 = "메인보드",
								item_Compat1 = cpu.Product_Name,
								item_Compat2 = mainboard.Product_Name,
								item_CompatName1 = cpu.Product_Info.Split('/')[2],
								item_CompatName2 = mainboard.Product_Info.Split('/')[1]
							});
							point = new Point(point.X, point.Y + 115);
						}
					});
				});

			}

            if (vo.ContainsKey("Memory"))
            {
				vo["Memory"].ForEach((Memory) =>
				{
					vo["Mainboard"].ForEach((mainboard) =>
					{
						if (!(Memory.Product_Info.Split('/')[1] == mainboard.Product_Info.Split('/')[4]))
						{
							tabPage1.Controls.Add(new CompatibilityCheck
							{
								Name = Memory.Product_ID.ToString() + mainboard.Product_ID.ToString(),
								Size = new Size(515, 100),
								Location = point,
								product_item1 = "Memory",
								product_item2 = "메인보드",
								item_Compat1 = Memory.Product_Name,
								item_Compat2 = mainboard.Product_Name,
								item_CompatName1 = Memory.Product_Info.Split('/')[1],
								item_CompatName2 = mainboard.Product_Info.Split('/')[4]
							});
							point = new Point(point.X, point.Y + 115);
						}
					});
				});
			}

			if (vo.ContainsKey("Case"))
			{
				vo["Case"].ForEach((Memory) =>
				{
					vo["Mainboard"].ForEach((mainboard) =>
					{
						if (!(Memory.Product_Info.Split('/')[1] == mainboard.Product_Info.Split('/')[2]))
						{
							tabPage1.Controls.Add(new CompatibilityCheck
							{
								Name = Memory.Product_ID.ToString() + mainboard.Product_ID.ToString(),
								Size = new Size(515, 100),
								Location = point,
								product_item1 = "Case",
								product_item2 = "메인보드",
								item_Compat1 = Memory.Product_Name,
								item_Compat2 = mainboard.Product_Name,
								item_CompatName1 = Memory.Product_Info.Split('/')[1],
								item_CompatName2 = mainboard.Product_Info.Split('/')[2]
							});
							point = new Point(point.X, point.Y + 115);	//다음 추가 로케이션 지정
						}
					});
				});
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}
