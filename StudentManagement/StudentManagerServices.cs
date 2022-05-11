using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class StudentManagerServices
    {
        private StudentDAOContainer db;
        public StudentManagerServices()
        {
            db = new StudentDAOContainer();
        }
        public bool Insert(string name,int date,int sex,
            string phone,string address,string email)
        {
            Students st = new Students();
            st.name = name;
            st.birthday = date;
            st.sex = sex;
            st.phone = phone;
            st.address = address;
            st.email = email;
            try
            {
                db.Students1.Add(st);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int mssv)
        {
            var st = db.Students1.Find(mssv);
            try
            {
                db.Students1.Remove(st);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
              
            }
            return false;
        }
        public bool Edit(int mssv, string name, int date, int sex,
            string phone, string address, string email)
        {
            try
            {
                Students st = db.Students1.Find(mssv);
                st.name = name;
                st.birthday = date;
                st.sex = sex;
                st.phone = phone;
                st.address = address;
                st.email = email;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }
        public List<Students> showAllData()
        {
            var list = db.Students1.ToList();
            return list;
        }
        
    }

}
