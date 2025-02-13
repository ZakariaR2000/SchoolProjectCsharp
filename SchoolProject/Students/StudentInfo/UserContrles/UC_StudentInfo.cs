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

namespace SchoolProject.Students.StudentInfo.UserContrles
{
    public partial class UC_StudentInfo : UserControl
    {
        public UC_StudentInfo()
        {
            InitializeComponent();
        }

        public void LoadStudentInfo(int studentID)
        {
            
            int PersonID = clsStudent.FindByStudentID(studentID).PersonID;

            ctrlPersonCard1.LoadPersonInfo(PersonID);



        }
    }
}
