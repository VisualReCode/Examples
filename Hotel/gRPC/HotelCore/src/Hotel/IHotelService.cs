using System;
using System.Collections.Generic;
using Hotel.Data;

namespace Hotel
{
    /* Recoded [ServiceContract] */
    public interface IHotelService
    {
        /* Recoded [OperationContract] */
        IList<Room> GetAvailableRooms(DateTimeOffset checkInDate, DateTimeOffset checkOutDate);

        /* Recoded [OperationContract] */
        Room GetRoom(int number);

        /* Recoded [OperationContract] */
        Room[] GetRooms(int[] numbers);

        /* Recoded [OperationContract] */
        IEnumerable<Room> AllRooms();
    }
}

