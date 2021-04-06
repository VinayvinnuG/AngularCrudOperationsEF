using AngularCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AngularCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        #region CrudOperations

        /// Get All Employee   
        public JsonResult Get_AllEmployee()
        {
            using (MVCPraticeEntities Obj = new MVCPraticeEntities())
            {
                List<Employee> Emp = Obj.Employees.ToList();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }
        ///*
        /// Get Employee With Id  
        public JsonResult Get_EmployeeById(string Id)
        {
            using (MVCPraticeEntities Obj = new MVCPraticeEntities())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Employees.Find(EmpId), JsonRequestBehavior.AllowGet);
            }
        }
        /// Insert New Employee 
        public string Insert_Employee(Employee Employe)
        {
            if (Employe != null)
            {
                using (MVCPraticeEntities Obj = new MVCPraticeEntities())
                {
                    Obj.Employees.Add(Employe);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }
        /// Delete Employee Information 
        public string Delete_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using (MVCPraticeEntities Obj = new MVCPraticeEntities())
                {
                    var Emp_ = Obj.Entry(Emp);
                    if (Emp_.State == EntityState.Detached)
                    {
                        Obj.Employees.Attach(Emp);
                        Obj.Employees.Remove(Emp);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            }
            else
            {
                return "Employee Not Deleted! Try Again";
            }
        }
        /// Update Employee Information  
        public string Update_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using (MVCPraticeEntities Obj = new MVCPraticeEntities())
                {
                    var Emp_ = Obj.Entry(Emp);
                    Employee EmpObj = Obj.Employees.Where(x => x.Emp_Id == Emp.Emp_Id).FirstOrDefault();
                    EmpObj.Emp_Age = Emp.Emp_Age;
                    EmpObj.Emp_City = Emp.Emp_City;
                    EmpObj.Emp_Name = Emp.Emp_Name;
                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }
        //*/
        #endregion CrudOperations

    }
}