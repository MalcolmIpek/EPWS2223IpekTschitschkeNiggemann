using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public int neededEnergy = 0;
    public GameObject circuitswitch;
    public GameObject safeUI;
    public bool canBeOpened = false;

    private void Update()
    {
        if ((circuitswitch.GetComponent<NewCircuitComponent>().I <= neededEnergy && circuitswitch.GetComponent<NewCircuitComponent>().I >= neededEnergy - 1) && circuitswitch.GetComponent<NewCircuitComponent>().switchOutputEnergy == true) canBeOpened = true;
        else canBeOpened = false;
    }
    
    public void OpenSafe()
    {
        if(canBeOpened== true) safeUI.SetActive(true);
    }
}
