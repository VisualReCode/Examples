
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

namespace Microsoft.Samples.Duplex
{

    // The callback interface is used to send messages from service back to client.
    // The Result operation will return the current result after each operation.
    // The Equation opertion will return the complete equation after Clear() is called.
    public interface ICalculatorDuplexCallback
    {
        /* Recoded [OperationContract(IsOneWay = true)] */
        void Result(double value);
        /* Recoded [OperationContract(IsOneWay = true)] */
        void Equation(string eqn);
    }
}

