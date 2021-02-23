namespace TeamProject
{
    partial class frmPCEstimate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Dynamic.ExpandoObject expandoObject1 = new System.Dynamic.ExpandoObject();
            this.Pnl_prol = new System.Windows.Forms.Panel();
            this.pnl_Categories = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_AlladdProductDelete = new System.Windows.Forms.Button();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btn_AddWishList = new System.Windows.Forms.Button();
            this.txt_WishName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_maxPrice = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.lbl_id = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Categorie_Name = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMyInfo = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cbx_maxPrice = new System.Windows.Forms.CheckBox();
            this.ProductFeature = new TeamProject.ProductFeature();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_prol
            // 
            this.Pnl_prol.AutoScroll = true;
            this.Pnl_prol.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Pnl_prol.Location = new System.Drawing.Point(16, 155);
            this.Pnl_prol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pnl_prol.Name = "Pnl_prol";
            this.Pnl_prol.Size = new System.Drawing.Size(606, 499);
            this.Pnl_prol.TabIndex = 5;
            // 
            // pnl_Categories
            // 
            this.pnl_Categories.Location = new System.Drawing.Point(19, 51);
            this.pnl_Categories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_Categories.Name = "pnl_Categories";
            this.pnl_Categories.Size = new System.Drawing.Size(335, 452);
            this.pnl_Categories.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pnl_Categories);
            this.panel1.Location = new System.Drawing.Point(622, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 520);
            this.panel1.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(154, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 19);
            this.label12.TabIndex = 19;
            this.label12.Text = "PC 주요부품";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_AlladdProductDelete);
            this.panel7.Controls.Add(this.lbl_Price);
            this.panel7.Controls.Add(this.label25);
            this.panel7.Location = new System.Drawing.Point(622, 595);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(374, 59);
            this.panel7.TabIndex = 12;
            // 
            // btn_AlladdProductDelete
            // 
            this.btn_AlladdProductDelete.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_AlladdProductDelete.Location = new System.Drawing.Point(301, 7);
            this.btn_AlladdProductDelete.Name = "btn_AlladdProductDelete";
            this.btn_AlladdProductDelete.Size = new System.Drawing.Size(63, 21);
            this.btn_AlladdProductDelete.TabIndex = 3;
            this.btn_AlladdProductDelete.Text = "전체삭제";
            this.btn_AlladdProductDelete.UseVisualStyleBackColor = true;
            this.btn_AlladdProductDelete.Click += new System.EventHandler(this.btn_AlladdProductDelete_Click);
            // 
            // lbl_Price
            // 
            this.lbl_Price.AutoSize = true;
            this.lbl_Price.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Price.Location = new System.Drawing.Point(306, 31);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(52, 24);
            this.lbl_Price.TabIndex = 1;
            this.lbl_Price.Text = "가격";
            this.lbl_Price.SizeChanged += new System.EventHandler(this.lbl_Price_SizeChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.Location = new System.Drawing.Point(6, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(122, 24);
            this.label25.TabIndex = 0;
            this.label25.Text = "총 합계금액";
            // 
            // btn_AddWishList
            // 
            this.btn_AddWishList.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_AddWishList.Location = new System.Drawing.Point(895, 702);
            this.btn_AddWishList.Name = "btn_AddWishList";
            this.btn_AddWishList.Size = new System.Drawing.Size(100, 34);
            this.btn_AddWishList.TabIndex = 18;
            this.btn_AddWishList.Text = "찜목록 등록";
            this.btn_AddWishList.UseVisualStyleBackColor = true;
            this.btn_AddWishList.Click += new System.EventHandler(this.btn_AddWishList_Click);
            // 
            // txt_WishName
            // 
            this.txt_WishName.Location = new System.Drawing.Point(708, 709);
            this.txt_WishName.Name = "txt_WishName";
            this.txt_WishName.Size = new System.Drawing.Size(176, 21);
            this.txt_WishName.TabIndex = 17;
            this.txt_WishName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_WishName_KeyPress);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.Location = new System.Drawing.Point(599, 711);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(88, 17);
            this.label29.TabIndex = 16;
            this.label29.Text = "찜목록 이름";
            // 
            // txt_maxPrice
            // 
            this.txt_maxPrice.Enabled = false;
            this.txt_maxPrice.Location = new System.Drawing.Point(708, 671);
            this.txt_maxPrice.Name = "txt_maxPrice";
            this.txt_maxPrice.Size = new System.Drawing.Size(127, 21);
            this.txt_maxPrice.TabIndex = 14;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button7.Location = new System.Drawing.Point(896, 662);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 34);
            this.button7.TabIndex = 13;
            this.button7.Text = "호환성 체크";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btn_compatibility_Click);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(668, 24);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(0, 12);
            this.lbl_id.TabIndex = 19;
            this.lbl_id.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Categorie_Name);
            this.panel2.Controls.Add(this.ProductFeature);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 138);
            this.panel2.TabIndex = 21;
            // 
            // lbl_Categorie_Name
            // 
            this.lbl_Categorie_Name.AutoSize = true;
            this.lbl_Categorie_Name.Location = new System.Drawing.Point(23, 8);
            this.lbl_Categorie_Name.Name = "lbl_Categorie_Name";
            this.lbl_Categorie_Name.Size = new System.Drawing.Size(0, 12);
            this.lbl_Categorie_Name.TabIndex = 21;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogin.Location = new System.Drawing.Point(932, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(72, 37);
            this.btnLogin.TabIndex = 22;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogout.Location = new System.Drawing.Point(932, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(72, 37);
            this.btnLogout.TabIndex = 23;
            this.btnLogout.Text = "로그아웃";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMyInfo
            // 
            this.btnMyInfo.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMyInfo.Location = new System.Drawing.Point(840, 12);
            this.btnMyInfo.Name = "btnMyInfo";
            this.btnMyInfo.Size = new System.Drawing.Size(72, 37);
            this.btnMyInfo.TabIndex = 24;
            this.btnMyInfo.Text = "내정보";
            this.btnMyInfo.UseVisualStyleBackColor = true;
            this.btnMyInfo.Click += new System.EventHandler(this.btnMyInfo_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(759, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 12);
            this.lblUserName.TabIndex = 25;
            this.lblUserName.Visible = false;
            // 
            // cbx_maxPrice
            // 
            this.cbx_maxPrice.AutoSize = true;
            this.cbx_maxPrice.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbx_maxPrice.Location = new System.Drawing.Point(590, 670);
            this.cbx_maxPrice.Name = "cbx_maxPrice";
            this.cbx_maxPrice.Size = new System.Drawing.Size(97, 23);
            this.cbx_maxPrice.TabIndex = 26;
            this.cbx_maxPrice.Text = "예산 설정";
            this.cbx_maxPrice.UseVisualStyleBackColor = true;
            this.cbx_maxPrice.CheckedChanged += new System.EventHandler(this.cbx_maxPrice_CheckedChanged);
            // 
            // ProductFeature
            // 
            this.ProductFeature.Info = expandoObject1;
            this.ProductFeature.Location = new System.Drawing.Point(3, 26);
            this.ProductFeature.Name = "ProductFeature";
            this.ProductFeature.Size = new System.Drawing.Size(598, 109);
            this.ProductFeature.TabIndex = 20;
            // 
            // frmPCEstimate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 746);
            this.Controls.Add(this.cbx_maxPrice);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnMyInfo);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.btn_AddWishList);
            this.Controls.Add(this.txt_WishName);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txt_maxPrice);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Pnl_prol);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPCEstimate";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_prol;
        private System.Windows.Forms.Panel pnl_Categories;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_AlladdProductDelete;
        private System.Windows.Forms.Label lbl_Price;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btn_AddWishList;
        private System.Windows.Forms.TextBox txt_WishName;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_maxPrice;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lbl_id;
        private ProductFeature ProductFeature;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Categorie_Name;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnMyInfo;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.CheckBox cbx_maxPrice;
    }
}