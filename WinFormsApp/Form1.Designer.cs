
namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLED1 = new System.Windows.Forms.Button();
            this.btnLED2 = new System.Windows.Forms.Button();
            this.btnLED3 = new System.Windows.Forms.Button();
            this.btnLED4 = new System.Windows.Forms.Button();
            this.btnAllControl = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLED1
            // 
            this.btnLED1.BackColor = System.Drawing.Color.Transparent;
            this.btnLED1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLED1.FlatAppearance.BorderSize = 0;
            this.btnLED1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLED1.Image = global::WinFormsApp.Properties.Resources.lamp_off;
            this.btnLED1.Location = new System.Drawing.Point(99, 189);
            this.btnLED1.Name = "btnLED1";
            this.btnLED1.Size = new System.Drawing.Size(75, 90);
            this.btnLED1.TabIndex = 0;
            this.btnLED1.UseVisualStyleBackColor = false;
            this.btnLED1.Click += new System.EventHandler(this.btnLED1_Click);
            // 
            // btnLED2
            // 
            this.btnLED2.BackColor = System.Drawing.Color.Transparent;
            this.btnLED2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLED2.FlatAppearance.BorderSize = 0;
            this.btnLED2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLED2.Image = global::WinFormsApp.Properties.Resources.lamp_off;
            this.btnLED2.Location = new System.Drawing.Point(229, 189);
            this.btnLED2.Name = "btnLED2";
            this.btnLED2.Size = new System.Drawing.Size(75, 90);
            this.btnLED2.TabIndex = 0;
            this.btnLED2.UseVisualStyleBackColor = false;
            this.btnLED2.Click += new System.EventHandler(this.btnLED2_Click);
            // 
            // btnLED3
            // 
            this.btnLED3.BackColor = System.Drawing.Color.Transparent;
            this.btnLED3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLED3.FlatAppearance.BorderSize = 0;
            this.btnLED3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLED3.Image = global::WinFormsApp.Properties.Resources.lamp_off;
            this.btnLED3.Location = new System.Drawing.Point(359, 189);
            this.btnLED3.Name = "btnLED3";
            this.btnLED3.Size = new System.Drawing.Size(75, 90);
            this.btnLED3.TabIndex = 0;
            this.btnLED3.UseVisualStyleBackColor = false;
            this.btnLED3.Click += new System.EventHandler(this.btnLED3_Click);
            // 
            // btnLED4
            // 
            this.btnLED4.BackColor = System.Drawing.Color.Transparent;
            this.btnLED4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLED4.FlatAppearance.BorderSize = 0;
            this.btnLED4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLED4.Image = global::WinFormsApp.Properties.Resources.lamp_off;
            this.btnLED4.Location = new System.Drawing.Point(489, 189);
            this.btnLED4.Name = "btnLED4";
            this.btnLED4.Size = new System.Drawing.Size(75, 90);
            this.btnLED4.TabIndex = 0;
            this.btnLED4.UseVisualStyleBackColor = false;
            this.btnLED4.Click += new System.EventHandler(this.btnLED4_Click);
            // 
            // btnAllControl
            // 
            this.btnAllControl.BackColor = System.Drawing.Color.Transparent;
            this.btnAllControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllControl.FlatAppearance.BorderSize = 0;
            this.btnAllControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllControl.Image = global::WinFormsApp.Properties.Resources.power_btn_on;
            this.btnAllControl.Location = new System.Drawing.Point(618, 189);
            this.btnAllControl.Name = "btnAllControl";
            this.btnAllControl.Size = new System.Drawing.Size(75, 90);
            this.btnAllControl.TabIndex = 0;
            this.btnAllControl.UseVisualStyleBackColor = false;
            this.btnAllControl.Click += new System.EventHandler(this.btnAllControl_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(352, 326);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 45);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Location = new System.Drawing.Point(99, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "LED 1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox2.Location = new System.Drawing.Point(229, 143);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 27);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "LED 2";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox3.Location = new System.Drawing.Point(359, 143);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 27);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "LED 3";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox4.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox4.Location = new System.Drawing.Point(489, 143);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(75, 27);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "LED 4";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox5.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox5.Location = new System.Drawing.Point(610, 143);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(93, 27);
            this.textBox5.TabIndex = 2;
            this.textBox5.Text = "Control all";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(99, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Control LED";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTime.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTime.Location = new System.Drawing.Point(605, 27);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(59, 28);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Time";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(576, -1);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(57, 28);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAllControl);
            this.Controls.Add(this.btnLED4);
            this.Controls.Add(this.btnLED3);
            this.Controls.Add(this.btnLED2);
            this.Controls.Add(this.btnLED1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLED1;
        private System.Windows.Forms.Button btnLED2;
        private System.Windows.Forms.Button btnLED3;
        private System.Windows.Forms.Button btnLED4;
        private System.Windows.Forms.Button btnAllControl;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDate;
    }
}

