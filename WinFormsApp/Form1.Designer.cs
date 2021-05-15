
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
            this.btnLED1 = new System.Windows.Forms.Button();
            this.btnLED2 = new System.Windows.Forms.Button();
            this.btnLED3 = new System.Windows.Forms.Button();
            this.btnLED4 = new System.Windows.Forms.Button();
            this.btnAllControl = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLED1
            // 
            this.btnLED1.BackColor = System.Drawing.Color.Gray;
            this.btnLED1.Location = new System.Drawing.Point(129, 164);
            this.btnLED1.Name = "btnLED1";
            this.btnLED1.Size = new System.Drawing.Size(94, 29);
            this.btnLED1.TabIndex = 0;
            this.btnLED1.Text = "LED1";
            this.btnLED1.UseVisualStyleBackColor = false;
            this.btnLED1.Click += new System.EventHandler(this.btnLED1_Click);
            // 
            // btnLED2
            // 
            this.btnLED2.BackColor = System.Drawing.Color.Gray;
            this.btnLED2.Location = new System.Drawing.Point(278, 164);
            this.btnLED2.Name = "btnLED2";
            this.btnLED2.Size = new System.Drawing.Size(94, 29);
            this.btnLED2.TabIndex = 0;
            this.btnLED2.Text = "LED2";
            this.btnLED2.UseVisualStyleBackColor = false;
            this.btnLED2.Click += new System.EventHandler(this.btnLED2_Click);
            // 
            // btnLED3
            // 
            this.btnLED3.BackColor = System.Drawing.Color.Gray;
            this.btnLED3.Location = new System.Drawing.Point(402, 164);
            this.btnLED3.Name = "btnLED3";
            this.btnLED3.Size = new System.Drawing.Size(94, 29);
            this.btnLED3.TabIndex = 0;
            this.btnLED3.Text = "LED3";
            this.btnLED3.UseVisualStyleBackColor = false;
            this.btnLED3.Click += new System.EventHandler(this.btnLED3_Click);
            // 
            // btnLED4
            // 
            this.btnLED4.BackColor = System.Drawing.Color.Gray;
            this.btnLED4.Location = new System.Drawing.Point(517, 164);
            this.btnLED4.Name = "btnLED4";
            this.btnLED4.Size = new System.Drawing.Size(94, 29);
            this.btnLED4.TabIndex = 0;
            this.btnLED4.Text = "LED4";
            this.btnLED4.UseVisualStyleBackColor = false;
            this.btnLED4.Click += new System.EventHandler(this.btnLED4_Click);
            // 
            // btnAllControl
            // 
            this.btnAllControl.BackColor = System.Drawing.Color.Silver;
            this.btnAllControl.Location = new System.Drawing.Point(657, 164);
            this.btnAllControl.Name = "btnAllControl";
            this.btnAllControl.Size = new System.Drawing.Size(94, 29);
            this.btnAllControl.TabIndex = 0;
            this.btnAllControl.Text = "All ON";
            this.btnAllControl.UseVisualStyleBackColor = false;
            this.btnAllControl.Click += new System.EventHandler(this.btnAllControl_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(402, 276);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAllControl);
            this.Controls.Add(this.btnLED4);
            this.Controls.Add(this.btnLED3);
            this.Controls.Add(this.btnLED2);
            this.Controls.Add(this.btnLED1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLED1;
        private System.Windows.Forms.Button btnLED2;
        private System.Windows.Forms.Button btnLED3;
        private System.Windows.Forms.Button btnLED4;
        private System.Windows.Forms.Button btnAllControl;
        private System.Windows.Forms.Button btnExit;
    }
}

