namespace AfishaParser.models
{
    public class FilmObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public double Vote { get; set; }
        public string VoteCount { get; set; }
        public double ImdbVote { get; set; }
        public string Countries { get; set; }
        public string Actors { get; set; }
        public string Producer { get; set; }
        public string EnteredUA { get; set; }
        public SessionObject[] Sessions { get; set; }
        public string AgeLimit { get; set; }
    }
}