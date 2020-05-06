using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HotelService.HotelServiceClient("");
            client.GetAvailableRooms(DateTimeOffset.Now.AddDays(1), DateTimeOffset.Now.AddDays(7));
        }
    }
}
