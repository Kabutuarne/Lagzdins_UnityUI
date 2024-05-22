using UnityEngine;
using UnityEngine.UI;  // Make sure to include this to use the Image component

public class RunningScript : MonoBehaviour
{
    public bool Enabled = false;
    public Sprite[] sprites;
    public float changeInterval = 0.1f;
    public GameObject imageHolder;
    private float timer;
    private int currentSpriteIndex = 0;

    void Start()
    {
        if (sprites.Length > 0)
        {
            imageHolder.GetComponent<Image>().sprite = sprites[0];
        }
    }

    void Update()
    {
        if(Enabled){
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
