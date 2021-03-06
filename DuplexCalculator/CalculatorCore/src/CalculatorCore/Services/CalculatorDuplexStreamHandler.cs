//
// This code was generated by Visual ReCode 1.0.0.0
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CalculatorCore.Services
{
    public partial class CalculatorDuplexStreamHandler
    {
        private readonly IAsyncStreamReader<Protos.CalculatorDuplexAction> _requestStream;
        private readonly IServerStreamWriter<Protos.CalculatorDuplexCallback> _responseStream;
        private readonly ILogger _logger;
        private readonly PendingCompletionStore _pendingCompletions;
        private readonly CalculatorDuplexCallbackImplementation _callback;
        private readonly global::Microsoft.Samples.Duplex.ICalculatorDuplex _contract;
        
        public CalculatorDuplexStreamHandler(ICalculatorDuplexCallbackContractFactory callbackContractFactory, IAsyncStreamReader<Protos.CalculatorDuplexAction> requestStream, IServerStreamWriter<Protos.CalculatorDuplexCallback> responseStream, ILogger logger)
        {
            _requestStream = requestStream;
            _responseStream = responseStream;
            _logger = logger;
            _pendingCompletions = new PendingCompletionStore(TimeSpan.FromMinutes(1));
            _callback = new CalculatorDuplexCallbackImplementation(_responseStream, _pendingCompletions);
            _contract = callbackContractFactory.Create(_callback);
        }

        public async Task RunAsync(CancellationToken token)
        {
            await foreach (var action in _requestStream.ReadAllAsync(token))
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                switch (action.ActionCase)
                {
                    case Protos.CalculatorDuplexAction.ActionOneofCase.Clear:
                        Task.Run(() => InvokeClearAsync(action.Clear));
                        break;
                    case Protos.CalculatorDuplexAction.ActionOneofCase.AddTo:
                        Task.Run(() => InvokeAddToAsync(action.AddTo));
                        break;
                    case Protos.CalculatorDuplexAction.ActionOneofCase.SubtractFrom:
                        Task.Run(() => InvokeSubtractFromAsync(action.SubtractFrom));
                        break;
                    case Protos.CalculatorDuplexAction.ActionOneofCase.MultiplyBy:
                        Task.Run(() => InvokeMultiplyByAsync(action.MultiplyBy));
                        break;
                    case Protos.CalculatorDuplexAction.ActionOneofCase.DivideBy:
                        Task.Run(() => InvokeDivideByAsync(action.DivideBy));
                        break;
                }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
        }

        private Task InvokeClearAsync(Protos.CalculatorDuplexAction.Types.Clear action)
        {
            try
            {
                _contract.Clear();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invoking Clear");
                throw;
            }
        }


        private Task InvokeAddToAsync(Protos.CalculatorDuplexAction.Types.AddTo action)
        {
            try
            {
                _contract.AddTo(action.Value);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invoking AddTo");
                throw;
            }
        }


        private Task InvokeSubtractFromAsync(Protos.CalculatorDuplexAction.Types.SubtractFrom action)
        {
            try
            {
                _contract.SubtractFrom(action.Value);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invoking SubtractFrom");
                throw;
            }
        }


        private Task InvokeMultiplyByAsync(Protos.CalculatorDuplexAction.Types.MultiplyBy action)
        {
            try
            {
                _contract.MultiplyBy(action.Value);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invoking MultiplyBy");
                throw;
            }
        }


        private Task InvokeDivideByAsync(Protos.CalculatorDuplexAction.Types.DivideBy action)
        {
            try
            {
                _contract.DivideBy(action.Value);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invoking DivideBy");
                throw;
            }
        }


    }
}

