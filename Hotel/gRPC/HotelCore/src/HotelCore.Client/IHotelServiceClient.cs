using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCore.Client
{
    public interface IHotelServiceClient
    {
        [Obsolete("Use GetAvailableRoomsAsync")]
        IList<Room> GetAvailableRooms(DateTimeOffset checkInDate, DateTimeOffset checkOutDate);

        Task<IList<Room>> GetAvailableRoomsAsync(DateTimeOffset checkInDate, DateTimeOffset checkOutDate);

        [Obsolete("Use GetRoomAsync")]
        Room GetRoom(int number);

        Task<Room> GetRoomAsync(int number);

        [Obsolete("Use GetRoomsAsync")]
        Room[] GetRooms(int[] numbers);

        Task<Room[]> GetRoomsAsync(int[] numbers);

#if(NETSTANDARD2_1)
        IAsyncEnumerable<Room> AllRooms();
#else
        [Obsolete("Use AllRoomsAsync")]
        IEnumerable<Room> AllRooms();

        Task<IEnumerable<Room>> AllRoomsAsync();
#endif
    }
}

