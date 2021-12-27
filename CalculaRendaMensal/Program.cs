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

            Console.WriteLine($"{worker.Name}, {level}, {salary.ToString("F2", CI)}, {department}");

        }
    }
}
