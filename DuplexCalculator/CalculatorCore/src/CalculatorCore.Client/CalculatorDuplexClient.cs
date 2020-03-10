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
#if(NETSTANDARD2_1)
using Grpc.Net.Client;
#endif

namespace CalculatorCore.Client
{
    public partial class CalculatorDuplexClient : ICalculatorDuplexClient, IDisposable
    {
        private readonly Protos.CalculatorDuplex.CalculatorDuplexClient _client;
        private readonly ICalculatorDuplexClientCallback _callback;
        private readonly object _sync = new object();
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CalculatorDuplexCallbackStreamHandler _streamHandler;
        private Task _streamHandlerTask;
        
        public CalculatorDuplexClient(Protos.CalculatorDuplex.CalculatorDuplexClient client, ICalculatorDuplexClientCallback callback)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }
        
        public CalculatorDuplexClient(string url, ICalculatorDuplexClientCallback callback)
        {
#if(NETSTANDARD2_1)
            var channel = GrpcChannel.ForAddress(url);
            _client = new Protos.CalculatorDuplex.CalculatorDuplexClient(channel);
#else
            var uri = new Uri(url);
            var channel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
            _client = new Protos.CalculatorDuplex.CalculatorDuplexClient(channel);
            
#endif
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }
        
        public async Task ClearAsync()
        {
            EnsureStarted();
            var action = new Protos.CalculatorDuplexAction.Types.Clear();
            var message = new Protos.CalculatorDuplexAction
            {
                Clear = action,
            };
            await _streamHandler.WriteAsync(message);
        }

        [Obsolete("Use ClearAsync")]
        public void Clear()
        {
            ClearAsync().GetAwaiter().GetResult();
        }
        
        public async Task AddToAsync(double value)
        {
            EnsureStarted();
            var action = new Protos.CalculatorDuplexAction.Types.AddTo
            {
                Value = value,
            };
            var message = new Protos.CalculatorDuplexAction
            {
                AddTo = action,
            };
            await _streamHandler.WriteAsync(message);
        }

        [Obsolete("Use AddToAsync")]
        public void AddTo(double value)
        {
            AddToAsync(value).GetAwaiter().GetResult();
        }
        
        public async Task SubtractFromAsync(double value)
        {
            EnsureStarted();
            var action = new Protos.CalculatorDuplexAction.Types.SubtractFrom
            {
                Value = value,
            };
            var message = new Protos.CalculatorDuplexAction
            {
                SubtractFrom = action,
            };
            await _streamHandler.WriteAsync(message);
        }

        [Obsolete("Use SubtractFromAsync")]
        public void SubtractFrom(double value)
        {
            SubtractFromAsync(value).GetAwaiter().GetResult();
        }
        
        public async Task MultiplyByAsync(double value)
        {
            EnsureStarted();
            var action = new Protos.CalculatorDuplexAction.Types.MultiplyBy
            {
                Value = value,
            };
            var message = new Protos.CalculatorDuplexAction
            {
                MultiplyBy = action,
            };
            await _streamHandler.WriteAsync(message);
        }

        [Obsolete("Use MultiplyByAsync")]
        public void MultiplyBy(double value)
        {
            MultiplyByAsync(value).GetAwaiter().GetResult();
        }
        
        public async Task DivideByAsync(double value)
        {
            EnsureStarted();
            var action = new Protos.CalculatorDuplexAction.Types.DivideBy
            {
                Value = value,
            };
            var message = new Protos.CalculatorDuplexAction
            {
                DivideBy = action,
            };
            await _streamHandler.WriteAsync(message);
        }

        [Obsolete("Use DivideByAsync")]
        public void DivideBy(double value)
        {
            DivideByAsync(value).GetAwaiter().GetResult();
        }
        
        private void EnsureStarted()
        {
            lock (_sync)
            {
                if (_streamHandler is null)
                {
                    var stream = _client.Start();
                    _streamHandler = new CalculatorDuplexCallbackStreamHandler(_callback, stream.RequestStream, stream.ResponseStream);
                    _streamHandlerTask = _streamHandler.RunAsync(_cancellationTokenSource.Token);
                }
            }
        }

        public void Dispose()
        {
            _streamHandler?.Dispose();
            _cancellationTokenSource.Cancel();
        }
    }
}

