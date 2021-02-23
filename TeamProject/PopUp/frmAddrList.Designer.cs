namespace TeamProject.PopUp
{
	partial class frmAddrList
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
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_UserID = new System.Windows.Forms.Label();
			this.btn_AddAddr = new System.Windows.Forms.Button();
			this.dgv_AddrList = new System.Windows.Forms.DataGridView();
			this.btn_UpdateAddr = new System.Windows.Forms.Button();
			this.btn_DelAddr = new System.Windows.Forms.Button();
			this.btn_Select = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_AddrList)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(38, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "배송지 목록";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.panel1.Controls.Add(this.lbl_UserID);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(-10, -6);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(805, 46);
			this.panel1.TabIndex = 1;
			// 
			// lbl_UserID
			// 
			this.lbl_UserID.AutoSize = true;
			this.lbl_UserID.Location = new System.Drawing.Point(657, 15);
			this.lbl_UserID.Name = "lbl_UserID";
			this.lbl_UserID.Size = new System.Drawing.Size(41, 14);
			this.lbl_UserID.TabIndex = 1;
			this.lbl_UserID.Text = "test11";
			this.lbl_UserID.Visible = false;
			// 
			// btn_AddAddr
			// 
			this.btn_AddAddr.Location = new System.Drawing.Point(669, 59);
			this.btn_AddAddr.Name = "btn_AddAddr";
			this.btn_AddAddr.Size = new System.Drawing.Size(102, 23);
			this.btn_AddAddr.TabIndex = 2;
			this.btn_AddAddr.Text = "신규 배송지 등록";
			this.btn_AddAddr.UseVisualStyleBackColor = true;
			this.btn_AddAddr.Click += new System.EventHandler(this.btn_AddAddr_Click);
			// 
			// dgv_AddrList
			// 
			this.dgv_AddrList.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgv_AddrList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgv_AddrList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_AddrList.Location = new System.Drawing.Point(12, 97);
			this.dgv_AddrList.Name = "dgv_AddrList";
			this.dgv_AddrList.RowHeadersVisible = false;
			this.dgv_AddrList.RowTemplate.Height = 23;
			this.dgv_AddrList.Size = new System.Drawing.Size(759, 209);
			this.dgv_AddrList.TabIndex = 3;
			this.dgv_AddrList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AddrList_CellContentClick);
			// 
			// btn_UpdateAddr
			// 
			this.btn_UpdateAddr.Location = new System.Drawing.Point(12, 312);
			this.btn_UpdateAddr.Name = "btn_UpdateAddr";
			this.btn_UpdateAddr.Size = new System.Drawing.Size(40, 24);
			this.btn_UpdateAddr.TabIndex = 4;
			this.btn_UpdateAddr.Text = "수정";
			this.btn_UpdateAddr.UseVisualStyleBackColor = true;
			this.btn_UpdateAddr.Click += new System.EventHandler(this.btn_UpdateAddr_Click);
			// 
			// btn_DelAddr
			// 
			this.btn_DelAddr.Location = new System.Drawing.Point(58, 312);
			this.btn_DelAddr.Name = "btn_DelAddr";
			this.btn_DelAddr.Size = new System.Drawing.Size(40, 24);
			this.btn_DelAddr.TabIndex = 5;
			this.btn_DelAddr.Text = "삭제";
			this.btn_DelAddr.UseVisualStyleBackColor = true;
			this.btn_DelAddr.Click += new System.EventHandler(this.btn_DelAddr_Click);
			// 
			// btn_Select
			// 
			this.btn_Select.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btn_Select.Location = new System.Drawing.Point(339, 312);
			this.btn_Select.Name = "btn_Select";
			this.btn_Select.Size = new System.Drawing.Size(104, 24);
			this.btn_Select.TabIndex = 6;
			this.btn_Select.Text = "배송지로 선택";
			this.btn_Select.UseVisualStyleBackColor = false;
			this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
			// 
			// frmAddrList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(783, 348);
			this.Controls.Add(this.btn_Select);
			this.Controls.Add(this.btn_DelAddr);
			this.Controls.Add(this.btn_UpdateAddr);
			this.Controls.Add(this.dgv_AddrList);
			this.Controls.Add(this.btn_AddAddr);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.Name = "frmAddrList";
			this.Text = "frmAddrList";
			this.Load += new System.EventHandler(this.frmAddrList_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_AddrList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_AddAddr;
		private System.Windows.Forms.DataGridView dgv_AddrList;
		private System.Windows.Forms.Button btn_UpdateAddr;
		private System.Windows.Forms.Button btn_DelAddr;
		private System.Windows.Forms.Button btn_Select;
		private System.Windows.Forms.Label lbl_UserID;
	}
}