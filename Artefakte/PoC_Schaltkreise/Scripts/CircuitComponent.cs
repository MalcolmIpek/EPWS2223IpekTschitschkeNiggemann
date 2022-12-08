using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CircuitComponent: MonoBehaviour
{
    public Socket socket;
    public Sprite initialSprite;
    public float energyUsage = 0f;
    public float resistance = 0f;

    private bool outputEnergy = true;
    public bool OutputEnergy
    {
        set { outputEnergy = value; }
        get { return outputEnergy; }
    }
    //fix energy output
    private float energyOutput = 0f;
    public float EnergyInput 
    {
        get 
        {
            if(socket!= null)
                if(socket.input != null)
                    if(socket.input.component!= null)
                        return socket.input.component.EnergyOutput;
            return 0f;
        } 
    }
    //energy output combined with all outputs before
    public float EnergyOutput 
    {
        set { energyOutput= value; }
        get 
        {
            if(OutputEnergy)
                return EnergyInput + energyOutput - energyUsage;
            return 0f;
        } 
    }

    public void SetComponentOnStart()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = socket.gameObject.GetComponent<RectTransform>().anchoredPosition;
        socket.holdsCircuitComponent = true;
        socket.component = this;
    }
}
