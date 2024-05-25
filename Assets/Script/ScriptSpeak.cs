using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptSpeak : MonoBehaviour
{
    public GameObject displayField;
    public GameObject inputField;
    public GameObject inputField2;


    public void sayMyName()
    {
        //int age = displayField.GetComponent<Text>().text;
        string text = ""+inputField.GetComponent<Text>().text;
        string showText="";
        int age = -696969;
        if(inputField2.GetComponent<Text>().text!="")
            age = 2024-int.Parse(inputField2.GetComponent<Text>().text);
        if(text!="")
            showText+="I am "+text+" ";
        if(age!=-696969)
            showText+="and i'm "+age+" years old";
        displayField.GetComponent<Text>().text = showText;
                            
    }
}
