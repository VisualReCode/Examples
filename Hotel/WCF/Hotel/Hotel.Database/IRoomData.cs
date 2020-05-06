using System;
using System.Collections.Generic;
using Hotel.Data;

namespace Hotel.Database
{
    public interface IRoomData
    {
        IEnumerable<Room> GetAvailableRooms(DateTimeOffset checkInDate, DateTimeOffset checkOutDate);
        Room GetRoom(int number);
        Room[] GetRooms(int[] numbers);
        IEnumerable<Room> AllRooms();
    }
}
