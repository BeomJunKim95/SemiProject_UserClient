namespace TeamProject
{
    partial class frm_User_Sign
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblPwdfail2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUserInsert = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtUserEmail2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUserEmail1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUserPhone2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUserPhoneHead = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserPhone1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserPwd2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIDfail = new System.Windows.Forms.Label();
            this.lblIDok = new System.Windows.Forms.Label();
            this.btnIDCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblPwdfail1 = new System.Windows.Forms.Label();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.lbl_Mail_chek = new System.Windows.Forms.Label();
            this.txt_Mail = new System.Windows.Forms.TextBox();
            this.btnCodeCheck = new System.Windows.Forms.Button();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_PhonNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPwdfail2
            // 
            this.lblPwdfail2.AutoSize = true;
            this.lblPwdfail2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPwdfail2.ForeColor = System.Drawing.Color.Red;
            this.lblPwdfail2.Location = new System.Drawing.Point(126, 179);
            this.lblPwdfail2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPwdfail2.Name = "lblPwdfail2";
            this.lblPwdfail2.Size = new System.Drawing.Size(180, 15);
            this.lblPwdfail2.TabIndex = 60;
            this.lblPwdfail2.Text = "* 비밀번호가 일치하지 않습니다.";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(302, 573);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 47);
            this.btnClose.TabIndex = 59;
            this.btnClose.Text = "취소";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUserInsert
            // 
            this.btnUserInsert.Location = new System.Drawing.Point(129, 573);
            this.btnUserInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserInsert.Name = "btnUserInsert";
            this.btnUserInsert.Size = new System.Drawing.Size(100, 47);
            this.btnUserInsert.TabIndex = 58;
            this.btnUserInsert.Text = "회원가입";
            this.btnUserInsert.UseVisualStyleBackColor = true;
            this.btnUserInsert.Click += new System.EventHandler(this.btnUserInsert_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "naver.com",
            "hanmail.com",
            "gmail.com",
            "nate.com",
            "hotmail.com",
            "freechal.com",
            "hamir.com",
            "korea.com",
            "paran.com",
            "직접입력"});
            this.comboBox2.Location = new System.Drawing.Point(433, 332);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(125, 27);
            this.comboBox2.TabIndex = 57;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // txtUserEmail2
            // 
            this.txtUserEmail2.Location = new System.Drawing.Point(302, 332);
            this.txtUserEmail2.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserEmail2.Name = "txtUserEmail2";
            this.txtUserEmail2.Size = new System.Drawing.Size(123, 26);
            this.txtUserEmail2.TabIndex = 56;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(271, 336);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 19);
            this.label13.TabIndex = 55;
            this.label13.Text = "@";
            // 
            // txtUserEmail1
            // 
            this.txtUserEmail1.Location = new System.Drawing.Point(126, 333);
            this.txtUserEmail1.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserEmail1.MaxLength = 100;
            this.txtUserEmail1.Name = "txtUserEmail1";
            this.txtUserEmail1.Size = new System.Drawing.Size(137, 26);
            this.txtUserEmail1.TabIndex = 6;
            this.txtUserEmail1.TextChanged += new System.EventHandler(this.txtUserEmail1_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(60, 338);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 15);
            this.label12.TabIndex = 53;
            this.label12.Text = "E-mail";
            // 
            // txtUserPhone2
            // 
            this.txtUserPhone2.Location = new System.Drawing.Point(341, 271);
            this.txtUserPhone2.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserPhone2.MaxLength = 4;
            this.txtUserPhone2.Name = "txtUserPhone2";
            this.txtUserPhone2.Size = new System.Drawing.Size(79, 26);
            this.txtUserPhone2.TabIndex = 5;
            this.txtUserPhone2.TextChanged += new System.EventHandler(this.txtUserPhone1_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(316, 275);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 19);
            this.label11.TabIndex = 51;
            this.label11.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(207, 275);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 19);
            this.label10.TabIndex = 50;
            this.label10.Text = "-";
            // 
            // txtUserPhoneHead
            // 
            this.txtUserPhoneHead.FormattingEnabled = true;
            this.txtUserPhoneHead.Items.AddRange(new object[] {
            "010",
            "011",
            "016",
            "017",
            "018",
            "019",
            "0139"});
            this.txtUserPhoneHead.Location = new System.Drawing.Point(126, 271);
            this.txtUserPhoneHead.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserPhoneHead.Name = "txtUserPhoneHead";
            this.txtUserPhoneHead.Size = new System.Drawing.Size(74, 27);
            this.txtUserPhoneHead.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(36, 277);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 48;
            this.label9.Text = "휴대폰번호";
            // 
            // txtUserPhone1
            // 
            this.txtUserPhone1.Location = new System.Drawing.Point(229, 271);
            this.txtUserPhone1.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserPhone1.MaxLength = 4;
            this.txtUserPhone1.Name = "txtUserPhone1";
            this.txtUserPhone1.Size = new System.Drawing.Size(80, 26);
            this.txtUserPhone1.TabIndex = 4;
            this.txtUserPhone1.TextChanged += new System.EventHandler(this.txtUserPhone1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(72, 216);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 46;
            this.label6.Text = "이름";
            // 
            // txtUserName
            // 
            this.txtUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtUserName.Location = new System.Drawing.Point(126, 210);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(137, 26);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtUserPwd2
            // 
            this.txtUserPwd2.Location = new System.Drawing.Point(126, 149);
            this.txtUserPwd2.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserPwd2.MaxLength = 12;
            this.txtUserPwd2.Name = "txtUserPwd2";
            this.txtUserPwd2.PasswordChar = '*';
            this.txtUserPwd2.Size = new System.Drawing.Size(288, 26);
            this.txtUserPwd2.TabIndex = 2;
            this.txtUserPwd2.TextChanged += new System.EventHandler(this.txtUserPwd2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(21, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 43;
            this.label5.Text = "비밀번호 확인";
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(126, 88);
            this.txtUserPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserPwd.MaxLength = 12;
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(288, 26);
            this.txtUserPwd.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(48, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "비밀번호";
            // 
            // lblIDfail
            // 
            this.lblIDfail.AutoSize = true;
            this.lblIDfail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIDfail.ForeColor = System.Drawing.Color.Red;
            this.lblIDfail.Location = new System.Drawing.Point(126, 58);
            this.lblIDfail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDfail.Name = "lblIDfail";
            this.lblIDfail.Size = new System.Drawing.Size(171, 15);
            this.lblIDfail.TabIndex = 40;
            this.lblIDfail.Text = "* 사용할 수 없는 아이디입니다.";
            // 
            // lblIDok
            // 
            this.lblIDok.AutoSize = true;
            this.lblIDok.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIDok.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblIDok.Location = new System.Drawing.Point(126, 58);
            this.lblIDok.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDok.Name = "lblIDok";
            this.lblIDok.Size = new System.Drawing.Size(148, 14);
            this.lblIDok.TabIndex = 39;
            this.lblIDok.Text = "* 사용 가능한 아이디입니다.";
            this.lblIDok.Visible = false;
            // 
            // btnIDCheck
            // 
            this.btnIDCheck.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnIDCheck.Location = new System.Drawing.Point(317, 28);
            this.btnIDCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnIDCheck.Name = "btnIDCheck";
            this.btnIDCheck.Size = new System.Drawing.Size(97, 26);
            this.btnIDCheck.TabIndex = 38;
            this.btnIDCheck.Text = "ID중복확인";
            this.btnIDCheck.UseVisualStyleBackColor = true;
            this.btnIDCheck.Click += new System.EventHandler(this.btnIDCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(60, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "아이디";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(126, 28);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserID.MaxLength = 30;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(183, 26);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // lblPwdfail1
            // 
            this.lblPwdfail1.AutoSize = true;
            this.lblPwdfail1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPwdfail1.ForeColor = System.Drawing.Color.Red;
            this.lblPwdfail1.Location = new System.Drawing.Point(126, 122);
            this.lblPwdfail1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPwdfail1.Name = "lblPwdfail1";
            this.lblPwdfail1.Size = new System.Drawing.Size(268, 15);
            this.lblPwdfail1.TabIndex = 61;
            this.lblPwdfail1.Text = "* 영어와 숫자를 이용해 8자리 이상 입력해 주세요";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(126, 405);
            this.btnSendMail.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(111, 36);
            this.btnSendMail.TabIndex = 62;
            this.btnSendMail.Text = "메일 확인";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Mail_chek
            // 
            this.lbl_Mail_chek.AutoSize = true;
            this.lbl_Mail_chek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Mail_chek.ForeColor = System.Drawing.Color.Red;
            this.lbl_Mail_chek.Location = new System.Drawing.Point(126, 367);
            this.lbl_Mail_chek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Mail_chek.Name = "lbl_Mail_chek";
            this.lbl_Mail_chek.Size = new System.Drawing.Size(132, 15);
            this.lbl_Mail_chek.TabIndex = 63;
            this.lbl_Mail_chek.Text = "* 메일을 확인해 주세요.";
            // 
            // txt_Mail
            // 
            this.txt_Mail.Location = new System.Drawing.Point(265, 409);
            this.txt_Mail.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Mail.MaxLength = 100;
            this.txt_Mail.Name = "txt_Mail";
            this.txt_Mail.Size = new System.Drawing.Size(137, 26);
            this.txt_Mail.TabIndex = 64;
            this.txt_Mail.Visible = false;
            // 
            // btnCodeCheck
            // 
            this.btnCodeCheck.Location = new System.Drawing.Point(430, 405);
            this.btnCodeCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCodeCheck.Name = "btnCodeCheck";
            this.btnCodeCheck.Size = new System.Drawing.Size(111, 36);
            this.btnCodeCheck.TabIndex = 65;
            this.btnCodeCheck.Text = "코드 체크";
            this.btnCodeCheck.UseVisualStyleBackColor = true;
            this.btnCodeCheck.Visible = false;
            this.btnCodeCheck.Click += new System.EventHandler(this.btnCodeCheck_Click);
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Name.ForeColor = System.Drawing.Color.Red;
            this.lbl_Name.Location = new System.Drawing.Point(126, 244);
            this.lbl_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(129, 15);
            this.lbl_Name.TabIndex = 66;
            this.lbl_Name.Text = "* 이름을 입력해 주세요";
            // 
            // lbl_PhonNumber
            // 
            this.lbl_PhonNumber.AutoSize = true;
            this.lbl_PhonNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PhonNumber.ForeColor = System.Drawing.Color.Red;
            this.lbl_PhonNumber.Location = new System.Drawing.Point(123, 306);
            this.lbl_PhonNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PhonNumber.Name = "lbl_PhonNumber";
            this.lbl_PhonNumber.Size = new System.Drawing.Size(126, 15);
            this.lbl_PhonNumber.TabIndex = 67;
            this.lbl_PhonNumber.Text = "* 번호를 입력해주세요";
            // 
            // frm_User_Sign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 633);
            this.Controls.Add(this.lbl_PhonNumber);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.btnCodeCheck);
            this.Controls.Add(this.txt_Mail);
            this.Controls.Add(this.lbl_Mail_chek);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.lblPwdfail1);
            this.Controls.Add(this.lblPwdfail2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUserInsert);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.txtUserEmail2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtUserEmail1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUserPhone2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUserPhoneHead);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUserPhone1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtUserPwd2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIDfail);
            this.Controls.Add(this.lblIDok);
            this.Controls.Add(this.btnIDCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserID);
            this.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_User_Sign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.frm_User_Sign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblPwdfail2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUserInsert;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txtUserEmail2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUserEmail1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUserPhone2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox txtUserPhoneHead;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserPhone1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserPwd2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIDfail;
        private System.Windows.Forms.Label lblIDok;
        private System.Windows.Forms.Button btnIDCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblPwdfail1;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.Label lbl_Mail_chek;
        private System.Windows.Forms.TextBox txt_Mail;
        private System.Windows.Forms.Button btnCodeCheck;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_PhonNumber;
    }
}

