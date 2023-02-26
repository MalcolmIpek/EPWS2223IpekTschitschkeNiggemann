using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLamp : MonoBehaviour
{
    public Sprite lampOn;
    public Sprite lampOff;

    public GameObject blende;
    public GameObject NewSwitch;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = lampOff;
    }

    private void Update()
    {
        if (GetComponent<NewCircuitComponent>().I > 1 && NewSwitch.GetComponent<NewCircuitComponent>().switchOutputEnergy == true)
        {
            GetComponent<SpriteRenderer>().sprite = lampOn;
            blende.SetActive(false);
        }
        else 
        {
            GetComponent<SpriteRenderer>().sprite = lampOff;
            blende.SetActive(true);
        }
    }
}
