using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : CircuitComponent
{
    public Sprite powerOnImage;
    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = initialSprite;
        OutputEnergy = true;

        if (socket != null)
            SetComponentOnStart();
    }
    private void Update()
    {
        Debug.Log(EnergyOutput);
        CheckState();
    }

    public void CheckState()
    {
        if (socket != null)
        {
            if (socket.input != null)
            {
                if (socket.input.component != null && socket.input.component.EnergyOutput >= energyUsage)
                    gameObject.GetComponent<Image>().sprite = powerOnImage;
                else
                    gameObject.GetComponent<Image>().sprite = initialSprite;
            }
            else
                gameObject.GetComponent<Image>().sprite = initialSprite;
        }
        else
            gameObject.GetComponent<Image>().sprite = initialSprite;
    }
}
