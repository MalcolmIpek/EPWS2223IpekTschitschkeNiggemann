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

    private void Update()
    {
        if(circuitswitch.GetComponent<NewCircuitComponent>().EnergyOutputV >= neededEnergy && circuitswitch.GetComponent<NewCircuitComponent>().switchOutputEnergy == true) gameObject.GetComponent<Image>().sprite = opentex;
        else gameObject.GetComponent<Image>().sprite = closetex;
    }
}
