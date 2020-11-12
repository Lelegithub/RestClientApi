using System.Collections;
using RestClient.Core.Models;
using RestClient.Core.Singletons;
using UnityEngine;
using UnityEngine.Networking;
 
namespace RestClient.Core
{
    public class RestWebClient : Singleton<RestWebClient>
    {
        private const string defaultContentType = "application/json";
        public IEnumerator HttpGet(string url, System.Action<Response> callback)
        {
            using(UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();
                
                if(webRequest.result== UnityWebRequest.Result.ConnectionError){
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        Error = webRequest.error,
                    });
                }
                
                if(webRequest.isDone)
                {
                    string data = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                    Debug.Log("Data: " + data);
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        Error = webRequest.error,
                        Data = data
                    });
                }
            }
        }

         
        
    }
}