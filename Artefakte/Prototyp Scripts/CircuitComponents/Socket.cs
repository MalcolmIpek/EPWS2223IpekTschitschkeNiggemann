using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Socket : MonoBehaviour
{
    public bool holdsCircuitComponent = false;
    public CircuitComponent component;

    public Socket input;

    public List<GameObject> outputWire;
    private Color32 wireColorOn = new(255, 255, 255, 255);
    private Color32 wireColorOff = new(70, 70, 70, 255);

    public float EnergyInput
    {
        get
        {
            if(component != null) return component.EnergyInput;
            else if(input != null) return input.EnergyInput;
            return 0f;
        }
    }
    public float EnergyOutput
    {
        get
        {
            if(component != null) return component.EnergyOutput;
            else if(input != null) return input.EnergyOutput;
            return 0f;
        }
    }

    private void Update()
    {
        ChangeWireColor();
    }

    public void PlaceCircuitComponent(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && holdsCircuitComponent == false)
        {
            eventData.pointerDrag.transform.SetParent(gameObject.GetComponent<RectTransform>(), false);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            component = eventData.pointerDrag.GetComponent<CircuitComponent>();
            component.socket = this;
            holdsCircuitComponent = true;
        }
        else if (eventData.pointerDrag != null && holdsCircuitComponent == true)
        {
            Debug.Log("Cannot Drop! Socket already holds component!");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<DragAndDrop>().initialPosition;
        }
    }

    private void ChangeWireColor()
    {
        if(outputWire!= null)
        {
            if (EnergyOutput > 0f)
            {
                foreach(var wire in outputWire)
                    wire.GetComponent<Image>().color = wireColorOn;
            }
            else
            {
                foreach (var wire in outputWire)
                    wire.GetComponent<Image>().color = wireColorOff;
            }
        }        
    }
}
