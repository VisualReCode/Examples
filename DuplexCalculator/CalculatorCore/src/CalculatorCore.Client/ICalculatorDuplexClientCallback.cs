using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorCore.Client
{
    public interface ICalculatorDuplexClientCallback
    {
        [Obsolete("Use ResultAsync")]
        void Result(double value);

        Task ResultAsync(double value);

        [Obsolete("Use EquationAsync")]
        void Equation(string eqn);

        Task EquationAsync(string eqn);

    }
}

