using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionScript : MonoBehaviour
{

    public Image characterComponent;
    public Image selectionIcon;

    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    void Start()
    {
        if (characterComponent != null)
        {
            Color initialColor = characterComponent.color;
            redSlider.value = initialColor.r;
            greenSlider.value = initialColor.g;
            blueSlider.value = initialColor.b;
        }
        redSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        greenSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        blueSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
    }
    public void UpdateColor()
    {
        if (characterComponent != null)
        {
            float r = redSlider.value;
            float g = greenSlider.value;
            float b = blueSlider.value;

            characterComponent.color = new Color(r, g, b, characterComponent.color.a);
        }
        if (selectionIcon != null)
        {
            float r = redSlider.value;
            float g = greenSlider.value;
            float b = blueSlider.value;

            selectionIcon.color = new Color(r, g, b, selectionIcon.color.a);
        }
    }
}
