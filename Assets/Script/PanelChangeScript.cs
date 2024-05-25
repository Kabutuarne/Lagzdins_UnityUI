using UnityEngine;
using UnityEngine.UI;

public class PanelChangeScript  : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPanelPair
    {
        public Button button;
        public GameObject panel;
    }

    public ButtonPanelPair[] buttonPanelPairs;

    void Start()
    {
        foreach (var pair in buttonPanelPairs)
        {
            pair.panel.SetActive(false);
        }
        foreach (var pair in buttonPanelPairs)
        {
            ButtonPanelPair currentPair = pair;
            currentPair.button.onClick.AddListener(() => SwitchPanel(currentPair.panel));
        }
    }

    void SwitchPanel(GameObject panelToShow)
    {
        foreach (var pair in buttonPanelPairs)
        {
            pair.panel.SetActive(false);
        }
        panelToShow.SetActive(true);
    }
}
