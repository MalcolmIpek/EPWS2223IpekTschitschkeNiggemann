using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Switch : CircuitComponent
{
    public Sprite powerOnImage;

    public int state = 0;
    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = initialSprite;
        OutputEnergy = false;

        if (socket != null)
            SetComponentOnStart();
    }
    private void Update()
    {
        CheckState();
    }

    public void CheckState()
    {
        if (socket != null)
        {
            if (Input.GetButtonDown("Right Mousebutton"))
            {
                if (state == 0)
                {
                    state = 1;
                    gameObject.GetComponent<Image>().sprite = powerOnImage;
                    OutputEnergy = true;
                }
                else if (state == 1)
                {
                    state = 0;
                    gameObject.GetComponent<Image>().sprite = initialSprite;
                    OutputEnergy = false;
                }
            }
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = initialSprite;
            state= 0;
            OutputEnergy = false;
        }
    }
}
