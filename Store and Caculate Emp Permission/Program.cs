using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace TungVu_300386998_Quiz2
{
    internal class Program
    {
        //declare dictionary
        static Dictionary<string, string[]> employees = new Dictionary<string, string[]>();
        public static void display() //method to display all records
        {
            var record = from emp in employees
                         orderby emp.Key //order by name
                         select emp;

            foreach (var emp in record) //return result
            {
                WriteLine("Employee name: " + emp.Key);
                WriteLine("Employee type: " + emp.Value[0]);
                WriteLine("Employee sales is: " + emp.Value[1]);
                if (emp.Value[0].Equals("F"))
                {
                    WriteLine("Employee commission is: {0:F2}", double.Parse(emp.Value[1]) / 100 * 15);
                }
                else
                {
                    WriteLine("Employee commission is: {0:F2}", double.Parse(emp.Value[1]) / 100 * 10);
                }
            }
        }
        static void Main(string[] args)
        {
            //declare inputs
            char menuSelect;
            string empName;
            char empType;
            int empSale;
            bool Again = true;
            //loop through the program
            while (Again)
            {
                //promp user for imput
                Write("(A)dd Employee, (R)emove Employee, (M)odify Employee, (C)ompute or (Q)uit |");
                menuSelect = char.Parse(ReadLine());
                if (menuSelect == 'A')
                {
                    Write("Enter the Employee name: ");
                    empName = ReadLine();
                    Write("Enter the employee type (F for Full-time and P for Part-time): ");
                    try
                    {
                        empType = char.Parse(ReadLine());
                        Write("Enter the employee sales: ");
                        empSale = int.Parse(ReadLine());
                        //add record to dictionary
                        employees.Add(empName, new string[] { empType.ToString(), empSale.ToString("F2") });
                        WriteLine("Record Updated......");
                    }
                    catch (Exception ex)
                    {
                        Write(ex.Message);
                    }

                }
                else if (menuSelect == 'M')
                {
                    Write("Enter the Employee name: ");
                    empName = ReadLine();
                    Write("Enter the new sales amount: ");
                    empSale = int.Parse(ReadLine());
                    //modify sales for existing
                    var record = from emp in employees
                                 where emp.Key == empName
                                 select emp;
                    foreach (var emp in record)
                    {
                        emp.Value[1] = empSale.ToString();
                    }
                    WriteLine("Record Updated......");

                }
                else if (menuSelect == 'R')
                {
                    char Confirm;
                    Write("Enter the Employee name: ");
                    empName = ReadLine();
                    Write("Do you really want to delete this record? Y/N: ");
                    try
                    {
                        Confirm = char.Parse(ReadLine());
                        //delete record with mentioned name
                        employees.Remove(empName);
                        WriteLine("Record Deleted......");
                    }
                    catch
                    {
                        WriteLine("Please enter the correct letter");
                    }
                }
                else if (menuSelect == 'C')
                {
                    display(); //call method to display
                }
                else if (menuSelect == 'Q')
                {
                    WriteLine("Thank you..."); //end
                    Again = false;
                }
                else
                {
                    WriteLine("Please enter the corect input (with Capital)"); //input if user not input correct letter
                }
            }
            ReadKey();
        }
    }
}
