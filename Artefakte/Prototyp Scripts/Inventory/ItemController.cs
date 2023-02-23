using UnityEngine;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public bool interactable = true;

    void Pickup()
    {
        if (interactable)
        {
            InventoryManager.Instance.Add(item);
            Destroy(gameObject);
            InventoryManager.Instance.ListItems();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Pickup();
    }
}
