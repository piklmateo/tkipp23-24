namespace EventManager
{
    partial class FrmUserTransactions
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
            this.lblMyTransactions = new System.Windows.Forms.Label();
            this.dgvUserTransactions = new System.Windows.Forms.DataGridView();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMyTransactions
            // 
            this.lblMyTransactions.AutoSize = true;
            this.lblMyTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMyTransactions.Location = new System.Drawing.Point(9, 7);
            this.lblMyTransactions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMyTransactions.Name = "lblMyTransactions";
            this.lblMyTransactions.Size = new System.Drawing.Size(238, 26);
            this.lblMyTransactions.TabIndex = 1;
            this.lblMyTransactions.Text = "MY TRANSACTIONS";
            // 
            // dgvUserTransactions
            // 
            this.dgvUserTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserTransactions.Location = new System.Drawing.Point(14, 36);
            this.dgvUserTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUserTransactions.Name = "dgvUserTransactions";
            this.dgvUserTransactions.RowHeadersWidth = 51;
            this.dgvUserTransactions.RowTemplate.Height = 24;
            this.dgvUserTransactions.Size = new System.Drawing.Size(578, 320);
            this.dgvUserTransactions.TabIndex = 2;
            // 
            // FrmUserTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.dgvUserTransactions);
            this.Controls.Add(this.lblMyTransactions);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmUserTransactions";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Transactions";
            this.Load += new System.EventHandler(this.FrmUserTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMyTransactions;
        private System.Windows.Forms.DataGridView dgvUserTransactions;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}