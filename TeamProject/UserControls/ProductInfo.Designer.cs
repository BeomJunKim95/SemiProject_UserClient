namespace TeamProject
{
    partial class ProductInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInfo));
            this.btn_Add = new System.Windows.Forms.Button();
            this.lbl_Producprice = new System.Windows.Forms.Label();
            this.lbl_Productinfo = new System.Windows.Forms.Label();
            this.lbl_ProductName = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_Count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.Location = new System.Drawing.Point(478, 51);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(82, 31);
            this.btn_Add.TabIndex = 11;
            this.btn_Add.Text = "담기 ->";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lbl_Producprice
            // 
            this.lbl_Producprice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Producprice.AutoSize = true;
            this.lbl_Producprice.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Producprice.Location = new System.Drawing.Point(458, 18);
            this.lbl_Producprice.Name = "lbl_Producprice";
            this.lbl_Producprice.Size = new System.Drawing.Size(48, 21);
            this.lbl_Producprice.TabIndex = 10;
            this.lbl_Producprice.Text = "가격";
            this.lbl_Producprice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Producprice.SizeChanged += new System.EventHandler(this.lbl_Producprice_SizeChanged);
            // 
            // lbl_Productinfo
            // 
            this.lbl_Productinfo.AutoSize = true;
            this.lbl_Productinfo.Location = new System.Drawing.Point(99, 36);
            this.lbl_Productinfo.Name = "lbl_Productinfo";
            this.lbl_Productinfo.Size = new System.Drawing.Size(99, 12);
            this.lbl_Productinfo.TabIndex = 8;
            this.lbl_Productinfo.Text = "상품상세(간략히)";
            // 
            // lbl_ProductName
            // 
            this.lbl_ProductName.AutoSize = true;
            this.lbl_ProductName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ProductName.Location = new System.Drawing.Point(99, 12);
            this.lbl_ProductName.Name = "lbl_ProductName";
            this.lbl_ProductName.Size = new System.Drawing.Size(59, 15);
            this.lbl_ProductName.TabIndex = 9;
            this.lbl_ProductName.Text = "상품이름";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_Count
            // 
            this.lbl_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Count.AutoSize = true;
            this.lbl_Count.Location = new System.Drawing.Point(476, 60);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(38, 12);
            this.lbl_Count.TabIndex = 12;
            this.lbl_Count.Text = "label1";
            // 
            // ProductInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_Count);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lbl_Producprice);
            this.Controls.Add(this.lbl_Productinfo);
            this.Controls.Add(this.lbl_ProductName);
            this.Controls.Add(this.pictureBox2);
            this.Name = "ProductInfo";
            this.Size = new System.Drawing.Size(576, 96);
            this.Load += new System.EventHandler(this.UserControl6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label lbl_Producprice;
        private System.Windows.Forms.Label lbl_Productinfo;
        private System.Windows.Forms.Label lbl_ProductName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_Count;
    }
}
