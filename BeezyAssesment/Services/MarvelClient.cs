using BeezyAssesment.Models;
using Refit;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeezyAssesment.Services
{
    public class MarvelClient
    {         
        private static MarvelClient instance = new MarvelClient();
        public static MarvelClient Instance => instance;

        //**** Prefer to use catched query data than going again to the source for data that we already got
        public ComicDataWrapper CatchedComicData;

        private IMarvelApi marvelService;
        private HttpClient httpClient;
        private string PUBLIC_API_KEY = "8cccc158a8dbe11c7d1dee9ae22bea4c";
        private string PRIVATE_API_KEY = "26dc4e6181fb29eaa21dc34ad6445d795159db08";
        private string API_URL = "http://gateway.marvel.com";
      
        public MarvelClient()
        {         
            //string ts = DateTime.Now.ToFileTime().ToString();
            string ts = Guid.NewGuid().ToString();
            string hash = GetMD5Hash($"{ts}{PRIVATE_API_KEY}{PUBLIC_API_KEY}");

            //with this message handler we can inject fixed parameters to every query automatically
            var httpMessageHandler = new QuerystringInjectingHttpMessageHandler(
                             ("apikey", PUBLIC_API_KEY),
                             ("hash", hash),
                             ("ts", ts),
                             ("limit", "20"),
                             ("orderBy", "modified"));


            httpClient = new HttpClient(httpMessageHandler)
            {
                BaseAddress = new Uri(API_URL)
            };

            marvelService = RestService.For<IMarvelApi>(httpClient);            

          
        }
        public async Task<ComicDataWrapper> GetComics()
        {
            var res = await marvelService.GetComics();

            if (res.IsSuccessStatusCode)
            {
                CatchedComicData = res.Content;
                return CatchedComicData;
            }
            else
                //handle error...
                return null;
        }

        public async Task<ComicDataWrapper> GetComicsByTitleStartsWith(string titleStartsWith)
        {
            var res = await marvelService.GetComicsByTitleStartsWith(titleStartsWith);

            if (res.IsSuccessStatusCode)
            {
                CatchedComicData = res.Content;
                return CatchedComicData;
            }
            else
                //handle error...
                return null;
        }
      

        //public async Task<ComicDataWrapper> GetComicById(string comicId)
        //{
        //    var res = await marvelService.GetComicById(comicId);

        //    if (res.IsSuccessStatusCode)
        //    {
        //        CatchedComicData = res.Content;
        //        return CatchedComicData;
        //    }
        //    //handle error...
        //    return null;
        //}
        private string GetMD5Hash(string text)
        {           
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
  
}
