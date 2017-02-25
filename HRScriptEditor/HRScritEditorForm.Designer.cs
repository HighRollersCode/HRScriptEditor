namespace WindowsFormsApplication1
{
    partial class HRScritEditorForm
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
            this.ButtonLoadLocal = new System.Windows.Forms.Button();
            this.FileEdit = new System.Windows.Forms.RichTextBox();
            this.TextBoxServer = new System.Windows.Forms.TextBox();
            this.FilesCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxPath = new System.Windows.Forms.TextBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.ButtonUpload = new System.Windows.Forms.Button();
            this.ButtonLoadRobot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonLoadLocal
            // 
            this.ButtonLoadLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonLoadLocal.Location = new System.Drawing.Point(469, 39);
            this.ButtonLoadLocal.Name = "ButtonLoadLocal";
            this.ButtonLoadLocal.Size = new System.Drawing.Size(116, 23);
            this.ButtonLoadLocal.TabIndex = 0;
            this.ButtonLoadLocal.Text = "Load(Local)";
            this.ButtonLoadLocal.UseVisualStyleBackColor = true;
            this.ButtonLoadLocal.Click += new System.EventHandler(this.ButtonLoadLocal_Click);
            // 
            // FileEdit
            // 
            this.FileEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileEdit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FileEdit.Location = new System.Drawing.Point(13, 133);
            this.FileEdit.Name = "FileEdit";
            this.FileEdit.Size = new System.Drawing.Size(572, 220);
            this.FileEdit.TabIndex = 2;
            this.FileEdit.Text = "";
            this.FileEdit.TextChanged += new System.EventHandler(this.FileEdit_TextChanged);
            // 
            // TextBoxServer
            // 
            this.TextBoxServer.Location = new System.Drawing.Point(118, 13);
            this.TextBoxServer.Name = "TextBoxServer";
            this.TextBoxServer.Size = new System.Drawing.Size(345, 20);
            this.TextBoxServer.TabIndex = 3;
            this.TextBoxServer.Text = "10.9.87.2";
            this.TextBoxServer.TextChanged += new System.EventHandler(this.ServerTextBox_TextChanged);
            // 
            // FilesCombo
            // 
            this.FilesCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesCombo.Cursor = System.Windows.Forms.Cursors.Default;
            this.FilesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilesCombo.FormattingEnabled = true;
            this.FilesCombo.Location = new System.Drawing.Point(12, 106);
            this.FilesCombo.Name = "FilesCombo";
            this.FilesCombo.Size = new System.Drawing.Size(571, 21);
            this.FilesCombo.TabIndex = 5;
            this.FilesCombo.SelectedIndexChanged += new System.EventHandler(this.FilesCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Robot IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Local Folder:";
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.Location = new System.Drawing.Point(118, 41);
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.Size = new System.Drawing.Size(303, 20);
            this.TextBoxPath.TabIndex = 8;
            this.TextBoxPath.Text = "C:\\Users\\HighRollers\\Desktop\\HRScripts\\";
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(427, 39);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(36, 23);
            this.ButtonBrowse.TabIndex = 9;
            this.ButtonBrowse.Text = "...";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // ButtonUpload
            // 
            this.ButtonUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonUpload.Location = new System.Drawing.Point(469, 68);
            this.ButtonUpload.Name = "ButtonUpload";
            this.ButtonUpload.Size = new System.Drawing.Size(116, 23);
            this.ButtonUpload.TabIndex = 10;
            this.ButtonUpload.Text = "Upload and Save";
            this.ButtonUpload.UseVisualStyleBackColor = true;
            this.ButtonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // ButtonLoadRobot
            // 
            this.ButtonLoadRobot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonLoadRobot.Location = new System.Drawing.Point(469, 10);
            this.ButtonLoadRobot.Name = "ButtonLoadRobot";
            this.ButtonLoadRobot.Size = new System.Drawing.Size(116, 23);
            this.ButtonLoadRobot.TabIndex = 11;
            this.ButtonLoadRobot.Text = "Load(Robot)";
            this.ButtonLoadRobot.UseVisualStyleBackColor = true;
            this.ButtonLoadRobot.Click += new System.EventHandler(this.ButtonLoadRobot_Click);
            // 
            // HRScritEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 365);
            this.Controls.Add(this.ButtonLoadRobot);
            this.Controls.Add(this.ButtonUpload);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.TextBoxPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilesCombo);
            this.Controls.Add(this.TextBoxServer);
            this.Controls.Add(this.FileEdit);
            this.Controls.Add(this.ButtonLoadLocal);
            this.Name = "HRScritEditorForm";
            this.Text = "HRScript Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLoadLocal;
        private System.Windows.Forms.RichTextBox FileEdit;
        private System.Windows.Forms.TextBox TextBoxServer;
        private System.Windows.Forms.ComboBox FilesCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxPath;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.Button ButtonUpload;
        private System.Windows.Forms.Button ButtonLoadRobot;
    }
}

