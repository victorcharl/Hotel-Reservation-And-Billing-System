namespace HotelReservationSystem
{
    partial class registerAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registerAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.regfemale = new System.Windows.Forms.RadioButton();
            this.regmale = new System.Windows.Forms.RadioButton();
            this.regconfirm = new System.Windows.Forms.TextBox();
            this.regpassword = new System.Windows.Forms.TextBox();
            this.regusername = new System.Windows.Forms.TextBox();
            this.regmi = new System.Windows.Forms.TextBox();
            this.regfirst = new System.Windows.Forms.TextBox();
            this.reglast = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(440, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "\"Username in Used\"";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(437, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "\"Password not match!\"";
            this.label3.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = " ";
            this.label7.Visible = false;
            // 
            // regfemale
            // 
            this.regfemale.AutoSize = true;
            this.regfemale.BackColor = System.Drawing.Color.Transparent;
            this.regfemale.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regfemale.Location = new System.Drawing.Point(326, 97);
            this.regfemale.Name = "regfemale";
            this.regfemale.Size = new System.Drawing.Size(71, 21);
            this.regfemale.TabIndex = 12;
            this.regfemale.Text = "female";
            this.regfemale.UseVisualStyleBackColor = false;
            this.regfemale.CheckedChanged += new System.EventHandler(this.regfemale_CheckedChanged);
            // 
            // regmale
            // 
            this.regmale.AutoSize = true;
            this.regmale.BackColor = System.Drawing.Color.Transparent;
            this.regmale.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regmale.Location = new System.Drawing.Point(233, 97);
            this.regmale.Name = "regmale";
            this.regmale.Size = new System.Drawing.Size(59, 21);
            this.regmale.TabIndex = 11;
            this.regmale.Text = "male";
            this.regmale.UseVisualStyleBackColor = false;
            this.regmale.CheckedChanged += new System.EventHandler(this.regmale_CheckedChanged);
            // 
            // regconfirm
            // 
            this.regconfirm.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regconfirm.Location = new System.Drawing.Point(233, 201);
            this.regconfirm.MaxLength = 9;
            this.regconfirm.Name = "regconfirm";
            this.regconfirm.PasswordChar = '*';
            this.regconfirm.Size = new System.Drawing.Size(203, 25);
            this.regconfirm.TabIndex = 18;
            this.regconfirm.TextChanged += new System.EventHandler(this.regconfirm_TextChanged);
            // 
            // regpassword
            // 
            this.regpassword.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regpassword.Location = new System.Drawing.Point(233, 166);
            this.regpassword.MaxLength = 9;
            this.regpassword.Name = "regpassword";
            this.regpassword.PasswordChar = '*';
            this.regpassword.Size = new System.Drawing.Size(203, 25);
            this.regpassword.TabIndex = 17;
            // 
            // regusername
            // 
            this.regusername.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regusername.Location = new System.Drawing.Point(234, 131);
            this.regusername.MaxLength = 50;
            this.regusername.Name = "regusername";
            this.regusername.Size = new System.Drawing.Size(203, 25);
            this.regusername.TabIndex = 16;
            this.regusername.TextChanged += new System.EventHandler(this.regusername_TextChanged);
            // 
            // regmi
            // 
            this.regmi.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regmi.Location = new System.Drawing.Point(471, 56);
            this.regmi.MaxLength = 1;
            this.regmi.Name = "regmi";
            this.regmi.Size = new System.Drawing.Size(69, 25);
            this.regmi.TabIndex = 10;
            this.regmi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.regmi_KeyPress);
            // 
            // regfirst
            // 
            this.regfirst.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regfirst.Location = new System.Drawing.Point(225, 56);
            this.regfirst.MaxLength = 50;
            this.regfirst.Name = "regfirst";
            this.regfirst.Size = new System.Drawing.Size(240, 25);
            this.regfirst.TabIndex = 9;
            this.regfirst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.regfirst_KeyPress);
            // 
            // reglast
            // 
            this.reglast.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reglast.Location = new System.Drawing.Point(32, 56);
            this.reglast.MaxLength = 50;
            this.reglast.Name = "reglast";
            this.reglast.Size = new System.Drawing.Size(178, 25);
            this.reglast.TabIndex = 8;
            this.reglast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.reglast_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(344, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "B&ack";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(252, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(249, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 17);
            this.label12.TabIndex = 9;
            this.label12.Text = "\"Incomplete Details\"";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(71, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Confirm Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(131, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(127, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Username:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(119, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Gender:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(468, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "MI:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(222, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Firstname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lastname:";
            // 
            // registerAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(606, 417);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.regfemale);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.regmale);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.regconfirm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.regpassword);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.regusername);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.regmi);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.regfirst);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.reglast);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "registerAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton regfemale;
        private System.Windows.Forms.RadioButton regmale;
        private System.Windows.Forms.TextBox regconfirm;
        private System.Windows.Forms.TextBox regpassword;
        private System.Windows.Forms.TextBox regusername;
        private System.Windows.Forms.TextBox regmi;
        private System.Windows.Forms.TextBox regfirst;
        private System.Windows.Forms.TextBox reglast;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;

    }
}