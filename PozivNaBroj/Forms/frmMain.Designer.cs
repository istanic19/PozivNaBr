
namespace PozivNaBroj.Forms
{
    partial class frmMain
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
            this.lkpPozivNaBroj = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtPozivNaBroj = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lkpPozivNaBroj
            // 
            this.lkpPozivNaBroj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lkpPozivNaBroj.FormattingEnabled = true;
            this.lkpPozivNaBroj.Location = new System.Drawing.Point(12, 64);
            this.lkpPozivNaBroj.Name = "lkpPozivNaBroj";
            this.lkpPozivNaBroj.Size = new System.Drawing.Size(121, 21);
            this.lkpPozivNaBroj.TabIndex = 0;
            this.lkpPozivNaBroj.SelectedIndexChanged += new System.EventHandler(this.lkpPozivNaBroj_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(51, 39);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(82, 20);
            this.txtModel.TabIndex = 2;
            // 
            // txtPozivNaBroj
            // 
            this.txtPozivNaBroj.Location = new System.Drawing.Point(139, 38);
            this.txtPozivNaBroj.Name = "txtPozivNaBroj";
            this.txtPozivNaBroj.Size = new System.Drawing.Size(397, 20);
            this.txtPozivNaBroj.TabIndex = 3;
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(579, 35);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 4;
            this.btnValidate.Text = "Validiraj";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(660, 35);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Kreiraj";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pbResult
            // 
            this.pbResult.Location = new System.Drawing.Point(542, 25);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(34, 34);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbResult.TabIndex = 6;
            this.pbResult.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(178, 22);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pbResult);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.txtPozivNaBroj);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lkpPozivNaBroj);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox lkpPozivNaBroj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtPozivNaBroj;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Label lblError;
    }
}

