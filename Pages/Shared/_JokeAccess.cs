using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

using System.IO;
using System.Net;
using System.Text;

namespace JokeAccess
{
    class SingleJoke {
        public string id {get; set;}
        public string joke {get; set;}
        public int status {get; set;}
    }
    class Joke {
        public string id {get; set;}
        public string joke {get; set;}
    }
    class SearchResult {
        public int current_page {get; set;}
        public int limit {get; set;}
        public int total_pages {get; set;}
        public int next_page {get; set;}
        public int previous_page {get; set;}
        public string search_term {get; set;}
        public int status {get; set;}
        public int total_jokes {get; set;}
        public List<Joke> results {get; set;}
    }
    class WebStuff
    {
        // this section was basically pulled from a side project to work out getting the information i
        //      needed from icanhazdadjoke.com
        /*public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // I want to test out the getting of the dad jokes and the searching of dad jokes
            // as part of this testing I want to get the data laid out also...
            Random();
            Search("sell");
            Search("how");
        }*/

        private static string getWebRequest(string url) {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // non-JSON stuff was not working well...
            request.Headers.Set("Accept", "application/json");
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            //Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
        public static string RandomJoke() {
            string result = getWebRequest("https://icanhazdadjoke.com/");
            //Console.WriteLine(result);
            // get this string into a JSON object
            SingleJoke obj = JsonSerializer.Deserialize<SingleJoke>(result);
            //Console.WriteLine($"The joke: {obj.joke}");
            return obj.joke;
        }

        public static List<string> SearchJoke(string term) {
            string result = getWebRequest("https://icanhazdadjoke.com/search?limit=30&term=" + term);
            List<string> ret = new List<string>();
            //Console.WriteLine(result);
            SearchResult obj = JsonSerializer.Deserialize<SearchResult>(result);

            //Console.WriteLine($"Found {obj.total_jokes} jokes ({obj.results.Count})");
            obj.results.Sort(delegate(Joke x, Joke y) {
                return x.joke.Split(' ').Length.CompareTo(y.joke.Split(' ').Length);
            });
            foreach (var jk in obj.results)
            {
                //Console.WriteLine($"  {jk.joke} ({jk.joke.Split(' ').Length})");
                ret.Add(jk.joke);
            }
            return ret;
        }
    }
}
