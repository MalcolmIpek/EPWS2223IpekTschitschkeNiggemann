using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Socket : MonoBehaviour, IDropHandler
{
    public bool holdsCircuitComponent = false;
    public CircuitComponent component;

    public Socket input;
    //public Socket[] output;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && holdsCircuitComponent == false)
        {
            Debug.Log("Dropping!");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
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
}
