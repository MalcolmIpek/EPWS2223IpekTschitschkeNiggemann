using UnityEngine;
using UnityEngine.EventSystems;

public class EnergyIOComponent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public IOType type;

    [SerializeField]
    private LineController lineprefab;
    LineController newLine;

    public NewCircuitComponent component;

    private void Awake()
    {
        if(component== null) { component = transform.parent.GetComponent<NewCircuitComponent>(); }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(lineprefab != null)
        {
            //wenn noch kein Kabel von dieser Node ausgeht
            if (newLine == null)
            {
                newLine = Instantiate(lineprefab);
                newLine.SetInput(this);
                newLine.transform.SetParent(GameObject.Find("Fusebox UI Element").transform);
                newLine.SetPositionOne(newLine.cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 8.5f));

                if (type == IOType.INPUT)
                    newLine.input = this;
                else
                    newLine.output = this;
            }
            //Wenn schon ein Kabel von dieser Node ausgeht
            else
            {
                if (type == IOType.INPUT)
                    component.Input = null;
                else
                    newLine.input.component.Input = null;

                Destroy(newLine.gameObject);
                newLine = Instantiate(lineprefab);
                newLine.SetInput(this);
                newLine.transform.SetParent(GameObject.Find("Fusebox UI Element").transform);
                newLine.SetPositionOne(newLine.cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 8.5f));

                if (type == IOType.INPUT)
                    newLine.input = this;
                else
                    newLine.output = this;
            }
        }
    }

    bool CheckIOComponentOnDrop(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null
            && eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>()
            && eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>().type != type
            && eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>().component != component
            && eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>().newLine == null)
            return true;
        return false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (lineprefab != null)
        {
            if (CheckIOComponentOnDrop(eventData))
            {
                newLine.SetPositionTwo(newLine.cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 8.5f));

                eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>().newLine = newLine;

                //Wenn das Kabel auf eine Node gezogen wird, die als Input markiert ist, setzen wir den Input dieser Komponente auf die ursprüngliche Komponente
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>().type == IOType.INPUT)
                    eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>().component.Input = component;
                //Ansonsten setzten wir die ursprüngliche Komponenten auf die Komponente der aktuellen Node
                else
                    component.Input = eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>().component;

                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>().type == IOType.INPUT)
                    newLine.input = eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>();
                else
                    newLine.output = eventData.pointerCurrentRaycast.gameObject.GetComponent<EnergyIOComponent>();
            }
            else
            {
                Destroy(newLine.gameObject);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(lineprefab != null)
        {
            newLine.SetPositionTwo(newLine.cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 8.5f));
        }
    }    
}

public enum IOType { INPUT, OUTPUT }
