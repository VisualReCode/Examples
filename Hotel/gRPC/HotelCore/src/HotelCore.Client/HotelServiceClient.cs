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

namespace HotelCore.Client
{
    public partial class HotelServiceClient : IHotelServiceClient, IDisposable
    {
        private readonly HotelCore.Client.Protos.HotelService.HotelServiceClient _client;
        
        public HotelServiceClient(HotelCore.Client.Protos.HotelService.HotelServiceClient client)
        {
            _client = client;
        }
        
#if(NETSTANDARD2_1)
        private readonly GrpcChannel _channel;

        public HotelServiceClient(string url)
        {
            _channel = GrpcChannel.ForAddress(url);
            _client = new HotelCore.Client.Protos.HotelService.HotelServiceClient(_channel);
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
#else
        private readonly Channel _channel;

        public HotelServiceClient(string url)
        {
            var uri = new Uri(url);
            _channel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
            _client = new HotelCore.Client.Protos.HotelService.HotelServiceClient(_channel);
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

        public async Task<IList<Room>> GetAvailableRoomsAsync(DateTimeOffset checkInDate, DateTimeOffset checkOutDate)
        {
            var request = new Protos.GetAvailableRoomsRequest
            {
                CheckInDate = Timestamp.FromDateTimeOffset(checkInDate),
                CheckOutDate = Timestamp.FromDateTimeOffset(checkOutDate),
            };
            var response = await _client.GetAvailableRoomsAsync(request);
            var returnValue = response.Values.Select(x => (global::HotelCore.Client.Room)x).ToList();
            return returnValue;
        }

        [Obsolete("Use GetAvailableRoomsAsync")]
        public IList<Room> GetAvailableRooms(DateTimeOffset checkInDate, DateTimeOffset checkOutDate)
        {
            return GetAvailableRoomsAsync(checkInDate, checkOutDate).GetAwaiter().GetResult();
        }
        
        public async Task<Room> GetRoomAsync(int number)
        {
            var request = new Protos.GetRoomRequest
            {
                Number = number,
            };
            var response = await _client.GetRoomAsync(request);
            var returnValue = (global::HotelCore.Client.Room)response.Value;
            return returnValue;
        }

        [Obsolete("Use GetRoomAsync")]
        public Room GetRoom(int number)
        {
            return GetRoomAsync(number).GetAwaiter().GetResult();
        }
        
        public async Task<Room[]> GetRoomsAsync(int[] numbers)
        {
            var request = new Protos.GetRoomsRequest();
            request.Numbers.AddRange(numbers);
            var response = await _client.GetRoomsAsync(request);
            var returnValue = response.Values.Select(x => (global::HotelCore.Client.Room)x).ToArray();
            return returnValue;
        }

        [Obsolete("Use GetRoomsAsync")]
        public Room[] GetRooms(int[] numbers)
        {
            return GetRoomsAsync(numbers).GetAwaiter().GetResult();
        }
        
#if(NETSTANDARD2_1)
        public async IAsyncEnumerable<Room> AllRooms()
        {
            var request = new Protos.AllRoomsRequest();
            var streamingCall = _client.AllRooms(request);
            await foreach (var response in streamingCall.ResponseStream.ReadAllAsync())
            {
                var returnValue = (global::HotelCore.Client.Room)response.Value;
                yield return returnValue;
            }
        }
#else
        public IEnumerable<Room> AllRooms() =>
            AllRoomsAsync().GetAwaiter().GetResult();

        public async Task<IEnumerable<Room>> AllRoomsAsync()
        {
            var request = new Protos.AllRoomsRequest();
            var streamingCall = _client.AllRooms(request);
            
            var list = new List<Room>();
            while (await streamingCall.ResponseStream.MoveNext())
            {
                var response = streamingCall.ResponseStream.Current;
                var returnValue = (global::HotelCore.Client.Room)response.Value;
                list.Add(returnValue);
            }
            return list;
        }
#endif
        
    }
}

