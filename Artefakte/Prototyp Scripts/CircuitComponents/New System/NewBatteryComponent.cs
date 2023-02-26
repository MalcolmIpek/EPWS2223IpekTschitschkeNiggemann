using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBatteryComponent : MonoBehaviour
{
    public Sprite batteryBurn;
    public Sprite battery;

    public bool isCircuit = false;

    void Update()
    {
        isCircuit = GetComponent<NewCircuitComponent>().IsCircuit();
        if (GetComponent<NewCircuitComponent>().IsCircuit() == true && GetComponent<NewCircuitComponent>().R < 1f) GetComponent<Image>().sprite = batteryBurn;
        else GetComponent<Image>().sprite = battery;
    }
}
