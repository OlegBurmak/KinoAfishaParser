namespace AfishaParser.models
{
    public class FilmItem
    {
        public int id;
        public string name;
        public string url;
        public string image;
        public string vote;
        public string count_vote;
        public string imdb;
        public string countries;
        public string actors;
        public string rejisser;
        public string entered_ua;
        public SessionItem[] sessions;
        public string age_limit;

        public string GetImage
        {
            get
            {
                return $"https://kinoafisha.ua{image}";
            }
        }
        public string GetUrl 
        { 
            get
            {
                return $"https://kinoafisha.ua{url}";
            }
        }
    }
}