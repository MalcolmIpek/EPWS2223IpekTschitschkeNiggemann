using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstInteractionPopUp : MonoBehaviour
{
    public bool firstInteraction = true;
    public GameObject popup;

    public void OnFirstInteraction()
    {
        if (firstInteraction)
        {
            popup.SetActive(true);
        }        
        firstInteraction = false;
    }
}
