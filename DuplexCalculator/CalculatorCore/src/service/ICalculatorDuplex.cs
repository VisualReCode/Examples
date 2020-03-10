
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

namespace Microsoft.Samples.Duplex
{
    // Define a duplex service contract.
    // A duplex contract consists of two interfaces.
    // The primary interface is used to send messages from the client to the service.
    // The callback interface is used to send messages from the service back to the client.
    // ICalculatorDuplex allows one to perform multiple operations on a running result.
    // The result is sent back after each operation on the ICalculatorCallback interface.
    /* Recoded [ServiceContract(Namespace = "http://Microsoft.Samples.Duplex", SessionMode=SessionMode.Required,
                     CallbackContract=typeof(ICalculatorDuplexCallback))] */
    public interface ICalculatorDuplex
    {
        /* Recoded [OperationContract(IsOneWay = true)] */
        void Clear();
        /* Recoded [OperationContract(IsOneWay = true)] */
        void AddTo(double value);
        /* Recoded [OperationContract(IsOneWay = true)] */
        void SubtractFrom(double value);
        /* Recoded [OperationContract(IsOneWay = true)] */
        void MultiplyBy(double value);
        /* Recoded [OperationContract(IsOneWay = true)] */
        void DivideBy(double value);
        global::Microsoft.Samples.Duplex.ICalculatorDuplexCallback Callback { get; set; }
    }
}

