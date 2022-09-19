using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;


namespace BLL
{
    public class BusinessLogicLayer
    {
        DataAccessLayer dal = new DataAccessLayer();
        public int InsertCourse(Course c)
        {
            return dal.InsertCourse(c);
        }
        public int UpdateCourse(Course c)
        {
            return dal.UpdateCourse(c);
        }
        public int DeleteCourse(Course c)
        {
            return dal.DeleteCourse(c);
        }
        public DataTable GetCourseType()
        {
            return dal.GetCourseType();
        }
        public DataTable GetCourse()
        {
            return dal.GetCourse();
        }
    }
}
