namespace AirLines_Reservations_TRPO
{
    partial class Admin_create_flight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_create_flight));
            this.cancel_flight = new System.Windows.Forms.Button();
            this.add_flight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flight_id = new System.Windows.Forms.TextBox();
            this.punkt_naz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.punkt_otpr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_time = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fly_time = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bis_count = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bis_cost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.eco_count = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.eco_cost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel_flight
            // 
            this.cancel_flight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_flight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_flight.Location = new System.Drawing.Point(815, 664);
            this.cancel_flight.Name = "cancel_flight";
            this.cancel_flight.Size = new System.Drawing.Size(102, 37);
            this.cancel_flight.TabIndex = 0;
            this.cancel_flight.Text = "Отмена";
            this.cancel_flight.UseVisualStyleBackColor = true;
            this.cancel_flight.Click += new System.EventHandler(this.cancel_flight_Click);
            // 
            // add_flight
            // 
            this.add_flight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.add_flight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_flight.Location = new System.Drawing.Point(934, 664);
            this.add_flight.Name = "add_flight";
            this.add_flight.Size = new System.Drawing.Size(136, 37);
            this.add_flight.TabIndex = 1;
            this.add_flight.Text = "Добавить";
            this.add_flight.UseVisualStyleBackColor = true;
            this.add_flight.Click += new System.EventHandler(this.add_flight_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID рейса";
            // 
            // flight_id
            // 
            this.flight_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flight_id.Location = new System.Drawing.Point(242, 10);
            this.flight_id.Name = "flight_id";
            this.flight_id.Size = new System.Drawing.Size(234, 30);
            this.flight_id.TabIndex = 3;
            this.flight_id.Enter += new System.EventHandler(this.flight_id_Enter);
            this.flight_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.flight_id_KeyPress);
            this.flight_id.Leave += new System.EventHandler(this.flight_id_Leave);
            this.flight_id.Validating += new System.ComponentModel.CancelEventHandler(this.flight_id_Validating);
            // 
            // punkt_naz
            // 
            this.punkt_naz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.punkt_naz.Location = new System.Drawing.Point(242, 73);
            this.punkt_naz.Name = "punkt_naz";
            this.punkt_naz.Size = new System.Drawing.Size(234, 30);
            this.punkt_naz.TabIndex = 5;
            this.punkt_naz.Enter += new System.EventHandler(this.punkt_naz_Enter);
            this.punkt_naz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.punkt_naz_KeyPress);
            this.punkt_naz.Leave += new System.EventHandler(this.punkt_naz_Leave);
            this.punkt_naz.Validating += new System.ComponentModel.CancelEventHandler(this.punkt_naz_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пункт назначения";
            // 
            // punkt_otpr
            // 
            this.punkt_otpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.punkt_otpr.Location = new System.Drawing.Point(242, 135);
            this.punkt_otpr.Name = "punkt_otpr";
            this.punkt_otpr.Size = new System.Drawing.Size(234, 30);
            this.punkt_otpr.TabIndex = 7;
            this.punkt_otpr.Enter += new System.EventHandler(this.punkt_otpr_Enter);
            this.punkt_otpr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.punkt_otpr_KeyPress);
            this.punkt_otpr.Leave += new System.EventHandler(this.punkt_otpr_Leave);
            this.punkt_otpr.Validating += new System.ComponentModel.CancelEventHandler(this.punkt_otpr_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пункт отправления";
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date.Location = new System.Drawing.Point(242, 189);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(234, 30);
            this.date.TabIndex = 9;
            this.date.Enter += new System.EventHandler(this.date_Enter);
            this.date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.date_KeyPress);
            this.date.Leave += new System.EventHandler(this.date_Leave);
            this.date.Validating += new System.ComponentModel.CancelEventHandler(this.date_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Дата вылета";
            // 
            // date_time
            // 
            this.date_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_time.Location = new System.Drawing.Point(242, 251);
            this.date_time.Name = "date_time";
            this.date_time.Size = new System.Drawing.Size(234, 30);
            this.date_time.TabIndex = 11;
            this.date_time.Enter += new System.EventHandler(this.date_time_Enter);
            this.date_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.date_time_KeyPress);
            this.date_time.Leave += new System.EventHandler(this.date_time_Leave);
            this.date_time.Validating += new System.ComponentModel.CancelEventHandler(this.date_time_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Время вылета";
            // 
            // fly_time
            // 
            this.fly_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fly_time.Location = new System.Drawing.Point(242, 302);
            this.fly_time.Name = "fly_time";
            this.fly_time.Size = new System.Drawing.Size(234, 30);
            this.fly_time.TabIndex = 13;
            this.fly_time.Enter += new System.EventHandler(this.fly_time_Enter);
            this.fly_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fly_time_KeyPress);
            this.fly_time.Leave += new System.EventHandler(this.fly_time_Leave);
            this.fly_time.Validating += new System.ComponentModel.CancelEventHandler(this.fly_time_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(13, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Время полета";
            // 
            // bis_count
            // 
            this.bis_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bis_count.Location = new System.Drawing.Point(815, 15);
            this.bis_count.Name = "bis_count";
            this.bis_count.Size = new System.Drawing.Size(234, 30);
            this.bis_count.TabIndex = 15;
            this.bis_count.Enter += new System.EventHandler(this.bis_count_Enter);
            this.bis_count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bis_count_KeyPress);
            this.bis_count.Leave += new System.EventHandler(this.bis_count_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(556, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Число бизнесс мест";
            // 
            // bis_cost
            // 
            this.bis_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bis_cost.Location = new System.Drawing.Point(815, 76);
            this.bis_cost.Name = "bis_cost";
            this.bis_cost.Size = new System.Drawing.Size(234, 30);
            this.bis_cost.TabIndex = 17;
            this.bis_cost.Enter += new System.EventHandler(this.bis_cost_Enter);
            this.bis_cost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bis_cost_KeyPress);
            this.bis_cost.Leave += new System.EventHandler(this.bis_cost_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(556, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Цена бизнесс места";
            // 
            // eco_count
            // 
            this.eco_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eco_count.Location = new System.Drawing.Point(815, 135);
            this.eco_count.Name = "eco_count";
            this.eco_count.Size = new System.Drawing.Size(234, 30);
            this.eco_count.TabIndex = 19;
            this.eco_count.Enter += new System.EventHandler(this.eco_count_Enter);
            this.eco_count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eco_count_KeyPress);
            this.eco_count.Leave += new System.EventHandler(this.eco_count_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(556, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Число эконом мест";
            // 
            // eco_cost
            // 
            this.eco_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eco_cost.Location = new System.Drawing.Point(815, 186);
            this.eco_cost.Name = "eco_cost";
            this.eco_cost.Size = new System.Drawing.Size(234, 30);
            this.eco_cost.TabIndex = 21;
            this.eco_cost.Enter += new System.EventHandler(this.eco_cost_Enter);
            this.eco_cost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eco_cost_KeyPress);
            this.eco_cost.Leave += new System.EventHandler(this.eco_cost_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(556, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Цена эконом места";
            // 
            // Admin_create_flight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 713);
            this.Controls.Add(this.eco_cost);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.eco_count);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bis_cost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bis_count);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fly_time);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.date_time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.punkt_otpr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.punkt_naz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flight_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add_flight);
            this.Controls.Add(this.cancel_flight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1100, 760);
            this.MinimumSize = new System.Drawing.Size(1100, 760);
            this.Name = "Admin_create_flight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание нового рейса";
            this.Load += new System.EventHandler(this.Addnewflight_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_flight;
        private System.Windows.Forms.Button add_flight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox flight_id;
        private System.Windows.Forms.TextBox punkt_naz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox punkt_otpr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox date_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fly_time;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox bis_count;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox bis_cost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox eco_count;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox eco_cost;
        private System.Windows.Forms.Label label10;
    }
}