using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, 
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject Hair,Head,Eye,EyeWhites,Shirt,Undershirt,Hands,Pants,Shoes;
    public Toggle ToggleButton;
    private RectTransform rTransform;
    public Canvas canv;
    private Sprite dragHair,dragHead,standHead, standHair, standEye, dragEye, standEyeWhites, dragEyeWhites, standShirt,
    dragShirt,standUndershirt,dragUndershirt,dragHands,standHands,dragPants,standPants,standShoes,dragShoes;
    private RunningScript runningScript;
    private RunningScriptHair runningScriptHair;
    private int selectedHairI=1;
    public int SelectedHairI{
        set{selectedHairI=value;}
        get{return selectedHairI;}
    }
    public GameObject OtherScriptHolder;


    public float minX, maxX, minY, maxY;
    public GameObject hairChoiceLeft,hairChoiceMiddle,hairChoiceRight; 
    public Sprite disabledButton;


    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        //changeHair(0);

        //Standing Sprites:
        standHair = standSprite2("Hair","Hair_"+selectedHairI);
        standEye = standSprite("Eyes");
        standEyeWhites = standSprite("Eye_Whites");
        standShirt = standSprite("Shirt");
        standUndershirt = standSprite("Undershirt");
        standHands = standSprite("Hands");
        standPants = standSprite("Pants");
        standShoes = standSprite("Shoes");
        standHead = standSprite("Head");

        //Dragging Sprites:
        dragHair = dragSprite2("Hair","Hair_"+selectedHairI);
        dragEye = dragSprite("Eyes");
        dragEyeWhites = dragSprite("Eye_Whites");
        dragShirt = dragSprite("Shirt");
        dragUndershirt = dragSprite("Undershirt");
        dragHands = dragSprite("Hands");
        dragPants = dragSprite("Pants");
        dragShoes = dragSprite("Shoes");
        dragHead = dragSprite("Head");
        enableAnimation(false);
    }

    public void OnPointerDown(PointerEventData data)
    {
        updateHair();
        //Debug.Log("Izdarīts klikšis uz velkama objekta!");
    }

    public void OnBeginDrag(PointerEventData data)
    {   
        //selectedHair = OtherScriptHolder.GetComponent<Image>().SelectedHairIndex;
        Hair.GetComponent<RunningScriptHair>().Spritez = 0;
        Debug.Log(selectedHairI+"testtt");
    }
    public void enableAnimation(bool value){
        //Debug.Log(value);
        updateHair();
        Shirt.GetComponent<RunningScript>().Enabled = value;
        Head.GetComponent<RunningScript>().Enabled = value;

        Hair.GetComponent<RunningScriptHair>().Enabled = value;
        Hair.GetComponent<RunningScriptHair>().Spritez = 0;
        Pants.GetComponent<RunningScript>().Enabled = value;
        EyeWhites.GetComponent<RunningScript>().Enabled = value;
        Eye.GetComponent<RunningScript>().Enabled = value;
        Undershirt.GetComponent<RunningScript>().Enabled = value;
        Hands.GetComponent<RunningScript>().Enabled = value;
        Shoes.GetComponent<RunningScript>().Enabled = value;

        if(value==false){
            //Debug.Log(selectedHairI);
            
            Shirt.GetComponent<Image>().sprite = standShirt;
            Head.GetComponent<Image>().sprite = standHead;
            Hair.GetComponent<Image>().sprite = standHair;
            Pants.GetComponent<Image>().sprite = standPants;
            Undershirt.GetComponent<Image>().sprite = standUndershirt;
            Eye.GetComponent<Image>().sprite = standEye;
            EyeWhites.GetComponent<Image>().sprite = standEyeWhites;
            Hands.GetComponent<Image>().sprite = standHands;
            Shoes.GetComponent<Image>().sprite = standShoes;
        }
    }
    public void OnDrag(PointerEventData data)
    {
        enableAnimation(false);
        updateHair();
        Shirt.GetComponent<Image>().sprite = dragShirt;
        
        Head.GetComponent<Image>().sprite = dragHead;
        Hair.GetComponent<Image>().sprite = dragHair;
        Pants.GetComponent<Image>().sprite = dragPants;
        Undershirt.GetComponent<Image>().sprite = dragUndershirt;
        Eye.GetComponent<Image>().sprite = dragEye;
        EyeWhites.GetComponent<Image>().sprite = dragEyeWhites;
        Hands.GetComponent<Image>().sprite = dragHands;
        Shoes.GetComponent<Image>().sprite = dragShoes;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        float adjustedMinX = screenCenter.x + minX;
        float adjustedMaxX = screenCenter.x + maxX;
        float adjustedMinY = screenCenter.y + minY;
        float adjustedMaxY = screenCenter.y + maxY;

        mousePosition.x = Mathf.Clamp(mousePosition.x, adjustedMinX + rTransform.rect.width / 2, adjustedMaxX - rTransform.rect.width / 2);
        mousePosition.y = Mathf.Clamp(mousePosition.y, adjustedMinY + rTransform.rect.height / 2, adjustedMaxY - rTransform.rect.height / 2);

        rTransform.position = mousePosition;

        //Debug.Log("x=" + mousePosition.x + " un y=" + mousePosition.y);
    }


    public void OnEndDrag(PointerEventData data)
    {       

            Shirt.GetComponent<Image>().sprite = standShirt;
            Head.GetComponent<Image>().sprite = standHead;
            Hair.GetComponent<Image>().sprite = standHair;
            Pants.GetComponent<Image>().sprite = standPants;
            Undershirt.GetComponent<Image>().sprite = standUndershirt;
            Eye.GetComponent<Image>().sprite = standEye;
            EyeWhites.GetComponent<Image>().sprite = standEyeWhites;
            Hands.GetComponent<Image>().sprite = standHands;
            Shoes.GetComponent<Image>().sprite = standShoes;
            enableAnimation(ToggleButton.isOn);
        //Debug.Log("Objekts atlaists, vilkšana pārtraukta!");
    }
    private Sprite dragSprite(string component){
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+component+"/Player_"+component);
        Sprite dragSpr=null;
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == "Player_"+component+"_5")
            {
                dragSpr = sprite;
                break;
            }
        }
        return dragSpr;
    }
    private Sprite standSprite(string component){
        Sprite standSpr=null;
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+component+"/Player_"+component);
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == "Player_"+component+"_0")
            {
                standSpr = sprite;
                break;
            }
        }
        return standSpr;
    }
    private Sprite dragSprite2(string folder, string component){
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+folder+"/Player_"+component);
        Sprite dragSpr=null;
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == "Player_"+component+"_5")
            {
                dragSpr = sprite;
                break;
            }
        }
        return dragSpr;
    }
    private Sprite standSprite2(string folder,string component){
        Sprite standSpr=null;
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+folder+"/Player_"+component);
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == "Player_"+component+"_0")
            {
                standSpr = sprite;
                break;
            }
        }
        return standSpr;
    }
    public void changeHair(int index){
        if (selectedHairI+index<=0 || selectedHairI+index>50){

        }else{
            selectedHairI+=index;
            updateHairButtons();
            
        }   
    }
    public void updateHairButtons(){
            enableAnimation(false);
            standHair = standSprite2("Hair","Hair_"+selectedHairI);
            dragHair = dragSprite2("Hair","Hair_"+selectedHairI);
            if(selectedHairI>1){
            hairChoiceLeft.GetComponent<Image>().sprite = standSprite2("Hair","Hair_"+(selectedHairI-1));
            }
            else
            hairChoiceLeft.GetComponent<Image>().sprite = disabledButton;
            
            hairChoiceMiddle.GetComponent<Image>().sprite = standHair;
            
            if(selectedHairI<50){
            hairChoiceRight.GetComponent<Image>().sprite = standSprite2("Hair","Hair_"+(selectedHairI+1));
            }
            else
            hairChoiceRight.GetComponent<Image>().sprite = disabledButton;

            Hair.GetComponent<RunningScriptHair>().HairIndex = selectedHairI;
            enableAnimation(ToggleButton.isOn);
    }
    public void updateHair(){
            standHair = standSprite2("Hair","Hair_"+selectedHairI);
            dragHair = dragSprite2("Hair","Hair_"+selectedHairI);
            Hair.GetComponent<RunningScriptHair>().HairIndex = selectedHairI;
    }
}
