using AfishaParser.Connecter;
using AfishaParser.models;
using AfishaParser.JsonParser;

namespace AfishaParser
{
    public class AfishaClient
    {
        public AfishaClient()
        {
            
        }

        public string GetSource(string url, DataParam data)
        {
            var r = Connecter.Connecter.PostSource(url, data);
            return r;
        }

        public void GetJsonSource(string source)
        {
            JsonParser.JsonParser.GetSource(source);
        }
    }
}