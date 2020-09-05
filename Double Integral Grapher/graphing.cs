using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using org.mariuszgromada.math.mxparser;

public class graphing : MonoBehaviour
{
    //for the dot
    public GameObject point;
    //for the unit
    public GameObject unit;

    public GameObject axis;

    public Text upperx;
    public Text lowerx;
    public Text uppery;
    public Text lowery;

    // Start is called before the first frame update
    void Start()
    {
        //i is x and j is y
        for (int i = -10; i < 100; i++)
        {
            for (int j = -50; j < 100; j++)
            {
                GameObject newUnit = Instantiate(unit);
                newUnit.transform.position = new Vector2(i, j);
                
                if (j == 0)
                {
                    GameObject newAxis = Instantiate(axis);
                    newAxis.transform.position = new Vector2(i, j);
                }

                if (i == 0)
                {
                    GameObject newAxis = Instantiate(axis, new Vector3(i, j, 0), Quaternion.AngleAxis(90, Vector3.forward));
                    
                }
            }
        }

        Argument x = new Argument("x");
        Argument y = new Argument("y");

        Expression lowerxbound = new Expression(PlayerPrefs.GetString("UserInputLowerX", "-1"), x, y);
        Expression upperxbound = new Expression(PlayerPrefs.GetString("UserInputUpperX", "-1"), x, y);
        Expression lowerybound = new Expression(PlayerPrefs.GetString("UserInputLowerY", "-1"), x, y);
        Expression upperybound = new Expression(PlayerPrefs.GetString("UserInputUpperY", "-1"), x, y);

        //divide the RGB colors by 255
        drawGraphInTermsOfY(lowerxbound, y, new Color(171f/255f, 235f/255f, 52f/255f, 1));
        drawGraphInTermsOfY(upperxbound, y, new Color(235f/255f, 52f/255f, 223f/255f, 1));
        drawGraphInTermsOfX(lowerybound, x, new Color(235f/255f, 189f/255f, 52f/255f, 1));
        drawGraphInTermsOfX(upperybound, x, new Color(143f/255f, 52f/255f, 235f/255f, 1));

        lowerx.text += PlayerPrefs.GetString("UserInputLowerX", "No lower x bound added");
        upperx.text += PlayerPrefs.GetString("UserInputUpperX", "No upper x bound added");
        lowery.text += PlayerPrefs.GetString("UserInputLowerY", "No lower y bound added");
        uppery.text += PlayerPrefs.GetString("UserInputUpperY", "No upper y bound added");
    }

    //for both x bounds
    void drawGraphInTermsOfX(Expression e, Argument y, Color colorline)
    {
        //make this 0 so in unity the step size is smaller than 1 or else there is weird spacing, in this
        //way points are closer together
        double currVar = 0;
        
        for (int i = 0; i < 1000; i++)
        {
            
            y.setArgumentValue(currVar);
            double currY = e.calculate();
            //make a copy of the point object
            GameObject newPoint = Instantiate(point);
            SpriteRenderer renderer = newPoint.GetComponent<SpriteRenderer>();
            renderer.color = colorline;

            if (Double.IsNaN(currY))
            {
                currY = 0;
            }
            //Unity has transform->position
            //The Vector's x and y is "i" because this is a linear function
            newPoint.transform.position = new Vector2((float)currVar, (float)currY);
            //step size:
            currVar += .1;
        }

    }

    //for both y bounds
    void drawGraphInTermsOfY(Expression e, Argument x, Color colorline)
    {
        //make this 0 so in unity the step size is smaller than 1 or else there is weird spacing, in this
        //way points are closer together
        double currVar = 0;

        for (int i = 0; i < 1000; i++)
        {
            x.setArgumentValue(currVar);
            
            double currX = e.calculate();
            //make a copy of the point object
            GameObject newPoint = Instantiate(point);

            SpriteRenderer renderer = newPoint.GetComponent<SpriteRenderer>();
            renderer.color = colorline;

            if (Double.IsNaN(currX))
            {
                currX = 0;
            }
            //Unity has transform->position
            //The Vector's x and y is "i" because this is a linear function
            newPoint.transform.position = new Vector2((float)currX, (float)currVar);
            //step size:
            currVar += .1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
