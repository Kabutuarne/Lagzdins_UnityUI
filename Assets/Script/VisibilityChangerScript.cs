using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VisibilityChangerScript : MonoBehaviour
{   
    public Image LeggingsImg, ChestplateImg;
    public void setLeggingsVisibility(bool value){
            Color color = LeggingsImg.color;
            if(value)
            color.a = 1f;
            else
            color.a = 0f;
            LeggingsImg.color = color;
    }
    public void setChestplateVisibility(bool value){
            Color color = ChestplateImg.color;
            if(value)
            color.a = 1f;
            else
            color.a = 0f;
            ChestplateImg.color = color;
    }
}
