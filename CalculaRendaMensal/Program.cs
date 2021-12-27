using System;
using System.Globalization;
using CalculaRendaMensal.Entities;
using CalculaRendaMensal.Entities.Enums;


namespace CalculaRendaMensal
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
                        
            Console.Write("Enter department's name: ");
            string dep = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CI);

            Department department = new Department(dep);

            Worker worker = new Worker(name, level, salary, department);
            
            Console.Write("How many contracts to this worker? ");
            int nContracts = int.Parse(Console.ReadLine());
            for (int i = 1; i <= nContracts; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CI);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);                
            }
            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            double income =  worker.Income(year, month);
            
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department}");
            Console.WriteLine($"Income for 08/2018: {income.ToString("F2", CI)}");
        }
    }
}
