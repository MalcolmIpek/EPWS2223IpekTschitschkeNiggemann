using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [HideInInspector]public Vector2 initialPosition;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        rectTransform= GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag!");
        initialPosition= rectTransform.anchoredPosition;
        canvasGroup.alpha= .6f;
        canvasGroup.blocksRaycasts= false;

        if (eventData.pointerDrag.GetComponent<CircuitComponent>().socket != null)
        {
            eventData.pointerDrag.GetComponent<CircuitComponent>().socket.holdsCircuitComponent = false;
            eventData.pointerDrag.GetComponent<CircuitComponent>().socket.component = null;
            eventData.pointerDrag.GetComponent<CircuitComponent>().socket = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("On dragging!");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag!");
        if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "CircuitComponent")
            rectTransform.anchoredPosition = initialPosition;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts= true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Drag!");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropping item");
    }
}
