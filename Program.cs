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
                Date = DateTime.UtcNow,
                CityId = 1,
                CinemaId = 0,
                Offset = 0,
                Limit = 9999,
                Sort = "rate"
            });
            var films = client.GetFilms(source);
            client.SaveSourceToJson("result.json", films);
        }
    }
}
