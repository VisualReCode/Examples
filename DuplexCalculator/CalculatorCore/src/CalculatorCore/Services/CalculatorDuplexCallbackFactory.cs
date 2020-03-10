using System;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorCore.Services
{
    public interface ICalculatorDuplexCallbackContractFactory
    {
        global::Microsoft.Samples.Duplex.ICalculatorDuplex Create(global::Microsoft.Samples.Duplex.ICalculatorDuplexCallback callbackProxy);
    }

    public class CalculatorDuplexCallbackContractFactory : ICalculatorDuplexCallbackContractFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CalculatorDuplexCallbackContractFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public global::Microsoft.Samples.Duplex.ICalculatorDuplex Create(global::Microsoft.Samples.Duplex.ICalculatorDuplexCallback callbackProxy)
        {
            var contract = _serviceProvider.GetService<global::Microsoft.Samples.Duplex.ICalculatorDuplex>();
            contract.Callback = callbackProxy;
            return contract;
        }
    }
}

