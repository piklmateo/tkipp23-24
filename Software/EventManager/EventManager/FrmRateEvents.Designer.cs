namespace EventManager
{
    partial class FrmRateEvents
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
            this.lblRateEvents = new System.Windows.Forms.Label();
            this.btnRateEvent = new System.Windows.Forms.Button();
            this.dgvRateEvents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRateEvents
            // 
            this.lblRateEvents.AutoSize = true;
            this.lblRateEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRateEvents.Location = new System.Drawing.Point(12, 9);
            this.lblRateEvents.Name = "lblRateEvents";
            this.lblRateEvents.Size = new System.Drawing.Size(220, 32);
            this.lblRateEvents.TabIndex = 1;
            this.lblRateEvents.Text = "RATE EVENTS";
            // 
            // btnRateEvent
            // 
            this.btnRateEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRateEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRateEvent.Location = new System.Drawing.Point(661, 402);
            this.btnRateEvent.Name = "btnRateEvent";
            this.btnRateEvent.Size = new System.Drawing.Size(133, 41);
            this.btnRateEvent.TabIndex = 6;
            this.btnRateEvent.Text = "Rate Event";
            this.btnRateEvent.UseVisualStyleBackColor = true;
            // 
            // dgvRateEvents
            // 
            this.dgvRateEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRateEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRateEvents.Location = new System.Drawing.Point(12, 44);
            this.dgvRateEvents.Name = "dgvRateEvents";
            this.dgvRateEvents.RowHeadersWidth = 51;
            this.dgvRateEvents.RowTemplate.Height = 24;
            this.dgvRateEvents.Size = new System.Drawing.Size(782, 349);
            this.dgvRateEvents.TabIndex = 7;
            // 
            // FrmRateEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 455);
            this.Controls.Add(this.dgvRateEvents);
            this.Controls.Add(this.btnRateEvent);
            this.Controls.Add(this.lblRateEvents);
            this.Name = "FrmRateEvents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rate Events";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRateEvents;
        private System.Windows.Forms.Button btnRateEvent;
        private System.Windows.Forms.DataGridView dgvRateEvents;
    }
}