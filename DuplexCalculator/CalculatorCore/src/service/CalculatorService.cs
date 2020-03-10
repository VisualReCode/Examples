
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

namespace Microsoft.Samples.Duplex
{

    // Service class which implements a duplex service contract.
    // Use an InstanceContextMode of PerSession to store the result
    // An instance of the service will be bound to each duplex session
    /* Recoded [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] */
    public class CalculatorService : ICalculatorDuplex
    {
        double result = 0.0D;
        string equation;

        public CalculatorService()
        {
            equation = result.ToString();
        }

        public void Clear()
        {
            Callback.Equation(equation + " = " + result.ToString());
            equation = result.ToString();
        }

        public void AddTo(double value)
        {
            result += value;
            equation += " + " + value.ToString();
            Callback.Result(result);
        }

        public void SubtractFrom(double value)
        {
            result -= value;
            equation += " - " + value.ToString();
            Callback.Result(result);
        }

        public void MultiplyBy(double value)
        {
            result *= value;
            equation += " * " + value.ToString();
            Callback.Result(result);
        }

        public void DivideBy(double value)
        {
            result /= value;
            equation += " / " + value.ToString();
            Callback.Result(result);
        }
public Microsoft.Samples.Duplex.ICalculatorDuplexCallback Callback { get; set; }    }
}

