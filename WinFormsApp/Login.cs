using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp.Account;

namespace WinFormsApp
{
    public partial class Login : Form
    {
        public List<Users> userList = new List<Users>();
        public Login()
        {
            Form1_Load();
            InitializeComponent();
        }

        private void Form1_Load()
        {
            if (userList.Count == 0)
            {
                Users admin = new Users()
                {
                    userName = "admin",
                    password = "admin",
                };
                userList.Add(admin);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String result = "";
            foreach (var account in userList)
            {
                if (account.userName == txtUserId.Text)
                {
                    if (account.password == txtPassword.Text)
                    {
                        result = "1";
                    }
                    else
                        result = "Invalid credentials";
                }
            }

            if (result == "1")
            {
                Program.openDashboard = true;

                this.Close();
            }
            else
                MessageBox.Show(result);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUserId.Text = "";
            this.Hide();
        }
    }
}
