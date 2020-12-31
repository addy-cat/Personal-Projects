using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class Test : MonoBehaviour
{

    //these two components make up a velocity vector
    public Transform canvas;
    public Text T1;
    public Text T2;

    // Start is called before the first frame update
    void Start()
    {
        Text tempT1 = Instantiate(T1);
        tempT1.transform.SetParent(canvas, false);
        Text tempT2 = Instantiate(T2);
        tempT2.transform.SetParent(canvas, false);
        tempT1.transform.position += new Vector3(0.0f, -40.0f, 0.0f);
        tempT2.transform.position += new Vector3(0.0f, -40.0f, 0.0f);
       

    }

    public IEnumerator GetRequest(string uri, Text getWindspeed, Text getDirection)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            //rawData is the block of information from the website, it isnt parsed 
            string rawData;

            string windSpeedUnparsed = "";
            string windSpeedParsed = string.Empty;

            string windDirectionCardinal = "";
        

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            //the rawData is the block of text on the website the API brings in
            rawData = webRequest.downloadHandler.text;

            //IN THE API, THE LINE IN QUESTION APPEARS LIKE THIS:
            //"windSpeed": "15 to 25 mph",

            //IndexOf finds the first usage of "windSpeed" on the website (above), this returns the first quotation mark seen below.
            //When we are at that first quotation mark, we need to go ahead 13 spaces to get to the numerical data
            //13 characters after that quotation mark.
            int speedIndex = rawData.IndexOf("windSpeed") + 13;

            //IndexOf finds the first usage of "windDirection" on the website (above), this returns the first quotation mark seen below.
            //When we are at that first quotation mark, we need to go ahead 19 spaces to get to the numerical data
            //19 characters after that quotation mark.
            int directionIndex = rawData.IndexOf("windDirection") + 17;

            //while we are right at the 'mph' of the wind speed
            while (rawData[speedIndex] != '"')
            {
                //grab all of the windspeed data
                windSpeedUnparsed += rawData[speedIndex];
                speedIndex++;
            }

            getWindspeed.text = windSpeedUnparsed;


            if (windSpeedUnparsed.Length > 6)
            {
                //we have something that looks like either "15 mph" or 
                //"10 to 15 mph", regardless we need to cleanse this for
                //the numbers only
                //for (int i = 0; i < windSpeedUnparsed.Length; i++)
                // {


                int index = 0;

                while (index < windSpeedUnparsed.Length && char.IsDigit(windSpeedUnparsed[index]))
                {

                    windSpeedParsed += windSpeedUnparsed[index];
                    index++;
                }

                double wind1 = double.Parse(windSpeedParsed);
                //print(wind1);
                windSpeedParsed = string.Empty;



                while (index < windSpeedUnparsed.Length)
                {
                    if (char.IsDigit(windSpeedUnparsed[index]))
                    {
                        windSpeedParsed += windSpeedUnparsed[index];
                    }

                    index++;
                }

                double wind2 = double.Parse(windSpeedParsed);
                //print(wind2);

                double windSpeed = (wind1 + wind2) / 2.0;
                print(windSpeed);
                getWindspeed.text = "speed: " + windSpeed.ToString();

            } else
            {
                int index = 0;

                while (index < windSpeedUnparsed.Length && char.IsDigit(windSpeedUnparsed[index]))
                {

                    windSpeedParsed += windSpeedUnparsed[index];
                    index++;
                }

                int windSpeed = int.Parse(windSpeedParsed);
                print(windSpeed);
                getWindspeed.text = "speed: " + windSpeed.ToString();
                // windSpeedParsed = string.Empty;

            }



            int windDirection = 0; 

            //while we are right at the end of the wind direction
            while (rawData[directionIndex] != '"')
            {
                //grab all of the windspeed data
                windDirectionCardinal += rawData[directionIndex];
                directionIndex++;
            }

            
                if (windDirectionCardinal == "N")
                {
                    windDirection = 90;
                }
                else if (windDirectionCardinal == "NE")
                {
                    windDirection = 45;
                }
                else if (windDirectionCardinal == "E")
                {
                    windDirection = 0;
                }
                else if (windDirectionCardinal == "SE")
                {
                    windDirection = 315;
                }
                else if (windDirectionCardinal == "S")
                {
                    windDirection = 270;
                }
                else if (windDirectionCardinal == "SW")
                {
                    windDirection = 225;
                }
                else if (windDirectionCardinal == "W")
                {
                    windDirection = 180;
                }
                else if (windDirectionCardinal == "NW")
                {
                    windDirection = 135;
                }


            print(windDirection);
            getDirection.text = "direction: " + windDirection.ToString();
            
            
         
        }

        //StopAllCoroutines();
    }



    

}
