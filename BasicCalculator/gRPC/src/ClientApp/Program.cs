//
// This is the only hand-written code in this solution.
// Everything else was automatically generated from the WCF original.
//
using System;
using BasicCalculatorCore.Client;

namespace ClientApp
{
    class Program
    {
        static void Main()
        {
            // This demonstrates the wrapper client, which matches the generated client
            // from the WCF service and is intended to make migrating client applications easier

            // Create a client
            CalculatorClient client = new CalculatorClient("https://localhost:5001");

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }    }
}
