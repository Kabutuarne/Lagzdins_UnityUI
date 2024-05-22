using UnityEngine;
using UnityEngine.UI;  

public class RunningScript : MonoBehaviour
{
    
    public Sprite[] sprites;
    public float changeInterval = 0.1f;
    public GameObject imageHolder;
    private float timer;
    private int currentSpriteIndex = 0;
    private bool enabled = true;
    public bool Enabled{
            get { return enabled; }
            set { enabled = value; 
                currentSpriteIndex = 0;
                    } 
        }
    void Start()
    {
        if (sprites.Length > 0)
        {
            imageHolder.GetComponent<Image>().sprite = sprites[0];
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
        
