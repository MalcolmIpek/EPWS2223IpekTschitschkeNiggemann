using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Switch : CircuitComponent
{
    public Sprite powerOnImage;

    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = initialSprite;
        OutputEnergy = false;
    }

    public void CheckState()
    {
        if (!OutputEnergy)
        {
            gameObject.GetComponent<Image>().sprite = powerOnImage;
            OutputEnergy = true;
        }
        else if (OutputEnergy)
        {
            gameObject.GetComponent<Image>().sprite = initialSprite;
            OutputEnergy = false;
        }
    }
}
