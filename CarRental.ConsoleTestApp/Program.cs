using System.Collections.Generic;
using System;
using System.Linq;

namespace CarRental.ConsoleTestApp
{
    public class Program 
    {
        private static void Main(string[] args)
        {

            var mgr = new Manager("Rennish Joseph");
            Console.WriteLine("Employee Name is {0}", mgr.Name);

            Console.ReadLine();

        }
        
    }

    public abstract class Employee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract void Show();
    }

    public class Manager : Employee    
    {
        public Manager(string name ) : base(name)
        {

        }

        public override void Show()
        {
           // Console.WriteLine(" Employee name is {0}", this.Name);
        }
    }


    
}