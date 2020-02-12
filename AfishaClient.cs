using AfishaParser.Connecter;
using AfishaParser.models;

namespace AfishaParser
{
    public class AfishaClient
    {
        public AfishaClient()
        {
            
        }

        public string GetSource(string url, DataParam data)
        {
            var source = Connecter.Connecter.PostSource(url, data);
            return source;
        }

        public FilmObject[] GetFilms(string source)
        {
            return JsonParser.JsonParser.GetFilmsSource(source);
        }

        public void SaveSourceToJson(string path, FilmObject[] filmsArray)
        {
            JsonParser.JsonParser.SaveToJson(path, filmsArray);
        }
    }
}