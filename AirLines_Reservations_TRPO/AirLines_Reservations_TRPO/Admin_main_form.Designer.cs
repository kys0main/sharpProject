namespace AirLines_Reservations_TRPO
{
    partial class Admin_main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_main_form));
            this.Add_flight = new System.Windows.Forms.Button();
            this.Edit_flight = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Add_flight
            // 
            this.Add_flight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_flight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_flight.Location = new System.Drawing.Point(273, 204);
            this.Add_flight.Name = "Add_flight";
            this.Add_flight.Size = new System.Drawing.Size(229, 43);
            this.Add_flight.TabIndex = 0;
            this.Add_flight.Text = "Добавить рейс";
            this.Add_flight.UseVisualStyleBackColor = true;
            this.Add_flight.Click += new System.EventHandler(this.Add_flight_Click);
            // 
            // Edit_flight
            // 
            this.Edit_flight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_flight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Edit_flight.Location = new System.Drawing.Point(273, 320);
            this.Edit_flight.Name = "Edit_flight";
            this.Edit_flight.Size = new System.Drawing.Size(229, 91);
            this.Edit_flight.TabIndex = 1;
            this.Edit_flight.Text = "Просмотр и редактирование рейсов";
            this.Edit_flight.UseVisualStyleBackColor = true;
            this.Edit_flight.Click += new System.EventHandler(this.Edit_flight_Click);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.Location = new System.Drawing.Point(576, 498);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(194, 43);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Завершить сеанс";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Admin_main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Edit_flight);
            this.Controls.Add(this.Add_flight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Admin_main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно администратора";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add_flight;
        private System.Windows.Forms.Button Edit_flight;
        private System.Windows.Forms.Button Exit;
    }
}