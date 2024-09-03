namespace EventManager
{
    partial class FrmEventDetailsUser
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
            this.gbAddEvent = new System.Windows.Forms.GroupBox();
            this.picEvent = new System.Windows.Forms.PictureBox();
            this.txtEventDate = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblTicketCategory = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblVenueName = new System.Windows.Forms.Label();
            this.lblOrganizer = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtVenueName = new System.Windows.Forms.TextBox();
            this.txtOrganizer = new System.Windows.Forms.TextBox();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtHumidity = new System.Windows.Forms.TextBox();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.TxtRain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbAddEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAddEvent
            // 
            this.gbAddEvent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbAddEvent.Controls.Add(this.txtDescription);
            this.gbAddEvent.Controls.Add(this.txtHumidity);
            this.gbAddEvent.Controls.Add(this.txtTemperature);
            this.gbAddEvent.Controls.Add(this.TxtRain);
            this.gbAddEvent.Controls.Add(this.label5);
            this.gbAddEvent.Controls.Add(this.picEvent);
            this.gbAddEvent.Controls.Add(this.txtEventDate);
            this.gbAddEvent.Controls.Add(this.txtCategory);
            this.gbAddEvent.Controls.Add(this.lblTicketCategory);
            this.gbAddEvent.Controls.Add(this.lblStartTime);
            this.gbAddEvent.Controls.Add(this.lblVenueName);
            this.gbAddEvent.Controls.Add(this.lblOrganizer);
            this.gbAddEvent.Controls.Add(this.lblEventName);
            this.gbAddEvent.Controls.Add(this.lblEventDate);
            this.gbAddEvent.Controls.Add(this.txtStartTime);
            this.gbAddEvent.Controls.Add(this.txtVenueName);
            this.gbAddEvent.Controls.Add(this.txtOrganizer);
            this.gbAddEvent.Controls.Add(this.txtEventName);
            this.gbAddEvent.Location = new System.Drawing.Point(0, 0);
            this.gbAddEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAddEvent.Name = "gbAddEvent";
            this.gbAddEvent.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAddEvent.Size = new System.Drawing.Size(835, 741);
            this.gbAddEvent.TabIndex = 33;
            this.gbAddEvent.TabStop = false;
            this.gbAddEvent.Text = "Event";
            // 
            // picEvent
            // 
            this.picEvent.Location = new System.Drawing.Point(237, 30);
            this.picEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picEvent.Name = "picEvent";
            this.picEvent.Size = new System.Drawing.Size(367, 192);
            this.picEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEvent.TabIndex = 40;
            this.picEvent.TabStop = false;
            // 
            // txtEventDate
            // 
            this.txtEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtEventDate.Location = new System.Drawing.Point(147, 394);
            this.txtEventDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEventDate.Name = "txtEventDate";
            this.txtEventDate.ReadOnly = true;
            this.txtEventDate.Size = new System.Drawing.Size(244, 26);
            this.txtEventDate.TabIndex = 39;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(147, 558);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(531, 22);
            this.txtCategory.TabIndex = 38;
            // 
            // lblTicketCategory
            // 
            this.lblTicketCategory.AutoSize = true;
            this.lblTicketCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTicketCategory.Location = new System.Drawing.Point(143, 534);
            this.lblTicketCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTicketCategory.Name = "lblTicketCategory";
            this.lblTicketCategory.Size = new System.Drawing.Size(125, 20);
            this.lblTicketCategory.TabIndex = 37;
            this.lblTicketCategory.Text = "Event category:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblStartTime.Location = new System.Drawing.Point(428, 368);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(87, 20);
            this.lblStartTime.TabIndex = 34;
            this.lblStartTime.Text = "Start time:";
            // 
            // lblVenueName
            // 
            this.lblVenueName.AutoSize = true;
            this.lblVenueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblVenueName.Location = new System.Drawing.Point(147, 454);
            this.lblVenueName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVenueName.Name = "lblVenueName";
            this.lblVenueName.Size = new System.Drawing.Size(107, 20);
            this.lblVenueName.TabIndex = 33;
            this.lblVenueName.Text = "Venue name:";
            // 
            // lblOrganizer
            // 
            this.lblOrganizer.AutoSize = true;
            this.lblOrganizer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblOrganizer.Location = new System.Drawing.Point(428, 454);
            this.lblOrganizer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrganizer.Name = "lblOrganizer";
            this.lblOrganizer.Size = new System.Drawing.Size(88, 20);
            this.lblOrganizer.TabIndex = 32;
            this.lblOrganizer.Text = "Organizer:";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEventName.Location = new System.Drawing.Point(147, 288);
            this.lblEventName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(102, 20);
            this.lblEventName.TabIndex = 29;
            this.lblEventName.Text = "Event name:";
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEventDate.Location = new System.Drawing.Point(147, 368);
            this.lblEventDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(93, 20);
            this.lblEventDate.TabIndex = 28;
            this.lblEventDate.Text = "Event date:";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtStartTime.Location = new System.Drawing.Point(435, 394);
            this.txtStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(244, 26);
            this.txtStartTime.TabIndex = 24;
            // 
            // txtVenueName
            // 
            this.txtVenueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtVenueName.Location = new System.Drawing.Point(147, 480);
            this.txtVenueName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVenueName.Name = "txtVenueName";
            this.txtVenueName.ReadOnly = true;
            this.txtVenueName.Size = new System.Drawing.Size(244, 26);
            this.txtVenueName.TabIndex = 23;
            // 
            // txtOrganizer
            // 
            this.txtOrganizer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtOrganizer.Location = new System.Drawing.Point(435, 480);
            this.txtOrganizer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrganizer.Name = "txtOrganizer";
            this.txtOrganizer.ReadOnly = true;
            this.txtOrganizer.Size = new System.Drawing.Size(244, 26);
            this.txtOrganizer.TabIndex = 22;
            // 
            // txtEventName
            // 
            this.txtEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtEventName.Location = new System.Drawing.Point(147, 314);
            this.txtEventName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.ReadOnly = true;
            this.txtEventName.Size = new System.Drawing.Size(531, 26);
            this.txtEventName.TabIndex = 20;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDescription.Location = new System.Drawing.Point(146, 637);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(335, 26);
            this.txtDescription.TabIndex = 57;
            // 
            // txtHumidity
            // 
            this.txtHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtHumidity.Location = new System.Drawing.Point(503, 637);
            this.txtHumidity.Name = "txtHumidity";
            this.txtHumidity.ReadOnly = true;
            this.txtHumidity.Size = new System.Drawing.Size(174, 26);
            this.txtHumidity.TabIndex = 56;
            // 
            // txtTemperature
            // 
            this.txtTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTemperature.Location = new System.Drawing.Point(150, 685);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.ReadOnly = true;
            this.txtTemperature.Size = new System.Drawing.Size(331, 26);
            this.txtTemperature.TabIndex = 55;
            // 
            // TxtRain
            // 
            this.TxtRain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TxtRain.Location = new System.Drawing.Point(503, 685);
            this.TxtRain.Name = "TxtRain";
            this.TxtRain.ReadOnly = true;
            this.TxtRain.Size = new System.Drawing.Size(175, 26);
            this.TxtRain.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(143, 600);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 53;
            this.label5.Text = "Expected weather:";
            // 
            // FrmEventDetailsUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 748);
            this.Controls.Add(this.gbAddEvent);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmEventDetailsUser";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "FrmEventDetailsUser";
            this.Load += new System.EventHandler(this.FrmEventDetailsUser_Load);
            this.gbAddEvent.ResumeLayout(false);
            this.gbAddEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddEvent;
        private System.Windows.Forms.PictureBox picEvent;
        private System.Windows.Forms.TextBox txtEventDate;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblTicketCategory;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblVenueName;
        private System.Windows.Forms.Label lblOrganizer;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtVenueName;
        private System.Windows.Forms.TextBox txtOrganizer;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtHumidity;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.TextBox TxtRain;
        private System.Windows.Forms.Label label5;
    }
}