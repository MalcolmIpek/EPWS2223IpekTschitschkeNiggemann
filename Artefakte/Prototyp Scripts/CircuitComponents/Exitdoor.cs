using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exitdoor : CircuitComponent
{
    public int powerRequired;
    public Sprite openSprite;

    private void Awake()
    {
        OutputEnergy = true;
    }
    private void Update()
    {
        if (EnergyInput == powerRequired)
            gameObject.GetComponent<Image>().sprite = openSprite;
        else
            gameObject.GetComponent<Image>().sprite = initialSprite;
    }
}
