//
// This code was generated by Visual ReCode 1.0.0.0
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CalculatorCore.Client
{
    public partial class CalculatorDuplexCallbackStreamHandler : IDisposable
    {
        private readonly IClientStreamWriter<Protos.CalculatorDuplexAction> _requestStream;
        private readonly IAsyncStreamReader<Protos.CalculatorDuplexCallback> _responseStream;
        private readonly PendingCompletionStore _pendingCompletions;
        private readonly ICalculatorDuplexClientCallback _callback;
        
        public CalculatorDuplexCallbackStreamHandler(ICalculatorDuplexClientCallback callback, IClientStreamWriter<Protos.CalculatorDuplexAction> requestStream, IAsyncStreamReader<Protos.CalculatorDuplexCallback> responseStream)
        {
            _callback = callback;
            _requestStream = requestStream;
            _responseStream = responseStream;
            _pendingCompletions = new PendingCompletionStore(TimeSpan.FromMinutes(1));
        }

        public (long, Task<T>) GetCompletion<T>()
        {
            var (callId, completionSource) = _pendingCompletions.Create<T>();
            return (callId, completionSource.Task);
        }

        public async Task WriteAsync(Protos.CalculatorDuplexAction action)
        {
            await _requestStream.WriteAsync(action);
        }

#if(NETSTANDARD2_1)
        public async Task RunAsync(CancellationToken cancellation = default)
        {
            await foreach (var callback in _responseStream.ReadAllAsync(cancellation))
            {
                HandleCallback(callback);
            }
        }
#else
        public async Task RunAsync(CancellationToken cancellation = default)
        {
            while (await _responseStream.MoveNext(cancellation))
            {
                HandleCallback(_responseStream.Current);
            }
        }
#endif
        public void HandleCallback(Protos.CalculatorDuplexCallback callback)
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            switch (callback.CallbackCase)
            {
                case Protos.CalculatorDuplexCallback.CallbackOneofCase.Result:
                    Task.Run(() => InvokeResultAsync(callback.Result));
                    break;
                case Protos.CalculatorDuplexCallback.CallbackOneofCase.Equation:
                    Task.Run(() => InvokeEquationAsync(callback.Equation));
                    break;
            }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private async Task InvokeResultAsync(Protos.CalculatorDuplexCallback.Types.Result callback)
        {
            await _callback.ResultAsync(callback.Value);
        }


        private async Task InvokeEquationAsync(Protos.CalculatorDuplexCallback.Types.Equation callback)
        {
            await _callback.EquationAsync(callback.Eqn);
        }


        public void Dispose()
        {
            _requestStream.CompleteAsync().GetAwaiter().GetResult();
        }
    }
}
