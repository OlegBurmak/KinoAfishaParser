using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
                //TODO show Exception
                return null;
            }
        }

        private static double RegexParseDouble(string parseNumber)
        {
            Regex regex = new Regex(@"(\d*,\d*).*?");
            double number = 0.0;
            try
            {
                Match match = regex.Match(parseNumber);
                string result = match.Groups[1].ToString();
                regex = new Regex(",");
                result = regex.Replace(result, ".");
                number = double.Parse(result);
            }
            catch (System.Exception)
            {
               //TODO show Exception
            }
            return number;
        }

        private static SessionObject[] GetSessions(SessionItem[] sessionItems)
        {
            List<SessionObject> sessionsList = new List<SessionObject>();
            foreach(var item in sessionItems)
            {
                try
                {
                    sessionsList.Add(new SessionObject()
                    {
                        CinemaName = item.k_name,
                        CinemaAddres = item.k_addr,
                        CinemaUrl = item.GetUrl,
                        HallName = item.h_name,
                        Session = HtmlLogic.GetText(item.sessions)
                    });
                }
                catch (System.Exception)
                {
                    continue;
                }
            }
            return sessionsList.ToArray();
        }
        public static FilmObject[] GetFilmsSource(string source)
        {
            List<FilmObject> filmsList = new List<FilmObject>();
            var films = ParseFilmSource(source);
            foreach(var item in films)
            {
                try
                {
                    filmsList.Add(new FilmObject()
                    {
                        Id = item.id,
                        Name = item.name,
                        Url = item.GetUrl,
                        ImageUrl = item.GetImage,
                        Vote = RegexParseDouble(item.vote),
                        VoteCount = item.count_vote,
                        ImdbVote = RegexParseDouble(item.imdb),
                        Countries = item.countries,
                        Actors = HtmlLogic.GetText(item.actors),
                        Producer = HtmlLogic.GetText(item.rejisser),
                        EnteredUA = item.entered_ua,
                        Sessions = GetSessions(item.sessions),
                        AgeLimit = item.age_limit
                    });
                }
                catch (System.Exception)
                {
                    continue;
                }
            }
            return filmsList.ToArray();
        }

        public static void SaveToJson(string path, FilmObject[] filmsArray)
        {
            try
            {
                string resultJson = JsonConvert.SerializeObject(filmsArray);
                File.AppendAllText(path, resultJson);
            }
            catch (System.Exception)
            {
                //TODO show Exception
            }
            
        }

        //TODO create DataBase save method
    }
}