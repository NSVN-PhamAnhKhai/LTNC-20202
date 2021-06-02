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
        static List<Users> userList = new List<Users> 
        {        
            new Users{userName = "admin", password = "admin"},
            new Users{userName = "dongbx", password = "20172473"},
            new Users{userName = "datnt", password = "20172451"},
            new Users{userName = "trungpq", password = "20172875"},
            new Users{userName = "khaipa", password = "20172617"},
            new Users{userName = "thangnv", password = "20172808"}
        };
        public Login()
        {
            Form1_Load();
            InitializeComponent();
        }

        private void Form1_Load()
        {
            
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
