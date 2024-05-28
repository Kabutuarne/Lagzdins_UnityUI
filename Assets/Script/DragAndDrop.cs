using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, 
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject Hair,Head,Eye,EyeWhites,Shirt,Undershirt,Hands,Pants,Shoes,ArmorLegs,ArmorChest,Cloak;
    public Toggle ToggleButton;
    private RectTransform rTransform;
    public Canvas canv;
    private Sprite dragHair,dragHead,standHead, standHair, standEye, dragEye, standEyeWhites, dragEyeWhites, standShirt,
    dragShirt,standUndershirt,dragUndershirt,dragHands,standHands,dragPants,standPants,standShoes,dragShoes,standArmorLegs,dragArmorLegs,
    standArmorChest,dragArmorChest,cloakStill;
    private RunningScript runningScript;
    private RunningScriptHair runningScriptHair;
    private RunningScriptChestArmor runningScriptChestArmor;
    private RunningScriptLegsArmor runningScriptLegsArmor;
    private DragAndDrop dragAndDrop;
    private int selectedHairI=1,selectedArmorChestI=1,selectedArmorLegsI=1;

    private string gender = "Player"; // "Player" or "Female" (for future)
    
    public string Gender{ // (for future)
        set{gender=value;}
        get{return gender;}
    }

    public int SelectedHairI{
        set{selectedHairI=value;}
        get{return selectedHairI;}
    }
    
    public int SelectedArmorLegsI{
        set{selectedArmorLegsI=value;}
        get{return selectedArmorLegsI;}
    }

    public int SelectedArmorChestI{
        set{selectedArmorChestI=value;}
        get{return selectedArmorChestI;}
    }
    public Sprite DragHair{
        set{dragHair=value;}
        get{return dragHair;}
    }
    public Sprite StandHair{
        set{standHair=value;}
        get{return standHair;}
    }
    public Sprite DragArmorLegs{
        set{dragArmorLegs=value;}
        get{return dragArmorLegs;}
    }
    public Sprite StandArmorLegs{
        set{standArmorLegs=value;}
        get{return standArmorLegs;}
    }
    public Sprite DragArmorChest{
        set{dragArmorChest=value;}
        get{return dragArmorChest;}
    }
    public Sprite StandArmorChest{
        set{standArmorChest=value;}
        get{return standArmorChest;}
    }

    public GameObject OtherScriptHolder;


    public float minX, maxX, minY, maxY;
    public GameObject hairChoiceLeft,hairChoiceMiddle,hairChoiceRight;

    public GameObject chestChoiceLeft,chestChoiceMiddle,chestChoiceRight; 

    public GameObject legsChoiceLeft,legsChoiceMiddle,legsChoiceRight; 
    public Sprite disabledButton;


    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        //changeHair(0);

        //Standing Sprites:
        //cloak
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/WizardCloak");
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == "WizardCloak_0")
            {
                cloakStill = sprite;
                break;
            }
        }
        ////
        standArmorChest = standSprite3("Armor/ArmorBody","Armor_Body_"+selectedArmorChestI);
        standArmorLegs = standSprite3("Armor/ArmorLegs","Armor_Legs_"+selectedArmorLegsI);

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
        dragArmorChest = dragSprite3("Armor/ArmorBody","Armor_Body_"+selectedArmorChestI);
        dragArmorLegs = dragSprite3("Armor/ArmorLegs","Armor_Legs_"+selectedArmorLegsI);

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

        
        //Debug.Log("Izdarīts klikšis uz velkama objekta!");
    }

    public void OnBeginDrag(PointerEventData data)
    {   
        
        Hair.GetComponent<RunningScriptHair>().Spritez = 0;
        ArmorChest.GetComponent<RunningScriptChestArmor>().Spritez = 0;
        ArmorLegs.GetComponent<RunningScriptLegsArmor>().Spritez = 0;

        selectedHairI = OtherScriptHolder.GetComponent<DragAndDrop>().SelectedHairI;
        selectedArmorChestI = OtherScriptHolder.GetComponent<DragAndDrop>().SelectedArmorChestI;
        selectedArmorLegsI = OtherScriptHolder.GetComponent<DragAndDrop>().SelectedArmorLegsI;


        Debug.Log(selectedHairI+"testtt");
    }
    public void enableAnimation(bool value){
        //Debug.Log(value);
        
        updateElements();
        Shirt.GetComponent<RunningScript>().Enabled = value;
        Head.GetComponent<RunningScript>().Enabled = value;
        
        Hair.GetComponent<RunningScriptHair>().Enabled = value;
        Hair.GetComponent<RunningScriptHair>().Spritez = 0;
        
        ArmorChest.GetComponent<RunningScriptChestArmor>().Enabled = value;
        ArmorChest.GetComponent<RunningScriptChestArmor>().Spritez = 0;

        ArmorLegs.GetComponent<RunningScriptLegsArmor>().Enabled = value;
        ArmorLegs.GetComponent<RunningScriptLegsArmor>().Spritez = 0;

        Pants.GetComponent<RunningScript>().Enabled = value;
        EyeWhites.GetComponent<RunningScript>().Enabled = value;
        Eye.GetComponent<RunningScript>().Enabled = value;
        Undershirt.GetComponent<RunningScript>().Enabled = value;
        Hands.GetComponent<RunningScript>().Enabled = value;
        Shoes.GetComponent<RunningScript>().Enabled = value;

        if(value==false){
            //Debug.Log(selectedHairI);
            
            ArmorChest.GetComponent<Image>().sprite = standArmorChest;
            ArmorLegs.GetComponent<Image>().sprite = standArmorLegs;

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
        Hair.GetComponent<RunningScriptHair>().Spritez = 0;
        selectedHairI = OtherScriptHolder.GetComponent<DragAndDrop>().SelectedHairI;

        ArmorChest.GetComponent<RunningScriptChestArmor>().Spritez = 0;
        selectedArmorChestI = OtherScriptHolder.GetComponent<DragAndDrop>().SelectedArmorChestI;

        ArmorLegs.GetComponent<RunningScriptLegsArmor>().Spritez = 0;
        selectedArmorLegsI = OtherScriptHolder.GetComponent<DragAndDrop>().SelectedArmorLegsI;

        updateElements();
        Shirt.GetComponent<Image>().sprite = dragShirt;
        Head.GetComponent<Image>().sprite = dragHead;

        ArmorChest.GetComponent<Image>().sprite = dragArmorChest;
        ArmorLegs.GetComponent<Image>().sprite = dragArmorLegs;

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
            //Hair.GetComponent<Image>().sprite = standHair;
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
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+component+"/"+gender+"_"+component);
        Sprite dragSpr=null;
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == gender+"_"+component+"_5")
            {
                dragSpr = sprite;
                break;
            }
        }
        return dragSpr;
    }
    private Sprite standSprite(string component){
        Sprite standSpr=null;
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+component+"/"+gender+"_"+component);
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
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+folder+"/"+gender+"_"+component);
        Sprite dragSpr=null;
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == gender+"_"+component+"_5")
            {
                dragSpr = sprite;
                break;
            }
        }
        return dragSpr;
    }
    private Sprite standSprite2(string folder,string component){
        Sprite standSpr=null;
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+folder+"/"+gender+"_"+component);
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == gender+"_"+component+"_0")
            {
                standSpr = sprite;
                break;
            }
        }
        return standSpr;
    }
    private Sprite dragSprite3(string folder, string component){
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+folder+"/"+component);
        Sprite dragSpr=null;
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == component+"_5")
            {
                dragSpr = sprite;
                break;
            }
        }
        return dragSpr;
    }
    private Sprite standSprite3(string folder,string component){
        Sprite standSpr=null;
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharResources/"+folder+"/"+component);
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == component+"_0")
            {
                standSpr = sprite;
                break;
            }
        }
        return standSpr;
    }
    ///////////////////////////////////////////////////////////////
    public void changeHair(int index){
        if (selectedHairI+index<=0 || selectedHairI+index>51){
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
            
            if(selectedHairI<=51){
            hairChoiceRight.GetComponent<Image>().sprite = standSprite2("Hair","Hair_"+(selectedHairI+1));
            }
            else
            hairChoiceRight.GetComponent<Image>().sprite = disabledButton;

            Hair.GetComponent<RunningScriptHair>().HairIndex = selectedHairI;
            enableAnimation(ToggleButton.isOn);
    }
    ///////////////////////////////////////////////////////////////////
    public void updateElements(){

            standHair = standSprite2("Hair","Hair_"+selectedHairI);
            dragHair = dragSprite2("Hair","Hair_"+selectedHairI);

            standArmorChest = standSprite3("Armor/ArmorBody","Armor_Body_"+selectedArmorChestI);
            dragArmorChest = dragSprite3("Armor/ArmorBody","Armor_Body_"+selectedArmorChestI);

            standArmorLegs = standSprite3("Armor/ArmorLegs","Armor_Legs_"+selectedArmorLegsI);
            dragArmorLegs = dragSprite3("Armor/ArmorLegs","Armor_Legs_"+selectedArmorLegsI);

            ArmorLegs.GetComponent<RunningScriptLegsArmor>().LegsIndex = selectedArmorLegsI;
            ArmorChest.GetComponent<RunningScriptChestArmor>().ChestIndex = selectedArmorChestI;
            Hair.GetComponent<RunningScriptHair>().HairIndex = selectedHairI;
    }
    public void changeArmorChest(int index){
        if (selectedArmorChestI+index<=0 || selectedArmorChestI+index>50){
        }else{
            selectedArmorChestI+=index;
            updateArmorChestButtons();
        }   
    }
    public void updateArmorChestButtons(){
            enableAnimation(false);
            standArmorChest = standSprite3("Armor/ArmorBody","Armor_Body_"+selectedArmorChestI);
            dragArmorChest = dragSprite3("Armor/ArmorBody","Armor_Body_"+selectedArmorChestI);
            if(selectedArmorChestI>1){
            chestChoiceLeft.GetComponent<Image>().sprite = standSprite3("Armor/ArmorBody","Armor_Body_"+(selectedArmorChestI-1));
            }
            else
            chestChoiceLeft.GetComponent<Image>().sprite = disabledButton;
            
            chestChoiceMiddle.GetComponent<Image>().sprite = standArmorChest;
            
            if(selectedArmorChestI<50){
            chestChoiceRight.GetComponent<Image>().sprite = standSprite3("Armor/ArmorBody","Armor_Body_"+(selectedArmorChestI+1));
            }
            else
            chestChoiceRight.GetComponent<Image>().sprite = disabledButton;

            ArmorChest.GetComponent<RunningScriptChestArmor>().ChestIndex = selectedArmorChestI;
            enableAnimation(ToggleButton.isOn);
    }
    //////////////////////////////////////////////////////////////////////////
        public void changeArmorLegs(int index){
        if (selectedArmorLegsI+index<=0 || selectedArmorLegsI+index>50){
        }else{
            selectedArmorLegsI+=index;
            updateArmorLegsButtons();
        }   
    }
    public void updateArmorLegsButtons(){
            enableAnimation(false);
            standArmorLegs = standSprite3("Armor/ArmorLegs","Armor_Legs_"+selectedArmorLegsI);
            dragArmorLegs = dragSprite3("Armor/ArmorLegs","Armor_Legs_"+selectedArmorLegsI);
            if(selectedArmorLegsI>1){
            legsChoiceLeft.GetComponent<Image>().sprite = standSprite3("Armor/ArmorLegs","Armor_Legs_"+(selectedArmorLegsI-1));
            }
            else
            legsChoiceLeft.GetComponent<Image>().sprite = disabledButton;
            
            legsChoiceMiddle.GetComponent<Image>().sprite = standArmorLegs;
            
            if(selectedArmorLegsI<50){
            legsChoiceRight.GetComponent<Image>().sprite = standSprite3("Armor/ArmorLegs","Armor_Legs_"+(selectedArmorLegsI+1));
            }
            else
            legsChoiceRight.GetComponent<Image>().sprite = disabledButton;

            ArmorLegs.GetComponent<RunningScriptLegsArmor>().LegsIndex = selectedArmorLegsI;
            enableAnimation(ToggleButton.isOn);
    }
}
