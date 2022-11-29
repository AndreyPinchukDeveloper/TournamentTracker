namespace TrackerUI
{
    partial class CreatePrizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePrizeForm));
            this.prizeLabel = new System.Windows.Forms.Label();
            this.placeNumberValueTextBox = new System.Windows.Forms.TextBox();
            this.placeNumberLabel = new System.Windows.Forms.Label();
            this.placeNameValueTextBox = new System.Windows.Forms.TextBox();
            this.placeNameLabel = new System.Windows.Forms.Label();
            this.placeAmountValueTextBox = new System.Windows.Forms.TextBox();
            this.placeAmountLabel = new System.Windows.Forms.Label();
            this.placePercentageValueTextBox = new System.Windows.Forms.TextBox();
            this.prizePercentageLabel = new System.Windows.Forms.Label();
            this.orLabel = new System.Windows.Forms.Label();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prizeLabel
            // 
            this.prizeLabel.AutoSize = true;
            this.prizeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prizeLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.prizeLabel.Location = new System.Drawing.Point(42, 19);
            this.prizeLabel.Name = "prizeLabel";
            this.prizeLabel.Size = new System.Drawing.Size(129, 30);
            this.prizeLabel.TabIndex = 15;
            this.prizeLabel.Text = "Create Prize";
            // 
            // placeNumberValueTextBox
            // 
            this.placeNumberValueTextBox.Location = new System.Drawing.Point(97, 68);
            this.placeNumberValueTextBox.Name = "placeNumberValueTextBox";
            this.placeNumberValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.placeNumberValueTextBox.TabIndex = 17;
            // 
            // placeNumberLabel
            // 
            this.placeNumberLabel.AutoSize = true;
            this.placeNumberLabel.ForeColor = System.Drawing.Color.Teal;
            this.placeNumberLabel.Location = new System.Drawing.Point(15, 73);
            this.placeNumberLabel.Name = "placeNumberLabel";
            this.placeNumberLabel.Size = new System.Drawing.Size(74, 13);
            this.placeNumberLabel.TabIndex = 16;
            this.placeNumberLabel.Text = "Place Number";
            // 
            // placeNameValueTextBox
            // 
            this.placeNameValueTextBox.Location = new System.Drawing.Point(97, 109);
            this.placeNameValueTextBox.Name = "placeNameValueTextBox";
            this.placeNameValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.placeNameValueTextBox.TabIndex = 19;
            // 
            // placeNameLabel
            // 
            this.placeNameLabel.AutoSize = true;
            this.placeNameLabel.ForeColor = System.Drawing.Color.Teal;
            this.placeNameLabel.Location = new System.Drawing.Point(15, 114);
            this.placeNameLabel.Name = "placeNameLabel";
            this.placeNameLabel.Size = new System.Drawing.Size(65, 13);
            this.placeNameLabel.TabIndex = 18;
            this.placeNameLabel.Text = "Place Name";
            // 
            // placeAmountValueTextBox
            // 
            this.placeAmountValueTextBox.Location = new System.Drawing.Point(97, 146);
            this.placeAmountValueTextBox.Name = "placeAmountValueTextBox";
            this.placeAmountValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.placeAmountValueTextBox.TabIndex = 21;
            // 
            // placeAmountLabel
            // 
            this.placeAmountLabel.AutoSize = true;
            this.placeAmountLabel.ForeColor = System.Drawing.Color.Teal;
            this.placeAmountLabel.Location = new System.Drawing.Point(15, 151);
            this.placeAmountLabel.Name = "placeAmountLabel";
            this.placeAmountLabel.Size = new System.Drawing.Size(73, 13);
            this.placeAmountLabel.TabIndex = 20;
            this.placeAmountLabel.Text = "Place Amount";
            // 
            // placePercentageValueTextBox
            // 
            this.placePercentageValueTextBox.Location = new System.Drawing.Point(114, 213);
            this.placePercentageValueTextBox.Name = "placePercentageValueTextBox";
            this.placePercentageValueTextBox.Size = new System.Drawing.Size(83, 20);
            this.placePercentageValueTextBox.TabIndex = 23;
            // 
            // prizePercentageLabel
            // 
            this.prizePercentageLabel.AutoSize = true;
            this.prizePercentageLabel.ForeColor = System.Drawing.Color.Teal;
            this.prizePercentageLabel.Location = new System.Drawing.Point(16, 216);
            this.prizePercentageLabel.Name = "prizePercentageLabel";
            this.prizePercentageLabel.Size = new System.Drawing.Size(92, 13);
            this.prizePercentageLabel.TabIndex = 22;
            this.prizePercentageLabel.Text = "Place Percentage";
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.ForeColor = System.Drawing.Color.Teal;
            this.orLabel.Location = new System.Drawing.Point(73, 181);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(28, 13);
            this.orLabel.TabIndex = 24;
            this.orLabel.Text = "- or -";
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.Location = new System.Drawing.Point(63, 259);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(108, 44);
            this.createPrizeButton.TabIndex = 25;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.UseVisualStyleBackColor = true;
            // 
            // CreatePrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 330);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.orLabel);
            this.Controls.Add(this.placePercentageValueTextBox);
            this.Controls.Add(this.prizePercentageLabel);
            this.Controls.Add(this.placeAmountValueTextBox);
            this.Controls.Add(this.placeAmountLabel);
            this.Controls.Add(this.placeNameValueTextBox);
            this.Controls.Add(this.placeNameLabel);
            this.Controls.Add(this.placeNumberValueTextBox);
            this.Controls.Add(this.placeNumberLabel);
            this.Controls.Add(this.prizeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatePrizeForm";
            this.Text = "CreatePrizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label prizeLabel;
        private System.Windows.Forms.TextBox placeNumberValueTextBox;
        private System.Windows.Forms.Label placeNumberLabel;
        private System.Windows.Forms.TextBox placeNameValueTextBox;
        private System.Windows.Forms.Label placeNameLabel;
        private System.Windows.Forms.TextBox placeAmountValueTextBox;
        private System.Windows.Forms.Label placeAmountLabel;
        private System.Windows.Forms.TextBox placePercentageValueTextBox;
        private System.Windows.Forms.Label prizePercentageLabel;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Button createPrizeButton;
    }
}