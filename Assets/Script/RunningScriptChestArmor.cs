using UnityEngine;
using UnityEngine.UI;  

public class RunningScriptChestArmor : MonoBehaviour
{
    
    private Sprite[] spritess;
    private Sprite[] sprites = new Sprite[13];
    public float changeInterval = 0.1f;
    public GameObject imageHolder;
    private float timer;
    private int currentSpriteIndex = 0;
    private bool enabled = true;
    private int chestIndex=1;
    public int Spritez{
        get{return 0;}
        set{changeSprites();}
    }

    public bool Enabled{
            get { return enabled; }
            set { enabled = value; 
                currentSpriteIndex = 0;
                    } 
        }
        public int ChestIndex{
            get { return chestIndex; }
            set { chestIndex = value; 
                currentSpriteIndex = 0;
                    } 
        }
    void Start()
    {
        spritess = Resources.LoadAll<Sprite>("CharResources/Armor/ArmorBody/Armor_Body_"+chestIndex);
            int i=0;
            for(int j=6;j<=18;j++){
                sprites[i]=spritess[j];
                i++;
            }
            
    }

    void Update()
    {
        if(enabled){
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            timer = 0f;
            currentSpriteIndex++;

            if (currentSpriteIndex >= sprites.Length)
            {
                currentSpriteIndex = 0;
            }

           
            imageHolder.GetComponent<Image>().sprite = sprites[currentSpriteIndex];
        }
    }
    }
    private void changeSprites(){
        spritess = Resources.LoadAll<Sprite>("CharResources/Armor/ArmorBody/Armor_Body_"+chestIndex);
            int i=0;
            for(int j=6;j<=18;j++){
                sprites[i]=spritess[j];
                i++;
            }
    }
}
        
