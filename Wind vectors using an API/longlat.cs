using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class longlat : MonoBehaviour
{

    //these two components make up a velocity vector
    public Transform canvas;
    public Text ForecastURL;
    public Text T1;
    public Text T2;
    public Test APIHandler;
    

    // Start is called before the first frame update
    void Start()
    {
        linkedList list = new linkedList();
        windInfo the_info = new windInfo(4.0, 6.0);
        windInfo the_info2 = new windInfo(2.0, 3.0);

        list.add_windData(the_info);
        list.add_windData(the_info2);

        list.display_info();

        Text tempForecastURL = Instantiate(T1);

       // tempT1.transform.SetParent(canvas, false);
       // Text tempT2 = Instantiate(T2);
       // tempT2.transform.SetParent(canvas, false);
       // tempT1.transform.position += new Vector3(0.0f, -40.0f, 0.0f);
       // tempT2.transform.position += new Vector3(0.0f, -40.0f, 0.0f);
        

        StartCoroutine(GetRequest("https://api.weather.gov/points/45.7534,-121.9908", ForecastURL));
        //StartCoroutine(GetRequest("https://api.weather.gov/points/44.8869,-124.0258", tempT1, tempT2));
        //StartCoroutine(GetRequest("https://api.weather.gov/points/44.9287,-124.0386"));

    }

    IEnumerator GetRequest(string uri, Text getForecastURL)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            //rawData is the block of information from the website, it isnt parsed 
            string rawData;

            string forecastURL = "";

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            //the rawData is the block of text on the website the API brings in
            rawData = webRequest.downloadHandler.text;

            int index = rawData.IndexOf("forecast\"") + 12;
           
            while (rawData[index] != '"')
            {
                //grab all of the forecast URL
                forecastURL += rawData[index];
                index++;
            }

            getForecastURL.text = forecastURL;
            StartCoroutine(APIHandler.GetRequest(forecastURL, T1, T2));
        }

      
    }



}
