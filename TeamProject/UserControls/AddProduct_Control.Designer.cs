namespace TeamProject.UserControls
{
    partial class AddProduct_Control
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_DeleteProduct = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nuCount = new System.Windows.Forms.NumericUpDown();
            this.lblProductName = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_DeleteProduct);
            this.panel2.Controls.Add(this.lblPrice);
            this.panel2.Controls.Add(this.nuCount);
            this.panel2.Controls.Add(this.lblProductName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 30);
            this.panel2.TabIndex = 11;
            // 
            // btn_DeleteProduct
            // 
            this.btn_DeleteProduct.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_DeleteProduct.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_DeleteProduct.Location = new System.Drawing.Point(306, 5);
            this.btn_DeleteProduct.Name = "btn_DeleteProduct";
            this.btn_DeleteProduct.Size = new System.Drawing.Size(18, 22);
            this.btn_DeleteProduct.TabIndex = 3;
            this.btn_DeleteProduct.Text = "X";
            this.btn_DeleteProduct.UseVisualStyleBackColor = true;
            this.btn_DeleteProduct.Click += new System.EventHandler(this.btn_DeleteProduct_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(206, 8);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(29, 12);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "가격";
            this.lblPrice.SizeChanged += new System.EventHandler(this.lblPrice_SizeChanged);
            // 
            // nuCount
            // 
            this.nuCount.Location = new System.Drawing.Point(259, 3);
            this.nuCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuCount.Name = "nuCount";
            this.nuCount.Size = new System.Drawing.Size(41, 21);
            this.nuCount.TabIndex = 1;
            this.nuCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuCount.ValueChanged += new System.EventHandler(this.nuCount_ValueChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(4, 10);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(53, 12);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "상품이름";
            // 
            // AddProduct_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel2);
            this.Name = "AddProduct_Control";
            this.Size = new System.Drawing.Size(330, 30);
            this.Load += new System.EventHandler(this.AddProduct_Control_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_DeleteProduct;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nuCount;
        private System.Windows.Forms.Label lblProductName;
    }
}
