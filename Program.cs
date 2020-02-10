using System;
using System.IO;
using AfishaParser.models;

namespace AfishaParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new AfishaClient();
            var source = client.GetSource("https://kinoafisha.ua/ajax/kinoafisha_load", new DataParam()
            {
                Date = DateTime.Now.Date,
                CityId = 1,
                CinemaId = 134,
                Offset = 0,
                Limit = 9999,
                Sort = "rate"
            });
            client.GetJsonSource(source);
        }
    }
}
