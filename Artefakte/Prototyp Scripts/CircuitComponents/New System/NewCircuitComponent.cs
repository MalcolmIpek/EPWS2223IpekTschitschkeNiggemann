using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewCircuitComponent : MonoBehaviour
{
    public float globalCurrent;
    public ComponentType type;

    public Item item;

    public NewCircuitComponent Input;

    public bool isInInventory = true;


    public bool switchOutputEnergy = true;

    public bool outputEnergy = false;

    public float producedEnergy = 0f;
    public float LocalVoltage { get { if (producedEnergy != 0) return producedEnergy; else return U * (LocalResistance / R); } }
    public float U
    {
        get
        {
            if (Input == null) return 0f;

            float sum = 0f;
            NewCircuitComponent currentComponent = this;

            do
            {
                sum += currentComponent.producedEnergy;
                currentComponent = currentComponent.Input;
            } while (currentComponent != this && currentComponent.Input != null);
            
            if(currentComponent == null) return 0f;

            if (switchOutputEnergy == false) return 0f;
            
            return sum;
        }
    }
    [Range(0.0001f, 1000)]
    public float LocalResistance = 0.01f;
    public float R
    {
        get
        {
            if (Input == null) return 0f;

            float sum = 0f;
            NewCircuitComponent currentComponent = this;

            do
            {
                sum += currentComponent.LocalResistance;
                currentComponent = currentComponent.Input;
            } while (currentComponent != this && currentComponent.Input != null);

            if (currentComponent == null) return 0f;

            return sum;
        }
    }
    public float LocalElectricCurrent { get { return LocalVoltage / LocalResistance; } }
    public float I { get { return U / R; } }

    public bool IsCircuit()
    {
        NewCircuitComponent currentComponent = this;

        if(Input == null) return false;

        while (currentComponent.Input != this && currentComponent.Input != null)
        {
            currentComponent = currentComponent.Input;
        }

        currentComponent = currentComponent.Input;

        if(currentComponent == null) return false;

        if (currentComponent == this) return true;

        return false;
    }
    private void Update()
    {
        globalCurrent = I;
    }
}

public enum ComponentType { ENERGYSOURCE, RESISTANCE, POWERUSER, SWITCH}
