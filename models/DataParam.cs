using System;

namespace AfishaParser.models
{
    public class DataParam
    {
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        public int CityId { get; set; } = 1;
        public int CinemaId { get; set; } = 0;
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 9999;
        public string Sort { get; set; } = "date";
    }
}