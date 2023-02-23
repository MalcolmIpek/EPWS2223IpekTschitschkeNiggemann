using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Material outlineMaterial;
    private Material defaultMaterial;

    private void Awake()
    {
        defaultMaterial = GetComponent<Image>().material;
        outlineMaterial = Resources.Load<Material>("Outline");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().material = outlineMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().material = defaultMaterial;
    }
}
