using System;

namespace AfishaParser.models
{
    public class DataParam
    {
        public DateTime Date { get; set; }
        public int CityId { get; set; }
        public int CinemaId { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string Sort { get; set; }
    }
}