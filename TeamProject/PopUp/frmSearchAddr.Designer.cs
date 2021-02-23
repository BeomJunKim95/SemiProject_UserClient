namespace TeamProject.PopUp
{
	partial class frmSearchAddr
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_Search = new System.Windows.Forms.TextBox();
			this.btn_Search = new System.Windows.Forms.Button();
			this.dgv_AddrSearch = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_AddrSearch)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(-4, -3);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(642, 52);
			this.panel1.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(28, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "주소 검색";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(157, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(265, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "도로명, 지번, 건물명에 대한 통합검색";
			// 
			// txt_Search
			// 
			this.txt_Search.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.txt_Search.Location = new System.Drawing.Point(29, 92);
			this.txt_Search.Name = "txt_Search";
			this.txt_Search.Size = new System.Drawing.Size(507, 29);
			this.txt_Search.TabIndex = 5;
			this.txt_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Search_KeyPress);
			// 
			// btn_Search
			// 
			this.btn_Search.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_Search.Location = new System.Drawing.Point(532, 92);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(75, 29);
			this.btn_Search.TabIndex = 6;
			this.btn_Search.Text = "검색";
			this.btn_Search.UseVisualStyleBackColor = true;
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// dgv_AddrSearch
			// 
			this.dgv_AddrSearch.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgv_AddrSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgv_AddrSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_AddrSearch.Location = new System.Drawing.Point(29, 127);
			this.dgv_AddrSearch.Name = "dgv_AddrSearch";
			this.dgv_AddrSearch.RowTemplate.Height = 23;
			this.dgv_AddrSearch.Size = new System.Drawing.Size(578, 258);
			this.dgv_AddrSearch.TabIndex = 7;
			this.dgv_AddrSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AddrSearch_CellDoubleClick);
			// 
			// frmSearchAddr
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 397);
			this.Controls.Add(this.dgv_AddrSearch);
			this.Controls.Add(this.btn_Search);
			this.Controls.Add(this.txt_Search);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.Name = "frmSearchAddr";
			this.Text = "frmSearchAddr";
			this.Load += new System.EventHandler(this.frmSearchAddr_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_AddrSearch)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_Search;
		private System.Windows.Forms.Button btn_Search;
		private System.Windows.Forms.DataGridView dgv_AddrSearch;
	}
}