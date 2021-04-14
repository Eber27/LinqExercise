using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            Console.WriteLine($"Sum is {sum}");

            var average = numbers.Average();
            Console.WriteLine($"Average: {average}");


            //Order numbers in ascending order and decsending order. Print each to console.

            var ascend = numbers.OrderBy(x => x);
            Console.WriteLine("----------------------");
            Console.WriteLine("Asc");

            foreach (var x in ascend)
            {
                Console.WriteLine(x);
            }

            var descend = numbers.OrderByDescending(x => x);
            Console.WriteLine("----------------------");
            Console.WriteLine("Desc");

            foreach (var x in descend)
            {
                Console.WriteLine(x);
            }

            //Print to the console only the numbers greater than 6

            var six = numbers.Where(num => num > 6);
            Console.WriteLine("Greater than six");

            foreach (var num in six)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var onlyFour = ascend.Take(4);
            Console.WriteLine("Show only four numbers");

            foreach (var x in onlyFour)
            {
                Console.WriteLine(x);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 32;
            Console.WriteLine("Change index four with Age");

            foreach (var x in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(x);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var fullNames = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);

            Console.WriteLine("C or S Employees First Names");

            foreach (var employee in fullNames)
            {
                Console.WriteLine(employee.FullName);
            }


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var overtwentysix = employees.Where(x => x.Age > 26)
                .OrderBy(x => x.Age)
                .ThenBy(x => x.FirstName);
            Console.WriteLine("Over 26");

            foreach (var item in overtwentysix)
            {
                Console.WriteLine($"Full Name: {item.FullName}  Age: {item.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var YOE = employees.Where(exp => exp.YearsOfExperience <= 10 && exp.Age > 35);

            var SumYOE = employees.Sum(exp => exp.YearsOfExperience);
            var AvgYOE = employees.Average(exp => exp.YearsOfExperience);
            Console.WriteLine(" Years of Experience Sum and Average");

            Console.WriteLine($"Sum is: {SumYOE} and Average is: {AvgYOE}");



            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("FirstName", "LastName", 57, 11)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($" {emp.FirstName} {emp.LastName} {emp.Age} {emp.YearsOfExperience}");
            }

            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
