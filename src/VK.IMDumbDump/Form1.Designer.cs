namespace VK.IMDumbDump {
	partial class FrmMain {
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent() {
            this.lbl_login = new System.Windows.Forms.Label();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.btn_logout = new System.Windows.Forms.Button();
            this.lst_dialogs = new System.Windows.Forms.CheckedListBox();
            this.lbl_dialogs = new System.Windows.Forms.Label();
            this.btn_check_all_dialogs = new System.Windows.Forms.Button();
            this.btn_uncheck_all_dialogs = new System.Windows.Forms.Button();
            this.chk_photos = new System.Windows.Forms.CheckBox();
            this.chk_docs = new System.Windows.Forms.CheckBox();
            this.chk_videos = new System.Windows.Forms.CheckBox();
            this.chk_audos = new System.Windows.Forms.CheckBox();
            this.chk_delete_after_dump = new System.Windows.Forms.CheckBox();
            this.txt_save_path = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_dump = new System.Windows.Forms.Button();
            this.grp_account = new System.Windows.Forms.GroupBox();
            this.grp_dump = new System.Windows.Forms.GroupBox();
            this.lbl_save_to = new System.Windows.Forms.Label();
            this.lbl_dump_settings = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.FolderBrowserDialog();
            this.grp_account.SuspendLayout();
            this.grp_dump.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Location = new System.Drawing.Point(6, 21);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(36, 13);
            this.lbl_login.TabIndex = 1;
            this.lbl_login.Text = "Login";
            // 
            // txt_login
            // 
            this.txt_login.Location = new System.Drawing.Point(93, 21);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(100, 22);
            this.txt_login.TabIndex = 2;
            this.txt_login.Text = "god@who.ec";
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Location = new System.Drawing.Point(245, 21);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(56, 13);
            this.lbl_pass.TabIndex = 3;
            this.lbl_pass.Text = "Password";
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(332, 21);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(100, 22);
            this.txt_pass.TabIndex = 4;
            // 
            // btn_logout
            // 
            this.btn_logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_logout.Location = new System.Drawing.Point(502, 51);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 23);
            this.btn_logout.TabIndex = 5;
            this.btn_logout.Text = "Log Out";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // lst_dialogs
            // 
            this.lst_dialogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_dialogs.FormattingEnabled = true;
            this.lst_dialogs.Location = new System.Drawing.Point(24, 60);
            this.lst_dialogs.Name = "lst_dialogs";
            this.lst_dialogs.Size = new System.Drawing.Size(210, 242);
            this.lst_dialogs.TabIndex = 6;
            // 
            // lbl_dialogs
            // 
            this.lbl_dialogs.AutoSize = true;
            this.lbl_dialogs.Location = new System.Drawing.Point(22, 27);
            this.lbl_dialogs.Name = "lbl_dialogs";
            this.lbl_dialogs.Size = new System.Drawing.Size(96, 13);
            this.lbl_dialogs.TabIndex = 7;
            this.lbl_dialogs.Text = "Dialogs to dump:";
            // 
            // btn_check_all_dialogs
            // 
            this.btn_check_all_dialogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_check_all_dialogs.Location = new System.Drawing.Point(24, 322);
            this.btn_check_all_dialogs.Name = "btn_check_all_dialogs";
            this.btn_check_all_dialogs.Size = new System.Drawing.Size(78, 23);
            this.btn_check_all_dialogs.TabIndex = 8;
            this.btn_check_all_dialogs.Text = "Check All";
            this.btn_check_all_dialogs.UseVisualStyleBackColor = true;
            this.btn_check_all_dialogs.Click += new System.EventHandler(this.btn_check_all_dialogs_Click);
            // 
            // btn_uncheck_all_dialogs
            // 
            this.btn_uncheck_all_dialogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_uncheck_all_dialogs.Location = new System.Drawing.Point(126, 322);
            this.btn_uncheck_all_dialogs.Name = "btn_uncheck_all_dialogs";
            this.btn_uncheck_all_dialogs.Size = new System.Drawing.Size(88, 23);
            this.btn_uncheck_all_dialogs.TabIndex = 9;
            this.btn_uncheck_all_dialogs.Text = "Uncheck All";
            this.btn_uncheck_all_dialogs.UseVisualStyleBackColor = true;
            this.btn_uncheck_all_dialogs.Click += new System.EventHandler(this.btn_uncheck_all_dialogs_Click);
            // 
            // chk_photos
            // 
            this.chk_photos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_photos.AutoSize = true;
            this.chk_photos.Checked = true;
            this.chk_photos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_photos.Location = new System.Drawing.Point(278, 60);
            this.chk_photos.Name = "chk_photos";
            this.chk_photos.Size = new System.Drawing.Size(62, 17);
            this.chk_photos.TabIndex = 10;
            this.chk_photos.Text = "Photos";
            this.chk_photos.UseVisualStyleBackColor = true;
            // 
            // chk_docs
            // 
            this.chk_docs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_docs.AutoSize = true;
            this.chk_docs.Enabled = false;
            this.chk_docs.Location = new System.Drawing.Point(436, 60);
            this.chk_docs.Name = "chk_docs";
            this.chk_docs.Size = new System.Drawing.Size(84, 17);
            this.chk_docs.TabIndex = 11;
            this.chk_docs.Text = "Documents";
            this.chk_docs.UseVisualStyleBackColor = true;
            // 
            // chk_videos
            // 
            this.chk_videos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_videos.AutoSize = true;
            this.chk_videos.Enabled = false;
            this.chk_videos.Location = new System.Drawing.Point(278, 107);
            this.chk_videos.Name = "chk_videos";
            this.chk_videos.Size = new System.Drawing.Size(61, 17);
            this.chk_videos.TabIndex = 12;
            this.chk_videos.Text = "Videos";
            this.chk_videos.UseVisualStyleBackColor = true;
            // 
            // chk_audos
            // 
            this.chk_audos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_audos.AutoSize = true;
            this.chk_audos.Enabled = false;
            this.chk_audos.Location = new System.Drawing.Point(436, 107);
            this.chk_audos.Name = "chk_audos";
            this.chk_audos.Size = new System.Drawing.Size(62, 17);
            this.chk_audos.TabIndex = 13;
            this.chk_audos.Text = "Audios";
            this.chk_audos.UseVisualStyleBackColor = true;
            // 
            // chk_delete_after_dump
            // 
            this.chk_delete_after_dump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_delete_after_dump.AutoSize = true;
            this.chk_delete_after_dump.Enabled = false;
            this.chk_delete_after_dump.Location = new System.Drawing.Point(268, 168);
            this.chk_delete_after_dump.Name = "chk_delete_after_dump";
            this.chk_delete_after_dump.Size = new System.Drawing.Size(186, 17);
            this.chk_delete_after_dump.TabIndex = 14;
            this.chk_delete_after_dump.Text = "Delete all messages after dump";
            this.chk_delete_after_dump.UseVisualStyleBackColor = true;
            // 
            // txt_save_path
            // 
            this.txt_save_path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_save_path.Location = new System.Drawing.Point(281, 236);
            this.txt_save_path.Name = "txt_save_path";
            this.txt_save_path.Size = new System.Drawing.Size(187, 22);
            this.txt_save_path.TabIndex = 15;
            // 
            // btn_login
            // 
            this.btn_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_login.Location = new System.Drawing.Point(502, 16);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 16;
            this.btn_login.Text = "Log In";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browse.Location = new System.Drawing.Point(492, 236);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 17;
            this.btn_browse.Text = "...";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_dump
            // 
            this.btn_dump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dump.Location = new System.Drawing.Point(281, 265);
            this.btn_dump.Name = "btn_dump";
            this.btn_dump.Size = new System.Drawing.Size(286, 53);
            this.btn_dump.TabIndex = 18;
            this.btn_dump.Text = "Dump!";
            this.btn_dump.UseVisualStyleBackColor = true;
            this.btn_dump.Click += new System.EventHandler(this.btn_dump_Click);
            // 
            // grp_account
            // 
            this.grp_account.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_account.Controls.Add(this.lbl_login);
            this.grp_account.Controls.Add(this.txt_login);
            this.grp_account.Controls.Add(this.btn_login);
            this.grp_account.Controls.Add(this.lbl_pass);
            this.grp_account.Controls.Add(this.txt_pass);
            this.grp_account.Controls.Add(this.btn_logout);
            this.grp_account.Location = new System.Drawing.Point(12, 10);
            this.grp_account.Name = "grp_account";
            this.grp_account.Size = new System.Drawing.Size(586, 84);
            this.grp_account.TabIndex = 19;
            this.grp_account.TabStop = false;
            this.grp_account.Text = "Login";
            // 
            // grp_dump
            // 
            this.grp_dump.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_dump.Controls.Add(this.lbl_save_to);
            this.grp_dump.Controls.Add(this.lbl_dump_settings);
            this.grp_dump.Controls.Add(this.btn_dump);
            this.grp_dump.Controls.Add(this.lst_dialogs);
            this.grp_dump.Controls.Add(this.btn_browse);
            this.grp_dump.Controls.Add(this.lbl_dialogs);
            this.grp_dump.Controls.Add(this.txt_save_path);
            this.grp_dump.Controls.Add(this.btn_check_all_dialogs);
            this.grp_dump.Controls.Add(this.chk_delete_after_dump);
            this.grp_dump.Controls.Add(this.btn_uncheck_all_dialogs);
            this.grp_dump.Controls.Add(this.chk_audos);
            this.grp_dump.Controls.Add(this.chk_photos);
            this.grp_dump.Controls.Add(this.chk_videos);
            this.grp_dump.Controls.Add(this.chk_docs);
            this.grp_dump.Enabled = false;
            this.grp_dump.Location = new System.Drawing.Point(12, 97);
            this.grp_dump.Name = "grp_dump";
            this.grp_dump.Size = new System.Drawing.Size(586, 353);
            this.grp_dump.TabIndex = 20;
            this.grp_dump.TabStop = false;
            this.grp_dump.Text = "Dump Settings";
            // 
            // lbl_save_to
            // 
            this.lbl_save_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_save_to.AutoSize = true;
            this.lbl_save_to.Location = new System.Drawing.Point(281, 204);
            this.lbl_save_to.Name = "lbl_save_to";
            this.lbl_save_to.Size = new System.Drawing.Size(80, 13);
            this.lbl_save_to.TabIndex = 20;
            this.lbl_save_to.Text = "Save dump to:";
            // 
            // lbl_dump_settings
            // 
            this.lbl_dump_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_dump_settings.AutoSize = true;
            this.lbl_dump_settings.Location = new System.Drawing.Point(281, 27);
            this.lbl_dump_settings.Name = "lbl_dump_settings";
            this.lbl_dump_settings.Size = new System.Drawing.Size(132, 13);
            this.lbl_dump_settings.TabIndex = 19;
            this.lbl_dump_settings.Text = "Dump attached content:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 462);
            this.Controls.Add(this.grp_account);
            this.Controls.Add(this.grp_dump);
            this.Name = "FrmMain";
            this.Text = "VK.IMDumbDump()";
            this.grp_account.ResumeLayout(false);
            this.grp_account.PerformLayout();
            this.grp_dump.ResumeLayout(false);
            this.grp_dump.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lbl_login;
		private System.Windows.Forms.TextBox txt_login;
		private System.Windows.Forms.Label lbl_pass;
		private System.Windows.Forms.TextBox txt_pass;
		private System.Windows.Forms.Button btn_logout;
		private System.Windows.Forms.CheckedListBox lst_dialogs;
		private System.Windows.Forms.Label lbl_dialogs;
		private System.Windows.Forms.Button btn_check_all_dialogs;
		private System.Windows.Forms.Button btn_uncheck_all_dialogs;
		private System.Windows.Forms.CheckBox chk_photos;
		private System.Windows.Forms.CheckBox chk_docs;
		private System.Windows.Forms.CheckBox chk_videos;
		private System.Windows.Forms.CheckBox chk_audos;
		private System.Windows.Forms.CheckBox chk_delete_after_dump;
		private System.Windows.Forms.TextBox txt_save_path;
		private System.Windows.Forms.Button btn_login;
		private System.Windows.Forms.Button btn_browse;
		private System.Windows.Forms.Button btn_dump;
		private System.Windows.Forms.GroupBox grp_account;
		private System.Windows.Forms.GroupBox grp_dump;
		private System.Windows.Forms.Label lbl_save_to;
		private System.Windows.Forms.Label lbl_dump_settings;
		private System.Windows.Forms.FolderBrowserDialog sfd;
	}
}

