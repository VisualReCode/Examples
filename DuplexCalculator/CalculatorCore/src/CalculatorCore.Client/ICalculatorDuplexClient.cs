using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorCore.Client
{
    public interface ICalculatorDuplexClient
    {
        [Obsolete("Use ClearAsync")]
        void Clear();

        Task ClearAsync();

        [Obsolete("Use AddToAsync")]
        void AddTo(double value);

        Task AddToAsync(double value);

        [Obsolete("Use SubtractFromAsync")]
        void SubtractFrom(double value);

        Task SubtractFromAsync(double value);

        [Obsolete("Use MultiplyByAsync")]
        void MultiplyBy(double value);

        Task MultiplyByAsync(double value);

        [Obsolete("Use DivideByAsync")]
        void DivideBy(double value);

        Task DivideByAsync(double value);

    }
}

