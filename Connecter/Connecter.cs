using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using AfishaParser.models;

namespace AfishaParser.Connecter
{
    public static class Connecter
    {
        

        private static WebRequest ConnectRequest(string url, string contentType = "", string method = "")
        {
            WebRequest request = WebRequest.Create(url);
            if(contentType != "" && contentType != " ")
            {
                request.ContentType = contentType;
            }
            if(method != "" && method != " ")
            {
                request.Method = method;
            }

            return request;
        }

        private static string WebResponseSource(WebRequest request)
        {
            string source = "";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using(Stream rStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(rStream, Encoding.UTF8);
                source = reader.ReadToEnd().ToString();
            }

            return source;
        }

        public static string PostSource(string url, DataParam dataParams)
        {
            var date = ConverterUnixTime.ConvertToUnixTime(dataParams.Date);
            var city = dataParams.CityId;
            var cinema = dataParams.CinemaId;
            var offset = dataParams.Offset;
            var limit = dataParams.Limit;
            var sort = dataParams.Sort;
            string data = $"date={date}&city={city}&kinoteatr={cinema}&offset={offset}&limit={limit}&sort={sort}";
            WebRequest request = ConnectRequest(url, "application/x-www-form-urlencoded", "POST");

            using(var sWrite = new StreamWriter(request.GetRequestStream()))
            {
                sWrite.Write(data);
            }

            var source = WebResponseSource(request);

            return source;
        }

    }
}