using AfishaParser.HtmlParser;
using AfishaParser.models;
using Newtonsoft.Json;

namespace AfishaParser.JsonParser
{
    public static class JsonParser
    {
        
        private static FilmItem[] ParseFilmSource(string source)
        {
            try
            {
                CinemaFilms filmsSource = JsonConvert.DeserializeObject<CinemaFilms>(source);
                return filmsSource.result;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public static void GetSource(string source)
        {
            var films = ParseFilmSource(source);
            if(films != null)
            {
                foreach(var item in films)
                {
                    System.Console.WriteLine(item.name + " - " + item.vote + " - " + item.imdb);
                    System.Console.WriteLine(item.countries);
                    System.Console.WriteLine(item.entered_ua);
                    System.Console.WriteLine(item.GetUrl);
                    System.Console.WriteLine(HtmlLogic.GetText(item.rejisser));
                    System.Console.WriteLine(item.url);
                    System.Console.WriteLine(HtmlLogic.GetText(item.actors));
                    System.Console.WriteLine("***********************");
                }
            }
            else
            {
                System.Console.WriteLine("Continue");
            }
            
        }
    }
}