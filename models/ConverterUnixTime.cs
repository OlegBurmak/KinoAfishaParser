using System;

namespace AfishaParser.models
{
    public static class ConverterUnixTime
    {

        private static readonly DateTime UnixTime = new DateTime(1970, 1, 1);
        
        public static int ConvertToUnixTime(DateTime date)
        {
            if(date.GetType() == new DateTime().GetType())
            {
                return (int)(date - UnixTime).TotalSeconds;
            }
            else
            {
                return (int)(DateTime.UtcNow - UnixTime).TotalSeconds;
            }
            
        }

    }
}