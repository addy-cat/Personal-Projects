using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using org.mariuszgromada.math.mxparser;

public class add : MonoBehaviour
{
    string userinputupperx = "Upper x bound";
    string userinputlowerx = "Lower x bound";
    string userinputuppery = "Upper y bound";
    string userinputlowery = "Upper y bound";
    public Text upperxbound;
    public Text lowerxbound;
    public Text upperybound;
    public Text lowerybound;

    int index = 0;

    
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        upperxbound.text = userinputupperx;
        lowerxbound.text = userinputlowerx;
        upperybound.text = userinputuppery;
        lowerybound.text = userinputlowery;

    }
    /*
     * Argument x = new Argument("x");
        Argument y = new Argument("y");
        upperxexp = new Expression(userinputupperx, x, y);
        */

    public void getUpperX()
    {
        userinputupperx = input.text;
        PlayerPrefs.SetString("UserInputUpperX", userinputupperx);
    }

    public void getLowerX()
    {
        userinputlowerx = input.text;
        PlayerPrefs.SetString("UserInputLowerX", userinputlowerx);
    }
    public void getUpperY()
    {
        userinputuppery = input.text;
        PlayerPrefs.SetString("UserInputUpperY", userinputuppery);

    }
    public void getLowerY()
    {
        userinputlowery = input.text;
        PlayerPrefs.SetString("UserInputLowerY", userinputlowery);

    }

    public void handleInput()
    {
        if (index == 0)
        {
            getUpperX();
        } else if (index == 1)
        {
            getLowerX();
        }
        else if (index == 2)
        {
            getUpperY();
        }
        else if (index == 3)
        {
            getLowerY();
        }

        index++;
    }
}
