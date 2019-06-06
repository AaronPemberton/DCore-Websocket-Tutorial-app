namespace DCore_Websocket_App
{
    partial class Form1
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
            this.textBox_walletFile = new System.Windows.Forms.TextBox();
            this.button_Select = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Show = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_sendTo = new System.Windows.Forms.TextBox();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Memo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Send = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox_Status = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wallet File:";
            // 
            // textBox_walletFile
            // 
            this.textBox_walletFile.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_walletFile.Location = new System.Drawing.Point(103, 6);
            this.textBox_walletFile.Name = "textBox_walletFile";
            this.textBox_walletFile.ReadOnly = true;
            this.textBox_walletFile.Size = new System.Drawing.Size(200, 20);
            this.textBox_walletFile.TabIndex = 1;
            // 
            // button_Select
            // 
            this.button_Select.Location = new System.Drawing.Point(309, 6);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(48, 20);
            this.button_Select.TabIndex = 2;
            this.button_Select.Text = "Select";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wallet Password: ";
            // 
            // button_Show
            // 
            this.button_Show.Location = new System.Drawing.Point(309, 32);
            this.button_Show.Name = "button_Show";
            this.button_Show.Size = new System.Drawing.Size(48, 20);
            this.button_Show.TabIndex = 5;
            this.button_Show.Text = "Show";
            this.button_Show.UseVisualStyleBackColor = true;
            this.button_Show.Click += new System.EventHandler(this.button_Show_Click);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(103, 32);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(200, 20);
            this.textBox_Password.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Send To:";
            // 
            // textBox_sendTo
            // 
            this.textBox_sendTo.Location = new System.Drawing.Point(103, 73);
            this.textBox_sendTo.Name = "textBox_sendTo";
            this.textBox_sendTo.Size = new System.Drawing.Size(200, 20);
            this.textBox_sendTo.TabIndex = 7;
            // 
            // textBox_Amount
            // 
            this.textBox_Amount.Location = new System.Drawing.Point(103, 99);
            this.textBox_Amount.Name = "textBox_Amount";
            this.textBox_Amount.Size = new System.Drawing.Size(200, 20);
            this.textBox_Amount.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Amount:";
            // 
            // textBox_Memo
            // 
            this.textBox_Memo.Location = new System.Drawing.Point(103, 125);
            this.textBox_Memo.Name = "textBox_Memo";
            this.textBox_Memo.Size = new System.Drawing.Size(200, 20);
            this.textBox_Memo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Memo (Optional):";
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(282, 184);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 13;
            this.button_Send.Text = "SEND";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox_Status
            // 
            this.richTextBox_Status.Location = new System.Drawing.Point(12, 162);
            this.richTextBox_Status.Name = "richTextBox_Status";
            this.richTextBox_Status.Size = new System.Drawing.Size(245, 45);
            this.richTextBox_Status.TabIndex = 14;
            this.richTextBox_Status.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 216);
            this.Controls.Add(this.richTextBox_Status);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_Memo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Amount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_sendTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Show);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.textBox_walletFile);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(385, 255);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(385, 255);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DCore Websocket App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_walletFile;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Show;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_sendTo;
        private System.Windows.Forms.TextBox textBox_Amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Memo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBox_Status;
    }
}

