using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/CreateNewItem")]

public class Item : ScriptableObject
{
    public string itemName;
    public int id;
    public List<string> droppableOn;
}