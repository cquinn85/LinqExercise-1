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
            var average = numbers.Average();
            Console.WriteLine($"Sum: {sum}, Average: {average}");

            Console.WriteLine("=======================");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascend = numbers.OrderBy(num => num);
            var descend = numbers.OrderByDescending(x => x);

            Console.WriteLine("Ascending:");

            foreach (var num in ascend)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("===========================");

            Console.WriteLine("Descending:");

                         
            foreach(var num in descend)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("==================");

            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);

            Console.WriteLine("Numbers greater than 6:");

            foreach(var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========================");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Print 4 numbers:");

            foreach (var num in ascend.Take(4))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("====================");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 35;

            foreach (var num in numbers.OrderByDescending(num => num)) 
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("==================");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            //make a new variable first
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
             .OrderBy(person => person.FirstName);

            Console.WriteLine("C or S for employees");
            
            foreach(var item in filtered)
            {
                Console.WriteLine(item.FirstName);
            }

            Console.WriteLine("=================");



            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.FirstName).ThenBy(person => person.FirstName)
                .ThenBy(person => person.YearsOfExperience);

            Console.WriteLine("Employees First Name over the age of 26:");

            foreach(var age in overTwentySix)
            {
                Console.WriteLine($"First name: {age.FirstName} Age: {age.Age}, Years of experience: {age.YearsOfExperience}");
            }

            Console.WriteLine("===================");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var years = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);

            Console.WriteLine($"Sum: {years.Sum(person => person.YearsOfExperience)} Average: {years.Average(person => person.YearsOfExperience)}");

            Console.WriteLine("=====================");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jane", "Doe", 98, 1)).ToList();
            foreach(var person in employees)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age} {person.YearsOfExperience}");
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
