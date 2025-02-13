using SchoolProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProjectBuisness
{
    public class clsClass
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;


        public int ID { set; get; }
        public string ClassName { set; get; }
        public float ClassFees { set; get; }


        public clsClass()

        {
            this.ID = -1;
            this.ClassName = "";
            this.ClassFees = 0;

            Mode = enMode.AddNew;

        }

        private clsClass(int ID, string ClassName , float ClassFees)
        {
            this.ID = ID;
            this.ClassName = ClassName;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;


        }

        public static clsClass Find(int ID)
        {
            string ClassName = "";
            float ClassFees = 0;

            if (clsClassData.GetClassInfoByID(ID, ref ClassName, ref ClassFees))

                return new clsClass(ID, ClassName, ClassFees);
            else
                return null;

        }

        //public static clsClass Find(string ClassName)
        //{

        //    int ID = -1;
        //    float ClassFees = 0;

        //    if (clsClassData.GetClassInfoByClassName(ClassName, ref ID, ref ClassFees))
        //        return new clsClass(ID, ClassName, ClassFees);
        //    else
        //        return null;

        //}

        public static clsClass Find(string ClassName)
        {
            int ID = -1;
            float ClassFees = 0;


            if (clsClassData.GetClassInfoByClassName(ClassName, ref ID, ref ClassFees))
            {
                return new clsClass(ID, ClassName, ClassFees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllClasses()
        {
            return clsClassData.GetAllClasses();

        }

        private bool _AddNewClass()
        {
            //call DataAccess Layer 

            this.ID = clsClassData.AddNewClass(this.ClassName, this.ClassFees);


            return (this.ID != -1);
        }

        private bool _UpdateClass()
        {
            //call DataAccess Layer 

            return clsClassData.UpdateClass(this.ID, this.ClassName, this.ClassFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClass())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateClass();

            }

            return false;
        }


        public static bool IsClassNameAvailable(string className)
        {

            return clsClassData.DoesClassNameExist(className);

        }

        public static int GetClassID(string className)
        {
            return clsClassData.GetClassIDByName(className);
        }

    }
}
