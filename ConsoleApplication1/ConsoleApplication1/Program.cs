using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {


            string fileName = "C:\\temp\\Employees.xml";

            List<Employee> employee = new List<Employee>();

            ReadFile();
            
            if (File.Exists(fileName))
            {
                
            }
            else
            {
                bool keeplooping = true;

                while (keeplooping)
                {
                    drawMenu();

                    int menuchoice = Convert.ToChar(Console.ReadLine());

                    switch (menuchoice)
                    {
                        case '1':
                            {
                                createEmployee(employee);
                                break;
                            }
                        case '2':
                            {
                                terminate(employee);
                                break;
                            }

                        case '3':
                            {
                                giveRaise(employee);
                                break;
                            }


                        case '4':
                            {
                                pay(employee);
                                break;
                            }

                        case '5':
                            {
                                DisplayAll(employee);
                                break;
                            }
                        case '6':
                            {
                                Console.WriteLine("Thanks for using the employee program!");
                                Save(employee);
                                keeplooping = false;
                                break;
                            }
                        default:
                            Console.WriteLine("Sorry, invalid selection");
                            break;
                    }
                    Console.WriteLine("Hit any key to continue.");
                    Console.ReadKey();
                }
             
            }
        }




        #region methods

        public static void drawMenu()
        {
            Console.Clear();
            Console.WriteLine("Employee program");
            Console.WriteLine("-----------------");
            Console.WriteLine("Please select an option from the menu");
            Console.WriteLine("1.) Create an employee");
            Console.WriteLine("2.) Terminate an employee");
            Console.WriteLine("3.) Give a raise");
            Console.WriteLine("4.) Pay all employees");
            Console.WriteLine("5.) Display all employees");
            Console.WriteLine("6.) Exit the Program");
        }

        public static void createEmployee(List<Employee> c)
        {
            Console.WriteLine("Please enter an id for the employee");
            string y = Console.ReadLine();
            Console.WriteLine("Please enter a name for the employee");
            string x = Console.ReadLine();
            Console.WriteLine("Please enter the pay rate for the employee");
            string z = Console.ReadLine();
            DateTime q = DateTime.Now;
            Employee newEmployee = new Employee(y, x, Convert.ToDouble(z), q);
            c.Add(newEmployee);
            Console.WriteLine("Employee saved!");
            Console.WriteLine(" ");
        }

        public static void giveRaise(List<Employee> a)
        {
            bool itemFound = false;
            Console.WriteLine("Which employee ID should get a raise?");
            string y = Console.ReadLine();
            foreach (Employee c in a)
            {
                if (y == c.GetEmployeeId)
                {
                    Console.WriteLine("How much do you want to raise this hourly salary by?");
                    c.Raise(Convert.ToDouble(Console.ReadLine()));
                    Console.WriteLine("New salary saved!");
                    Console.WriteLine(" ");
                    itemFound = true;
                }
            }
            if (itemFound == false)
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public static void terminate(List<Employee> a)
        {

            Console.WriteLine("Which employee ID should be terminated?");
            string y = Console.ReadLine();
            foreach (Employee c in a)
            {
                if (y == c.GetEmployeeId)
                {
                    c.setTermDate(c);
                    Console.WriteLine(c.GetEmployeeName + " Got terminated");
                    Console.WriteLine(" ");
                }
            }
        }

        public static void pay(List<Employee> c)
        {
            foreach (Employee a in c)
            {
                if (a.getTermDate != DateTime.MinValue)
                {
                    Console.WriteLine(a.GetEmployeeName + " Got paid");
                    Console.WriteLine(" ");
                }
            }
        }

        public static void DisplayAll(List<Employee> c)
        {
            foreach (Employee a in c)
            {
                if (a.getTermDate != DateTime.MinValue)
                {

                    Console.WriteLine(a.GetEmployeeName + " , " + a.getPayRate);
                }
            }
        }



        public static void Save(List<Employee> a)
        {
            using (XmlWriter writer = XmlWriter.Create("C:\\temp\\Employees.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Company");

                foreach (Employee c in a)
                {
                    writer.WriteStartElement("Employee");
 
                    writer.WriteStartElement("Id", c.GetEmployeeId.ToString());
                    writer.WriteStartElement("Name", c.GetEmployeeName.ToString());
                    writer.WriteStartElement("PayRate", c.getPayRate.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();

            }
        }

        public static void ReadFile()
        {

            string fileName = "C:\\temp\\Employees.xml";
            if (File.Exists(fileName))
            {

            }
        }
    }
}



#endregion


