using UnityEngine;
using UnityEngine.UI;  

public class RunningScript : MonoBehaviour
{
    
    private Sprite[] spritess;
    private Sprtie[] sprites = new Sprites[13];
    public float changeInterval = 0.1f;
    public GameObject imageHolder;
    private float timer;
    private int currentSpriteIndex = 0;
    private bool enabled = true;
    private int hairIndex=1;
    public bool Enabled{
            get { return enabled; }
            set { enabled = value; 
                currentSpriteIndex = 0;
                    } 
        }
        public int HairIndex{
            get { return hairIndex; }
            set { hairIndex = value; 
                currentSpriteIndex = 0;
                    } 
        }
    void Start()
    {
        spritess = Resources.LoadAll<Sprite>("CharResources/Hair/Player_Hair_"+hairIndex);
            int i = 6;
            int j = 0;
        foreach (Sprite sprite in spritess)
        {
            if (sprite.name == "Player_"+i+"_"+i) // Japabeidz cuh
            {
                spritess[j] = sprite;
                i++;
                j++;
            }
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
}
        
