using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consumer : CircuitComponent
{
    public Sprite powerOnSprite;

    private void Awake()
    {
        OutputEnergy = true;
    }
    private void Update()
    {
        if(initialSprite== null)
        {
            if (EnergyInput > 0) GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            else GetComponent<Image>().color = new Color32(0, 0, 0, 160);
        }
        else
        {
            if (EnergyInput > 0) GetComponent<Image>().sprite = powerOnSprite;
            else GetComponent<Image>().sprite = initialSprite;
        }
    }
}
