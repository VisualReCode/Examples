//
// This code was generated by Visual ReCode 1.0.0.0
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
#if(NETSTANDARD2_1)
using Grpc.Net.Client;
#endif

namespace BasicCalculatorCore.Client
{
    public partial class CalculatorClient : ICalculatorClient, IDisposable
    {
        private readonly BasicCalculatorCore.Client.Protos.Calculator.CalculatorClient _client;
        
        public CalculatorClient(BasicCalculatorCore.Client.Protos.Calculator.CalculatorClient client)
        {
            _client = client;
        }
        
#if(NETSTANDARD2_1)
        private readonly GrpcChannel _channel;

        public CalculatorClient(string url)
        {
            _channel = GrpcChannel.ForAddress(url);
            _client = new BasicCalculatorCore.Client.Protos.Calculator.CalculatorClient(_channel);
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
#else
        private readonly Channel _channel;

        public CalculatorClient(string url)
        {
            var uri = new Uri(url);
            _channel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
            _client = new BasicCalculatorCore.Client.Protos.Calculator.CalculatorClient(_channel);
        }

        public void Dispose()
        {
            if (_channel is null) return;
            try
            {
                _channel.ShutdownAsync().GetAwaiter().GetResult();
            }
            catch
            {
                // Ignored
            }
        }
#endif

        public async Task<double> AddAsync(double value1, double value2)
        {
            var request = new Protos.AddRequest
            {
                Value1 = value1,
                Value2 = value2,
            };
            var response = await _client.AddAsync(request);
            var returnValue = response.Value;
            return returnValue;
        }

        [Obsolete("Use AddAsync")]
        public double Add(double value1, double value2)
        {
            return AddAsync(value1, value2).GetAwaiter().GetResult();
        }
        
        public async Task<double> SubtractAsync(double value1, double value2)
        {
            var request = new Protos.SubtractRequest
            {
                Value1 = value1,
                Value2 = value2,
            };
            var response = await _client.SubtractAsync(request);
            var returnValue = response.Value;
            return returnValue;
        }

        [Obsolete("Use SubtractAsync")]
        public double Subtract(double value1, double value2)
        {
            return SubtractAsync(value1, value2).GetAwaiter().GetResult();
        }
        
        public async Task<double> MultiplyAsync(double value1, double value2)
        {
            var request = new Protos.MultiplyRequest
            {
                Value1 = value1,
                Value2 = value2,
            };
            var response = await _client.MultiplyAsync(request);
            var returnValue = response.Value;
            return returnValue;
        }

        [Obsolete("Use MultiplyAsync")]
        public double Multiply(double value1, double value2)
        {
            return MultiplyAsync(value1, value2).GetAwaiter().GetResult();
        }
        
        public async Task<double> DivideAsync(double value1, double value2)
        {
            var request = new Protos.DivideRequest
            {
                Value1 = value1,
                Value2 = value2,
            };
            var response = await _client.DivideAsync(request);
            var returnValue = response.Value;
            return returnValue;
        }

        [Obsolete("Use DivideAsync")]
        public double Divide(double value1, double value2)
        {
            return DivideAsync(value1, value2).GetAwaiter().GetResult();
        }
        
    }
}

