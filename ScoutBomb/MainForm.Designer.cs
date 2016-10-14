namespace ScoutBomb
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.QBox1 = new System.Windows.Forms.TextBox();
            this.timeLeftProgressBar = new System.Windows.Forms.ProgressBar();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.timeLeftTextLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.beeptimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // answerTextBox
            // 
            this.answerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.answerTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.answerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.answerTextBox.Enabled = false;
            this.answerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerTextBox.ForeColor = System.Drawing.Color.White;
            this.answerTextBox.Location = new System.Drawing.Point(6, 252);
            this.answerTextBox.Multiline = true;
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(314, 258);
            this.answerTextBox.TabIndex = 2;
            this.answerTextBox.Text = "SKRIV SVAR HER";
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(331, 12);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(462, 576);
            this.pic.TabIndex = 8;
            this.pic.TabStop = false;
            // 
            // QBox1
            // 
            this.QBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.QBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.QBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.QBox1.Enabled = false;
            this.QBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QBox1.ForeColor = System.Drawing.Color.White;
            this.QBox1.Location = new System.Drawing.Point(6, 104);
            this.QBox1.Multiline = true;
            this.QBox1.Name = "QBox1";
            this.QBox1.Size = new System.Drawing.Size(314, 142);
            this.QBox1.TabIndex = 3;
            this.QBox1.TextChanged += new System.EventHandler(this.QBox1_TextChanged);
            // 
            // timeLeftProgressBar
            // 
            this.timeLeftProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLeftProgressBar.Location = new System.Drawing.Point(18, 87);
            this.timeLeftProgressBar.Maximum = 10000;
            this.timeLeftProgressBar.Name = "timeLeftProgressBar";
            this.timeLeftProgressBar.Size = new System.Drawing.Size(307, 11);
            this.timeLeftProgressBar.Step = 1;
            this.timeLeftProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.timeLeftProgressBar.TabIndex = 6;
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLeftLabel.ForeColor = System.Drawing.Color.White;
            this.timeLeftLabel.Location = new System.Drawing.Point(202, 4);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(135, 40);
            this.timeLeftLabel.TabIndex = 5;
            this.timeLeftLabel.Text = "??:??:??";
            this.timeLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeLeftTextLabel
            // 
            this.timeLeftTextLabel.AutoSize = true;
            this.timeLeftTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLeftTextLabel.ForeColor = System.Drawing.Color.White;
            this.timeLeftTextLabel.Location = new System.Drawing.Point(12, 9);
            this.timeLeftTextLabel.Name = "timeLeftTextLabel";
            this.timeLeftTextLabel.Size = new System.Drawing.Size(206, 31);
            this.timeLeftTextLabel.TabIndex = 4;
            this.timeLeftTextLabel.Text = "Resterende tid: ";
            this.timeLeftTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(12, 44);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(313, 31);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "Stopped";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // beeptimer
            // 
            this.beeptimer.Interval = 1000;
            this.beeptimer.Tick += new System.EventHandler(this.beeptimer_Tick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.timeLeftLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeLeftProgressBar);
            this.Controls.Add(this.QBox1);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.timeLeftTextLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScoutBomb";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox QBox1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.ProgressBar timeLeftProgressBar;
        private System.Windows.Forms.Label timeLeftLabel;
        private System.Windows.Forms.Label timeLeftTextLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Timer beeptimer;
    }
}

