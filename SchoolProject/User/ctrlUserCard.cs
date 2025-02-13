﻿using SchoolProjectBuisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject.User
{
    public partial class ctrlUserCard : UserControl
    {

        private int _UserID = -1;

        private clsUser _User;

        public int UserID
        {
            get
            {
                return _UserID;
            }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _ResetPersonInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();

            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }


        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonInfo.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);

            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _FillUserInfo();
        }
    }
}
