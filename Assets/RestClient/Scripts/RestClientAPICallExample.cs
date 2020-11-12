using RestClient.Core;
using RestClient.Core.Models;
using UnityEngine;

public class RestClientAPICallExample : MonoBehaviour
{
    [SerializeField]
    private string baseUrl = "https://localhost:8000";

    void Start()
    {
        // send a get request
        StartCoroutine(RestWebClient.Instance.HttpGet($"{baseUrl}", (r) => OnRequestComplete(r)));

        // setup the request header
         RequestHeader header = new RequestHeader {
            Key = "Content-Type",
            Value = "application/json"
        };

      
    }

    void OnRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
    }

    public class Player
    {
        public string FullName;
    }
}
