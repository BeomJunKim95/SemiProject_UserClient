
namespace TeamProject
{
    partial class Uctrl_CartItemList
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
            this.lbl_ProdName = new System.Windows.Forms.Label();
            this.nu_ProdCount = new System.Windows.Forms.NumericUpDown();
            this.cbx_Check = new System.Windows.Forms.CheckBox();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.pb_ProductImg = new System.Windows.Forms.PictureBox();
            this.btn_DelCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nu_ProdCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ProductImg)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ProdName
            // 
            this.lbl_ProdName.AutoSize = true;
            this.lbl_ProdName.Location = new System.Drawing.Point(183, 30);
            this.lbl_ProdName.Name = "lbl_ProdName";
            this.lbl_ProdName.Size = new System.Drawing.Size(38, 12);
            this.lbl_ProdName.TabIndex = 0;
            this.lbl_ProdName.Text = "label1";
            // 
            // nu_ProdCount
            // 
            this.nu_ProdCount.Location = new System.Drawing.Point(411, 28);
            this.nu_ProdCount.Name = "nu_ProdCount";
            this.nu_ProdCount.Size = new System.Drawing.Size(58, 21);
            this.nu_ProdCount.TabIndex = 1;
            this.nu_ProdCount.ValueChanged += new System.EventHandler(this.nu_ProdCount_ValueChanged);
            // 
            // cbx_Check
            // 
            this.cbx_Check.AutoSize = true;
            this.cbx_Check.Location = new System.Drawing.Point(37, 28);
            this.cbx_Check.Name = "cbx_Check";
            this.cbx_Check.Size = new System.Drawing.Size(15, 14);
            this.cbx_Check.TabIndex = 2;
            this.cbx_Check.UseVisualStyleBackColor = true;
            this.cbx_Check.CheckedChanged += new System.EventHandler(this.cbx_Check_CheckedChanged);
            // 
            // lbl_Price
            // 
            this.lbl_Price.AutoSize = true;
            this.lbl_Price.Location = new System.Drawing.Point(519, 30);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(38, 12);
            this.lbl_Price.TabIndex = 3;
            this.lbl_Price.Text = "label1";
            // 
            // pb_ProductImg
            // 
            this.pb_ProductImg.Location = new System.Drawing.Point(58, 3);
            this.pb_ProductImg.Name = "pb_ProductImg";
            this.pb_ProductImg.Size = new System.Drawing.Size(100, 68);
            this.pb_ProductImg.TabIndex = 5;
            this.pb_ProductImg.TabStop = false;
            // 
            // btn_DelCart
            // 
            this.btn_DelCart.Location = new System.Drawing.Point(599, 20);
            this.btn_DelCart.Name = "btn_DelCart";
            this.btn_DelCart.Size = new System.Drawing.Size(40, 32);
            this.btn_DelCart.TabIndex = 6;
            this.btn_DelCart.Text = "삭제";
            this.btn_DelCart.UseVisualStyleBackColor = true;
            this.btn_DelCart.Click += new System.EventHandler(this.btn_DelCart_Click);
            // 
            // Uctrl_CartItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_DelCart);
            this.Controls.Add(this.pb_ProductImg);
            this.Controls.Add(this.lbl_Price);
            this.Controls.Add(this.cbx_Check);
            this.Controls.Add(this.nu_ProdCount);
            this.Controls.Add(this.lbl_ProdName);
            this.Name = "Uctrl_CartItemList";
            this.Size = new System.Drawing.Size(642, 74);
            this.Load += new System.EventHandler(this.Uctrl_CartItemList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nu_ProdCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ProductImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ProdName;
        private System.Windows.Forms.NumericUpDown nu_ProdCount;
        private System.Windows.Forms.CheckBox cbx_Check;
        private System.Windows.Forms.Label lbl_Price;
        private System.Windows.Forms.PictureBox pb_ProductImg;
        private System.Windows.Forms.Button btn_DelCart;
    }
}
