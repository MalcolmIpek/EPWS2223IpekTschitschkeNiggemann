using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneCable : MonoBehaviour
{
    public NewCircuitComponent input;

    public Sprite lowVoltage;
    public Sprite midVoltage;
    public Sprite highVoltage;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = lowVoltage;
    }

    private void Update()
    {
        if (input.I == 0) GetComponent<SpriteRenderer>().sprite = lowVoltage;
        else if (input.I <= 5 && input.I > 1) GetComponent<SpriteRenderer>().sprite = midVoltage;
        else if(input.I > 1) GetComponent<SpriteRenderer>().sprite = highVoltage;
    }
}
