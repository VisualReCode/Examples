
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.Samples.GettingStarted
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.Samples.GettingStarted")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double value1, double value2);
        [OperationContract]
        double Subtract(double value1, double value2);
        [OperationContract]
        double Multiply(double value1, double value2);
        [OperationContract]
        double Divide(double value1, double value2);
    }

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
