using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace tgbot
{
    public class Forismatic
    {

        public class Quote
        {
            public string quoteText { get; set; }
            public string quoteAuthor { get; set; }
        }

        private RestClient RC = new RestClient();
        private const string URL = "https://api.forismatic.com/api/1.0/?method=getQuote&format=json&lang=ru";
        public Forismatic()
        {

        }
        public string getRandom()
        {
            var Request = new RestRequest(URL);
            var Response = RC.Get(Request);
            var json = Response.Content;

            var quote = JsonConvert.DeserializeObject<Quote>(json);

            if(quote.quoteAuthor.Length > 0)
            {
                return $" {quote.quoteAuthor} однажды сказал:{quote.quoteText}";

            }
            else
            {
                return quote.quoteText;
            }
        }


    }
}
