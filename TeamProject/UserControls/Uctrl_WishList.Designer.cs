
namespace TeamProject
{
    partial class Uctrl_WishList
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbx_Select = new System.Windows.Forms.CheckBox();
            this.lbl_WishName = new System.Windows.Forms.Label();
            this.btn_ShowList = new System.Windows.Forms.Button();
            this.lbl_ProdList = new System.Windows.Forms.Label();
            this.lbl_price = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbx_Select
            // 
            this.cbx_Select.AutoSize = true;
            this.cbx_Select.Location = new System.Drawing.Point(16, 18);
            this.cbx_Select.Name = "cbx_Select";
            this.cbx_Select.Size = new System.Drawing.Size(15, 14);
            this.cbx_Select.TabIndex = 0;
            this.cbx_Select.UseVisualStyleBackColor = true;
            // 
            // lbl_WishName
            // 
            this.lbl_WishName.AutoSize = true;
            this.lbl_WishName.Location = new System.Drawing.Point(74, 11);
            this.lbl_WishName.Name = "lbl_WishName";
            this.lbl_WishName.Size = new System.Drawing.Size(38, 12);
            this.lbl_WishName.TabIndex = 1;
            this.lbl_WishName.Text = "label1";
            // 
            // btn_ShowList
            // 
            this.btn_ShowList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShowList.Location = new System.Drawing.Point(549, 15);
            this.btn_ShowList.Name = "btn_ShowList";
            this.btn_ShowList.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowList.TabIndex = 2;
            this.btn_ShowList.Text = "상세보기";
            this.btn_ShowList.UseVisualStyleBackColor = true;
            this.btn_ShowList.Click += new System.EventHandler(this.btn_ShowList_Click);
            // 
            // lbl_ProdList
            // 
            this.lbl_ProdList.Location = new System.Drawing.Point(74, 32);
            this.lbl_ProdList.Name = "lbl_ProdList";
            this.lbl_ProdList.Size = new System.Drawing.Size(389, 22);
            this.lbl_ProdList.TabIndex = 3;
            this.lbl_ProdList.Text = "label1";
            // 
            // lbl_price
            // 
            this.lbl_price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_price.AutoSize = true;
            this.lbl_price.Location = new System.Drawing.Point(466, 20);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(38, 12);
            this.lbl_price.TabIndex = 4;
            this.lbl_price.Text = "label1";
            // 
            // Uctrl_WishList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_price);
            this.Controls.Add(this.lbl_ProdList);
            this.Controls.Add(this.btn_ShowList);
            this.Controls.Add(this.lbl_WishName);
            this.Controls.Add(this.cbx_Select);
            this.Name = "Uctrl_WishList";
            this.Size = new System.Drawing.Size(644, 54);
            this.Load += new System.EventHandler(this.Uctrl_WishList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbx_Select;
        private System.Windows.Forms.Label lbl_WishName;
        private System.Windows.Forms.Button btn_ShowList;
        private System.Windows.Forms.Label lbl_ProdList;
        private System.Windows.Forms.Label lbl_price;
    }
}
