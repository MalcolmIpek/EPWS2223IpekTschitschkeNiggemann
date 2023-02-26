using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Sprite opentex;
    public Sprite closetex;
    public int neededEnergy = 0;
    public GameObject circuitswitch;

    public bool isOpen = false;

    private void Update()
    {
        if((circuitswitch.GetComponent<NewCircuitComponent>().I <= neededEnergy && circuitswitch.GetComponent<NewCircuitComponent>().I >= neededEnergy - 1) && circuitswitch.GetComponent<NewCircuitComponent>().switchOutputEnergy == true)
        {
            gameObject.GetComponent<Image>().sprite = opentex;
            isOpen = true;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = closetex;
            isOpen = false;
        }
    }
}
