
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

namespace Microsoft.Samples.GettingStarted
{

    // Service class which implements the service contract.
    public class CalculatorService : ICalculator
    {
        public double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        public double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }

        public double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }

        public double Divide(double value1, double value2)
        {
            return value1 / value2;
        }
    }

}

