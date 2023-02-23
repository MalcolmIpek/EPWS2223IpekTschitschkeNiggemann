using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public Vector2 initialPosition;

    private void Awake()
    {
        canvas = GameObject.Find("UI").GetComponent<Canvas>();
        rectTransform= GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition= gameObject.GetComponent<RectTransform>().anchoredPosition;
        gameObject.transform.SetParent(GameObject.Find("UI").transform);
        canvasGroup.alpha= .6f;
        canvasGroup.blocksRaycasts= false;

        if (eventData.pointerDrag.GetComponent<CircuitComponent>().socket != null)
        {
            eventData.pointerDrag.GetComponent<CircuitComponent>().RemoveFromSocket();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        string tag;
        if (eventData.pointerCurrentRaycast.gameObject == null) tag = "Untagged";
        else tag = eventData.pointerCurrentRaycast.gameObject.tag;

        switch (tag)
        {
            case "Inventory":
                if (!gameObject.GetComponent<CircuitComponent>().isInInventory)
                {
                    InventoryManager.Instance.Add(gameObject.GetComponent<CircuitComponent>().item);
                    gameObject.GetComponent<CircuitComponent>().isInInventory = true;
                }
                gameObject.transform.SetParent(GameObject.Find("Content").transform);
                break;
            case "CircuitPuzzle":
                if (gameObject.GetComponent<CircuitComponent>().isInInventory)
                {
                    gameObject.GetComponent<CircuitComponent>().isInInventory = false;
                    InventoryManager.Instance.Remove(gameObject.GetComponent<CircuitComponent>().item);
                    InventoryManager.Instance.ListItems();
                }
                gameObject.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                break;
            case "Socket":
                if (gameObject.GetComponent<CircuitComponent>().isInInventory)
                {
                    gameObject.GetComponent<CircuitComponent>().isInInventory = false;
                    InventoryManager.Instance.Remove(gameObject.GetComponent<CircuitComponent>().item);
                    InventoryManager.Instance.ListItems();
                }
                eventData.pointerCurrentRaycast.gameObject.GetComponent<Socket>().PlaceCircuitComponent(eventData);
                gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(.5f, .5f);
                gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(.5f, .5f);
                gameObject.GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
                break;
            default:
                if (!gameObject.GetComponent<CircuitComponent>().isInInventory)
                {
                    InventoryManager.Instance.Add(gameObject.GetComponent<CircuitComponent>().item);
                    gameObject.GetComponent<CircuitComponent>().isInInventory = true;
                }
                gameObject.transform.SetParent(GameObject.Find("Content").transform);
                break;
        }


        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts= true;        
        if(eventData.pointerPressRaycast.gameObject != null) initialPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }
   
    public void OnPointerDown(PointerEventData eventData){}

    public void OnDrop(PointerEventData eventData){}
}
