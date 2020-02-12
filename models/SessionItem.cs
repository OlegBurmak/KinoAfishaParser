namespace AfishaParser.models
{
    public class SessionItem
    {
        public string k_name;
        public string k_addr;
        public string k_url;
        public string h_name;
        public string sessions;

        public string GetUrl 
        { 
            get
            {
                return $"https://kinoafisha.ua{k_url}";
            }
        }
    }
}