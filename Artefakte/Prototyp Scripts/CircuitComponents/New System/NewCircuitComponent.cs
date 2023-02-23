using System.Collections.Generic;
using UnityEngine;

public class NewCircuitComponent : MonoBehaviour
{
    public float testoutput;

    //public EnergyIOComponent input;
    //public EnergyIOComponent output;
    public Item item;

    public NewCircuitComponent Input;

    public bool isInInventory = true;

    [Range(0.01f,1000)]
    public float resistanceO = 1;

    public bool switchOutputEnergy = true;

    public bool outputEnergy = false;
    public float energyProducedV = 0f;
    public float EnergyProduced
    {
        get { return energyProducedV; }
        set { energyProducedV = value; }
    }

    public float EnergyOutputV
    {
        get
        {
            if(switchOutputEnergy) 
                if(outputEnergy) 
                    return (EnergyInputV(this, 0f) * resistanceO + energyProducedV) / resistanceO;
            return 0f;
        }
    }
    public float EnergyInputV(Component originalInput, float totalenergy)
    {
        if (Input == null) return 0f;
        else if (Input.Input == originalInput) return Input.energyProducedV;
        else return Input.EnergyInputV(originalInput, totalenergy * resistanceO + energyProducedV);
    }

    public bool CheckCircuit()
    {
        List<NewCircuitComponent> visitedObjects = new List<NewCircuitComponent>();

        NewCircuitComponent currentObject = this;

        while (!visitedObjects.Contains(currentObject))
        {
            visitedObjects.Add(currentObject);

            currentObject = currentObject.Input;

            if (currentObject == null) { foreach (var comp in visitedObjects) comp.outputEnergy = false;  return false; }
        }

        foreach (var comp in visitedObjects) comp.outputEnergy = true;

        return true;
    }

    private void Update()
    {
        testoutput = EnergyOutputV;
    }
}
