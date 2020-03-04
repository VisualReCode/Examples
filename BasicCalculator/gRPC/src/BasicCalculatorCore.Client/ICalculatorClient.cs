using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCalculatorCore.Client
{
    public interface ICalculatorClient
    {
        [Obsolete("Use AddAsync")]
        double Add(double value1, double value2);

        Task<double> AddAsync(double value1, double value2);

        [Obsolete("Use SubtractAsync")]
        double Subtract(double value1, double value2);

        Task<double> SubtractAsync(double value1, double value2);

        [Obsolete("Use MultiplyAsync")]
        double Multiply(double value1, double value2);

        Task<double> MultiplyAsync(double value1, double value2);

        [Obsolete("Use DivideAsync")]
        double Divide(double value1, double value2);

        Task<double> DivideAsync(double value1, double value2);

    }
}

