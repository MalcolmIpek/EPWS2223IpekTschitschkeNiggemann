using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCircuitSwitch : MonoBehaviour
{
    public Sprite on;
    public Sprite off;

    public void OnSwitchClick()
    {
        if (gameObject.GetComponent<NewCircuitComponent>().switchOutputEnergy == false)
        {
            gameObject.GetComponent<NewCircuitComponent>().switchOutputEnergy = true;
            gameObject.GetComponent<Image>().sprite = on;
        }
        else
        {
            gameObject.GetComponent<NewCircuitComponent>().switchOutputEnergy = false;
            gameObject.GetComponent<Image>().sprite = off;
        }
    }
}
