namespace AirLines_Reservations_TRPO
{
    partial class Pass_main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pass_main_form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.reserve = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pass_flights = new System.Windows.Forms.DataGridView();
            this.my_reserve = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.my_reserve_grid = new System.Windows.Forms.DataGridView();
            this.Exit_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.reserve.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pass_flights)).BeginInit();
            this.my_reserve.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.my_reserve_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Exit_button, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1262, 673);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.reserve);
            this.tabControl1.Controls.Add(this.my_reserve);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1256, 599);
            this.tabControl1.TabIndex = 1;
            // 
            // reserve
            // 
            this.reserve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reserve.Controls.Add(this.tableLayoutPanel2);
            this.reserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reserve.Location = new System.Drawing.Point(4, 34);
            this.reserve.Name = "reserve";
            this.reserve.Padding = new System.Windows.Forms.Padding(3);
            this.reserve.Size = new System.Drawing.Size(1248, 561);
            this.reserve.TabIndex = 0;
            this.reserve.Text = "Бронирование";
            this.reserve.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            this.tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pass_flights, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1242, 555);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pass_flights
            // 
            this.pass_flights.AllowUserToAddRows = false;
            this.pass_flights.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_flights.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.pass_flights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pass_flights.BackgroundColor = System.Drawing.Color.MediumTurquoise;
            this.pass_flights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pass_flights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pass_flights.Location = new System.Drawing.Point(3, 3);
            this.pass_flights.Name = "pass_flights";
            this.pass_flights.ReadOnly = true;
            this.pass_flights.RowHeadersWidth = 51;
            this.pass_flights.RowTemplate.Height = 24;
            this.pass_flights.Size = new System.Drawing.Size(1236, 493);
            this.pass_flights.TabIndex = 0;
            this.pass_flights.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pass_flights_CellDoubleClick);
            // 
            // my_reserve
            // 
            this.my_reserve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.my_reserve.Controls.Add(this.tableLayoutPanel3);
            this.my_reserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.my_reserve.Location = new System.Drawing.Point(4, 34);
            this.my_reserve.Name = "my_reserve";
            this.my_reserve.Padding = new System.Windows.Forms.Padding(3);
            this.my_reserve.Size = new System.Drawing.Size(1248, 561);
            this.my_reserve.TabIndex = 1;
            this.my_reserve.Text = "Мои бронирования";
            this.my_reserve.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel3.BackgroundImage")));
            this.tableLayoutPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.my_reserve_grid, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1242, 555);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // my_reserve_grid
            // 
            this.my_reserve_grid.AllowUserToAddRows = false;
            this.my_reserve_grid.AllowUserToDeleteRows = false;
            this.my_reserve_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.my_reserve_grid.BackgroundColor = System.Drawing.Color.MediumTurquoise;
            this.my_reserve_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.my_reserve_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.my_reserve_grid.Location = new System.Drawing.Point(3, 3);
            this.my_reserve_grid.Name = "my_reserve_grid";
            this.my_reserve_grid.ReadOnly = true;
            this.my_reserve_grid.RowHeadersWidth = 51;
            this.my_reserve_grid.RowTemplate.Height = 24;
            this.my_reserve_grid.Size = new System.Drawing.Size(1236, 493);
            this.my_reserve_grid.TabIndex = 1;
            this.my_reserve_grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.my_reserve_grid_CellDoubleClick);
            // 
            // Exit_button
            // 
            this.Exit_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.Exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit_button.Location = new System.Drawing.Point(1058, 608);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(201, 62);
            this.Exit_button.TabIndex = 2;
            this.Exit_button.Text = "Завершить сеанс";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Pass_main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Pass_main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно пользователя";
            this.Load += new System.EventHandler(this.PassForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.reserve.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pass_flights)).EndInit();
            this.my_reserve.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.my_reserve_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage reserve;
        private System.Windows.Forms.TabPage my_reserve;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView pass_flights;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView my_reserve_grid;
    }
}