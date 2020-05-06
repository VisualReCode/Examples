using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace HotelCore.Protos
{
    public partial class Room
    {
        public static implicit operator Room(global::Hotel.Data.Room src)
        {
            var value = new Room {
                Number = src.Number,
                Floor = src.Floor,
                Name = src.Name,
                Price = src.Price,
            };
            return value;
        }


        public static implicit operator global::Hotel.Data.Room(Room src)
        {
            var value = new global::Hotel.Data.Room {
                Number = src.Number,
                Floor = src.Floor,
                Name = src.Name,
                Price = src.Price,
            };
            return value;
        }

    }
}

