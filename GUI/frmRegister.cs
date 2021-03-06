using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BUS;
namespace GUI
{
    public partial class frmRegister : Form
    {
        StaffBUS staffBUS = new StaffBUS();
        AccountBUS accountBUS = new AccountBUS();
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
            // get data
            int gender = 0;
            if (rdoFemale.Checked)
            {
                gender = 1;
            }

            DateTime birthdate = dtpBirthDate.Value;
           
            // end get data
            Account account = new Account(txtUserName.Text, txtPassword.Text, 1);
            Staff staff = new Staff(txtName.Text, gender, birthdate, txtAddress.Text, txtPhoneNumber.Text);
            
            // validate
            bool result1 = staffBUS.ValidateStaffs(staff);
            bool result2 = accountBUS.ValidateAccounts(account);
            // end validate
            if (result1 && result2)
            {
                accountBUS.addAccounts(account);
                staff.AccountID = accountBUS.getLatestID();
                staffBUS.addStaffs(staff);
                this.Close();
                Thread thread = new Thread(OpenRegisterSuccess);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            



        }
        private void OpenRegisterSuccess(object obj)
        {
            Application.Run(new RegisterSuccess());
            
        }
        private void OpenFrmLogin(object obj)
        {
            Application.Run(new frmLogin());

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
