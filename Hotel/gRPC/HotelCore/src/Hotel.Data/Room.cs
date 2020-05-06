using System.Runtime.Serialization;

namespace Hotel.Data
{
    /* Recoded [DataContract] */
    public class Room
    {
        /* Recoded [DataMember] */
        public int Number { get; set; }

        /* Recoded [DataMember] */
        public int Floor { get; set; }

        /* Recoded [DataMember] */
        public string Name { get; set; }

        /* Recoded [DataMember] */
        public decimal Price { get; set; }
    }
}

