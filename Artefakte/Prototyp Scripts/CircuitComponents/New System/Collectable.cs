using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject collectebleEntry;

    public void OnClick()
    {
        collectebleEntry.SetActive(true);
        Destroy(gameObject);
    }
}
