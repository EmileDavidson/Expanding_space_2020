using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationDoor : MonoBehaviour
{
    public GameObject door;
    public List<string> lijst = new List<string>();

    public void setDoor(bool value)
    {
        door.SetActive(value);
    }
}