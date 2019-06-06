using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MovieAPIProject.Models
{
    public class MovieDAL
    {
        private static readonly string APIKey = GetAPIKey();
        public static JObject GetMovieAPI()
        {
            
            HttpWebRequest request = WebRequest.CreateHttp($"http://www.omdbapi.com/?apikey={APIKey}&s=good");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());

                JObject movieData = JObject.Parse(data.ReadToEnd());
                return movieData;
            }
            return null;
        }

        private static string GetAPIKey()
        {
            string APIKey;
            string fileName = @"APIKey.txt";
            string binaryPath = AppDomain.CurrentDomain.BaseDirectory + fileName;

            StreamReader myFile = new StreamReader(binaryPath);

            try
            {
                APIKey = myFile.ReadToEnd();
            }
            finally
            {
                myFile.Close();
            }

            return APIKey;
        }
    }
}