using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest";
            var ronSwansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            /*we send a GET request to the specified Uri and return the response
             * body as a string in an asynchronous operation.Basically, we get a string of JSON back*/

            /* Then we can parse through our JSON response and grab the values we are interested in.
             * In this case, we grab the VALUE associated with the “quote” NAME.  
             * Remember, JSON uses a NAME : VALUE pairing system. */


            for(int i = 0; i < 5; i++)
            {
            var kanyeResponse= client.GetStringAsync(kanyeURL).Result;
            var swansonResponse = client.GetStringAsync(ronSwansonURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            var swansonQuote = JArray.Parse(swansonResponse).ToString().Replace("[", "").Replace("]", "").Replace('\"' , ' ').Trim();
            Console.WriteLine($"\nKanye: {kanyeQuote} ");
            Console.WriteLine($"\nRon: {swansonQuote} ");
            }
        }
    }
}