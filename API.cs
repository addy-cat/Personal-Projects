using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class API : MonoBehaviour
{
    private const string URL = "www.google.ca";
    public Text responseText;

    public void Request()
    {
        //create a request for data
        UnityWebRequest request = UnityWebRequest.Get(URL);
       
        //send in your request, we can now wait until this is called
        StartCoroutine(OnResponse(request));
    }

    //we need to create time to get the data, (Unity documentation)
    private IEnumerator OnResponse(UnityWebRequest req)
    {
        yield return req;

        responseText.text = req.downloadHandler.text;

    }
}
