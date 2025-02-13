using SchoolProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectBuisness
{
    public class clsAdmin
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int AdminID { set; get; }
        public int PersonID { set; get; }
        public clsPerson PersonInfo;
      //  public string UserName { set; get; }
      public string AdminName {  set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public clsAdmin()
        {
            this.AdminID = -1;
            this.AdminName = "";
            this.Password = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private clsAdmin(int AdminID, int PersonID, string Password,
            bool IsActive, string AdminName)
        {
            this.AdminID = AdminID;
            this.AdminName = AdminName;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.Password = Password;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }

        private bool _AddNewAdmin()
        {
            // استدعاء الطبقة الخاصة بالبيانات
            this.AdminID = clsAdminData.AddNewAdmin(this.PersonID, this.AdminName, this.Password, this.IsActive);
            return (this.AdminID != -1);
        }

        private bool _UpdateAdmin()
        {
            // استدعاء الطبقة الخاصة بالبيانات
            return clsAdminData.UpdateAdmin(this.AdminID, this.PersonID, this.AdminName, this.Password, this.IsActive);
        }

        public static clsAdmin FindByAdminID(int AdminID)
        {
            int PersonID = -1;
            string AdminName = "",  Password = "";
            bool IsActive = false;

            bool IsFound = clsAdminData.GetAdminInfoByAdminID(AdminID, ref PersonID, ref AdminName, ref Password, ref IsActive);

            if (IsFound)
                return new clsAdmin(AdminID, PersonID, Password, IsActive, AdminName);
            else
                return null;
        }

        public static clsAdmin FindByPersonID(int PersonID)
        {
            int AdminID = -1;
            string AdminName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsAdminData.GetAdminInfoByPersonID(PersonID , ref AdminID , ref AdminName , ref Password , ref IsActive);

            if (IsFound)
                return new clsAdmin(AdminID, PersonID, Password, IsActive, AdminName);
            else
                return null;
        }

        public static clsAdmin FindByAdminNameAndPassword(string AdminName, string Password)
        {
            int AdminID = -1;
            int PersonID = -1;
            bool IsActive = false;

            bool IsFound = clsAdminData.GetAdminInfoByAdminNameAndPassword(AdminName, Password, ref AdminID, ref PersonID, ref IsActive);

            if (IsFound)
                return new clsAdmin(AdminID, PersonID, Password, IsActive, AdminName);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAdmin())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAdmin();
            }

            return false;
        }

        public static DataTable GetAllAdmins()
        {
            return clsAdminData.GetAllAdmins();
        }

        public static bool DeleteAdmin(int AdminID)
        {
            return clsAdminData.DeleteAdmin(AdminID);
        }

        public static bool IsAdminExist(int AdminID)
        {
            return clsAdminData.IsAdminExist(AdminID);
        }

        

        
    }
}
