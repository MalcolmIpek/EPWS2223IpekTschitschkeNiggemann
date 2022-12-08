using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : CircuitComponent
{
    public float generatedEnergy;
    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = initialSprite;
        EnergyOutput = generatedEnergy;
        OutputEnergy = true;

        if (socket != null)
            SetComponentOnStart();
    }
}
