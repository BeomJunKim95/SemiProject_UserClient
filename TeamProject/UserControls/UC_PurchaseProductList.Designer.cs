namespace TeamProject
{
	partial class UC_PurchaseProductList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_PurchaseProductList));
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.lbl_TotalPrice = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.lbl_count = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.lbl_ProdName = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.pb_ProductImg = new System.Windows.Forms.PictureBox();
            this.panel14.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ProductImg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.panel20);
            this.panel14.Controls.Add(this.panel18);
            this.panel14.Controls.Add(this.panel17);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(730, 110);
            this.panel14.TabIndex = 16;
            // 
            // panel20
            // 
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.lbl_TotalPrice);
            this.panel20.Location = new System.Drawing.Point(629, -1);
            this.panel20.Margin = new System.Windows.Forms.Padding(6);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(102, 110);
            this.panel20.TabIndex = 9;
            // 
            // lbl_TotalPrice
            // 
            this.lbl_TotalPrice.AutoSize = true;
            this.lbl_TotalPrice.Location = new System.Drawing.Point(8, 48);
            this.lbl_TotalPrice.Name = "lbl_TotalPrice";
            this.lbl_TotalPrice.Size = new System.Drawing.Size(29, 14);
            this.lbl_TotalPrice.TabIndex = 1;
            this.lbl_TotalPrice.Text = "가격";
            // 
            // panel18
            // 
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.lbl_count);
            this.panel18.Location = new System.Drawing.Point(527, -1);
            this.panel18.Margin = new System.Windows.Forms.Padding(6);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(102, 110);
            this.panel18.TabIndex = 8;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(35, 48);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(29, 14);
            this.lbl_count.TabIndex = 2;
            this.lbl_count.Text = "수량";
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.lbl_Price);
            this.panel17.Location = new System.Drawing.Point(425, -1);
            this.panel17.Margin = new System.Windows.Forms.Padding(6);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(102, 110);
            this.panel17.TabIndex = 7;
            // 
            // lbl_Price
            // 
            this.lbl_Price.AutoSize = true;
            this.lbl_Price.Location = new System.Drawing.Point(8, 48);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(29, 14);
            this.lbl_Price.TabIndex = 0;
            this.lbl_Price.Text = "가격";
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.lbl_ProdName);
            this.panel16.Location = new System.Drawing.Point(110, -1);
            this.panel16.Margin = new System.Windows.Forms.Padding(6);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(315, 110);
            this.panel16.TabIndex = 7;
            // 
            // lbl_ProdName
            // 
            this.lbl_ProdName.AutoSize = true;
            this.lbl_ProdName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ProdName.Location = new System.Drawing.Point(32, 48);
            this.lbl_ProdName.Name = "lbl_ProdName";
            this.lbl_ProdName.Size = new System.Drawing.Size(59, 15);
            this.lbl_ProdName.TabIndex = 4;
            this.lbl_ProdName.Text = "상품이름";
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.pb_ProductImg);
            this.panel15.Location = new System.Drawing.Point(0, -1);
            this.panel15.Margin = new System.Windows.Forms.Padding(6);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(110, 110);
            this.panel15.TabIndex = 6;
            // 
            // pb_ProductImg
            // 
            this.pb_ProductImg.Image = ((System.Drawing.Image)(resources.GetObject("pb_ProductImg.Image")));
            this.pb_ProductImg.Location = new System.Drawing.Point(10, 10);
            this.pb_ProductImg.Margin = new System.Windows.Forms.Padding(10);
            this.pb_ProductImg.Name = "pb_ProductImg";
            this.pb_ProductImg.Size = new System.Drawing.Size(90, 90);
            this.pb_ProductImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ProductImg.TabIndex = 0;
            this.pb_ProductImg.TabStop = false;
            // 
            // UC_PurchaseProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel14);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "UC_PurchaseProductList";
            this.Size = new System.Drawing.Size(730, 110);
            this.Load += new System.EventHandler(this.UC_PurchaseProductList_Load);
            this.panel14.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ProductImg)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Panel panel20;
		private System.Windows.Forms.Label lbl_TotalPrice;
		private System.Windows.Forms.Panel panel18;
		private System.Windows.Forms.Label lbl_count;
		private System.Windows.Forms.Panel panel17;
		private System.Windows.Forms.Label lbl_Price;
		private System.Windows.Forms.Panel panel16;
		private System.Windows.Forms.Label lbl_ProdName;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.PictureBox pb_ProductImg;
	}
}
