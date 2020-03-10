using System;
using System.Threading.Tasks;
using CalculatorCore.Client;

namespace CalculatorConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new CalculatorDuplexClient("https://localhost:5001", new Callback()))
            {
                await client.AddToAsync(21);
                await client.MultiplyByAsync(2);
                await Task.Delay(1000);
            }

            Console.ReadLine();
        }
    }

    class Callback : ICalculatorDuplexClientCallback
    {
        public void Result(double value)
        {
            Console.WriteLine($"Result: {value}");
        }

        public Task ResultAsync(double value)
        {
            Console.WriteLine($"Result: {value}");
            return Task.CompletedTask;
        }

        public void Equation(string eqn)
        {
        }

        public Task EquationAsync(string eqn)
        {
            return Task.CompletedTask;
        }
    }
}
