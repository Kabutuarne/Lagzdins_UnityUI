using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GeneralScripts : MonoBehaviour
{
    public GameObject CharacterImg;

    public void addSize(){
    Vector3 currentScale = CharacterImg.transform.localScale;
    if(currentScale.x<9){
    float newSizeX = currentScale.x + 0.4f;
    float newSizeY = currentScale.y + 0.4f;
    CharacterImg.transform.localScale = new Vector3(newSizeX, newSizeY, currentScale.z);
    }   
        }
    public void subtractSize(){
    Vector3 currentScale = CharacterImg.transform.localScale;
    if(currentScale.x>5){
    float newSizeX = currentScale.x - 0.4f;
    float newSizeY = currentScale.y - 0.4f;
    CharacterImg.transform.localScale = new Vector3(newSizeX, newSizeY, currentScale.z);
    } 
    }

}
