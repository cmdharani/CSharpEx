using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDesignPattern
{
    //This is going to be our Model class which holds the Model data
    //This class is going to be used by both EmployeeDAL and EmployeeBL
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    #region WITHOUT Dependency Injection
    ////Service Class or Dependency Object
    ////This is the class that is responsible for Interacting with the Database
    ////This class is going to be used by the EmpoloyeeBL class
    ////That means it is going to be the Dependency Object
    //public class EmployeeDAL
    //{
    //    public List<Employee> SelectAllEmployees()
    //    {
    //        List<Employee> ListEmployees = new List<Employee>
    //        {
    //            //Get the Employees from the Database
    //            //for now we are hard coded the employees
    //            new Employee() { ID = 1, Name = "Pranaya", Department = "IT" },
    //            new Employee() { ID = 2, Name = "Kumar", Department = "HR" },
    //            new Employee() { ID = 3, Name = "Rout", Department = "Payroll" }
    //        };
    //        return ListEmployees;
    //    }
    //}

    ////Client Class or Dependent Object
    ////This is the Class that is going to consume the services provided by the EmployeeDAL Class
    ////That means it is the Dependent Class which is Depending on the EmployeeDAL Class
    //public class EmployeeBL
    //{




    //    public EmployeeDAL employeeDAL;
    //    public List<Employee> GetAllEmployees()
    //    {
    //        //Creating an Instance of Dependency Class means it is a Tight Coupling
    //        employeeDAL = new EmployeeDAL();
    //        return employeeDAL.SelectAllEmployees();
    //    }
    //} 
    #endregion


    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }


    public class EmployeeDAL : IEmployeeDAL
    {
        List<Employee> IEmployeeDAL.SelectAllEmployees()
        {
            List<Employee> ListEmployees = new List<Employee>
            {
                //Get the Employees from the Database
                //for now we are hard coded the employees
                new Employee() { ID = 1, Name = "Pranaya", Department = "IT" },
                new Employee() { ID = 2, Name = "Kumar", Department = "HR" },
                new Employee() { ID = 3, Name = "Rout", Department = "Payroll" }
            };
            return ListEmployees;
        }
    }

    public class EmployeeBL
    {
        public IEmployeeDAL _employeeDAL;

        public EmployeeBL(IEmployeeDAL employeeDAL)
        {
            _employeeDAL=employeeDAL;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeDAL.SelectAllEmployees();
        }

    }



    class Program
    {
        public static void Main1()
        {
            //EmployeeBL employeeBL = new EmployeeBL();
            EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
            var empList = employeeBL.GetAllEmployees();

            foreach (var emp in empList)
            {
                Console.WriteLine(emp.Name);
            }
            Console.ReadLine();

        }
    }
}
