using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationPressurePlate : MonoBehaviour
{
    public GameObject MainObject;
    public string color;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER");
        MainObject.GetComponent<CombinationDoor>().lijst.Add(color);
    }
}