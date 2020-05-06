﻿
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.Samples.Duplex
{
    // Define a duplex service contract.
    // A duplex contract consists of two interfaces.
    // The primary interface is used to send messages from the client to the service.
    // The callback interface is used to send messages from the service back to the client.
    // ICalculatorDuplex allows one to perform multiple operations on a running result.
    // The result is sent back after each operation on the ICalculatorCallback interface.
    [ServiceContract(Namespace = "http://Microsoft.Samples.Duplex", SessionMode=SessionMode.Required,
                     CallbackContract=typeof(ICalculatorDuplexCallback))]
    public interface ICalculatorDuplex
    {
        [OperationContract(IsOneWay = true)]
        void Clear();
        [OperationContract(IsOneWay = true)]
        void AddTo(double value);
        [OperationContract(IsOneWay = true)]
        void SubtractFrom(double value);
        [OperationContract(IsOneWay = true)]
        void MultiplyBy(double value);
        [OperationContract(IsOneWay = true)]
        void DivideBy(double value);
    }

    // The callback interface is used to send messages from service back to client.
    // The Result operation will return the current result after each operation.
    // The Equation opertion will return the complete equation after Clear() is called.
    public interface ICalculatorDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Result(double value);
        [OperationContract(IsOneWay = true)]
        void Equation(string eqn);
    }

    // Service class which implements a duplex service contract.
    // Use an InstanceContextMode of PerSession to store the result
    // An instance of the service will be bound to each duplex session
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
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

        ICalculatorDuplexCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
            }
        }
    }
}