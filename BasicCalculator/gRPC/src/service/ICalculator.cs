
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

namespace Microsoft.Samples.GettingStarted
{
    // Define a service contract.
    /* Recoded [ServiceContract(Namespace="http://Microsoft.Samples.GettingStarted")] */
    public interface ICalculator
    {
        /* Recoded [OperationContract] */
        double Add(double value1, double value2);
        /* Recoded [OperationContract] */
        double Subtract(double value1, double value2);
        /* Recoded [OperationContract] */
        double Multiply(double value1, double value2);
        /* Recoded [OperationContract] */
        double Divide(double value1, double value2);
    }

}

