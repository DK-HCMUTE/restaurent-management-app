﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread thread = new Thread(OpenFrmLogin);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread thread = new Thread(OpenRegisterSuccess);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void OpenRegisterSuccess(object obj)
        {
            Application.Run(new RegisterSuccess());
            
        }
        private void OpenFrmLogin(object obj)
        {
            Application.Run(new frmLogin());

        }
    }
}
