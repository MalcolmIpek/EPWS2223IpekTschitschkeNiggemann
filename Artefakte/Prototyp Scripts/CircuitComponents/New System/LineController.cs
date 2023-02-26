using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public EnergyIOComponent input;
    public EnergyIOComponent output;

    [SerializeField]
    private Texture lowVTexture;
    [SerializeField]
    private Texture midVTexture;
    [SerializeField]
    private Texture highVTexture;

    private Vector3 startPos = new Vector3(0, 0, 0);
    private Vector3 endPos = new Vector3(0, 0, 0);

    public Camera cam;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        cam = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        ResetPositions();

        SetCableTexture();
    }

    public void SetPositionOne(Vector3 _startPosition)
    {
        startPos = _startPosition;
    }
    public void SetPositionTwo(Vector3 _endPosition)
    {
        endPos = _endPosition;
    }
    public void SetInput(EnergyIOComponent _input)
    {
        input = _input;
    }

    public void ResetPositions()
    {
        if(input != null && output != null)
        {
            SetPositionOne(input.gameObject.transform.position + new Vector3(0,0,-.5f));
            SetPositionTwo(output.gameObject.transform.position + new Vector3(0, 0, -.5f));            
        }
    }

    public void SetCableTexture()
    {
        if(output!= null)
        {
            if (output.component.I == 0) lineRenderer.material.mainTexture = lowVTexture;
            else if (output.component.I <= 5) lineRenderer.material.mainTexture = midVTexture;
            else lineRenderer.material.mainTexture = highVTexture;
        }
    }
}
