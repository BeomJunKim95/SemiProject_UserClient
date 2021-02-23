namespace TeamProject.UserControls
{
    partial class ProductList_Control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductList_Control));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_ProductID = new System.Windows.Forms.Label();
            this.btn_ProductAdd = new System.Windows.Forms.Button();
            this.lbl_ProductPrice = new System.Windows.Forms.Label();
            this.lbl_ProductDetail = new System.Windows.Forms.Label();
            this.lbl_PorductName = new System.Windows.Forms.Label();
            this.Ptb_ProductImage = new System.Windows.Forms.PictureBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ptb_ProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lblCategory);
            this.panel3.Controls.Add(this.lbl_ProductID);
            this.panel3.Controls.Add(this.btn_ProductAdd);
            this.panel3.Controls.Add(this.lbl_ProductPrice);
            this.panel3.Controls.Add(this.lbl_ProductDetail);
            this.panel3.Controls.Add(this.lbl_PorductName);
            this.panel3.Controls.Add(this.Ptb_ProductImage);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(595, 95);
            this.panel3.TabIndex = 1;
            // 
            // lbl_ProductID
            // 
            this.lbl_ProductID.AutoSize = true;
            this.lbl_ProductID.Location = new System.Drawing.Point(100, 80);
            this.lbl_ProductID.Name = "lbl_ProductID";
            this.lbl_ProductID.Size = new System.Drawing.Size(0, 12);
            this.lbl_ProductID.TabIndex = 7;
            this.lbl_ProductID.Visible = false;
            // 
            // btn_ProductAdd
            // 
            this.btn_ProductAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProductAdd.Location = new System.Drawing.Point(503, 54);
            this.btn_ProductAdd.Name = "btn_ProductAdd";
            this.btn_ProductAdd.Size = new System.Drawing.Size(82, 31);
            this.btn_ProductAdd.TabIndex = 6;
            this.btn_ProductAdd.Text = "담기 ->";
            this.btn_ProductAdd.UseVisualStyleBackColor = true;
            this.btn_ProductAdd.Click += new System.EventHandler(this.btn_ProductAdd_Click);
            // 
            // lbl_ProductPrice
            // 
            this.lbl_ProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ProductPrice.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ProductPrice.Location = new System.Drawing.Point(370, 25);
            this.lbl_ProductPrice.Name = "lbl_ProductPrice";
            this.lbl_ProductPrice.Size = new System.Drawing.Size(201, 21);
            this.lbl_ProductPrice.TabIndex = 5;
            this.lbl_ProductPrice.Text = "가격";
            this.lbl_ProductPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ProductDetail
            // 
            this.lbl_ProductDetail.AutoSize = true;
            this.lbl_ProductDetail.Location = new System.Drawing.Point(99, 36);
            this.lbl_ProductDetail.Name = "lbl_ProductDetail";
            this.lbl_ProductDetail.Size = new System.Drawing.Size(99, 12);
            this.lbl_ProductDetail.TabIndex = 4;
            this.lbl_ProductDetail.Text = "상품상세(간략히)";
            // 
            // lbl_PorductName
            // 
            this.lbl_PorductName.AutoSize = true;
            this.lbl_PorductName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PorductName.Location = new System.Drawing.Point(99, 12);
            this.lbl_PorductName.Name = "lbl_PorductName";
            this.lbl_PorductName.Size = new System.Drawing.Size(59, 15);
            this.lbl_PorductName.TabIndex = 4;
            this.lbl_PorductName.Text = "상품이름";
            // 
            // Ptb_ProductImage
            // 
            this.Ptb_ProductImage.Image = ((System.Drawing.Image)(resources.GetObject("Ptb_ProductImage.Image")));
            this.Ptb_ProductImage.Location = new System.Drawing.Point(3, 3);
            this.Ptb_ProductImage.Name = "Ptb_ProductImage";
            this.Ptb_ProductImage.Size = new System.Drawing.Size(90, 90);
            this.Ptb_ProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Ptb_ProductImage.TabIndex = 0;
            this.Ptb_ProductImage.TabStop = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(102, 72);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(0, 12);
            this.lblCategory.TabIndex = 8;
            // 
            // ProductList_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "ProductList_Control";
            this.Size = new System.Drawing.Size(595, 95);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ptb_ProductImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_ProductAdd;
        private System.Windows.Forms.Label lbl_ProductPrice;
        private System.Windows.Forms.Label lbl_ProductDetail;
        private System.Windows.Forms.Label lbl_PorductName;
        private System.Windows.Forms.PictureBox Ptb_ProductImage;
        private System.Windows.Forms.Label lbl_ProductID;
        private System.Windows.Forms.Label lblCategory;
    }
}
