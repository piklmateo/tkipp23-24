namespace EventManager
{
    partial class FrmUserEvents
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
            this.lblMyEvents = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboUserEvents = new System.Windows.Forms.ComboBox();
            this.dgvUserEvents = new System.Windows.Forms.DataGridView();
            this.btnUnrateEvents = new System.Windows.Forms.Button();
            this.btnSelectedEvent = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMyEvents
            // 
            this.lblMyEvents.AutoSize = true;
            this.lblMyEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMyEvents.Location = new System.Drawing.Point(9, 7);
            this.lblMyEvents.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMyEvents.Name = "lblMyEvents";
            this.lblMyEvents.Size = new System.Drawing.Size(149, 26);
            this.lblMyEvents.TabIndex = 1;
            this.lblMyEvents.Text = "MY EVENTS";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSearch.Location = new System.Drawing.Point(518, 7);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboUserEvents
            // 
            this.cboUserEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUserEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cboUserEvents.FormattingEnabled = true;
            this.cboUserEvents.Items.AddRange(new object[] {
            "All Events",
            "Attended Events",
            "Unattended Events"});
            this.cboUserEvents.Location = new System.Drawing.Point(362, 7);
            this.cboUserEvents.Margin = new System.Windows.Forms.Padding(2);
            this.cboUserEvents.Name = "cboUserEvents";
            this.cboUserEvents.Size = new System.Drawing.Size(152, 23);
            this.cboUserEvents.TabIndex = 3;
            // 
            // dgvUserEvents
            // 
            this.dgvUserEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserEvents.Location = new System.Drawing.Point(14, 36);
            this.dgvUserEvents.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUserEvents.Name = "dgvUserEvents";
            this.dgvUserEvents.RowHeadersWidth = 51;
            this.dgvUserEvents.RowTemplate.Height = 24;
            this.dgvUserEvents.Size = new System.Drawing.Size(578, 291);
            this.dgvUserEvents.TabIndex = 4;
            // 
            // btnUnrateEvents
            // 
            this.btnUnrateEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnrateEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUnrateEvents.Location = new System.Drawing.Point(491, 332);
            this.btnUnrateEvents.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnrateEvents.Name = "btnUnrateEvents";
            this.btnUnrateEvents.Size = new System.Drawing.Size(100, 33);
            this.btnUnrateEvents.TabIndex = 5;
            this.btnUnrateEvents.Text = "Unrate Events";
            this.btnUnrateEvents.UseVisualStyleBackColor = true;
            // 
            // btnSelectedEvent
            // 
            this.btnSelectedEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectedEvent.Location = new System.Drawing.Point(14, 331);
            this.btnSelectedEvent.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectedEvent.Name = "btnSelectedEvent";
            this.btnSelectedEvent.Size = new System.Drawing.Size(100, 43);
            this.btnSelectedEvent.TabIndex = 6;
            this.btnSelectedEvent.Text = "Show details of event";
            this.btnSelectedEvent.UseVisualStyleBackColor = true;
            this.btnSelectedEvent.Click += new System.EventHandler(this.btnSelectedEvent_Click);
            // 
            // FrmUserEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 376);
            this.Controls.Add(this.btnSelectedEvent);
            this.Controls.Add(this.btnUnrateEvents);
            this.Controls.Add(this.dgvUserEvents);
            this.Controls.Add(this.cboUserEvents);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblMyEvents);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmUserEvents";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Events";
            this.Load += new System.EventHandler(this.FrmUserEvents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMyEvents;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboUserEvents;
        private System.Windows.Forms.DataGridView dgvUserEvents;
        private System.Windows.Forms.Button btnUnrateEvents;
        private System.Windows.Forms.Button btnSelectedEvent;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}