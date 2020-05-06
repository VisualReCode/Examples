using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace HotelCore.Client.Protos
{
    public partial class Room
    {
        public static implicit operator Room(global::HotelCore.Client.Room src)
        {
            var value = new Room {
                Number = src.Number,
                Floor = src.Floor,
                Name = src.Name,
                Price = src.Price,
            };
            return value;
        }


        public static implicit operator global::HotelCore.Client.Room(Room src)
        {
            var value = new global::HotelCore.Client.Room {
                Number = src.Number,
                Floor = src.Floor,
                Name = src.Name,
                Price = src.Price,
            };
            return value;
        }

    }
}

