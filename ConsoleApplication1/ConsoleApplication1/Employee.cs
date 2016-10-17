using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Employee
    {
        protected string employeeID, employeeName;
        DateTime termDate;
        double payrate;

        public Employee(string newEmployeeID, string newEmployeeName, double newPayrate, DateTime newTermDate)
        {
            employeeID = newEmployeeID;
            employeeName = newEmployeeName;
            payrate = newPayrate;
            termDate = newTermDate;
        }

        public string GetEmployeeId
        {
            get
            {
                return employeeID;
            }
        }

        public string GetEmployeeName
        {
            get
            {
                return employeeName;
            }
        }

        public double getPayRate
        {
            get
            {
                return payrate;
            }
        }
        public DateTime getTermDate
        {
            get
            {
                return termDate;
            }

        }

        public void setTermDate(Employee a)
        {
            termDate = DateTime.MinValue;
        }

        public void Raise(double raiseAmount)
        {
            payrate = (payrate + raiseAmount);
        }

        
    }

}




